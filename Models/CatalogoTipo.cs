﻿using System;
using System.Collections.Generic;
using AvionesBackNet.utils;

namespace AvionesBackNet.Models;

public partial class CatalogoTipo : CommonsModel<ulong>
{
    public string Codigo { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;


    public virtual ICollection<Catalogo> Catalogos { get; set; } = new List<Catalogo>();
}
