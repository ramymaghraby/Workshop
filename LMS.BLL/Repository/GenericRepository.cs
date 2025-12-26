using LMS.DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace LMS.BLL.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, new()
    {
        ApplicationContext _db;
        IQueryable<T> _dbSet;
        public GenericRepository() { 
            _db = new ApplicationContext();
            _dbSet = _db.Set<T>().AsQueryable();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null)
        {
            if (filter != null)
            {
                return await Task.FromResult(_db.Set<T>().AsQueryable().Where(filter));
            }
            return await Task.FromResult(_db.Set<T>().AsQueryable());
        }
        public async Task<T> GetByAsync(Expression<Func<T, bool>> filter)
        {
            var entity = await Task.FromResult(_db.Set<T>().AsQueryable().FirstOrDefault(filter));
            return entity!;
        }
        public async Task<T> CreateAsync(T entity)
        {
            await _db.Set<T>().AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
        public async Task<T> UpdateAsync(T entity)
        {
            _db.Set<T>().Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
        
    }

    public interface IGenericRepository<T> where T : class, new()
    {
        // Get All
        public Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null);
        // Get By Id or Condition
        public Task<T> GetByAsync(Expression<Func<T,bool>> filter);
        // Create
        public Task<T> CreateAsync(T entity);
        // Update
        public Task<T> UpdateAsync(T entity);
    }
}
