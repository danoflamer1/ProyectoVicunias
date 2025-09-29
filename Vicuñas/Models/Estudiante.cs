using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vicuñas.Models
{
    public class Estudiante
    {
        [Key]
        public int CI { get; set; }
        public string? Ci_Complemento { get; set; }
        [Required]
        public string? Ci_Expedido { get; set; }
        [Required, MinLength(5),MaxLength(50)]
        public string? Apellido_P { get; set; }
        [Required, MinLength(5), MaxLength(50)]
        public string? Apellido_M { get; set; }
        [Required, MinLength(5), MaxLength(50)]
        public string? Nombres { get; set; }
        [Required]
        public char Sexo { get; set; }
        [Required]
        [Column(TypeName = "date")]
        public DateTime Fecha_Nac { get; set; }
        [Required]
        public bool Discapacidad { get; set; }
        public int Nro_Discapacidad { get; set; }
        public string? Tipo_Auditiva { get; set; }
        public string? Tipo_Visual { get; set; }
        public string? Tipo_Intelectual { get; set; }
        public string? Tipo_Fisica { get; set; }
        public string? Tipo_Mental { get; set; }
        public string? Tipo_Discapacidad { get; set; }
        public List<string>? Programa_Apoyo { get; set; }
        [Required]
        public bool Extranjero { get; set; }
        public string? Tipo_Documento_Extranjero { get; set; }
        public string? Nro_Documento_Extranjero { get; set; }
        [Required]
        public int Nro_Telefono { get; set; }
        [Required]
        public int Nro_Celular { get; set; }
        [Required]
        public string? Pais { get; set; }
        [Required]
        public string? Departamento { get; set; }
        [Required]
        public string? Provincia { get; set; }
        [Required]
        public string? Municipio { get; set; }
        [Required]
        public string? Localidad { get; set; }
        [Required]
        public string? Zona { get; set; }
        [Required]
        public string? Direccion { get; set; }
        [Required]
        public int Nro_Vivienda { get; set; }
        [Required]
        public int Certificado_Oficialia { get; set; }
        [Required]
        public int Certificado_Libro { get; set; }
        [Required]
        public int Certificado_Partida { get; set; }
        [Required]
        public int Certificado_Folio { get; set; }
        [Required]
        public string? Nro_Rude { get; set; }
        //relacion padre estudiante
        public virtual List<Padre>? Tutores { get; set; }
        //relacion inscripcion estudiante
        public virtual List<Inscripcion>? Inscripciones { get; set; }
        //relacion estudiante paralelo
        public int ParaleloId { get; set; }
        public virtual Paralelo? Paralelo { get; set; }
        //relacion estudiante nota 
        public virtual List<Nota>? Notas { get; set; }
    }
}
