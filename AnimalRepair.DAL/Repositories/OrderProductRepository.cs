using Animal_Repair;
using AnimalRepair.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace OrderProductRepair.DAL.Repositories
{
    internal class OrderProductRepository : IRepository<OrderProduct>
    {
        private readonly DbA9ae8dDbanimalreContext _dbContext;

        public OrderProductRepository(DbA9ae8dDbanimalreContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(OrderProduct item)
        {
            _dbContext.OrderProducts.Add(item);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = _dbContext.OrderProducts.Find(id);
            if (item != null)
            {
                _dbContext.OrderProducts.Remove(item);
                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<OrderProduct> Find(Func<OrderProduct, bool> predicate)
        {
            return _dbContext.OrderProducts.Where(predicate).ToList();
        }

        public OrderProduct Get(int id)
        {
            var orderProduct = _dbContext.OrderProducts.Find(id);

            if (orderProduct == null)
            {

            }

            return orderProduct;
        }

        public IEnumerable<OrderProduct> GetAll()
        {
            return _dbContext.OrderProducts.ToList();
        }

        public void Update(OrderProduct item)
        {
            _dbContext.OrderProducts.Update(item);
            _dbContext.SaveChanges();
        }
    }
}
