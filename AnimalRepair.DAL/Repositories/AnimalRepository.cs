using Animal_Repair;
using AnimalRepair.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalRepair.DAL.Repositories
{
    internal class AnimalRepository : BaseRepository<Animal>
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
    }
}