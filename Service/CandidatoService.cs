﻿using AutoMapper;
using RH.DTOs;
using RH.Models;
using RH.Repository.Interface;
using RH.Service.Interface;

namespace RH.Service
{
    public class CandidatoService : ICandidatoService
    {
        private readonly IMapper _mapper;
        private readonly ITecnologiaService _tecService;

        protected readonly IRepository<Candidato> _repository;
        private readonly ICandidatoRepository _candidatoRepository;

        public CandidatoService(IRepository<Candidato> repository, IMapper mapper, ITecnologiaService tecService, ICandidatoRepository candidatoRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _tecService = tecService;
            _candidatoRepository = candidatoRepository;
        }

        public async Task Atualizar(CandidatoDto candidatoDto, int id)
        {
            var candidato = await _repository.BuscarPorId(id);
            if (candidato == null)
            {
                throw new KeyNotFoundException("Candidato nao encontrado");
            }

            _mapper.Map(candidatoDto, candidato);
            await _repository.Atualizar(candidato);
        }

        public async Task Cadastrar(CandidatoDto candidatoDto)
        {
            var entidade = _mapper.Map<Candidato>(candidatoDto);

            await _repository.Cadastrar(entidade);
        }

        public async Task<IList<CandidatoDto>> ListarTodos()
        {
            var resultList = await _repository.ListarTodos();

            return _mapper.Map<IList<CandidatoDto>>(resultList);
        }

        public async Task<CandidatoDto> BuscarPorId(int id)
        {
            var result = await _repository.BuscarPorId(id);

            return _mapper.Map<CandidatoDto>(result);
        }

        public async Task Deletar(CandidatoDto entity)
        {
            var entidade = _mapper.Map<Candidato>(entity);
            await _repository.Deletar(entidade);
        }

        public async Task VincularCandidatoTecnologia(int idCandidato, List<int> idsTecnologia)
        {
            var candidatoTecnologias = idsTecnologia.Select(idTecnologia => new CandidatoTecnologia
            {
                IdCandidato = idCandidato,
                IdTecnologia = idTecnologia
            }).ToList();

            await _candidatoRepository.VincularCandidatoTecnologia(candidatoTecnologias);
        }
    }
}