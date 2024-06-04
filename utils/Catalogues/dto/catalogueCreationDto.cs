using System.ComponentModel.DataAnnotations;

namespace project.utils.catalogues.dto
{
    public class catalogueCreationDto
    {
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(255)]
        public string Descripcion { get; set; }
    }
}
