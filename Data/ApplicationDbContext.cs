using Microsoft.EntityFrameworkCore;
using RH.Models;

namespace RH.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Vaga> Vaga { get; set; }
        public DbSet<Tecnologia> Tecnologia { get; set; }
        public DbSet<Candidato> Candidato { get; set; }
        public DbSet<CandidatoVaga> CandidatosVagas { get; set; }
        public DbSet<CandidatoTecnologia> CandidatosTecnologia { get; set; }
        public DbSet<PesoTecnologia> PesosTecnologia { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CandidatoVaga>()
            .HasKey(cv => new { cv.IdCandidato, cv.IdVaga });

            modelBuilder.Entity<CandidatoTecnologia>()
                .HasKey(ct => new { ct.IdCandidato, ct.IdTecnologia });

            modelBuilder.Entity<PesoTecnologia>()
                .HasKey(pt => new { pt.Id });

            modelBuilder.Entity<PesoTecnologia>()
                .HasOne(pt => pt.Vaga)
                .WithMany(v => v.PesosTecnologias)
                .HasForeignKey(pt => pt.Id);

            modelBuilder.Entity<PesoTecnologia>()
                .HasOne(pt => pt.Tecnologia)
                .WithMany(t => t.PesosVagas)
                .HasForeignKey(pt => pt.IdTecnologia);
        }
    }
}