using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turnero.DAL.DBContext;
using Turnero.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Turnero.DAL.Implementacion
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class

    {
        private readonly TurneroContext _dBContext;
        public GenericRepository(TurneroContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<TEntity> Obtener(Expression<Func<TEntity, bool>> filtro)
        {
            try
            {
                TEntity entidad = await _dBContext.Set<TEntity>().FirstOrDefaultAsync(filtro);
                return entidad;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<IQueryable<TEntity>> Consultar(Expression<Func<TEntity, bool>> filtro = null)
        {
            IQueryable<TEntity> queryTable = filtro == null ? _dBContext.Set<TEntity>() : _dBContext.Set<TEntity>().Where(filtro);
            return queryTable;
        }

        public async Task<TEntity> Crear(TEntity entidad)
        {
            try
            {
                _dBContext.Set<TEntity>().Add(entidad);
                await _dBContext.SaveChangesAsync();
                return entidad;
            }
            catch (Exception ex) { throw; }

        }

        public async Task<bool> Editar(TEntity entidad)
        {
            try
            {
                _dBContext.Set<TEntity>().Update(entidad);
                await _dBContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) { throw; }
        }

        public async Task<bool> Eliminar(TEntity entidad)
        {
            try
            {
                _dBContext.Set<TEntity>().Remove(entidad);
                await _dBContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) { throw; }
        }


    }
}
