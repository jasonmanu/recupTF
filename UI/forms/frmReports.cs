using Entities.Enums;
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
    public partial class frmReports : Form
    {
        private DateTime selectedDate;

        public frmReports()
        {
            InitializeComponent();
        }

        private void frmReports_Load(object sender, EventArgs e)
        {
            dtpDate.Format = DateTimePickerFormat.Custom;
            dtpDate.CustomFormat = "MMM-yyyy";
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            selectedDate = dtpDate.Value;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
