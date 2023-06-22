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

namespace OrderProductRepair.DAL.Repositories
{
    internal class OrderProductRepository : BaseRepository<OrderProduct>
    {
        public OrderProductRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
