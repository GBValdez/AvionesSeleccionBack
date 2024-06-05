using System;
using System.Collections.Generic;
using project.utils;

namespace AvionesBackNet.Models;

public partial class CatalogoTipo : CommonsModel<long>
{
    public string code { get; set; } = null!;

    public string name { get; set; } = null!;

    public string? description { get; set; }

    public virtual ICollection<Catalogo> Catalogos { get; set; } = new List<Catalogo>();
}
