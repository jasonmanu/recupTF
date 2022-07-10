using BLL.Contracts;
using Entities;
using Entities.Enums;
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
    public partial class frmCreateOffer : Form
    {
        private readonly IOfferService offerService;

        public frmCreateOffer(IOfferService offerService)
        {
            this.offerService = offerService;
            InitializeComponent();
        }

        private void frmCreateOffer_Load(object sender, EventArgs e)
        {

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Offer newOffer = new Offer()
            {
                Active = true,
                Discount = Convert.ToInt32(nudDiscount.Value),
                Start = DateTime.Now,
                End = DateTime.Now,
                Name = txtName.Text,
                Suggested = false,
                Type = (DiscountTypeEnum)cboType.SelectedValue
            };

            offerService.Create(newOffer);
        }
    }
}
