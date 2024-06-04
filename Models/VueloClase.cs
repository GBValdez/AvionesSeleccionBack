using System;
using System.Collections.Generic;
using project.utils;

namespace AvionesBackNet.Models;

public partial class VueloClase : CommonsModel<long>
{

    public long ClaseId { get; set; }

    public long VueloId { get; set; }

    public decimal Precio { get; set; }

    public virtual Catalogo Clase { get; set; } = null!;

    public virtual Vuelo Vuelo { get; set; } = null!;
}
