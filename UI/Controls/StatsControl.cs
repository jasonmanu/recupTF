using BLL;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace UI.Controls
{
    public partial class StatsControl : UserControl
    {
        private readonly ISubscriptionService subscriptionService;
        private readonly ISubscriptionTypeService subscriptionTypeService;

        public StatsControl(ISubscriptionService subscriptionService, ISubscriptionTypeService subscriptionTypeService)
        {
            InitializeComponent();
            this.subscriptionService = subscriptionService;
            this.subscriptionTypeService = subscriptionTypeService;
            try
            {
                LoadChartNewSubs();
                LoadChartMasReservas();
                LoadChartUsersPerSubType();

                int currentYear = DateTime.Now.Year;
                List<int> yearsList = new List<int>() { currentYear, currentYear - 1, currentYear - 2 };
                cboYearSubsChart.DataSource = yearsList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando datos");
            }
        }

        private void LoadChartNewSubs()
        {
            // Datos de ejemplo para cada mes (puedes sustituirlos con tus propios datos)
            int[] valoresPorMes = { 10, 15, 20, 25, 30, 35, 40, 45, 50, 55, 60, 65 };

            // Configurar el gráfico como de columnas
            chartNewSubs.Series.Clear();
            chartNewSubs.Series.Add("NewSubs");
            chartNewSubs.Series["NewSubs"].ChartType = SeriesChartType.Column;

            // Llenar el gráfico con los valores por cada mes
            for (int i = 0; i < valoresPorMes.Length; i++)
            {
                chartNewSubs.Series["NewSubs"].Points.AddXY(i + 1, valoresPorMes[i]);
            }

            // Configurar etiquetas y título
            chartNewSubs.ChartAreas[0].AxisX.Title = "Mes";
            chartNewSubs.ChartAreas[0].AxisY.Title = "Valores";
            chartNewSubs.Titles.Add("Nuevas suscripciones por mes");
        }

        private void LoadChartMasReservas()
        {
            // Configurar el área del gráfico
            ChartArea chartArea = new ChartArea();
            chartArea.AxisX.Title = "Valores";
            chartArea.AxisY.Title = "Categorías";
            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisY.MajorGrid.Enabled = false;

            chartMasReservas.ChartAreas.Add(chartArea);

            // Crear una serie para el gráfico de barras
            Series series = new Series
            {
                ChartType = SeriesChartType.Bar
            };

            // Añadir datos a la serie
            series.Points.Add(new DataPoint(0, 5) { AxisLabel = "A" });
            series.Points.Add(new DataPoint(0, 7) { AxisLabel = "B" });
            series.Points.Add(new DataPoint(0, 11) { AxisLabel = "C" });

            // Añadir la serie al gráfico
            chartMasReservas.Series.Add(series);
        }

        private void LoadChartUsersPerSubType()
        {
            List<Subscription> subscriptions = subscriptionService.GetAll();
            List<string> subTypesIds = subscriptions.Select(x => x.SubscriptionTypeId).Distinct().ToList();
            Dictionary<string, int> datosUsuariosPorSubscripcion = new Dictionary<string, int>();

            foreach (string subTypeId in subTypesIds)
            {
                int cantidadDeUsuarios = subscriptions.Count(x => x.SubscriptionTypeId == subTypeId);
                datosUsuariosPorSubscripcion.Add(key: subscriptionTypeService.GetById(subTypeId)?.Name, value: cantidadDeUsuarios);
            }

            // Configuración del gráfico circular
            ChartArea chartArea = chartSubsPerType.ChartAreas[0];
            Series series = chartSubsPerType.Series[0];

            chartArea.AxisX.Enabled = AxisEnabled.False;
            chartArea.AxisY.Enabled = AxisEnabled.False;

            series.ChartType = SeriesChartType.Pie;
            series.IsValueShownAsLabel = true;
            series.LabelFormat = "#,##0";

            // Paleta de colores personalizada
            Color[] colores = new Color[] { Color.Blue, Color.Green, Color.Orange };

            // Llenar el gráfico con los datos proporcionados y asignar colores
            int index = 0;
            foreach (var kvp in datosUsuariosPorSubscripcion)
            {
                DataPoint point = new DataPoint();
                point.SetValueY(kvp.Value);
                point.AxisLabel = kvp.Key;
                point.Color = colores[index % colores.Length];
                series.Points.Add(point);
                index++;
            }
        }

        private void StatsControl_Load(object sender, EventArgs e)
        {
        }

        private void cboYearSubsChart_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedYear = (int)cboYearSubsChart.SelectedValue;
        }
    }
}
