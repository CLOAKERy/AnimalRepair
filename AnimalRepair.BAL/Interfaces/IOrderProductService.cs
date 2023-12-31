﻿using Animal_Repair;
using AnimalRepair.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalRepair.BLL.Interfaces
{
    public interface IOrderProductService : IDisposable
    {
        Task RemoveOrderProduct(int orderProductId);
        Task<IEnumerable<OrderProductDTO>> GetOrderProductByIdOrder(int orderId);
        Task<IEnumerable<OrderProductDTO>> GetOrderProductByIdProduct(int productId);
        Task SaveOrderWithProducts(OrderDTO order, List<ProductDTO> products, List<AnimalDTO> animalDTOs);
        Task UpdateOrderProduct(OrderProductDTO orderProductDto);
        Task CreateOrderProduct(OrderProductDTO orderProductDto);
    }
}
