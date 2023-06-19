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
    internal class CustomerRepository : IRepository<Customer>
    {
        private readonly DbA9ae8dDbanimalreContext _dbContext;

        public CustomerRepository(DbA9ae8dDbanimalreContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Create(Customer item)
        {
            _dbContext.Customers.Add(item);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = _dbContext.Customers.Find(id);
            if (item != null)
            {
                _dbContext.Customers.Remove(item);
                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<Customer> Find(Func<Customer, bool> predicate)
        {
            return _dbContext.Customers.Where(predicate).ToList();
        }

        public Customer Get(int id)
        {
            var customer = _dbContext.Customers.Find(id);

            if (customer == null)
            {

            }

            return customer;
        }

        public IEnumerable<Customer> GetAll()
        {
            return _dbContext.Customers.ToList();
        }

        public void Update(Customer item)
        {
            _dbContext.Customers.Update(item);
            _dbContext.SaveChanges();
        }
    }
}
