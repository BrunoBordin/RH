using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RH.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUnnecessaryTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidatoTecnologia");

            migrationBuilder.DropTable(
                name: "EmpresaVaga");

            migrationBuilder.DropTable(
                name: "VagaTecnologia");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CandidatoTecnologia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCandidato = table.Column<int>(type: "int", nullable: false),
                    IdTecnologia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidatoTecnologia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidatoTecnologia_Candidato_IdCandidato",
                        column: x => x.IdCandidato,
                        principalTable: "Candidato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidatoTecnologia_Tecnologia_IdTecnologia",
                        column: x => x.IdTecnologia,
                        principalTable: "Tecnologia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmpresaVaga",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEmpresa = table.Column<int>(type: "int", nullable: false),
                    IdVaga = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresaVaga", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpresaVaga_Empresa_IdEmpresa",
                        column: x => x.IdEmpresa,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpresaVaga_Vaga_IdVaga",
                        column: x => x.IdVaga,
                        principalTable: "Vaga",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VagaTecnologia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTecnologia = table.Column<int>(type: "int", nullable: false),
                    IdVaga = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VagaTecnologia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VagaTecnologia_Tecnologia_IdTecnologia",
                        column: x => x.IdTecnologia,
                        principalTable: "Tecnologia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VagaTecnologia_Vaga_IdVaga",
                        column: x => x.IdVaga,
                        principalTable: "Vaga",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidatoTecnologia_IdCandidato",
                table: "CandidatoTecnologia",
                column: "IdCandidato");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatoTecnologia_IdTecnologia",
                table: "CandidatoTecnologia",
                column: "IdTecnologia");

            migrationBuilder.CreateIndex(
                name: "IX_EmpresaVaga_IdEmpresa",
                table: "EmpresaVaga",
                column: "IdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_EmpresaVaga_IdVaga",
                table: "EmpresaVaga",
                column: "IdVaga");

            migrationBuilder.CreateIndex(
                name: "IX_VagaTecnologia_IdTecnologia",
                table: "VagaTecnologia",
                column: "IdTecnologia");

            migrationBuilder.CreateIndex(
                name: "IX_VagaTecnologia_IdVaga",
                table: "VagaTecnologia",
                column: "IdVaga");
        }
    }
}
