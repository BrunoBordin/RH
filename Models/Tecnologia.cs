namespace RH.Models
{
    public class Tecnologia : Entity
    {
        public string Nome { get; set; }

        public ICollection<CandidatoTecnologia> Candidatos { get; set; }
        public ICollection<PesoTecnologia> PesosVagas { get; set; }
    }
}