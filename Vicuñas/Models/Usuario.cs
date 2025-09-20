using System.ComponentModel.DataAnnotations;
using Vicuñas.Dtos;

namespace Vicuñas.Models
{
    public class Usuario
    {
        [Key]
        public int CI { get; set; }
        [Required, MinLength(5), MaxLength(50)]
        public string Apellido_P { get; set; }
        [Required, MinLength(5), MaxLength(50)]
        public string Apellido_M { get; set; }
        [Required, MinLength(5), MaxLength(50)]
        public string Nombres { get; set; }
        [Required]
        public Rolenum Rol { get; set; }
    }
}
