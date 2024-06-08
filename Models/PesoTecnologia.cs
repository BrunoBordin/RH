namespace RH.Models
{
    public class PesoTecnologia : Entity
    {
        public int IdTecnologia { get; set; }
        public int IdVaga { get; set; }
        public int Peso { get; set; }
        public Vaga Vaga { get; set; }
        public Tecnologia Tecnologia { get; set; }
    }
}
