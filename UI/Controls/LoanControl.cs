using BLL;
using Entities;
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
    public partial class LoanControl : UserControl
    {
        private ILoanService loanService;
        private User user;

        public LoanControl(ILoanService loanService, User user)
        {
            this.Dock = DockStyle.Fill;
            InitializeComponent();
            this.loanService = loanService;
            this.user = user;
        }
    }
}
