using Persistencia.Migrations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using WebProjectMVC.Modelo.Cadastros;
using WebProjectMVC.Modelo.Tabelas;

namespace Persistencia.Contexts
{
    class EFContext : DbContext
    {
        public EFContext() : base("Asp_Net_MVC")
        {
            Database.SetInitializer<EFContext>(new MigrateDatabaseToLatestVersion<EFContext, Configuration>());
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Fabricante> Fabricantes { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.
            Remove<PluralizingTableNameConvention>();
        }
    }
}
