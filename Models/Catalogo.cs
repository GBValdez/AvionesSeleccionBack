using System;
using System.Collections.Generic;
using project.utils;

namespace AvionesBackNet.Models;

public partial class Catalogo : CommonsModel<long>
{
    public string name { get; set; } = null!;
    public string? description { get; set; }
    public long CatalogoTipoId { get; set; }
    public virtual CatalogoTipo CatalogoTipo { get; set; } = null!;


}
