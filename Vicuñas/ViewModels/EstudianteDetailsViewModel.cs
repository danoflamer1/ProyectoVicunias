using System.Collections.Generic;
using Vicuñas.Models;

namespace Vicuñas.ViewModels
{
    public class EstudianteDetailsViewModel
    {
        public Estudiante Estudiante { get; set; } = null!;
        public List<Nota> Notas { get; set; } = new List<Nota>();
        public List<Mensaje> Mensajes { get; set; } = new List<Mensaje>();
    }
}
