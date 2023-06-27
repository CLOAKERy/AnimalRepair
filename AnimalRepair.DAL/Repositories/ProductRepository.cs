﻿using Animal_Repair;
using AnimalRepair.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AnimalRepair.DAL.Repositories
{
    internal class ProductRepository : BaseRepository<Product>, IProductRepository<Product>
    {
        public ProductRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Product>> GetAllAsync(params Expression<Func<Product, object>>[] includes)
        {
            IQueryable<Product> query = _dbContext.Set<Product>();

            // Включение связанных данных с помощью метода Include
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.ToListAsync();
        }
    }
}
