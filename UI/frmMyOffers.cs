using BLL.Contracts;
using Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class frmMyOffers : Form
    {
        private readonly IOrderService orderService;
        private readonly IOfferService offerService;
        private readonly IProductService productService;
        private readonly User user;

        public frmMyOffers(IServiceProvider serviceProvider, User user)
        {
            InitializeComponent();
            this.orderService = serviceProvider.GetRequiredService<IOrderService>();
            this.offerService = serviceProvider.GetRequiredService<IOfferService>();
            this.productService = serviceProvider.GetRequiredService<IProductService>();
            this.user = user;
            LoadMyOffers();
        }

        private void LoadMyOffers()
        {
            try
            {
                List<Order> myOrders = orderService.GetAll().Where(x => x.UserId == user.Id).ToList();

                if (myOrders?.Count > 0)
                {
                    Dictionary<string, int> productPurchaseCounts = new Dictionary<string, int>();

                    foreach (Order order in myOrders)
                    {
                        if (productPurchaseCounts.ContainsKey(order.ProductId))
                        {
                            productPurchaseCounts[order.ProductId]++;
                        }
                        else
                        {
                            productPurchaseCounts[order.ProductId] = 1;
                        }
                    }

                    KeyValuePair<string, int> mostPurchasedProduct = productPurchaseCounts.OrderByDescending(kv => kv.Value).FirstOrDefault();
                    List<Offer> offersForMostPurchasedProduct = offerService.GetOffersByProductId(mostPurchasedProduct.Key);

                    if (offersForMostPurchasedProduct?.Count > 0)
                    {
                        Product productData = productService.GetById(mostPurchasedProduct.Key);
                        lblOfertas.Text = $"Existen ofertas para su producto mas comprado: {productData.Name}, puede revisarlas en pestaña products";
                    }
                }
                else
                {
                    lblOfertas.Text = "No hay ofertas encontradas para usted actualmente";
                }
            }
            catch (Exception)
            {
                lblOfertas.Text = "No hay ofertas encontradas para usted actualmente";
            }
        }

        private void lblOfertas_Click(object sender, EventArgs e)
        {
        }
    }
}
