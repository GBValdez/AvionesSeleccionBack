using System;
using System.Collections.Generic;
using AvionesBackNet.utils;

namespace AvionesBackNet.Models;

public partial class Vuelo : CommonsModel<long>
{

    public string Codigo { get; set; } = null!;

    public DateTime FechaSalida { get; set; }

    public DateTime FechaLlegada { get; set; }

    public long AvionId { get; set; }

    public long AeropuertoOrigenId { get; set; }

    public long AeropuertoDestinoId { get; set; }

    public virtual Aeropuerto AeropuertoDestino { get; set; } = null!;

    public virtual Aeropuerto AeropuertoOrigen { get; set; } = null!;

    public virtual Avione Avion { get; set; } = null!;

    public virtual ICollection<Boleto> Boletos { get; set; } = new List<Boleto>();

    public virtual ICollection<VueloClase> VueloClases { get; set; } = new List<VueloClase>();
}
