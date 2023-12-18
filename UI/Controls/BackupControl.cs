using BLL;
using Entities;
using FormSupport;
using System;
using System.Windows.Forms;

namespace UI.Controls
{
    public partial class BackupControl : UserControl
    {
        private readonly IBackupService backupService;
        private readonly User user;

        public BackupControl(IBackupService backupService, User user)
        {
            this.backupService = backupService;
            this.user = user;
            InitializeComponent();
            LoadData();
            HabilitarBotones();
            btnImport.Enabled = false;
        }

        private void HabilitarBotones()
        {
            btnExport.Enabled = false;
            btnImport.Enabled = false;

            if (user.Permisos.Contains("Backup.Leer"))
            {
                btnImport.Enabled = true;
            }

            if (user.Permisos.Contains("Backup.Crear"))
            {
                btnExport.Enabled = true;
            }
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
                backupService.ImportById(id, user);
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
                backupService.Export(user);
                LoadData();
                MessageBox.Show("Backup generado");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generando backup.");
            }
        }

        private void dgvData_SelectionChanged(object sender, EventArgs e)
        {
            string id = FormHelper.GetCurrentRowId(dgvData);

            if (id != null)
            {
                Backup selectBackup = backupService.GetById(id);

                if (selectBackup.Action.Contains("Export"))
                {
                    btnImport.Enabled = true;
                }
            }
        }
    }
}
