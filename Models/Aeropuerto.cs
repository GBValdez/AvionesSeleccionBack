using System;
using System.Collections.Generic;

namespace AvionesBackNet.Models;

public partial class Aeropuerto
{
    public ulong Id { get; set; }

    public string Iata { get; set; } = null!;

    public string Oaci { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Ciudad { get; set; } = null!;

    public string Localidad { get; set; } = null!;

    public string ZonaHoraria { get; set; } = null!;

    public string? Latitud { get; set; }

    public string? Longitud { get; set; }

    public string Telefono { get; set; } = null!;

    public string Email { get; set; } = null!;

    public bool? Activo { get; set; }

    public bool? Interno { get; set; }

    public ulong PaisId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<AerolineaAeropuerto> AerolineaAeropuertos { get; set; } = new List<AerolineaAeropuerto>();

    public virtual Catalogo Pais { get; set; } = null!;

    public virtual ICollection<Vuelo> VueloAeropuertoDestinos { get; set; } = new List<Vuelo>();

    public virtual ICollection<Vuelo> VueloAeropuertoOrigens { get; set; } = new List<Vuelo>();
}
