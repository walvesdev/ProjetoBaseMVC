using Microsoft.EntityFrameworkCore;
using ProjetoBase.AcessoDados.TypeConfiguration;
using ProjetoBaseMVC.Dados.AcessoDados.TypeConfiguration;
using ProjetoBaseMVC.Model.Models;

namespace ProjetoBase.AcessoDados
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Empresa> Empresas { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public ApplicationContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = localhost; Database = ProjetoBaseMVC; Trusted_Connection = True;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("ProjetoBaseMVC");
            modelBuilder.ApplyConfiguration(new EmpresaTypeConfiguration());
        }
    }
}
