using Microsoft.EntityFrameworkCore;
using RH.Data;
using RH.Models;
using RH.Repository.Interface;

namespace RH.Repository
{
    public class VagaRepository : RepositoryBase<Vaga>, IVagaRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public VagaRepository(ApplicationDbContext context, ApplicationDbContext dbContext) : base(context)
        {
            _dbContext = dbContext;
        }

        public async Task<Vaga> BuscarVagaTecnologiasPorIdVaga(int idVaga)
        {
            var result = await _dbContext.Vaga.Include(x => x.VagaTecnologias)
                .FirstOrDefaultAsync(x => x.IdVaga == idVaga);

            return result;
        }

        public async Task DefinirPesos(List<VagaTecnologia> vagaTecnologiaList)
        {
            await _dbContext.VagaTecnologia.AddRangeAsync(vagaTecnologiaList);
            await _dbContext.SaveChangesAsync();
        }
    }
}