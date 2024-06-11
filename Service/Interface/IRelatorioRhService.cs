using RH.DTOs;

namespace RH.Service.Interface
{
    public interface IRelatorioRhService
    {
        Task<List<VagaTecnologiaRequisitoDto>> GerarRelatorioCandidatosVaga(int idVaga);
    }
}