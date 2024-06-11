using Microsoft.EntityFrameworkCore;
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

        public async Task<List<EmpresaTecnologia>> ListarTodosPorEmpresa(int id)
        {
            return await _dbContext.EmpresaTecnologia.ToListAsync();
        }

        public async Task VincularTecnologiaEmpresa(EmpresaTecnologia entidade)
        {
            await _dbContext.EmpresaTecnologia.AddAsync(entidade);
            await _dbContext.SaveChangesAsync();
        }
    }
}