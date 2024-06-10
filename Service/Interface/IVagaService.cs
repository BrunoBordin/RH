using RH.DTOs;

namespace RH.Service.Interface
{
    public interface IVagaService
    {
        Task Atualizar(VagaDto vagaDto, int id);

        Task Cadastrar(VagaDto vagaDto);

        Task<IList<VagaDto>> ListarTodos();

        Task<VagaDto> BuscarPorId(int id);

        Task Deletar(int id);

        Task DefinirPesos(int idVaga, Dictionary<int, int> tecnologiaPesos);
    }
}