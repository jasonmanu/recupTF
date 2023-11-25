using BLL.Contracts;
using Entities;
using Entities.Enums;
using FormSupport;
using Microsoft.Extensions.DependencyInjection;
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
        private readonly IBrandService brandService;
        private readonly IProductService productService;
        private readonly IServiceProvider serviceProvider;
        private List<Offer> offers;

        public frmManageOffer(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            this.serviceProvider = serviceProvider;
            this.offerService = serviceProvider.GetRequiredService<IOfferService>();
            this.categoryService = serviceProvider.GetRequiredService<ICategoryService>();
            this.brandService = serviceProvider.GetRequiredService<IBrandService>();
            this.productService = serviceProvider.GetRequiredService<IProductService>();
            cboType.DataSource = Enum.GetValues(typeof(DiscountTypeEnum));
        }

        private void frmManageOffer_Load(object sender, EventArgs e)
        {
            LoadOffers();
        }

        private void LoadOffers()
        {
            offers = offerService.GetAll();
            List<OfferDto> offersDto = new List<OfferDto>();

            if (offers != null)
            {
                foreach (Offer offer in offers)
                {
                    offersDto.Add(new OfferDto()
                    {
                        Active = DateHelper.GetOfferStatusByCurrentDate(offer.Start, offer.End),
                        Marca = offer.BrandId != null ? brandService.GetNameById(offer.BrandId) : null,
                        Categoria = offer.CategoryId != null ? categoryService.GetNameById(offer.CategoryId) : null,
                        Producto = offer.ProductId != null ? productService.GetById(offer.ProductId)?.Name : null,
                        CreatedAt = offer.CreatedAt,
                        Discount = offer.Discount,
                        Inicio = offer.Start.ToShortDateString(),
                        Fin = offer.End.ToShortDateString(),
                        Id = offer.Id,
                        BrandId = offer.BrandId,
                        CategoryId = offer.CategoryId,
                        End = offer.End,
                        Start = offer.Start,
                        Name = offer.Name,
                        ProductId = offer.ProductId,
                        Type = offer.Type
                    });
                }

                try
                {
                    dgvOffers.Refresh();
                    dgvOffers.DataSource = offersDto;
                    //dgvOffers.Columns["Id"].Visible = true;
                    dgvOffers.Columns["BrandId"].Visible = false;
                    dgvOffers.Columns["CategoryId"].Visible = false;
                    dgvOffers.Columns["ProductId"].Visible = false;
                    dgvOffers.Columns["CreatedAt"].Visible = false;
                    dgvOffers.Columns["Start"].Visible = false;
                    dgvOffers.Columns["End"].Visible = false;
                    dgvOffers.Columns["Name"].Width = 150;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = FormHelper.GetCurrentRowId(dgvOffers);

            if (id != null)
            {
                offerService.Delete(id);
                LoadOffers();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string id = FormHelper.GetCurrentRowId(dgvOffers);

            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("Seleccione fila a actualizar");
            }
            else
            {
                Offer currentDiscount = offerService.GetById(id);
                currentDiscount.Discount = Convert.ToInt32(nudDiscount.Value);
                currentDiscount.Type = (DiscountTypeEnum)cboType.SelectedValue;
                currentDiscount.Name = txtName.Text;
                currentDiscount.Active = checkActive.Checked;

                offerService.Update(currentDiscount);
                LoadOffers();
            }
        }

        private void dgvOffers_SelectionChanged(object sender, EventArgs e)
        {
        }
    }
}
