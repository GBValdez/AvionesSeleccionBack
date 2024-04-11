using System;
using System.Collections.Generic;

namespace AvionesBackNet.Models;

public partial class Aerolinea
{
    public ulong Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Codigo { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Email { get; set; } = null!;

    public ulong PaisId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<AerolineaAeropuerto> AerolineaAeropuertos { get; set; } = new List<AerolineaAeropuerto>();

    public virtual ICollection<Avione> Aviones { get; set; } = new List<Avione>();

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();

    public virtual ICollection<ModeloAvionAerolinea> ModeloAvionAerolineas { get; set; } = new List<ModeloAvionAerolinea>();

    public virtual Catalogo Pais { get; set; } = null!;

    public virtual ICollection<Tripulacione> Tripulaciones { get; set; } = new List<Tripulacione>();
}
