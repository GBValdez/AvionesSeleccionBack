using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvionesBackNet.Modules.Empleados
{
    public class employeeCreationDto : employeeDtoBase
    {
        public long PaisId { get; set; }
        public long PuestoId { get; set; }
        public long TripulacionId { get; set; }
        public long AerolineaId { get; set; }
        public string UserId { get; set; }
    }
}