using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RH.Data;
using RH.DTOs;
using RH.Repository.Interface;

namespace RH.Repository
{
    public class RelatorioRepository : IRelatorioRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public RelatorioRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<RelatorioCandidatosDto>> GerarRelatorioCandidatosVaga(int idVaga)
        {
            var query = @"select nome as NomeCandidato, sum(pesoCandidato) as Pontuacao
                             from (
                            select c.nome, (select peso  from VagaTecnologiaRequisito p where p.IdTecnologia = t.IdTecnologia and p.IdVaga = v.IdVaga) as pesoCandidato
                             from VinculoCanditadoVaga v
                             inner join VinculoCanditadoVagaTecnologia t on v.Id= t.IdVinculoCandidatoVaga
                             inner join Candidato c on c.Id = v.IdCandidato
                             where v.IdVaga = @idVaga
                            ) rh
                            group by rh.nome
                            order by Pontuacao desc";

            var result = new List<RelatorioCandidatosDto>();

            using (var command = _dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = query;
                command.Parameters.Add(new SqlParameter("@idVaga", idVaga));

                await _dbContext.Database.OpenConnectionAsync();

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        result.Add(new RelatorioCandidatosDto
                        {
                            Candidato = reader.GetString(0),
                            Pontuacao = reader.GetInt32(1)
                        });
                    }
                }
            }

            return result;
        }
    }
}