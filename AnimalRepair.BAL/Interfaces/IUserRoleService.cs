using AnimalRepair.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalRepair.BLL.Interfaces
{
    public interface IUserRoleService : IDisposable
    {
        Task AddUserRole(UserRoleDTO userRoleDto);
        Task<UserRoleDTO> GetUserRole(int userId);
        Task<IEnumerable<UserRoleDTO>> GetAllUserRoles();
        Task UpdateUserRole(UserRoleDTO UserRoleDto);
        Task DeleteUserRole(int UserRoleId);
    }
}
