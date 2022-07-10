using BLL.Contracts;
using Entities;
using System;
using System.Windows.Forms;
using UI.forms;

namespace UI
{
    public partial class MDIBase : Form
    {
        private readonly IOfferService offerService;
        private readonly ICategoryService categoryService;
        private readonly ISuggestedOfferService suggestedOfferService;

        public MDIBase(UserRole userRole, IOfferService offerService, ICategoryService categoryService, ISuggestedOfferService suggestedOfferService)
        {
            InitializeComponent();
            LoadRoleButtons(userRole);
            this.offerService = offerService;
            this.categoryService = categoryService;
            this.suggestedOfferService = suggestedOfferService;
        }

        #region Login
        private void LoadRoleButtons(UserRole userRole)
        {
            switch (userRole)
            {
                case UserRole.ADMIN:
                    sellersMenu.Visible = true;
                    reportsMenu.Visible = true;
                    productsMenu.Visible = true;
                    offersMenu.Visible = true;
                    break;
                case UserRole.SELLER:
                    offersMenu.Visible = true;
                    productsMenu.Visible = true;
                    break;
                case UserRole.SHOPPER:
                    ordersMenu.Visible = true;
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region Offers
        private void createOfferMenu_Click(object sender, EventArgs e)
        {
            new frmCreateOffer(offerService, categoryService) { MdiParent = this }.Show();
        }

        private void btnCreateOffer_Click(object sender, EventArgs e)
        {
            var formCreateOffer = new frmCreateOffer(offerService, categoryService)
            {
                MdiParent = this
            };
            formCreateOffer.Show();
        }

        private void btnGetOffers_Click(object sender, EventArgs e)
        {
            new frmManageOffer(offerService, categoryService) { MdiParent = this }.Show();
        }

        private void btnSuggestedOffers_Click(object sender, EventArgs e)
        {
            new frmSuggestedOffers(suggestedOfferService) { MdiParent = this }.Show();
        }
        #endregion

        #region Reports
        private void reportsMenu_Click(object sender, EventArgs e)
        {
            new frmReports() { MdiParent = this }.Show();
        }
        #endregion      
    }
}
