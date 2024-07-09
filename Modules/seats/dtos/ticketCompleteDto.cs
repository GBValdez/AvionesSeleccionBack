using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvionesBackNet.Modules.Aviones;
using AvionesBackNet.Modules.Vuelos;

namespace AvionesBackNet.Modules.seats.dtos
{
    public class ticketCompleteDto
    {
        public List<boletoDto> boletos { get; set; }
        public vueloDto vuelo { get; set; }
        public clienteDto cliente { get; set; }
    }
}