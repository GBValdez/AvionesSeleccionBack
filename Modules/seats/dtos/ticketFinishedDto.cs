using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvionesBackNet.Modules.seats.dtos
{
    public class ticketFinishedDto
    {
        public string Codigo { get; set; } = null!;
        public int CantidadDeMaletas { get; set; }
    }
}