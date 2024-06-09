namespace RH.DTOs
{
    public class CandidatoTecnologiaDto
    {
        public int IdCandidato { get; set; }
        public CandidatoDto Candidato { get; set; }
        public int IdTecnologia { get; set; }
        public TecnologiaDto Tecnologia { get; set; }
    }
}