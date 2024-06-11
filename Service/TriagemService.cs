using AutoMapper;
using RH.DTOs;
using RH.Repository.Interface;
using RH.Service.Interface;

namespace RH.Service
{
    public class TriagemService : IRelatorioRhService
    {
        private readonly IMapper _mapper;
        private readonly IVagaRepository _repositoryVaga;
        private readonly ICandidatoRepository _repositoryCandidato;

        public TriagemService(IMapper mapper, IVagaRepository repositoryVaga, ICandidatoRepository repositoryCandidato)
        {
            _repositoryVaga = repositoryVaga;
            _repositoryCandidato = repositoryCandidato;
            _mapper = mapper;
        }

        public async Task<List<VagaTecnologiaRequisitoDto>> GerarRelatorioCandidatosVaga(int idVaga)
        {
            return null;
        }
    }
}