using BLL.Contracts;
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
            var suggestedOffers = suggestedOfferService.GetAll();

            if (suggestedOffers != null)
            {
                dgvSuggestedOffers.DataSource = suggestedOffers;
                dgvSuggestedOffers.Columns["Id"].Visible = false;
            }
        }
    }
}
