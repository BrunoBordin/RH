using Microsoft.AspNetCore.Mvc;
using RH.DTOs;
using RH.Models;
using RH.Service.Interface;

namespace RH.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CandidatoController : Controller
    {
        private readonly ICandidatoService _candidatoService;

        public CandidatoController(ICandidatoService candidatoService)
        {
            _candidatoService = candidatoService;
        }

        [HttpGet("porId/{id}")]
        public async Task<IActionResult> ObterPorId([FromRoute] int id)
        {
            var result = await _candidatoService.BuscarPorId(id);
            return Ok(result);
        }

        [HttpGet("listar")]
        public async Task<IActionResult> ObterListaCandidatos()
        {
            IList<Candidato> list = await _candidatoService.ListarTodos();
            return Ok(list);
        }

        [HttpPost("cadastrar")]
        public async Task<IActionResult> Cadastrar([FromBody] CandidatoDto candidatoDto)
        {
            await _candidatoService.Cadastrar(candidatoDto);
            return Ok();
        }

        [HttpPut("atualizar/{id}")]
        public async Task<IActionResult> Atualizar([FromBody] CandidatoDto candidatoDto, [FromRoute] int id)
        {
            await _candidatoService.Atualizar(candidatoDto, id);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar([FromRoute] int id)
        {
            var candidato = await _candidatoService.BuscarPorId(id);

            if (candidato == null)
            {
                return NotFound();
            }

            await _candidatoService.Deletar(candidato);
            return Ok();
        }
    }
}