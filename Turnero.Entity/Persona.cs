using System;
using System.Collections.Generic;

namespace Turnero.Entity;

public partial class Persona
{
    public int IdPersona { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string NroDocumentos { get; set; } = null!;

    public string NroCelular { get; set; } = null!;

    public bool Activo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public int? IdMunicipio { get; set; }

    public int? IdTipoDocumento { get; set; }

    public virtual ICollection<AtendidoPor> AtendidoPors { get; set; } = new List<AtendidoPor>();

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();

    public virtual Municipio? IdMunicipioNavigation { get; set; }

    public virtual TipoDocumento? IdTipoDocumentoNavigation { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
