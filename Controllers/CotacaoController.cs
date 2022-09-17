using APICotacao.Models;
using APICotacao.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cotacao.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CotacaoController : ControllerBase
    {
        private readonly ICotacaoRepository _cotacaoRepository;
        public CotacaoController(ICotacaoRepository cotacaoRepository)
        {
            _cotacaoRepository = cotacaoRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<APICotacao.Models.Cotacao>> GetCotacaos()
        {
            return await _cotacaoRepository.Get();
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<APICotacao.Models.Cotacao>> GetCotacoes(int Id)
        {
            return await _cotacaoRepository.Get(Id);
        }
        [HttpPost]
        public async Task<ActionResult<APICotacao.Models.Cotacao>> PostCotacoes([FromBody] APICotacao.Models.Cotacao cotacao)
        {
            if (cotacao.Logradouro == "" || cotacao.Bairro == "" || cotacao.UF == "")
            {
                var cepClient = RestService.For<ICepApiService>("http://viacep.com.br");
                var endereco = await cepClient.GetAddressAsync(cotacao.CEP);

                cotacao.Logradouro = cotacao.Logradouro != "" ? cotacao.Logradouro : endereco.Logradouro;
                cotacao.Bairro = cotacao.Bairro != "" ? cotacao.Bairro : endereco.Bairro;
                cotacao.UF = cotacao.UF != "" ? cotacao.UF : endereco.Uf;

            }
            var newCotacao = await _cotacaoRepository.Create(cotacao);
            return CreatedAtAction(nameof(GetCotacaos), new { Id = newCotacao.Id }, newCotacao);
        }

        [HttpDelete]
        public async Task<ActionResult<APICotacao.Models.Cotacao>> Delete(int Id)
        {
            var cotacaoDelete = await _cotacaoRepository.Get(Id);

            if (cotacaoDelete == null)
                return NotFound();

            await _cotacaoRepository.Delete(Id);
            return NoContent();
        }
        [HttpPut]
        public async Task<ActionResult<APICotacao.Models.Cotacao>> PutCotacao(int Id, [FromBody] APICotacao.Models.Cotacao cotacao)
        {
            if (Id == cotacao.Id)
                return BadRequest();

            await _cotacaoRepository.Update(cotacao);
            return NoContent();
        }

    }
}