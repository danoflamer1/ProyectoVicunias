using System.ComponentModel.DataAnnotations;
using Vicuñas.Dtos;

namespace Vicuñas.Models
{
    public class Idioma_Cultura
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Idioma_1 { get; set; }
        public string? Idioma_2 { get; set; }
        public string? Idioma_3 { get; set; }
        public string? Idioma_4 { get; set; }
        public List<Idiomaenum>? Idiomas { get; set; }
    }
}
