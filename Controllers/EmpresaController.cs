using Microsoft.AspNetCore.Mvc;
using RH.DTOs;
using RH.Service.Interface;

namespace RH.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmpresaController : Controller
    {
        private readonly IEmpresaService _empresaService;

        public EmpresaController(IEmpresaService empresaService)
        {
            _empresaService = empresaService;
        }

        [HttpGet("porId/{id}")]
        [ProducesResponseType(typeof(EmpresaDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObterPorId([FromRoute] int id)
        {
            try
            {
                var result = await _empresaService.BuscarPorId(id);
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
        [ProducesResponseType(typeof(List<EmpresaDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObterListaEmpresas()
        {
            try
            {
                var list = await _empresaService.ListarTodos();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Erro. COnsulte o time de desenvolvimento", Details = ex.Message });
            }
        }

        [HttpPost("cadastrar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Cadastrar([FromBody] EmpresaDto empresaDto)
        {
            try
            {
                await _empresaService.Cadastrar(empresaDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Erro. COnsulte o time de desenvolvimento", Details = ex.Message });
            }
        }

        [HttpPut("atualizar/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Atualizar([FromBody] EmpresaDto empresaDto, [FromRoute] int id)
        {
            try
            {
                await _empresaService.Atualizar(empresaDto, id);
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
                await _empresaService.Deletar(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Erro. COnsulte o time de desenvolvimento", Details = ex.Message });
            }
        }
    }
}