using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using project.utils;

namespace AvionesBackNet.Models;

public partial class Avione : CommonsModel<long>
{
    public string Codigo { get; set; } = null!;

    public string Year { get; set; } = null!;

    public string Serie { get; set; } = null!;

    public decimal CapacidadCarga { get; set; }

    public decimal CapacidadPasajeros { get; set; }

    public decimal CapacidadCombustible { get; set; }

    public decimal TamAsientoPorc { get; set; } = 10;

    public long MarcaId { get; set; }

    public long AerolineaId { get; set; }

    public long ModeloId { get; set; }

    public long TipoAvionId { get; set; }

    public long EstadoId { get; set; }
    public Aerolinea Aerolinea { get; set; } = null!;

    public Catalogo Estado { get; set; } = null!;

    public Catalogo Marca { get; set; } = null!;

    public Catalogo Modelo { get; set; } = null!;

    public Catalogo TipoAvion { get; set; } = null!;

    [JsonIgnore]

    public ICollection<Vuelo> Vuelos { get; set; } = new List<Vuelo>();
    [JsonIgnore]

    public ICollection<Asiento> Asientos { get; set; } = new List<Asiento>();
    [JsonIgnore]
    public ICollection<Tripulacione> Tripulaciones { get; set; } = new List<Tripulacione>();
}
