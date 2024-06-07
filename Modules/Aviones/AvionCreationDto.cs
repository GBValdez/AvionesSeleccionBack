using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AvionesBackNet.Modules.Aviones
{
    public class AvionCreationDto : AvionDtoBase
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public long MarcaId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public long ModeloId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public long TipoAvionId { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public long TripulacionId { get; set; }

    }
}