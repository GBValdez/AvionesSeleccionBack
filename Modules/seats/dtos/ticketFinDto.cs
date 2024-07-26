using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvionesBackNet.Modules.seats.dtos
{
    public class ticketFinDto
    {
        public string ticket { get; set; } = "";
        public List<ticketFinishedDto> ticketFinish { get; set; } = new List<ticketFinishedDto>();

    }
}