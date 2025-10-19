using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vicuñas.Models
{
    public class Nota
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(1900, 2100, ErrorMessage = "El año debe estar entre 1900 y 2100.")]
        public int Anio { get; set; }

        [Required]
        [Range(1, 4, ErrorMessage = "El trimestre debe ser 1, 2 o 3.")]
        public int Trimestre { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "El valor debe estar entre 0 y 100.")]
        public int Valor { get; set; }

        [Range(1000000, 99999999, ErrorMessage = "CI inválido.")]
        public int? UsuarioCi { get; set; }
        public virtual Usuario? Usuario { get; set; }

        [Range(1000000, 99999999, ErrorMessage = "CI inválido.")]
        public int? EstudianteCi { get; set; }
        public virtual Estudiante? Estudiante { get; set; }

        // Id de materia (si es autonumérico)
        [Range(1, 99999, ErrorMessage = "Id de materia inválido.")]
        public int? MateriaId { get; set; }
        public virtual Materia? Materia { get; set; }
    }
}
