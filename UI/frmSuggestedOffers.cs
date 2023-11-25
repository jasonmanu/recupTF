using BLL.Contracts;
using Entities;
using FormSupport;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace UI.forms
{
    public partial class frmSuggestedOffers : Form
    {
        private readonly ISuggestedOfferService suggestedOfferService;
        private readonly IOfferService offerService;
        private readonly IServiceProvider serviceProvider;
        private List<SuggestedOffer> suggestedOffers;

        public frmSuggestedOffers(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            this.serviceProvider = serviceProvider;
            this.suggestedOfferService = serviceProvider.GetRequiredService<ISuggestedOfferService>();
            this.offerService = serviceProvider.GetRequiredService<IOfferService>();
        }

        private void frmSuggestedOffers_Load(object sender, EventArgs e)
        {
            LoadSuggestedOffers();
        }

        private void LoadSuggestedOffers()
        {
            dgvSuggestedOffers.DataSource = null;
            dgvSuggestedOffers.Refresh();

            suggestedOffers = suggestedOfferService.GetAll();
            if (suggestedOffers?.Count > 0)
            {
                dgvSuggestedOffers.DataSource = suggestedOffers;
            }
        }

        //private void btnCreate_Click(object sender, EventArgs e)
        //{
        //    string currentId = FormHelper.GetCurrentRowId(dgvSuggestedOffers);

        //    if (currentId != null)
        //    {
        //        SuggestedOffer suggestedOffer = suggestedOffers.FirstOrDefault(x => x.Id ==  Convert.ToString(currentId));
        //        suggestedOfferService.Delete(currentId);

        //        offerService.Create(new Offer()
        //        {
        //            Active = DateHelper.GetOfferStatusByCurrentDate(suggestedOffer.Start, suggestedOffer.End),
        //            CreatedAt = DateTime.Now,
        //            Discount = suggestedOffer.Discount,
        //            Start = suggestedOffer.Start,
        //            End = suggestedOffer.End,
        //            Name = suggestedOffer.Name,
        //            Type = suggestedOffer.Type,
        //            CategoryId = Convert.ToString(suggestedOffer.CategoryId) ,
        //            BrandId = Convert.ToString(suggestedOffer.BrandId),
        //            ProductId = Convert.ToString(suggestedOffer.ProductId)
        //        });

        //        MessageBox.Show("Creado correctamente");
        //        LoadSuggestedOffers();
        //    }
        //}
    }
}
