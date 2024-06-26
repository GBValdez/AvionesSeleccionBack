﻿using System;
using System.Collections.Generic;
using AvionesBackNet.utils;

namespace AvionesBackNet.Models;

public partial class BitacoraCuerpo : CommonsModel<long>
{
    public string Campo { get; set; } = null!;

    public string ValorAnterior { get; set; } = null!;

    public string ValorNuevo { get; set; } = null!;

    public long BitacoraEncabezadoId { get; set; }
    public virtual BitacoraEncabezado BitacoraEncabezado { get; set; } = null!;
}
