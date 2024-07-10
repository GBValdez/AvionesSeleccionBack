using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using project.users;
using project.utils;

namespace AvionesBackNet.Models;

public partial class Empleado : CommonsModel<long>
{
    public string Nombre { get; set; } = null!;
    public DateOnly FechaNacimiento { get; set; }
    public string Correo { get; set; } = null!;
    public string Direccion { get; set; } = null!;
    public string Telefono { get; set; } = null!;
    public long PaisId { get; set; }
    public long PuestoId { get; set; }
    public long? TripulacionId { get; set; } = null;
    public long AerolineaId { get; set; }
    public string UserId { get; set; }
    public Aerolinea Aerolinea { get; set; } = null!;
    public Paise Pais { get; set; } = null!;
    public Catalogo Puesto { get; set; } = null!;
    public Tripulacione? Tripulacion { get; set; } = null!;
    [ForeignKey("UserId")]
    public userEntity User { get; set; } = null!;
}
