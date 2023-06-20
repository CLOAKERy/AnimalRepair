using Animal_Repair;
using AnimalRepair.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalRepair.DAL.Repositories
{
    internal class UserRoleRepository : IRepository<UserRole>
    {
        private readonly DbA9ae8dDbanimalreContext _dbContext;
        public UserRoleRepository(DbA9ae8dDbanimalreContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Create(UserRole item)
        {
            _dbContext.UserRoles.Add(item);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = _dbContext.UserRoles.Find(id);
            if (item != null)
            {
                _dbContext.UserRoles.Remove(item);
                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<UserRole> Find(Func<UserRole, bool> predicate)
        {
            return _dbContext.UserRoles.Where(predicate).ToList();
        }

        public UserRole Get(int id)
        {
            var userRole = _dbContext.UserRoles.Find(id);

            if (userRole == null)
            {

            }

            return userRole;
        }

        public IEnumerable<UserRole> GetAll()
        {
            return _dbContext.UserRoles.ToList();
        }

        public void Update(UserRole item)
        {
            _dbContext.UserRoles.Update(item);
            _dbContext.SaveChanges();
        }
    }
}
