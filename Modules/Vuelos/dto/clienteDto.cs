using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvionesBackNet.Modules.Catalogues;
using AvionesBackNet.Modules.Paises;
using AvionesBackNet.Modules.Vuelos.dto;
using project.utils.catalogues.dto;

namespace AvionesBackNet.Modules.Vuelos
{
    public class clienteDto : clienteDtoBase
    {

        public virtual paisDto CodigoTelefonoEmergenciaNavigation { get; set; } = null!;
        public virtual paisDto CodigoTelefonoNavigation { get; set; } = null!;
        public virtual paisDto Pais { get; set; } = null!;
    }
}