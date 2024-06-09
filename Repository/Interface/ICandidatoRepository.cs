using RH.Models;

namespace RH.Repository.Interface
{
    public interface ICandidatoRepository : IRepository<Candidato>
    {
        Task<List<Candidato>> BuscarCandidatosPorIdVaga(int idVaga);

        Task VincularCandidatoTecnologia(List<CandidatoTecnologia> candidatoTecnologias);
    }
}