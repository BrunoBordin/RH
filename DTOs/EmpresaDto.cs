using RH.Models;

namespace RH.DTOs
{
    public class EmpresaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Vaga> Vagas { get; set; }

        public virtual ICollection<Tecnologia> Tecnologias { get; set; }
    }
}