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
    internal class LoginRepository : BaseRepository<Login>
    {
        public LoginRepository(DbContext dbContext) : base(dbContext)
        {
        }
        public async Task<Login> GetLastAsync()
        {   var entity = await _dbContext.Set<Login>().OrderByDescending(x => x.Id).FirstOrDefaultAsync();
            return entity;
        }
    }
}
