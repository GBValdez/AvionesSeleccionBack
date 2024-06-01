using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvionesBackNet.Models;
using AvionesBackNet.Modules.Catalogues;

namespace AvionesBackNet.Modules.seats
{
    public class asientoDto : asientoDtoBase
    {
        public long Id { get; set; }
        public catalogueDto Clase { get; set; } = null;
        public catalogueDto Estado { get; set; } = null;
    }
}