using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvionesBackNet.Modules.Vuelos
{
    public class vueloDtoCreation
    {
        public string Codigo { get; set; } = null!;
        public DateTime FechaSalida { get; set; }
        public DateTime FechaLlegada { get; set; }
        public long AvionId { get; set; }
        public long AeropuertoOrigenId { get; set; }
        public long AeropuertoDestinoId { get; set; }
        public ICollection<vueloClaseDtoCreation> VueloClases { get; set; } = new List<vueloClaseDtoCreation>();

    }
}