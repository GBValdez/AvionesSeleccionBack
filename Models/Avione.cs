using System;
using System.Collections.Generic;
using AvionesBackNet.utils;

namespace AvionesBackNet.Models;

public partial class Avione : CommonsModel<long>
{

    public string Year { get; set; } = null!;

    public string Serie { get; set; } = null!;

    public decimal CapacidadCarga { get; set; }

    public decimal CapacidadPasajeros { get; set; }

    public decimal CapacidadCombustible { get; set; }

    public decimal TamAsientoPorc { get; set; }

    public long MarcaId { get; set; }

    public long AerolineaId { get; set; }

    public long ModeloId { get; set; }

    public long TipoAvionId { get; set; }

    public long EstadoId { get; set; }
    public virtual Aerolinea Aerolinea { get; set; } = null!;

    public virtual Catalogo Estado { get; set; } = null!;

    public virtual Catalogo Marca { get; set; } = null!;

    public virtual Catalogo Modelo { get; set; } = null!;

    public virtual Catalogo TipoAvion { get; set; } = null!;

    public virtual ICollection<Vuelo> Vuelos { get; set; } = new List<Vuelo>();
    public virtual ICollection<Asiento> Asientos { get; set; } = new List<Asiento>();
}
