using BLL;
using BLL.Contracts;
using Entities;
using Entities.Enums;
using FormSupport;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using UI.forms;

namespace UI
{
    public partial class frmProduct : Form
    {
        private readonly IProductService productService;
        private readonly IPurchaseService purchaseService;
        private readonly ICategoryService categoryService;
        private readonly IBrandService brandService;
        private readonly IOfferService offerService;
        private User user;
        private List<Product> products;

        public frmProduct(User user, IProductService productService, IPurchaseService purchaseService, ICategoryService categoryService, IBrandService brandService, IOfferService offerService)
        {
            InitializeComponent();
            this.productService = productService;
            this.purchaseService = purchaseService;
            this.categoryService = categoryService;
            this.brandService = brandService;
            this.offerService = offerService;
            this.user = user;

            if (user.Role == UserRole.SHOPPER)
            {
                tlpShopper.Visible = true;
                tlpAdmin.Visible = false;
            }
            else
            {
                tlpAdmin.Visible = true;
                tlpShopper.Visible = false;
            }
        }

        private void frmProduct_Load(object sender, EventArgs e)
        {
            LoadProducts();
            LoadProductDiscounts();
        }

        private void LoadProductDiscounts()
        {
            int productId = (int)FormHelper.GetCurrentRowId(dgvProducts);
            List<Offer> offers = offerService.GetOffersByProductId(productId);

            if (offers != null )// add length
            {
            }

            lblDiscount.Text += "\n";

            //if (productId != null)
            //{
            //    Offer currentOffer = offers?.FirstOrDefault(x => x.Id == id);

            //    if (currentOffer != null)
            //    {
            //        txtName.Text = currentOffer.Name;
            //        checkActive.Checked = currentOffer.Active;
            //        nudDiscount.Value = currentOffer.Discount;
            //        cboType.SelectedItem = currentOffer.Type;
            //    }
            //}
        }

        private void LoadProducts()
        {
            List<Product> products = productService.GetAll();

            if (products != null)
            {
                try
                {
                    dgvProducts.Refresh();
                    dgvProducts.DataSource = products;
                    dgvProducts.Columns["Id"].Visible = false;
                    dgvProducts.Columns["BrandId"].Visible = false;
                    dgvProducts.Columns["CategoryId"].Visible = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            new frmCreateProduct(categoryService, brandService, productService).Show();
            LoadProducts();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int? productId = FormHelper.GetCurrentRowId(dgvProducts);

            if (productId == null)
            {
                MessageBox.Show("Select a product row");
            }
            else
            {
                if (productId != null)
                {
                    productService.Delete(Convert.ToInt32(productId));
                    MessageBox.Show("deleting");
                }
            }
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            int? productId = FormHelper.GetCurrentRowId(dgvProducts);

            if (productId != null)
            {
                purchaseService.Create(new Purchase() { ProductId = (int)productId, Date = DateTime.Now, UserId = user.Id });
            }
        }
    }
}
