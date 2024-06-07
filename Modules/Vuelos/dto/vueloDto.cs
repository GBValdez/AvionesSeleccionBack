using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvionesBackNet.Modules.Aeropuertos;
using AvionesBackNet.Modules.Aviones;

namespace AvionesBackNet.Modules.Vuelos
{
    public class vueloDto
    {
        public long Id { get; set; }
        public string Codigo { get; set; } = null!;
        public DateTime FechaSalida { get; set; }
        public DateTime FechaLlegada { get; set; }
        public virtual AeropuertoDto AeropuertoDestino { get; set; } = null!;

        public virtual AeropuertoDto AeropuertoOrigen { get; set; } = null!;

        public virtual AvionDto Avion { get; set; } = null!;
        public virtual ICollection<vueloClaseDto> VueloClases { get; set; } = new List<vueloClaseDto>();

    }
}