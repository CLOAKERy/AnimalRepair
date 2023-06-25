using Animal_Repair;
using AnimalRepair.BLL.DTO;
using AnimalRepair.BLL.Infrastructure;
using AnimalRepair.BLL.Interfaces;
using AnimalRepair.DAL.Interfaces;
using AnimalRepair.DAL.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalRepair.BLL.Services
{
    internal class UserRoleService : IUserRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserRoleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task AddUserRole(UserRoleDTO userRoleDto)
        {
            // Валидация данных 
            if (string.IsNullOrEmpty(userRoleDto.Role.ToString()))
                throw new ValidationException("Роль не может быть пустым", "");

            // Маппинг 
            var user = _mapper.Map<UserRoleDTO, UserRole>(userRoleDto);

            // Пример сохранения в базу данных с использованием UnitOfWork
            await _unitOfWork.UserRoles.CreateAsync(user);
            _unitOfWork.Save();
        }

        public async Task DeleteUserRole(int UserRoleId)
        {
            UserRole userRole = await _unitOfWork.UserRoles.GetAsync(UserRoleId);
            if (userRole == null)
                throw new ValidationException("Роль не найдена", "");

            await _unitOfWork.UserRoles.DeleteAsync(UserRoleId);
            _unitOfWork.Save();
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public async Task<IEnumerable<UserRoleDTO>> GetAllUserRoles()
        {
            // Получение списка ролей
            IEnumerable<UserRole> userRole = await _unitOfWork.UserRoles.GetAllAsync();
            return _mapper.Map<IEnumerable<UserRole>, IEnumerable<UserRoleDTO>>(userRole);
        }

        public async Task<UserRoleDTO> GetUserRole(int userRoleId)
        {
            // Поиск животного по идентификатору
            UserRole userRole = await _unitOfWork.UserRoles.GetAsync(userRoleId);
            if (userRole == null)
                throw new ValidationException("Роль не найдена", "");

            UserRoleDTO userRoleDTO = _mapper.Map<UserRole, UserRoleDTO>(userRole);

            return userRoleDTO;
        }

        public async Task UpdateUserRole(UserRoleDTO UserRoleDto)
        {
            // Поиск животного по идентификатору
            UserRole userRole = await _unitOfWork.UserRoles.GetAsync(UserRoleDto.Id);
            if (userRole == null)
                throw new ValidationException("Животное не найдено", "");

            // Обновление данных животного
            userRole.Role = UserRoleDto.Role;

            // Маппинг AnimalDTO в Animal
            UserRole updatedUserRole = _mapper.Map<UserRoleDTO, UserRole>(UserRoleDto);

            // Обновление животного в базе данных
            await _unitOfWork.UserRoles.UpdateAsync(updatedUserRole);
            _unitOfWork.Save();
        }
    }
}
