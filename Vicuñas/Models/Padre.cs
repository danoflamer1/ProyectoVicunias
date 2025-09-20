using System.ComponentModel.DataAnnotations;

namespace Vicuñas.Models
{
    public class Padre
    {
        [Key]
        public int CI { get; set; }
        [Required, MinLength(5), MaxLength(50)]
        public string Apellido_P { get; set; }
        [Required, MinLength(5), MaxLength(50)]
        public string Apellido_M { get; set; }
        [Required, MinLength(5), MaxLength(50)]
        public string Nombres { get; set; }
        [Required, MinLength(3), MaxLength(50)]
        public string Idioma1 { get; set; }
        [Required, MinLength(3), MaxLength(50)]
        public string Laburo { get; set; }
        [Required, MinLength(3), MaxLength(50)]
        public string Educacion { get; set; }
        [Required]
        public DateTime Fecha_Nac { get; set; }
        public bool Extranjero { get; set; }
    }
}
