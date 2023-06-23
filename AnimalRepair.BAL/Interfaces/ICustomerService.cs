using AnimalRepair.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalRepair.BLL.Interfaces
{
    public interface ICustomerService
    {
        void RegisterUser(CustomerDTO userDto);
        bool IsUsernameUnique(string username);
        CustomerDTO GetUserByUsername(string username);
        void Dispose();
    }
}
