using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RH.Data;
using RH.DTOs;
using RH.Models;
using RH.Repository.Interface;

namespace RH.Repository
{
    public class CandidatoRepository : RepositoryBase<Candidato>, ICandidatoRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CandidatoRepository(ApplicationDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public async Task<List<EntrevistaCandidatoDTO>> ListaEntrevistas()
        {
            var entrevistaVaga = (from v in _dbContext.VinculoCanditadoVaga
                                  join can in _dbContext.Candidato on v.IdCandidato equals can.Id
                                  join va in _dbContext.Vaga on v.IdVaga equals va.Id
                                  select new EntrevistaCandidatoDTO()
                                  {
                                      Candidato = can.Nome,
                                      Vaga = va.Descricao,
                                      IdVaga = v.Id
                                  }).ToList();


            foreach (var item in entrevistaVaga)
            {
                var tec = (from t in _dbContext.VinculoCanditadoVagaTecnologia
                           join te in _dbContext.Tecnologia on t.IdTecnologia equals te.Id
                           where t.IdVinculoCandidatoVaga == item.IdVaga
                           select te.Nome).ToList();

                item.Tecnologias = string.Join(", ", tec);
            }

            return entrevistaVaga;
        }
    }
}
