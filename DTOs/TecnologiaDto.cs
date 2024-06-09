using RH.Models;

namespace RH.DTOs
{
    public class TecnologiaDto
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public decimal Peso { get; set; }

        public ICollection<Candidato> Candidatos { get; set; }
    }
}