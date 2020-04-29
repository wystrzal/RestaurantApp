using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Menu.Data.Repository.BaseRepository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DataContext dataContext;

        public BaseRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public void Add(T entity)
        {
            dataContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            dataContext.Set<T>().Remove(entity);
        }

        public async Task<List<T>> GetAll()
        {
            return await dataContext.Set<T>().ToListAsync();
        }

        public async Task<List<T>> GetByCondition(Func<T, bool> func)
        {
            var data = dataContext.Set<T>().Where(func).AsQueryable().ToList();
            return await Task.FromResult(data);
 
        }

        public async Task<T> GetById(int id)
        {
            return await dataContext.Set<T>().FindAsync(id);
        }

        public async Task<bool> SaveAll()
        {
            return await dataContext.SaveChangesAsync() > 0 ? true : false;
        }
    }
}
