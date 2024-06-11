using RH.DTOs;
using RH.Models;

namespace RH.Repository.Interface
{
    public interface IVagaRepository : IRepository<Vaga>
    {
        Task<VagaTecnologiaRequisito> BuscarVagaTecnologiaPorId(int id);

        Task<List<VagaTecnologiaPesoDto>> ListarVagaTecnologiaRequisito();

        Task SetarPesoVagaTecnologiaRequisito(VagaTecnologiaRequisito vagaTecnologiaRequ);

        Task VincularCandidatoVaga(VinculoCanditadoVaga vinculoCanditadoVaga);

        Task VincularCanditadoVagaTecnologia(VinculoCanditadoVagaTecnologia entidade);

        Task VincularVagaTecnologiaRequisito(VagaTecnologiaRequisito entidade);
    }
}