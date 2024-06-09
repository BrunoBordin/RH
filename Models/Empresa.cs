namespace RH.Models
{
    public class Empresa : Entity
    {
        public virtual ICollection<Vaga> Vagas { get; set; }

        public virtual ICollection<Tecnologia> Tecnologias { get; set; }
    }
}