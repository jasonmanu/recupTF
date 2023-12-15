using BLL;
using Entities;
using FormSupport;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace UI.Controls
{
    public partial class UsuariosControl : UserControl
    {
        private readonly IUserService userService;

        public UsuariosControl(IUserService userService)
        {
            this.Dock = DockStyle.Fill;
            InitializeComponent();
            this.userService = userService;
            LoadData();
        }

        private void LoadData()
        {
            var roles = new List<Role>
            {
                new Role() { Name = "ROL A" },
                new Role() { Name = "ROL B" }
            };
            cboRole.DataSource = roles;
            cboRole.DisplayMember = "Name";
            dgvData.Refresh();
            var users = userService.GetAll();
            dgvData.DataSource = users;
            //cboRole.ValueMember = "Id";// TODO add
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                userService.Create(new User()
                {
                    Username = txtName.Text,
                    Password = txtPassword.Text,
                    Address = txtAddress.Text,
                    LastLoginAt = DateTime.Now,
                    RoleName = "Cliente"
                });

                MessageBox.Show("Creado correctamente");
                LoadData();

                txtName.ResetText();
                txtAddress.ResetText();
                txtPassword.ResetText();
                txtUsername.ResetText();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string id = FormHelper.GetCurrentRowId(dgvData);

            try
            {
                var user = new User()
                {
                    Id = id,
                    Username = txtName.Text,
                    Password = txtPassword.Text,
                    Address = txtAddress.Text,
                    LastLoginAt = DateTime.Now,
                    RoleName = "Cliente"
                };

                userService.Update(user);
                MessageBox.Show("Actualizado correctamente");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = FormHelper.GetCurrentRowId(dgvData);

            try
            {
                userService.Delete(id);
                MessageBox.Show("Eliminado correctamente");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvData_SelectionChanged(object sender, EventArgs e)
        {
            string id = FormHelper.GetCurrentRowId(dgvData);
            var user = userService.GetById(id);

            if (user != null)
            {
                txtName.Text = user.Username;
                txtAddress.Text = user.Address;
                txtPassword.Text = user.Password;//TODO ocultar
                txtUsername.Text = user.Username;

                //if (user.Role != null)
                //{
                //    cboRole.SelectedValue = user.Role;//TODO elegir Id;
                //}
            }
        }
    }
}
