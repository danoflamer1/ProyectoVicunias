using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Vicuñas.Dtos;

namespace Vicuñas.Models
{
    public class Inscripcion
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime Fecha { get; set; }
        public string? Idioma_1 { get; set; }
        public string? Idioma_2 { get; set; }
        public string? Idioma_3 { get; set; }
        public string? Idioma_4 { get; set; }
        public Idiomaenum Idiomas { get; set; }
        public bool Centro_Salud { get; set; }
        public int Tipo_Medicacion { get; set; }
        public int Frecuencia_Salud { get; set; }
        public bool Seguro_Salud { get; set; }
        public bool Agua { get; set; }
        public bool Banio { get; set; }
        public bool Alcantarillado { get; set; }
        public bool Electricidad { get; set; }
        public bool Basurero { get; set; }
        public int Tipo_Vivienda { get; set; }
        public int Internet { get; set; }
        public int Frecuencia_Internet { get; set; }
        public bool Estado_Laburo { get; set; }
        public int Tipo_Laburo { get; set; }
        public string? Laburo_Otro { get; set; }
        public int Mes { get; set; }
        public string? Medio_Transporte_Otro { get; set; }
        public int Turno { get; set; }
        public int Frecuencia_Laburo { get; set; }
        public bool Pago { get; set; }
        public int Tipo_Pago { get; set; }
        public int Medio_Transporte { get; set; }
        public string? MovilidadOtra { get; set; }
        public int Tiempo_Transporte { get; set; }
        public bool EstadoAbandono { get; set; }
        public Abandonoenum Motivo { get; set; }
        public string? Otro_Motivo { get; set; }
        //relacion inscripcion estudiante
        public int? EstudianteCi { get; set; }
        public virtual Estudiante? Estudiante { get; set; }
        //relacion inscripcion tutor
        public int? TutorCi { get; set; }
        public virtual Padre? Tutor { get; set; }
        //relacion inscripcion usuario
        public int? UsuarioCi { get; set; }
        public virtual Usuario? Usuario { get; set; }
        //relacion inscripcion paralelo
        public int? ParaleloId { get; set; }
        public virtual Paralelo? Paralelo { get; set; }
    }
}
