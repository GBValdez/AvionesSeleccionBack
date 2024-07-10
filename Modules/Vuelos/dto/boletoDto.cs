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
        public asientoDto Asiento { get; set; } = null!;
        public clienteDto Cliente { get; set; } = null!;
        public catalogueDto EstadoBoleto { get; set; } = null!;
        public vueloDto Vuelo { get; set; } = null!;
    }
}