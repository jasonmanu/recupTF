using BLL;
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

namespace UI.forms
{
    public partial class frmManageOffer : Form
    {
        private readonly IOfferService offerService;

        public frmManageOffer(IOfferService offerService)
        {
            this.offerService = offerService;
            InitializeComponent();
        }

        private int? GetCurrentId()
        {
            DataGridViewRow currentRow = dgvOffers.CurrentRow;

            if (currentRow == null)
                return null;

            return Convert.ToInt32(currentRow.Cells["Id"]?.Value);
        }

        private void frmManageOffer_Load(object sender, EventArgs e)
        {
            LoadOffers();
        }

        private void LoadOffers()
        {
            List<Offer> offers = offerService.GetAll();

            if (offers != null)
            {
                dgvOffers.DataSource = offers;
                dgvOffers.Columns["Id"].Visible = false;
                dgvOffers.Columns["Name"].Width = 150;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int? discountId = GetCurrentId();

            if (discountId != null)
            {
                offerService.Delete((int)discountId);
                LoadOffers();
            }
        }
    }
}
