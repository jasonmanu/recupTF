using BLL;
using Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
        private readonly INotificationService notificationService;
        private BookControl bookControl;
        private UsuariosControl usersControl;
        private NotifsControl notifsControl;
        private AuthorControl authorControl;
        private BackupControl backupControl;
        private CategoryControl categoryControl;
        private SubscriptionTypeControl subscriptionTypesControl;
        private RolsControl rolsControl;
        private StatsControl statsControl;
        private User user;

        public MainForm(IServiceProvider serviceProvider)
        {
            userService = serviceProvider.GetRequiredService<IUserService>();
            categoryService = serviceProvider.GetRequiredService<ICategoryService>();
            backupService = serviceProvider.GetRequiredService<IBackupService>();
            bookService = serviceProvider.GetRequiredService<IBookService>();
            authorService = serviceProvider.GetRequiredService<IAuthorService>();
            subscriptionService = serviceProvider.GetRequiredService<ISubscriptionService>();
            subscriptionTypeService = serviceProvider.GetRequiredService<ISubscriptionTypeService>();
            loanService = serviceProvider.GetRequiredService<ILoanService>();
            roleService = serviceProvider.GetRequiredService<IRoleService>();
            notificationService = serviceProvider.GetRequiredService<INotificationService>();
            user = null;
            InitializeComponent();
            HabilitarBotonesPorRol();
        }

        private void btnLibros_Click(object sender, EventArgs e)
        {
            try
            {
                ResetButtonsColors();
                btnLibros.BackColor = Color.LightBlue;
                bookControl = new BookControl(bookService, authorService, categoryService, loanService, subscriptionService, subscriptionTypeService, notificationService, userService, user);
                mainPanel.Controls.Add(bookControl);
                bookControl.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ejecutando la orden");
            }
        }

        private void btnNotificaciones_Click(object sender, EventArgs e)
        {
            try
            {
                ResetButtonsColors();
                btnNotificaciones.BackColor = Color.LightBlue;
                notifsControl = new NotifsControl(notificationService, user);
                mainPanel.Controls.Add(notifsControl);
                notifsControl.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ejecutando la orden");
            }
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            try
            {
                ResetButtonsColors();
                btnUsuarios.BackColor = Color.LightBlue;
                usersControl = new UsuariosControl(userService, roleService, user);
                mainPanel.Controls.Add(usersControl);
                usersControl.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ejecutando la orden");
            }
        }

        private void btnAuthors_Click(object sender, EventArgs e)
        {
            try
            {
                ResetButtonsColors();
                btnAuthors.BackColor = Color.LightBlue;
                authorControl = new AuthorControl(authorService, user);
                mainPanel.Controls.Add(authorControl);
                authorControl.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ejecutando la orden");
            }
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            try
            {
                ResetButtonsColors();
                btnCategories.BackColor = Color.LightBlue;
                categoryControl = new CategoryControl(categoryService, user);
                mainPanel.Controls.Add(categoryControl);
                categoryControl.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ejecutando la orden");
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            try
            {
                ResetButtonsColors();
                btnBackup.BackColor = Color.LightBlue;
                backupControl = new BackupControl(backupService, user);
                mainPanel.Controls.Add(backupControl);
                backupControl.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ejecutando la orden");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Salir de la aplicacion?", "Confirmar", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        Application.Exit();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("App finalizada");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ejecutando la orden");
            }
        }

        private void btnSubsInfo_Click(object sender, EventArgs e)
        {
            try
            {
                ResetButtonsColors();
                btnSubscriptionTypes.BackColor = Color.LightBlue;
                subscriptionTypesControl = new SubscriptionTypeControl(subscriptionTypeService, subscriptionService, user);
                mainPanel.Controls.Add(subscriptionTypesControl);
                subscriptionTypesControl.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ejecutando la orden");
            }
        }

        private void btnRoles_Click(object sender, EventArgs e)
        {
            try
            {
                ResetButtonsColors();
                btnRoles.BackColor = Color.LightBlue;
                rolsControl = new RolsControl(roleService);
                mainPanel.Controls.Add(rolsControl);
                rolsControl.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ejecutando la orden");
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text;
                string password = txtPassword.Text;

                user = userService.Login(username, password);

                if (user == null)
                {
                    MessageBox.Show("Usuario y/o contraseña no validos");
                    txtUsername.ResetText();
                }
                else
                {
                    txtUsername.Enabled = false;
                    txtPassword.Enabled = false;


                    btnLogin.Enabled = false;
                    btnRegister.Enabled = false;

                    HabilitarBotonesPorRol();
                }

                txtPassword.ResetText();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ejecutando la orden");
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text;
                string password = txtUsername.Text;

                userService.Create(new User(username, password, "cliente"));
                MessageBox.Show("Registrado Correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ejecutando la orden");
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            try
            {
                user = null;
                HabilitarBotonesPorRol();

                foreach (Control control in mainPanel.Controls.OfType<UserControl>())
                {
                    control.Visible = false;
                }

                txtUsername.Enabled = true;
                txtPassword.Enabled = true;
                txtUsername.ResetText();

                btnLogin.Enabled = true;
                btnRegister.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ejecutando la orden");
            }
        }

        private void btnEstadisticas_Click(object sender, EventArgs e)
        {
            try
            {
                ResetButtonsColors();
                btnEstadisticas.BackColor = Color.LightBlue;

                statsControl = new StatsControl(subscriptionService, subscriptionTypeService, loanService, bookService);
                mainPanel.Controls.Add(statsControl);
                statsControl.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ejecutando la orden");
            }
        }

        private void ResetButtonsColors()
        {
            try
            {
                btnLibros.BackColor = Color.LightGray;
                btnNotificaciones.BackColor = Color.LightGray;
                btnUsuarios.BackColor = Color.LightGray;
                btnSubscriptionTypes.BackColor = Color.LightGray;
                btnBackup.BackColor = Color.LightGray;
                btnAuthors.BackColor = Color.LightGray;
                btnCategories.BackColor = Color.LightGray;
                btnRoles.BackColor = Color.LightGray;
                btnEstadisticas.BackColor = Color.LightGray;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ejecutando la orden");
            }
        }

        private void HabilitarBotonesPorRol()
        {
            try
            {
                btnNotificaciones.Visible = false;
                btnLibros.Visible = false;
                btnNotificaciones.Visible = false;
                btnUsuarios.Visible = false;
                btnRoles.Visible = false;
                btnAuthors.Visible = false;
                btnCategories.Visible = false;
                btnSubscriptionTypes.Visible = false;
                btnBackup.Visible = false;
                btnEstadisticas.Visible = false;
                btnLogout.Visible = false;
                btnEstadisticas.Visible = false;
                btnLogout.Visible = true;

                if (user == null)
                {
                    return;
                }

                List<string> permisosGenerales = user?.Permisos?.Select(x => x.Split('.')?[0])?.Distinct()?.ToList() ?? new List<string>();

                if (permisosGenerales.Contains("Libro"))
                {
                    btnLibros.Visible = true;
                }

                if (permisosGenerales.Contains("TipoSubscripcion"))
                {
                    btnSubscriptionTypes.Visible = true;
                }

                if (permisosGenerales.Contains("Usuario"))
                {
                    btnUsuarios.Visible = true;
                }

                if (permisosGenerales.Contains("Autor"))
                {
                    btnAuthors.Visible = true;
                }

                if (permisosGenerales.Contains("Backup"))
                {
                    btnBackup.Visible = true;
                }

                if (permisosGenerales.Contains("Categoria"))
                {
                    btnCategories.Visible = true;
                }

                if (permisosGenerales.Contains("Notificacion"))
                {
                    btnNotificaciones.Visible = true;
                }

                if (permisosGenerales.Contains("Subscripcion"))
                {
                    btnSubscriptionTypes.Visible = true;
                }

                if (permisosGenerales.Contains("Estadisticas"))
                {
                    btnEstadisticas.Visible = true;
                }

                if (permisosGenerales.Contains("Roles"))
                {
                    btnRoles.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ejecutando la orden");
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }
    }
}
