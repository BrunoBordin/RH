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
        public async Task<IActionResult> Deletar([FromRoute] int id)
        {
            try
            {
                var tecnologia = await _service.BuscarPorId(id);
                if (tecnologia == null)
                {
                    return NotFound();
                }
                await _service.Deletar(tecnologia);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Erro. COnsulte o time de desenvolvimento", Details = ex.Message });
            }
        }
    }
}