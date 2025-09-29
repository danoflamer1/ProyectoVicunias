using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vicuñas.Models
{
    public class Inscripcion
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime Fecha { get; set; }
        //relacion inscripcion estudiante
        public int EstudianteCi { get; set; }
        public virtual Estudiante? Estudiante { get; set; }
        //relacion inscripcion tutor
        public int TutorCi { get; set; }
        public virtual Padre? Tutor { get; set; }
        //relacion inscripcion usuario
        public int UsuarioCi { get; set; }
        public virtual Usuario? Usuario { get; set; }
        //relacion inscripcion paralelo
        public int ParaleloId { get; set; }
        public virtual Paralelo? Paralelo { get; set; }
    }
}
