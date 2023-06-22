using AnimalRepair.BLL.Services;
using AnimalRepair.BLL.Interfaces;
namespace Animal_Repair.Util
{
    public class CustomerModule
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerService>();
        }
    }
}
