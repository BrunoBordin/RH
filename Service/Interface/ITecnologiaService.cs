using RH.DTOs;
using RH.Models;

namespace RH.Service.Interface
{
    public interface ITecnologiaService : IService<Tecnologia>
    {
        Task Atualizar(TecnologiaDto tecnologiaDto, int id);

        Task Cadastrar(TecnologiaDto tecnologiaDto);
    }
}