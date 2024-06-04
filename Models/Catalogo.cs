using System;
using System.Collections.Generic;
using project.utils;

namespace AvionesBackNet.Models;

public partial class Catalogo : CommonsModel<long>
{
    public string Nombre { get; set; } = null!;
    public string? Descripcion { get; set; }
    public long CatalogoTipoId { get; set; }
    public virtual CatalogoTipo CatalogoTipo { get; set; } = null!;


}
