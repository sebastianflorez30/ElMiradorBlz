using System;
using System.Collections.Generic;

namespace ElMirador.Modelo;

public partial class Asamblea
{
    public int Id { get; set; }

    public DateTime Fecha { get; set; }

    public TimeSpan Hora { get; set; }

    public string Lugar { get; set; } = null!;

    public string Agenda { get; set; } = null!;

    public virtual ICollection<Acta> Acta { get; set; } = new List<Acta>();

    public virtual ICollection<Voto> Votos { get; set; } = new List<Voto>();
}
