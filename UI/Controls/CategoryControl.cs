using BLL;
using Entities;
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

namespace UI.Controls
{
    public partial class CategoryControl : UserControl
    {
        private readonly ICategoryService categoryService;

        public CategoryControl(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            dgvData.DataSource = categoryService.GetAll();
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
            Category newCategory = new Category() { Name = txtName.Text };
            categoryService.Create(newCategory);
            MessageBox.Show("creado");
            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = FormHelper.GetCurrentRowId(dgvData);
            categoryService.Delete(id);
            MessageBox.Show("eliminado");
            LoadData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string id = FormHelper.GetCurrentRowId(dgvData);
            categoryService.Update(new Category() { Id = id, Name = txtName.Text });
            MessageBox.Show("actualizado");
            LoadData();
        }
    }
}
