using System;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Collections.Generic;
using PocSwagger;
using Swagger.Net.Application;
using Swagger.Net;
using System.Net.Http;
using PocSwagger.Attributes;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace PocSwagger
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.MultipleApiVersions(
                            (apiDesc, targetApiVersion) => ResolveVersionSupportByRouteConstraint(apiDesc, targetApiVersion),
                            (vc) =>
                            {
                                vc.Version("v2", "Teste API V2");
                                vc.Version("v1", "Teste API V1");
                            });
                        c.DocumentFilter<HideInDocsFilter>();
                        c.AccessControlAllowOrigin("*");
                        c.RootUrl(ResolveBasePath);
                        c.IncludeAllXmlComments(thisAssembly, AppDomain.CurrentDomain.BaseDirectory);
                        c.IgnoreIsSpecifiedMembers();
                        c.DescribeAllEnumsAsStrings(camelCase: false);
                    })
                .EnableSwaggerUi(c =>
                    {
                        c.ShowExtensions(true);
                        c.UImaxDisplayedTags(100);
                        c.UIfilter("''");
                    });
        }

        public static bool ResolveVersionSupportByRouteConstraint(ApiDescription apiDesc, string targetApiVersion)
        {
            return (apiDesc.Route.RouteTemplate.ToLower().Contains(targetApiVersion.ToLower()));
        }

        private class ApplyDocumentVendorExtensions : IDocumentFilter
        {
            public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
            {
                // Include the given data type in the final SwaggerDocument
                //
                //schemaRegistry.GetOrRegister(typeof(ExtraType));
            }
        }

        public class AssignOAuth2SecurityRequirements : IOperationFilter
        {
            public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
            {
                // Correspond each "Authorize" role to an oauth2 scope
                var scopes = apiDescription.ActionDescriptor.GetFilterPipeline()
                    .Select(filterInfo => filterInfo.Instance)
                    .OfType<AuthorizeAttribute>()
                    .SelectMany(attr => attr.Roles.Split(','))
                    .Distinct();

                if (scopes.Any())
                {
                    if (operation.security == null)
                        operation.security = new List<IDictionary<string, IEnumerable<string>>>();

                    var oAuthRequirements = new Dictionary<string, IEnumerable<string>>
                    {
                        { "oauth2", scopes }
                    };

                    operation.security.Add(oAuthRequirements);
                }
            }
        }

        private class ApplySchemaVendorExtensions : ISchemaFilter
        {
            public void Apply(Schema schema, SchemaRegistry schemaRegistry, Type type)
            {
                // Modify the example values in the final SwaggerDocument
                //
                if (schema.properties != null)
                {
                    foreach (var p in schema.properties)
                    {
                        switch (p.Value.format)
                        {
                            case "int32":
                                p.Value.example = 123;
                                break;
                            case "double":
                                p.Value.example = 9858.216;
                                break;
                        }
                    }
                }
            }
        }

        public class HideInDocsFilter : IDocumentFilter
        {
            /// <summary>
            /// [ApiExplorerSettings(IgnoreApi = true)] é bom mas não atende quando ocorre a necessidade de dinamismo 
            /// </summary>
            /// <param name="swaggerDoc"></param>
            /// <param name="schemaRegistry"></param>
            /// <param name="apiExplorer"></param>
            public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
            {
                List<string> removeModels = new List<string>();
                List<string> showModels = new List<string>();
                List<string> removeTags = new List<string>();
                List<string> showTags = new List<string>();

                foreach (ApiDescription api in apiExplorer.ApiDescriptions)
                {
                    bool exibir = !api.ActionDescriptor.ControllerDescriptor.GetCustomAttributes<HideInDocsAttribute>().Any() && !api.ActionDescriptor.GetCustomAttributes<HideInDocsAttribute>().Any();

                    foreach (ApiParameterDescription parameter in api.ParameterDescriptions)
                    {
                        if (exibir)
                            showModels.Add(parameter.ParameterDescriptor.ParameterType.Name);
                        else
                            removeModels.Add(parameter.ParameterDescriptor.ParameterType.Name);
                    }

                    if (api.ResponseDescription?.DeclaredType != null)
                    {
                        if (exibir)
                            showModels.Add(api.ResponseDescription.DeclaredType.Name);
                        else
                            removeModels.Add(api.ResponseDescription.DeclaredType.Name);
                    }

                    if (!exibir)
                    {
                        if (api.ActionDescriptor?.ControllerDescriptor?.ControllerName != null)
                            removeTags.Add(api.ActionDescriptor.ControllerDescriptor.ControllerName);

                        swaggerDoc.paths.Remove($"/{api.Route.RouteTemplate.TrimEnd('/')}");
                    }
                    else
                    {
                        if (api.ActionDescriptor?.ControllerDescriptor?.ControllerName != null)
                            showTags.Add(api.ActionDescriptor.ControllerDescriptor.ControllerName);
                    }
                }

                removeModels.Except(showModels).ToList().ForEach(f => schemaRegistry.Definitions.Remove(f));
                List<string> tags = removeTags.Except(showTags).ToList();
                tags.ForEach(tagRemover =>
                {
                    swaggerDoc.tags.Remove(swaggerDoc.tags.FirstOrDefault(tag => tagRemover == tag.name));
                });
            }
        }

        /// <summary>
        /// Quando quem responde HTTPS é o IIS Application Request Routing (ARR)
        /// é necessário uma validação para que não ocorra o erro
        /// Possible mixed-content issue? The page was loaded over https:// but a http:// URL was specified. Check that you are not attempting to load mixed content.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private static string ResolveBasePath(HttpRequestMessage message)
        {
            var ssl = message.Headers.FirstOrDefault(f => f.Key == "X-ARR-SSL").Value;

            string uri = $"{{0}}://{message.RequestUri.Host}{{1}}";

            if (ssl != null && ssl.Any())
            {
                return string.Format(uri, "https", string.Empty);
            }
            else
                return string.Format(uri, "http", $":{message.RequestUri.Port}");
        }
    }
}
