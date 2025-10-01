using System.ComponentModel.DataAnnotations;

namespace Vicuñas.Models
{
    public class Paralelo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Nombre { get; set; }

        //relacion paralelo curso
        public int? GradoId { get; set; }
        public virtual Grado? Grado { get; set; }
        //relacion paralelo inscripcion
        public virtual Inscripcion? Inscripcion { get; set; }
        //relacion paralelo usuario
        public int? UsuarioCi { get; set; }
        public virtual Usuario? Usuario { get; set; }
        //relacion paralelo estudiante
        public virtual List<Estudiante>? Estudiantes { get; set; }
    }
}
