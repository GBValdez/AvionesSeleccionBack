using System;
using System.Collections.Generic;

namespace AvionesBackNet.Models;

public partial class Empleado
{
    public ulong Id { get; set; }

    public string Nombre { get; set; } = null!;

    public DateOnly FechaNacimiento { get; set; }

    public string Correo { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public ulong PaisId { get; set; }

    public ulong PuestoId { get; set; }

    public ulong TripulacionId { get; set; }

    public ulong AerolineaId { get; set; }

    public ulong UserId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Aerolinea Aerolinea { get; set; } = null!;

    public virtual Catalogo Pais { get; set; } = null!;

    public virtual Catalogo Puesto { get; set; } = null!;

    public virtual Tripulacione Tripulacion { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
