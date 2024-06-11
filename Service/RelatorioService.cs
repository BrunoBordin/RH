using RH.DTOs;
using RH.Repository.Interface;
using RH.Service.Interface;

namespace RH.Service
{
    public class RelatorioService : IRelatorioService
    {
        private readonly IRelatorioRepository _repository;

        public RelatorioService(IRelatorioRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<RelatorioCandidatosDto>> GerarRelatorioCandidatosVaga(int idVaga)
        {
            List<RelatorioCandidatosDto> candidatos = await _repository.GerarRelatorioCandidatosVaga(idVaga);

            return candidatos;
        }
    }
}