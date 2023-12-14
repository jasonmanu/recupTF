using BLL;
using Entities;
using FormSupport;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Controls
{
    public partial class SubscriptionTypeControl : UserControl
    {
        private readonly ISubscriptionTypeService subscriptionTypeService;
        private readonly ISubscriptionService subscriptionService;
        private readonly string userId = "";// TODO read from other side

        public SubscriptionTypeControl(ISubscriptionTypeService subscriptionTypeService, ISubscriptionService subscriptionService)
        {
            this.subscriptionTypeService = subscriptionTypeService;
            this.subscriptionService = subscriptionService;
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            dgvData.DataSource = subscriptionTypeService.GetAll();
            tlpCrud.Visible = true;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                subscriptionTypeService.Create(new SubscriptionType()
                {
                    LoanDays = (int)nudLoanDays.Value,
                    Name = txtName.Text,
                    Price = (int)nudPrice.Value,
                    MaxLoanBooks = 1//(int)nudPrice.MaxLoanBooks
                });

                MessageBox.Show("Creado correctamente");
                LoadData();
                txtName.ResetText();
                nudPrice.ResetText();
                nudLoanDays.ResetText();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error creando sub type");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string id = FormHelper.GetCurrentRowId(dgvData);

            try
            {
                SubscriptionType book = new SubscriptionType()
                {
                    Id = id,
                    LoanDays = (int)nudLoanDays.Value,
                    Name = txtName.Text,
                    Price = (int)nudPrice.Value
                };

                subscriptionTypeService.Update(book);
                MessageBox.Show("Actualizado correctamente");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error actualizando sub type");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = FormHelper.GetCurrentRowId(dgvData);

            try
            {
                subscriptionTypeService.Delete(id);
                MessageBox.Show("Eliminado correctamente");
                LoadData();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void dgvData_SelectionChanged(object sender, EventArgs e)
        {
            string id = FormHelper.GetCurrentRowId(dgvData);
            SubscriptionType subscriptionType = subscriptionTypeService.GetById(id);

            if (subscriptionType != null)
            {
                txtName.Text = subscriptionType.Name;
                nudPrice.Value = subscriptionType.Price;
                nudLoanDays.Value = subscriptionType.LoanDays;
            }
        }

        private void btnBuySubscription_Click(object sender, EventArgs e)
        {
            string subTypeId = FormHelper.GetCurrentRowId(dgvData);
            Subscription userSubscription = subscriptionService.GetAll().Where(x => x.UserId == userId).FirstOrDefault();

            if (userSubscription == null)
            {
                subscriptionService.Create(new Subscription() { SubscriptionTypeId = subTypeId, UserId = userId, StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(1) });
                MessageBox.Show("Subscripcion creada");
            }
            else
            {
                //TODO: verify
                if (userSubscription.Id != subTypeId)
                {
                    subscriptionService.Update(new Subscription() { Id = userSubscription.Id, SubscriptionTypeId = subTypeId, UserId = userId, StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(1) });
                }
            }
        }

        private void btnCancelSubscription_Click(object sender, EventArgs e)
        {
            string subTypeId = FormHelper.GetCurrentRowId(dgvData);
            Subscription userSubscription = subscriptionService.GetAll().Where(x => x.UserId == userId).FirstOrDefault();

            if (userSubscription != null)
            {
                subscriptionService.Delete(userSubscription.Id);
                MessageBox.Show("Subscripcion cancelada");
            }
            else
            {
                MessageBox.Show("sub no encontrada");
            }
        }
    }
}
