using APICotacao.Models;
using Microsoft.EntityFrameworkCore;

namespace APICotacao.Repositories
{
    public class CotacaoRepository : ICotacaoRepository
    {
        public readonly CotacaoDBContext _DB;
        public CotacaoRepository(CotacaoDBContext context)
        {
            _DB = context;
        }
        public async Task<Models.Cotacao> Create(Models.Cotacao cotacao)
        {
            _DB.Cotacoes.Add(cotacao);
            await _DB.SaveChangesAsync();

            return cotacao;
        }

        public async Task Delete(int Id)
        {
            var cotacaoToDelete = await _DB.Cotacoes.FindAsync(Id);
            _DB.Cotacoes.Remove(cotacaoToDelete);
            await _DB.SaveChangesAsync();
        }

        public async Task<IEnumerable<Models.Cotacao>> Get()
        {
            return await _DB.Cotacoes.ToListAsync();

        }

        public async Task<Models.Cotacao> Get(int Id)
        {
          return await _DB.Cotacoes.FindAsync(Id);
        }

        public async Task Update(Models.Cotacao cotacao)
        {
            _DB.Entry(cotacao).State = EntityState.Modified; 
            await _DB.SaveChangesAsync();
        }
    }
}
