using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.forms
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            bool validLogin = Login(username, password);
            if (validLogin)
            {
                var mainMDI = new MDIBase
                {
                    StartPosition = FormStartPosition.CenterScreen
                };
                Hide();
                mainMDI.Show();
            }
            else
            {
                MessageBox.Show("Usuario y/o contraseña no validos");
            }
        }

        private bool Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return false;

            return true;
        }
    }
}
