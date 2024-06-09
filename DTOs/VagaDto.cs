using RH.Models;

namespace RH.DTOs
{
    public class VagaDto
    {
        public string Nome { get; set; }
        public virtual ICollection<Tecnologia> TecnologiasRequeridas { get; set; }
    }
}