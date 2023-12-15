using BLL;
using Entities;
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
            LoadData();
        }

        private void LoadData()
        {
            var myNotifs = notificationService.GetAll().Where(x => x.UserId == user.Id);
            dgvData.DataSource = myNotifs;
        }
    }
}
