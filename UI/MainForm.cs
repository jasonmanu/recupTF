﻿using BLL;
using Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using UI.Controls;

namespace UI
{
    public partial class MainForm : Form
    {
        private readonly IUserService userService;
        private readonly ICategoryService categoryService;
        private readonly IBackupService backupService;
        private readonly IBookService bookService;
        private readonly ILoanService loanService;
        private readonly IAuthorService authorService;
        private readonly ISubscriptionService subscriptionService;
        private readonly ISubscriptionTypeService subscriptionTypeService;
        private readonly IRoleService roleService;

        private User user;
        private BookControl bookControl;
        private LoanControl loanControl;
        private UsuariosControl usersControl;
        private MultasControl multasControl;
        private BibliotecariosControl bibliotecariosControl;
        private AuthorControl authorControl;
        private BackupControl backupControl;
        private CategoryControl categoryControl;
        private SubscriptionTypeControl subscriptionTypesControl;

        public MainForm(IServiceProvider serviceProvider)
        {
            this.userService = serviceProvider.GetRequiredService<IUserService>();
            this.categoryService = serviceProvider.GetRequiredService<ICategoryService>();
            this.backupService = serviceProvider.GetRequiredService<IBackupService>();
            this.bookService = serviceProvider.GetRequiredService<IBookService>();
            this.authorService = serviceProvider.GetRequiredService<IAuthorService>();
            this.subscriptionService = serviceProvider.GetRequiredService<ISubscriptionService>();
            this.subscriptionTypeService = serviceProvider.GetRequiredService<ISubscriptionTypeService>();
            this.loanService = serviceProvider.GetRequiredService<ILoanService>();
            this.roleService = serviceProvider.GetRequiredService<IRoleService>();

            InitializeComponent();

            btnMultas.Visible = false;
            btnLibros.Visible = false;
            btnPrestamos.Visible = false;
            btnMultas.Visible = false;
            btnUsuarios.Visible = false;
            btnRoles.Visible = false;
            btnAuthors.Visible = false;
            btnCategories.Visible = false;
            btnSubscriptionTypes.Visible = false;
            btnBackup.Visible = false;

            //homeControl = new HomeControl(userService);
            //mainPanel.Controls.Add(homeControl);
            //homeControl.BringToFront();
            //btnInicio.BackColor = Color.LightBlue;
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            ResetButtonsColors();
            btnInicio.BackColor = Color.LightBlue;
            this.mainPanel.Controls.Clear();
            //foreach (Control control in this.mainPanel.Controls.Clear())
            //{
            //    if (control is UserControl)
            //    {
            //        control.Visible = false;
            //    }
            //}
            //btnInicio.BackColor = Color.LightBlue;
            //homeControl = new HomeControl(userService);
            //mainPanel.Controls.Add(homeControl);
            //homeControl.BringToFront();
        }

        private void btnLibros_Click(object sender, EventArgs e)
        {
            ResetButtonsColors();
            btnLibros.BackColor = Color.LightBlue;
            bookControl = new BookControl(bookService, authorService, categoryService, loanService, user);
            mainPanel.Controls.Add(bookControl);
            bookControl.BringToFront();
        }

        private void btnPrestamos_Click(object sender, EventArgs e)
        {
            ResetButtonsColors();
            btnPrestamos.BackColor = Color.LightBlue;
            loanControl = new LoanControl();
            mainPanel.Controls.Add(loanControl);
            loanControl.BringToFront();
        }

        private void btnMultas_Click(object sender, EventArgs e)
        {
            ResetButtonsColors();
            btnMultas.BackColor = Color.LightBlue;
            multasControl = new MultasControl();
            mainPanel.Controls.Add(multasControl);
            multasControl.BringToFront();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            ResetButtonsColors();
            btnUsuarios.BackColor = Color.LightBlue;
            usersControl = new UsuariosControl(userService);
            mainPanel.Controls.Add(usersControl);
            usersControl.BringToFront();
        }

        private void btnBibliotecarios_Click(object sender, EventArgs e)
        {
            ResetButtonsColors();
            //btnBibliotecarios.BackColor = Color.LightBlue;
            bibliotecariosControl = new BibliotecariosControl();
            mainPanel.Controls.Add(bibliotecariosControl);
            bibliotecariosControl.BringToFront();
        }

        private void btnAuthors_Click(object sender, EventArgs e)
        {
            ResetButtonsColors();
            btnAuthors.BackColor = Color.LightBlue;
            authorControl = new AuthorControl(authorService);
            mainPanel.Controls.Add(authorControl);
            authorControl.BringToFront();
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            ResetButtonsColors();
            btnCategories.BackColor = Color.LightBlue;
            categoryControl = new CategoryControl(categoryService);
            mainPanel.Controls.Add(categoryControl);
            categoryControl.BringToFront();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            ResetButtonsColors();
            btnBackup.BackColor = Color.LightBlue;
            backupControl = new BackupControl(backupService);
            mainPanel.Controls.Add(backupControl);
            backupControl.BringToFront();
        }

        private void btnCollection_Click(object sender, EventArgs e)
        {
            ResetButtonsColors();
            //btnCollection.BackColor = Color.LightBlue;
            //mainPanel.Controls.Add(collectionControl);
            //collectionControl.BringToFront();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Salir de la aplicacion?", "Confirmar", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
        }

        private void btnSubscription_Click(object sender, EventArgs e)
        {
            ResetButtonsColors();
            //btnSubscription.BackColor = Color.LightBlue;
        }

        private void btnSubsInfo_Click(object sender, EventArgs e)
        {
            ResetButtonsColors();
            btnSubscriptionTypes.BackColor = Color.LightBlue;
            subscriptionTypesControl = new SubscriptionTypeControl(subscriptionTypeService, subscriptionService);
            mainPanel.Controls.Add(subscriptionTypesControl);
            subscriptionTypesControl.BringToFront();
        }

        private void ResetButtonsColors()
        {
            btnInicio.BackColor = Color.LightGray;
            btnLibros.BackColor = Color.LightGray;
            btnMultas.BackColor = Color.LightGray;
            //btnSubscription.BackColor = Color.LightGray;
            //btnCollection.BackColor = Color.LightGray;
            //btnBibliotecarios.BackColor = Color.LightGray;
            btnUsuarios.BackColor = Color.LightGray;
            btnPrestamos.BackColor = Color.LightGray;
            btnSubscriptionTypes.BackColor = Color.LightGray;
            btnBackup.BackColor = Color.LightGray;
            btnAuthors.BackColor = Color.LightGray;
            btnCategories.BackColor = Color.LightGray;
            btnRoles.BackColor = Color.LightGray;
        }

        private void btnRoles_Click(object sender, EventArgs e)
        {
            ResetButtonsColors();
            btnRoles.BackColor = Color.LightBlue;
            RolsControl rolsControl = new RolsControl(roleService);
            mainPanel.Controls.Add(rolsControl);
            rolsControl.BringToFront();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            user = userService.Login(username, password);

            if (user == null)
            {
                MessageBox.Show("Usuario y/o contraseña no validos");
            }
            else
            {
                txtUsername.Text = username;
                lblPassword.Visible = false;
                txtPassword.Visible = false;
                btnLogin.Visible = false;
                btnRegister.Visible = false;

                HabilitarBotonesPorRol();
            }
        }

        private void HabilitarBotonesPorRol()
        {
            List<string> permisosGenerales = new List<string>();

            foreach (var permiso in user.Permisos)
            {
                permisosGenerales.Add(permiso.Split('.')?[0]);
            }

            if (permisosGenerales.Contains("Libro"))
            {
                btnLibros.Visible = true;
            }

            if (permisosGenerales.Contains("TipoSubscripcion"))
            {
                btnSubscriptionTypes.Visible = true;
            }

            //TODO
            //btnLibros.Visible = true;
            //btnMultas.Visible = true;
            //btnPrestamos.Visible = true;
            //btnMultas.Visible = true;
            //btnUsuarios.Visible = true;
            //btnRoles.Visible = true;
            //btnAuthors.Visible = true;
            //btnCategories.Visible = true;
            //btnBackup.Visible = true;
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
    }
}