using Microsoft.AspNetCore.Mvc;
using RH.DTOs;
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
        [ProducesResponseType(typeof(CandidatoDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObterPorId([FromRoute] int id)
        {
            try
            {
                var result = await _candidatoService.BuscarPorId(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Erro. COnsulte o time de desenvolvimento", Details = ex.Message });
            }
        }

        [HttpGet("listar")]
        [ProducesResponseType(typeof(List<CandidatoDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObterListaCandidatos()
        {
            try
            {
                var list = await _candidatoService.ListarTodos();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Erro. COnsulte o time de desenvolvimento", Details = ex.Message });
            }
        }

        [HttpPost("cadastrar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Cadastrar([FromBody] CandidatoDto candidatoDto)
        {
            try
            {
                await _candidatoService.Cadastrar(candidatoDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Erro. COnsulte o time de desenvolvimento", Details = ex.Message });
            }
        }

        [HttpPut("atualizar/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Atualizar([FromBody] CandidatoDto candidatoDto, [FromRoute] int id)
        {
            try
            {
                await _candidatoService.Atualizar(candidatoDto, id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Erro. COnsulte o time de desenvolvimento", Details = ex.Message });
            }
        }

        [HttpDelete("deletar/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Deletar([FromRoute] int id)
        {
            try
            {
                await _candidatoService.Deletar(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Erro. COnsulte o time de desenvolvimento", Details = ex.Message });
            }
        }

        [HttpGet("entrevista")]
        [ProducesResponseType(typeof(List<EntrevistaCandidatoDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObterListaEntrevistas()
        {
            try
            {
                var list = await _candidatoService.ObterListaEntrevistas();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Erro. COnsulte o time de desenvolvimento", Details = ex.Message });
            }
        }
    }
}