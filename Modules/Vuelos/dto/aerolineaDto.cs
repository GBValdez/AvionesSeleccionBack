using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvionesBackNet.Modules.Vuelos.dto
{
    public class aerolineaDto
    {
        public string Nombre { get; set; } = null!;

        public string Codigo { get; set; } = null!;

        public string Direccion { get; set; } = null!;

        public string Telefono { get; set; } = null!;

        public string Email { get; set; } = null!;
    }
}