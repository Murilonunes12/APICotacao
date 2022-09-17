using APICotacao.Models;
using Refit;

namespace APICotacao.Repositories
{
    public interface ICepApiService
    {
        [Get("/ws/{cep}/json")]
        Task<CepResponse> GetAddressAsync(string cep);
    }
}
