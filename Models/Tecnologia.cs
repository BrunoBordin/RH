namespace RH.Models
{
    public class Tecnologia : Entity
    {
        public decimal Peso { get; set; }

        public ICollection<Candidato> Candidatos { get; set; }
    }
}