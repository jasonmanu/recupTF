using BLL.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.forms
{
    public partial class frmCreateOffer : Form
    {
        private readonly IOfferService offerService;

        public frmCreateOffer(IOfferService offerService)
        {
            this.offerService = offerService;
            InitializeComponent();
        }
    }
}
