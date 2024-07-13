using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using project.utils.dto;

namespace AvionesBackNet.utils.dto
{
    public class errResPag<TDto>
    {
        public errorMessageDto error { get; set; }
        public resPag<TDto> resPag { get; set; }
    }
}