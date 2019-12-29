using PocSwagger.Models;
using PocSwagger.Models.Teste.Modelo.Teste.Modelo;
using System.Web.Http;

namespace PocSwagger.Controllers
{
    [RoutePrefix("v1/Teste1")]
    public class TesteController : ApiController
    {
        [HttpPost]
        [Route("TesteComRetornoIgnoradoNoTeste2")]
        public Teste2RetornoModelo TesteComRetorno(Teste2Modelo teste)
        {
            return new Teste2RetornoModelo();
        }

        [HttpPost]
        [Route("TesteSemRetorno")]
        public void TesteSemRetorno(Teste2Modelo teste)
        {
        }

        [HttpPost]
        [Route("TesteTipoPrimitivoComRetorno")]
        public int TesteTipoPrimitivoComRetorno(int teste)
        {
            return teste;
        }

        [HttpPost]
        [Route("TesteTipoPrimitivoComRetorno")]
        public void TesteTipoPrimitivoSemRetorno(int teste)
        {
        }
    }
}
