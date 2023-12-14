using Entities.Enums;
using System;
using System.Xml.Serialization;

namespace Entities
{
    [Serializable]
    public class User : Entity
    {
        public User() { }

        public User(string username, string password, UserRole role)
        {
            Username = username;
            Password = password;
            Role = role;
        }

        [XmlElement("Username")]
        public string Username { get; set; }

        [XmlElement("Password")]
        public string Password { get; set; }

        [XmlElement("Role")]
        public UserRole Role { get; set; }
        
        [XmlElement("Address")]
        public string Address { get; set; }

        [XmlElement("LastLoginAt")]
        public DateTime? LastLoginAt { get; set; }

        //[XmlElement("Rol")]
        //public Rol Rol { get; set; }
    }
}
