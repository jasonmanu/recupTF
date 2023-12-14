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
    public partial class CollectionControl : UserControl
    {
        private readonly ICollectionService collectionService;

        public CollectionControl(ICollectionService collectionService)
        {
            InitializeComponent();
            this.collectionService = collectionService;
            LoadData();
        }

        private void LoadData()
        {
            dgvData.DataSource = collectionService.GetAll();
        }

        private void dgvData_SelectionChanged(object sender, EventArgs e)
        {
            string id = FormHelper.GetCurrentRowId(dgvData);
            Collection collection = collectionService.GetById(id);

            if (collection != null)
            {
                txtName.Text = collection.Name;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Collection collection = new Collection() { Name = txtName.Text };
            collectionService.Create(collection);
            MessageBox.Show("creado");
            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = FormHelper.GetCurrentRowId(dgvData);
            collectionService.Delete(id);
            MessageBox.Show("eliminado");
            LoadData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string id = FormHelper.GetCurrentRowId(dgvData);
            collectionService.Update(new Collection() { Id = id, Name = txtName.Text });
            MessageBox.Show("actualizado");
            LoadData();
        }
    }
}
