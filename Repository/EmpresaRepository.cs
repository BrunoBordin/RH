using RH.Data;
using RH.Models;
using RH.Repository.Interface;

namespace RH.Repository
{
    public class EmpresaRepository : RepositoryBase<Empresa>, IEmpresaRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public EmpresaRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }
    }
}