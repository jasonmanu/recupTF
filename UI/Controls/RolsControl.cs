using BLL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace UI.Controls
{
    public partial class RolsControl : UserControl
    {
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
            List<string> features = new List<string>() { "Libro", "Usuario", "Autor", "Backup", "Categoria", "Prestamo", "Notification", "Subscripcion", "TipoSubscripcion" };
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
            var roles = roleService.GetAll().Where(x => x.Id != null).ToList();
            cboRoles.DataSource = roles;
            cboRoles.DisplayMember = "Name";

            foreach (var rol in roles)
            {
                treeViewAvailable.Nodes.Add(ConvertToTreeNode(rol));
            }
        }


        private void btnAsignar_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = treeViewAvailable.SelectedNode;
            TreeNode clonedNode = (TreeNode)selectedNode.Clone();
            treeViewAssigned.Nodes.Add(clonedNode);
        }

        private void btnDesasignar_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = treeViewAssigned.SelectedNode;
            selectedNode.Remove();
        }

        private void btnCreateRole_Click(object sender, EventArgs e)
        {
            treeViewAssigned.Nodes.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var rolDeArbolAsignado = new CompositeRole
            {
                Name = txtNewRoleName.Text,
            };

            // Llamar al método recursivo para convertir el TreeView a roles
            ConvertirTreeViewARoles(treeViewAssigned.Nodes, rolDeArbolAsignado);

            if (((Role)cboRoles.SelectedValue)?.Name == txtNewRoleName.Text)
            {
                roleService.Delete(((Role)cboRoles.SelectedValue).Id);
            }

            // guarda rol en XML
            roleService.Create(rolDeArbolAsignado);
            treeViewAvailable.Nodes.Clear();
            CargarPermisosPredefinidos();
            CargarRolesExistentes();
        }

        private void cboRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            treeViewAssigned.Nodes.Clear();

            if (cboRoles.SelectedValue != null)
            {
                var rolId = ((Role)cboRoles.SelectedValue).Id;
                txtNewRoleName.Text = ((Role)cboRoles.SelectedValue).Name;

                var rol = roleService.GetById(rolId);
                treeViewAssigned.Nodes.Add(ConvertToTreeNode(rol));
            }
        }

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
    }
}