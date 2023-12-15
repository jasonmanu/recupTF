using System;
using System.Xml.Serialization;

namespace Entities
{
    [Serializable]
    public class User : Entity
    {
        public User() { }

        public User(string username, string password, string roleName)
        {
            Username = username;
            Password = password;
            RoleName = roleName;
        }

        [XmlElement("Username")]
        public string Username { get; set; }

        [XmlElement("Password")]
        public string Password { get; set; }

        [XmlElement("RoleName")]
        public string RoleName { get; set; }

        [XmlElement("Address")]
        public string Address { get; set; }

        [XmlElement("LastLoginAt")]
        public DateTime? LastLoginAt { get; set; }

        public Role Rol { get; set; }
    }
}
