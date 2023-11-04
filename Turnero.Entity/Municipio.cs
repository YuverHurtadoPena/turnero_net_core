using System;
using System.Collections.Generic;

namespace Turnero.Entity;

public partial class Municipio
{
    public int IdMunicipio { get; set; }

    public string? Descripcion { get; set; }

    public int? IdDeprtamento { get; set; }

    public virtual Departamento? IdDeprtamentoNavigation { get; set; }

    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
}
