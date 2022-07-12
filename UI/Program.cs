﻿using BLL;
using BLL.Contracts;
using DAL;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;
using UI.forms;

namespace UI
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // crea coleccion de servicios para inyeccion de dependencias
            var services = new ServiceCollection();
            ConfigureServices(services);

            // corre form principal con servicios inyectados
            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                frmLogin mainForm = serviceProvider.GetRequiredService<frmLogin>();
                Application.Run(mainForm);
            }
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>))
                    .AddScoped<IUserService, UserService>()
                    .AddScoped<IOfferService, OfferService>()
                    .AddScoped<ISuggestedOfferService, SuggestedOfferService>()
                    .AddScoped<ICategoryService, CategoryService>()
                    .AddScoped<IBrandService, BrandService>()
                    .AddScoped<IProductService, ProductService>()
                    .AddScoped<IPurchaseService, PurchaseService>();

            services.AddScoped<frmLogin>();
        }
    }
}
