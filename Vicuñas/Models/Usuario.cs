using System.ComponentModel.DataAnnotations;
using Vicuñas.Dtos;

namespace Vicuñas.Models
{
    public class Usuario
    {
        [Key]
        public int CI { get; set; }
        [Required, MinLength(5), MaxLength(50)]
        public string? Apellido_P { get; set; }
        [Required, MinLength(5), MaxLength(50)]
        public string? Apellido_M { get; set; }
        [Required, MinLength(5), MaxLength(50)]
        public string? Nombres { get; set; }
        [Required]
        public Rolenum Rol { get; set; }
        [Required]
        public float Sueldo { get; set; }
        //relacion usuario inscripcion
        public virtual List<Inscripcion>? Inscripciones { get; set; }
        //relacion usuario paralelo
        public virtual List<Paralelo>? Parallelos { get; set; }
        //relacion usuario materia
        public virtual List<Materia>? Materias { get; set; }
        //relacion usuario nota
        public virtual List<Nota>? Notas { get; set; }
    }
}
