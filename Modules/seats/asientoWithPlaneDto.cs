using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvionesBackNet.Modules.Aviones;

namespace AvionesBackNet.Modules.seats
{
    public class avionWithSeatsDto
    {
        public AvionDto avion { get; set; }
        public List<asientoDto> asientoDtos { get; set; }
    }
}