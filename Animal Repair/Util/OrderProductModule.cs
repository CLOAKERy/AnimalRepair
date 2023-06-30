using AnimalRepair.BLL.Interfaces;
using AnimalRepair.BLL.Services;

namespace Animal_Repair.Util
{
    public class OrderProductModule
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IOrderProductService, OrderProductService>();
        }
    }
}
