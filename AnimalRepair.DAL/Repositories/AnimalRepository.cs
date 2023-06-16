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
        private DbA9ae8dDbanimalreContext db;
        public void Create(Animal item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Animal> Find(Func<Animal, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Animal Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Animal> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Animal item)
        {
            throw new NotImplementedException();
        }
    }
}
