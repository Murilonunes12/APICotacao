using Microsoft.EntityFrameworkCore;

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
    }
}
