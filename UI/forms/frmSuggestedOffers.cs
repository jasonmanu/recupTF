using BLL.Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace UI.forms
{
    public partial class frmSuggestedOffers : Form
    {
        private readonly ISuggestedOfferService suggestedOfferService;

        public frmSuggestedOffers(ISuggestedOfferService suggestedOfferService)
        {
            InitializeComponent();
            this.suggestedOfferService = suggestedOfferService;
        }

        private void frmSuggestedOffers_Load(object sender, EventArgs e)
        {
            LoadSuggestedOffers();
        }

        private void LoadSuggestedOffers()
        {
            List<SuggestedOffer> suggestedOffers = suggestedOfferService.GetAll();

            if (suggestedOffers != null)
            {
                dgvSuggestedOffers.Refresh();
                dgvSuggestedOffers.DataSource = suggestedOffers;
                dgvSuggestedOffers.Columns["Id"].Visible = false;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {

        }
    }
}
