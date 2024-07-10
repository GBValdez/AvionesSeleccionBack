using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvionesBackNet.Models;
using AvionesBackNet.Modules.Catalogues;
using project.utils.catalogues.dto;

namespace AvionesBackNet.Modules.seats
{
    public class asientoDto : asientoDtoBase
    {
        public long Id { get; set; }
        public catalogueDto Clase { get; set; } = null;
        public long ClaseId { get; set; }

    }
}