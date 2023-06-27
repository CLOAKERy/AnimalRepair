using Animal_Repair;
using AnimalRepair.BLL.DTO;
using AnimalRepair.BLL.Infrastructure;
using AnimalRepair.BLL.Interfaces;
using AnimalRepair.DAL.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalRepair.BLL.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CustomerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public Task<CustomerDTO> Authenticate(string username, string password)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteUser(int userId)
        {
            Customer customer = await _unitOfWork.Customers.GetAsync(userId);
            if (customer == null)
                throw new ValidationException("Пользователь не найден", "");

            await _unitOfWork.Customers.DeleteAsync(userId);
            _unitOfWork.Save();
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public async Task<CustomerDTO> GetUserProfile(int userId)
        {
            // Поиск логина и пароля по идентификатору
            Customer customer = await _unitOfWork.Customers.GetAsync(userId);
            if (customer == null)
                throw new ValidationException("Пользователь не найден", "");

            CustomerDTO customerDTO = _mapper.Map<Customer, CustomerDTO>(customer);

            return customerDTO;
        }

        public async Task<IEnumerable<CustomerDTO>> GetUsers()
        {
            // Получение списка пользователей
            IEnumerable<Customer> customer = await _unitOfWork.Customers.GetAllAsync();
            return _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerDTO>>(customer);
        }

        public async Task RegisterCustomer(CustomerDTO customerDto)
        {
            // Валидация данных 
            if (string.IsNullOrEmpty(customerDto.IdLogin.ToString()))
                throw new ValidationException("Логин не может быть пустым", "");
            if (string.IsNullOrEmpty(customerDto.IdRole.ToString()))
                throw new ValidationException("Роль не может быть пустым", "");
            if (string.IsNullOrEmpty(customerDto.Name.ToString()))
                throw new ValidationException("Имя не может быть пустым", "");
            if (string.IsNullOrEmpty(customerDto.PhoneNumber.ToString()))
                throw new ValidationException("Телефон не может быть пустым", "");
            if (string.IsNullOrEmpty(customerDto.Adress.ToString()))
                throw new ValidationException("Адрес не может быть пустым", "");

            // Маппинг 
            var customer = _mapper.Map<CustomerDTO, Customer>(customerDto);

            // Пример сохранения в базу данных с использованием UnitOfWork
            await _unitOfWork.Customers.CreateAsync(customer);
            _unitOfWork.Save();
        }

        public async Task UpdateUserProfile(CustomerDTO customerDto)
        {
            // Поиск логина и пароля по идентификатору
            Customer customer = await _unitOfWork.Customers.GetAsync(customerDto.Id);
            if (customer == null)
                throw new ValidationException("Пользователь не найден", "");

            // Обновление данных логина и пароля
            customer.Adress = customerDto.Adress;
            customer.IdLogin = customerDto.IdLogin;
            customer.PhoneNumber = customerDto.PhoneNumber;
            customer.Name = customerDto.Name;
            customer.IdRole = customerDto.IdRole;

            // Маппинг 
            Customer updatedCustomer = _mapper.Map<CustomerDTO, Customer>(customerDto);

            // Обновление пользователя в базе данных
            await _unitOfWork.Customers.UpdateAsync(updatedCustomer);
            _unitOfWork.Save();
        }

        public async Task<CustomerDTO> GetUserByLogin(int IdLogin)
        {
            // Поиск логина и пароля по идентификатору
            Customer customer = await _unitOfWork.Customers.GetByLoginIdAsync(IdLogin);
            if (customer == null)
                throw new ValidationException("Пользователь не найден", "");

            CustomerDTO customerDTO = _mapper.Map<Customer, CustomerDTO>(customer);

            return customerDTO;
        }
    }
}
