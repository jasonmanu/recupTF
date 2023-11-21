using BLL;
using Entities;
using FormSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace UI
{
    public partial class frmBackup : Form
    {
        private readonly IBackupService backupService;

        public frmBackup(IBackupService backupService)
        {
            InitializeComponent();
            this.backupService = backupService;
            LoadData();
        }

        private void LoadData()
        {
            dgvData.DataSource = backupService.GetAll();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            string id = FormHelper.GetCurrentRowId(dgvData);

            try
            {
                backupService.ImportById(id);
                LoadData();
                MessageBox.Show("Backup importado correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                backupService.Export();
                LoadData();
                MessageBox.Show("Backup generado");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
