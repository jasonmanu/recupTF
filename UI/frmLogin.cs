using BLL;
using BLL.Contracts;
using Entities;
using Entities.Enums;
using System;
using System.Windows.Forms;

namespace UI.forms
{
    public partial class frmLogin : Form
    {
        private readonly IUserService userService;
        private readonly IOfferService offerService;
        private readonly ISuggestedOfferService suggestedOfferService;
        private readonly ICategoryService categoryService;
        private readonly IBrandService brandService;
        private readonly IProductService productService;
        private readonly IOrderService purchaseService;
        private readonly IBackupService backupService;

        public frmLogin(IUserService userService, IOfferService offerService, ISuggestedOfferService suggestedOfferService, ICategoryService categoryService, IBrandService brandService, IProductService productService, IOrderService purchaseService, IBackupService backupService)
        {
            InitializeComponent();
            this.userService = userService;
            this.offerService = offerService;
            this.suggestedOfferService = suggestedOfferService;
            this.categoryService = categoryService;
            this.brandService = brandService;
            this.purchaseService = purchaseService;
            this.productService = productService;
            this.backupService = backupService;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            User loggedUser = userService.Login(username, password);

            if (loggedUser == null)
            {
                MessageBox.Show("Usuario y/o contraseña no validos");
            }
            else
            {
                Hide();
                new MDIBase(loggedUser, offerService, suggestedOfferService, categoryService, brandService, productService, purchaseService, backupService).Show();
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtUsername.Text;

            try
            {
                userService.Register(new User(username, password, UserRole.SHOPPER));
                MessageBox.Show("Registrado Correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
