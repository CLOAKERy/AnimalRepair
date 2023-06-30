using AnimalRepair.BLL.Interfaces;
using AnimalRepair.BLL.Services;

namespace Animal_Repair.Util
{
    public class OrderModule
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IOrderService, OrderService>();
        }
    }
}
