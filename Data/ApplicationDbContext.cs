using Microsoft.EntityFrameworkCore;
using RH.Models;

namespace RH.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Candidato> Candidato { get; set; }
        public DbSet<Tecnologia> Tecnologia { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<EmpresaTecnologia> EmpresaTecnologia { get; set; }
        public DbSet<Vaga> Vaga { get; set; }
        public DbSet<VagaTecnologiaRequisito> VagaTecnologiaRequisito { get; set; }
        public DbSet<VinculoCanditadoVaga> VinculoCanditadoVaga { get; set; }
        public DbSet<VinculoCanditadoVagaTecnologia> VinculoCanditadoVagaTecnologia { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Candidato>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nome).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<Tecnologia>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nome).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nome).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<EmpresaTecnologia>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne<Empresa>()
                      .WithMany()
                      .HasForeignKey(e => e.IdEmpresa);
                entity.HasOne<Tecnologia>()
                      .WithMany()
                      .HasForeignKey(e => e.IdTecnologia);
            });

            modelBuilder.Entity<Vaga>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Titulo).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Descricao).IsRequired();
                entity.Property(e => e.Aberta).IsRequired();
            });

            modelBuilder.Entity<VagaTecnologiaRequisito>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne<Vaga>()
                      .WithMany()
                      .HasForeignKey(e => e.IdVaga);
                entity.HasOne<Tecnologia>()
                      .WithMany()
                      .HasForeignKey(e => e.IdTecnologia);
                entity.Property(e => e.Peso).IsRequired();
            });

            modelBuilder.Entity<VinculoCanditadoVaga>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne<Candidato>()
                      .WithMany()
                      .HasForeignKey(e => e.IdCandidato);
                entity.HasOne<Vaga>()
                      .WithMany()
                      .HasForeignKey(e => e.IdVaga);
            });

            modelBuilder.Entity<VinculoCanditadoVagaTecnologia>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne<VinculoCanditadoVaga>()
                      .WithMany()
                      .HasForeignKey(e => e.IdVinculoCandidatoVaga);
                entity.HasOne<Tecnologia>()
                      .WithMany()
                      .HasForeignKey(e => e.IdTecnologia);
            });
        }
    }
}