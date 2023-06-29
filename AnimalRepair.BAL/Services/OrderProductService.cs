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
    public class OrderProductService : IOrderProductService
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

        public async Task<IEnumerable<OrderProductDTO>> GetOrderProductByIdOrder(int orderId)
        {
            // Получение списка промежуточной таблицы по идентификатору заказа
            IEnumerable<OrderProduct> Orders = await _unitOfWork.OrderProducts.GetOrderProductByIdOrder(orderId);
            return _mapper.Map<IEnumerable<OrderProduct>, IEnumerable<OrderProductDTO>>(Orders);
        }

        public async Task<IEnumerable<OrderProductDTO>> GetOrderProductByIdProduct(int productId)
        {
            // Получение списка промежуточной таблицы по идентификатору продукта
            IEnumerable<OrderProduct> Orders = await _unitOfWork.OrderProducts.GetOrderProductByIdProduct(productId);
            return _mapper.Map<IEnumerable<OrderProduct>, IEnumerable<OrderProductDTO>>(Orders);
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public async Task RemoveOrderProduct(int orderProductId)
        {
            OrderProduct orderProduct = await _unitOfWork.OrderProducts.GetAsync(orderProductId);
            if (orderProduct == null)
                throw new ValidationException("Заказ не найден", "");

            await _unitOfWork.OrderProducts.DeleteAsync(orderProductId);
            _unitOfWork.Save();
        }

        public async Task UpdateOrderProduct(OrderProductDTO orderProductDto)
        {
            OrderProduct updatedOrderProduct = _mapper.Map<OrderProductDTO, OrderProduct>(orderProductDto);

            await _unitOfWork.OrderProducts.UpdateAsync(updatedOrderProduct);
            _unitOfWork.Save();
        }

        public async Task SaveOrderWithProducts(OrderDTO orderDTO, List<ProductDTO> productDTOs, List<AnimalDTO> animalDTOs)
        {
            // Маппинг OrderDTO в Order
            Order order = _mapper.Map<Order>(orderDTO);
            await _unitOfWork.Orders.CreateAsync(order);

            Order orderForAnimal = await _unitOfWork.Orders.GetLastOrder();

            foreach (var animalDTO in animalDTOs)
            {
                animalDTO.IdOrder = orderForAnimal.Id;
                Animal animal = _mapper.Map<Animal>(animalDTO);
                await _unitOfWork.Animals.UpdateAsync(animal);
            }

            // Маппинг списка ProductDTO в список Product
            var products = _mapper.Map<List<Product>>(productDTOs);

            // Вызов метода сохранения в базе данных
            await _unitOfWork.OrderProducts.SaveOrderWithProducts(orderForAnimal, products);
        }
    }
}
