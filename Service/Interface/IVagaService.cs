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

        Task VincularCandidatoVaga(int idCandidato, int idVaga, List<int> listaTecnologias);

        Task<List<VagaTecnologiaPesoDto>> ListarVagaTecnologiaRequisito();

        Task SetarPesoVagaTecnologiaRequisito(VagaTecnologiaRequisitoDto vagaTecnologiaRequisitoDto, int id);
    }
}