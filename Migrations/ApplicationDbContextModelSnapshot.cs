﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RH.Data;

#nullable disable

namespace RH.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RH.Models.Candidato", b =>
                {
                    b.Property<int>("IdCandidato")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCandidato"));

                    b.Property<int>("IdVaga")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VagaIdVaga")
                        .HasColumnType("int");

                    b.HasKey("IdCandidato");

                    b.HasIndex("VagaIdVaga");

                    b.ToTable("Candidato");
                });

            modelBuilder.Entity("RH.Models.CandidatoTecnologia", b =>
                {
                    b.Property<int>("IdCandidato")
                        .HasColumnType("int");

                    b.Property<int>("IdTecnologia")
                        .HasColumnType("int");

                    b.HasKey("IdCandidato", "IdTecnologia");

                    b.HasIndex("IdTecnologia");

                    b.ToTable("CandidatoTecnologia");
                });

            modelBuilder.Entity("RH.Models.Tecnologia", b =>
                {
                    b.Property<int>("IdTecnologia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTecnologia"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdTecnologia");

                    b.ToTable("Tecnologia");
                });

            modelBuilder.Entity("RH.Models.Vaga", b =>
                {
                    b.Property<int>("IdVaga")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdVaga"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdVaga");

                    b.ToTable("Vaga");
                });

            modelBuilder.Entity("RH.Models.VagaTecnologia", b =>
                {
                    b.Property<int>("IdVaga")
                        .HasColumnType("int");

                    b.Property<int>("IdTecnologia")
                        .HasColumnType("int");

                    b.Property<int>("Peso")
                        .HasColumnType("int");

                    b.HasKey("IdVaga", "IdTecnologia");

                    b.HasIndex("IdTecnologia");

                    b.ToTable("VagaTecnologia");
                });

            modelBuilder.Entity("RH.Models.Candidato", b =>
                {
                    b.HasOne("RH.Models.Vaga", "Vaga")
                        .WithMany()
                        .HasForeignKey("VagaIdVaga")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vaga");
                });

            modelBuilder.Entity("RH.Models.CandidatoTecnologia", b =>
                {
                    b.HasOne("RH.Models.Candidato", "Candidato")
                        .WithMany("CandidatoTecnologias")
                        .HasForeignKey("IdCandidato")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RH.Models.Tecnologia", "Tecnologia")
                        .WithMany()
                        .HasForeignKey("IdTecnologia")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidato");

                    b.Navigation("Tecnologia");
                });

            modelBuilder.Entity("RH.Models.VagaTecnologia", b =>
                {
                    b.HasOne("RH.Models.Tecnologia", "Tecnologia")
                        .WithMany()
                        .HasForeignKey("IdTecnologia")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RH.Models.Vaga", "Vaga")
                        .WithMany("VagaTecnologias")
                        .HasForeignKey("IdVaga")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tecnologia");

                    b.Navigation("Vaga");
                });

            modelBuilder.Entity("RH.Models.Candidato", b =>
                {
                    b.Navigation("CandidatoTecnologias");
                });

            modelBuilder.Entity("RH.Models.Vaga", b =>
                {
                    b.Navigation("VagaTecnologias");
                });
#pragma warning restore 612, 618
        }
    }
}