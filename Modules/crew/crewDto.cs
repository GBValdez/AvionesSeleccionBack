using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvionesBackNet.Models;
using AvionesBackNet.Modules.Empleados;
using AvionesBackNet.Modules.Vuelos.dto;

namespace AvionesBackNet.Modules.crew
{
    public class crewDto : crewDtoBase
    {
        public long Id { get; set; }
        public virtual aerolineaDto Aerolinea { get; set; } = null!;
        public virtual ICollection<employeeDto> Empleados { get; set; } = new List<employeeDto>();
    }
}