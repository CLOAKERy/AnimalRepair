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
using AnimalRepair.DAL.Interfaces;
using AnimalRepair.DAL.Repositories;
using AnimalRepair.BLL.DTO;
using Microsoft.AspNetCore.Authentication.Cookies;
using Animal_Repair.Middleware;

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
        services.AddDbContext<AnimalRepairContext>(options => options.UseSqlServer(connection));


        services.AddControllersWithViews();
        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
        {
            options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
            options.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
        });

        services.AddSession(options =>
        {
            options.Cookie.Name = "YourSessionCookieName"; // Установите имя cookie сеанса
            options.IdleTimeout = TimeSpan.FromMinutes(30); // Установите время простоя сеанса
        });

        var customerModule = new CustomerModule();
        customerModule.ConfigureServices(services);

        var animalModule = new AnimalModule();
        animalModule.ConfigureServices(services);

        var productModule = new ProductModule();
        productModule.ConfigureServices(services);

        var accountModule = new AccountModule();
        accountModule.ConfigureServices(services);

        var kindOfGenderModule = new KindOfGenderModule();
        kindOfGenderModule.ConfigureServices(services);
        var kindOfAnimalModule = new KindOfAnimalModule();
        kindOfAnimalModule.ConfigureServices(services);

        var ProductModule = new ProductModule();
        ProductModule.ConfigureServices(services);

        var kindOfProductModule = new KindOfProductModule();
        kindOfProductModule.ConfigureServices(services);



        services.AddScoped<IUnitOfWork, EFUnitOfWork>();

        services.AddAutoMapper(typeof(AnimalMapper));
        services.AddAutoMapper(typeof(AdminMapper));
        services.AddAutoMapper(typeof(CustomerMapper));
        services.AddAutoMapper(typeof(KindOfAnimalMapper));
        services.AddAutoMapper(typeof(KindOfGenderMapper));
        services.AddAutoMapper(typeof(KindOfProductMapper));
        services.AddAutoMapper(typeof(OrderMapper));
        services.AddAutoMapper(typeof(LoginMapper));
        services.AddAutoMapper(typeof(OrderProductMapper));
        services.AddAutoMapper(typeof(ProductMapper));
        services.AddAutoMapper(typeof(UserRoleMapper));

        // Другие сервисы и настройки...
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // Конфигурация HTTP-конвейера
        
        app.UseErrorHandlingMiddleware();
        app.UseExceptionHandler("/Home/Error");
        app.UseRouting();
        app.UseStaticFiles();
        //app.UseDeveloperExceptionPage();
        app.UseSession();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
    }
}