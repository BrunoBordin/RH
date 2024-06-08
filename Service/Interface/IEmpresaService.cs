using RH.DTOs;
using RH.Models;

namespace RH.Service.Interface
{
    public interface IEmpresaService
    {
        Task CadastrarEmpresa(EmpresaDto empresaDto);

        Task<Vaga> CadastrarVaga(VagaDto vagaDto, int empresaId);

        Task<List<Vaga>> ObterVagasPorEmpresa(int empresaId);

        Task<Tecnologia> CadastrarTecnologia(TecnologiaDto tecnologiaDto, int empresaId);

        Task AtualizarEmpresa(EmpresaDto empresaDto, int idEmpresa);

        Task DeletarEmpresa(int idEmpresa);

        Task<EmpresaDto> ObterPorId(int idEmpresa);

        Task<List<EmpresaDto>> ListarEmpresa();
    }
}