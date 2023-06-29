using Animal_Repair;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalRepair.DAL.Interfaces
{
    public interface IOrderProductRepository<OrderProduct> : IRepository<OrderProduct> where OrderProduct : class
    {
        Task<IEnumerable<OrderProduct>> GetOrderProductByIdOrder(int orderId);
        Task<IEnumerable<OrderProduct>> GetOrderProductByIdProduct(int productId);
        Task SaveOrderWithProducts(Order order, List<Product> products);
    }
}
