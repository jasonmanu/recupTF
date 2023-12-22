
namespace UI.Controls
{
    partial class StatsControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tlpGeneral = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chartNewSubs = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartMasReservas = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartSubsPerType = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cboYearSubsChart = new System.Windows.Forms.ComboBox();
            this.tlpGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartNewSubs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMasReservas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSubsPerType)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpGeneral
            // 
            this.tlpGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpGeneral.ColumnCount = 2;
            this.tlpGeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.99999F));
            this.tlpGeneral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.00001F));
            this.tlpGeneral.Controls.Add(this.label1, 0, 0);
            this.tlpGeneral.Controls.Add(this.chartNewSubs, 0, 2);
            this.tlpGeneral.Controls.Add(this.label3, 1, 0);
            this.tlpGeneral.Controls.Add(this.chartSubsPerType, 1, 2);
            this.tlpGeneral.Controls.Add(this.cboYearSubsChart, 0, 1);
            this.tlpGeneral.Location = new System.Drawing.Point(41, 17);
            this.tlpGeneral.Name = "tlpGeneral";
            this.tlpGeneral.RowCount = 3;
            this.tlpGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.433962F));
            this.tlpGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.433962F));
            this.tlpGeneral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 81.13207F));
            this.tlpGeneral.Size = new System.Drawing.Size(984, 302);
            this.tlpGeneral.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(494, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(487, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Cantida de usuarios por tipo de Suscripcion";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(485, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nuevos suscriptores";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(468, 341);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Libros con mas reservas";
            // 
            // chartNewSubs
            // 
            this.chartNewSubs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chartNewSubs.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartNewSubs.Legends.Add(legend1);
            this.chartNewSubs.Location = new System.Drawing.Point(3, 59);
            this.chartNewSubs.Name = "chartNewSubs";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartNewSubs.Series.Add(series1);
            this.chartNewSubs.Size = new System.Drawing.Size(485, 240);
            this.chartNewSubs.TabIndex = 0;
            this.chartNewSubs.Text = "chart1";
            // 
            // chartMasReservas
            // 
            this.chartMasReservas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            chartArea3.Name = "ChartArea1";
            this.chartMasReservas.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartMasReservas.Legends.Add(legend3);
            this.chartMasReservas.Location = new System.Drawing.Point(221, 357);
            this.chartMasReservas.Name = "chartMasReservas";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartMasReservas.Series.Add(series3);
            this.chartMasReservas.Size = new System.Drawing.Size(623, 268);
            this.chartMasReservas.TabIndex = 2;
            this.chartMasReservas.Text = "chart2";
            // 
            // chartSubsPerType
            // 
            this.chartSubsPerType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.Name = "ChartArea1";
            this.chartSubsPerType.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartSubsPerType.Legends.Add(legend2);
            this.chartSubsPerType.Location = new System.Drawing.Point(494, 59);
            this.chartSubsPerType.Name = "chartSubsPerType";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartSubsPerType.Series.Add(series2);
            this.chartSubsPerType.Size = new System.Drawing.Size(487, 240);
            this.chartSubsPerType.TabIndex = 1;
            this.chartSubsPerType.Text = "chart1";
            // 
            // cboYearSubsChart
            // 
            this.cboYearSubsChart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboYearSubsChart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboYearSubsChart.FormattingEnabled = true;
            this.cboYearSubsChart.Location = new System.Drawing.Point(3, 31);
            this.cboYearSubsChart.Name = "cboYearSubsChart";
            this.cboYearSubsChart.Size = new System.Drawing.Size(485, 21);
            this.cboYearSubsChart.TabIndex = 6;
            this.cboYearSubsChart.SelectedIndexChanged += new System.EventHandler(this.cboYearSubsChart_SelectedIndexChanged);
            // 
            // StatsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpGeneral);
            this.Controls.Add(this.chartMasReservas);
            this.Controls.Add(this.label2);
            this.Name = "StatsControl";
            this.Size = new System.Drawing.Size(1044, 640);
            this.Load += new System.EventHandler(this.StatsControl_Load);
            this.tlpGeneral.ResumeLayout(false);
            this.tlpGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartNewSubs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMasReservas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSubsPerType)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpGeneral;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartNewSubs;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMasReservas;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSubsPerType;
        private System.Windows.Forms.ComboBox cboYearSubsChart;
    }
}
