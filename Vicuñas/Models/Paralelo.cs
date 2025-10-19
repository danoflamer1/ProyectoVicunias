using System.ComponentModel.DataAnnotations;

namespace Vicuñas.Models
{
    public class Paralelo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Nombre { get; set; }
        [Required]
        public int Cupo { get; set; }
        [Required]
        public bool Disponibilidad { get; set; }
        //relacion paralelo curso
        [Display(Name = "Grado del Paralelo")]
        public int? GradoId { get; set; }
        public virtual Grado? Grado { get; set; }
        //relacion paralelo inscripcion
        public virtual List<Inscripcion>? Inscripciones { get; set; }
        //relacion paralelo usuario
        [Display(Name = "Asesor de Curso")]
        public int? UsuarioId { get; set; }
        public virtual Usuario? Usuario { get; set; }
        //relacion paralelo estudiante
        public virtual List<Estudiante>? Estudiantes { get; set; }
    }
}
