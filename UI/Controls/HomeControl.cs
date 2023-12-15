using BLL;
using Entities;
using Entities.Enums;
using System;
using System.Windows.Forms;

namespace UI.Controls
{
    public partial class HomeControl : UserControl
    {
        private readonly IUserService userService;

        public HomeControl(IUserService userService)
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.userService = userService;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtUsername.Text;

            try
            {
                userService.Create(new User(username, password, "Cliente"));
                MessageBox.Show("Registrado Correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                MessageBox.Show("Bienvenido");
                
                //TODO: guardar user en session para toda la app y habilitar botones
                //TODO: habilitar los botones segun roles

                tlpLogin.Visible = false;
                btnLogout.Visible = true;
            }

        }
    }
}
