﻿using BLL.Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace UI.forms
{
    public partial class frmReports : Form
    {
        private readonly IPurchaseService purchaseService;

        public frmReports(IPurchaseService purchaseService)
        {
            InitializeComponent();
            this.purchaseService = purchaseService;
        }

        private void frmReports_Load(object sender, EventArgs e)
        {
            dtpDate.Value = DateTime.Now;
            dtpDate.Format = DateTimePickerFormat.Custom;
            dtpDate.CustomFormat = "MMM-yyyy";


            LoadRevenueData();
            LoadPurchasesData();
        }

        private void LoadPurchasesData()
        {
            chartSells.Titles.Add($"Cantidad de Ventas {dtpDate.Value.Year} por mes");
            var sellsPerMonth = purchaseService.GetPurchasesPerMonths(dtpDate.Value.Year);

            if (sellsPerMonth!= null && sellsPerMonth.Count> 0)
            {
                foreach (PurchasePerMonth sellPerMonth in sellsPerMonth)
                {
                    chartSells.Series["Ventas"].Points.AddXY(sellPerMonth.Month, sellPerMonth.Purchases);
                }
            }
        }

        private void LoadRevenueData()
        {
            chartRevenue.Titles.Add($"Ganancias de {dtpDate.Value.Year} por mes");
            List<RevenuePerMonth> revenuePerMonth = purchaseService.GetRevenuePerMonths(dtpDate.Value.Year);

            if (revenuePerMonth != null && revenuePerMonth.Count > 0)
            {
                foreach (RevenuePerMonth revPerMonth in revenuePerMonth)
                {
                    chartRevenue.Series["Ganancias"].Points.AddXY(revPerMonth.Month, revPerMonth.Revenue);
                }
            }
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            LoadRevenueData();
            LoadPurchasesData();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
