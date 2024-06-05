using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AvionesBackNet.Modules.airline
{
    public class airlineCreationDto : airlineDtoBase
    {
        [Required(ErrorMessage = "El pais es requerido")]
        public long PaisId { get; set; }
    }
}