using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FluentAPI_Escola.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Escola",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Escola", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    EscolaId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alunos_Escola_EscolaId",
                        column: x => x.EscolaId,
                        principalTable: "Escola",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EscolasAlunos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AlunoId = table.Column<Guid>(nullable: true),
                    IdAluno = table.Column<Guid>(nullable: false),
                    EscolaId = table.Column<Guid>(nullable: true),
                    IdEscola = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EscolasAlunos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EscolasAlunos_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EscolasAlunos_Escola_EscolaId",
                        column: x => x.EscolaId,
                        principalTable: "Escola",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_EscolaId",
                table: "Alunos",
                column: "EscolaId");

            migrationBuilder.CreateIndex(
                name: "IX_EscolasAlunos_AlunoId",
                table: "EscolasAlunos",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_EscolasAlunos_EscolaId",
                table: "EscolasAlunos",
                column: "EscolaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EscolasAlunos");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Escola");
        }
    }
}
