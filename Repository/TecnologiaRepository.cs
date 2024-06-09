using RH.Data;
using RH.Models;
using RH.Repository.Interface;

namespace RH.Repository
{
    public class TecnologiaRepository : RepositoryBase<Tecnologia>, ITecnologiaRepository
    {
        public TecnologiaRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}