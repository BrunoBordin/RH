using Microsoft.EntityFrameworkCore;
using RH.Data;
using RH.DTOs;
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

        public async Task<VagaTecnologiaRequisito> BuscarVagaTecnologiaPorId(int id)
        {
            return await _context.VagaTecnologiaRequisito.FindAsync(id);
        }

        public async Task<List<VagaTecnologiaPesoDto>> ListarVagaTecnologiaRequisito()
        {
            var result = await (from vtr in _dbContext.VagaTecnologiaRequisito
                                join t in _dbContext.Tecnologia on vtr.IdTecnologia equals t.Id
                                join v in _dbContext.Vaga on vtr.IdVaga equals v.Id
                                select new VagaTecnologiaPesoDto
                                {
                                    IdVagaTecnologiaRequisito = vtr.Id,
                                    Peso = vtr.Peso,
                                    NomeTecnologia = t.Nome,
                                    NomeVaga = v.Titulo
                                }).ToListAsync();

            return result;
        }

        public async Task SetarPesoVagaTecnologiaRequisito(VagaTecnologiaRequisito vagaTecnologiaRequ)
        {
            _context.Entry(vagaTecnologiaRequ).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task VincularCandidatoVaga(int idCandidato, int idVaga, List<int> listaTecnologias)
        {
            var entidade = new VinculoCanditadoVaga()
            {
                IdCandidato = idCandidato,
                IdVaga = idVaga,
            };
            await _dbContext.VinculoCanditadoVaga.AddAsync(entidade);

             await _dbContext.SaveChangesAsync();

            await VincularCanditadoVagaTecnologia(entidade.Id, listaTecnologias);
        }

        private async Task VincularCanditadoVagaTecnologia(int idVinculoCandidatoVaga, List<int> listaTecnologias)
        {

            foreach (var item in listaTecnologias)
            {
                var vinculo = new VinculoCanditadoVagaTecnologia()
                {
                    IdVinculoCandidatoVaga = idVinculoCandidatoVaga,
                    IdTecnologia = item
                };

                await _dbContext.VinculoCanditadoVagaTecnologia.AddAsync(vinculo);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task VincularVagaTecnologiaRequisito(VagaTecnologiaRequisito entidade)
        {
            await _dbContext.VagaTecnologiaRequisito.AddAsync(entidade);
            await _dbContext.SaveChangesAsync();
        }
    }
}