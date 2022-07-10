using BLL.Contracts;
using Entities;
using System;
using System.Windows.Forms;

namespace UI.forms
{
    public partial class frmLogin : Form
    {
        private readonly IUserService userService;
        private readonly IOfferService offerService;

        public frmLogin(IUserService userService, IOfferService offerService)
        {
            this.userService = userService;
            this.offerService = offerService;
            InitializeComponent();
            txtPassword.Text = "admin";
            txtUsername.Text = "admin";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            User loggedUser = userService.Login(username, password);

            if (loggedUser != null)
            {
                Hide();
                new MDIBase(loggedUser.Role, offerService)
                {
                    StartPosition = FormStartPosition.CenterScreen
                }.Show();
            }
            else
            {
                MessageBox.Show("Usuario y/o contraseña no validos");
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            bool registerFinished = userService.Register(username, password);

            if (registerFinished)
            {
                MessageBox.Show("Registrado Correctamente");
            }
        }

        private void btnForgotPassword_Click(object sender, EventArgs e)
        {
        }

        private void tlpLogin_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
