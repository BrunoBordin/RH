using Microsoft.AspNetCore.Mvc;
using RH.DTOs;
using RH.Models;
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
            var result = await _service.BuscarPorId(id);
            return Ok(result);
        }

        [HttpGet("listar")]
        public async Task<IActionResult> ObterListaTecnologias()
        {
            var list = await _service.ListarTodos();
            return Ok(list);
        }

        [HttpPost("cadastrar")]
        public async Task<IActionResult> Cadastrar([FromBody] TecnologiaDto tecnologiaDto)
        {
            await _service.Cadastrar(tecnologiaDto);
            return Ok();
        }

        [HttpPut("atualizar/{id}")]
        public async Task<IActionResult> Atualizar([FromBody] TecnologiaDto tecnologiaDto, [FromRoute] int id)
        {
            await _service.Atualizar(tecnologiaDto, id);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar([FromRoute] int id)
        {
            var tecnologia = await _service.BuscarPorId(id);
            if (tecnologia == null)
            {
                return NotFound();
            }
            await _service.Deletar(tecnologia);
            return Ok();
        }
    }
}