using System;
using System.Collections.Generic;

namespace Turnero.Entity;

public partial class EstadoCitas
{
    public int IdEstadoCita { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();
}
