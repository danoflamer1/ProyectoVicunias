using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vicuñas.Migrations
{
    /// <inheritdoc />
    public partial class Migracion3d : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Padres",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CI = table.Column<int>(type: "int", nullable: false),
                    Ci_Complemento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ci_Expedido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo_Tutor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido_P = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellido_M = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Idioma1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Laburo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Educacion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Contraseña = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha_Nac = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Padres", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CI = table.Column<int>(type: "int", nullable: false),
                    Ci_Complemento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido_P = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellido_M = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Rol = table.Column<int>(type: "int", nullable: false),
                    Sueldo = table.Column<float>(type: "real", nullable: false),
                    Contraseña = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Materias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioCi = table.Column<int>(type: "int", nullable: true),
                    UsuarioID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Materias_Usuarios_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Paralelos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GradoId = table.Column<int>(type: "int", nullable: true),
                    UsuarioCi = table.Column<int>(type: "int", nullable: true),
                    UsuarioID = table.Column<int>(type: "int", nullable: true)
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
                        name: "FK_Paralelos_Usuarios_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "ID");
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
                    UsuarioCi = table.Column<int>(type: "int", nullable: false),
                    UsuarioID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reportes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reportes_Usuarios_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Estudiantes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CI = table.Column<int>(type: "int", nullable: false),
                    Ci_Complemento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ci_Expedido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido_P = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellido_M = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Fecha_Nac = table.Column<DateTime>(type: "date", nullable: false),
                    Discapacidad = table.Column<bool>(type: "bit", nullable: false),
                    Nro_Discapacidad = table.Column<int>(type: "int", nullable: false),
                    Tipo_Auditiva = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tipo_Visual = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tipo_Intelectual = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tipo_Fisica = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tipo_Mental = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tipo_Discapacidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Programa_Apoyo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Extranjero = table.Column<bool>(type: "bit", nullable: false),
                    Tipo_Documento_Extranjero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nro_Documento_Extranjero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nro_Telefono = table.Column<int>(type: "int", nullable: false),
                    Nro_Celular = table.Column<int>(type: "int", nullable: false),
                    Pais = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Departamento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Provincia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Municipio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Localidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zona = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nro_Vivienda = table.Column<int>(type: "int", nullable: false),
                    Certificado_Oficialia = table.Column<int>(type: "int", nullable: false),
                    Certificado_Libro = table.Column<int>(type: "int", nullable: false),
                    Certificado_Partida = table.Column<int>(type: "int", nullable: false),
                    Certificado_Folio = table.Column<int>(type: "int", nullable: false),
                    Nro_Rude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParaleloId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiantes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Estudiantes_Paralelos_ParaleloId",
                        column: x => x.ParaleloId,
                        principalTable: "Paralelos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EstudiantePadre",
                columns: table => new
                {
                    EstudiantesID = table.Column<int>(type: "int", nullable: false),
                    TutoresID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstudiantePadre", x => new { x.EstudiantesID, x.TutoresID });
                    table.ForeignKey(
                        name: "FK_EstudiantePadre_Estudiantes_EstudiantesID",
                        column: x => x.EstudiantesID,
                        principalTable: "Estudiantes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EstudiantePadre_Padres_TutoresID",
                        column: x => x.TutoresID,
                        principalTable: "Padres",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
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
                    EstudianteID = table.Column<int>(type: "int", nullable: true),
                    TutorCi = table.Column<int>(type: "int", nullable: true),
                    TutorID = table.Column<int>(type: "int", nullable: true),
                    UsuarioCi = table.Column<int>(type: "int", nullable: true),
                    UsuarioID = table.Column<int>(type: "int", nullable: true),
                    ParaleloId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscripciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inscripciones_Estudiantes_EstudianteID",
                        column: x => x.EstudianteID,
                        principalTable: "Estudiantes",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Inscripciones_Padres_TutorID",
                        column: x => x.TutorID,
                        principalTable: "Padres",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Inscripciones_Paralelos_ParaleloId",
                        column: x => x.ParaleloId,
                        principalTable: "Paralelos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Inscripciones_Usuarios_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "ID");
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
                    UsuarioID = table.Column<int>(type: "int", nullable: true),
                    EstudianteCi = table.Column<int>(type: "int", nullable: true),
                    EstudianteID = table.Column<int>(type: "int", nullable: true),
                    MateriaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notas_Estudiantes_EstudianteID",
                        column: x => x.EstudianteID,
                        principalTable: "Estudiantes",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Notas_Materias_MateriaId",
                        column: x => x.MateriaId,
                        principalTable: "Materias",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Notas_Usuarios_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EstudiantePadre_TutoresID",
                table: "EstudiantePadre",
                column: "TutoresID");

            migrationBuilder.CreateIndex(
                name: "IX_Estudiantes_ParaleloId",
                table: "Estudiantes",
                column: "ParaleloId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_EstudianteID",
                table: "Inscripciones",
                column: "EstudianteID");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_ParaleloId",
                table: "Inscripciones",
                column: "ParaleloId",
                unique: true,
                filter: "[ParaleloId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_TutorID",
                table: "Inscripciones",
                column: "TutorID");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_UsuarioID",
                table: "Inscripciones",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Materias_UsuarioID",
                table: "Materias",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Notas_EstudianteID",
                table: "Notas",
                column: "EstudianteID");

            migrationBuilder.CreateIndex(
                name: "IX_Notas_MateriaId",
                table: "Notas",
                column: "MateriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Notas_UsuarioID",
                table: "Notas",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Paralelos_GradoId",
                table: "Paralelos",
                column: "GradoId");

            migrationBuilder.CreateIndex(
                name: "IX_Paralelos_UsuarioID",
                table: "Paralelos",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Reportes_UsuarioID",
                table: "Reportes",
                column: "UsuarioID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstudiantePadre");

            migrationBuilder.DropTable(
                name: "Inscripciones");

            migrationBuilder.DropTable(
                name: "Notas");

            migrationBuilder.DropTable(
                name: "Reportes");

            migrationBuilder.DropTable(
                name: "Padres");

            migrationBuilder.DropTable(
                name: "Estudiantes");

            migrationBuilder.DropTable(
                name: "Materias");

            migrationBuilder.DropTable(
                name: "Paralelos");

            migrationBuilder.DropTable(
                name: "Grados");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
