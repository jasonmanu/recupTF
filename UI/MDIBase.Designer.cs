
namespace UI
{
    partial class MDIBase
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MDIBase));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.productsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.categoriesMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.offersMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCreateOffer = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGetOffers = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSuggestedOffers = new System.Windows.Forms.ToolStripMenuItem();
            this.sellersMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.backupMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGenerateBackup = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRestoreBackup = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.printToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.printPreviewToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.brandMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productsMenu,
            this.categoriesMenu,
            this.offersMenu,
            this.sellersMenu,
            this.backupMenu,
            this.brandMenu});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1264, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // productsMenu
            // 
            this.productsMenu.Name = "productsMenu";
            this.productsMenu.Size = new System.Drawing.Size(73, 20);
            this.productsMenu.Text = "Productos";
            this.productsMenu.Click += new System.EventHandler(this.productsMenu_Click);
            // 
            // categoriesMenu
            // 
            this.categoriesMenu.Name = "categoriesMenu";
            this.categoriesMenu.Size = new System.Drawing.Size(75, 20);
            this.categoriesMenu.Text = "Categorias";
            this.categoriesMenu.Click += new System.EventHandler(this.categoriesMenu_Click);
            // 
            // offersMenu
            // 
            this.offersMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCreateOffer,
            this.btnGetOffers,
            this.btnSuggestedOffers});
            this.offersMenu.Name = "offersMenu";
            this.offersMenu.Size = new System.Drawing.Size(57, 20);
            this.offersMenu.Text = "Ofertas";
            // 
            // btnCreateOffer
            // 
            this.btnCreateOffer.Name = "btnCreateOffer";
            this.btnCreateOffer.Size = new System.Drawing.Size(165, 22);
            this.btnCreateOffer.Text = "Crear";
            this.btnCreateOffer.Click += new System.EventHandler(this.btnCreateOffer_Click);
            // 
            // btnGetOffers
            // 
            this.btnGetOffers.Name = "btnGetOffers";
            this.btnGetOffers.Size = new System.Drawing.Size(165, 22);
            this.btnGetOffers.Text = "Ver ofertas";
            this.btnGetOffers.Click += new System.EventHandler(this.btnGetOffers_Click);
            // 
            // btnSuggestedOffers
            // 
            this.btnSuggestedOffers.Name = "btnSuggestedOffers";
            this.btnSuggestedOffers.Size = new System.Drawing.Size(165, 22);
            this.btnSuggestedOffers.Text = "Ofertas sugeridas";
            this.btnSuggestedOffers.Click += new System.EventHandler(this.btnSuggestedOffers_Click);
            // 
            // sellersMenu
            // 
            this.sellersMenu.Name = "sellersMenu";
            this.sellersMenu.Size = new System.Drawing.Size(80, 20);
            this.sellersMenu.Text = "Vendedores";
            // 
            // backupMenu
            // 
            this.backupMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGenerateBackup,
            this.btnRestoreBackup});
            this.backupMenu.Name = "backupMenu";
            this.backupMenu.Size = new System.Drawing.Size(58, 20);
            this.backupMenu.Text = "Backup";
            // 
            // btnGenerateBackup
            // 
            this.btnGenerateBackup.Name = "btnGenerateBackup";
            this.btnGenerateBackup.Size = new System.Drawing.Size(123, 22);
            this.btnGenerateBackup.Text = "Generar";
            this.btnGenerateBackup.Click += new System.EventHandler(this.btnGenerateBackup_Click);
            // 
            // btnRestoreBackup
            // 
            this.btnRestoreBackup.Name = "btnRestoreBackup";
            this.btnRestoreBackup.Size = new System.Drawing.Size(123, 22);
            this.btnRestoreBackup.Text = "Restaurar";
            this.btnRestoreBackup.Click += new System.EventHandler(this.btnRestoreBackup_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton,
            this.openToolStripButton,
            this.saveToolStripButton,
            this.toolStripSeparator1,
            this.printToolStripButton,
            this.printPreviewToolStripButton,
            this.toolStripSeparator2,
            this.helpToolStripButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1264, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "ToolStrip";
            // 
            // newToolStripButton
            // 
            this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
            this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Black;
            this.newToolStripButton.Name = "newToolStripButton";
            this.newToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.newToolStripButton.Text = "New";
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Black;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.openToolStripButton.Text = "Open";
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Black;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveToolStripButton.Text = "Save";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // printToolStripButton
            // 
            this.printToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.printToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripButton.Image")));
            this.printToolStripButton.ImageTransparentColor = System.Drawing.Color.Black;
            this.printToolStripButton.Name = "printToolStripButton";
            this.printToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.printToolStripButton.Text = "Print";
            // 
            // printPreviewToolStripButton
            // 
            this.printPreviewToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.printPreviewToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("printPreviewToolStripButton.Image")));
            this.printPreviewToolStripButton.ImageTransparentColor = System.Drawing.Color.Black;
            this.printPreviewToolStripButton.Name = "printPreviewToolStripButton";
            this.printPreviewToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.printPreviewToolStripButton.Text = "Print Preview";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // helpToolStripButton
            // 
            this.helpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.helpToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripButton.Image")));
            this.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Black;
            this.helpToolStripButton.Name = "helpToolStripButton";
            this.helpToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.helpToolStripButton.Text = "Help";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 739);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1264, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // brandMenu
            // 
            this.brandMenu.Name = "brandMenu";
            this.brandMenu.Size = new System.Drawing.Size(52, 20);
            this.brandMenu.Text = "Marca";
            this.brandMenu.Click += new System.EventHandler(this.brandMenu_Click);
            // 
            // MDIBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 761);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MDIBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "e-commerce";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MDIBase_FormClosed);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem productsMenu;
        private System.Windows.Forms.ToolStripButton newToolStripButton;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripButton printToolStripButton;
        private System.Windows.Forms.ToolStripButton printPreviewToolStripButton;
        private System.Windows.Forms.ToolStripButton helpToolStripButton;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem offersMenu;
        private System.Windows.Forms.ToolStripMenuItem sellersMenu;
        private System.Windows.Forms.ToolStripMenuItem btnCreateOffer;
        private System.Windows.Forms.ToolStripMenuItem btnGetOffers;
        private System.Windows.Forms.ToolStripMenuItem btnSuggestedOffers;
        private System.Windows.Forms.ToolStripMenuItem backupMenu;
        private System.Windows.Forms.ToolStripMenuItem btnGenerateBackup;
        private System.Windows.Forms.ToolStripMenuItem btnRestoreBackup;
        private System.Windows.Forms.ToolStripMenuItem categoriesMenu;
        private System.Windows.Forms.ToolStripMenuItem brandMenu;
    }
}



