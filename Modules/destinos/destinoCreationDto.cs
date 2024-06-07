using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvionesBackNet.Modules.destinos
{
    public class destinoCreationDto
    {
        public long AerolineaId { get; set; }
        public long AeropuertoId { get; set; }
        public bool IsDestino { get; set; }
    }
}