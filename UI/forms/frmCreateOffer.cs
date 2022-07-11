using BLL.Contracts;
using Entities;
using Entities.Enums;
using System;
using System.Windows.Forms;

namespace UI.forms
{
    public partial class frmCreateOffer : Form
    {
        private readonly IOfferService offerService;

        public frmCreateOffer(IOfferService offerService)
        {
            InitializeComponent();
            this.offerService = offerService;

            // valores iniciales de nueva oferta
            dtpStart.Value = DateTime.Now;
            dtpEnd.Value = DateTime.Now.AddDays(7);
            cboType.DataSource = Enum.GetValues(typeof(DiscountTypeEnum));
            cboCategory.DataSource = Enum.GetValues(typeof(CategoryEnum));
        }


        private void btnCreate_Click(object sender, EventArgs e)
        {
            Offer newOffer = new Offer()
            {
                Active = false,
                Discount = Convert.ToInt32(nudDiscount.Value),
                Start = DateTime.Now,
                End = DateTime.Now,
                Name = txtName.Text,
                Type = (DiscountTypeEnum)cboType.SelectedValue
            };

            DateTime currentDate = DateTime.Now;
            DateTime startDate = dtpStart.Value;
            DateTime endDate = dtpEnd.Value;

            if (currentDate >= startDate && currentDate <= endDate)
            {
                newOffer.Active = true;
            }

            // select category/product

            try
            {
                // creacion de oferta con valores del usuario
                offerService.Create(newOffer);
                MessageBox.Show("Oferta creada correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
