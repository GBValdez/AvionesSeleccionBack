using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AvionesBackNet.Modules.Vuelos.dto
{
    public class clienteCreationDto : clienteDtoBase
    {
        [Required(ErrorMessage = "El campo País es requerido")]
        public long PaisId { get; set; }
        [Required(ErrorMessage = "El campo Contraseña es requerido")]
        public string? userName { get; set; }
        [Required(ErrorMessage = "El campo Contraseña es requerido")]
        public string? password { get; set; }
        [Required(ErrorMessage = "El campo Código de Teléfono es requerido")]
        public long CodigoTelefono { get; set; }
        [Required(ErrorMessage = "El campo Código de Teléfono de Emergencia es requerido")]
        public long CodigoTelefonoEmergencia { get; set; }
    }
}