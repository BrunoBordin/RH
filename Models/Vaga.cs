namespace RH.Models
{
    public class Vaga : Entity
    {
        public string Titulo { get; set; }
        public Empresa Empresa { get; set; }
        public ICollection<CandidatoVaga> Candidatos { get; set; }
        public ICollection<PesoTecnologia> PesosTecnologias { get; set; }
    }
}