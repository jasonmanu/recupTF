﻿using BLL.Contracts;
using Entities;
using System;
using System.Windows.Forms;

namespace UI.forms
{
    public partial class frmLogin : Form
    {
        private readonly IUserService userService;
        private readonly IOfferService offerService;
        private readonly ISuggestedOfferService suggestedOfferService;

        public frmLogin(IUserService userService, IOfferService offerService, ISuggestedOfferService suggestedOfferService)
        {
            InitializeComponent();

            this.userService = userService;
            this.offerService = offerService;
            this.suggestedOfferService = suggestedOfferService;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            User loggedUser = userService.Login(username, password);

            if (loggedUser != null)
            {
                Hide();
                new MDIBase(loggedUser.Role, offerService, suggestedOfferService).Show();
            }
            else
            {
                MessageBox.Show("Usuario y/o contraseña no validos");
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtUsername.Text;

            try
            {
                userService.Create(new User(username, password, UserRole.SHOPPER));
                MessageBox.Show("Registrado Correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnForgotPassword_Click(object sender, EventArgs e)
        {
        }
    }
}
