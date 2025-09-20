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
    }
}