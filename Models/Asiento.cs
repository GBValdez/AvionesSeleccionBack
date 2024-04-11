using System;
using System.Collections.Generic;

namespace AvionesBackNet.Models;

public partial class Asiento
{
    public ulong Id { get; set; }

    public string Codigo { get; set; } = null!;

    public string Posicion { get; set; } = null!;

    public ulong ClaseId { get; set; }

    public ulong AvionId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<Boleto> Boletos { get; set; } = new List<Boleto>();

    public virtual Catalogo Clase { get; set; } = null!;
}
