using BLL;
using FormSupport;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace UI
{
    public partial class frmBackup : Form
    {
        private readonly IBackupService backupService;
        private readonly IServiceProvider serviceProvider;

        public frmBackup(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            this.serviceProvider = serviceProvider;
            this.backupService = serviceProvider.GetRequiredService<IBackupService>();
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
