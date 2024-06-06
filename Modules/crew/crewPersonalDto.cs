using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvionesBackNet.Modules.crew
{
    public class crewPersonalDto : crewCreationDto
    {
        public long piloto { get; set; }
        public long copiloto { get; set; }
        public long ingeniero { get; set; }
        public long azafata1 { get; set; }
        public long azafata2 { get; set; }
        public long azafata3 { get; set; }
    }
}