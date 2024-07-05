using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvionesBackNet.Modules.seats
{
    public class seatPlaneDto
    {
        public List<asientoDtoCreation> asientos { get; set; }
        public decimal sizeSeat { get; set; }
    }
}