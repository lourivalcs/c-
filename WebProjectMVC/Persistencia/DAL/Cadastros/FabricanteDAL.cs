using Persistencia.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProjectMVC.Modelo.Cadastros;

namespace Persistencia.DAL.Cadastros
{
    public class FabricanteDAL
    {
        private EFContext context = new EFContext();
        public IQueryable<Fabricante> BuscaFabricantes()
        {
            return context.Fabricantes.OrderBy(b => b.Nome);
        }

        public void GravaFabricante(Fabricante fabricante)
        {
            if (fabricante.IdFabricante == 0)
                context.Fabricantes.Add(fabricante);
            else
                context.Entry(fabricante).State = EntityState.Modified;

            context.SaveChanges();
        }

        public Fabricante BuscaFabricantePorID(long id)
        {
            return context.Fabricantes
                   .Where(f => f.IdFabricante == id)
                   .Include("Produtos.Categoria")
                   .First();
        }

        public Fabricante ExcluiFabricantePorID(long id)
        {
            Fabricante fabricante = BuscaFabricantePorID(id);

            context.Fabricantes.Remove(fabricante);
            context.SaveChanges();

            return fabricante;
        }
    }
}