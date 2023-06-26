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

        [XmlElement("Username")]//[XmlAttribute("username")]
        public string Username { get; set; }

        [XmlElement("Password")]
        public string Password { get; set; }

        [XmlElement("Role")]
        public UserRole Role { get; set; }
    }
}
