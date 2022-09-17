using APICotacao.Models;

namespace APICotacao.Repositories
{
    public interface ICotacaoItemRepository
    {
        Task<IEnumerable<CotacaoItem>> Get();
        Task<CotacaoItem> Get(int Id);
        Task<CotacaoItem> Create(CotacaoItem cotacao);
        Task Update(CotacaoItem cotacao);
        Task Delete(int Id);
    }
}
