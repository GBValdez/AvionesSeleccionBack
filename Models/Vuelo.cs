using System;
using System.Collections.Generic;

namespace AvionesBackNet.Models;

public partial class Vuelo
{
    public ulong Id { get; set; }

    public string Codigo { get; set; } = null!;

    public DateTime FechaSalida { get; set; }

    public DateTime FechaLlegada { get; set; }

    public ulong AvionId { get; set; }

    public ulong TripulacionId { get; set; }

    public ulong AeropuertoOrigenId { get; set; }

    public ulong AeropuertoDestinoId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Aeropuerto AeropuertoDestino { get; set; } = null!;

    public virtual Aeropuerto AeropuertoOrigen { get; set; } = null!;

    public virtual Avione Avion { get; set; } = null!;

    public virtual ICollection<Boleto> Boletos { get; set; } = new List<Boleto>();

    public virtual Tripulacione Tripulacion { get; set; } = null!;

    public virtual ICollection<VueloClase> VueloClases { get; set; } = new List<VueloClase>();
}
