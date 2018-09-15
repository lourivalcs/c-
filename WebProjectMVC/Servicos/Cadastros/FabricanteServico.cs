using Persistencia.DAL.Cadastros;
using System.Linq;
using WebProjectMVC.Modelo.Cadastros;

namespace Servicos.Cadastros
{
    public class FabricanteServico
    {
        private FabricanteDAL fabricanteDAL = new FabricanteDAL();

        public IQueryable<Fabricante> BuscaFabricantes()
        {
            return fabricanteDAL.BuscaFabricantes();
        }

        public void GravaFabricante(Fabricante fabricante)
        {
            fabricanteDAL.GravaFabricante(fabricante);
        }

        public Fabricante BuscaFabricantePorID(long id)
        {
            return fabricanteDAL.BuscaFabricantePorID(id);
        }

        public Fabricante ExcluiFabricantePorID(long id)
        {
            return fabricanteDAL.ExcluiFabricantePorID(id);
        }
    }
}
