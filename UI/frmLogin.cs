using BLL.Contracts;
using Entities;
using Entities.Enums;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace UI.forms
{
    public partial class frmLogin : Form
    {
        private readonly IServiceProvider serviceProvider;
        private readonly IUserService userService;

        public frmLogin(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            this.serviceProvider = serviceProvider;
            this.userService = serviceProvider.GetRequiredService<IUserService>();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            User loggedUser = userService.Login(username, password);

            if (loggedUser == null)
            {
                MessageBox.Show("Usuario y/o contraseña no validos");
            }
            else
            {
                Hide();
                new MDIBase(loggedUser, serviceProvider).Show();
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtUsername.Text;

            try
            {
                userService.Register(new User(username, password, UserRole.SHOPPER));
                MessageBox.Show("Registrado Correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
