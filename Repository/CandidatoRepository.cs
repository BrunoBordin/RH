using RH.Data;
using RH.Models;
using RH.Repository.Interface;

namespace RH.Repository
{
    public class CandidatoRepository : RepositoryBase<Candidato>, ICandidatoRepository
    {
        public CandidatoRepository(ApplicationDbContext context) : base(context)
        {
        }

    }
}