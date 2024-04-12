using System.ComponentModel.DataAnnotations;

namespace AvionesBackNet.Modules.Categories
{
    public class catalogueDto
    {
        [Required]
        [StringLength(50)]
        public string name { get; set; }
        [Required]
        [StringLength(255)]
        public string description { get; set; }
    }
}
