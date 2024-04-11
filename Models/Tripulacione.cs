using System;
using System.Collections.Generic;

namespace AvionesBackNet.Models;

public partial class Tripulacione
{
    public ulong Id { get; set; }

    public string Codigo { get; set; } = null!;

    public ulong AerolineaId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Aerolinea Aerolinea { get; set; } = null!;

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();

    public virtual ICollection<Vuelo> Vuelos { get; set; } = new List<Vuelo>();
}
