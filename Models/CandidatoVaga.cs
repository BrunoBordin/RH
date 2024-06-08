namespace RH.Models
{
    public class CandidatoVaga : Entity
    {
        public int IdCandidato { get; set; }
        public int IdVaga { get; set; }
        public Candidato Candidato { get; set; }
        public Tecnologia Tecnologia { get; set; }
    }
}