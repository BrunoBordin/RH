namespace RH.DTOs
{
    public class VagaTecnologiaDto
    {
        public int IdVaga { get; set; }
        public VagaDto Vaga { get; set; }
        public int IdTecnologia { get; set; }
        public TecnologiaDto Tecnologia { get; set; }
        public int Peso { get; set; }
    }
}