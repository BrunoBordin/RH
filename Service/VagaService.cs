using AutoMapper;
using RH.DTOs;
using RH.Models;
using RH.Repository.Interface;
using RH.Service.Interface;

namespace RH.Service
{
    public class VagaService : IVagaService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Vaga> _repository;
        private readonly IVagaRepository _repositoryVaga;

        public VagaService(IMapper mapper, IRepository<Vaga> repository, IVagaRepository repositoryVaga)
        {
            _mapper = mapper;
            _repository = repository;
            _repositoryVaga = repositoryVaga;
        }

        public Task Atualizar(VagaDto vagaDto, int id)
        {
            throw new NotImplementedException();
        }

        public async Task Cadastrar(VagaDto vagaDto)
        {
            var entidade = _mapper.Map<Vaga>(vagaDto);

            await _repository.Cadastrar(entidade);
        }

        public async Task<IList<VagaDto>> ListarTodos()
        {
            var resultList = await _repository.ListarTodos();

            return _mapper.Map<IList<VagaDto>>(resultList);
        }

        public async Task<VagaDto> BuscarPorId(int id)
        {
            var result = await _repository.BuscarPorId(id);

            return _mapper.Map<VagaDto>(result);
        }

        public async Task Deletar(VagaDto entity)
        {
            var entidade = _mapper.Map<Vaga>(entity);
            await _repository.Deletar(entidade);
        }

        public async Task DefinirPesos(int idVaga, Dictionary<int, int> tecnologiaPesos)
        {
            try
            {
                var vagaTecnologiaList = tecnologiaPesos.Select(item => new VagaTecnologia
                {
                    IdVaga = idVaga,
                    IdTecnologia = item.Key,
                    Peso = item.Value
                }).ToList();

                await _repositoryVaga.DefinirPesos(vagaTecnologiaList);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}