using APICotacao.Models;

namespace APICotacao.Repositories
{
    public interface ICotacaoRepository
    {
        Task<IEnumerable<APICotacao.Models.Cotacao>> Get();      
        Task<APICotacao.Models.Cotacao> Get(int Id);
        Task<APICotacao.Models.Cotacao> Create(APICotacao.Models.Cotacao cotacao);
        Task Update(APICotacao.Models.Cotacao cotacao);
        Task Delete(int Id);
    }
}
