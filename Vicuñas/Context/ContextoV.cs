using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Vicuñas.Models;

namespace Micontexto.Context
{
    public class ContextoV : DbContext
    {
        public ContextoV(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Padre> Padres { get; set; }
        public DbSet<Inscripcion> Inscripciones { get; set; }
        public DbSet<Grado> Grados { get; set; }
        public DbSet<Nota> Notas { get; set; }
        public DbSet<Paralelo> Paralelos { get; set; }
        public DbSet<Reporte> Reportes { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Materia> Mensajes{ get; set; }
        public DbSet<Vicuñas.Models.Mensaje> Mensaje { get; set; } = default!;
    }
}