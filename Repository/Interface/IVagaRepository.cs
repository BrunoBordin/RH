using RH.DTOs;
using RH.Models;

namespace RH.Repository.Interface
{
    public interface IVagaRepository : IRepository<Vaga>
    {
        Task<List<VagaTecnologiaRequisito>> ListarVagaTecnologiaRequisito();

        Task VincularCandidatoVaga(VinculoCanditadoVaga vinculoCanditadoVaga);

        Task VincularCanditadoVagaTecnologia(VinculoCanditadoVagaTecnologia entidade);

        Task VincularVagaTecnologiaRequisito(VagaTecnologiaRequisito entidade);
    }
}