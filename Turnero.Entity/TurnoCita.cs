using System;
using System.Collections.Generic;

namespace Turnero.Entity;

public partial class TurnoCita
{
    public int IdTurnoCita { get; set; }

    public string Descripcion { get; set; } = null!;

    public bool Activo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public DateTime FechaAtencion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();
}
