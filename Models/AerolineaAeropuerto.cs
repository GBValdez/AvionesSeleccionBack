using System;
using System.Collections.Generic;
using project.utils;

namespace AvionesBackNet.Models;

public partial class AerolineaAeropuerto : CommonsModel<long>
{
    public long AerolineaId { get; set; }

    public long AeropuertoId { get; set; }

    public bool IsDestino { get; set; }

    public Aerolinea Aerolinea { get; set; } = null!;

    public Aeropuerto Aeropuerto { get; set; } = null!;
}
