using RH.Data;
using RH.Models;
using RH.Repository.Interface;

namespace RH.Repository
{
    public class TecnologiaRepository : RepositoryBase<Tecnologia>, ITecnologiaRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public TecnologiaRepository(ApplicationDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public async Task VincularTecnologiaCandidato(CandidatoTecnologia entidade)
        {
            await _dbContext.CandidatoTecnologia.AddAsync(entidade);
            await _dbContext.SaveChangesAsync();
        }

        public async Task VincularTecnologiaEmpresa(EmpresaTecnologia entidade)
        {
            await _dbContext.EmpresaTecnologia.AddAsync(entidade);
            await _dbContext.SaveChangesAsync();
        }

        public async Task VincularTecnologiaVaga(VagaTecnologia entidade)
        {
            await _dbContext.VagaTecnologia.AddAsync(entidade);
            await _dbContext.SaveChangesAsync();
        }
    }
}