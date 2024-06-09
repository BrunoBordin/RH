namespace RH.Models
{
    public class VagaTecnologia
    {
        public int IdVaga { get; set; }
        public Vaga Vaga { get; set; }
        public int IdTecnologia { get; set; }
        public Tecnologia Tecnologia { get; set; }
        public int Peso { get; set; }
    }
}