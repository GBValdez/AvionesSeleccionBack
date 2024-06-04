using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AvionesBackNet.Modules.country
{
    public class countryCreationDto
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(10, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        public string PhoneCode { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(5, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        public string Iso3166 { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(5, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        public string Iso4217 { get; set; } = null!;

    }
}