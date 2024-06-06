using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvionesBackNet.Modules.Empleados
{
    public class employeeQuery
    {
        public long? PuestoId { get; set; }
        public bool? withoutTripulation { get; set; } = null;

    }
}