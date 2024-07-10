using AvionesBackNet.Models;
using AvionesBackNet.Modules.crew;
using AvionesBackNet.Modules.Paises;
using AvionesBackNet.Modules.Vuelos.dto;
using project.users;
using project.users.dto;
using project.utils.catalogues.dto;

namespace AvionesBackNet.Modules.Empleados
{
    public class employeeDto : employeeDtoBase
    {
        public long Id { get; set; }
        public aerolineaDto Aerolinea { get; set; } = null!;
        public paisDto Pais { get; set; } = null!;
        public catalogueDto Puesto { get; set; } = null!;
        public crewDto Tripulacion { get; set; } = null!;
        public userDto User { get; set; } = null!;
    }
}