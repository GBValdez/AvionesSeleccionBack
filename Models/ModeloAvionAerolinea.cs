using System;
using System.Collections.Generic;

namespace AvionesBackNet.Models;

public partial class ModeloAvionAerolinea
{
    public ulong Id { get; set; }

    public ulong ModeloAvionId { get; set; }

    public ulong AerolineaId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Aerolinea Aerolinea { get; set; } = null!;

    public virtual Catalogo ModeloAvion { get; set; } = null!;
}
