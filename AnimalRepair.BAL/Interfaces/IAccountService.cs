using AnimalRepair.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AnimalRepair.BLL.Interfaces
{
    public interface IAccountService
    {
        Task<ClaimsIdentity> Register(LoginDTO loginDTO);

        Task<ClaimsIdentity> Login(LoginDTO loginDTO);

        
    }
}
