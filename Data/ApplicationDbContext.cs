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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //
        }
    }
}