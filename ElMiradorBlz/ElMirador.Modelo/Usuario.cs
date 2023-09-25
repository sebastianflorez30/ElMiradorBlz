using System;
using System.Collections.Generic;

namespace ElMirador.Modelo;

public partial class Usuario
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string CorreoElectronico { get; set; } = null!;

    public string NumeroIdentificacion { get; set; } = null!;

    public virtual ICollection<Voto> Votos { get; set; } = new List<Voto>();
}
