using PocSwagger.Models;
using PocSwagger.Models.Teste.Modelo.Teste.Modelo;
using Swagger.Net.Annotations;
using System.Web.Http;

namespace PocSwagger.Controllers
{
    [RoutePrefix("v2/Teste2")]
    public class TesteV2Controller : ApiController
    {
        [HttpGet]
        [Route("AparecerTagTeste2")]
        [SwaggerOperation(Tags = new[] { "Teste2" })]
        public void AparecerTagTeste2()
        {

        }

        [HttpPost]
        [Route("TesteComRetorno2")]
        public Teste2RetornoModelo TesteComRetorno(Teste2Modelo teste)
        {
            return new Teste2RetornoModelo();
        }

        [HttpPost]
        [Route("TesteSemRetorno2")]
        public void TesteSemRetorno(Teste2Modelo teste)
        {
        }

        [HttpPost]
        [Route("TesteTipoPrimitivoComRetorno2")]
        public int TesteTipoPrimitivoComRetorno(int teste)
        {
            return teste;
        }

        [HttpPost]
        [Route("TesteTipoPrimitivoComRetorno2")]
        public void TesteTipoPrimitivoSemRetorno(int teste)
        {
        }
    }
}
