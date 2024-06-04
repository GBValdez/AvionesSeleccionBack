using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvionesBackNet.Modules.Catalogues;
using project.utils.catalogues.dto;

namespace AvionesBackNet.Modules.Vuelos
{
    public class vueloClaseDto
    {
        public decimal Precio { get; set; }

        public virtual catalogueDto Clase { get; set; } = null!;

        public virtual vueloDto Vuelo { get; set; } = null!;
    }
}