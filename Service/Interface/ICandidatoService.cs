namespace RH.Service.Interface
{
    public interface ICandidatoService
    {
        Task VincularTecncologiasUsuario(int idUsuario, List<int> idTecnologia);
    }
}