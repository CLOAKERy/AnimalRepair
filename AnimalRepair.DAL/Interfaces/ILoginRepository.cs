using Animal_Repair;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalRepair.DAL.Interfaces
{
    public interface ILoginRepository<Login> : IRepository<Login> where Login : class
    {
        public Task<Login> GetLastAsync();
        public Task<Login> GetByLoginAsync(string login);
    }
}
