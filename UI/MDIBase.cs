using BLL.Contracts;
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
using UI.forms;

namespace UI
{
    public partial class MDIBase : Form
    {
        private readonly IOfferService offerService;

        public MDIBase(UserRole userRole, IOfferService offerService)
        {
            InitializeComponent();
            LoadRoleButtons(userRole);
            this.offerService = offerService;
        }

        private void LoadRoleButtons(UserRole userRole)
        {
            switch (userRole)
            {
                case UserRole.ADMIN:
                    sellersMenu.Visible = true;
                    reportsMenu.Visible = true;
                    productsMenu.Visible = true;
                    offersMenu.Visible = true;
                    break;
                case UserRole.SELLER:
                    offersMenu.Visible = true;
                    productsMenu.Visible = true;
                    break;
                case UserRole.SHOPPER:
                    ordersMenu.Visible = true;
                    break;
                default:
                    break;
            }
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void createOfferMenu_Click(object sender, EventArgs e)
        {
        }

        private void btnCreateOffer_Click(object sender, EventArgs e)
        {
            var formCreateOffer = new frmCreateOffer(offerService)
            {
                MdiParent = this
            };
            formCreateOffer.Show();
        }

        private void btnGetOffers_Click(object sender, EventArgs e)
        {
            var formCreateOffer = new frmManageOffer(offerService)
            {
                MdiParent = this
            };
            formCreateOffer.Show();
        }

        private void reportsMenu_Click(object sender, EventArgs e)
        {
            new frmReports()
            {
                StartPosition = FormStartPosition.CenterScreen
            }.Show();
        }

        private void btnSuggestedOffers_Click(object sender, EventArgs e)
        {

        }
    }
}
