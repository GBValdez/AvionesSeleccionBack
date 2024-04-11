using System;
using System.Collections.Generic;

namespace AvionesBackNet.Models;

public partial class VueloClase
{
    public ulong Id { get; set; }

    public ulong ClaseId { get; set; }

    public ulong VueloId { get; set; }

    public decimal Precio { get; set; }

    public DateTime? DeletedAt { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Catalogo Clase { get; set; } = null!;

    public virtual Vuelo Vuelo { get; set; } = null!;
}
