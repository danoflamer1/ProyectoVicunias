using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vicuñas.Migrations
{
    /// <inheritdoc />
    public partial class SegundaMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Extranjero",
                table: "Padres");

            migrationBuilder.AddColumn<float>(
                name: "Sueldo",
                table: "Usuarios",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha_Nac",
                table: "Padres",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Ci_Complemento",
                table: "Padres",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ci_Expedido",
                table: "Padres",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tipo_Tutor",
                table: "Padres",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha_Nac",
                table: "Estudiantes",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "Certificado_Folio",
                table: "Estudiantes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Certificado_Libro",
                table: "Estudiantes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Certificado_Oficialia",
                table: "Estudiantes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Certificado_Partida",
                table: "Estudiantes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Ci_Complemento",
                table: "Estudiantes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ci_Expedido",
                table: "Estudiantes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Departamento",
                table: "Estudiantes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "Estudiantes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Localidad",
                table: "Estudiantes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Municipio",
                table: "Estudiantes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Nro_Discapacidad",
                table: "Estudiantes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Nro_Documento_Extranjero",
                table: "Estudiantes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Nro_Vivienda",
                table: "Estudiantes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Pais",
                table: "Estudiantes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ParaleloId",
                table: "Estudiantes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Programa_Apoyo",
                table: "Estudiantes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Provincia",
                table: "Estudiantes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tipo_Auditiva",
                table: "Estudiantes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tipo_Discapacidad",
                table: "Estudiantes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tipo_Documento_Extranjero",
                table: "Estudiantes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tipo_Fisica",
                table: "Estudiantes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tipo_Intelectual",
                table: "Estudiantes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tipo_Mental",
                table: "Estudiantes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tipo_Visual",
                table: "Estudiantes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Zona",
                table: "Estudiantes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "EstudiantePadre",
                columns: table => new
                {
                    EstudiantesCI = table.Column<int>(type: "int", nullable: false),
                    TutoresCI = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstudiantePadre", x => new { x.EstudiantesCI, x.TutoresCI });
                    table.ForeignKey(
                        name: "FK_EstudiantePadre_Estudiantes_EstudiantesCI",
                        column: x => x.EstudiantesCI,
                        principalTable: "Estudiantes",
                        principalColumn: "CI",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EstudiantePadre_Padres_TutoresCI",
                        column: x => x.TutoresCI,
                        principalTable: "Padres",
                        principalColumn: "CI",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Grados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Materias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioCi = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Materias_Usuarios_UsuarioCi",
                        column: x => x.UsuarioCi,
                        principalTable: "Usuarios",
                        principalColumn: "CI");
                });

            migrationBuilder.CreateTable(
                name: "Reportes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaGeneracion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NombreArchivo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioCi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reportes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reportes_Usuarios_UsuarioCi",
                        column: x => x.UsuarioCi,
                        principalTable: "Usuarios",
                        principalColumn: "CI",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Paralelos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GradoId = table.Column<int>(type: "int", nullable: true),
                    UsuarioCi = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paralelos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Paralelos_Grados_GradoId",
                        column: x => x.GradoId,
                        principalTable: "Grados",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Paralelos_Usuarios_UsuarioCi",
                        column: x => x.UsuarioCi,
                        principalTable: "Usuarios",
                        principalColumn: "CI");
                });

            migrationBuilder.CreateTable(
                name: "Notas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Anio = table.Column<int>(type: "int", nullable: false),
                    Trimestre = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<int>(type: "int", nullable: false),
                    UsuarioCi = table.Column<int>(type: "int", nullable: true),
                    EstudianteCi = table.Column<int>(type: "int", nullable: true),
                    MateriaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notas_Estudiantes_EstudianteCi",
                        column: x => x.EstudianteCi,
                        principalTable: "Estudiantes",
                        principalColumn: "CI");
                    table.ForeignKey(
                        name: "FK_Notas_Materias_MateriaId",
                        column: x => x.MateriaId,
                        principalTable: "Materias",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Notas_Usuarios_UsuarioCi",
                        column: x => x.UsuarioCi,
                        principalTable: "Usuarios",
                        principalColumn: "CI");
                });

            migrationBuilder.CreateTable(
                name: "Inscripciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "date", nullable: false),
                    Idioma_1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Idioma_2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Idioma_3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Idioma_4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Idiomas = table.Column<int>(type: "int", nullable: false),
                    Centro_Salud = table.Column<bool>(type: "bit", nullable: false),
                    Tipo_Medicacion = table.Column<int>(type: "int", nullable: false),
                    Frecuencia_Salud = table.Column<int>(type: "int", nullable: false),
                    Seguro_Salud = table.Column<bool>(type: "bit", nullable: false),
                    Agua = table.Column<bool>(type: "bit", nullable: false),
                    Banio = table.Column<bool>(type: "bit", nullable: false),
                    Alcantarillado = table.Column<bool>(type: "bit", nullable: false),
                    Electricidad = table.Column<bool>(type: "bit", nullable: false),
                    Basurero = table.Column<bool>(type: "bit", nullable: false),
                    Tipo_Vivienda = table.Column<int>(type: "int", nullable: false),
                    Internet = table.Column<int>(type: "int", nullable: false),
                    Frecuencia_Internet = table.Column<int>(type: "int", nullable: false),
                    Estado_Laburo = table.Column<bool>(type: "bit", nullable: false),
                    Tipo_Laburo = table.Column<int>(type: "int", nullable: false),
                    Laburo_Otro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mes = table.Column<int>(type: "int", nullable: false),
                    Medio_Transporte_Otro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Turno = table.Column<int>(type: "int", nullable: false),
                    Frecuencia_Laburo = table.Column<int>(type: "int", nullable: false),
                    Pago = table.Column<bool>(type: "bit", nullable: false),
                    Tipo_Pago = table.Column<int>(type: "int", nullable: false),
                    Medio_Transporte = table.Column<int>(type: "int", nullable: false),
                    MovilidadOtra = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tiempo_Transporte = table.Column<int>(type: "int", nullable: false),
                    EstadoAbandono = table.Column<bool>(type: "bit", nullable: false),
                    Motivo = table.Column<int>(type: "int", nullable: false),
                    Otro_Motivo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstudianteCi = table.Column<int>(type: "int", nullable: true),
                    TutorCi = table.Column<int>(type: "int", nullable: true),
                    UsuarioCi = table.Column<int>(type: "int", nullable: true),
                    ParaleloId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscripciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inscripciones_Estudiantes_EstudianteCi",
                        column: x => x.EstudianteCi,
                        principalTable: "Estudiantes",
                        principalColumn: "CI");
                    table.ForeignKey(
                        name: "FK_Inscripciones_Padres_TutorCi",
                        column: x => x.TutorCi,
                        principalTable: "Padres",
                        principalColumn: "CI");
                    table.ForeignKey(
                        name: "FK_Inscripciones_Paralelos_ParaleloId",
                        column: x => x.ParaleloId,
                        principalTable: "Paralelos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Inscripciones_Usuarios_UsuarioCi",
                        column: x => x.UsuarioCi,
                        principalTable: "Usuarios",
                        principalColumn: "CI");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estudiantes_ParaleloId",
                table: "Estudiantes",
                column: "ParaleloId");

            migrationBuilder.CreateIndex(
                name: "IX_EstudiantePadre_TutoresCI",
                table: "EstudiantePadre",
                column: "TutoresCI");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_EstudianteCi",
                table: "Inscripciones",
                column: "EstudianteCi");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_ParaleloId",
                table: "Inscripciones",
                column: "ParaleloId",
                unique: true,
                filter: "[ParaleloId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_TutorCi",
                table: "Inscripciones",
                column: "TutorCi");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_UsuarioCi",
                table: "Inscripciones",
                column: "UsuarioCi");

            migrationBuilder.CreateIndex(
                name: "IX_Materias_UsuarioCi",
                table: "Materias",
                column: "UsuarioCi");

            migrationBuilder.CreateIndex(
                name: "IX_Notas_EstudianteCi",
                table: "Notas",
                column: "EstudianteCi");

            migrationBuilder.CreateIndex(
                name: "IX_Notas_MateriaId",
                table: "Notas",
                column: "MateriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Notas_UsuarioCi",
                table: "Notas",
                column: "UsuarioCi");

            migrationBuilder.CreateIndex(
                name: "IX_Paralelos_GradoId",
                table: "Paralelos",
                column: "GradoId");

            migrationBuilder.CreateIndex(
                name: "IX_Paralelos_UsuarioCi",
                table: "Paralelos",
                column: "UsuarioCi");

            migrationBuilder.CreateIndex(
                name: "IX_Reportes_UsuarioCi",
                table: "Reportes",
                column: "UsuarioCi");

            migrationBuilder.AddForeignKey(
                name: "FK_Estudiantes_Paralelos_ParaleloId",
                table: "Estudiantes",
                column: "ParaleloId",
                principalTable: "Paralelos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estudiantes_Paralelos_ParaleloId",
                table: "Estudiantes");

            migrationBuilder.DropTable(
                name: "EstudiantePadre");

            migrationBuilder.DropTable(
                name: "Inscripciones");

            migrationBuilder.DropTable(
                name: "Notas");

            migrationBuilder.DropTable(
                name: "Reportes");

            migrationBuilder.DropTable(
                name: "Paralelos");

            migrationBuilder.DropTable(
                name: "Materias");

            migrationBuilder.DropTable(
                name: "Grados");

            migrationBuilder.DropIndex(
                name: "IX_Estudiantes_ParaleloId",
                table: "Estudiantes");

            migrationBuilder.DropColumn(
                name: "Sueldo",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Ci_Complemento",
                table: "Padres");

            migrationBuilder.DropColumn(
                name: "Ci_Expedido",
                table: "Padres");

            migrationBuilder.DropColumn(
                name: "Tipo_Tutor",
                table: "Padres");

            migrationBuilder.DropColumn(
                name: "Certificado_Folio",
                table: "Estudiantes");

            migrationBuilder.DropColumn(
                name: "Certificado_Libro",
                table: "Estudiantes");

            migrationBuilder.DropColumn(
                name: "Certificado_Oficialia",
                table: "Estudiantes");

            migrationBuilder.DropColumn(
                name: "Certificado_Partida",
                table: "Estudiantes");

            migrationBuilder.DropColumn(
                name: "Ci_Complemento",
                table: "Estudiantes");

            migrationBuilder.DropColumn(
                name: "Ci_Expedido",
                table: "Estudiantes");

            migrationBuilder.DropColumn(
                name: "Departamento",
                table: "Estudiantes");

            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "Estudiantes");

            migrationBuilder.DropColumn(
                name: "Localidad",
                table: "Estudiantes");

            migrationBuilder.DropColumn(
                name: "Municipio",
                table: "Estudiantes");

            migrationBuilder.DropColumn(
                name: "Nro_Discapacidad",
                table: "Estudiantes");

            migrationBuilder.DropColumn(
                name: "Nro_Documento_Extranjero",
                table: "Estudiantes");

            migrationBuilder.DropColumn(
                name: "Nro_Vivienda",
                table: "Estudiantes");

            migrationBuilder.DropColumn(
                name: "Pais",
                table: "Estudiantes");

            migrationBuilder.DropColumn(
                name: "ParaleloId",
                table: "Estudiantes");

            migrationBuilder.DropColumn(
                name: "Programa_Apoyo",
                table: "Estudiantes");

            migrationBuilder.DropColumn(
                name: "Provincia",
                table: "Estudiantes");

            migrationBuilder.DropColumn(
                name: "Tipo_Auditiva",
                table: "Estudiantes");

            migrationBuilder.DropColumn(
                name: "Tipo_Discapacidad",
                table: "Estudiantes");

            migrationBuilder.DropColumn(
                name: "Tipo_Documento_Extranjero",
                table: "Estudiantes");

            migrationBuilder.DropColumn(
                name: "Tipo_Fisica",
                table: "Estudiantes");

            migrationBuilder.DropColumn(
                name: "Tipo_Intelectual",
                table: "Estudiantes");

            migrationBuilder.DropColumn(
                name: "Tipo_Mental",
                table: "Estudiantes");

            migrationBuilder.DropColumn(
                name: "Tipo_Visual",
                table: "Estudiantes");

            migrationBuilder.DropColumn(
                name: "Zona",
                table: "Estudiantes");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha_Nac",
                table: "Padres",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AddColumn<bool>(
                name: "Extranjero",
                table: "Padres",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha_Nac",
                table: "Estudiantes",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");
        }
    }
}
