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

        public frmCreateOffer(IOfferService offerService, ICategoryService categoryService)
        {
            this.offerService = offerService;
            InitializeComponent();
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
