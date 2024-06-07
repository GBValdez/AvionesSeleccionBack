using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AvionesBackNet.Modules.Vuelos.dto
{
    public class clienteDtoBase
    {
        [Required(ErrorMessage = "El campo No Pasaporte es requerido")]
        public string NoPasaporte { get; set; } = null!;

        [Required(ErrorMessage = "El campo Nombre es requerido")]
        [StringLength(100, ErrorMessage = "El campo Nombre no puede tener más de 100 caracteres")]
        public string Nombre { get; set; } = null!;
        [Required(ErrorMessage = "El campo Fecha de Nacimiento es requerido")]
        public DateOnly FechaNacimiento { get; set; }
        [Required(ErrorMessage = "El campo Correo es requerido")]
        public string Correo { get; set; } = null!;
        [Required(ErrorMessage = "El campo Teléfono es requerido")]
        [StringLength(10, ErrorMessage = "El campo Teléfono no puede tener más de 10 caracteres")]
        public string Telefono { get; set; } = null!;
        [Required(ErrorMessage = "El campo Teléfono de Emergencia es requerido")]
        [StringLength(10, ErrorMessage = "El campo Teléfono de Emergencia no puede tener más de 10 caracteres")]
        public string TelefonoEmergencia { get; set; } = null!;
        [Required(ErrorMessage = "El campo Dirección es requerido")]
        [StringLength(100, ErrorMessage = "El campo Dirección no puede tener más de 100 caracteres")]
        public string Direccion { get; set; } = null!;
    }
}