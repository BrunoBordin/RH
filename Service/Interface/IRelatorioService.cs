using RH.DTOs;

namespace RH.Service.Interface
{
    public interface IRelatorioService
    {
        Task<List<RelatorioCandidatosDto>> GerarRelatorioCandidatosVaga(int idVaga);
    }
}
