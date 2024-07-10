using System;
using System.Collections.Generic;
using project.utils;

namespace AvionesBackNet.Models;

public partial class Vuelo : CommonsModel<long>
{
    public string Codigo { get; set; } = null!;

    public DateTime FechaSalida { get; set; }

    public DateTime FechaLlegada { get; set; }

    public long AvionId { get; set; }

    public long AeropuertoOrigenId { get; set; }

    public long AeropuertoDestinoId { get; set; }

    public Aeropuerto AeropuertoDestino { get; set; } = null!;

    public Aeropuerto AeropuertoOrigen { get; set; } = null!;

    public Avione Avion { get; set; } = null!;

    public ICollection<Boleto> Boletos { get; set; } = new List<Boleto>();

    public ICollection<VueloClase> VueloClases { get; set; } = new List<VueloClase>();
}
