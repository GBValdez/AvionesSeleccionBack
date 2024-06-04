using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvionesBackNet.Modules.Catalogues;
using AvionesBackNet.Modules.Paises;
using project.utils.catalogues.dto;

namespace AvionesBackNet.Modules.Vuelos
{
    public class clienteDto
    {
        public string NoPasaporte { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public DateOnly FechaNacimiento { get; set; }
        public string Correo { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string TelefonoEmergencia { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public virtual catalogueDto CodigoTelefonoEmergenciaNavigation { get; set; } = null!;
        public virtual catalogueDto CodigoTelefonoNavigation { get; set; } = null!;
        public virtual paisDto Pais { get; set; } = null!;
    }
}