using AutoMapper;
using RH.DTOs;
using RH.Models;
using RH.Repository.Interface;
using RH.Service.Interface;

namespace RH.Service
{
    public class TecnologiaService : ServiceBase<Tecnologia>, ITecnologiaService
    {
        private readonly IMapper _mapper;
        private readonly ITecnologiaRepository _repository;

        public TecnologiaService(IMapper mapper, ITecnologiaRepository repository) : base(repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task Atualizar(TecnologiaDto tecnologiaDto, int id)
        {
            var tecnologia = await _repository.BuscarPorId(id);

            if (tecnologia == null)
            {
                throw new KeyNotFoundException("tecnologia nao encontrda");
            }

            _mapper.Map(tecnologiaDto, tecnologia);
            await _repository.Atualizar(tecnologia);
        }

        public async Task Cadastrar(TecnologiaDto tecnologiaDto)
        {
            var entidade = _mapper.Map<Tecnologia>(tecnologiaDto);

            await _repository.Cadastrar(entidade);
        }
    }
}