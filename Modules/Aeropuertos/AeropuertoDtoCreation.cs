using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AvionesBackNet.Modules.Aeropuertos
{
    public class AeropuertoDtoCreation
    {
        [Required(ErrorMessage = "El Iata es requerido")]
        [StringLength(3, ErrorMessage = "El Iata no puede tener mas de {1} caracteres")]
        public string Iata { get; set; } = null!;

        [Required(ErrorMessage = "El Oaci es requerido")]
        [StringLength(4, ErrorMessage = "El Oaci no puede tener mas de {1} caracteres")]
        public string Oaci { get; set; } = null!;
        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(50, ErrorMessage = "El nombre no puede tener mas de {1} caracteres")]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = "La direccion es requerida")]
        [StringLength(255, ErrorMessage = "La direccion no puede tener mas de {1} caracteres")]
        public string Ciudad { get; set; } = null!;

        [Required(ErrorMessage = "La localidad es requerida")]
        [StringLength(255, ErrorMessage = "La localidad no puede tener mas de {1} caracteres")]
        public string Localidad { get; set; } = null!;

        [Required(ErrorMessage = "La zona horaria es requerida")]
        public long ZonaHorariaId { get; set; }

        [Required(ErrorMessage = "La latitud es requerida")]
        public string Latitud { get; set; }

        [Required(ErrorMessage = "La longitud es requerida")]
        public string Longitud { get; set; }

        [Required(ErrorMessage = "El telefono es requerido")]
        [StringLength(10, ErrorMessage = "El telefono no puede tener mas de {1} caracteres")]
        public string Telefono { get; set; } = null!;
        [Required(ErrorMessage = "El email es requerido")]
        [EmailAddress(ErrorMessage = "El email no es valido")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "El estado es requerido")]
        public bool Activo { get; set; }

        [Required(ErrorMessage = "El estado es requerido")]
        public bool Interno { get; set; }

        [Required(ErrorMessage = "El pais es requerido")]
        public long PaisId { get; set; }
    }
}