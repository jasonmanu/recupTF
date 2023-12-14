using BLL;
using Entities;
using Entities.Enums;
using FormSupport;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace UI
{
    public partial class frmProduct : Form
    {
        //private readonly IProductService productService;
        //private readonly IOrderService orderService;
        //private readonly ICategoryService categoryService;
        //private readonly IBrandService brandService;
        //private readonly IOfferService offerService;
        ////private List<ProductDto> dgvDataSource = new List<ProductDto>();
        ////private bool updateButtonEnabled = false;
        //private User user;
        //private readonly IServiceProvider serviceProvider;

        public frmProduct(User user, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            //this.serviceProvider = serviceProvider;
            //this.productService = serviceProvider.GetRequiredService<IProductService>();
            //this.orderService = serviceProvider.GetRequiredService<IOrderService>();
            //this.categoryService = serviceProvider.GetRequiredService<ICategoryService>();
            //this.brandService = serviceProvider.GetRequiredService<IBrandService>();
            //this.offerService = serviceProvider.GetRequiredService<IOfferService>();
            //this.user = user;

            //if (user.Role == UserRole.SHOPPER)
            //{
            //    tlpShopper.Visible = true;
            //    tlpAdmin.Visible = false;
            //}
            //else
            //{
            //    tlpAdmin.Visible = true;
            //    tlpShopper.Visible = false;
            //}
        }

        private void frmProduct_Load(object sender, EventArgs e)
        {
            //LoadData();
            //LoadProductOffers();
            //cboBrand.DataSource = brandService.GetAll();
            //cboBrand.DisplayMember = "Name";
            //cboBrand.ValueMember = "Id";

            //cboCategory.DataSource = categoryService.GetAll();
            //cboCategory.DisplayMember = "Name";
            //cboCategory.ValueMember = "Id";

            //btnUpdate.Enabled = updateButtonEnabled;
        }

        private void LoadProductOffers()
        {
            //string productId = FormHelper.GetCurrentRowId(dgvProducts);
            //List<Offer> offers = offerService.GetOffersByProductId(productId);

            //lblDiscount.Text = string.Empty;

            //if (offers?.Count > 0)
            //{
            //    lblDiscount.Text = "Oferta/s\n";

            //    foreach (Offer offer in offers)
            //    {
            //        string discountText;

            //        if (offer.Type == DiscountTypeEnum.Amount)
            //        {
            //            discountText = $"${offer.Discount} ";
            //        }
            //        else
            //        {
            //            discountText = $"{offer.Discount}% ";
            //        }

            //        lblDiscount.Text += discountText;

            //        if (offer.CategoryId != null)
            //        {
            //            lblDiscount.Text += "de descuento por Categoria\n";
            //        }

            //        if (offer.BrandId != null)
            //        {
            //            lblDiscount.Text += "de descuento por Marca\n";
            //        }

            //        if (offer.ProductId != null)
            //        {
            //            lblDiscount.Text += "de descuento en este producto\n";
            //        }
            //    }
            //}
            //else
            //{
            //    lblDiscount.Text = "No hay ofertas para este producto";
            //}
        }

        private void LoadData()
        {
            //try
            //{
            //    dgvProducts.Refresh();
            //    var products = productService.GetExtendedProducts();

            //    if (products?.Count > 0)
            //    {
            //        foreach (var product in products)
            //        {
            //            product.PriceDiscount = offerService.CalculateFinalPriceForProduct(product.Id);
            //        }
            //    }

            //    dgvProducts.DataSource = products;

            //    dgvProducts.Columns["Id"].Visible = false;
            //    dgvProducts.Columns["BrandId"].Visible = false;
            //    dgvProducts.Columns["CategoryId"].Visible = false;

            //    dgvProducts.Columns["Name"].DisplayIndex = 0;
            //    dgvProducts.Columns["Description"].DisplayIndex = 1;
            //    dgvProducts.Columns["Price"].DisplayIndex = 2;
            //    dgvProducts.Columns["BrandName"].DisplayIndex = 3;
            //    dgvProducts.Columns["CategoryName"].DisplayIndex = 4;

            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    Product newProduct = new Product()
            //    {
            //        Name = txtName.Text,
            //        Description = txtDescription.Text,
            //        Price = Convert.ToInt32(nudPrice.Value),
            //        BrandId = (string)cboBrand.SelectedValue,
            //        CategoryId = (string)cboCategory.SelectedValue
            //    };

            //    productService.Create(newProduct);
            //    MessageBox.Show("Producto creado");
            //    LoadData();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    string id = FormHelper.GetCurrentRowId(dgvProducts);
            //    productService.Delete(id);
            //    MessageBox.Show("Eliminado");
            //    LoadData();
            //}
            //catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            //string productId = FormHelper.GetCurrentRowId(dgvProducts);

            //if (productId != null)
            //{
            //    try
            //    {
            //        orderService.Create(new Order() { ProductId = productId, Date = DateTime.Now, UserId = user.Id, TotalPrice = offerService.CalculateFinalPriceForProduct(productId) });
            //        MessageBox.Show("Producto comprado correctamente");
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //}
        }

        private void dgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            //updateButtonEnabled = true;
            LoadProductOffers();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    string id = FormHelper.GetCurrentRowId(dgvProducts);
            //    Product toUpdate = new Product()
            //    {
            //        Id = id,
            //        Name = txtName.Text,
            //        BrandId = (string)cboBrand.SelectedValue,
            //        CategoryId = (string)cboCategory.SelectedValue,
            //        Description = txtDescription.Text,
            //        Price = Convert.ToInt32(nudPrice.Value)
            //    };
            //    productService.Update(toUpdate);
            //    MessageBox.Show("Actualizado");
            //    LoadData();
            //}
            //catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dgvProducts_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
        }
    }
}
