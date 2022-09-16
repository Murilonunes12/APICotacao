using APICotacao.Models;
using APICotacao.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cotacao.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CotacaoItemController : ControllerBase
    {
        private readonly ICotacaoItemRepository _cotacaoItemRepository;
        public CotacaoItemController(ICotacaoItemRepository cotacaoItemRepository)
        {
            _cotacaoItemRepository = cotacaoItemRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<APICotacao.Models.CotacaoItem>> GetCotacaos()
        {
            return await _cotacaoItemRepository.Get();
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<APICotacao.Models.CotacaoItem>> GetCotacoes(int Id)
        {
            return await _cotacaoItemRepository.Get(Id);
        }
        [HttpPost]
        public async Task<ActionResult<APICotacao.Models.CotacaoItem>> PostCotacoes([FromBody] APICotacao.Models.CotacaoItem cotacao)
        {
            var newCotacao = await _cotacaoItemRepository.Create(cotacao);
            return CreatedAtAction(nameof(GetCotacaos), new { Id = newCotacao.Id }, newCotacao);
        }

        [HttpDelete]
        public async Task<ActionResult<APICotacao.Models.CotacaoItem>> Delete(int Id)
        {
            var cotacaoDelete = await _cotacaoItemRepository.Get(Id);

            if (cotacaoDelete == null)
                return NotFound();

            await _cotacaoItemRepository.Delete(Id);
            return NoContent();
        }
        [HttpPut]
        public async Task<ActionResult<APICotacao.Models.CotacaoItem>> PutCotacao(int Id, [FromBody] APICotacao.Models.CotacaoItem cotacao)
        {
            if (Id == cotacao.Id)
                return BadRequest();

            await _cotacaoItemRepository.Update(cotacao);
            return NoContent();
        }

    }
}