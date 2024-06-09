﻿using Microsoft.AspNetCore.Mvc;
using RH.DTOs;
using RH.Service.Interface;

namespace RH.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CandidatoController : Controller
    {
        private readonly ICandidatoService _candidatoService;

        public CandidatoController(ICandidatoService candidatoService)
        {
            _candidatoService = candidatoService;
        }

        [HttpGet("porId/{id}")]
        public async Task<IActionResult> ObterPorId([FromRoute] int id)
        {
            try
            {
                var result = await _candidatoService.BuscarPorId(id);
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
        public async Task<IActionResult> ObterListaCandidatos()
        {
            try
            {
                var list = await _candidatoService.ListarTodos();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Erro. COnsulte o time de desenvolvimento", Details = ex.Message });
            }
        }

        [HttpPost("cadastrar")]
        public async Task<IActionResult> Cadastrar([FromBody] CandidatoDto candidatoDto)
        {
            try
            {
                await _candidatoService.Cadastrar(candidatoDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Erro. COnsulte o time de desenvolvimento", Details = ex.Message });
            }
        }

        [HttpPut("atualizar/{id}")]
        public async Task<IActionResult> Atualizar([FromBody] CandidatoDto candidatoDto, [FromRoute] int id)
        {
            try
            {
                await _candidatoService.Atualizar(candidatoDto, id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Erro. COnsulte o time de desenvolvimento", Details = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar([FromRoute] int id)
        {
            try
            {
                var candidato = await _candidatoService.BuscarPorId(id);

                if (candidato == null)
                {
                    return NotFound();
                }

                await _candidatoService.Deletar(candidato);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Erro. COnsulte o time de desenvolvimento", Details = ex.Message });
            }
        }

        [HttpPost("vincular-tecnologia")]
        public async Task<IActionResult> VincularTecnologia(int idCandidato, List<int> idTecnologia)
        {
            try
            {
                var candidato = await _candidatoService.BuscarPorId(idCandidato);

                if (candidato == null)
                {
                    return NotFound(new { Message = "Candidato não encontrado para vincular as tecnologias." });
                }

                await _candidatoService.VincularCandidatoTecnologia(idCandidato, idTecnologia);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Erro. COnsulte o time de desenvolvimento", Details = ex.Message });
            }
        }
    }
}