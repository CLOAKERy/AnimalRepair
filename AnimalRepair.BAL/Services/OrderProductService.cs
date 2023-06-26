﻿using Animal_Repair;
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
    internal class OrderProductService : IOrderProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public OrderProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task CreateOrderProduct(OrderProductDTO orderProductDto)
        {
            // Валидация данных промежуточной таблицы
            if (string.IsNullOrEmpty(orderProductDto.IdProduct.ToString()))
                throw new ValidationException("Продукт не может быть пустым", "");
            if (string.IsNullOrEmpty(orderProductDto.IdOrder.ToString()))
                throw new ValidationException("Заказ не может быть пустым", "");

            // Маппинг 
            var orderProduct = _mapper.Map<OrderProductDTO, OrderProduct>(orderProductDto);

            // Пример сохранения в базу данных с использованием UnitOfWork
            await _unitOfWork.OrderProducts.CreateAsync(orderProduct);
            _unitOfWork.Save();
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public async Task<IEnumerable<OrderProductDTO>> GetOrderProductByIdOrder(int orderId)
        {
            // Получение списка промежуточной таблицы по идентификатору заказа
            IEnumerable<OrderProduct> Orders = await _unitOfWork.OrderProducts.GetOrderProductByIdOrder(orderId);
            return _mapper.Map<IEnumerable<OrderProduct>, IEnumerable<OrderProductDTO>>(Orders);
        }

        public async Task<IEnumerable<OrderProductDTO>> GetOrderProductByIdProduct(int productId)
        {
            // Получение списка промежуточной таблицы по идентификатору продукта
            IEnumerable<OrderProduct> Orders = await _unitOfWork.OrderProducts.GetOrderProductByIdOrder(productId);
            return _mapper.Map<IEnumerable<OrderProduct>, IEnumerable<OrderProductDTO>>(Orders);
        }

        public async Task RemoveOrderProduct(int orderId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateOrderProduct(OrderProductDTO orderProductDto)
        {
            throw new NotImplementedException();
        }
    }
}
