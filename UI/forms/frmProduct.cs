using BLL;
using Entities;
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

        public frmProduct(IProductService productService)
        {
            InitializeComponent();
            this.productService = productService;
        }

        private void frmProduct_Load(object sender, EventArgs e)
        {
            products = new List<Product>
            {
                //new Product("Name 1", "desc 1", 1),
                //new Product("Name 2", "desc 2", 2)
            };

            dgvProducts.DataSource = products;
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
