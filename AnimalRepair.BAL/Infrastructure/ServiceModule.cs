using AnimalRepair.DAL.Interfaces;
using AnimalRepair.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalRepair.BLL.Infrastructure
{
    public class ServiceModule
    {
        private string connectionString;

        public ServiceModule()
        {
            
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork>(provider => new EFUnitOfWork());
        }
    }
}
