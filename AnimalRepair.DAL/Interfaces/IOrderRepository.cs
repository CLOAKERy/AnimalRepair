using Animal_Repair;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalRepair.DAL.Interfaces
{
    public interface IOrderRepository<Order> : IRepository<Order> where Order : class
    {
        Task<IEnumerable<Order>> GetOrdersByCustomerId(int customerId);

        Task<IEnumerable<Order>> GetOrdersByStatus(string status);
    }
}
