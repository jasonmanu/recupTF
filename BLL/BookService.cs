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
    }

    public class BookService : BaseService<Book>, IBookService
    {
        public BookService(IBookRepository bookRepository) : base(bookRepository)
        {
        }
    }
}
