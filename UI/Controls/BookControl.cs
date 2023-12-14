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
    public partial class BookControl : UserControl
    {
        private readonly IBookService bookService;
        private readonly IAuthorService authorService;
        private readonly ICollectionService collectionService;
        private readonly ICategoryService categoryService;
        private readonly ILoanService loanService;

        public BookControl(IBookService bookService, IAuthorService authorService, ICollectionService collectionService, ICategoryService categoryService, ILoanService loanService)//, Rol rol = null)
        {
            this.Dock = DockStyle.Fill;
            this.bookService = bookService;
            this.authorService = authorService;
            this.collectionService = collectionService;
            this.categoryService = categoryService;
            this.loanService = loanService;

            InitializeComponent();
            LoadBooks();
            //btnCreate.Visible = TienePermiso(rol, TipoPermiso.Crear);
            //btnUpdate.Visible = TienePermiso(rol, TipoPermiso.Editar);
            //btnDelete.Visible = TienePermiso(rol, TipoPermiso.Eliminar);
        }

        //private bool TienePermiso(Rol rol, TipoPermiso tipoPermiso)
        //{
        //    return rol.Permisos.Any(p => p.TipoPermiso == tipoPermiso) ||
        //        (rol is RolCompuesto rolCompuesto &&
        //         rolCompuesto.Roles.Any(subRol => TienePermiso(subRol, tipoPermiso)));
        //}

        private void LoadBooks()
        {
            dgvData.Refresh();
            dgvData.DataSource = bookService.GetAll();
            //dgvBooks.Columns["Id"].Visible = false;
            //dgvBooks.Columns["BrandId"].Visible = false;
            //dgvBooks.Columns["CategoryId"].Visible = false;
            //dgvBooks.Columns["Name"].DisplayIndex = 0;
            //dgvBooks.Columns["Description"].DisplayIndex = 1;
            //dgvBooks.Columns["Price"].DisplayIndex = 2;
            //dgvBooks.Columns["BrandName"].DisplayIndex = 3;
            //dgvBooks.Columns["CategoryName"].DisplayIndex = 4;

            cboAuthor.DataSource = authorService.GetAll();
            cboAuthor.DisplayMember = "Name";
            cboAuthor.ValueMember = "Id";

            cboCategory.DataSource = categoryService.GetAll();
            cboCategory.DisplayMember = "Name";
            cboCategory.ValueMember = "Id";

            cboCollection.DataSource = collectionService.GetAll();
            cboCollection.DisplayMember = "Name";
            cboCollection.ValueMember = "Id";

            var userId = "1";
            var loanBooks = loanService.GetAll().Where(x => x.UserId == userId).ToList();


            var categories = new List<string>();
            foreach (var item in loanBooks)
            {
                var book = bookService.GetById(item.BookId);
                var category = categoryService.GetById(book.CategoryId);
            }

            List<Book> recommendedBooks = new List<Book>();
            listBoxRecommendations.Items.Add($"Basado en tus prestamos, reservas, colecciones y autores te recomendamos los libros");
            foreach (var book in recommendedBooks)
            {
                listBoxRecommendations.Items.Add($"- {book.Title}");
            }


            //var myReservations = reservationService.GetAll();
        }

        // Load Cbo in Enum
        // cboType.DataSource = Enum.GetValues(typeof(DiscountTypeEnum));
        // currentDiscount.Type = (DiscountTypeEnum)cboType.SelectedValue;
        // read checbox: currentDiscount.Active = checkActive.Checked;


        private void btnCreate_Click(object sender, EventArgs e)
        {
            Book book = new Book()
            {
                Title = txtTitle.Text,
                Description = txtDescription.Text,
                ISBN = txtISBN.Text,
                Stock = (int)nudPrice.Value,
                CategoryId = (string)cboCategory.SelectedValue ?? null,
                AuthorId = (string)cboAuthor.SelectedValue ?? null,
                CollectionId = (string)cboCollection.SelectedValue ?? null,
            };

            bookService.Create(book);
            MessageBox.Show("Libro creado correctamente");
            LoadBooks();
            txtDescription.ResetText();
            txtISBN.ResetText();
            txtTitle.ResetText();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = FormHelper.GetCurrentRowId(dgvData);

            try
            {
                bookService.Delete(id);
                MessageBox.Show("eliminado correctamente");
                LoadBooks();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string id = FormHelper.GetCurrentRowId(dgvData);

            try
            {
                Book book = new Book()
                {
                    Description = txtDescription.Text,
                    ISBN = txtISBN.Text,
                    Stock = (int)nudPrice.Value,
                    CollectionId = (string)cboCollection.SelectedValue,
                    CategoryId = (string)cboCategory.SelectedValue,
                    AuthorId = (string)cboAuthor.SelectedValue,
                    Title = txtTitle.Text,
                    Id = id
                };

                bookService.Update(book);
                MessageBox.Show("Actualizado correctamente");
                LoadBooks();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void dgvBooks_SelectionChanged(object sender, EventArgs e)
        {
            string id = FormHelper.GetCurrentRowId(dgvData);
            Book book = bookService.GetById(id);

            if (book != null)
            {
                txtDescription.Text = book.Description;
                txtISBN.Text = book.ISBN;
                txtTitle.Text = book.Title;

                if (book.AuthorId != null)
                {
                    cboAuthor.SelectedValue = book.AuthorId;
                }

                if (book.CategoryId != null)
                {
                    cboCategory.SelectedValue = book.CategoryId;
                }

                if (book.CollectionId != null)
                {
                    cboCollection.SelectedValue = book.CollectionId;
                }
            }
        }

        private void btnLoan_Click(object sender, EventArgs e)
        {
            string id = FormHelper.GetCurrentRowId(dgvData);
            //TODO: get user id
            string userId = "1";

            try
            {
                loanService.Create(new Loan()
                {
                    BookId = id,
                    UserId = userId
                });

                //TODO: crear notificacion
                MessageBox.Show($"Prestamo confirmado");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnReserve_Click(object sender, EventArgs e)
        {
            // reserva si no hay libros libres para prestar, como hacer si no devolvieron el libro y vien alguien a buscarlo? solo puede reservar si el libro esta disponible
        }
    }
}
