using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvionesBackNet.Modules.seats
{
    public class asientoDtoCreation : asientoDtoBase
    {
        public ulong ClaseId { get; set; }
        public ulong AvionId { get; set; }
    }
}