using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalRepair.DAL.Interfaces
{
    public interface ICustomerRepository<Customer> : IRepository<Customer> where Customer : class
    {
        public Task<Customer> GetByLoginIdAsync(int idLogin);
    }
}
