using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AvionesBackNet.Modules.seats
{
    public class seatPayDto
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public List<long> seats { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public long vueloId { get; set; }
    }
}