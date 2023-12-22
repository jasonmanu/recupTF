using BLL;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace UI.Controls
{
    public partial class NotifsControl : UserControl
    {
        private readonly INotificationService notificationService;
        private readonly User user;

        public NotifsControl(INotificationService notificationService, User user)
        {
            Dock = DockStyle.Fill;
            this.notificationService = notificationService;
            this.user = user;

            InitializeComponent();
            //LoadData();

            if (user.Permisos.Contains("Notificacion.Leer"))
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            try
            {
                List<Notification> myNotifs = notificationService.GetAll().Where(x => x.UserId == user.Id).ToList();
                dgvData.DataSource = myNotifs;
            }
            catch (Exception)
            {
                MessageBox.Show("Error ejecutando accion");
            }
        }
    }
}
