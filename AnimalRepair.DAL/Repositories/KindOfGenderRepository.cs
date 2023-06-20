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
    internal class KindOfGenderRepository : IRepository<KindOfGender>
    {
        private readonly DbA9ae8dDbanimalreContext _dbContext;

        public KindOfGenderRepository(DbA9ae8dDbanimalreContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Create(KindOfGender item)
        {
            _dbContext.KindOfGenders.Add(item);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = _dbContext.KindOfGenders.Find(id);
            if (item != null)
            {
                _dbContext.KindOfGenders.Remove(item);
                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<KindOfGender> Find(Func<KindOfGender, bool> predicate)
        {
            return _dbContext.KindOfGenders.Where(predicate).ToList();
        }

        public KindOfGender Get(int id)
        {
            var kindOfGender = _dbContext.KindOfGenders.Find(id);

            if (kindOfGender == null)
            {

            }

            return kindOfGender;
        }

        public IEnumerable<KindOfGender> GetAll()
        {
            return _dbContext.KindOfGenders.ToList();
        }

        public void Update(KindOfGender item)
        {
            _dbContext.KindOfGenders.Update(item);
            _dbContext.SaveChanges();
        }
    }
}
