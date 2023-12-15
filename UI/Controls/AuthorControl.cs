﻿using BLL;
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
    public partial class AuthorControl : UserControl
    {
        private readonly IAuthorService authorService;

        public AuthorControl(IAuthorService authorService)
        {
            InitializeComponent();
            this.authorService = authorService;
            LoadData();
        }

        private void LoadData()
        {
            dgvAuthors.DataSource = authorService.GetAll();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                authorService.Create(new Author() { Description = txtDescription.Text, Name = txtName.Text });
                MessageBox.Show("Autor creado correctamente");
                LoadData();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string id = FormHelper.GetCurrentRowId(dgvAuthors);
                //Product toUpdate = new Product()
                //{
                //    Id = id,
                //    Name = txtName.Text,
                //    BrandId = (string)cboBrand.SelectedValue,
                //    CategoryId = (string)cboCategory.SelectedValue,
                //    Description = txtDescription.Text,
                //    Price = Convert.ToInt32(nudPrice.Value)
                //};
                authorService.Update(new Author() { Id = id, Name = txtName.Text, Description = txtDescription.Text });
                MessageBox.Show("Actualizado");
                LoadData();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dgvAuthors_SelectionChanged(object sender, EventArgs e)
        {
            string id = FormHelper.GetCurrentRowId(dgvAuthors);
            Author author = authorService.GetById(id);

            if (author != null)
            {
                txtDescription.Text = author.Description;
                txtName.Text = author.Name;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = FormHelper.GetCurrentRowId(dgvAuthors);

            if (id != null)
            {
                authorService.Delete(id);
                LoadData();
            }
            else
            {
                MessageBox.Show("Seleccione fila a actualizar");
            }
        }
    }
}