using System;
using System.Collections.Generic;
using project.utils;

namespace AvionesBackNet.Models;

public partial class ModeloAvionAerolinea : CommonsModel<long>
{

    public long ModeloAvionId { get; set; }

    public long AerolineaId { get; set; }
    public virtual Aerolinea Aerolinea { get; set; } = null!;

    public virtual Catalogo ModeloAvion { get; set; } = null!;
}
