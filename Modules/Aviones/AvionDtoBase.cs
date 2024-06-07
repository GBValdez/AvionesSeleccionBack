using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AvionesBackNet.Modules.Aviones
{
    public class AvionDtoBase
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Codigo { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Year { get; set; } = null!;
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Serie { get; set; } = null!;
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(1, double.MaxValue, ErrorMessage = "El campo {0} debe ser un número positivo")]
        public decimal CapacidadCarga { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(1, double.MaxValue, ErrorMessage = "El campo {0} debe ser un número positivo")]
        public decimal CapacidadPasajeros { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(1, double.MaxValue, ErrorMessage = "El campo {0} debe ser un número positivo")]

        public decimal CapacidadCombustible { get; set; }

    }
}