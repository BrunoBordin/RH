using RH.Models;

namespace RH.Repository.Interface
{
    public interface IVagaRepository : IRepository<Vaga>
    {
        Task DefinirPesos(List<VagaTecnologia> vagaTecnologia);

        Task<List<VagaTecnologia>> BuscarVagaTecnologiasPorIdVaga(int idVaga);
    }
}