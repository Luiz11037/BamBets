using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bambets.Migrations
{
    /// <inheritdoc />
    public partial class RemoverListaDeJogadoresJogo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apostadores_Jogos_JogoId",
                table: "Apostadores");

            migrationBuilder.DropIndex(
                name: "IX_Apostadores_JogoId",
                table: "Apostadores");

            migrationBuilder.DropColumn(
                name: "JogoId",
                table: "Apostadores");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JogoId",
                table: "Apostadores",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Apostadores_JogoId",
                table: "Apostadores",
                column: "JogoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Apostadores_Jogos_JogoId",
                table: "Apostadores",
                column: "JogoId",
                principalTable: "Jogos",
                principalColumn: "Id");
        }
    }
}
