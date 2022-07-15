using BLL.Contracts;
using Entities;
using Entities.Enums;
using FormSupport;
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
        private List<Offer> offers;

        public frmManageOffer(IOfferService offerService, ICategoryService categoryService, IBrandService brandService, IProductService productService)
        {
            InitializeComponent();
            this.offerService = offerService;
            this.categoryService = categoryService;
            this.brandService = brandService;
            this.productService = productService;
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
                        Marca = offer.BrandId != null ? brandService.GetNameById((int)offer.BrandId) : null,
                        Categoria = offer.CategoryId != null ? categoryService.GetNameById((int)offer.CategoryId) : null,
                        Producto = offer.ProductId != null ? productService.GetById((int)offer.ProductId).Name : null,
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
                    dgvOffers.Columns["Id"].Visible = false;
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
            int? id = FormHelper.GetCurrentRowId(dgvOffers);

            if (id != null)
            {
                offerService.Delete((int)id);
                LoadOffers();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int? id = FormHelper.GetCurrentRowId(dgvOffers);

            if (offers != null)
            {
                Offer currentDiscount = offers.FirstOrDefault(x => x.Id == id);
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
            int? id = FormHelper.GetCurrentRowId(dgvOffers);

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
    }
}
