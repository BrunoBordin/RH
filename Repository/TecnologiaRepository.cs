using Microsoft.EntityFrameworkCore;
using RH.Data;
using RH.DTOs;
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

        public async Task<List<TecnologiaEmpresaDto>> ListarTodosPorEmpresa(int id)
        {
            var result = await (from emtec in _dbContext.EmpresaTecnologia
                                join tec in _dbContext.Tecnologia on emtec.IdTecnologia equals tec.Id
                                join emp in _dbContext.Empresa on emtec.IdEmpresa equals emp.Id
                                where emp.Id == id
                                select new TecnologiaEmpresaDto
                                {
                                    IdTecnologia = tec.Id,
                                    IdEmpresa = emp.Id,
                                    NomeTecnologia = tec.Nome,
                                    NomeEmpresa = emp.Nome
                                }).ToListAsync();

            return result;
        }

        public async Task VincularTecnologiaEmpresa(EmpresaTecnologia entidade)
        {
            await _dbContext.EmpresaTecnologia.AddAsync(entidade);
            await _dbContext.SaveChangesAsync();
        }
    }
}