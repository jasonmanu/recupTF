using Entities;
using System.Linq;

namespace DAL
{
    public class UserRepository : XmlRepository<User>, IUserRepository
    {
        public User GetByUsername(string username)
        {
            return GetAll().FirstOrDefault(x => x.Username == username);
        }
    }
}
