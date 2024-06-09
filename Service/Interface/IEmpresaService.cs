using RH.DTOs;
using RH.Models;

namespace RH.Service.Interface
{
    public interface IEmpresaService : IService<Empresa>
    {
        Task Atualizar(EmpresaDto empresaDto, int id);

        Task Cadastrar(EmpresaDto empresaDto);
    }
}