using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ListaEsperaGastrocentro.Migrations
{
    /// <inheritdoc />
    public partial class relacionarTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "PACIENTES",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PACIENTES_UsuarioId",
                table: "PACIENTES",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_PACIENTES_USUARIOS_UsuarioId",
                table: "PACIENTES",
                column: "UsuarioId",
                principalTable: "USUARIOS",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PACIENTES_USUARIOS_UsuarioId",
                table: "PACIENTES");

            migrationBuilder.DropIndex(
                name: "IX_PACIENTES_UsuarioId",
                table: "PACIENTES");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "PACIENTES");
        }
    }
}
