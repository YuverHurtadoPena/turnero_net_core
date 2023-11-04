using System;
using System.Collections.Generic;

namespace Turnero.Entity;

public partial class Usuario
{
    public int UsuarioId { get; set; }

    public string Usuario1 { get; set; } = null!;

    public string Clave { get; set; } = null!;

    public int? RolId { get; set; }

    public bool Activo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public int? IdPersona { get; set; }

    public virtual Persona? IdPersonaNavigation { get; set; }

    public virtual Rol? Rol { get; set; }
}
