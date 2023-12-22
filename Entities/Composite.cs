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

    //public virtual List<string> GetAllPermissions()
    //{
    //    return new List<string>(Permissions);
    //}
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

    //public override List<string> GetAllPermissions()
    //{
    //    List<string> allPermissions = base.GetAllPermissions();

    //    foreach (Role subRole in SubRoles)
    //    {
    //        List<string> subRolePermissions = subRole.GetAllPermissions();
    //        allPermissions.AddRange(subRolePermissions);
    //    }

    //    return allPermissions;
    //}
}
