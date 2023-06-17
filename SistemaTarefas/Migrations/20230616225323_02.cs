using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo.Migrations
{
    /// <inheritdoc />
    public partial class _02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tarefas_projects_id_projeto",
                table: "tarefas");

            migrationBuilder.AddForeignKey(
                name: "FK_tarefas_projects_id_projeto",
                table: "tarefas",
                column: "id_projeto",
                principalTable: "projects",
                principalColumn: "idproject",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tarefas_projects_id_projeto",
                table: "tarefas");

            migrationBuilder.AddForeignKey(
                name: "FK_tarefas_projects_id_projeto",
                table: "tarefas",
                column: "id_projeto",
                principalTable: "projects",
                principalColumn: "idproject",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
