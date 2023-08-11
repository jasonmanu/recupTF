using BLL.Contracts;
using Entities;
using FormSupport;
using System;
using System.Windows.Forms;

namespace UI
{
    public partial class frmBrand : Form
    {
        private readonly IBrandService brandService;

        public frmBrand(IBrandService brandService)
        {
            InitializeComponent();
            this.brandService = brandService;
            LoadData();
        }

        private void LoadData()
        {
            dgvData.DataSource = brandService.GetAll();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                brandService.Create(new Brand() { Name = txtName.Text });
                txtName.ResetText();
                MessageBox.Show("Creado");
                LoadData();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string id = FormHelper.GetCurrentRowId(dgvData);
                brandService.Update(new Brand() { Id = id, Name = txtName.Text });
                MessageBox.Show("Actualizado");
                LoadData();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string id = FormHelper.GetCurrentRowId(dgvData);
                brandService.Delete(id);
                MessageBox.Show("Eliminado");
                LoadData();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
