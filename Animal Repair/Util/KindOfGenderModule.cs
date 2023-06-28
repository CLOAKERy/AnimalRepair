using AnimalRepair.BLL.Interfaces;
using AnimalRepair.BLL.Services;

namespace Animal_Repair.Util
{
    public class KindOfGenderModule
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IKindOfGenderService, KindOfGenderService>();
        }
    }
}
