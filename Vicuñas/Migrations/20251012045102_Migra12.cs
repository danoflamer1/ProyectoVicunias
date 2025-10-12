using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vicuñas.Migrations
{
    /// <inheritdoc />
    public partial class Migra12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EstudiantePadre_Estudiantes_EstudiantesID",
                table: "EstudiantePadre");

            migrationBuilder.DropForeignKey(
                name: "FK_EstudiantePadre_Padres_TutoresID",
                table: "EstudiantePadre");

            migrationBuilder.DropForeignKey(
                name: "FK_Inscripciones_Estudiantes_EstudianteID",
                table: "Inscripciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Inscripciones_Padres_TutorID",
                table: "Inscripciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Inscripciones_Usuarios_UsuarioID",
                table: "Inscripciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Materias_Usuarios_UsuarioID",
                table: "Materias");

            migrationBuilder.DropForeignKey(
                name: "FK_Notas_Estudiantes_EstudianteID",
                table: "Notas");

            migrationBuilder.DropForeignKey(
                name: "FK_Notas_Usuarios_UsuarioID",
                table: "Notas");

            migrationBuilder.DropForeignKey(
                name: "FK_Paralelos_Usuarios_UsuarioID",
                table: "Paralelos");

            migrationBuilder.DropForeignKey(
                name: "FK_Reportes_Usuarios_UsuarioID",
                table: "Reportes");

            migrationBuilder.DropColumn(
                name: "UsuarioCi",
                table: "Paralelos");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Usuarios",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UsuarioID",
                table: "Reportes",
                newName: "UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Reportes_UsuarioID",
                table: "Reportes",
                newName: "IX_Reportes_UsuarioId");

            migrationBuilder.RenameColumn(
                name: "UsuarioID",
                table: "Paralelos",
                newName: "UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Paralelos_UsuarioID",
                table: "Paralelos",
                newName: "IX_Paralelos_UsuarioId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Padres",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UsuarioID",
                table: "Notas",
                newName: "UsuarioId");

            migrationBuilder.RenameColumn(
                name: "EstudianteID",
                table: "Notas",
                newName: "EstudianteId");

            migrationBuilder.RenameIndex(
                name: "IX_Notas_UsuarioID",
                table: "Notas",
                newName: "IX_Notas_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Notas_EstudianteID",
                table: "Notas",
                newName: "IX_Notas_EstudianteId");

            migrationBuilder.RenameColumn(
                name: "UsuarioID",
                table: "Materias",
                newName: "UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Materias_UsuarioID",
                table: "Materias",
                newName: "IX_Materias_UsuarioId");

            migrationBuilder.RenameColumn(
                name: "UsuarioID",
                table: "Inscripciones",
                newName: "UsuarioId");

            migrationBuilder.RenameColumn(
                name: "TutorID",
                table: "Inscripciones",
                newName: "TutorId");

            migrationBuilder.RenameColumn(
                name: "EstudianteID",
                table: "Inscripciones",
                newName: "EstudianteId");

            migrationBuilder.RenameIndex(
                name: "IX_Inscripciones_UsuarioID",
                table: "Inscripciones",
                newName: "IX_Inscripciones_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Inscripciones_TutorID",
                table: "Inscripciones",
                newName: "IX_Inscripciones_TutorId");

            migrationBuilder.RenameIndex(
                name: "IX_Inscripciones_EstudianteID",
                table: "Inscripciones",
                newName: "IX_Inscripciones_EstudianteId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Estudiantes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "TutoresID",
                table: "EstudiantePadre",
                newName: "TutoresId");

            migrationBuilder.RenameColumn(
                name: "EstudiantesID",
                table: "EstudiantePadre",
                newName: "EstudiantesId");

            migrationBuilder.RenameIndex(
                name: "IX_EstudiantePadre_TutoresID",
                table: "EstudiantePadre",
                newName: "IX_EstudiantePadre_TutoresId");

            migrationBuilder.AddForeignKey(
                name: "FK_EstudiantePadre_Estudiantes_EstudiantesId",
                table: "EstudiantePadre",
                column: "EstudiantesId",
                principalTable: "Estudiantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EstudiantePadre_Padres_TutoresId",
                table: "EstudiantePadre",
                column: "TutoresId",
                principalTable: "Padres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inscripciones_Estudiantes_EstudianteId",
                table: "Inscripciones",
                column: "EstudianteId",
                principalTable: "Estudiantes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Inscripciones_Padres_TutorId",
                table: "Inscripciones",
                column: "TutorId",
                principalTable: "Padres",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Inscripciones_Usuarios_UsuarioId",
                table: "Inscripciones",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Materias_Usuarios_UsuarioId",
                table: "Materias",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notas_Estudiantes_EstudianteId",
                table: "Notas",
                column: "EstudianteId",
                principalTable: "Estudiantes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notas_Usuarios_UsuarioId",
                table: "Notas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Paralelos_Usuarios_UsuarioId",
                table: "Paralelos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reportes_Usuarios_UsuarioId",
                table: "Reportes",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EstudiantePadre_Estudiantes_EstudiantesId",
                table: "EstudiantePadre");

            migrationBuilder.DropForeignKey(
                name: "FK_EstudiantePadre_Padres_TutoresId",
                table: "EstudiantePadre");

            migrationBuilder.DropForeignKey(
                name: "FK_Inscripciones_Estudiantes_EstudianteId",
                table: "Inscripciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Inscripciones_Padres_TutorId",
                table: "Inscripciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Inscripciones_Usuarios_UsuarioId",
                table: "Inscripciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Materias_Usuarios_UsuarioId",
                table: "Materias");

            migrationBuilder.DropForeignKey(
                name: "FK_Notas_Estudiantes_EstudianteId",
                table: "Notas");

            migrationBuilder.DropForeignKey(
                name: "FK_Notas_Usuarios_UsuarioId",
                table: "Notas");

            migrationBuilder.DropForeignKey(
                name: "FK_Paralelos_Usuarios_UsuarioId",
                table: "Paralelos");

            migrationBuilder.DropForeignKey(
                name: "FK_Reportes_Usuarios_UsuarioId",
                table: "Reportes");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Usuarios",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Reportes",
                newName: "UsuarioID");

            migrationBuilder.RenameIndex(
                name: "IX_Reportes_UsuarioId",
                table: "Reportes",
                newName: "IX_Reportes_UsuarioID");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Paralelos",
                newName: "UsuarioID");

            migrationBuilder.RenameIndex(
                name: "IX_Paralelos_UsuarioId",
                table: "Paralelos",
                newName: "IX_Paralelos_UsuarioID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Padres",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Notas",
                newName: "UsuarioID");

            migrationBuilder.RenameColumn(
                name: "EstudianteId",
                table: "Notas",
                newName: "EstudianteID");

            migrationBuilder.RenameIndex(
                name: "IX_Notas_UsuarioId",
                table: "Notas",
                newName: "IX_Notas_UsuarioID");

            migrationBuilder.RenameIndex(
                name: "IX_Notas_EstudianteId",
                table: "Notas",
                newName: "IX_Notas_EstudianteID");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Materias",
                newName: "UsuarioID");

            migrationBuilder.RenameIndex(
                name: "IX_Materias_UsuarioId",
                table: "Materias",
                newName: "IX_Materias_UsuarioID");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Inscripciones",
                newName: "UsuarioID");

            migrationBuilder.RenameColumn(
                name: "TutorId",
                table: "Inscripciones",
                newName: "TutorID");

            migrationBuilder.RenameColumn(
                name: "EstudianteId",
                table: "Inscripciones",
                newName: "EstudianteID");

            migrationBuilder.RenameIndex(
                name: "IX_Inscripciones_UsuarioId",
                table: "Inscripciones",
                newName: "IX_Inscripciones_UsuarioID");

            migrationBuilder.RenameIndex(
                name: "IX_Inscripciones_TutorId",
                table: "Inscripciones",
                newName: "IX_Inscripciones_TutorID");

            migrationBuilder.RenameIndex(
                name: "IX_Inscripciones_EstudianteId",
                table: "Inscripciones",
                newName: "IX_Inscripciones_EstudianteID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Estudiantes",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "TutoresId",
                table: "EstudiantePadre",
                newName: "TutoresID");

            migrationBuilder.RenameColumn(
                name: "EstudiantesId",
                table: "EstudiantePadre",
                newName: "EstudiantesID");

            migrationBuilder.RenameIndex(
                name: "IX_EstudiantePadre_TutoresId",
                table: "EstudiantePadre",
                newName: "IX_EstudiantePadre_TutoresID");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioCi",
                table: "Paralelos",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EstudiantePadre_Estudiantes_EstudiantesID",
                table: "EstudiantePadre",
                column: "EstudiantesID",
                principalTable: "Estudiantes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EstudiantePadre_Padres_TutoresID",
                table: "EstudiantePadre",
                column: "TutoresID",
                principalTable: "Padres",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inscripciones_Estudiantes_EstudianteID",
                table: "Inscripciones",
                column: "EstudianteID",
                principalTable: "Estudiantes",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Inscripciones_Padres_TutorID",
                table: "Inscripciones",
                column: "TutorID",
                principalTable: "Padres",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Inscripciones_Usuarios_UsuarioID",
                table: "Inscripciones",
                column: "UsuarioID",
                principalTable: "Usuarios",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Materias_Usuarios_UsuarioID",
                table: "Materias",
                column: "UsuarioID",
                principalTable: "Usuarios",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Notas_Estudiantes_EstudianteID",
                table: "Notas",
                column: "EstudianteID",
                principalTable: "Estudiantes",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Notas_Usuarios_UsuarioID",
                table: "Notas",
                column: "UsuarioID",
                principalTable: "Usuarios",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Paralelos_Usuarios_UsuarioID",
                table: "Paralelos",
                column: "UsuarioID",
                principalTable: "Usuarios",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reportes_Usuarios_UsuarioID",
                table: "Reportes",
                column: "UsuarioID",
                principalTable: "Usuarios",
                principalColumn: "ID");
        }
    }
}
