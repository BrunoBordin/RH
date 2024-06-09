namespace RH.Models
{
    public class Vaga : Entity
    {
        public virtual ICollection<Tecnologia> TecnologiasRequeridas { get; set; }
    }
}