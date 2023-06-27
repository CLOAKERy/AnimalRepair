using Animal_Repair;
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
    internal class AnimalRepository : BaseRepository<Animal>, IAnimalRepository<Animal>
    {
        public AnimalRepository(DbContext dbContext) : base(dbContext)
        {

        }
        public async Task GetByCategoryAsync(int idkindOfAnimal)
        {
            var item = await _dbContext.Set<Animal>().FindAsync(idkindOfAnimal);
            if (item != null)
            {
                _dbContext.Set<Animal>().Remove(item);
                await _dbContext.SaveChangesAsync();
            }
        }
        public new async Task<IEnumerable<Animal>> GetAllAsync(params Expression<Func<Animal, object>>[] includes)
        {
            IQueryable<Animal> query = _dbContext.Set<Animal>();

            // Включение связанных данных с помощью метода Include
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.ToListAsync();
        }

    }
}