using Animal_Repair;
using AnimalRepair.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalRepair.DAL.Repositories
{
    internal class KindOfAnimalRepository : IRepository<KindOfAnimal>
    {
        private readonly DbA9ae8dDbanimalreContext _dbContext;

        public KindOfAnimalRepository(DbA9ae8dDbanimalreContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Create(KindOfAnimal item)
        {
            _dbContext.KindOfAnimals.Add(item);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = _dbContext.KindOfAnimals.Find(id);
            if (item != null)
            {
                _dbContext.KindOfAnimals.Remove(item);
                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<KindOfAnimal> Find(Func<KindOfAnimal, bool> predicate)
        {
            return _dbContext.KindOfAnimals.Where(predicate).ToList();
        }

        public KindOfAnimal Get(int id)
        {
            var kindOfAnimal = _dbContext.KindOfAnimals.Find(id);

            if (kindOfAnimal == null)
            {

            }

            return kindOfAnimal;
        }

        public IEnumerable<KindOfAnimal> GetAll()
        {
            return _dbContext.KindOfAnimals.ToList();
        }

        public void Update(KindOfAnimal item)
        {
            _dbContext.KindOfAnimals.Update(item);
            _dbContext.SaveChanges();
        }
    }
}
