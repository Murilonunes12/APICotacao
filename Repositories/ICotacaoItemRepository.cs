using APICotacao.Models;

namespace APICotacao.Repositories
{
    public interface ICotacaoItemRepository
    {
        Task<IEnumerable<CotacaoItem>> Get();
        Task<CotacaoItem> Get(int Id);
        Task<CotacaoItem> Create(CotacaoItem cotacao);
        Task<CotacaoItem> Update(CotacaoItem cotacao);
        Task<CotacaoItem> Delete(int Id);
    }
}
