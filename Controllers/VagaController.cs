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
                return StatusCode(500, new { Message = "Erro. Consulte o time de desenvolvimento", Details = ex.Message });
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
                return StatusCode(500, new { Message = "Erro. Consulte o time de desenvolvimento", Details = ex.Message });
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
                return StatusCode(500, new { Message = "Erro. Consulte o time de desenvolvimento", Details = ex.Message });
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
                return StatusCode(500, new { Message = "Erro. Consulte o time de desenvolvimento", Details = ex.Message });
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
                return StatusCode(500, new { Message = "Erro. Consulte o time de desenvolvimento", Details = ex.Message });
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DefinirPesos(int idVaga, Dictionary<int, int> tecnologiaPesos)
        {
            //try
            //{
            //    await _vagaService.DefinirPesos(idVaga, tecnologiaPesos);
            //    return Ok();
            //}
            //catch (Exception ex)
            //{
            //    return StatusCode(500, new { Message = "Erro. Consulte o time de desenvolvimento", Details = ex.Message });
            //}
            return Ok();
        }

        [HttpPost("candidato")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> VincularCandidatoVaga([FromBody] VinculoCanditadoVagaDto vinculoCanditadoVagaDtos)
        {
            try
            {
                await _vagaService.VincularCandidatoVaga(vinculoCanditadoVagaDtos);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Erro. Consulte o time de desenvolvimento", Details = ex.Message });
            }
        }

        [HttpPost("tecnologia/candidato")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> VincularCanditadoVagaTecnologia([FromBody] VinculoCanditadoVagaTecnologiaDto vinculoCanditadoVagaTecnologiaDto)
        {
            try
            {
                await _vagaService.VincularCanditadoVagaTecnologia(vinculoCanditadoVagaTecnologiaDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Erro. Consulte o time de desenvolvimento", Details = ex.Message });
            }
        }

        [HttpPost("tecnologia/requisito")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> VincularVagaTecnologiaRequisito([FromBody] VagaTecnologiaRequisitoDto vagaTecnologiaRequisitoDto)
        {
            try
            {
                await _vagaService.VincularVagaTecnologiaRequisito(vagaTecnologiaRequisitoDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Erro. Consulte o time de desenvolvimento", Details = ex.Message });
            }
        }

        [HttpGet("listarTecnologia/requisito")]
        [ProducesResponseType(typeof(List<VagaTecnologiaRequisitoDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ListarVagaTecnologiaRequisito()
        {
            try
            {
                List<VagaTecnologiaRequisitoDto> aa = await _vagaService.ListarVagaTecnologiaRequisito();
                return Ok(aa);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Erro. Consulte o time de desenvolvimento", Details = ex.Message });
            }
        }

        [HttpPut("tecnologia/requisito/peso/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> SetarPesoVagaTecnologiaRequisito([FromBody] VagaTecnologiaRequisitoDto vagaTecnologiaRequisitoDto, [FromRoute] int id)
        {
            try
            {
                await _vagaService.SetarPesoVagaTecnologiaRequisito(vagaTecnologiaRequisitoDto, id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Erro. Consulte o time de desenvolvimento", Details = ex.Message });
            }
        }
    }
}