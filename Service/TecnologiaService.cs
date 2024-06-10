using AutoMapper;
using RH.DTOs;
using RH.Models;
using RH.Repository.Interface;
using RH.Service.Interface;

namespace RH.Service
{
    public class TecnologiaService : ITecnologiaService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Tecnologia> _repository;

        public TecnologiaService(IMapper mapper, IRepository<Tecnologia> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task Atualizar(TecnologiaDto tecnologiaDto, int id)
        {
            var tecnologia = await _repository.BuscarPorId(id) ?? throw new KeyNotFoundException("tecnologia nao encontrda");
            tecnologia.Nome = tecnologiaDto.Nome;
            await _repository.Atualizar(tecnologia);
        }

        public async Task Cadastrar(TecnologiaDto tecnologiaDto)
        {
            var entidade = _mapper.Map<Tecnologia>(tecnologiaDto);

            await _repository.Cadastrar(entidade);
        }

        public async Task<IList<TecnologiaDto>> ListarTodos()
        {
            var resultList = await _repository.ListarTodos();

            return _mapper.Map<IList<TecnologiaDto>>(resultList);
        }

        public async Task<TecnologiaDto> BuscarPorId(int id)
        {
            var result = await _repository.BuscarPorId(id);

            return _mapper.Map<TecnologiaDto>(result);
        }

        public async Task Deletar(TecnologiaDto entity)
        {
            var entidade = _mapper.Map<Tecnologia>(entity);
            await _repository.Deletar(entidade);
        }
    }
}