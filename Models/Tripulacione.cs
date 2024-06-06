using System;
using System.Collections.Generic;
using project.utils;

namespace AvionesBackNet.Models;

public partial class Tripulacione : CommonsModel<long>
{

    public string Codigo { get; set; } = null!;
    public long AerolineaId { get; set; }
    public virtual Aerolinea Aerolinea { get; set; } = null!;

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
