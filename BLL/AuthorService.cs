using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AuthorService : BaseService<Author>, IAuthorService
    {
        private readonly IAuthorRepository authorRepository;

        public AuthorService(IAuthorRepository authorRepository) : base(authorRepository)
        {
            this.authorRepository = authorRepository;
        }
    }
}
