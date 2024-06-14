using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AvionesBackNet.Modules.Vuelos.dto
{
    public class vueloQueryDto
    {
        public long? AeropuertoOrigenId { get; set; }
        public long? AeropuertoDestinoId { get; set; }
        public DateTime? FechaSalidaGreat { get; set; }
        public DateTime? FechaSalidaSmall { get; set; }
        public long? AerolineaId { get; set; }


    }
}