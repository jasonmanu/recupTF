using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public enum UserRole
    {
        ADMIN,
        SELLER,
        SHOPPER
    }

    public class User : Entity
    {
        public User(string username, string password, UserRole role)
        {
            Username = username;
            Password = password;
            Role = role;
        }

        public string GetFullName() {
            return Fullname;
        }

        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
    }
}
