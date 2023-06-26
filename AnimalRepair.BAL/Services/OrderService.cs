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
    internal class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task CreateOrder(OrderDTO orderDto)
        {
            // Валидация данных заказа
            if (string.IsNullOrEmpty(orderDto.IdCustomer.ToString()))
                throw new ValidationException("Пользователь не может быть пустым", "");
            if (string.IsNullOrEmpty(orderDto.Date))
                throw new ValidationException("Дата не может быть пустой", "");
            if (string.IsNullOrEmpty(orderDto.Price.ToString()))
                throw new ValidationException("Цена не может быть пустой", "");
            if (string.IsNullOrEmpty(orderDto.Status))
                throw new ValidationException("Статус не может быть пустой", "");

            // Маппинг OrderDTO в Order
            var order = _mapper.Map<OrderDTO, Order>(orderDto);

            // Пример сохранения в базу данных с использованием UnitOfWork
            await _unitOfWork.Orders.CreateAsync(order);
            _unitOfWork.Save();
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public async Task<OrderDTO> GetOrderById(int orderId)
        {
            // Поиск заказа по идентификатору
            Order order = await _unitOfWork.Orders.GetAsync(orderId);
            if (order == null)
                throw new ValidationException("Заказ не найден", "");

            OrderDTO orderDto = _mapper.Map<Order, OrderDTO>(order);

            return orderDto;
        }

        public async Task<IEnumerable<OrderDTO>> GetOrderByIdCustomer(int customerId)
        {
            // Получение списка заказов по пользователю
            IEnumerable<Order> Orders = await _unitOfWork.Orders.GetOrdersByCustomerId(customerId);
            return _mapper.Map<IEnumerable<Order>, IEnumerable<OrderDTO>>(Orders);
        }

        public async Task<IEnumerable<OrderDTO>> GetOrdersByStatus(string status)
        {
            // Получение списка заказов по статусу
            IEnumerable<Order> Orders = await _unitOfWork.Orders.GetOrdersByStatus(status);
            return _mapper.Map<IEnumerable<Order>, IEnumerable<OrderDTO>>(Orders);
        }

        public async Task RemoveOrder(int orderId)
        {
            Order order = await _unitOfWork.Orders.GetAsync(orderId);
            if (order == null)
                throw new ValidationException("Заказ не найден", "");

            await _unitOfWork.Orders.DeleteAsync(orderId);
            _unitOfWork.Save();
        }

        public async Task UpdateOrder(OrderDTO orderDto)
        {
            // Поиск заказа по идентификатору
            Order order = await _unitOfWork.Orders.GetAsync(orderDto.Id);
            if (order == null)
                throw new ValidationException("Заказ не найден", "");

            // Обновление данных 
            order.Date = orderDto.Date;
            order.Price = orderDto.Price;
            order.IdCustomer = orderDto.IdCustomer;
            order.Status = orderDto.Status;

            // Обновление других свойств животного

            // Маппинг OrderDTO в Order
            Order updatedOrder = _mapper.Map<OrderDTO, Order>(orderDto);

            // Обновление заказа в базе данных
            await _unitOfWork.Orders.UpdateAsync(updatedOrder);
            _unitOfWork.Save();
        }
    }
}
