using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvionesBackNet.Modules.Aeropuertos
{
    public class AeropuertoDtoCreation
    {
        public string Iata { get; set; } = null!;

        public string Oaci { get; set; } = null!;

        public string Nombre { get; set; } = null!;

        public string Ciudad { get; set; } = null!;

        public string Localidad { get; set; } = null!;

        public string ZonaHoraria { get; set; } = null!;

        public string Latitud { get; set; }

        public string Longitud { get; set; }

        public string Telefono { get; set; } = null!;

        public string Email { get; set; } = null!;

        public bool Activo { get; set; }

        public bool Interno { get; set; }

        public long PaisId { get; set; }
    }
}