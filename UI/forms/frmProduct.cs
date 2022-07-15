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
            LoadProductOffers();
        }

        private void LoadProductOffers()
        {
            int productId = (int)FormHelper.GetCurrentRowId(dgvProducts);
            List<Offer> offers = offerService.GetOffersByProductId(productId);

            lblDiscount.Text = string.Empty;

            if (offers != null && offers.Count > 0)
            {
                lblDiscount.Text = "Oferta/s\n";

                foreach (Offer offer in offers)
                {
                    string discountText;

                    if (offer.Type == DiscountTypeEnum.Amount)
                    {
                        discountText = $"${offer.Discount} ";
                    }
                    else
                    {
                        discountText = $"{offer.Discount}% ";
                    }

                    lblDiscount.Text += discountText;

                    if (offer.CategoryId != null)
                    {
                        lblDiscount.Text += "de descuento por Categoria\n";
                    }

                    if (offer.BrandId != null)
                    {
                        lblDiscount.Text += "de descuento por Marca\n";
                    }

                    if (offer.ProductId != null)
                    {
                        lblDiscount.Text += "de descuento en este producto\n";
                    }
                }
            }
            else
            {
                lblDiscount.Text = "No hay ofertas para este producto";
            }
        }

        private void LoadProducts()
        {
            List<Product> products = productService.GetAll();
            List<ProductDto> productsDto = new List<ProductDto>();

            if (products != null && products.Count > 0)
            {
                foreach (Product product in products)
                {
                    productsDto.Add(new ProductDto()
                    {
                        BrandId = product.BrandId,
                        CategoryId = product.CategoryId,
                        Id = product.Id,
                        Name = product.Name,
                        BrandName = brandService.GetNameById(product.BrandId),
                        Description = product.Description,
                        Price = product.Price,
                        PriceDiscount = offerService.CalculateFinalPriceForProduct(product.Id)
                    });
                }

                try
                {
                    dgvProducts.Refresh();
                    dgvProducts.DataSource = productsDto;

                    dgvProducts.Columns["Id"].Visible = false;
                    dgvProducts.Columns["BrandId"].Visible = false;
                    dgvProducts.Columns["CategoryId"].Visible = false;

                    dgvProducts.Columns["Name"].DisplayIndex = 0;
                    dgvProducts.Columns["BrandName"].DisplayIndex = 1;
                    dgvProducts.Columns["Description"].DisplayIndex = 2;
                    dgvProducts.Columns["Price"].DisplayIndex = 3;

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
                try
                {
                    purchaseService.Create(new Purchase() { ProductId = (int)productId, Date = DateTime.Now, UserId = user.Id, TotalPrice = offerService.CalculateFinalPriceForProduct((int)productId) });
                    MessageBox.Show("Producto comprado correctamente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            LoadProductOffers();
        }
    }
}
