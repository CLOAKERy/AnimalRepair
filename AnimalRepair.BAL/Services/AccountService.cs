using AnimalRepair.BLL.DTO;
using AnimalRepair.BLL.Infrastructure;
using AnimalRepair.BLL.Interfaces;
using AnimalRepair.BLL.BusinessModel;
using AnimalRepair.DAL.Interfaces;
using AnimalRepair.DAL.Repositories;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Animal_Repair;

namespace AnimalRepair.BLL.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AccountService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ClaimsIdentity> Register(LoginDTO loginDTO)
        {
            try
            {
                var login = await _unitOfWork.Logins.GetByLoginAsync(loginDTO.Login1);
                if (login != null)
                {
                    throw new ValidationException("Такое имя уже занято", "");
                }
                // Валидация данных 
                if (string.IsNullOrEmpty(loginDTO.Login1.ToString()))
                    throw new ValidationException("Логин не может быть пустым", "");
                if (string.IsNullOrEmpty(loginDTO.Password.ToString()))
                    throw new ValidationException("Пароль не может быть пустым", "");

                LoginDTO loginRegister = new()
                {
                    Login1 = loginDTO.Login1,  
                    Password = HashPassword.GetHashPassword(loginDTO.Password),
                };


                // Пример сохранения в базу данных с использованием UnitOfWork
                await _unitOfWork.Logins.CreateAsync(_mapper.Map<LoginDTO, Login>(loginRegister));
                _unitOfWork.Save();

                // Получение последнего логина из таблицы
                Login lastLogin = await _unitOfWork.Logins.GetLastAsync();
                //Login lastLogin = await _eFUnitOfWork.Logins.GetLastAsync();
                if (lastLogin == null)
                    throw new ValidationException("Логин и пароль не найдены", "");

                LoginDTO lastLoginDTO = _mapper.Map<Login, LoginDTO>(lastLogin);

                var customer = new CustomerDTO()
                {
                    IdLogin = lastLoginDTO.Id,
                    IdRole = 1,
                    Name = "Lera",
                    Adress = "Good",
                    PhoneNumber = "+Good"
                };

                await _unitOfWork.Customers.CreateAsync(_mapper.Map<CustomerDTO, Customer>(customer));
                _unitOfWork.Save();

                var result = Authenticate(customer);

                return result;

            }
            catch 
            {
                throw new ValidationException("Не работает", "");
             
            }
        }

        public async Task<ClaimsIdentity> Login(LoginDTO loginDTO)
        {
            try
            {
                var login = await _unitOfWork.Logins.GetByLoginAsync(loginDTO.Login1);
                if (login == null)
                {
                    throw new ValidationException("Пользователь не найден", "");
                }

                if (login.Password != HashPassword.GetHashPassword(loginDTO.Password))
                {
                    throw new ValidationException($"Неверный логин или пароль {HashPassword.GetHashPassword(login.Password)}", "");
                }

                // Поиск логина и пароля по идентификатору
                Customer customer = await _unitOfWork.Customers.GetByLoginIdAsync(login.Id);
                if (customer == null)
                    throw new ValidationException("Пользователь не найден", "");

                CustomerDTO customerDTO = _mapper.Map<Customer, CustomerDTO>(customer);

                var result = Authenticate(customerDTO);

                return result;
            }
            catch 
            {
                throw new ValidationException("Не работает", "");
            }
        }

        

        private ClaimsIdentity Authenticate(CustomerDTO user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Id.ToString()),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.IdRole.ToString())
            };
            return new ClaimsIdentity(claims, "ApplicationCookie",
                ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        }
    }
}
