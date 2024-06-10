using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RH.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tecnologia",
                columns: table => new
                {
                    IdTecnologia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tecnologia", x => x.IdTecnologia);
                });

            migrationBuilder.CreateTable(
                name: "Vaga",
                columns: table => new
                {
                    IdVaga = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaga", x => x.IdVaga);
                });

            migrationBuilder.CreateTable(
                name: "Candidato",
                columns: table => new
                {
                    IdCandidato = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdVaga = table.Column<int>(type: "int", nullable: false),
                    VagaIdVaga = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidato", x => x.IdCandidato);
                    table.ForeignKey(
                        name: "FK_Candidato_Vaga_VagaIdVaga",
                        column: x => x.VagaIdVaga,
                        principalTable: "Vaga",
                        principalColumn: "IdVaga",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VagaTecnologia",
                columns: table => new
                {
                    IdVaga = table.Column<int>(type: "int", nullable: false),
                    IdTecnologia = table.Column<int>(type: "int", nullable: false),
                    Peso = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VagaTecnologia", x => new { x.IdVaga, x.IdTecnologia });
                    table.ForeignKey(
                        name: "FK_VagaTecnologia_Tecnologia_IdTecnologia",
                        column: x => x.IdTecnologia,
                        principalTable: "Tecnologia",
                        principalColumn: "IdTecnologia",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VagaTecnologia_Vaga_IdVaga",
                        column: x => x.IdVaga,
                        principalTable: "Vaga",
                        principalColumn: "IdVaga",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CandidatoTecnologia",
                columns: table => new
                {
                    IdCandidato = table.Column<int>(type: "int", nullable: false),
                    IdTecnologia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidatoTecnologia", x => new { x.IdCandidato, x.IdTecnologia });
                    table.ForeignKey(
                        name: "FK_CandidatoTecnologia_Candidato_IdCandidato",
                        column: x => x.IdCandidato,
                        principalTable: "Candidato",
                        principalColumn: "IdCandidato",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidatoTecnologia_Tecnologia_IdTecnologia",
                        column: x => x.IdTecnologia,
                        principalTable: "Tecnologia",
                        principalColumn: "IdTecnologia",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Candidato_VagaIdVaga",
                table: "Candidato",
                column: "VagaIdVaga");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatoTecnologia_IdTecnologia",
                table: "CandidatoTecnologia",
                column: "IdTecnologia");

            migrationBuilder.CreateIndex(
                name: "IX_VagaTecnologia_IdTecnologia",
                table: "VagaTecnologia",
                column: "IdTecnologia");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidatoTecnologia");

            migrationBuilder.DropTable(
                name: "VagaTecnologia");

            migrationBuilder.DropTable(
                name: "Candidato");

            migrationBuilder.DropTable(
                name: "Tecnologia");

            migrationBuilder.DropTable(
                name: "Vaga");
        }
    }
}
