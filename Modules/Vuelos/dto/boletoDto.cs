using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvionesBackNet.Modules.Catalogues;
using AvionesBackNet.Modules.seats;
using project.utils.catalogues.dto;

namespace AvionesBackNet.Modules.Vuelos
{
    public class boletoDto
    {
        public int CantidadMaletasAdquiridas { get; set; }
        public int CantidadMaletasPresentadas { get; set; }
        public long AsientoId { get; set; }
        public long ClienteId { get; set; }
        public virtual asientoDto Asiento { get; set; } = null!;
        public virtual clienteDto Cliente { get; set; } = null!;
        public virtual catalogueDto EstadoBoleto { get; set; } = null!;
        public virtual vueloDto Vuelo { get; set; } = null!;
    }
}