using Microsoft.AspNetCore.Mvc;
using RH.DTOs;
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
        [ProducesResponseType(typeof(VagaDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObterPorId([FromRoute] int id)
        {
            try
            {
                var result = await _vagaService.BuscarPorId(id);
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
        [ProducesResponseType(typeof(List<VagaDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObterListaVagas()
        {
            try
            {
                var list = await _vagaService.ListarTodos();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Erro. COnsulte o time de desenvolvimento", Details = ex.Message });
            }
        }

        [HttpPost("cadastrar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Cadastrar([FromBody] VagaDto VagaDto)
        {
            try
            {
                await _vagaService.Cadastrar(VagaDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Erro. COnsulte o time de desenvolvimento", Details = ex.Message });
            }
        }

        [HttpPut("atualizar/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Atualizar([FromBody] VagaDto VagaDto, [FromRoute] int id)
        {
            try
            {
                await _vagaService.Atualizar(VagaDto, id);
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
                await _vagaService.Deletar(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Erro. COnsulte o time de desenvolvimento", Details = ex.Message });
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DefinirPesos(int idVaga, Dictionary<int, int> tecnologiaPesos)
        {
            try
            {
                await _vagaService.DefinirPesos(idVaga, tecnologiaPesos);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Erro. COnsulte o time de desenvolvimento", Details = ex.Message });
            }
        }
    }
}