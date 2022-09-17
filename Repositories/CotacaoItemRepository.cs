using APICotacao.Models;
using System.Data.Entity;

namespace APICotacao.Repositories
{
    public class CotacaoItemRepository : ICotacaoItemRepository
    {
        public readonly CotacaoDBContext _DB;
        public CotacaoItemRepository(CotacaoDBContext context)
        {
            _DB = context;
        }
        public async Task<Models.CotacaoItem> Create(Models.CotacaoItem cotacaoitem)
        {
            _DB.CotacaoItem.Add(cotacaoitem);
            await _DB.SaveChangesAsync();

            return cotacaoitem;
        }

        public async Task Delete(int Id)
        {
            var cotacaoToDelete = await _DB.CotacaoItem.FindAsync(Id);
            _DB.CotacaoItem.Remove(cotacaoToDelete);
            await _DB.SaveChangesAsync();
        }

        public async Task<IEnumerable<Models.CotacaoItem>> Get()
        {
            return await _DB.CotacaoItem.ToListAsync();

        }

        public async Task<Models.CotacaoItem> Get(int Id)
        {
            return await _DB.CotacaoItem.FindAsync(Id);
        }

        public async Task Update(Models.CotacaoItem cotacaoItem)
        {
            _DB.Entry(cotacaoItem).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;
            await _DB.SaveChangesAsync();
        }


    }
}
