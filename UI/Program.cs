using BLL;
using BLL.Contracts;
using DAL;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;
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
            ServiceCollection services = new ServiceCollection();
            services.AddScoped<IUserService, UserService>()
                    .AddScoped<IBrandService, BrandService>()
                    .AddScoped<ICategoryService, CategoryService>()
                    .AddScoped<IOfferService, OfferService>()
                    .AddScoped<IProductService, ProductService>()
                    .AddScoped<IOrderService, PurchaseService>()
                    .AddScoped<ISuggestedOfferService, SuggestedOfferService>()
                    .AddScoped<IUserRepository, UserRepository>()
                    .AddScoped<frmLogin>();
            //.AddScoped(typeof(IBaseRepository<>), typeof(XmlRepository<>))

            // corre form principal con servicios inyectados
            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                frmLogin mainForm = serviceProvider.GetRequiredService<frmLogin>();
                Application.Run(mainForm);
            }
        }

        //private static void ConfigureServices(ServiceCollection services)
        //{
        //    services.AddScoped(typeof(IBaseRepository<>), typeof(XmlRepository<>))
        //            .AddScoped<IUserRepository, UserRepository>()
        //            .AddScoped<IBrandService, BrandService>()
        //            .AddScoped<ICategoryService, CategoryService>()
        //            .AddScoped<IOfferService, OfferService>()
        //            .AddScoped<IProductService, ProductService>()
        //            .AddScoped<IOrderService, PurchaseService>()
        //            .AddScoped<ISuggestedOfferService, SuggestedOfferService>()
        //            .AddScoped<IUserService, UserService>()
        //            .AddScoped<frmLogin>();

        //    //services.AddScoped<frmLogin>();
        //}
    }
}
