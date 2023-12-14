using BLL;
using Entities;
using Entities.Enums;
using FormSupport;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace UI.Controls
{
    public partial class UsuariosControl : UserControl
    {
        private readonly IUserService userService;

        public UsuariosControl(IUserService userService)// IRoleService
        {
            this.Dock = DockStyle.Fill;
            InitializeComponent();
            this.userService = userService;
            LoadData();

            //Series series = new Series("Sample Series");

            //// Add data points to the series
            //series.Points.AddXY("Category A", 10);
            //series.Points.AddXY("Category B", 20);
            //series.Points.AddXY("Category C", 15);
            //series.Points.AddXY("Category D", 25);

            //// Add the series to the chart
            //chart.Series.Add(series);

            //// Set chart title
            //chart.Titles.Add("Sample Chart");

            //// Set chart area axis labels
            //chart.ChartAreas[0].AxisX.Title = "Categories";
            //chart.ChartAreas[0].AxisY.Title = "Values";

            //// Customize the chart appearance as needed
            //// For example, you can set the chart type, colors, etc.
            //series.ChartType = SeriesChartType.Column;
            //series.Color = System.Drawing.Color.Blue;
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
                    Role = UserRole.ADMIN,
                    LastLoginAt = DateTime.Now,
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
                    Role = UserRole.ADMIN,
                    LastLoginAt = DateTime.Now,
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
