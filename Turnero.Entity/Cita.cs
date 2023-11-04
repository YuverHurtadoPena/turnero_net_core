using System;
using System.Collections.Generic;

namespace Turnero.Entity;

public partial class Cita
{
    public int IdCita { get; set; }

    public DateTime FechaCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public int? IdEstadoCita { get; set; }

    public int? IdPersona { get; set; }

    public int? IdTurnoCita { get; set; }

    public virtual ICollection<AtendidoPor> AtendidoPors { get; set; } = new List<AtendidoPor>();

    public virtual EstadoCitas? IdEstadoCitaNavigation { get; set; }

    public virtual Persona? IdPersonaNavigation { get; set; }

    public virtual TurnoCita? IdTurnoCitaNavigation { get; set; }
}
