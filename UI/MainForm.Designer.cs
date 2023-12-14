
using UI.Controls;

namespace UI
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.leftPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnRoles = new System.Windows.Forms.Button();
            this.btnSubscriptionTypes = new System.Windows.Forms.Button();
            this.btnInicio = new System.Windows.Forms.Button();
            this.btnPrestamos = new System.Windows.Forms.Button();
            this.btnLibros = new System.Windows.Forms.Button();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.btnMultas = new System.Windows.Forms.Button();
            this.btnAuthors = new System.Windows.Forms.Button();
            this.btnCategories = new System.Windows.Forms.Button();
            this.btnBackup = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.topPanel = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.leftPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // leftPanel
            // 
            this.leftPanel.Controls.Add(this.tableLayoutPanel1);
            this.leftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftPanel.Location = new System.Drawing.Point(0, 0);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(236, 720);
            this.leftPanel.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnInicio, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnPrestamos, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnMultas, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnLibros, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnUsuarios, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnRoles, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnAuthors, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnSubscriptionTypes, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnCategories, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnBackup, 1, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(225, 696);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // btnRoles
            // 
            this.btnRoles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRoles.Location = new System.Drawing.Point(115, 327);
            this.btnRoles.Name = "btnRoles";
            this.btnRoles.Size = new System.Drawing.Size(107, 40);
            this.btnRoles.TabIndex = 9;
            this.btnRoles.Text = "Roles";
            this.btnRoles.UseVisualStyleBackColor = true;
            this.btnRoles.Click += new System.EventHandler(this.btnRoles_Click);
            // 
            // btnSubscriptionTypes
            // 
            this.btnSubscriptionTypes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubscriptionTypes.Location = new System.Drawing.Point(3, 606);
            this.btnSubscriptionTypes.Name = "btnSubscriptionTypes";
            this.btnSubscriptionTypes.Size = new System.Drawing.Size(106, 40);
            this.btnSubscriptionTypes.TabIndex = 11;
            this.btnSubscriptionTypes.Text = "Suscripciones";
            this.btnSubscriptionTypes.UseVisualStyleBackColor = true;
            this.btnSubscriptionTypes.Click += new System.EventHandler(this.btnSubsInfo_Click);
            // 
            // btnInicio
            // 
            this.btnInicio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInicio.BackColor = System.Drawing.Color.LightGray;
            this.btnInicio.Location = new System.Drawing.Point(3, 49);
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Size = new System.Drawing.Size(106, 40);
            this.btnInicio.TabIndex = 0;
            this.btnInicio.Text = "Inicio";
            this.btnInicio.UseVisualStyleBackColor = false;
            this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);
            // 
            // btnPrestamos
            // 
            this.btnPrestamos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrestamos.Location = new System.Drawing.Point(3, 188);
            this.btnPrestamos.Name = "btnPrestamos";
            this.btnPrestamos.Size = new System.Drawing.Size(106, 40);
            this.btnPrestamos.TabIndex = 2;
            this.btnPrestamos.Text = "Prestamos";
            this.btnPrestamos.UseVisualStyleBackColor = true;
            this.btnPrestamos.Click += new System.EventHandler(this.btnPrestamos_Click);
            // 
            // btnLibros
            // 
            this.btnLibros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLibros.Location = new System.Drawing.Point(115, 49);
            this.btnLibros.Name = "btnLibros";
            this.btnLibros.Size = new System.Drawing.Size(107, 40);
            this.btnLibros.TabIndex = 1;
            this.btnLibros.Text = "Libros";
            this.btnLibros.UseVisualStyleBackColor = true;
            this.btnLibros.Click += new System.EventHandler(this.btnLibros_Click);
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUsuarios.Location = new System.Drawing.Point(3, 327);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(106, 40);
            this.btnUsuarios.TabIndex = 4;
            this.btnUsuarios.Text = "Usuarios";
            this.btnUsuarios.UseVisualStyleBackColor = true;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // btnMultas
            // 
            this.btnMultas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMultas.Location = new System.Drawing.Point(115, 188);
            this.btnMultas.Name = "btnMultas";
            this.btnMultas.Size = new System.Drawing.Size(107, 40);
            this.btnMultas.TabIndex = 3;
            this.btnMultas.Text = "Multas";
            this.btnMultas.UseVisualStyleBackColor = true;
            this.btnMultas.Click += new System.EventHandler(this.btnMultas_Click);
            // 
            // btnAuthors
            // 
            this.btnAuthors.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAuthors.Location = new System.Drawing.Point(3, 466);
            this.btnAuthors.Name = "btnAuthors";
            this.btnAuthors.Size = new System.Drawing.Size(106, 40);
            this.btnAuthors.TabIndex = 6;
            this.btnAuthors.Text = "Autores";
            this.btnAuthors.UseVisualStyleBackColor = true;
            this.btnAuthors.Click += new System.EventHandler(this.btnAuthors_Click);
            // 
            // btnCategories
            // 
            this.btnCategories.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCategories.Location = new System.Drawing.Point(115, 466);
            this.btnCategories.Name = "btnCategories";
            this.btnCategories.Size = new System.Drawing.Size(107, 40);
            this.btnCategories.TabIndex = 7;
            this.btnCategories.Text = "Categorias";
            this.btnCategories.UseVisualStyleBackColor = true;
            this.btnCategories.Click += new System.EventHandler(this.btnCategories_Click);
            // 
            // btnBackup
            // 
            this.btnBackup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBackup.Location = new System.Drawing.Point(115, 606);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(107, 40);
            this.btnBackup.TabIndex = 8;
            this.btnBackup.Text = "Backup";
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.mainPanel.Location = new System.Drawing.Point(236, 80);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1044, 640);
            this.mainPanel.TabIndex = 1;
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.btnExit);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(236, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(1044, 80);
            this.topPanel.TabIndex = 2;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(997, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(35, 35);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "X";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.leftPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.leftPanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.topPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.Button btnPrestamos;
        private System.Windows.Forms.Button btnLibros;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.Button btnMultas;
        private System.Windows.Forms.Button btnInicio;
        private System.Windows.Forms.Button btnAuthors;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnCategories;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnSubscriptionTypes;
        private System.Windows.Forms.Button btnRoles;
    }
}