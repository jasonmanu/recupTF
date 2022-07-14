using BLL.Contracts;
using Entities;
using System;
using System.Windows.Forms;

namespace UI.forms
{
    public partial class frmCreateProduct : Form
    {
        private readonly ICategoryService categoryService;
        private readonly IBrandService brandService;
        private readonly IProductService productService;

        public frmCreateProduct(ICategoryService categoryService, IBrandService brandService, IProductService productService)
        {
            InitializeComponent();
            this.categoryService = categoryService;
            this.brandService = brandService;
            this.productService = productService;
        }

        private void frmCreateProduct_Load(object sender, EventArgs e)
        {
            cboBrand.DataSource = brandService.GetAll();
            cboBrand.DisplayMember = "Name";
            cboBrand.ValueMember = "Id";

            cboCategory.DataSource = categoryService.GetAll();
            cboCategory.DisplayMember = "Name";
            cboCategory.ValueMember = "Id";
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Product newProduct = new Product()
            {
                Name = txtName.Text,
                Description = txtDescription.Text,
                Price = Convert.ToInt32(nudPrice.Value),
                BrandId = (int)cboBrand.SelectedValue,
                CategoryId = (int)cboCategory.SelectedValue
            };

            try
            {
                productService.Create(newProduct);
                MessageBox.Show("Producto creado");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
