using AutoMapper;
using RH.DTOs;
using RH.Models;
using RH.Repository.Interface;
using RH.Service.Interface;

namespace RH.Service
{
    public class VagaService : ServiceBase<Vaga>, IVagaService
    {
        private readonly IMapper _mapper;

        public VagaService(IMapper mapper, IVagaRepository repository) : base(repository)
        {
            _mapper = mapper;
        }

        public Task Atualizar(VagaDto vagaDto, int id)
        {
            throw new NotImplementedException();
        }

        public Task Cadastrar(VagaDto vagaDto)
        {
            throw new NotImplementedException();
        }
    }
}