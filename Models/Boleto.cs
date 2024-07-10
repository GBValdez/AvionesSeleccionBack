using System;
using System.Collections.Generic;
using project.utils;

namespace AvionesBackNet.Models;

public partial class Boleto : CommonsModel<long>
{
    public int CantidadMaletasAdquiridas { get; set; }

    public int CantidadMaletasPresentadas { get; set; }

    public long EstadoBoletoId { get; set; }

    public long VueloId { get; set; }

    public long AsientoId { get; set; }

    public long ClienteId { get; set; }
    public Asiento Asiento { get; set; } = null!;

    public Cliente Cliente { get; set; } = null!;

    public Catalogo EstadoBoleto { get; set; } = null!;

    public Vuelo Vuelo { get; set; } = null!;
}
