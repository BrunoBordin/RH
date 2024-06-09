﻿using RH.Models;

namespace RH.DTOs
{
    public class CandidatoDto
    {
        public int IdCandidato { get; set; }
        public string Nome { get; set; }
        public int IdVaga { get; set; }
        public Vaga Vaga { get; set; }
        public ICollection<CandidatoTecnologiaDto> CandidatoTecnologias { get; set; }
    }
}