using AutoMapper;
using RH.DTOs;
using RH.Repository.Interface;
using RH.Service.Interface;

namespace RH.Service
{
    public class TriagemService : ITriagemService
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

        public async Task<List<CandidatoPontuadoDto>> GerarRelatorioCandidatosVaga(int idVaga)
        {
            var vaga = await _repositoryVaga.BuscarVagaTecnologiasPorIdVaga(idVaga);

            var candidatos = await _repositoryCandidato.BuscarCandidatosPorIdVaga(idVaga);

            var candidatosPontuados = new List<CandidatoPontuadoDto>();

            foreach (var candidato in candidatos)
            {
                int pontuacaoTotal = 0;

                foreach (var ct in candidato.CandidatoTecnologias)
                {
                    var vagaTecnologia = vaga.VagaTecnologias.FirstOrDefault(vt => vt.IdTecnologia == ct.IdTecnologia);
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

            return candidatosPontuados.OrderByDescending(cp => cp.Pontuacao).ToList();
        }
    }
}