using RH.DTOs;
using RH.Models;

namespace RH.Repository.Interface
{
    public interface ICandidatoRepository : IRepository<Candidato>
    {
        Task<List<EntrevistaCandidatoDTO>> ListaEntrevistas();
    }
}