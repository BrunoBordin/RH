﻿using RH.Data;
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

        public async Task VincularCandidatoVaga(VinculoCanditadoVaga vinculoCanditadoVaga)
        {
            await _dbContext.VinculoCanditadoVaga.AddAsync(vinculoCanditadoVaga);
            await _dbContext.SaveChangesAsync();
        }

        public async Task VincularCanditadoVagaTecnologia(VinculoCanditadoVagaTecnologia vinculoCanditadoVagaTecnologia)
        {
            await _dbContext.VinculoCanditadoVagaTecnologia.AddAsync(vinculoCanditadoVagaTecnologia);
            await _dbContext.SaveChangesAsync();
        }
    }
}