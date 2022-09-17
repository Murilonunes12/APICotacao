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

        private bool ValidaCamposObrigatorios(APICotacao.Models.Cotacao viewModel)
        {
            if (string.IsNullOrEmpty(viewModel.CNPJComprador))
                throw new Exception("CNPJ Comprador é campo obrigatório.");

            if (string.IsNullOrEmpty(viewModel.CNPJFornecedor))
                throw new Exception("CNPJ Fornecedor é campo obrigatório.");

            if (viewModel.NumeroCotacao == 0 || viewModel.NumeroCotacao == null)
                throw new Exception("Número da Cotação é campo obrigatório.");

            if (viewModel.DataCotacao == null)
                throw new Exception("Data Cotação é campo obrigatório.");

            if (viewModel.DataEntregaCotacao == null)
                throw new Exception("Data Entrega Cotação é campo obrigatório.");

            if (string.IsNullOrEmpty(viewModel.CEP))
                throw new Exception("Cep é campo obrigatório.");

            return true;

        }
    }
}
