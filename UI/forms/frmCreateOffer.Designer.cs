
namespace UI.forms
{
    partial class frmCreateOffer
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.nudDiscount = new System.Windows.Forms.NumericUpDown();
            this.checkActive = new System.Windows.Forms.CheckBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiscount)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(610, 123);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 4;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel4.Controls.Add(this.label2, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.lblType, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.lblDiscount, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.lblName, 0, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(604, 33);
            this.tableLayoutPanel4.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(538, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Estado";
            // 
            // lblType
            // 
            this.lblType.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(407, 20);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(28, 13);
            this.lblType.TabIndex = 2;
            this.lblType.Text = "Tipo";
            // 
            // lblDiscount
            // 
            this.lblDiscount.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Location = new System.Drawing.Point(256, 20);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(59, 13);
            this.lblDiscount.TabIndex = 1;
            this.lblDiscount.Text = "Descuento";
            // 
            // lblName
            // 
            this.lblName.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(98, 20);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(44, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Nombre";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel3.Controls.Add(this.cboType, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtName, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.nudDiscount, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.checkActive, 3, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 64);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(604, 37);
            this.tableLayoutPanel3.TabIndex = 5;
            // 
            // cboType
            // 
            this.cboType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType.FormattingEnabled = true;
            this.cboType.Location = new System.Drawing.Point(334, 8);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(175, 21);
            this.cboType.TabIndex = 3;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(3, 8);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(235, 20);
            this.txtName.TabIndex = 0;
            // 
            // nudDiscount
            // 
            this.nudDiscount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nudDiscount.Location = new System.Drawing.Point(244, 8);
            this.nudDiscount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDiscount.Name = "nudDiscount";
            this.nudDiscount.Size = new System.Drawing.Size(84, 20);
            this.nudDiscount.TabIndex = 1;
            this.nudDiscount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // checkActive
            // 
            this.checkActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.checkActive.AutoSize = true;
            this.checkActive.Location = new System.Drawing.Point(515, 10);
            this.checkActive.Name = "checkActive";
            this.checkActive.Size = new System.Drawing.Size(86, 17);
            this.checkActive.TabIndex = 4;
            this.checkActive.Text = "Activo";
            this.checkActive.UseVisualStyleBackColor = true;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(163, 150);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(313, 40);
            this.btnCreate.TabIndex = 1;
            this.btnCreate.Text = "Create offer";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // frmCreateOffer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 206);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmCreateOffer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crear oferta";
            this.Load += new System.EventHandler(this.frmCreateOffer_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiscount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.NumericUpDown nudDiscount;
        private System.Windows.Forms.CheckBox checkActive;
        private System.Windows.Forms.Button btnCreate;
    }
}