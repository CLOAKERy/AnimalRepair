using Animal_Repair;
using AnimalRepair.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalRepair.DAL.Repositories
{
    internal class LoginRepository : IRepository<Login>
    {
        private readonly DbA9ae8dDbanimalreContext _dbContext;
        public LoginRepository(DbA9ae8dDbanimalreContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Create(Login item)
        {
            _dbContext.Logins.Add(item);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = _dbContext.Logins.Find(id);
            if (item != null)
            {
                _dbContext.Logins.Remove(item);
                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<Login> Find(Func<Login, bool> predicate)
        {
            return _dbContext.Logins.Where(predicate).ToList();
        }

        public Login Get(int id)
        {
            var login = _dbContext.Logins.Find(id);

            if (login == null)
            {

            }

            return login;
        }

        public IEnumerable<Login> GetAll()
        {
            return _dbContext.Logins.ToList();
        }

        public void Update(Login item)
        {
            _dbContext.Logins.Update(item);
            _dbContext.SaveChanges();
        }
    }
}
