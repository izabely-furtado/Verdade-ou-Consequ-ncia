using Microsoft.EntityFrameworkCore;
using VerdadeConsequencia.Entities;
using System.Linq;

namespace VerdadeConsequencia.Persistencia
{
    public class Repositorio : DbContext
    {

        public static string ConnectionString { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(ConnectionString);
        }

        public DbSet<Alerta> Alertas { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Consequencia> Consequencias { get; set; }
        public DbSet<Sequencia> Sequencias { get; set; }
        public DbSet<Verdade> Verdades { get; set; }
        public DbSet<Opcao> Opcoes { get; set; }
        public DbSet<Tipo> Tipos { get; set; }
        public DbSet<VerdadeConsequenciaTipo> VerdadeConsequenciaTipos { get; set; }

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetProperties()).ToList()
                .ForEach(c => c.Relational().ColumnName = ToSnakeCase(c.Name));

            modelBuilder.Entity<Alerta>().ToTable("alerta");
            modelBuilder.Entity<Pessoa>().ToTable("pessoa");
            modelBuilder.Entity<Consequencia>().ToTable("consequencia");
            modelBuilder.Entity<Sequencia>().ToTable("sequencia");
            modelBuilder.Entity<Verdade>().ToTable("verdade");
            modelBuilder.Entity<Opcao>().ToTable("opcao");
            modelBuilder.Entity<Tipo>().ToTable("tipo");
            modelBuilder.Entity<VerdadeConsequenciaTipo>().ToTable("verdade_consequencia_tipo");
            
        }

        private string ToSnakeCase(string str)
        {
            return string.Concat(str.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x.ToString() : x.ToString())).ToLower();
        }
    }
}
