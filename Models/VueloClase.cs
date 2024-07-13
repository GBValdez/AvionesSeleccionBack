using System;
using System.Collections.Generic;
using project.utils;

namespace AvionesBackNet.Models;

public partial class VueloClase : CommonsModel<long>
{

    public long ClaseId { get; set; }

    public long VueloId { get; set; }

    public decimal Precio { get; set; }

    public int CantidadMaletasMax { get; set; }

    public Catalogo Clase { get; set; } = null!;

    public Vuelo Vuelo { get; set; } = null!;
}
