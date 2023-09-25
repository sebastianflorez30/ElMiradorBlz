using ElMirador.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElMirador.Repositorio.Contrato
{
    public interface IVotacionRepositorio : IGenericoRepositorio<Voto>
    {
        Task<Voto> Votar(Voto modelo);
    }
}
