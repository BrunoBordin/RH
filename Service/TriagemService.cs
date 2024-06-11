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
            var vaga = await _repositoryVaga.BuscarVagaTecnologiasPorIdVaga(idVaga);

            var candidatos = await _repositoryCandidato.BuscarCandidatosPorIdVaga(idVaga);

            var candidatosPontuados = new List<VagaTecnologiaRequisitoDto>();

            foreach (var candidato in candidatos)
            {
                int pontuacaoTotal = 0;

                foreach (var ct in candidato)
                {
                    var vagaTecnologia = vaga.FirstOrDefault(vt => vt.IdTecnologia == ct.IdTecnologia);
                    if (vagaTecnologia != null)
                    {
                        pontuacaoTotal += vagaTecnologia.Peso;
                    }
                }
                var entidade = _mapper.Map<CandidatoDto>(candidato);
                candidatosPontuados.Add(new CandidatoPontuadoDto
                {
                    CandidatoDto = entidade,
                    Pontuacao = pontuacaoTotal
                });
            }

            return candidatosPontuados.OrderByDescending(cp => cp.Peso).ToList();
        }
    }
}