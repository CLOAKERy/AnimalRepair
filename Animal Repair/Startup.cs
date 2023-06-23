using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AnimalRepair.BLL.Interfaces;
using AnimalRepair.BLL.Services;
using Animal_Repair.Util;
using AnimalRepair.BLL.Mapping;
using AutoMapper;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews();

        var customerModule = new CustomerModule();
        customerModule.ConfigureServices(services);

        services.AddAutoMapper(typeof(MappingProfile));

        // Другие сервисы и настройки...
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // Конфигурация HTTP-конвейера

        app.UseRouting();
        app.UseStaticFiles();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
    }
}