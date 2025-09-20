using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vicuñas.Migrations
{
    /// <inheritdoc />
    public partial class PrimeraMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estudiantes",
                columns: table => new
                {
                    CI = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Apellido_P = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellido_M = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Fecha_Nac = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Discapacidad = table.Column<bool>(type: "bit", nullable: false),
                    Extranjero = table.Column<bool>(type: "bit", nullable: false),
                    Nro_Telefono = table.Column<int>(type: "int", nullable: false),
                    Nro_Celular = table.Column<int>(type: "int", nullable: false),
                    Nro_Rude = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiantes", x => x.CI);
                });

            migrationBuilder.CreateTable(
                name: "Padres",
                columns: table => new
                {
                    CI = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Apellido_P = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellido_M = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Idioma1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Laburo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Educacion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Fecha_Nac = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Extranjero = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Padres", x => x.CI);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    CI = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Apellido_P = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellido_M = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Rol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.CI);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estudiantes");

            migrationBuilder.DropTable(
                name: "Padres");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
