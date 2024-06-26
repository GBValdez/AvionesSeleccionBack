﻿using System;
using System.Collections.Generic;
using AvionesBackNet.utils;

namespace AvionesBackNet.Models;

public partial class Empleado : CommonsModel<long>
{
    public string Nombre { get; set; } = null!;

    public DateOnly FechaNacimiento { get; set; }

    public string Correo { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public long PaisId { get; set; }

    public long PuestoId { get; set; }

    public long TripulacionId { get; set; }

    public long AerolineaId { get; set; }

    public long UserId { get; set; }
    public virtual Aerolinea Aerolinea { get; set; } = null!;

    public virtual Paise Pais { get; set; } = null!;

    public virtual Catalogo Puesto { get; set; } = null!;

    public virtual Tripulacione Tripulacion { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
