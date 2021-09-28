using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hospital.Infra.Migrations
{
    public partial class PrimeiraMigracao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Cpf = table.Column<string>(type: "VARCHAR(14)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Sexo = table.Column<string>(type: "CHAR(1)", nullable: false),
                    Telefone = table.Column<string>(type: "CHAR(14)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(400)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoExame",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Descricao = table.Column<string>(type: "VARCHAR(256)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoExame", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exame",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Observacao = table.Column<string>(type: "VARCHAR(1000)", nullable: false),
                    TipoExameId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exame", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exame_TipoExame_TipoExameId",
                        column: x => x.TipoExameId,
                        principalTable: "TipoExame",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConsultaMedica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteId = table.Column<int>(type: "int", nullable: true),
                    ExameId = table.Column<int>(type: "int", nullable: true),
                    DataHoraExame = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Protocolo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultaMedica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsultaMedica_Exame_ExameId",
                        column: x => x.ExameId,
                        principalTable: "Exame",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConsultaMedica_Paciente_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Paciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "TipoExame",
                columns: new[] { "Id", "Descricao", "Nome" },
                values: new object[] { 1, "Exame de sangue, Jejum 12 horas.", "Hemograma" });

            migrationBuilder.InsertData(
                table: "TipoExame",
                columns: new[] { "Id", "Descricao", "Nome" },
                values: new object[] { 2, "Exame de imagem.", "Raio X" });

            migrationBuilder.CreateIndex(
                name: "IX_ConsultaMedica_ExameId",
                table: "ConsultaMedica",
                column: "ExameId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultaMedica_PacienteId",
                table: "ConsultaMedica",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Exame_TipoExameId",
                table: "Exame",
                column: "TipoExameId");

            migrationBuilder.CreateIndex(
                name: "IX_PACIENTE_CPF",
                table: "Paciente",
                column: "Cpf");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsultaMedica");

            migrationBuilder.DropTable(
                name: "Exame");

            migrationBuilder.DropTable(
                name: "Paciente");

            migrationBuilder.DropTable(
                name: "TipoExame");
        }
    }
}
