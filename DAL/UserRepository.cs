using Entities;
using System.Linq;
using System.Xml.Linq;

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
    }
}
