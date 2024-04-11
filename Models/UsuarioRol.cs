using System;
using System.Collections.Generic;

namespace AvionesBackNet.Models;

public partial class UsuarioRol
{
    public ulong Id { get; set; }

    public ulong UserId { get; set; }

    public ulong RolId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Role Rol { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
