namespace RH.Models
{
    public class Candidato
    {
        public int IdCandidato { get; set; }
        public string Nome { get; set; }
        public int IdVaga { get; set; }
        public Vaga Vaga { get; set; }
        public ICollection<CandidatoTecnologia> CandidatoTecnologias { get; set; }
    }
}