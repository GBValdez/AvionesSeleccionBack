using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvionesBackNet.Modules.Aeropuertos;
using AvionesBackNet.Modules.Vuelos.dto;

namespace AvionesBackNet.Modules.destinos
{
    public class destinoDto
    {
        public long Id { get; set; }
        public bool IsDestino { get; set; }

        public aerolineaDto Aerolinea { get; set; } = null!;

        public AeropuertoDto Aeropuerto { get; set; } = null!;
    }
}