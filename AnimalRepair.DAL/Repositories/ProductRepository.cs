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
    internal class ProductRepository : IRepository<Product>
    {
        private readonly DbA9ae8dDbanimalreContext _dbContext;

        public ProductRepository(DbA9ae8dDbanimalreContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Create(Product item)
        {
            _dbContext.Products.Add(item);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = _dbContext.Products.Find(id);
            if (item != null)
            {
                _dbContext.Products.Remove(item);
                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<Product> Find(Func<Product, bool> predicate)
        {
            return _dbContext.Products.Where(predicate).ToList();
        }

        public Product Get(int id)
        {
            var product = _dbContext.Products.Find(id);

            if (product == null)
            {

            }

            return product;
        }

        public IEnumerable<Product> GetAll()
        {
            return _dbContext.Products.ToList();
        }

        public void Update(Product item)
        {
            _dbContext.Products.Update(item);
            _dbContext.SaveChanges();
        }
    }
}
