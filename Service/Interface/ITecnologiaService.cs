using RH.DTOs;

namespace RH.Service.Interface
{
    public interface ITecnologiaService
    {
        Task Atualizar(TecnologiaDto tecnologiaDto, int id);

        Task Cadastrar(TecnologiaDto tecnologiaDto);

        Task<IList<TecnologiaDto>> ListarTodos();

        Task<TecnologiaDto> BuscarPorId(int id);

        Task Deletar(int id);

        Task VincularTecnologiaEmpresa(EmpresaTecnologiaDto empresaTecnologiaDto);
    }
}