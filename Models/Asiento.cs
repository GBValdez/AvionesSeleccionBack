using System;
using System.Collections.Generic;
using project.utils;

namespace AvionesBackNet.Models;

public partial class Asiento : CommonsModel<long>
{

    public string Codigo { get; set; } = null!;

    public string Posicion { get; set; } = null!;

    public long ClaseId { get; set; }

    public long AvionId { get; set; }
    public ICollection<Boleto> Boletos { get; set; } = new List<Boleto>();

    public Catalogo Clase { get; set; } = null!;
    public Avione Avion { get; set; } = null!;
}
