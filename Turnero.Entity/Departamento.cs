﻿using System;
using System.Collections.Generic;

namespace Turnero.Entity;

public partial class Departamento
{
    public int IdDepartamento { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Municipio> Municipios { get; set; } = new List<Municipio>();
}
