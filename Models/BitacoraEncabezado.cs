using System;
using System.Collections.Generic;
using AvionesBackNet.utils;

namespace AvionesBackNet.Models;

public partial class BitacoraEncabezado : CommonsModel<long>
{
    public string Tabla { get; set; } = null!;

    public string IdRegistro { get; set; } = null!;

    public string TipoTransaccion { get; set; } = null!;

    public long UserId { get; set; }
    public virtual ICollection<BitacoraCuerpo> BitacoraCuerpos { get; set; } = new List<BitacoraCuerpo>();

    public virtual User User { get; set; } = null!;
}
