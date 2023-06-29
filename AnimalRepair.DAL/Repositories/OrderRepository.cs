using Animal_Repair;
using AnimalRepair.DAL.Interfaces;
using AnimalRepair.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace OrderRepair.DAL.Repositories
{
    internal class OrderRepository : BaseRepository<Order>, IOrderRepository<Order>
    {
        public OrderRepository(DbContext dbContext) : base(dbContext)
        {
        }
        public async Task<Order> GetLastOrder()
        {
            return await _dbContext.Set<Order>()
                .OrderByDescending(o => o.Id)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersByCustomerId(int customerId)
        {
            return await _dbContext.Set<Order>()
                .Where(a => a.IdCustomer == customerId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersByStatus(string status)
        {
            return await _dbContext.Set<Order>()
                .Where(a => a.Status == status)
                .ToListAsync();
        }
    }
}
