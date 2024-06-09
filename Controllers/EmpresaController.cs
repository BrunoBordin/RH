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

        [HttpGet("porId/{idEmpresa}")]
        public async Task<IActionResult> ObterPorId([FromRoute] int IdEmpresa)
        {
            var result = await _empresaService.BuscarPorId(IdEmpresa);
            return Ok(result);
        }

        [HttpGet("listar")]
        public async Task<IActionResult> ListarEmpresas()
        {
            var result = await _empresaService.ListarTodos();
            return Ok(result);
        }

        [HttpPost("cadastrar")]
        public async Task<IActionResult> CadastrarEmpresa([FromBody] EmpresaDto empresaDto)
        {
            await _empresaService.Cadastrar(empresaDto);
            return Ok();
        }

        [HttpPut("atualizar/{idEmpresa}")]
        public async Task<IActionResult> Atualizar([FromBody] EmpresaDto empresaDto, [FromQuery] int idEmpresa)
        {
            await _empresaService.Atualizar(empresaDto, idEmpresa);
            return Ok();
        }

        [HttpDelete("deletar/{idEmpresa}")]
        public async Task<IActionResult> Deletar([FromQuery] int idEmpresa)
        {
            var empresa = await _empresaService.BuscarPorId(idEmpresa);

            if (empresa == null)
            {
                return NotFound();
            }
            await _empresaService.Deletar(empresa);
            return Ok();
        }
    }
}