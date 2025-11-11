using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vicuñas.Models
{
    public class Estudiante
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(1000000, 99999999, ErrorMessage = "El CI debe tener entre 7 y 8 dígitos.")]
        public int CI { get; set; }

        [MaxLength(2, ErrorMessage = "El complemento del CI no debe tener más de 2 caracteres.")]
        public string? Ci_Complemento { get; set; }

        [Required, MaxLength(2, ErrorMessage = "El código de expedición debe tener 2 caracteres, por ejemplo: LP, CB, SC.")]
        public string? Ci_Expedido { get; set; }

        [Required, MinLength(3), MaxLength(20)]
        public string? Apellido_P { get; set; } 

        [Required, MinLength(3), MaxLength(20)]
        public string? Apellido_M { get; set; }

        [Required, MinLength(1), MaxLength(30)]
        public string? Nombres { get; set; }

        [Required]
        /*[RegularExpression("^[MF]$", ErrorMessage = "El sexo debe ser 'M' o 'F'.")]*/
        public string? Sexo { get; set; }
        [Required]
        public bool Inscrito { get; set; }
        [Required]
        [Column(TypeName = "date")]
        public DateOnly Fecha_Nac { get; set; }


        [Required]
        public bool Discapacidad { get; set; }


        public string? Nro_Discapacidad { get; set; }

        public string? Tipo_Auditiva { get; set; }

        public string? Tipo_Visual { get; set; }

        public string? Tipo_Intelectual { get; set; }

        public string? Tipo_Fisica { get; set; }

        public string? Tipo_Mental { get; set; }

        public string? Tipo_Discapacidad { get; set; }

        public List<string>? Programa_Apoyo { get; set; }

        [Required]
        public bool Extranjero { get; set; }

        [MaxLength(30)]
        public string? Tipo_Documento_Extranjero { get; set; }

        [MaxLength(30)]
        public string? Nro_Documento_Extranjero { get; set; }

        [Required]
        [Range(1000000, 99999999, ErrorMessage = "Número de teléfono inválido.")]
        public int Nro_Telefono { get; set; }

        [Required]
        [Range(10000000, 99999999, ErrorMessage = "Número de celular inválido.")]
        public int Nro_Celular { get; set; }

        [Required, MaxLength(30)]
        public string Pais { get; set; } = string.Empty;

        [Required, MaxLength(30)]
        public string Departamento { get; set; } = string.Empty;

        [Required, MaxLength(30)]
        public string Provincia { get; set; } = string.Empty;

        [Required, MaxLength(30)]
        public string Municipio { get; set; } = string.Empty;

        [Required, MaxLength(30)]
        public string Localidad { get; set; } = string.Empty;

        [Required, MaxLength(30)]
        public string Zona { get; set; } = string.Empty;

        [Required, MaxLength(100)]
        public string Direccion { get; set; } = string.Empty;

        [Required, Range(1, 99999)]
        public int Nro_Vivienda { get; set; }

        [Required, Range(1, 9999)]
        public int Certificado_Oficialia { get; set; }

        [Required, Range(1, 9999)]
        public int Certificado_Libro { get; set; }

        [Required, Range(1, 999999)]
        public int Certificado_Partida { get; set; }

        [Required, Range(1, 9999)]
        public int Certificado_Folio { get; set; }

        [Required, MinLength(6), MaxLength(15)]
        public string Nro_Rude { get; set; } = string.Empty;

       public int Strikes { get; set; }

        //relacion padre estudiante
        public virtual List<Padre>? Tutores { get; set; }
        //relacion inscripcion estudiante
        public virtual List<Inscripcion>? Inscripciones { get; set; }
        //relacion estudiante paralelo

        public int? ParaleloId { get; set; }
        public virtual Paralelo? Paralelo { get; set; }
        //relacion estudiante nota 
        public virtual List<Nota>? Notas { get; set; }
        //relacion estudiante Mensaje
        public virtual List<Mensaje>? Mensajes{ get; set; }
    }
}
