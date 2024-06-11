using RH.Models;

namespace RH.Repository.Interface
{
    public interface ITecnologiaRepository : IRepository<Tecnologia>
    {
        Task<List<EmpresaTecnologia>> ListarTodosPorEmpresa(int id);
        Task VincularTecnologiaEmpresa(EmpresaTecnologia entidade);
    }
}