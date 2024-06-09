using RH.DTOs;
using RH.Models;

namespace RH.Service.Interface
{
    public interface ICandidatoService : IService<Candidato>
    {
        Task Atualizar(CandidatoDto candidatoDto, int id);

        Task Cadastrar(CandidatoDto candidatoDto);
    }
}