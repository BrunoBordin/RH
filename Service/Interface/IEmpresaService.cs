using RH.DTOs;

namespace RH.Service.Interface
{
    public interface IEmpresaService
    {
        Task Atualizar(EmpresaDto candidatoDto, int id);

        Task Cadastrar(EmpresaDto candidatoDto);

        Task<IList<EmpresaDto>> ListarTodos();

        Task<EmpresaDto> BuscarPorId(int id);

        Task Deletar(int id);
    }
}