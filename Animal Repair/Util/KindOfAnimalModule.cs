using AnimalRepair.BLL.Interfaces;
using AnimalRepair.BLL.Services;

namespace Animal_Repair.Util
{
    public class KindOfAnimalModule
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IKindOfAnimalService, KindOfAnimalService>();
        }
    }
}
