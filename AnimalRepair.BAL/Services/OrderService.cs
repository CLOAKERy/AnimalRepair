using AnimalRepair.BLL.DTO;
using AnimalRepair.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalRepair.BLL.Services
{
    internal class OrderService : IOrderService
    {
        public Task CreateOrder(OrderDTO orderDto)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<AnimalDTO> GetAnimalById(int animalId)
        {
            throw new NotImplementedException();
        }

        public Task<AnimalDTO> GetAnimalByIdCustomer(int customerId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderDTO>> GetOrdersByStatus(string status)
        {
            throw new NotImplementedException();
        }

        public Task RemoveOrder(int animalId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateOrder(OrderDTO orderDto)
        {
            throw new NotImplementedException();
        }
    }
}
