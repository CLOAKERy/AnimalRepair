using AnimalRepair.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalRepair.BLL.Interfaces
{
    internal interface IOrderProductService : IDisposable
    {
        Task CreateOrderProduct(OrderProductDTO orderProductDto);
        Task UpdateOrderProduct(OrderProductDTO orderProductDto);
        Task RemoveOrderProduct(int orderProductId);
        Task<AnimalDTO> GetOrderProductByIdOrder(int orderId);
        Task<AnimalDTO> GetOrderProductByIdProduct(int productId);
    }
}
