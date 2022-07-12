using BLL;
using Entities;
using Entities.Enums;
using FormSupport;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace UI
{
    public partial class frmProduct : Form
    {
        private readonly IProductService productService;
        private List<Product> products;
        private UserRole userRole;

        public frmProduct(UserRole userRole, IProductService productService)
        {
            InitializeComponent();
            this.productService = productService;
            this.userRole = userRole;

            if (userRole == UserRole.SHOPPER)
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
    }
}
