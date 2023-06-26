using Animal_Repair;
using AnimalRepair.BLL.DTO;
using AnimalRepair.BLL.Infrastructure;
using AnimalRepair.BLL.Interfaces;
using AnimalRepair.DAL.Interfaces;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AnimalRepair.BLL.Services
{
    public class OrderService : IOrderService
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
            if (string.IsNullOrEmpty(orderDto.IdCustomer.ToString()))
                throw new ValidationException("Поле заказчика не может быть пустым", "");
            if (string.IsNullOrEmpty(orderDto.Date))
                throw new ValidationException("Поле даты заказа не может быть пустым", "");
            if (string.IsNullOrEmpty(orderDto.Price.ToString()))
                throw new ValidationException("Поле цены не может быть пкстым", "");

            var order = _mapper.Map<OrderDTO, Order>(orderDto);
            await _unitOfWork.Orders.CreateAsync(order);
            _unitOfWork.Save();
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
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
            // Поиск животного по идентификатору
            Order order = await _unitOfWork.Orders.GetAsync(orderDto.Id);
            if (order == null)
                throw new ValidationException("Заказ не найден", "");

 
            order.IdCustomer = orderDto.IdCustomer;
            order.Date = orderDto.Date;
            order.Price = orderDto.Price;

            Order updatedOrder = _mapper.Map<OrderDTO, Order>(orderDto);

            await _unitOfWork.Orders.UpdateAsync(updatedOrder);
            _unitOfWork.Save();
        }
    }
}
