using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace APICotacao.Models
{
    public class CotacaoDBContext : DbContext
    {
        public CotacaoDBContext(DbContextOptions<CotacaoDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Cotacao> Cotacoes { get; set; }
        public DbSet<CotacaoItem> CotacaoItem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cotacao>()
                .HasMany(b => b.CotacaoItems)
                .WithOne();

            modelBuilder.Entity<Cotacao>()
                .Navigation(b => b.CotacaoItems)
                .UsePropertyAccessMode(PropertyAccessMode.Property);
        }

    }

}
