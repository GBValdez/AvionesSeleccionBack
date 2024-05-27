using System;
using System.Collections.Generic;
using AvionesBackNet.utils;

namespace AvionesBackNet.Models;

public partial class Role : CommonsModel<long>
{
    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;
    public virtual ICollection<UsuarioRol> UsuarioRols { get; set; } = new List<UsuarioRol>();
}
