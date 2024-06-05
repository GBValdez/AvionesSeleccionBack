using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AvionesBackNet.Modules.airline
{
    public class airlineDtoBase
    {
        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(50, ErrorMessage = "El nombre no puede tener mas de {1} caracteres")]
        public string Nombre { get; set; } = null!;
        [Required(ErrorMessage = "El codigo es requerido")]
        [StringLength(10, ErrorMessage = "El codigo no puede tener mas de {1} caracteres")]
        public string Codigo { get; set; } = null!;
        [Required(ErrorMessage = "La direccion es requerida")]
        [StringLength(255, ErrorMessage = "La direccion no puede tener mas de {1} caracteres")]
        public string Direccion { get; set; } = null!;
        [Required(ErrorMessage = "El telefono es requerido")]
        [StringLength(10, ErrorMessage = "El telefono no puede tener mas de {1} caracteres")]
        public string Telefono { get; set; } = null!;

        [Required(ErrorMessage = "El email es requerido")]
        [StringLength(50, ErrorMessage = "El email no puede tener mas de {1} caracteres")]
        [EmailAddress(ErrorMessage = "El email no es valido")]
        public string Email { get; set; } = null!;
    }
}