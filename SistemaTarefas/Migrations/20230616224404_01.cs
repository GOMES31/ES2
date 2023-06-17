using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Demo.Migrations
{
    /// <inheritdoc />
    public partial class _01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "projects",
                columns: table => new
                {
                    idproject = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    precohora = table.Column<decimal>(type: "numeric", nullable: true),
                    nomecliente = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projects", x => x.idproject);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    idUser = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    password = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    nhoras = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.idUser);
                });

            migrationBuilder.CreateTable(
                name: "tarefas",
                columns: table => new
                {
                    idtarefa = table.Column<int>(name: "id_tarefa", type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    horainicio = table.Column<DateTime>(name: "hora_inicio", type: "date", nullable: false),
                    horafim = table.Column<DateTime>(name: "hora_fim", type: "date", nullable: true),
                    estado = table.Column<string>(type: "text", nullable: true),
                    descricao = table.Column<string>(type: "text", nullable: true),
                    precohora = table.Column<decimal>(type: "numeric", nullable: true),
                    idprojeto = table.Column<int>(name: "id_projeto", type: "integer", nullable: true),
                    idutilizador = table.Column<int>(name: "id_utilizador", type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tarefas", x => x.idtarefa);
                    table.ForeignKey(
                        name: "FK_tarefas_projects_id_projeto",
                        column: x => x.idprojeto,
                        principalTable: "projects",
                        principalColumn: "idproject",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_tarefas_users_id_utilizador",
                        column: x => x.idutilizador,
                        principalTable: "users",
                        principalColumn: "idUser");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tarefas_id_projeto",
                table: "tarefas",
                column: "id_projeto");

            migrationBuilder.CreateIndex(
                name: "IX_tarefas_id_utilizador",
                table: "tarefas",
                column: "id_utilizador");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tarefas");

            migrationBuilder.DropTable(
                name: "projects");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
