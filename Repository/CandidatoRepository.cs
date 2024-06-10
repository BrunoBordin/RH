using Microsoft.EntityFrameworkCore;
using RH.Data;
using RH.Models;
using RH.Repository.Interface;

namespace RH.Repository
{
    public class CandidatoRepository : RepositoryBase<Candidato>, ICandidatoRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CandidatoRepository(ApplicationDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public async Task<List<Candidato>> BuscarCandidatosPorIdVaga(int idVaga)
        {
           // var candidatos = await _dbContext.Candidato

           //.Where(c => c.IdVaga == idVaga)
           //.Include(c => c.CandidatoTecnologias)
           //.ThenInclude(ct => ct.Tecnologia)
           //.ToListAsync();

            return null;
        }

        public async Task VincularCandidatoTecnologia(List<CandidatoTecnologia> candidatoTecnologias)
        {
            await _dbContext.CandidatoTecnologia.AddRangeAsync(candidatoTecnologias);
            await _dbContext.SaveChangesAsync();
        }
    }
}