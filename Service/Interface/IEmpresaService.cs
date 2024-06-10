using RH.DTOs;

namespace RH.Service.Interface
{
    public interface IEmpresaService
    {
        Task Atualizar(CandidatoDto candidatoDto, int id);

        Task Cadastrar(CandidatoDto candidatoDto);

        Task<IList<CandidatoDto>> ListarTodos();

        Task<CandidatoDto> BuscarPorId(int id);

        Task Deletar(int id);

        Task VincularCandidatoTecnologia(int idCandidato, List<int> idTecnologia);
    }
}
