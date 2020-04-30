using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Menu.Data.Repository
{
    public abstract class BaseRepository : IBaseRepository
    {
        private readonly DataContext dataContext;

        public BaseRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public void Add<T>(T entity) where T : class
        {
            dataContext.Set<T>().Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            dataContext.Set<T>().Remove(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            dataContext.Set<T>().Update(entity);
        }

        public async Task<List<T>> GetAll<T>() where T : class
        {
            return await dataContext.Set<T>().ToListAsync();
        }

        public async Task<List<T>> GetByCondition<T>(Func<T, bool> func) where T : class
        {
            var data = dataContext.Set<T>().Where(func).AsQueryable().ToList();
            return await Task.FromResult(data);
 
        }

        public async Task<T> GetById<T>(int id) where T : class
        {
            return await dataContext.Set<T>().FindAsync(id);
        }

        public async Task<bool> SaveAll()
        {
            return await dataContext.SaveChangesAsync() > 0 ? true : false;
        }
    }
}
