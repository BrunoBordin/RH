using AutoMapper;
using RH.DTOs;
using RH.Models;
using RH.Repository.Interface;
using RH.Service.Interface;

namespace RH.Service
{
    public class CandidatoService : ServiceBase<Candidato>, ICandidatoService
    {
        private readonly IMapper _mapper;

        public CandidatoService(ICandidatoRepository candidatoRepository, IMapper mapper) : base(candidatoRepository)
        {
            _mapper = mapper;
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
    }
}