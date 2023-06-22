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
    internal class UserRoleRepository : BaseRepository<UserRole>
    {
        public UserRoleRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}