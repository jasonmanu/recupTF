using BLL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace UI.Controls
{
    public partial class RolsControl : UserControl
    {
        //protected static readonly string appFolderPath = AppDomain.CurrentDomain.BaseDirectory;
        //protected readonly string _filePath = Path.Combine(appFolderPath, "roles.xml");
        //private CompositeRole newCompositeRole;
        //private TreeNode selectedTreeNode;
        //private RoleManager rolManager;
        private Role selectedRole;
        private readonly IRoleService roleService;

        public RolsControl(IRoleService roleService)
        {
            InitializeComponent();
            this.roleService = roleService;
            CargarPermisosPredefinidos();
            CargarRolesExistentes();
            //selectedTreeNode = new TreeNode();
        }
        private void CargarPermisosPredefinidos()
        {
            List<string> features = new List<string>() { "Libro", "Usuario", "Autor" };
            List<string> permisos = new List<string>() { "Crear", "Leer", "Editar", "Eliminar" };
            List<string> permisosSueltos = new List<string>();
            List<SimpleRole> entidadesPermisos = new List<SimpleRole>();

            foreach (string feature in features)
            {
                SimpleRole rolFeature = new SimpleRole() { Name = $"Gestion.{feature}" };
                TreeNode treeNode = new TreeNode($"Gestion.{feature}");

                foreach (string permiso in permisos)
                {
                    string permisoSuelto = $"{feature}.{permiso}";

                    // agregar a todos los roles disponibles
                    permisosSueltos.Add(permisoSuelto);
                    treeViewAvailable.Nodes.Add(permisoSuelto);

                    // agregar a rol compuesto sin agregar al arbol
                    rolFeature.Permissions.Add(permisoSuelto);
                    entidadesPermisos.Add(rolFeature);
                    treeNode.Nodes.Add(permisoSuelto);
                }

                // agregar rol compuesto al arbol
                treeViewAvailable.Nodes.Add(treeNode);
            }
        }
        private void CargarRolesExistentes()
        {
            //var roles = roleService.GetAll();
            //cboRoles.DataSource = roles;
            //cboRoles.DisplayMember = "Name";

            var roles = new List<Role>() { new Role() { Name = "Nodo1", Permissions = new List<string>() { "D", "A" } }, new SimpleRole() { Name = "Simple Rol", Permissions = new List<string>() { "A", "B", "C" } } };
            var compositeRole = new CompositeRole() { Name = "CompositeRole", Permissions = new List<string>() { "Nodo1.1" }, SubRoles = new List<Role>() { new SimpleRole() { Name = "SimpleRole", Permissions = new List<string>() { "A", "B", "C" } } } };
            roles.Add(compositeRole);

            // TODO: roles a arbol
            foreach (var rol in roles)
            {
                treeViewAvailable.Nodes.Add(ConvertToTreeNode(rol));
            }
        }


        private void btnAsignar_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = treeViewAvailable.SelectedNode;
            TreeNode clonedNode = (TreeNode)selectedNode.Clone();

            //bool nodoSeleccionadoEsRol = clonedNode.Nodes.Count > 0;
            //if (nodoSeleccionadoEsRol)
            //{
            //    CompositeRole nuevoRolCompuesto = new CompositeRole
            //    {
            //        Name = txtNewRoleName.Text,
            //        Permissions = selectedRole?.Permissions ?? new List<string>(),
            //    };

            //    var 
            //    //nuevoRolCompuesto.SubRoles.Add(GetSelectedRole(selectedNode));

            //    selectedRole = nuevoRolCompuesto;
            //}
            //else
            //{
            //    if (selectedRole is null)
            //    {
            //        selectedRole = new SimpleRole() { Name = txtNewRoleName.Text };
            //        selectedRole.Permissions.Add(clonedNode.Text);
            //    }
            //    else
            //    {
            //        selectedRole.Permissions.Add(clonedNode.Text);
            //    }
            //}

            treeViewAssigned.Nodes.Add(clonedNode);
        }

        private void btnDesasignar_Click(object sender, EventArgs e)
        {
            // sacar del arbol
            TreeNode selectedNode = treeViewAssigned.SelectedNode;
            selectedNode.Remove();
            // guardar en XML con update by ID, no es necesario si solo uso un metodo de arbol a rol
        }

        private void btnCreateRole_Click(object sender, EventArgs e)
        {
            treeViewAssigned.Nodes.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Crear el rol principal (puede ser CompositeRole o SimpleRole según tu estructura)
            var rootRole = new CompositeRole
            {
                Name = "Root"
            };

            // Llamar al método recursivo para convertir el TreeView a roles
            ConvertirTreeViewARoles(treeViewAssigned.Nodes, rootRole);

            //List<Role> roles = new List<Role>();
            //// pasa de arbol a rol
            //ConvertTreeViewToRoles(treeViewAssigned.Nodes, roles);
            //var rol = TreeViewRoleConverter.ConvertTreeViewToRole(treeViewAssigned);
            // guarda rol en XML
            treeViewAssigned.Nodes.Clear();

            treeViewAssigned.Nodes.Add(ConvertToTreeNode(rootRole));
        }

        private void cboRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TODO: mostrar rol como arbol
        }

        //private void ConvertTreeViewToRoles(TreeNodeCollection nodes, List<Role> roles)
        //{
        //    foreach (TreeNode node in nodes)
        //    {
        //        if (node.Nodes.Count == 0)
        //        {
        //            // Nodo sin hijos, es un permiso
        //            var permission = new Role { Name = node.Text };
        //            roles.Add(permission);
        //        }
        //        else if (node.Nodes.Count == 1 && node.Nodes[0].Nodes.Count == 0)
        //        {
        //            // Nodo con un hijo sin hijos, es un rol simple
        //            var simpleRole = new SimpleRole { Name = node.Text };
        //            var permission = new Role { Name = node.Nodes[0].Text };
        //            simpleRole.Permissions.Add(permission);
        //            roles.Add(simpleRole);
        //        }
        //        else
        //        {
        //            // Nodo con dos o más subniveles, es un rol compuesto
        //            var compositeRole = new CompositeRole { Name = node.Text };
        //            ConvertTreeViewToRoles(node.Nodes, compositeRole.SubRoles);
        //            roles.Add(compositeRole);
        //        }
        //    }
        //}

        public static TreeNode ConvertToTreeNode(Role role)
        {
            TreeNode node = new TreeNode(role.Name);

            foreach (string permission in role.Permissions)
            {
                node.Nodes.Add(permission);
            }

            if (role is CompositeRole compositeRole)
            {
                foreach (Role subRole in compositeRole.SubRoles)
                {
                    node.Nodes.Add(ConvertToTreeNode(subRole));
                }
            }

            return node;
        }

        private void ConvertirTreeViewARoles(TreeNodeCollection nodes, CompositeRole parentRole)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Nodes.Count == 0)
                {
                    // Nodo sin nodos hijos, crear SimpleRole
                    var simpleRole = new SimpleRole
                    {
                        Name = node.Text
                    };

                    parentRole.SubRoles.Add(simpleRole);
                }
                else
                {
                    // Nodo con nodos hijos, crear CompositeRole y llamar recursivamente
                    var compositeRole = new CompositeRole
                    {
                        Name = node.Text
                    };

                    parentRole.SubRoles.Add(compositeRole);

                    // Llamada recursiva para procesar los nodos hijos
                    ConvertirTreeViewARoles(node.Nodes, compositeRole);
                }
            }
        }

        //private void btnConvertir_Click(object sender, EventArgs e)
        //{
        //    // Crear el rol principal (puede ser CompositeRole o SimpleRole según tu estructura)
        //    var rootRole = new CompositeRole
        //    {
        //        Name = "Root"
        //    };

        //    // Llamar al método recursivo para convertir el TreeView a roles
        //    ConvertirTreeViewARoles(treeViewAssigned.Nodes, rootRole);

        //    // Ahora, el rol principal (rootRole) contiene la estructura convertida
        //    // Puedes hacer lo que quieras con rootRole, como almacenarlo o procesarlo de alguna manera.
        //}
    }
}