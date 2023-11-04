using System;
using System.Collections.Generic;

namespace Turnero.Entity;

public partial class Menu
{
    public int MenuId { get; set; }

    public string Titulo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public int? RolId { get; set; }

    public virtual Rol? Rol { get; set; }
}
