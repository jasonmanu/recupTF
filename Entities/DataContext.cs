using System.Collections.Generic;
using System.Xml.Serialization;

namespace Entities
{
    [XmlRoot("root")]
    public class DataContext
    {
        public DataContext()
        {
            UsersRoot = new UsersRoot();
        }

        [XmlElement("Authors")]
        public AuthorsRoot AuthorsRoot { get; set; }

        [XmlElement("Backups")]
        public BackupsRoot BackupsRoot { get; set; }

        [XmlElement("Books")]
        public BooksRoot BooksRoot { get; set; }

        [XmlElement("Categories")]
        public CategoriesRoot CategoriesRoot { get; set; }

        [XmlElement("Loans")]
        public LoansRoot LoansRoot { get; set; }

        [XmlElement("Users")]
        public UsersRoot UsersRoot { get; set; }
    }

    public class LoansRoot
    {
        public LoansRoot()
        {
        }

        [XmlElement("Loan")]
        public List<Loan> Loans { get; set; }
    }

    public class BackupsRoot
    {
        public BackupsRoot()
        {
        }

        [XmlElement("Backup")]
        public List<Backup> Backups { get; set; }
    }

    public class AuthorsRoot
    {
        public AuthorsRoot()
        {
        }

        [XmlElement("Author")]
        public List<Author> Authors { get; set; }
    }

    public class BooksRoot
    {
        public BooksRoot()
        {
        }

        [XmlElement("Book")]
        public List<Book> Books { get; set; }
    }

    public class CategoriesRoot
    {
        public CategoriesRoot()
        {
        }

        [XmlElement("Category")]
        public List<Category> Categories { get; set; }
    }

    public class UsersRoot
    {
        public UsersRoot()
        {
        }

        [XmlElement("User")]
        public List<User> Users { get; set; }
    }
}
