using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace AvionesBackNet.utils
{
    public class CommonsModel<idClass> : ICommonModel<idClass>
    {
        public idClass Id { get; set; }
        public DateTime? DeletedAt { get  ; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? CreatedAt { get ; set; }
    }
}