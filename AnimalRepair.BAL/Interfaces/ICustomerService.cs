using AnimalRepair.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalRepair.BLL.Interfaces
{
    public interface ICustomerService : IDisposable
    {
            Task RegisterCustomer(CustomerDTO customerDto);
            Task<CustomerDTO> Authenticate(string username, string password);
            Task<CustomerDTO> GetUserProfile(int userId);
            Task<IEnumerable<CustomerDTO>> GetUsers();
            Task UpdateUserProfile(CustomerDTO customerDto);
            Task DeleteUser(int userId);
            Task<CustomerDTO> GetUserByLogin(int IdLogin);
    }
}
