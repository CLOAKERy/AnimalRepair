using Animal_Repair;
using AnimalRepair.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AnimalRepair.DAL.Repositories
{
    internal class AnimalRepository : IRepository<Animal>
    {
        private readonly DbA9ae8dDbanimalreContext _dbContext;

        public AnimalRepository(DbA9ae8dDbanimalreContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(Animal item)
        {
            _dbContext.Animals.Add(item);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = _dbContext.Animals.Find(id);
            if (item != null)
            {
                _dbContext.Animals.Remove(item);
                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<Animal> Find(Func<Animal, bool> predicate)
        {
            return _dbContext.Animals.Where(predicate).ToList();
        }

        public Animal Get(int id)
        {
            var animal = _dbContext.Animals.Find(id);

            if (animal == null)
            {
                
            }

            return animal;
        }

        public IEnumerable<Animal> GetAll()
        {
            return _dbContext.Animals.ToList();
        }

        public void Update(Animal item)
        {
            _dbContext.Animals.Update(item);
            _dbContext.SaveChanges();
        }
    }
}
