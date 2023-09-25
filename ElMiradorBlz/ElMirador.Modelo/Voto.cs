using System;
using System.Collections.Generic;

namespace ElMirador.Modelo;

public partial class Voto
{
    public int Id { get; set; }

    public int IdAsamblea { get; set; }

    public int IdUsuario { get; set; }

    public string VotoEmitido { get; set; } = null!;

    public virtual Asamblea IdAsambleaNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
