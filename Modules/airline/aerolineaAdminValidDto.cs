using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using project.utils.dto;

namespace AvionesBackNet.Modules.airline
{
    public class aerolineaAdminValidDto
    {
        public long? aerlonieaId { get; set; }
        public errorMessageDto? error { get; set; }
    }
}