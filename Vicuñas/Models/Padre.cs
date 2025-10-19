using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vicuñas.Models
{
    public class Padre
    {
        [Key]
        public int Id { get; set; }
        public int CI { get; set; }
        public string? Ci_Complemento { get; set; }
        [Required]
        public string? Ci_Expedido { get; set; }
        [Required]
        public string? Tipo_Tutor { get; set; }
        [Required, MinLength(5), MaxLength(50)]
        public string? Apellido_P { get; set; }
        [Required, MinLength(5), MaxLength(50)]
        public string? Apellido_M { get; set; }
        [Required, MinLength(5), MaxLength(50)]
        public string? Nombres { get; set; }
        [Required, MinLength(3), MaxLength(50)]
        public string? Idioma1 { get; set; }
        [Required, MinLength(3), MaxLength(50)]
        public string? Laburo { get; set; }
        [Required, MinLength(3), MaxLength(50)]
        public string? Educacion { get; set; }
        public string? Contraseña { get; set; }
        [Required]
        [Column(TypeName = "date")]
        public DateTime Fecha_Nac { get; set; }
        //relacion tutor estudiante
        public virtual List<Estudiante>? Estudiantes { get; set; }
        //relacion tutor inscripcion
        public virtual List<Inscripcion>? Inscripciones { get; set; }
    }
}
