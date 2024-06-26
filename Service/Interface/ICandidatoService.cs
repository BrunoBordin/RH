﻿using RH.DTOs;

namespace RH.Service.Interface
{
    public interface ICandidatoService
    {
        Task Atualizar(CandidatoDto candidatoDto, int id);

        Task Cadastrar(CandidatoDto candidatoDto);

        Task<IList<CandidatoDto>> ListarTodos();

        Task<CandidatoDto> BuscarPorId(int id);

        Task Deletar(int id);
        Task<IList<EntrevistaCandidatoDTO>> ObterListaEntrevistas();
    }
}