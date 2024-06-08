namespace RH.DTOs
{
    public class CandidatoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }

    public class CandidatoTecnologiaDto
    {
        public int IdCandidato { get; set; }
        public int IdTecnologia { get; set; }
    }

    public class CandidatoVagaDto
    {
        public int IdCandidato { get; set; }
        public int IdVaga { get; set; }
    }
}