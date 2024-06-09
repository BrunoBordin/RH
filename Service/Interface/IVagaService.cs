using RH.DTOs;
using RH.Models;

namespace RH.Service.Interface
{
    public interface IVagaService : IService<Vaga>
    {
        Task Atualizar(VagaDto vagaDto, int id);

        Task Cadastrar(VagaDto vagaDto);
    }
}