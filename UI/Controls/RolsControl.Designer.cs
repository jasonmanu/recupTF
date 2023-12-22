
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAsignar = new System.Windows.Forms.Button();
            this.btnDesasignar = new System.Windows.Forms.Button();
            this.cboRoles = new System.Windows.Forms.ComboBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.txtNewRoleName = new System.Windows.Forms.TextBox();
            this.btnCreateRole = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // treeViewAvailable
            // 
            this.treeViewAvailable.Location = new System.Drawing.Point(58, 112);
            this.treeViewAvailable.Name = "treeViewAvailable";
            this.treeViewAvailable.Size = new System.Drawing.Size(348, 419);
            this.treeViewAvailable.TabIndex = 0;
            // 
            // treeViewAssigned
            // 
            this.treeViewAssigned.Location = new System.Drawing.Point(576, 112);
            this.treeViewAssigned.Name = "treeViewAssigned";
            this.treeViewAssigned.Size = new System.Drawing.Size(348, 419);
            this.treeViewAssigned.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(194, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Todos los permisos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(618, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Permisos Asignados";
            // 
            // btnAsignar
            // 
            this.btnAsignar.Location = new System.Drawing.Point(455, 239);
            this.btnAsignar.Name = "btnAsignar";
            this.btnAsignar.Size = new System.Drawing.Size(92, 23);
            this.btnAsignar.TabIndex = 5;
            this.btnAsignar.Text = "Asignar ->";
            this.btnAsignar.UseVisualStyleBackColor = true;
            this.btnAsignar.Click += new System.EventHandler(this.btnAsignar_Click);
            // 
            // btnDesasignar
            // 
            this.btnDesasignar.Location = new System.Drawing.Point(455, 318);
            this.btnDesasignar.Name = "btnDesasignar";
            this.btnDesasignar.Size = new System.Drawing.Size(92, 23);
            this.btnDesasignar.TabIndex = 6;
            this.btnDesasignar.Text = "<- Desasignar";
            this.btnDesasignar.UseVisualStyleBackColor = true;
            this.btnDesasignar.Click += new System.EventHandler(this.btnDesasignar_Click);
            // 
            // cboRoles
            // 
            this.cboRoles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRoles.FormattingEnabled = true;
            this.cboRoles.Location = new System.Drawing.Point(58, 43);
            this.cboRoles.Name = "cboRoles";
            this.cboRoles.Size = new System.Drawing.Size(348, 21);
            this.cboRoles.TabIndex = 7;
            this.cboRoles.SelectedIndexChanged += new System.EventHandler(this.cboRoles_SelectedIndexChanged);
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Location = new System.Drawing.Point(184, 6);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(79, 13);
            this.lblRole.TabIndex = 8;
            this.lblRole.Text = "Seleccione Rol";
            // 
            // txtNewRoleName
            // 
            this.txtNewRoleName.Location = new System.Drawing.Point(576, 565);
            this.txtNewRoleName.Name = "txtNewRoleName";
            this.txtNewRoleName.Size = new System.Drawing.Size(348, 20);
            this.txtNewRoleName.TabIndex = 9;
            // 
            // btnCreateRole
            // 
            this.btnCreateRole.Location = new System.Drawing.Point(763, 78);
            this.btnCreateRole.Name = "btnCreateRole";
            this.btnCreateRole.Size = new System.Drawing.Size(161, 26);
            this.btnCreateRole.TabIndex = 10;
            this.btnCreateRole.Text = "Vaciar Roles asignados";
            this.btnCreateRole.UseVisualStyleBackColor = true;
            this.btnCreateRole.Click += new System.EventHandler(this.btnCreateRole_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(576, 591);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(348, 23);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Guardar cambios en rol";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(671, 539);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(165, 13);
            this.lblInfo.TabIndex = 12;
            this.lblInfo.Text = "Cambie titulo para crear nuevo rol";
            // 
            // RolsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCreateRole);
            this.Controls.Add(this.txtNewRoleName);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.cboRoles);
            this.Controls.Add(this.btnDesasignar);
            this.Controls.Add(this.btnAsignar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.treeViewAssigned);
            this.Controls.Add(this.treeViewAvailable);
            this.Name = "RolsControl";
            this.Size = new System.Drawing.Size(1044, 640);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewAvailable;
        private System.Windows.Forms.TreeView treeViewAssigned;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAsignar;
        private System.Windows.Forms.Button btnDesasignar;
        private System.Windows.Forms.ComboBox cboRoles;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.TextBox txtNewRoleName;
        private System.Windows.Forms.Button btnCreateRole;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblInfo;
    }
}
