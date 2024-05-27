using System;
using System.Collections.Generic;
using AvionesBackNet.utils;

namespace AvionesBackNet.Models;

public partial class Asiento : CommonsModel<long>
{

    public string Codigo { get; set; } = null!;

    public string Posicion { get; set; } = null!;

    public long ClaseId { get; set; }

    public long AvionId { get; set; }
    public virtual ICollection<Boleto> Boletos { get; set; } = new List<Boleto>();

    public virtual Catalogo Clase { get; set; } = null!;
    public virtual Avione Avion { get; set; } = null!;
}
