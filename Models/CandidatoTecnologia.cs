namespace RH.Models
{
    public class CandidatoTecnologia
    {
        public int IdCandidato { get; set; }
        public Candidato Candidato { get; set; }
        public int IdTecnologia { get; set; }
        public Tecnologia Tecnologia { get; set; }
    }
}