﻿using Animal_Repair;
using AnimalRepair.DAL.Interfaces;
using AnimalRepair.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace OrderProductRepair.DAL.Repositories
{
    internal class OrderProductRepository : BaseRepository<OrderProduct>, IOrderProductRepository<OrderProduct>
    {
        public OrderProductRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<OrderProduct>> GetOrderProductByIdOrder(int orderId)
        {
            return await _dbContext.Set<OrderProduct>()
                .Where(a => a.IdOrder == orderId)
                .ToListAsync();
        }

        public async Task<IEnumerable<OrderProduct>> GetOrderProductByIdProduct(int productId)
        {
            return await _dbContext.Set<OrderProduct>()
                .Where(a => a.IdProduct == productId)
                .ToListAsync();
        }

        public async Task SaveOrderWithProducts(Order order, List<Product> products)
        {
            // Создаем новую запись заказа в базе данных
            await _dbContext.Set<Order>().AddAsync(order);
            await _dbContext.SaveChangesAsync();

            // Сохраняем связанные записи продуктов
            foreach (var product in products)
            {
                var orderProduct = new OrderProduct
                {
                    IdOrder = order.Id, // Предполагается, что у заказа есть поле Id
                    IdProduct = product.Id // Предполагается, что у продукта есть поле Id
                };

                await _dbContext.Set<OrderProduct>().AddAsync(orderProduct);
            }

            await _dbContext.SaveChangesAsync();
        }

    }
}
