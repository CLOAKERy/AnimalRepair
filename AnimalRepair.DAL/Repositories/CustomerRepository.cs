using Animal_Repair;
using AnimalRepair.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalRepair.DAL.Repositories
{
    internal class CustomerRepository : BaseRepository<Customer>, ICustomerRepository<Customer>
    {
        public CustomerRepository(DbContext dbContext) : base(dbContext)
        {
        }
        public async Task<Customer> GetByLoginIdAsync(int idLogin)
        {
            var customers = await FindAsync(c => c.IdLogin == idLogin);
            return customers.FirstOrDefault();
        }
    }
}
