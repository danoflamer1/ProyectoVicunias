using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vicuñas.Models
{
    public class Mensaje
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "date")]
        public DateTime Fecha{ get; set; }
        [Required]
        public string? Titulo { get; set; }
        [Required]
        public string? Descripcion { get; set; }
        //relacion grado paralelo
        public int? EstudianteId { get; set; }
        public virtual Estudiante? Estudiante { get; set; }

        public int? UsuarioId { get; set; }
        public virtual Usuario? Usuario { get; set; }
    }
}
