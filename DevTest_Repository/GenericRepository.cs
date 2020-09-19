using DevTest_Repository.Repos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using DevTest_Data.Models;
using System.Threading.Tasks;

namespace DevTest_Repository
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly TestModel _dbContext;
        private readonly DbSet _dbSet;
        public GenericRepository(TestModel context)
        {
            _dbContext = context;
            _dbSet = _dbContext.Set<T>();
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return (IEnumerable<T>) await _dbSet.ToListAsync();
        }

        public T GetbyId(int id)
        {
            return (T)_dbSet.Find(id);
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        
    }
}
