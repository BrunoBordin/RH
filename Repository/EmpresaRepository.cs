using RH.Data;
using RH.Models;
using RH.Repository.Interface;

namespace RH.Repository
{
    public class EmpresaRepository : RepositoryBase<Empresa>, IEmpresaRepository
    {
        public EmpresaRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}