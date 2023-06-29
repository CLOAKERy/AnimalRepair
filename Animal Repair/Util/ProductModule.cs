using AnimalRepair.BLL.Interfaces;
using AnimalRepair.BLL.Services;

namespace Animal_Repair.Util
{
    public class ProductModule
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
        }
    }
}
