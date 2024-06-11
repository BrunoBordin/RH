using RH.Models;

namespace RH.Repository.Interface
{
    public interface ITecnologiaRepository : IRepository<Tecnologia>
    {
        Task VincularTecnologiaCandidato(CandidatoTecnologia entidade);
        Task VincularTecnologiaEmpresa(EmpresaTecnologia entidade);
        Task VincularTecnologiaVaga(VagaTecnologia entidade);
    }
}