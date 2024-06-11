using Microsoft.AspNetCore.Mvc;
using RH.DTOs;
using RH.Service.Interface;

namespace RH.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RelatorioRhController : Controller
    {
        private readonly IRelatorioRhService _relatorioRhService;

        public RelatorioRhController(IRelatorioRhService relatorioRhService)
        {
            _relatorioRhService = relatorioRhService;
        }

        [HttpGet("{idVaga}")]
        [ProducesResponseType(typeof(List<VagaTecnologiaRequisitoDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GerarRelatorio([FromRoute] int idVaga)
        {
            try
            {
                var candidatosParaVaga = await _relatorioRhService.GerarRelatorioCandidatosVaga(idVaga);
                if (candidatosParaVaga == null)
                {
                    return NotFound("Não foram encontrados candidatos qualificados para esta vaga.");
                }
                return Ok(candidatosParaVaga);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Erro. COnsulte o time de desenvolvimento", Details = ex.Message });
            }
        }
    }
}