using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvionesBackNet.utils
{
    public interface ICommonModelHeader
    {
        public string userUpdateId { get; set; }

        public DateTime? deleteAt { get; set; }

    }
}