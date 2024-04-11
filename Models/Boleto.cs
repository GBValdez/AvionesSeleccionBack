using System;
using System.Collections.Generic;

namespace AvionesBackNet.Models;

public partial class Boleto
{
    public ulong Id { get; set; }

    public int CantidadMaletasAdquiridas { get; set; }

    public int CantidadMaletasPresentadas { get; set; }

    public ulong EstadoBoletoId { get; set; }

    public ulong VueloId { get; set; }

    public ulong AsientoId { get; set; }

    public ulong ClienteId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Asiento Asiento { get; set; } = null!;

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual Catalogo EstadoBoleto { get; set; } = null!;

    public virtual Vuelo Vuelo { get; set; } = null!;
}
