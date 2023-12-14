using BLL;
using FormSupport;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Controls
{
    public partial class BackupControl : UserControl
    {
        private readonly IBackupService backupService;

        public BackupControl(IBackupService backupService)
        {
            this.backupService = backupService;
            InitializeComponent();
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
