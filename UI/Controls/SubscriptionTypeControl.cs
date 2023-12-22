using BLL;
using Entities;
using FormSupport;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace UI.Controls
{
    public partial class SubscriptionTypeControl : UserControl
    {
        private readonly ISubscriptionTypeService subscriptionTypeService;
        private readonly ISubscriptionService subscriptionService;
        private readonly User user;

        public SubscriptionTypeControl(ISubscriptionTypeService subscriptionTypeService, ISubscriptionService subscriptionService, User user)
        {
            this.subscriptionTypeService = subscriptionTypeService;
            this.subscriptionService = subscriptionService;
            this.user = user;
            InitializeComponent();
            LoadData();
            HabilitarBotones();
        }

        private void HabilitarBotones()
        {
            btnBuySubscription.Enabled = false;
            btnCancelSubscription.Enabled = false;

            if (user.Permisos.Contains("TipoSubscripcion.Leer"))
            {
                btnCreate.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }

            if (user.Permisos.Contains("TipoSubscripcion.Crear"))
            {
                btnCreate.Enabled = true;
            }

            if (user.Permisos.Contains("TipoSubscripcion.Editar"))
            {
                btnUpdate.Enabled = true;
            }

            if (user.Permisos.Contains("TipoSubscripcion.Eliminar"))
            {
                btnDelete.Enabled = true;
            }

            if (user.Permisos.Contains("Prestamo.Crear"))
            {
                btnBuySubscription.Enabled = true;
            }

            if (user.Permisos.Contains("Prestamo.Editar"))
            {
                btnCancelSubscription.Enabled = true;
            }

            if (user.Permisos.Contains("Prestamo.Eliminar"))
            {
                btnCancelSubscription.Enabled = true;
            }
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
                    MaxLoanBooks = (int)nudPrestamosSimultaneos.Value,
                });

                MessageBox.Show("Creado correctamente");
                LoadData();
                txtName.ResetText();
                nudPrice.ResetText();
                nudLoanDays.ResetText();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ejecutando accion");
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
                    Price = (int)nudPrice.Value,
                    MaxLoanBooks = (int)nudPrestamosSimultaneos.Value,
                };

                subscriptionTypeService.Update(book);
                MessageBox.Show("Actualizado correctamente");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ejecutando accion");
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
                MessageBox.Show("Error ejecutando accion");
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
                nudPrestamosSimultaneos.Value = subscriptionType.MaxLoanBooks;
            }
        }

        private void btnBuySubscription_Click(object sender, EventArgs e)
        {
            try
            {
                string subTypeId = FormHelper.GetCurrentRowId(dgvData);
                Subscription userSubscription = subscriptionService.GetAll().Where(x => x.UserId == user.Id).FirstOrDefault();

                if (userSubscription == null)
                {
                    subscriptionService.Create(new Subscription() { SubscriptionTypeId = subTypeId, UserId = user.Id, StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(1) });
                    MessageBox.Show("Subscripcion creada");
                }
                else
                {
                    if (userSubscription.SubscriptionTypeId != subTypeId)
                    {
                        subscriptionService.Update(new Subscription() { Id = userSubscription.Id, SubscriptionTypeId = subTypeId, UserId = user.Id, StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(1) });
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error ejecutando accion");
            }
        }

        private void btnCancelSubscription_Click(object sender, EventArgs e)
        {
            try
            {
                string subTypeId = FormHelper.GetCurrentRowId(dgvData);
                Subscription userSubscription = subscriptionService.GetAll().Where(x => x.UserId == user.Id).FirstOrDefault();

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
            catch (Exception)
            {
                MessageBox.Show("Error ejecutando accion");
            }
        }
    }
}
