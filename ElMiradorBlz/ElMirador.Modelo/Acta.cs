using System;
using System.Collections.Generic;

namespace ElMirador.Modelo;

public partial class Acta
{
    public int Id { get; set; }

    public int IdAsamblea { get; set; }

    public string Tema { get; set; } = null!;

    public string Votaciones { get; set; } = null!;

    public virtual Asamblea IdAsambleaNavigation { get; set; } = null!;
}
