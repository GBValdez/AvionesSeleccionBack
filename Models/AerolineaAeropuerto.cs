using System;
using System.Collections.Generic;

namespace AvionesBackNet.Models;

public partial class AerolineaAeropuerto
{
    public ulong Id { get; set; }

    public ulong AerolineaId { get; set; }

    public ulong AeropuertoId { get; set; }

    public bool IsDestino { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Aerolinea Aerolinea { get; set; } = null!;

    public virtual Aeropuerto Aeropuerto { get; set; } = null!;
}
