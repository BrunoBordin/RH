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
                name: "Candidato",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidato", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tecnologia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tecnologia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vaga",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aberta = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaga", x => x.Id);
                });

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
                name: "EmpresaTecnologia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEmpresa = table.Column<int>(type: "int", nullable: false),
                    IdTecnologia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpresaTecnologia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpresaTecnologia_Empresa_IdEmpresa",
                        column: x => x.IdEmpresa,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpresaTecnologia_Tecnologia_IdTecnologia",
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
                    IdVaga = table.Column<int>(type: "int", nullable: false),
                    IdEmpresa = table.Column<int>(type: "int", nullable: false)
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
                    IdVaga = table.Column<int>(type: "int", nullable: false),
                    IdTecnologia = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "VagaTecnologiaRequisito",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdVaga = table.Column<int>(type: "int", nullable: false),
                    IdTecnologia = table.Column<int>(type: "int", nullable: false),
                    Peso = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VagaTecnologiaRequisito", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VagaTecnologiaRequisito_Tecnologia_IdTecnologia",
                        column: x => x.IdTecnologia,
                        principalTable: "Tecnologia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VagaTecnologiaRequisito_Vaga_IdVaga",
                        column: x => x.IdVaga,
                        principalTable: "Vaga",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VinculoCanditadoVaga",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCandidato = table.Column<int>(type: "int", nullable: false),
                    IdVaga = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VinculoCanditadoVaga", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VinculoCanditadoVaga_Candidato_IdCandidato",
                        column: x => x.IdCandidato,
                        principalTable: "Candidato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VinculoCanditadoVaga_Vaga_IdVaga",
                        column: x => x.IdVaga,
                        principalTable: "Vaga",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VinculoCanditadoVagaTecnologia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdVinculoCandidatoVaga = table.Column<int>(type: "int", nullable: false),
                    IdTecnologia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VinculoCanditadoVagaTecnologia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VinculoCanditadoVagaTecnologia_Tecnologia_IdTecnologia",
                        column: x => x.IdTecnologia,
                        principalTable: "Tecnologia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VinculoCanditadoVagaTecnologia_VinculoCanditadoVaga_IdVinculoCandidatoVaga",
                        column: x => x.IdVinculoCandidatoVaga,
                        principalTable: "VinculoCanditadoVaga",
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
                name: "IX_EmpresaTecnologia_IdEmpresa",
                table: "EmpresaTecnologia",
                column: "IdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_EmpresaTecnologia_IdTecnologia",
                table: "EmpresaTecnologia",
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

            migrationBuilder.CreateIndex(
                name: "IX_VagaTecnologiaRequisito_IdTecnologia",
                table: "VagaTecnologiaRequisito",
                column: "IdTecnologia");

            migrationBuilder.CreateIndex(
                name: "IX_VagaTecnologiaRequisito_IdVaga",
                table: "VagaTecnologiaRequisito",
                column: "IdVaga");

            migrationBuilder.CreateIndex(
                name: "IX_VinculoCanditadoVaga_IdCandidato",
                table: "VinculoCanditadoVaga",
                column: "IdCandidato");

            migrationBuilder.CreateIndex(
                name: "IX_VinculoCanditadoVaga_IdVaga",
                table: "VinculoCanditadoVaga",
                column: "IdVaga");

            migrationBuilder.CreateIndex(
                name: "IX_VinculoCanditadoVagaTecnologia_IdTecnologia",
                table: "VinculoCanditadoVagaTecnologia",
                column: "IdTecnologia");

            migrationBuilder.CreateIndex(
                name: "IX_VinculoCanditadoVagaTecnologia_IdVinculoCandidatoVaga",
                table: "VinculoCanditadoVagaTecnologia",
                column: "IdVinculoCandidatoVaga");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidatoTecnologia");

            migrationBuilder.DropTable(
                name: "EmpresaTecnologia");

            migrationBuilder.DropTable(
                name: "EmpresaVaga");

            migrationBuilder.DropTable(
                name: "VagaTecnologia");

            migrationBuilder.DropTable(
                name: "VagaTecnologiaRequisito");

            migrationBuilder.DropTable(
                name: "VinculoCanditadoVagaTecnologia");

            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropTable(
                name: "Tecnologia");

            migrationBuilder.DropTable(
                name: "VinculoCanditadoVaga");

            migrationBuilder.DropTable(
                name: "Candidato");

            migrationBuilder.DropTable(
                name: "Vaga");
        }
    }
}
