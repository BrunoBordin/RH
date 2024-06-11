using Microsoft.AspNetCore.Mvc;
using RH.DTOs;
using RH.Service.Interface;

namespace RH.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RelatorioRhController : Controller
    {
        private readonly IRelatorioService _relatorioService;

        public RelatorioRhController(IRelatorioService relatorioService)
        {
            _relatorioService = relatorioService;
        }

        [HttpGet("{idVaga}")]
        [ProducesResponseType(typeof(List<RelatorioCandidatosDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GerarRelatorio([FromRoute] int idVaga)
        {
            try
            {
                List<RelatorioCandidatosDto> candidatosParaVaga = await _relatorioService.GerarRelatorioCandidatosVaga(idVaga);
                if (candidatosParaVaga == null)
                {
                    return NotFound("Não foram encontrados candidatos qualificados para esta vaga.");
                }
                return Ok(candidatosParaVaga);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Erro. Consulte o time de desenvolvimento", Details = ex.Message });
            }
        }
    }
}