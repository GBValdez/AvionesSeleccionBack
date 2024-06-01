using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvionesBackNet.utils
{
    public interface ICommonModelHeader
    {

        public DateTime? DeletedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public DateTime? CreatedAt { get; set; }

    }
}