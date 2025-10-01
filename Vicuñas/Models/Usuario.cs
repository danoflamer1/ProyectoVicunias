using System.ComponentModel.DataAnnotations;
using Vicuñas.Dtos;

namespace Vicuñas.Models
{
    public class Usuario
    {
        [Key]
        [Display(Name = "Cédula de Identidad")]
        public int CI { get; set; }
        [Required, MinLength(2), MaxLength(50)]
        [Display(Name = "Apellido Paterno")]
        public string? Apellido_P { get; set; }
        [Display(Name = "Apellido Materno")]
        [Required, MinLength(2), MaxLength(50)]
        public string? Apellido_M { get; set; }
        [Display(Name = "Nombres")]
        [Required, MinLength(2), MaxLength(50)]
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
        //relacion usuario reporte
        public virtual List<Reporte>? Reportes { get; set; }
    }
}
