using System.ComponentModel.DataAnnotations.Schema;

namespace Vicuñas.Models
{
    public class Reporte
    {
        public int Id { get; set; }
        public string? Tipo { get; set; }
        public DateTime FechaGeneracion { get; set; } = DateTime.Now;
        public string? NombreArchivo { get; set; }
        [NotMapped]
        public IFormFile? Archivo { get; set; }
        //relacion reporte usuario
        public int UsuarioCi { get; set; }
        public virtual Usuario? Usuario { get; set; } 
    }
}
