using Persistencia.DAL.Tabelas;
using System.Linq;
using WebProjectMVC.Modelo.Tabelas;

namespace Servicos.Tabelas
{
    public class CategoriaServico
    {
        private CategoriaDAL categoriaDAL = new CategoriaDAL();

        public IQueryable<Categoria> BuscaCategorias()
        {
            return categoriaDAL.BuscaCategorias();
        }

        public void GravaCategoria(Categoria categoria)
        {
            categoriaDAL.GravaCategoria(categoria);
        }

        public Categoria BuscaCategoriaPorID(long id)
        {
            return categoriaDAL.BuscaCategoriaPorID(id);
        }

        public Categoria ExluirCategoriaPorID(long id)
        {
            return categoriaDAL.ExluirCategoriaPorID(id);
        }
    }
}
