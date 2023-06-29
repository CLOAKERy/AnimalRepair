using Animal_Repair;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AnimalRepair.DAL.Interfaces
{
    public interface IProductRepository<Product> : IRepository<Product> where Product : class
    {
        Task<IEnumerable<Product>> GetAllAsync(params Expression<Func<Product, object>>[] includes);
        Task<IEnumerable<Product>> GetProductsByCategoryAsync(int idKindOfProduct);
        Task<Product> GetAsync(int id, params Expression<Func<Product, object>>[] includes);
    }
}
