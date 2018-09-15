using Persistencia.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using WebProjectMVC.Modelo.Cadastros;

namespace Persistencia.DAL.Cadastros
{
    public class ProdutoDAL
    {
        private EFContext context = new EFContext();

        public IQueryable BuscaProdutos()
        {
            return context.Produtos
                    .Include(c => c.Categoria)
                    .Include(f => f.Fabricante)
                    .OrderBy(n => n.Nome);
        }

        public Produto BuscaProdutoPorId(long id)
        {
            return context.Produtos
                    .Where(p => p.IdProduto == id)
                    .Include(c => c.Categoria)
                    .Include(f => f.Fabricante)
                    .First();
        }

        public void GravarProduto(Produto produto)
        {
            if (produto.IdProduto == 0)
            {
                context.Produtos.Add(produto);
            }
            else
            {
                context.Entry(produto).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public Produto ExcluirProdutoPorId(long id)
        {
            Produto produto = BuscaProdutoPorId(id);
            context.Produtos.Remove(produto);
            context.SaveChanges();
            return produto;
        }
    }
}