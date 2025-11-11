using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vicuñas.Migrations
{
    /// <inheritdoc />
    public partial class MigraMateria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParaleloId",
                table: "Materia",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Materia_ParaleloId",
                table: "Materia",
                column: "ParaleloId");

            migrationBuilder.AddForeignKey(
                name: "FK_Materia_Paralelos_ParaleloId",
                table: "Materia",
                column: "ParaleloId",
                principalTable: "Paralelos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materia_Paralelos_ParaleloId",
                table: "Materia");

            migrationBuilder.DropIndex(
                name: "IX_Materia_ParaleloId",
                table: "Materia");

            migrationBuilder.DropColumn(
                name: "ParaleloId",
                table: "Materia");
        }
    }
}
