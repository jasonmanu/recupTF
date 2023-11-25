﻿using BLL.Contracts;
using Entities;
using FormSupport;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace UI
{
    public partial class frmCategories : Form
    {
        private readonly ICategoryService categoriesService;
        private readonly IServiceProvider serviceProvider;

        public frmCategories(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            this.serviceProvider = serviceProvider;
            this.categoriesService = serviceProvider.GetRequiredService<ICategoryService>();
            LoadData();
        }

        private void LoadData()
        {
            dgvCategories.DataSource = categoriesService.GetAll();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                categoriesService.Create(new Category() { Name = txtName.Text });
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
                string id = FormHelper.GetCurrentRowId(dgvCategories);
                categoriesService.Update(new Category() { Id = id, Name = txtName.Text });
                MessageBox.Show("Actualizado");
                LoadData();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string id = FormHelper.GetCurrentRowId(dgvCategories);
                categoriesService.Delete(id);
                MessageBox.Show("Eliminado");
                LoadData();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
