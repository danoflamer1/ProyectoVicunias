using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vicuñas.Migrations
{
    /// <inheritdoc />
    public partial class Migra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Cupo",
                table: "Paralelos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Disponibilidad",
                table: "Paralelos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cupo",
                table: "Paralelos");

            migrationBuilder.DropColumn(
                name: "Disponibilidad",
                table: "Paralelos");
        }
    }
}
