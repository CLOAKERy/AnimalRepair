using AnimalRepair.BLL.DTO;
using AnimalRepair.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalRepair.BLL.Services
{
    internal class OrderProductService : IOrderProductService
    {
        public Task CreateOrderProduct(OrderProductDTO orderProductDto)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<AnimalDTO> GetOrderProductByIdOrder(int orderId)
        {
            throw new NotImplementedException();
        }

        public Task<AnimalDTO> GetOrderProductByIdProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveOrderProduct(int orderProductId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateOrderProduct(OrderProductDTO orderProductDto)
        {
            throw new NotImplementedException();
        }
    }
}
