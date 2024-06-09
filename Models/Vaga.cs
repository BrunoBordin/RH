namespace RH.Models
{
    public class Vaga
    {
        public int IdVaga { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public ICollection<VagaTecnologia> VagaTecnologias { get; set; }
    }
}