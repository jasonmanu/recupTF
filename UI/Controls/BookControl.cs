using BLL;
using Entities;
using FormSupport;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace UI.Controls
{
    public partial class BookControl : UserControl
    {
        private readonly IBookService bookService;
        private readonly IAuthorService authorService;
        private readonly ICategoryService categoryService;
        private readonly ILoanService loanService;
        private readonly ISubscriptionService subscriptionService;
        private readonly ISubscriptionTypeService subscriptionTypeService;
        private readonly INotificationService notificationService;
        private readonly IUserService userService;
        private readonly User user;
        private readonly Subscription userSubscription;
        private readonly SubscriptionType userSubscriptionType;

        public BookControl(IBookService bookService, IAuthorService authorService, ICategoryService categoryService, ILoanService loanService, ISubscriptionService subscriptionService, ISubscriptionTypeService subscriptionTypeService, INotificationService notificationService, IUserService userService, User loggedUser)
        {
            Dock = DockStyle.Fill;
            this.bookService = bookService;
            this.authorService = authorService;
            this.categoryService = categoryService;
            this.loanService = loanService;
            this.subscriptionService = subscriptionService;
            this.subscriptionTypeService = subscriptionTypeService;
            this.notificationService = notificationService;
            this.userService = userService;
            this.user = loggedUser;
            InitializeComponent();

            userSubscription = subscriptionService.GetAll().FirstOrDefault(x => x.UserId == loggedUser?.Id);
            userSubscriptionType = subscriptionTypeService.GetById(userSubscription?.SubscriptionTypeId);

            LoadBooks();
            HabilitarBotones();
            LoadUsers();
            LoadBooksCombobox();
        }

        private void LoadBooksCombobox()
        {
            cboLibro.DataSource = bookService.GetAll();
            cboLibro.DisplayMember = "Title";
            cboLibro.ValueMember = "Id";
        }

        private void LoadUsers()
        {
            cboUsuario.DataSource = userService.GetAll();
            cboUsuario.DisplayMember = "Username";
            cboUsuario.ValueMember = "Id";
        }

        private void HabilitarBotones()
        {
            listBoxRecommendations.Visible = false;

            if (user.RoleName == "Cliente")
            {
                listBoxRecommendations.Visible = true;
            }

            //tlpCrud.Visible = true;
            //tlpCrud.Enabled = true;
            //tlpCrudBotones.Visible = true;
            //tlpCrudBotones.Enabled = true;

            btnLoan.Enabled = false;

            if (user.Permisos.Contains("Libro.Leer"))
            {
                tlpCrud.Enabled = false;
                tlpCrudBotones.Visible = false;
            }

            if (user.Permisos.Contains("Libro.Crear"))
            {
                tlpCrud.Enabled = true;
                tlpCrudBotones.Visible = true;
                btnCreate.Visible = true;
            }

            if (user.Permisos.Contains("Libro.Editar"))
            {
                tlpCrud.Enabled = true;
                tlpCrudBotones.Visible = true;
                btnUpdate.Visible = true;
            }

            if (user.Permisos.Contains("Libro.Eliminar"))
            {
                tlpCrud.Enabled = true;
                tlpCrudBotones.Visible = true;
                btnDelete.Visible = true;
            }

            if (user.Permisos.Contains("Libro.Eliminar"))
            {
                btnLoan.Enabled = true;
            }
        }

        private void LoadBooks()
        {
            dgvData.Refresh();
            dgvData.DataSource = bookService.GetAll();

            cboAuthor.DataSource = authorService.GetAll();
            cboAuthor.DisplayMember = "Name";
            cboAuthor.ValueMember = "Id";

            cboCategory.DataSource = categoryService.GetAll();
            cboCategory.DisplayMember = "Name";
            cboCategory.ValueMember = "Id";

            listBoxRecommendations.Items.Clear();

            List<Loan> misPrestamos = loanService.GetAll().Where(x => x.UserId == user.Id).ToList();
            List<string> misCategorias = new List<string>();
            List<string> misAutores = new List<string>();

            foreach (var prestamo in misPrestamos)
            {
                Book book = bookService.GetById(prestamo.BookId);
                misCategorias.Add(book.CategoryId);
                Category category = categoryService.GetById(book.CategoryId);
                misAutores.Add(book.AuthorId);
            }

            List<Book> recommendedBooks = new List<Book>();
            var todosLosLibros = bookService.GetAll();

            foreach (var libro in todosLosLibros)
            {
                if (misCategorias.Contains(libro.CategoryId))
                {
                    recommendedBooks.Add(libro);
                }
            }

            foreach (var libro in todosLosLibros)
            {
                if (misAutores.Contains(libro.AuthorId))
                {
                    recommendedBooks.Add(libro);
                }
            }

            listBoxRecommendations.Items.Add($"Basado en tus prestamos, reservas y autores te recomendamos los libros");

            foreach (var book in recommendedBooks)
            {
                listBoxRecommendations.Items.Add($"- {book.Title}");
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Book book = new Book()
            {
                Title = txtTitle.Text,
                Description = txtDescription.Text,
                ISBN = txtISBN.Text,
                Stock = (int)nudStock.Value,
                CategoryId = (string)cboCategory.SelectedValue ?? null,
                AuthorId = (string)cboAuthor.SelectedValue ?? null,
                //CollectionId = (string)cboCollection.SelectedValue ?? null,
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
                    Stock = (int)nudStock.Value,
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
                nudStock.Value = book.Stock;

                if (book.AuthorId != null)
                {
                    cboAuthor.SelectedValue = book.AuthorId;
                }

                if (book.CategoryId != null)
                {
                    cboCategory.SelectedValue = book.CategoryId;
                }

                if (book.Stock == 0)
                {
                    btnLoan.Text = "Crear reserva";
                }
                else
                {
                    btnLoan.Text = "Iniciar prestamo";
                }
            }
        }

        private void btnLoan_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Confirmar prestamo/reserva", "Confirmar", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                string bookId = FormHelper.GetCurrentRowId(dgvData);

                try
                {
                    Book book = bookService.GetById(bookId);

                    if (userSubscription == null)
                    {
                        MessageBox.Show("No se puede prestar/reservar libro sin subscripcion");
                    }

                    if (book.Stock == 0)
                    {
                        //crea reserva
                        loanService.Create(new Loan()
                        {
                            BookId = bookId,
                            UserId = user.Id,
                            EndDate = null,
                            StartDate = DateTime.Now,
                            PuedeRetirar = false,
                            ReturnDate = null,
                        });

                        MessageBox.Show($"Reserva creada. Recibira una notificacion cuando el libro este disponible para retirar");
                    }
                    else
                    {
                        int cantidadPrestamosDelUsuario = loanService.GetAll().Count(x => x.ReturnDate != null && x.UserId == user.Id);

                        if (cantidadPrestamosDelUsuario < userSubscriptionType.MaxLoanBooks)
                        {
                            DateTime loanEndDate = DateTime.Now.AddDays(userSubscriptionType.LoanDays);

                            // crea prestamo
                            loanService.Create(new Loan()
                            {
                                BookId = bookId,
                                UserId = user.Id,
                                StartDate = DateTime.Now,
                                EndDate = loanEndDate,
                                PuedeRetirar = true,
                                ReturnDate = null,
                            });

                            book.Stock = book.Stock - 1;
                            bookService.Update(book);

                            notificationService.Create(new Notification() { Date = DateTime.Now, Message = $"Puede retirar su libro {book.Title}", UserId = user.Id });
                            notificationService.Create(new Notification() { Date = DateTime.Now, Message = $"Debe devolver el libro {book.Title} antes de {loanEndDate}", UserId = user.Id });
                            MessageBox.Show($"Prestamo creado. Puede retirar el libro en la biblioteca.");
                        }
                        else
                        {
                            MessageBox.Show("No puedes superar tu maximo de libros prestados por tu tipo de subscripcion");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Prestamo/Reserva cancelado");
            }
        }

        private void btnReserve_Click(object sender, EventArgs e)
        {
            // reserva si no hay libros libres para prestar, como hacer si no devolvieron el libro y vien alguien a buscarlo? solo puede reservar si el libro esta disponible
        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cboAuthor_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnEntregar_Click(object sender, EventArgs e)
        {
            //entregar a cliente
            string selectedBookId = (string)cboLibro.SelectedValue;
            string selectedUserId = (string)cboLibro.SelectedValue;
            Loan prestamoParaRetirar = loanService.GetAll().FirstOrDefault(x => x.UserId == selectedUserId && x.BookId == selectedBookId && x.PuedeRetirar == true);

            if (prestamoParaRetirar != null)
            {
                prestamoParaRetirar.PuedeRetirar = false;
                loanService.Update(prestamoParaRetirar);
                MessageBox.Show("Retirado correcto, puede entregar libro");
            }
            else
            {
                MessageBox.Show("No se encontró prestamo para retirar");
            }
        }

        private void btnRecibirLibro_Click(object sender, EventArgs e)
        {
            // recibir de cliente
            string selectedBookId = (string)cboLibro.SelectedValue;
            string selectedUserId = (string)cboLibro.SelectedValue;
            Book book = bookService.GetById(selectedBookId);
            Loan prestamoARecibir = loanService.GetAll().FirstOrDefault(x => x.UserId == selectedUserId && x.BookId == selectedBookId && x.ReturnDate == null);

            if (prestamoARecibir != null)
            {
                DateTime currentDate = DateTime.Now;

                if (currentDate > prestamoARecibir.EndDate)
                {
                    // cobrar multa
                    TimeSpan diferencia = (TimeSpan)(currentDate - prestamoARecibir.EndDate);
                    int diferenciaEnDias = (int)diferencia.TotalDays;
                    int multaPorDia = 5;
                    MessageBox.Show($"Multa es de ${diferenciaEnDias * multaPorDia}");
                }

                // setear return date
                prestamoARecibir.ReturnDate = DateTime.Now;
                loanService.Update(prestamoARecibir);
                MessageBox.Show("Libro devuelto correctamente");
            }

            // aumentar stock
            book.Stock = book.Stock + 1;
            bookService.Update(book);

            // avisar a reserva
            Loan reservaDelLibro = loanService.GetAll().Where(x => x.BookId == selectedBookId).OrderBy(x => x.StartDate).FirstOrDefault();

            if (reservaDelLibro != null)
            {
                reservaDelLibro.StartDate = DateTime.Now;
                reservaDelLibro.EndDate = DateTime.Now.AddDays(userSubscriptionType.LoanDays);
                reservaDelLibro.PuedeRetirar = true;

                loanService.Update(reservaDelLibro);

                book.Stock = book.Stock - 1;
                bookService.Update(book);

                notificationService.Create(new Notification() { Date = DateTime.Now, UserId = reservaDelLibro.UserId, Message = $"El libro reservado {book.Title} ya esta disponible para retirar" });
            }
        }
    }
}
