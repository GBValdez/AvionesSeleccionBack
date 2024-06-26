﻿using System;
using System.Collections.Generic;
using AvionesBackNet.utils;

namespace AvionesBackNet.Models;

public partial class Paise : CommonsModel<long>
{
    public string Nombre { get; set; } = null!;

    public string PhoneCode { get; set; } = null!;

    public string Iso3166 { get; set; } = null!;

    public string Iso4217 { get; set; } = null!;
    public virtual ICollection<Aerolinea> Aerolineas { get; set; } = new List<Aerolinea>();

    public virtual ICollection<Aeropuerto> Aeropuertos { get; set; } = new List<Aeropuerto>();

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
