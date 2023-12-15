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

        private void CargarRolesExistentes()
        {
            var roles = this.roleService.GetAll();
            cboRoles.DataSource = roles;
            cboRoles.DisplayMember = "Name";
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

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = treeViewAvailable.SelectedNode;
            TreeNode clonedNode = (TreeNode)selectedNode.Clone();

            bool nodoSeleccionadoEsRol = clonedNode.Nodes.Count > 0;
            if (nodoSeleccionadoEsRol)
            {
                CompositeRole nuevoRolCompuesto = new CompositeRole
                {
                    Name = txtNewRoleName.Text,
                    Permissions = selectedRole?.Permissions ?? new List<string>(),
                };

                //TODO update
                nuevoRolCompuesto.SubRoles.Add(GetSelectedRole(selectedNode));

                selectedRole = nuevoRolCompuesto;
            }
            else
            {
                if (selectedRole is null)
                {
                    selectedRole = new SimpleRole() { Name = txtNewRoleName.Text };
                    selectedRole.Permissions.Add(clonedNode.Text);
                }
                else
                {
                    selectedRole.Permissions.Add(clonedNode.Text);
                }
            }

            treeViewAssigned.Nodes.Add(clonedNode);

            //rolManager = new RoleManager();
            //rolManager.AddRole(selectedRole);
            //rolManager.SaveRolesToXml();
        }

        private void btnDesasignar_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = treeViewAssigned.SelectedNode;
            selectedNode.Remove();

            // actualizar el rol selected
        }

        private void btnCreateRole_Click(object sender, EventArgs e)
        {
            treeViewAssigned.Nodes.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (treeViewAssigned.Nodes.Count == 0)
            {
                MessageBox.Show("no se puede guardar rol vacio");
            }
            else
            {
                roleService.Create(selectedRole);
                MessageBox.Show("Rol creado");
                // TODO: usar ese rol por si quiere hacer update
            }
        }

        #region test
        private void PrintNode(TreeNode node)
        {
            Console.WriteLine(node.Text);
        }

        private void PrintNodeAndChildren(TreeNode node)
        {
            PrintNode(node);

            // Si el nodo tiene nodos hijos, recorrerlos recursivamente
            foreach (TreeNode childNode in node.Nodes)
            {
                PrintNodeAndChildren(childNode);
            }
        }

        private void PrintTreeView()
        {
            // Recorrer todos los nodos del TreeView
            //foreach (TreeNode node in treeView.Nodes)
            //{
            //    // Si el nodo no tiene nodos hijos, imprimir solo el nombre
            //    if (node.Nodes.Count == 0)
            //    {
            //        PrintNode(node);
            //    }
            //    else
            //    {
            //        // Si el nodo tiene nodos hijos, imprimir el nombre y recorrer recursivamente los hijos
            //        PrintNodeAndChildren(node);
            //    }
            //}
        }


        private Role GetSelectedRole(TreeNode selectedNode)
        {
            return null;

            if (selectedNode != null)
            {
                var esRol = selectedNode.Nodes.Count > 0;
                if (esRol)
                {
                    foreach (TreeNode node in selectedNode.Nodes)
                    {
                        // Si el nodo no tiene nodos hijos, imprimir solo el nombre
                        if (node.Nodes.Count == 0)
                        {
                            PrintNode(node);
                        }
                        else
                        {
                            // Si el nodo tiene nodos hijos, imprimir el nombre y recorrer recursivamente los hijos
                            PrintNodeAndChildren(node);
                        }
                    }
                }

            }
        }

        #endregion
    }
}