using BLL;
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
        private readonly IProductService productService;
        private readonly IBrandService brandService;
        private readonly ICategoryService categoryService;

        public frmCreateOffer(IOfferService offerService, IProductService productService, ICategoryService categoryService, IBrandService brandService)
        {
            InitializeComponent();
            this.offerService = offerService;
            this.productService = productService;
            this.categoryService = categoryService;
            this.brandService = brandService;
            LoadOfferConnections();
        }

        private void LoadOfferConnections()
        {
            dtpStart.Value = DateTime.Now;
            dtpEnd.Value = DateTime.Now.AddDays(7);
            cboType.DataSource = Enum.GetValues(typeof(DiscountTypeEnum));

            try
            {
                cboBrand.DataSource = brandService.GetAll();
                cboBrand.DisplayMember = "Name";
                cboBrand.ValueMember = "Id";

                cboCategory.DataSource = categoryService.GetAll();
                cboCategory.DisplayMember = "Name";
                cboCategory.ValueMember = "Id";

                cboProduct.DataSource = productService.GetAll();
                cboProduct.DisplayMember = "Name";
                cboProduct.ValueMember = "Id";
            }
            catch (Exception)
            {

                throw;
            }
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

            int brandId = Convert.ToInt32(cboBrand.SelectedValue);
            int productId = Convert.ToInt32(cboProduct.SelectedValue);
            int categoryId = Convert.ToInt32(cboCategory.SelectedValue);
            //TODO crear relacion entre oferta y brand/category/product, solo 1

            DateTime currentDate = DateTime.Now;
            DateTime startDate = dtpStart.Value;
            DateTime endDate = dtpEnd.Value;

            if (currentDate >= startDate && currentDate <= endDate)
            {
                newOffer.Active = true;
            }

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

        private void rbtnCategory_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnCategory.Checked)
            {
                cboCategory.Enabled = true;
                cboBrand.Enabled = false;
                cboProduct.Enabled = false;
            }
        }

        private void rbtnBrand_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnBrand.Checked)
            {
                cboBrand.Enabled = true;
                cboCategory.Enabled = false;
                cboProduct.Enabled = false;
            }
        }

        private void rbtnProducto_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnProducto.Checked)
            {
                cboProduct.Enabled = true;
                cboCategory.Enabled = false;
                cboBrand.Enabled = false;
            }
        }
    }
}
