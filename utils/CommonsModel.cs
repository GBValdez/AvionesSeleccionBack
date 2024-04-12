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

        public string userUpdateId { get; set; }

        [ForeignKey("userUpdateId")]
        public DateTime? deleteAt { get; set; }
    }
}