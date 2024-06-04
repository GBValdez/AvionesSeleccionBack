using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvionesBackNet.Modules.Paises
{
    public class paisDto
    {
        public long Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string PhoneCode { get; set; } = null!;
        public string Iso3166 { get; set; } = null!;
        public string Iso4217 { get; set; } = null!;
    }
}