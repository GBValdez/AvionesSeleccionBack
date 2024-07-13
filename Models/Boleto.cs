using System;
using System.Collections.Generic;
using project.utils;

namespace AvionesBackNet.Models;

public partial class Boleto : CommonsModel<long>
{
    public string Codigo { get; set; } = null!;
    public int CantidadMaletasPresentadas { get; set; }
    public long EstadoBoletoId { get; set; }
    public long VueloId { get; set; }

    public long AsientoId { get; set; }

    public long ClienteId { get; set; }
    public long ClaseId { get; set; }
    public Catalogo Clase { get; set; } = null!;
    public Asiento Asiento { get; set; } = null!;

    public Cliente Cliente { get; set; } = null!;

    public Catalogo EstadoBoleto { get; set; } = null!;

    public Vuelo Vuelo { get; set; } = null!;
}
