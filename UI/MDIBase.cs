using BLL;
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
        private readonly IBackupService backupService;
        private User user;

        public MDIBase(User user, IOfferService offerService, ISuggestedOfferService suggestedOfferService, ICategoryService categoryService, IBrandService brandService, IProductService productService, IOrderService purchaseService, IBackupService backupService)
        {
            InitializeComponent();
            this.offerService = offerService;
            this.suggestedOfferService = suggestedOfferService;
            this.brandService = brandService;
            this.productService = productService;
            this.purchaseService = purchaseService;
            this.backupService = backupService;
            this.categoryService = categoryService;
            this.user = user;
            LoadRoleButtons();
        }

        #region Role
        private void LoadRoleButtons()
        {
            if (user.Role == UserRole.SHOPPER)
            {
                productsMenu.Visible = true;
                categoriesMenu.Visible = false;
                backupMenu.Visible = false;
                offersMenu.Visible = false;
                backupMenu.Visible = false;
                brandMenu.Visible = false;
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

        private void MDIBase_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void productsMenu_Click(object sender, EventArgs e)
        {
            new frmProduct(user, productService, purchaseService, categoryService, brandService, offerService) { MdiParent = this }.Show();
        }

        #region Backup
        private void btnGenerateBackup_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Backup generado");
        }

        private void btnRestoreBackup_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Backup restaurado");
        }
        #endregion

        private void categoriesMenu_Click(object sender, EventArgs e)
        {
            new frmCategories(categoryService).Show();
        }

        private void brandMenu_Click(object sender, EventArgs e)
        {
            new frmBrand(brandService).Show();
        }

        private void backupMenu_Click(object sender, EventArgs e)
        {
            new frmBackup(backupService).Show();
        }

        private void myOffersMenu_Click(object sender, EventArgs e)
        {
            new frmMyOffers(orderService, user).Show();
        }
    }
}
