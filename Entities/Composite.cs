using Entities;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

[XmlInclude(typeof(SimpleRole))]
[XmlInclude(typeof(CompositeRole))]
[Serializable]
public class Role : Entity
{
    public string Name { get; set; }
    public List<string> Permissions { get; set; }

    public Role()
    {
        Permissions = new List<string>();
    }
}

[Serializable]
public class SimpleRole : Role { }

[Serializable]
public class CompositeRole : Role
{
    public List<Role> SubRoles { get; set; }

    public CompositeRole()
    {
        SubRoles = new List<Role>();
    }
}
