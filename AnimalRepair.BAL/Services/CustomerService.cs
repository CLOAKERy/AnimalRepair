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
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool IsUsernameUnique(string username)
        {
            throw new NotImplementedException();
        }

        CustomerDTO ICustomerService.GetUserByUsername(string username)
        {
            throw new NotImplementedException();
        }

        void ICustomerService.RegisterUser(CustomerDTO userDto)
        {
            throw new NotImplementedException();
        }
    }
}
