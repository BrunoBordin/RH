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
        private readonly ITecnologiaRepository _tecnologiaRepository;

        public TecnologiaService(IMapper mapper, IRepository<Tecnologia> repository, ITecnologiaRepository tecnologiaRepository)
        {
            _mapper = mapper;
            _repository = repository;
            _tecnologiaRepository = tecnologiaRepository;
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

        public async Task Deletar(int id)
        {
            var tecnologia = await _repository.BuscarPorId(id) ?? throw new KeyNotFoundException("Tecnologia não encontrada");
            await _repository.Deletar(tecnologia);
        }

        public async Task VincularTecnologiaEmpresa(EmpresaTecnologiaDto empresaTecnologiaDto)
        {
            var entidade = _mapper.Map<EmpresaTecnologia>(empresaTecnologiaDto);

            await _tecnologiaRepository.VincularTecnologiaEmpresa(entidade);
        }
    }
}