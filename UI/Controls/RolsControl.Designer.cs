
namespace UI.Controls
{
    partial class RolsControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.treeViewAvailable = new System.Windows.Forms.TreeView();
            this.treeViewAssigned = new System.Windows.Forms.TreeView();
            this.labelSelectedNode = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAsignar = new System.Windows.Forms.Button();
            this.btnDesasignar = new System.Windows.Forms.Button();
            this.cboRoles = new System.Windows.Forms.ComboBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.txtNewRoleName = new System.Windows.Forms.TextBox();
            this.btnCreateRole = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treeViewAvailable
            // 
            this.treeViewAvailable.Location = new System.Drawing.Point(58, 181);
            this.treeViewAvailable.Name = "treeViewAvailable";
            this.treeViewAvailable.Size = new System.Drawing.Size(348, 458);
            this.treeViewAvailable.TabIndex = 0;
            // 
            // treeViewAssigned
            // 
            this.treeViewAssigned.Location = new System.Drawing.Point(576, 181);
            this.treeViewAssigned.Name = "treeViewAssigned";
            this.treeViewAssigned.Size = new System.Drawing.Size(348, 458);
            this.treeViewAssigned.TabIndex = 2;
            // 
            // labelSelectedNode
            // 
            this.labelSelectedNode.AutoSize = true;
            this.labelSelectedNode.Location = new System.Drawing.Point(479, 471);
            this.labelSelectedNode.Name = "labelSelectedNode";
            this.labelSelectedNode.Size = new System.Drawing.Size(35, 13);
            this.labelSelectedNode.TabIndex = 1;
            this.labelSelectedNode.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(195, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Todos los permisos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(702, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Permisos Asignados";
            // 
            // btnAsignar
            // 
            this.btnAsignar.Location = new System.Drawing.Point(455, 278);
            this.btnAsignar.Name = "btnAsignar";
            this.btnAsignar.Size = new System.Drawing.Size(92, 23);
            this.btnAsignar.TabIndex = 5;
            this.btnAsignar.Text = "Asignar ->";
            this.btnAsignar.UseVisualStyleBackColor = true;
            this.btnAsignar.Click += new System.EventHandler(this.btnAsignar_Click);
            // 
            // btnDesasignar
            // 
            this.btnDesasignar.Location = new System.Drawing.Point(455, 357);
            this.btnDesasignar.Name = "btnDesasignar";
            this.btnDesasignar.Size = new System.Drawing.Size(92, 23);
            this.btnDesasignar.TabIndex = 6;
            this.btnDesasignar.Text = "<- Desasignar";
            this.btnDesasignar.UseVisualStyleBackColor = true;
            this.btnDesasignar.Click += new System.EventHandler(this.btnDesasignar_Click);
            // 
            // cboRoles
            // 
            this.cboRoles.FormattingEnabled = true;
            this.cboRoles.Location = new System.Drawing.Point(313, 111);
            this.cboRoles.Name = "cboRoles";
            this.cboRoles.Size = new System.Drawing.Size(349, 21);
            this.cboRoles.TabIndex = 7;
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Location = new System.Drawing.Point(451, 95);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(79, 13);
            this.lblRole.TabIndex = 8;
            this.lblRole.Text = "Seleccione Rol";
            // 
            // txtNewRoleName
            // 
            this.txtNewRoleName.Location = new System.Drawing.Point(313, 21);
            this.txtNewRoleName.Name = "txtNewRoleName";
            this.txtNewRoleName.Size = new System.Drawing.Size(268, 20);
            this.txtNewRoleName.TabIndex = 9;
            // 
            // btnCreateRole
            // 
            this.btnCreateRole.Location = new System.Drawing.Point(587, 21);
            this.btnCreateRole.Name = "btnCreateRole";
            this.btnCreateRole.Size = new System.Drawing.Size(75, 23);
            this.btnCreateRole.TabIndex = 10;
            this.btnCreateRole.Text = "Crear rol";
            this.btnCreateRole.UseVisualStyleBackColor = true;
            this.btnCreateRole.Click += new System.EventHandler(this.btnCreateRole_Click);
            // 
            // RolsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCreateRole);
            this.Controls.Add(this.txtNewRoleName);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.cboRoles);
            this.Controls.Add(this.btnDesasignar);
            this.Controls.Add(this.btnAsignar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.treeViewAssigned);
            this.Controls.Add(this.labelSelectedNode);
            this.Controls.Add(this.treeViewAvailable);
            this.Name = "RolsControl";
            this.Size = new System.Drawing.Size(970, 665);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewAvailable;
        private System.Windows.Forms.TreeView treeViewAssigned;
        private System.Windows.Forms.Label labelSelectedNode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAsignar;
        private System.Windows.Forms.Button btnDesasignar;
        private System.Windows.Forms.ComboBox cboRoles;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.TextBox txtNewRoleName;
        private System.Windows.Forms.Button btnCreateRole;
    }
}
