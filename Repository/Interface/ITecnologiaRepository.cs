using RH.DTOs;
using RH.Models;

namespace RH.Repository.Interface
{
    public interface ITecnologiaRepository : IRepository<Tecnologia>
    {
        Task<List<TecnologiaEmpresaDto>> ListarTodosPorEmpresa(int id);
        Task VincularTecnologiaEmpresa(EmpresaTecnologia entidade);
    }
}