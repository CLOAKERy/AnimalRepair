using AnimalRepair.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalRepair.DAL.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext _dbContext;

        protected BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(T item)
        {
            _dbContext.Set<T>().Add(item);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = _dbContext.Set<T>().Find(id);
            if (item != null)
            {
                _dbContext.Set<T>().Remove(item);
                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return _dbContext.Set<T>().Where(predicate).ToList();
        }

        public T Get(int id)
        {
            var entity = _dbContext.Set<T>().Find(id);
            if (entity == null)
            {
                // Обработка случая, когда сущность не найдена
                throw new KeyNotFoundException($"Entity of type {typeof(T).Name} with ID {id} not found.");
            }
            return entity;
        }

        public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public void Update(T item)
        {
            _dbContext.Set<T>().Update(item);
            _dbContext.SaveChanges();
        }
    }
}
