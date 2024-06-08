using RH.DTOs;
using RH.Models;

namespace RH.Repository.Interface
{
    public interface IEmpresaRepository
    {
        Task CadastrarEmpresa(Empresa empresaDto);

        Task CadastrarVaga(Vaga vagaDto, int empresaId);

        Task<List<Vaga>> ObterVagasPorEmpresa(int empresaId);

        Task CadastrarTecnologia(Tecnologia tecnologiaDto, int empresaId);
    }
}
