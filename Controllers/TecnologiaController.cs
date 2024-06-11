using Microsoft.AspNetCore.Mvc;
using RH.DTOs;
using RH.Service.Interface;

namespace RH.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TecnologiaController : Controller
    {
        private readonly ITecnologiaService _service;

        public TecnologiaController(ITecnologiaService service)
        {
            _service = service;
        }

        [HttpGet("porId/{id}")]
        [ProducesResponseType(typeof(TecnologiaDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObterPorId([FromRoute] int id)
        {
            try
            {
                var result = await _service.BuscarPorId(id);
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
        [ProducesResponseType(typeof(TecnologiaDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObterListaTecnologias()
        {
            try
            {
                var list = await _service.ListarTodos();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Erro. COnsulte o time de desenvolvimento", Details = ex.Message });
            }
        }

        [HttpPost("cadastrar")]
        [ProducesResponseType(typeof(TecnologiaDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Cadastrar([FromBody] TecnologiaDto tecnologiaDto)
        {
            try
            {
                await _service.Cadastrar(tecnologiaDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Erro. COnsulte o time de desenvolvimento", Details = ex.Message });
            }
        }

        [HttpPut("atualizar/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Atualizar([FromBody] TecnologiaDto tecnologiaDto, [FromRoute] int id)
        {
            try
            {
                await _service.Atualizar(tecnologiaDto, id);
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
                await _service.Deletar(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Erro. COnsulte o time de desenvolvimento", Details = ex.Message });
            }
        }

        [HttpPost("empresa")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> VincularTecnologiaEmpresa([FromBody] EmpresaTecnologiaDto empresaTecnologiaDto)
        {
            try
            {
                await _service.VincularTecnologiaEmpresa(empresaTecnologiaDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Erro. COnsulte o time de desenvolvimento", Details = ex.Message });
            }
        }
    }
}