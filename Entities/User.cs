﻿using System;
using System.Collections.Generic;
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

        [XmlElement("IsActive")]
        public bool IsActive { get; set; }

        public List<string> Permisos { get; set; }
    }
}
