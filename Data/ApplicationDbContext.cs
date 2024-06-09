using Microsoft.EntityFrameworkCore;
using RH.Models;

namespace RH.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Tecnologia> Tecnologia { get; set; }
        public DbSet<Vaga> Vaga { get; set; }
        public DbSet<Candidato> Candidato { get; set; }
        public DbSet<CandidatoTecnologia> CandidatoTecnologia { get; set; }
        public DbSet<VagaTecnologia> VagaTecnologia { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Candidato>()
                .HasKey(c => c.IdCandidato);

            modelBuilder.Entity<Tecnologia>()
                .HasKey(t => t.IdTecnologia);

            modelBuilder.Entity<Vaga>()
                .HasKey(v => v.IdVaga);

            modelBuilder.Entity<CandidatoTecnologia>()
                .HasKey(ct => new { ct.IdCandidato, ct.IdTecnologia });

            modelBuilder.Entity<CandidatoTecnologia>()
                .HasOne(ct => ct.Candidato)
                .WithMany(c => c.CandidatoTecnologias)
                .HasForeignKey(ct => ct.IdCandidato);

            modelBuilder.Entity<CandidatoTecnologia>()
                .HasOne(ct => ct.Tecnologia)
                .WithMany()
                .HasForeignKey(ct => ct.IdTecnologia);

            modelBuilder.Entity<VagaTecnologia>()
                .HasKey(vt => new { vt.IdVaga, vt.IdTecnologia });

            modelBuilder.Entity<VagaTecnologia>()
                .HasOne(vt => vt.Vaga)
                .WithMany(v => v.VagaTecnologias)
                .HasForeignKey(vt => vt.IdVaga);

            modelBuilder.Entity<VagaTecnologia>()
                .HasOne(vt => vt.Tecnologia)
                .WithMany()
                .HasForeignKey(vt => vt.IdTecnologia);
        }
    }
}