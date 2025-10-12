using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vicuñas.Migrations
{
    /// <inheritdoc />
    public partial class Migra123 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Grados");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Grados",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Inscrito",
                table: "Estudiantes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Grados");

            migrationBuilder.DropColumn(
                name: "Inscrito",
                table: "Estudiantes");

            migrationBuilder.AddColumn<int>(
                name: "Numero",
                table: "Grados",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
