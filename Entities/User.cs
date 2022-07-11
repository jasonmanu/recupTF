using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entities
{
    public enum UserRole
    {
        ADMIN,
        SELLER,
        SHOPPER
    }

    [Serializable]
    public class User : Entity
    {
        public User()
        {
        }

        public User(string username, string password, UserRole role)
        {
            Username = username;
            Password = password;
            Role = role;
        }

        public string Username { get; set; }

        public string Password { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public UserRole Role { get; set; }
    }
}
