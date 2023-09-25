using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using ElMirador.Repositorio.Contrato;
using ElMirador.Repositorio.DBContext;

namespace ElMirador.Repositorio.Implementacion
{
    public class GenericoRepositorio<TModelo> : IGenericoRepositorio<TModelo> where TModelo : class
    {
        private readonly ElMiradorDbContext _dbContext;

        public GenericoRepositorio(ElMiradorDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<TModelo> Consultar(Expression<Func<TModelo, bool>>? filtro = null)
        {
            IQueryable<TModelo> Consulta = (filtro == null) ? _dbContext.Set<TModelo>() : _dbContext.Set<TModelo>().Where(filtro);//trae informacion de la tabla y muestra opcion de filtro
            return Consulta;//retorna consulta
        }

        public async Task<TModelo> Crear(TModelo modelo)
        {
            try
            {
                _dbContext.Set<TModelo>().Add(modelo);//agregar segun el modelo
                await _dbContext.SaveChangesAsync();//sincronizar y guardar cambio
                return modelo;//retona modelo
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(TModelo modelo)
        {
            try
            {
                _dbContext.Set<TModelo>().Update(modelo);//edita segun el modelo
                await _dbContext.SaveChangesAsync();//sincronizar y guardar cambio
                return true;//retona verdadero
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(TModelo modelo)
        {
            try
            {
                _dbContext.Set<TModelo>().Remove(modelo);//elimina segun el modelo
                await _dbContext.SaveChangesAsync();//sincronizar y guardar cambio
                return true;//retona verdadero
            }
            catch
            {
                throw;
            }
        }
    }
}
