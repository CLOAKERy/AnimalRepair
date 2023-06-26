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
        Task RemoveOrder(int orderId);
        Task<OrderDTO> GetOrderById(int orderId);
        Task<IEnumerable<OrderDTO>> GetOrderByIdCustomer(int customerId);
        Task<IEnumerable<OrderDTO>> GetOrdersByStatus(string status);
    }
}
