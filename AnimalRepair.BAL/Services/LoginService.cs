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
    public class LoginService : ILoginService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly EFUnitOfWork _eFUnitOfWork;
        private readonly IMapper _mapper;
        public LoginService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task AddLogin(LoginDTO loginDto)
        {
            // Валидация данных 
            if (string.IsNullOrEmpty(loginDto.Login1.ToString()))
                throw new ValidationException("Логин не может быть пустым", "");
            if (string.IsNullOrEmpty(loginDto.Password.ToString()))
                throw new ValidationException("Пароль не может быть пустым", "");

            // Маппинг 
            var login = _mapper.Map<LoginDTO, Login>(loginDto);

            // Пример сохранения в базу данных с использованием UnitOfWork
            await _unitOfWork.Logins.CreateAsync(login);
            _unitOfWork.Save();
        }

        public async Task DeleteLogin(int loginId)
        {
            Login login = await _unitOfWork.Logins.GetAsync(loginId);
            if (login == null)
                throw new ValidationException("Логин и пароль не найдены", "");

            await _unitOfWork.Logins.DeleteAsync(loginId);
            _unitOfWork.Save();
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public async Task<IEnumerable<LoginDTO>> GetAllLogins()
        {
            // Получение списка ролей
            IEnumerable<Login> login = await _unitOfWork.Logins.GetAllAsync();
            return _mapper.Map<IEnumerable<Login>, IEnumerable<LoginDTO>>(login);
        }

        public async Task<LoginDTO> GetLogin(int loginId)
        {
            // Поиск логина и пароля по идентификатору
            Login login = await _unitOfWork.Logins.GetAsync(loginId);
            if (login == null)
                throw new ValidationException("Логин и пароль не найдены", "");

            LoginDTO loginDTO = _mapper.Map<Login, LoginDTO>(login);

            return loginDTO;
        }

        public async Task UpdateLogin(LoginDTO loginDto)
        {
            // Поиск логина и пароля по идентификатору
            Login login = await _unitOfWork.Logins.GetAsync(loginDto.Id);
            if (login == null)
                throw new ValidationException("Логин и пароль не найдены", "");

            // Обновление данных логина и пароля
            login.Login1 = loginDto.Login1;
            login.Password = loginDto.Password;

            // Маппинг 
            Login updatedLogin = _mapper.Map<LoginDTO, Login>(loginDto);

            // Обновление логина и пароля в базе данных
            await _unitOfWork.Logins.UpdateAsync(updatedLogin);
            _unitOfWork.Save();
        }
        public async Task<LoginDTO> GetLastLogin()
        {
            // Получение последнего логина из таблицы
            Login lastLogin = await _eFUnitOfWork.Logins.GetLastAsync();
            if (lastLogin == null)
                throw new ValidationException("Логин и пароль не найдены", "");

            LoginDTO lastLoginDTO = _mapper.Map<Login, LoginDTO>(lastLogin);

            return lastLoginDTO;
        }

    }
}
