using ElMirador.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElMirador.Repositorio.Contrato
{
    public interface INotificarRepositorio : IGenericoRepositorio<Asamblea>
    {
        Task<Asamblea> Notificar(Asamblea modelo);
    }
}
