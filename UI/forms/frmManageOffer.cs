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

        private void frmManageOffer_Load(object sender, EventArgs e)
        {
            List<Offer> offers = offerService.GetAll();
            if (offers != null)
            {
                dgvOffers.DataSource = offers;
            }
            dgvOffers.Columns["Id"].Visible = false;
        }
    }
}
