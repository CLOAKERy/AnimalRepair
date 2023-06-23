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
using Microsoft.EntityFrameworkCore;
using System;
using Animal_Repair;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        // получаем строку подключения из файла конфигурации
        string connection = Configuration.GetConnectionString("DefaultConnection");
        // добавляем контекст AppDBContext в качестве сервиса в приложение
        services.AddDbContext<AnimalRepairContext>(options => options.UseSqlServer("Data Source=sql5106.site4now.net;User ID=db_a9ae8d_dbanimalre_admin;Password=a12345678;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;"));
        services.AddControllersWithViews();

        var customerModule = new CustomerModule();
        customerModule.ConfigureServices(services);

        var animalModule = new AnimalModule();
        animalModule.ConfigureServices(services);

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