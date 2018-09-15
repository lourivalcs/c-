using WebProjectMVC.Modelo.Tabelas;
using Persistencia.Contexts;
using System.Linq;
using System.Data.Entity;

namespace Persistencia.DAL.Tabelas
{
    public class CategoriaDAL
    {
        private EFContext context = new EFContext();

        public IQueryable<Categoria>BuscaCategorias()
        {
            return context.Categorias.OrderBy(b => b.Nome);
        }

        public void GravaCategoria(Categoria categoria)
        {
            if (categoria.IdCategoria == 0)
                context.Categorias.Add(categoria);
            else
                context.Entry(categoria).State = EntityState.Modified;

            context.SaveChanges();
        }

        public Categoria BuscaCategoriaPorID(long id)
        {
            return context.Categorias
                    .Where(c => c.IdCategoria == id)
                    .Include("Produtos.Fabricante").First();
        }

        public Categoria ExluirCategoriaPorID(long id)
        {
            Categoria categoria = BuscaCategoriaPorID(id);

            context.Categorias.Remove(categoria);
            context.SaveChanges();

            return categoria;
        }

    }
}