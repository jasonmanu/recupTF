using Entities;
using System.Linq;
using System.Xml.Linq;

public class LoginDto
{
    public string Username { get; set; }
    public string Password { get; set; }
}

namespace DAL
{
    public class UserRepository : XmlRepository<User>, IUserRepository
    {
        public User GetByUsername(string username)
        {
            XElement element = _xmlDocument.Descendants(typeof(User).Name).FirstOrDefault(e => e.Element("Username").Value == username);

            if (element != null)
            {
                return Deserialize<User>(element);
            }

            return null;
        }

        public User Login(LoginDto loginDto)
        {
            XElement element = _xmlDocument.Descendants(typeof(User).Name).FirstOrDefault(e => e.Element("Username").Value == loginDto.Username && e.Element("Password").Value == loginDto.Password);

            if (element != null)
            {
                return Deserialize<User>(element);
            }

            return null;
        }
    }
}
