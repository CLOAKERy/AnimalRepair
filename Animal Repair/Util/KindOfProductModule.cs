﻿using AnimalRepair.BLL.Interfaces;
using AnimalRepair.BLL.Services;

namespace Animal_Repair.Util
{
    public class KindOfProductModule
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IKindOfProductService, KindOfProductService>();
        }
    }
}