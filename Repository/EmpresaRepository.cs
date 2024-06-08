using RH.Data;
using RH.Models;
using RH.Repository.Interface;

namespace RH.Repository
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private ApplicationDbContext _dbContext;

        public EmpresaRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public async Task CadastrarEmpresa(Empresa empresa)
        {
            try
            {
               await  _dbContext.AddAsync(empresa);
               await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task CadastrarTecnologia(Tecnologia tecnologiaDto, int empresaId)
        {
            throw new NotImplementedException();
        }

        public async Task CadastrarVaga(Vaga vagaDto, int empresaId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Vaga>> ObterVagasPorEmpresa(int empresaId)
        {
            throw new NotImplementedException();
        }
    }
}