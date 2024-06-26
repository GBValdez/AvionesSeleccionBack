﻿using System.ComponentModel.DataAnnotations;

namespace AvionesBackNet.Modules.Categories
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
