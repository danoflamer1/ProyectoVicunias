using System.ComponentModel.DataAnnotations;

namespace Vicuñas.Models
{
    public class Estudiante
    {
        [Key]
        public int CI { get; set; }
        [Required, MinLength(5),MaxLength(50)]
        public string Apellido_P { get; set; }
        [Required, MinLength(5), MaxLength(50)]
        public string Apellido_M { get; set; }
        [Required, MinLength(5), MaxLength(50)]
        public string Nombres { get; set; }
        [Required]
        public char Sexo { get; set; }
        [Required]
        public DateTime Fecha_Nac { get; set; }
        public bool Discapacidad { get; set; }
        public bool Extranjero { get; set; }
        [Required]
        public int Nro_Telefono { get; set; }
        [Required]
        public int Nro_Celular { get; set; }
        [Required]
        public string Nro_Rude { get; set; }
    }
}
