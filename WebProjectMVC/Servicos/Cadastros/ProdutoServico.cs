using Persistencia.DAL.Cadastros;
using System.Linq;
using WebProjectMVC.Modelo.Cadastros;

namespace Servicos.Cadastros
{
    public class ProdutoServico
    {
        private ProdutoDAL produtoDAL = new ProdutoDAL();

        public IQueryable BuscaProdutos()
        {
            return produtoDAL.BuscaProdutos();
        }

        public Produto BuscaProdutoPorId(long id)
        {
            return produtoDAL.BuscaProdutoPorId(id);
        }

        public void GravarProduto(Produto produto)
        {
            produtoDAL.GravarProduto(produto);
        }

        public Produto ExcluirProdutoPorId(long id)
        {
            return produtoDAL.ExcluirProdutoPorId(id);
        }
    }
}
