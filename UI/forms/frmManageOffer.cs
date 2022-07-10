using BLL.Contracts;
using Entities;
using Entities.Enums;
using FormSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace UI.forms
{
    public partial class frmManageOffer : Form
    {
        private readonly IOfferService offerService;
        private readonly ICategoryService categoryService;
        private List<Offer> offers;

        public frmManageOffer(IOfferService offerService, ICategoryService categoryService)
        {
            this.offerService = offerService;
            this.categoryService = categoryService;
            InitializeComponent();
            cboType.DataSource = Enum.GetValues(typeof(DiscountTypeEnum));
        }

        private void frmManageOffer_Load(object sender, EventArgs e)
        {
            LoadOffers();
        }

        private void LoadOffers()
        {
            offers = offerService.GetAll();

            if (offers != null)
            {
                try
                {
                    dgvOffers.DataSource = offers;
                    dgvOffers.Columns["Id"].Visible = false;
                    dgvOffers.Columns["Name"].Width = 150;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int? id = FormHelper.GetCurrentRowId(dgvOffers);

            if (id != null)
            {
                offerService.Delete((int)id);
                LoadOffers();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int? id = FormHelper.GetCurrentRowId(dgvOffers);

            if (offers != null)
            {
                Offer currentDiscount = offers.FirstOrDefault(x => x.Id == id);
                currentDiscount.Discount = Convert.ToInt32(nudDiscount.Value);
                currentDiscount.Type = (DiscountTypeEnum)cboType.SelectedValue;
                currentDiscount.Name = txtName.Text;
                currentDiscount.Active = checkActive.Checked;

                offerService.Update(currentDiscount);// con ORM va a funcionar, porque los datos se actualizan y leen, ahora solo lee lo no modificado
                LoadOffers();
            }
        }

        private void dgvOffers_SelectionChanged(object sender, EventArgs e)
        {
            int? id = FormHelper.GetCurrentRowId(dgvOffers);

            if (id != null)
            {
                Offer currentOffer = offers?.FirstOrDefault(x => x.Id == id);

                if (currentOffer != null)
                {
                    txtName.Text = currentOffer.Name;
                    checkActive.Checked = currentOffer.Active;
                    nudDiscount.Value = currentOffer.Discount;
                    cboType.SelectedItem = currentOffer.Type;
                }
            }
        }

        private void btnCreateDiscount_Click(object sender, EventArgs e)
        {
            new frmCreateOffer(offerService, categoryService).Show();
            LoadOffers();
        }
    }
}
