using App.Api.Datos.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Api.Datos.Repositorio
{
    public class RepositorioGenerico<T>: IRepositorioGenerico<T> where T: class
    {
        private AppDbContext _dbContext;
        public RepositorioGenerico(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> Add(T t)
        {
            _dbContext.Entry(t).State = EntityState.Added;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            return t;
        }

        public async Task<bool> Delete(string id)
        {
            var t = await _dbContext.Set<T>().FindAsync(id);

            _dbContext.Entry(t).State = EntityState.Deleted;
            try
            {
                return await _dbContext.SaveChangesAsync() > 0 ? true : false;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<T> Find(string id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> Get()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<bool> Update(T t)
        {
            _dbContext.Set<T>().Attach(t);
            _dbContext.Entry(t).State = EntityState.Modified;
            try
            {
                return await _dbContext.SaveChangesAsync() > 0 ? true : false;
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
