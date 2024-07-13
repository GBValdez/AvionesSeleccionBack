using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using project.utils.dto;

namespace AvionesBackNet.Modules.Vuelos.dto
{
    public class vueloWithPassagerDto
    {
        public vueloDto Vuelo { get; set; } = null!;
        public resPag<boletoDto> Boletos { get; set; } = null!;
    }
}