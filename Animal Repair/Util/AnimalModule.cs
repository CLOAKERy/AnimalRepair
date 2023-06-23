using AnimalRepair.BLL.Services;
using AnimalRepair.BLL.Interfaces;
namespace Animal_Repair.Util
{
    public class AnimalModule
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IAnimalService, AnimalService>();
        }
    }
}