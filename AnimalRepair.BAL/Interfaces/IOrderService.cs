using AnimalRepair.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalRepair.BLL.Interfaces
{
    internal interface IOrderService : IDisposable
    {
        Task CreateOrder(OrderDTO orderDto);
        Task UpdateOrder(OrderDTO orderDto);
        Task RemoveOrder(int animalId);
        Task<AnimalDTO> GetAnimalById(int animalId);
        Task<AnimalDTO> GetAnimalByIdCustomer(int customerId);
        Task<IEnumerable<OrderDTO>> GetOrdersByStatus(string status);
    }
}
