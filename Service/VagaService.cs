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

        public async Task Atualizar(VagaDto vagaDto, int id)
        {
            var vaga = await _repository.BuscarPorId(id) ?? throw new KeyNotFoundException("Vaga nao encontrada.");
            vaga.Titulo = vaga.Titulo;
            vaga.Descricao = vaga.Descricao;
            await _repository.Atualizar(vaga);
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

        public async Task Deletar(int id)
        {
            var entidade = await _repository.BuscarPorId(id) ?? throw new KeyNotFoundException("Vaga não encontrada");

            await _repository.Deletar(entidade);
        }

        public async Task DefinirPesos(int idVaga, Dictionary<int, int> tecnologiaPesos)
        {
            try
            {
                var vagaTecnologiaList = tecnologiaPesos.Select(item => new VagaTecnologia
                {
                    IdVaga = idVaga,
                    IdTecnologia = item.Key
                }).ToList();

                await _repositoryVaga.DefinirPesos(vagaTecnologiaList);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task VincularVagaEmpresa(List<EmpresaVagaDto> empresaVagaDto)
        {
            var entidade = _mapper.Map<List<EmpresaVaga>>(empresaVagaDto);
            await _repositoryVaga.VincularVagaEmpresa(entidade);
        }

        public async Task VincularCandidatoVaga(VinculoCanditadoVagaDto vinculoCanditadoVagaDto)
        {
            var entidade = _mapper.Map<VinculoCanditadoVaga>(vinculoCanditadoVagaDto);

            await _repositoryVaga.VincularCandidatoVaga(entidade);
        }

        public async Task VincularCanditadoVagaTecnologia(VinculoCanditadoVagaTecnologiaDto vinculoCanditadoVagaTecnologiaDto)
        {
            var entidade = _mapper.Map<VinculoCanditadoVagaTecnologia>(vinculoCanditadoVagaTecnologiaDto);
            await _repositoryVaga.VincularCanditadoVagaTecnologia(entidade);
        }
    }
}