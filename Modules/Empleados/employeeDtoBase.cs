using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvionesBackNet.Modules.Empleados
{
    public class employeeDtoBase
    {
        public string Nombre { get; set; } = null!;
        public DateOnly FechaNacimiento { get; set; }
        public string Correo { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string Telefono { get; set; } = null!;
    }
}