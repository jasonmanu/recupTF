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
        private readonly Subscription userSubscription;
        private readonly SubscriptionType userSubscriptionType;
        private readonly User user;

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

            HabilitarBotones();
            LoadBooks();
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

            foreach (Book libro in todosLosLibros)
            {
                if (misCategorias.Contains(libro.CategoryId))
                {
                    recommendedBooks.Add(libro);
                }
            }

            foreach (Book libro in todosLosLibros)
            {
                if (misAutores.Contains(libro.AuthorId))
                {
                    recommendedBooks.Add(libro);
                }
            }

            listBoxRecommendations.Items.Add($"Basado en tus prestamos, reservas y autores te recomendamos los libros");

            if (recommendedBooks.Count > 0)
            {
                foreach (string bookTitle in recommendedBooks?.Select(x => x.Title)?.Distinct()?.ToList())
                {
                    listBoxRecommendations.Items.Add($"- {bookTitle}");
                }
            }
        }

        private void HabilitarBotones()
        {
            lblLibroCbo.Visible = false;
            lblUserCbo.Visible = false;
            cboUsuario.Visible = false;
            cboLibro.Visible = false;
            btnLoan.Visible = false;
            btnEntregar.Visible = false;
            btnRecibirLibro.Visible = false;
            listBoxRecommendations.Visible = false;

            if (user.Permisos.Contains("Prestamo.Crear"))
            {
                btnLoan.Visible = true;
                listBoxRecommendations.Visible = true;
            }

            if (user.Permisos.Contains("Prestamo.Editar"))
            {
                lblLibroCbo.Visible = true;
                lblUserCbo.Visible = true;
                cboUsuario.Visible = true;
                cboLibro.Visible = true;
                btnEntregar.Visible = true;
                btnRecibirLibro.Visible = true;
            }

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
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                Book book = new Book()
                {
                    Title = txtTitle.Text,
                    Description = txtDescription.Text,
                    ISBN = txtISBN.Text,
                    Stock = (int)nudStock.Value,
                    CategoryId = (string)cboCategory.SelectedValue ?? null,
                    AuthorId = (string)cboAuthor.SelectedValue ?? null,
                };

                bookService.Create(book);
                MessageBox.Show("Libro creado correctamente");
                LoadBooks();
                txtDescription.ResetText();
                txtISBN.ResetText();
                txtTitle.ResetText();
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
                MessageBox.Show("Error ejecutando accion");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string id = FormHelper.GetCurrentRowId(dgvData);
                bookService.Delete(id);
                MessageBox.Show("eliminado correctamente");
                LoadBooks();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ejecutando accion");
            }
        }

        private void btnLoan_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Confirmar prestamo/reserva", "Confirmar", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    string bookId = FormHelper.GetCurrentRowId(dgvData);
                    Book book = bookService.GetById(bookId);

                    if (userSubscription == null)
                    {
                        MessageBox.Show("No se puede prestar/reservar libro sin subscripcion");
                        return;
                    }

                    if (book.Stock == 0)
                    {
                        loanService.Create(new Loan()
                        {
                            BookId = bookId,
                            UserId = user.Id,
                            EndDate = null,
                            StartDate = DateTime.Now,
                            PuedeRetirar = false,
                            ReturnDate = null,
                        });

                        notificationService.Create(new Notification() { Date = DateTime.Now, Message = $"Recibira notificacion cuando el libro {book.Title} este disponible", UserId = user.Id });

                        MessageBox.Show($"Reserva creada. Recibira una notificacion cuando el libro este disponible para retirar");
                    }
                    else
                    {
                        int cantidadPrestamosDelUsuario = loanService.GetAll().Count(x => x.ReturnDate != null && x.UserId == user.Id);

                        if (cantidadPrestamosDelUsuario < userSubscriptionType.MaxLoanBooks)
                        {
                            DateTime loanEndDate = DateTime.Now.AddDays(userSubscriptionType.LoanDays);

                            loanService.Create(new Loan()
                            {
                                BookId = bookId,
                                UserId = user.Id,
                                StartDate = DateTime.Now,
                                EndDate = loanEndDate,
                                PuedeRetirar = true,
                                ReturnDate = null,
                            });

                            book.Stock--;
                            bookService.Update(book);

                            notificationService.Create(new Notification() { Date = DateTime.Now, Message = $"Puede retirar su libro {book.Title}", UserId = user.Id });
                            notificationService.Create(new Notification() { Date = DateTime.Now, Message = $"Debe devolver el libro {book.Title} antes de {loanEndDate}", UserId = user.Id });
                            MessageBox.Show($"Prestamo creado. Puede retirar el libro en la biblioteca.");
                            LoadBooks();
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

        private void btnEntregar_Click(object sender, EventArgs e)
        {
            try
            {
                //entregar a cliente
                string selectedBookId = (string)cboLibro.SelectedValue;
                string selectedUserId = (string)cboUsuario.SelectedValue;
                var prestamoParaRetirar = loanService.GetAll().FirstOrDefault(x => x.UserId == selectedUserId && x.BookId == selectedBookId && x.PuedeRetirar == true);

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
            catch (Exception)
            {
                MessageBox.Show("Error ejecutando accion");
            }
        }

        private void btnRecibirLibro_Click(object sender, EventArgs e)
        {
            try
            {
                // recibir de cliente
                string selectedBookId = (string)cboLibro.SelectedValue;
                string selectedUserId = (string)cboUsuario.SelectedValue;

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

                    // aumentar stock de libro devuelto
                    book.Stock++;
                    bookService.Update(book);

                    // avisar a reserva
                    Loan reservaDelLibro = loanService.GetAll().Where(x => x.BookId == selectedBookId && x.PuedeRetirar == false && x.ReturnDate == null).OrderBy(x => x.StartDate).FirstOrDefault();

                    if (reservaDelLibro != null)
                    {
                        reservaDelLibro.StartDate = DateTime.Now;
                        reservaDelLibro.PuedeRetirar = true;

                        loanService.Update(reservaDelLibro);

                        book.Stock--;
                        bookService.Update(book);

                        notificationService.Create(new Notification() { Date = DateTime.Now, UserId = reservaDelLibro.UserId, Message = $"El libro reservado {book.Title} ya esta disponible para retirar" });
                    }

                    MessageBox.Show("Libro devuelto correctamente");
                }
                else
                {
                    MessageBox.Show("Sin libro para devolver");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error ejecutando accion");
            }
        }

        private void dgvBooks_SelectionChanged(object sender, EventArgs e)
        {
            try
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
            catch (Exception)
            {
                MessageBox.Show("Error ejecutando accion");
            }
        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cboAuthor_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
