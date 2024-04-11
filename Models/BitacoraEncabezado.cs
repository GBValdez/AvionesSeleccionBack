using System;
using System.Collections.Generic;

namespace AvionesBackNet.Models;

public partial class BitacoraEncabezado
{
    public ulong Id { get; set; }

    public string Tabla { get; set; } = null!;

    public string IdRegistro { get; set; } = null!;

    public string TipoTransaccion { get; set; } = null!;

    public ulong UserId { get; set; }

    public DateTime? DeletedAt { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<BitacoraCuerpo> BitacoraCuerpos { get; set; } = new List<BitacoraCuerpo>();

    public virtual User User { get; set; } = null!;
}
