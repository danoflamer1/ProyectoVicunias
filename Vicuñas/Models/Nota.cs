using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vicuñas.Models
{
    public class Nota
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Anio { get; set; }
        [Required]
        public int Trimestre { get; set; }
        [Required]
        public int Valor { get; set; }
        //relacion nota usuario
        public int? UsuarioCi { get; set; }
        public virtual Usuario? Usuario { get; set; }
        //relacion nota estudiante 
        public int? EstudianteCi { get; set; }
        public virtual Estudiante? Estudiante { get; set; }
        //relacion nota materia
        public int? MateriaId { get; set; }
        public virtual Materia? Materia { get; set; }
    }
}
