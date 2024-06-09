namespace RH.DTOs
{
    public class VagaDto
    {
        public string Titulo { get; set; }
        public ICollection<VagaTecnologiaDto> VagaTecnologias { get; set; }
    }
}