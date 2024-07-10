using System;
using System.Collections.Generic;
using project.utils;

namespace AvionesBackNet.Models;

public partial class Aerolinea : CommonsModel<long>
{

    public string Nombre { get; set; } = null!;

    public string Codigo { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Email { get; set; } = null!;

    public long PaisId { get; set; }

    public Paise Pais { get; set; } = null!;

    public ICollection<Avione> Aviones { get; set; } = new List<Avione>();

    public ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();

    public ICollection<Tripulacione> Tripulaciones { get; set; } = new List<Tripulacione>();
}
