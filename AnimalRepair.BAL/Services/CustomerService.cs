using AnimalRepair.BLL.DTO;
using AnimalRepair.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalRepair.BLL.Services
{
    public class CustomerService : ICustomerService
    {
        public Task<CustomerDTO> Authenticate(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUser(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<CustomerDTO> GetUserProfile(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CustomerDTO>> GetUsers()
        {
            throw new NotImplementedException();
        }

        public Task RegisterCustomer(CustomerDTO customerDto)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserProfile(CustomerDTO customerDto)
        {
            throw new NotImplementedException();
        }
    }
}
