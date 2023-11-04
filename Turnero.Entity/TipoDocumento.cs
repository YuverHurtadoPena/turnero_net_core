using System;
using System.Collections.Generic;

namespace Turnero.Entity;

public partial class TipoDocumento
{
    public int IdTipoDocumento { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
}
