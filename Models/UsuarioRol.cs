using System;
using System.Collections.Generic;
using AvionesBackNet.utils;

namespace AvionesBackNet.Models;

public partial class UsuarioRol : CommonsModel<long>
{

    public long UserId { get; set; }

    public long RolId { get; set; }

    public virtual Role Rol { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
