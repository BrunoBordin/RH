using RH.Models;

namespace RH.Repository.Interface
{
    public interface IVagaRepository : IRepository<Vaga>
    {
        Task DefinirPesos(List<VagaTecnologia> vagaTecnologia);

        Task<Vaga> BuscarVagaTecnologiasPorIdVaga(int idVaga);
    }
}