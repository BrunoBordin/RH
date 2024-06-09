using Microsoft.AspNetCore.Mvc;
using RH.DTOs;
using RH.Models;
using RH.Service.Interface;

namespace RH.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VagaController : Controller
    {
        private readonly IVagaService _vagaService;

        public VagaController(IVagaService vagaService)
        {
            _vagaService = vagaService;
        }

        [HttpGet("porId/{id}")]
        public async Task<IActionResult> ObterPorId([FromRoute] int id)
        {
            Vaga result = await _vagaService.BuscarPorId(id);
            return Ok(result);
        }

        [HttpGet("listar")]
        public async Task<IActionResult> ObterListaVagas()
        {
            var list = await _vagaService.ListarTodos();
            return Ok(list);
        }

        [HttpPost("cadastrar")]
        public async Task<IActionResult> Cadastrar([FromBody] VagaDto VagaDto)
        {
            await _vagaService.Cadastrar(VagaDto);
            return Ok();
        }

        [HttpPut("atualizar/{id}")]
        public async Task<IActionResult> Atualizar([FromBody] VagaDto VagaDto, [FromRoute] int id)
        {
            await _vagaService.Atualizar(VagaDto, id);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar([FromRoute] int id)
        {
            var vaga = await _vagaService.BuscarPorId(id);
            if (vaga == null)
            {
                return NotFound();
            }
            await _vagaService.Deletar(vaga);
            return Ok();
        }
    }
}