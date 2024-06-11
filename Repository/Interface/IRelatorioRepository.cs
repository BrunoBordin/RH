using RH.DTOs;

namespace RH.Repository.Interface
{
    public interface IRelatorioRepository
    {
        Task<List<RelatorioCandidatosDto>> GerarRelatorioCandidatosVaga(int idVaga);
    }
}