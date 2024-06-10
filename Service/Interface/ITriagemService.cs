using RH.DTOs;

namespace RH.Service.Interface
{
    public interface ITriagemService
    {
        Task<List<VagaTecnologiaRequisitoDto>> GerarRelatorioCandidatosVaga(int idVaga);
    }
}