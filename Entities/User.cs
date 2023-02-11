using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Entities
{
    [Serializable]
    //[Serializable, XmlRoot("users")]
    public class User : Entity
    {
        public User(string username, string password, UserRole role)
        {
            Username = username;
            Password = password;
            Role = role;
        }

        public User()
        {
        }

        //[XmlAttribute("username")]
        [XmlElement("username")]
        public string Username { get; set; }

        [XmlElement("password")]
        public string Password { get; set; }

        [XmlElement("role")]
        public UserRole Role { get; set; }
    }

    [XmlRoot("users")]
    public class UserRootXml
    {
        public UserRootXml()
        {
            Users = new List<User>();
        }

        [XmlElement("user")]
        public List<User> Users { get; set; }
    }
}
