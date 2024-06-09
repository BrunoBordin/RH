namespace RH.Models
{
    public class Candidato : Entity
    {
        public virtual ICollection<Tecnologia> Tecnologias { get; set; }
    }
}