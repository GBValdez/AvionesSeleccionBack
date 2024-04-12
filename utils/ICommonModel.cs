using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace AvionesBackNet.utils
{
    public interface ICommonModel<IdClass> : ICommonModelHeader
    {
        public IdClass Id { get; set; }

    }
}