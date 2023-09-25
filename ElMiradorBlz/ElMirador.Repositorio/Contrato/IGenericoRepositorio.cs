using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ElMirador.Repositorio.Contrato
{
    public interface IGenericoRepositorio<TModelo> where TModelo : class//Metodos para aplicar a todas las clases
    {
        IQueryable<TModelo> Consultar(Expression<Func<TModelo, bool>>? filtro = null); //permite aplicar filtro

        Task<TModelo> Crear(TModelo modelo); //Metodo crear, recibiendo el modelo segun lo que se desea

        Task<bool> Editar(TModelo modelo); //Metodo editar, recibiendo el modelo segun lo que se desea

        Task<bool> Eliminar(TModelo modelo); //Metodo borrar, recibiendo el modelo segun lo que se desea

    }
}
