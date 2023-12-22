using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{

    public interface IBookService : IBaseService<Book>
    {
        List<Book> GetRecommendedBooks(List<Loan> misPrestamos);
    }

    public class BookService : BaseService<Book>, IBookService
    {
        private readonly IBookRepository bookRepository;

        public BookService(IBookRepository bookRepository) : base(bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public List<Book> GetRecommendedBooks(List<Loan> misPrestamos)
        {
            List<string> misCategoriasIds = new List<string>();
            List<string> misAutoresIds = new List<string>();

            foreach (var prestamo in misPrestamos)
            {
                Book book = bookRepository.GetById(prestamo.BookId);
                misCategoriasIds.Add(book.CategoryId);
                misAutoresIds.Add(book.AuthorId);
            }

            List<Book> recommendedBooks = new List<Book>();
            var todosLosLibros = bookRepository.GetAll();

            foreach (Book libro in todosLosLibros)
            {
                if (misCategoriasIds.Contains(libro.CategoryId) && misPrestamos.Select(x => x.BookId).Contains(libro.Id) == false)
                {
                    recommendedBooks.Add(libro);
                }
            }

            foreach (Book libro in todosLosLibros)
            {
                if (misAutoresIds.Contains(libro.AuthorId) && misPrestamos.Select(x => x.BookId).Contains(libro.Id) == false)
                {
                    recommendedBooks.Add(libro);
                }
            }

            return recommendedBooks;
        }
    }
}
