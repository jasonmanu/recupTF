using BLL;
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
            int? id = GetCurrentId();

            if (id != null)
            {
                offerService.Delete((int)id);
                LoadOffers();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int? id = GetCurrentId();

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
            int? id = GetCurrentId();

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
            new frmCreateOffer(offerService, categoryService)
            {
                StartPosition = FormStartPosition.CenterScreen
            }.Show();

            LoadOffers();
        }
    }
}
