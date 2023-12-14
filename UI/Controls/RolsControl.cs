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
        private CompositeRole newCompositeRole;
        private TreeNode selectedTreeNode;

        public RolsControl()
        {
            InitializeComponent();
            CargarPermisosPredefinidos();
            CargarRolesExistentes();
            selectedTreeNode = new TreeNode();
        }

        private void CargarRolesExistentes()
        {
            RoleManager rolManager = new RoleManager();
            //rolManager.LoadRolesFromXml();
            // hacer que rolManager sea el rol service, asi lo puedo usar en cada form, hago getPermissions() y despues habilito ó no segun roles
        }

        private void CargarPermisosPredefinidos()
        {
            List<string> entidades = new List<string>() { "Libro", "Usuario", "Autor" };
            List<string> permisosCrud = new List<string>() { "Crear", "Leer", "Editar", "Eliminar" };
            List<string> permisosDisponibles = new List<string>();
            List<SimpleRole> entityManagementList = new List<SimpleRole>();

            foreach (string entidad in entidades)
            {
                SimpleRole entityManagement = new SimpleRole() { Name = $"Gestion.{entidad}" };

                foreach (string permiso in permisosCrud)
                {
                    string entidadPermiso = $"{entidad}.{permiso}";

                    // agregar permisos individuales
                    permisosDisponibles.Add(entidadPermiso);

                    // agregar a rol simple
                    entityManagement.Permissions.Add(entidadPermiso);
                }

                // agregar a lista general de permisos compuestos
                entityManagementList.Add(entityManagement);
            }

            foreach (SimpleRole rol in entityManagementList)
            {
                TreeNode treeNode = new TreeNode(rol.Name);

                foreach (string permiso in rol.Permissions)
                {
                    treeNode.Nodes.Add(permiso);
                }

                treeViewAvailable.Nodes.Add(treeNode);
            }

            foreach (string permiso in permisosDisponibles)
            {
                treeViewAvailable.Nodes.Add(permiso);
            }
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = treeViewAvailable.SelectedNode;

            if (selectedNode != null)
            {
                string nombrePermiso = selectedNode.Text;

                foreach (TreeNode item in treeViewAssigned.Nodes)
                {
                    if (item.Text == nombrePermiso)
                    {
                        return;
                    }
                }

                TreeNode clonedNode = (TreeNode)selectedNode.Clone();
                treeViewAssigned.Nodes.Add(clonedNode);

                // agregarlo al rol seleccionado del combobox
                // bloquear botones si no existe rol elegido
            }
        }

        private void btnDesasignar_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = treeViewAssigned.SelectedNode;
            selectedNode.Remove();

            // actualizar el rol selected
        }

        private void btnCreateRole_Click(object sender, EventArgs e)
        {
            newCompositeRole = new CompositeRole() { Name = txtNewRoleName.Text };
            // agregar nuevo rol al XML
            //cboRoles.SelectedItem = elegirlo en comboBox
        }
    }
}
