// Clase base para roles
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

[XmlInclude(typeof(SimpleRole))]
[XmlInclude(typeof(CompositeRole))]
[Serializable]
public class Role
{
    public string Name { get; set; }
    public List<string> Permissions { get; set; }

    public Role()
    {
        Permissions = new List<string>();
    }
}

// Clase para roles simples
[Serializable]
public class SimpleRole : Role { }

// Clase para roles compuestos
[Serializable]
public class CompositeRole : Role
{
    public List<Role> SubRoles { get; set; }

    public CompositeRole()
    {
        SubRoles = new List<Role>();
    }
}

// Clase para gestionar los roles y la serialización XML
public class RoleManager
{
    private List<Role> roles;

    public RoleManager()
    {
        roles = new List<Role>();
    }

    public void AddRole(Role role)
    {
        roles.Add(role);
    }

    public void SaveRolesToXml(string filePath = "roles.xml")
    {
        using (var writer = new StreamWriter(filePath))
        {
            var serializer = new XmlSerializer(typeof(List<Role>), new Type[] { typeof(SimpleRole), typeof(CompositeRole) });
            serializer.Serialize(writer, roles);
        }
    }

    public void LoadRolesFromXml(string filePath = "roles.xml")
    {
        using (var reader = new StreamReader(filePath))
        {
            var serializer = new XmlSerializer(typeof(List<Role>), new Type[] { typeof(SimpleRole), typeof(CompositeRole) });
            roles = (List<Role>)serializer.Deserialize(reader);
        }
    }

    private void DisplayRolePermissionsRecursive(Role role, int depth)
    {
        Console.WriteLine(new string('-', depth) + $"Permissions for role '{role.Name}':");

        foreach (var permission in role.Permissions)
        {
            Console.WriteLine(new string('-', depth + 1) + $"- {permission}");
        }

        if (role is CompositeRole compositeRole)
        {
            foreach (var subRole in compositeRole.SubRoles)
            {
                DisplayRolePermissionsRecursive(subRole, depth + 1);
            }
        }
    }

    public void DisplayRolePermissions(Role role)
    {
        DisplayRolePermissionsRecursive(role, 0);
    }
}