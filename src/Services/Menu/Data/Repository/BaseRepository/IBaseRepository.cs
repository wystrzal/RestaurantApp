using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Menu.Data.Repository.BaseRepository
{
    public interface IBaseRepository<T> where T : class
    {
        void Add(T entity);
        void Delete(T entity); 
        Task<bool> SaveAll();
        Task<List<T>> GetByCondition(Func<T, bool> func);
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
    }
}
