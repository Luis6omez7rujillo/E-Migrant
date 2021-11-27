using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio
{
    public class Servicios
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [MaxLength(40, ErrorMessage = "El campo {0} no puede superar los {1} caracteres")]
        [MinLength(4, ErrorMessage = "El campo {0} debe tener al menos {1} caracteres")]
        [RegularExpression("[a-zA-ZñÑáéíóúÁÉÍÓÚ ]*", ErrorMessage = "En el campo {0} se permiten solamente letras")]
        [Display (Name="Nombres")]
        public string Nombre {get;set;}

        //Tipo de dato Int para lograr validar el numero de inmigrantes
        public int MaxMigrantes{get;set;}

        //Tipo de dato Date - Con la finalidad de que se pueda escoger año, mes y dia
        public DateTime FechaInicio {get;set;}

        //Tipo de dato Date - Con la finalidad de que se pueda escoger año, mes y dia
        public DateTime FechaFinal {get;set;}

        
        public string Estado {get;set;}
        
    }
}