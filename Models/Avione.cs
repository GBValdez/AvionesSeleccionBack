using System;
using System.Collections.Generic;

namespace AvionesBackNet.Models;

public partial class Avione
{
    public ulong Id { get; set; }

    public DateOnly FechaEnsamble { get; set; }

    public string Serie { get; set; } = null!;

    public decimal CapacidadCarga { get; set; }

    public decimal CapacidadPasajeros { get; set; }

    public decimal CapacidadCombustible { get; set; }

    public decimal TamAsientoPorc { get; set; }

    public ulong MarcaId { get; set; }

    public ulong AerolineaId { get; set; }

    public ulong ModeloId { get; set; }

    public ulong TipoId { get; set; }

    public ulong EstadoId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual Aerolinea Aerolinea { get; set; } = null!;

    public virtual Catalogo Estado { get; set; } = null!;

    public virtual Catalogo Marca { get; set; } = null!;

    public virtual Catalogo Modelo { get; set; } = null!;

    public virtual Catalogo Tipo { get; set; } = null!;

    public virtual ICollection<Vuelo> Vuelos { get; set; } = new List<Vuelo>();
}
