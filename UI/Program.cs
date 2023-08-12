using BLL;
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
            ServiceCollection services = new ServiceCollection();
            services.AddScoped<IUserService, UserService>()
                    .AddScoped<IBrandService, BrandService>()
                    .AddScoped<ICategoryService, CategoryService>()
                    .AddScoped<IOfferService, OfferService>()
                    .AddScoped<IProductService, ProductService>()
                    .AddScoped<IOrderService, PurchaseService>()
                    .AddScoped<ISuggestedOfferService, SuggestedOfferService>()
                    .AddScoped<IBackupService, BackupService>()
                    .AddScoped<IUserRepository, UserRepository>()
                    .AddScoped<IBrandRepository, BrandRepository>()
                    .AddScoped<ICategoryRepository, CategoryRepository>()
                    .AddScoped<IOfferRepository, OfferRepository>()
                    .AddScoped<IProductRepository, ProductRepository>()
                    .AddScoped<IPurchaseRepository, PurchaseRepository>()
                    .AddScoped<ISuggestedOfferRepository, SuggestedOfferRepository>()
                    .AddScoped<IBackupRepository, BackupRepository>()
                    .AddSingleton(typeof(XmlRepository<>))
                    .AddScoped<frmLogin>();

            // corre form principal con servicios inyectados
            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                frmLogin mainForm = serviceProvider.GetRequiredService<frmLogin>();
                Application.Run(mainForm);
            }
        }
    }
}
