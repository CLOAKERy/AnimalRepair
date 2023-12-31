﻿using Animal_Repair;
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
            // Маппинг OrderDTO в Order
            Order updatedOrder = _mapper.Map<OrderDTO, Order>(orderDto);

            await _unitOfWork.Orders.UpdateAsync(updatedOrder);
            _unitOfWork.Save();
        }

        public async Task<IEnumerable<OrderDTO>> GetAllOrders()
        {
            IEnumerable<Order> orders = await _unitOfWork.Orders.GetAllAsync();

            var orderDTOs = _mapper.Map<IEnumerable<Order>, IEnumerable<OrderDTO>>(orders);

            List<Product> products = new List<Product>();

            foreach(var orderDTO in orderDTOs)
            {
                IEnumerable<OrderProduct> orderProducts = await _unitOfWork.OrderProducts.GetOrderProductByIdOrder(orderDTO.Id);
                foreach (var orderProduct in orderProducts)
                {
                    products.Add(await _unitOfWork.Products.GetAsync(orderProduct.IdProduct));
                }
                orderDTO.Products = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(products);
                products.Clear();

                IEnumerable<Animal> animal = await _unitOfWork.Animals.GetAnimaByIdOrderAsync(orderDTO.Id);
                orderDTO.Animals = _mapper.Map<IEnumerable<Animal>, IEnumerable<AnimalDTO>>(animal);
            }
            return orderDTOs;
        }
    }
}
