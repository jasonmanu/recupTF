using BLL.Contracts;
using Entities;
using Entities.Enums;
using System;
using System.Windows.Forms;
using UI.forms;

namespace UI
{
    public partial class MDIBase : Form
    {
        private readonly IOfferService offerService;
        private readonly ISuggestedOfferService suggestedOfferService;
        private readonly ICategoryService categoryService;
        private readonly IBrandService brandService;
        private readonly IProductService productService;
        private readonly IOrderService purchaseService;
        private User user;

        public MDIBase(User user, IOfferService offerService, ISuggestedOfferService suggestedOfferService, ICategoryService categoryService, IBrandService brandService, IProductService productService, IOrderService purchaseService)
        {
            InitializeComponent();

            this.offerService = offerService;
            this.suggestedOfferService = suggestedOfferService;
            this.brandService = brandService;
            this.productService = productService;
            this.purchaseService = purchaseService;
            this.categoryService = categoryService;
            this.user = user;

            LoadRoleButtons();
        }

        #region Login
        private void LoadRoleButtons()
        {
            UserRole userRole = UserRole.SELLER;//user.Role

            switch (userRole)
            {
                case UserRole.ADMIN:
                    reportsMenu.Visible = true;
                    productsMenu.Visible = true;
                    offersMenu.Visible = true;
                    break;
                case UserRole.SELLER:
                    offersMenu.Visible = true;
                    productsMenu.Visible = true;
                    productsMenu.Visible = true;
                    break;
                case UserRole.SHOPPER:
                    productsMenu.Visible = true;
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region Offers
        private void btnCreateOffer_Click(object sender, EventArgs e)
        {
            new frmCreateOffer(offerService, productService, categoryService, brandService)
            {
                MdiParent = this
            }.Show();
        }

        private void btnGetOffers_Click(object sender, EventArgs e)
        {
            new frmManageOffer(offerService, categoryService, brandService, productService) { MdiParent = this }.Show();
        }

        private void btnSuggestedOffers_Click(object sender, EventArgs e)
        {
            new frmSuggestedOffers(suggestedOfferService, offerService) { MdiParent = this }.Show();
        }
        #endregion

        #region Reports
        private void reportsMenu_Click(object sender, EventArgs e)
        {
            new frmReports(purchaseService) { MdiParent = this }.Show();
        }
        #endregion

        private void MDIBase_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void productsMenu_Click(object sender, EventArgs e)
        {
            new frmProduct(user, productService, purchaseService, categoryService, brandService, offerService) { MdiParent = this }.Show();
        }
    }
}
