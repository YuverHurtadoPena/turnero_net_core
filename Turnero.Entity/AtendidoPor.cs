using System;
using System.Collections.Generic;

namespace Turnero.Entity;

public partial class AtendidoPor
{
    public int IdAtendido { get; set; }

    public DateTime FechaCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public int? IdCita { get; set; }

    public int? IdPersona { get; set; }

    public virtual Cita? IdCitaNavigation { get; set; }

    public virtual Persona? IdPersonaNavigation { get; set; }
}
