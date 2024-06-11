namespace RH.DTOs
{
    public class VagaTecnologiaPesoDto
    {
        public int Id { get; set; }
        public int IdVagaTecnologiaRequisitoDto { get; set; }
        public string NomeVaga { get; set; }
        public string NomeTecnologia { get; set; }
        public int Peso { get; set; }
    }
}