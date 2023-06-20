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
    internal class AdminRepository : IRepository<Admin>
    {
        private readonly DbA9ae8dDbanimalreContext _dbContext;
        public AdminRepository(DbA9ae8dDbanimalreContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Create(Admin item)
        {
            _dbContext.Admins.Add(item);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = _dbContext.Admins.Find(id);
            if (item != null)
            {
                _dbContext.Admins.Remove(item);
                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<Admin> Find(Func<Admin, bool> predicate)
        {
            return _dbContext.Admins.Where(predicate).ToList();
        }

        public Admin Get(int id)
        {
            var admin = _dbContext.Admins.Find(id);

            if (admin == null)
            {

            }

            return admin;
        }

        public IEnumerable<Admin> GetAll()
        {
            return _dbContext.Admins.ToList();
        }

        public void Update(Admin item)
        {
            _dbContext.Admins.Update(item);
            _dbContext.SaveChanges();
        }
    }
}
