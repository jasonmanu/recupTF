using BLL;
using DAL;
using DAL.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

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
            services.AddScoped<IAuthorService, AuthorService>()
                    .AddScoped<IAuthorRepository, AuthorRepository>()
                    .AddScoped<IBackupService, BackupService>()
                    .AddScoped<IBackupRepository, BackupRepository>()
                    .AddScoped<IBookService, BookService>()
                    .AddScoped<IBookRepository, BookRepository>()
                    .AddScoped<ICategoryService, CategoryService>()
                    .AddScoped<ICategoryRepository, CategoryRepository>()
                    .AddScoped<IUserRepository, UserRepository>()
                    .AddScoped<IUserService, UserService>()
                    .AddScoped<IUserRepository, UserRepository>()
                    .AddScoped<ISubscriptionService, SubscriptionService>()
                    .AddScoped<ISubscriptionRepository, SubscriptionRepository>()
                    .AddScoped<ISubscriptionTypeService, SubscriptionTypeService>()
                    .AddScoped<ISubscriptionTypeRepository, SubscriptionTypeRepository>()
                    .AddScoped<ILoanService, LoanService>()
                    .AddScoped<ILoanRepository, LoanRepository>()
                    .AddScoped<IRoleService, RoleService>()
                    .AddScoped<IRoleRepository, RoleRepository>()
                    .AddSingleton(typeof(XmlRepository<>));

            ServiceProvider serviceProvider = services.BuildServiceProvider();
            Application.Run(new MainForm(serviceProvider));
        }
    }
}
