using BLL;
using BLL.Contracts;
using Entities;
using Entities.Enums;
using Microsoft.Extensions.DependencyInjection;
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
        private readonly IServiceProvider serviceProvider;

        public frmCreateOffer(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            this.serviceProvider = serviceProvider;
            this.offerService = serviceProvider.GetRequiredService<IOfferService>();
            this.productService = serviceProvider.GetRequiredService<IProductService>();
            this.categoryService = serviceProvider.GetRequiredService<ICategoryService>();
            this.brandService = serviceProvider.GetRequiredService<IBrandService>();
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
                Id = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.Now,
                Active = false,
                Discount = Convert.ToInt32(nudDiscount.Value),
                Start = dtpStart.Value,
                End = dtpEnd.Value,
                Name = txtName.Text,
                Type = (DiscountTypeEnum)cboType.SelectedValue
            };

            if (rbtnBrand.Checked)
            {
                newOffer.BrandId = (string)cboBrand.SelectedValue;
                newOffer.CategoryId = null;
                newOffer.ProductId = null;
            }

            if (rbtnCategory.Checked)
            {
                newOffer.BrandId = null;
                newOffer.CategoryId = (string)cboCategory.SelectedValue;
                newOffer.ProductId = null;
            }

            if (rbtnProducto.Checked)
            {
                newOffer.BrandId = null;
                newOffer.CategoryId = null;
                newOffer.ProductId = (string)cboProduct.SelectedValue;
            }

            DateTime currentDate = DateTime.Now;
            DateTime startDate = dtpStart.Value;
            DateTime endDate = dtpEnd.Value;

            if (currentDate >= startDate && currentDate <= endDate)
            {
                newOffer.Active = true;
            }
            else
            {
                newOffer.Active = false;
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

        private void frmCreateOffer_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
