﻿
namespace UI.forms
{
    partial class frmSuggestedOffers
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvSuggestedOffers = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuggestedOffers)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(323, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(277, 24);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Ofertas sugeridas por el sistema";
            // 
            // dgvSuggestedOffers
            // 
            this.dgvSuggestedOffers.AllowUserToAddRows = false;
            this.dgvSuggestedOffers.AllowUserToDeleteRows = false;
            this.dgvSuggestedOffers.AllowUserToResizeColumns = false;
            this.dgvSuggestedOffers.AllowUserToResizeRows = false;
            this.dgvSuggestedOffers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSuggestedOffers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSuggestedOffers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvSuggestedOffers.Location = new System.Drawing.Point(12, 46);
            this.dgvSuggestedOffers.Name = "dgvSuggestedOffers";
            this.dgvSuggestedOffers.ReadOnly = true;
            this.dgvSuggestedOffers.Size = new System.Drawing.Size(925, 337);
            this.dgvSuggestedOffers.TabIndex = 1;
            // 
            // frmSuggestedOffers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 403);
            this.Controls.Add(this.dgvSuggestedOffers);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmSuggestedOffers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ofertas sugeridas";
            this.Load += new System.EventHandler(this.frmSuggestedOffers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuggestedOffers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvSuggestedOffers;
    }
}