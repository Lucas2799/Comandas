using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Comandas.Migrations
{
    /// <inheritdoc />
    public partial class Reservas1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Cadeiras_CadeirasId",
                table: "Reservas");

            migrationBuilder.DropIndex(
                name: "IX_Reservas_CadeirasId",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "CadeirasId",
                table: "Reservas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CadeirasId",
                table: "Reservas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_CadeirasId",
                table: "Reservas",
                column: "CadeirasId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Cadeiras_CadeirasId",
                table: "Reservas",
                column: "CadeirasId",
                principalTable: "Cadeiras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
