using RH.Repository.Interface;
using RH.Service.Interface;

namespace RH.Service
{
    public class CandidatoService : ICandidatoService
    {
        private readonly ICandidatoRepository _candidatoRepository;

        public CandidatoService(ICandidatoRepository candidatoRepository)
        {
            _candidatoRepository = candidatoRepository;
        }

        public Task VincularTecncologiasUsuario(int idUsuario, List<int> idTecnologia)
        {
            throw new NotImplementedException();
        }
    }
}