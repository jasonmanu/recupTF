using BLL;
using Entities;
using FormSupport;
using System;
using System.Windows.Forms;

namespace UI.Controls
{
    public partial class AuthorControl : UserControl
    {
        private readonly IAuthorService authorService;
        private readonly User user;

        public AuthorControl(IAuthorService authorService, User user)
        {
            InitializeComponent();
            this.authorService = authorService;
            this.user = user;
            LoadData();
            HabilitarBotones();
        }

        private void HabilitarBotones()
        {
            if (user.Permisos.Contains("Autor.Leer"))
            {
                btnCreate.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }

            if (user.Permisos.Contains("Autor.Crear"))
            {
                btnCreate.Enabled = true;
            }

            if (user.Permisos.Contains("Autor.Editar"))
            {
                btnUpdate.Enabled = true;
            }

            if (user.Permisos.Contains("Autor.Eliminar"))
            {
                btnDelete.Enabled = true;
            }
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
                MessageBox.Show("Error ejecutando accion");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string id = FormHelper.GetCurrentRowId(dgvAuthors);
                authorService.Update(new Author() { Id = id, Name = txtName.Text, Description = txtDescription.Text });
                MessageBox.Show("Actualizado");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ejecutando accion");
            }
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
            try
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
            catch (Exception ex)
            {
                MessageBox.Show("Error ejecutando accion");
            }
        }
    }
}
