using BLL;
using BLL.Contracts;
using Entities;
using Entities.Enums;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;
using UI.forms;

namespace UI
{
    public partial class MDIBase : Form
    {
        private readonly IServiceProvider serviceProvider;
        private readonly IOfferService offerService;
        private readonly ISuggestedOfferService suggestedOfferService;
        private readonly ICategoryService categoryService;
        private readonly IBrandService brandService;
        private readonly IProductService productService;
        private readonly IOrderService orderService;
        private readonly IBackupService backupService;
        private User user;

        public MDIBase(User user, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            this.serviceProvider = serviceProvider;
            this.offerService = serviceProvider.GetRequiredService<IOfferService>();
            this.suggestedOfferService = serviceProvider.GetRequiredService<ISuggestedOfferService>();
            this.categoryService = serviceProvider.GetRequiredService<ICategoryService>();
            this.brandService = serviceProvider.GetRequiredService<IBrandService>();
            this.orderService = serviceProvider.GetRequiredService<IOrderService>();
            this.productService = serviceProvider.GetRequiredService<IProductService>();
            this.backupService = serviceProvider.GetRequiredService<IBackupService>();
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
            new frmCreateOffer(serviceProvider)
            {
                MdiParent = this
            }.Show();
        }

        private void btnGetOffers_Click(object sender, EventArgs e)
        {
            new frmManageOffer(serviceProvider) { MdiParent = this }.Show();
        }

        private void btnSuggestedOffers_Click(object sender, EventArgs e)
        {
            new frmSuggestedOffers(serviceProvider) { MdiParent = this }.Show();
        }
        #endregion

        private void MDIBase_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void productsMenu_Click(object sender, EventArgs e)
        {
            new frmProduct(user, serviceProvider) { MdiParent = this }.Show();
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
            new frmCategories(serviceProvider).Show();
        }

        private void brandMenu_Click(object sender, EventArgs e)
        {
            new frmBrand(serviceProvider).Show();
        }

        private void backupMenu_Click(object sender, EventArgs e)
        {
            new frmBackup(serviceProvider).Show();
        }

        private void myOffersMenu_Click(object sender, EventArgs e)
        {
            new frmMyOffers(serviceProvider, user).Show();
        }
    }
}
