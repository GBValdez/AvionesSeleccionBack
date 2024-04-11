using System;
using System.Collections.Generic;

namespace AvionesBackNet.Models;

public partial class BitacoraCuerpo
{
    public ulong Id { get; set; }

    public string Campo { get; set; } = null!;

    public string ValorAnterior { get; set; } = null!;

    public string ValorNuevo { get; set; } = null!;

    public ulong BitacoraEncabezadoId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual BitacoraEncabezado BitacoraEncabezado { get; set; } = null!;
}
