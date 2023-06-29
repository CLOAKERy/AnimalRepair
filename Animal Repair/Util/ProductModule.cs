using AnimalRepair.BLL.Interfaces;
using AnimalRepair.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace Animal_Repair.Util
{
    public class ProductModule : Controller
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
        }
    }
}
