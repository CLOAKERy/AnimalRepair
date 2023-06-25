using AnimalRepair.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalRepair.BLL.Interfaces
{
    internal interface ILoginService : IDisposable
    {
        Task AddLogin(LoginDTO loginDto);
        Task<LoginDTO> GetLogin(int loginId);
        Task<IEnumerable<LoginDTO>> GetAllLogins();
        Task UpdateLogin(LoginDTO loginDto);
        Task DeleteLogin(int loginId);
    }
}
