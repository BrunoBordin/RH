using RH.Data;
using RH.Models;
using RH.Repository.Interface;

namespace RH.Repository
{
    public class VagaRepository : RepositoryBase<Vaga>, IVagaRepository
    {
        public VagaRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}