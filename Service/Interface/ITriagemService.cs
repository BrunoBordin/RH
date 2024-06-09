using RH.DTOs;

namespace RH.Service.Interface
{
    public interface ITriagemService
    {
        Task<List<CandidatoPontuadoDto>> GerarRelatorioCandidatosVaga(int idVaga);
    }
}