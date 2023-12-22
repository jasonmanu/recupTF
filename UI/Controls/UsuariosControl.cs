using BLL;
using Entities;
using FormSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace UI.Controls
{
    public partial class UsuariosControl : UserControl
    {
        private readonly IUserService userService;
        private readonly IRoleService roleService;
        private readonly User user;

        public UsuariosControl(IUserService userService, IRoleService roleService, User user)
        {
            this.Dock = DockStyle.Fill;
            InitializeComponent();
            this.userService = userService;
            this.roleService = roleService;
            this.user = user;
            LoadData();
            HabilitarBotones();
        }

        private void HabilitarBotones()
        {
            if (user.Permisos.Contains("Usuario.Leer"))
            {
                btnCreate.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }

            if (user.Permisos.Contains("Usuario.Crear"))
            {
                btnCreate.Enabled = true;
            }

            if (user.Permisos.Contains("Usuario.Editar"))
            {
                btnUpdate.Enabled = true;
            }

            if (user.Permisos.Contains("Usuario.Eliminar"))
            {
                btnDelete.Enabled = true;
            }
        }

        private void LoadData()
        {
            List<Role> roles = roleService.GetAll().Where(x => x.Id != null).ToList();
            cboRole.DataSource = roles;
            cboRole.DisplayMember = "Name";
            cboRole.ValueMember = "Name";

            dgvData.Refresh();
            List<User> users = userService.GetAll();
            dgvData.DataSource = users;
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
                    RoleName = ((Role)cboRole.SelectedItem).Name,
                    IsActive = true,
                });

                MessageBox.Show("Creado correctamente");
                LoadData();

                txtName.ResetText();
                txtAddress.ResetText();
                txtPassword.ResetText();
                lblUsername.ResetText();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ejecutando accion");
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
                    RoleName = ((Role)cboRole.SelectedItem).Name,
                };

                userService.Update(user);
                MessageBox.Show("Actualizado correctamente");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ejecutando accion");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = FormHelper.GetCurrentRowId(dgvData);

            try
            {
                User user = userService.GetById(id);
                user.IsActive = false;
                userService.Update(user);
                MessageBox.Show("Eliminado correctamente");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ejecutando accion");
            }
        }

        private void dgvData_SelectionChanged(object sender, EventArgs e)
        {
            string userId = FormHelper.GetCurrentRowId(dgvData);
            var user = userService.GetById(userId);

            if (user != null)
            {
                txtName.Text = user.Username;
                txtAddress.Text = user.Address;
                txtPassword.Text = CryptoHelper.Decrypt(user.Password);
                cboRole.SelectedValue = user.RoleName;
            }
        }

        private void cboRole_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
