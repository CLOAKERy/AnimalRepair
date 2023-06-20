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
    internal class KindOfProductRepository : IRepository<KindOfProduct>
    {
        private readonly DbA9ae8dDbanimalreContext _dbContext;

        public KindOfProductRepository(DbA9ae8dDbanimalreContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Create(KindOfProduct item)
        {
            _dbContext.KindOfProducts.Add(item);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = _dbContext.KindOfProducts.Find(id);
            if (item != null)
            {
                _dbContext.KindOfProducts.Remove(item);
                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<KindOfProduct> Find(Func<KindOfProduct, bool> predicate)
        {
            return _dbContext.KindOfProducts.Where(predicate).ToList();
        }

        public KindOfProduct Get(int id)
        {
            var kindOfProduct = _dbContext.KindOfProducts.Find(id);

            if (kindOfProduct == null)
            {

            }

            return kindOfProduct;
        }

        public IEnumerable<KindOfProduct> GetAll()
        {
            return _dbContext.KindOfProducts.ToList();
        }

        public void Update(KindOfProduct item)
        {
            _dbContext.KindOfProducts.Update(item);
            _dbContext.SaveChanges();
        }
    }
}
