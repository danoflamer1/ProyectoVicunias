using System.ComponentModel.DataAnnotations;

namespace Vicuñas.Models
{
    public class Grado
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Numero { get; set; }
        [Required]
        public string? Nombre { get; set; }
        //relacion grado paralelo
        public virtual List<Paralelo>? Paralelos { get; set; }

    }
}
