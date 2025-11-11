using System.ComponentModel.DataAnnotations;

namespace Vicuñas.Models
{
    public class Materia
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Nombre { get; set; }
        //relacion materia usuario
        public int? UsuarioCi { get; set; }
        public virtual Usuario? Usuario { get; set; }
        //relacion materia nota
        public virtual List<Nota>? Notas { get; set; }
        //relacion materia usuario
        public int? ParaleloId { get; set; }
        public virtual Paralelo? Paralelo { get; set; }
    }
}
