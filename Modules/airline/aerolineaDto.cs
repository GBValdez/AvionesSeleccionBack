using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvionesBackNet.Modules.airline;
using AvionesBackNet.Modules.Paises;

namespace AvionesBackNet.Modules.Vuelos.dto
{
    public class aerolineaDto : airlineDtoBase
    {
        public long Id { get; set; }
        public paisDto Pais { get; set; } = null!;
    }
}