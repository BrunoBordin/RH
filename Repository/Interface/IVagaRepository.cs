using RH.Models;

namespace RH.Repository.Interface
{
    public interface IVagaRepository : IRepository<Vaga>
    {
        Task VincularCandidatoVaga(VinculoCanditadoVaga vinculoCanditadoVaga);

        Task VincularCanditadoVagaTecnologia(VinculoCanditadoVagaTecnologia entidade);
    }
}