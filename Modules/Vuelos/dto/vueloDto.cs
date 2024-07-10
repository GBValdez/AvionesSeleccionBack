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
        public AeropuertoDto AeropuertoDestino { get; set; } = null!;

        public AeropuertoDto AeropuertoOrigen { get; set; } = null!;

        public AvionDto Avion { get; set; } = null!;
        public ICollection<vueloClaseDto> VueloClases { get; set; } = new List<vueloClaseDto>();

    }
}