using Animal_Repair;
using AnimalRepair.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace OrderRepair.DAL.Repositories
{
    internal class OrderRepository : IRepository<Order>
    {
        private readonly DbA9ae8dDbanimalreContext _dbContext;

        public OrderRepository(DbA9ae8dDbanimalreContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(Order item)
        {
            _dbContext.Orders.Add(item);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = _dbContext.Orders.Find(id);
            if (item != null)
            {
                _dbContext.Orders.Remove(item);
                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<Order> Find(Func<Order, bool> predicate)
        {
            return _dbContext.Orders.Where(predicate).ToList();
        }

        public Order Get(int id)
        {
            var order = _dbContext.Orders.Find(id);

            if (order == null)
            {

            }

            return order;
        }

        public IEnumerable<Order> GetAll()
        {
            return _dbContext.Orders.ToList();
        }

        public void Update(Order item)
        {
            _dbContext.Orders.Update(item);
            _dbContext.SaveChanges();
        }
    }
}
