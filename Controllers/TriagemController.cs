using Microsoft.AspNetCore.Mvc;
using RH.DTOs;
using RH.Service.Interface;

namespace RH.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TriagemController : Controller
    {
        private readonly ITriagemService _triagemService;

        public TriagemController(ITriagemService triagemService)
        {
            _triagemService = triagemService;
        }

        [HttpGet("{idVaga}")]
        [ProducesResponseType(typeof(List<VagaTecnologiaRequisitoDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GerarRelatorio([FromRoute] int idVaga)
        {
            try
            {
                var candidatosParaVaga = await _triagemService.GerarRelatorioCandidatosVaga(idVaga);
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