using BLL;
using Entities;
using FormSupport;
using System;
using System.Windows.Forms;

namespace UI.Controls
{
    public partial class CategoryControl : UserControl
    {
        private readonly ICategoryService categoryService;
        private readonly User user;

        public CategoryControl(ICategoryService categoryService, User user)
        {
            this.categoryService = categoryService;
            this.user = user;
            InitializeComponent();
            LoadData();
            HabilitarBotones();
        }

        private void HabilitarBotones()
        {
            if (user.Permisos.Contains("Categoria.Leer"))
            {
                btnCreate.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }

            if (user.Permisos.Contains("Categoria.Crear"))
            {
                btnCreate.Enabled = true;
            }

            if (user.Permisos.Contains("Categoria.Editar"))
            {
                btnUpdate.Enabled = true;
            }

            if (user.Permisos.Contains("Categoria.Eliminar"))
            {
                btnDelete.Enabled = true;
            }
        }

        private void LoadData()
        {
            try
            {
                dgvData.DataSource = categoryService.GetAll();
            }
            catch (Exception)
            {
                MessageBox.Show("Error ejecutando accion");
            }
        }

        private void dgvData_SelectionChanged(object sender, EventArgs e)
        {
            string id = FormHelper.GetCurrentRowId(dgvData);
            Category category = categoryService.GetById(id);

            if (category != null)
            {
                txtName.Text = category.Name;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                Category newCategory = new Category() { Name = txtName.Text };
                categoryService.Create(newCategory);
                MessageBox.Show("creado");
                LoadData();
            }
            catch (Exception)
            {
                MessageBox.Show("Error ejecutando accion");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string id = FormHelper.GetCurrentRowId(dgvData);
                categoryService.Delete(id);
                MessageBox.Show("eliminado");
                LoadData();
            }
            catch (Exception)
            {
                MessageBox.Show("Error ejecutando accion");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string id = FormHelper.GetCurrentRowId(dgvData);
                categoryService.Update(new Category() { Id = id, Name = txtName.Text });
                MessageBox.Show("actualizado");
                LoadData();
            }
            catch (Exception)
            {
                MessageBox.Show("Error ejecutando accion");
            }
        }
    }
}
