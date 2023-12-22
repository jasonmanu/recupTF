
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chartNewSubs = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartMasReservas = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartSubsPerType = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cboYearSubsChart = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.cboMonthReservas = new System.Windows.Forms.ComboBox();
            this.cboYearReservas = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartNewSubs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMasReservas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSubsPerType)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.chartNewSubs, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.chartMasReservas, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.chartSubsPerType, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.cboYearSubsChart, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1038, 604);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(694, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(341, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "mes y año";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(339, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Año";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(694, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(341, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Cantida de usuarios por tipo de Suscripcion";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(339, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nuevos suscriptores";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(348, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(340, 13);
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
            this.chartNewSubs.Location = new System.Drawing.Point(3, 166);
            this.chartNewSubs.Name = "chartNewSubs";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartNewSubs.Series.Add(series1);
            this.chartNewSubs.Size = new System.Drawing.Size(339, 362);
            this.chartNewSubs.TabIndex = 0;
            this.chartNewSubs.Text = "chart1";
            // 
            // chartMasReservas
            // 
            this.chartMasReservas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.Name = "ChartArea1";
            this.chartMasReservas.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartMasReservas.Legends.Add(legend2);
            this.chartMasReservas.Location = new System.Drawing.Point(348, 166);
            this.chartMasReservas.Name = "chartMasReservas";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartMasReservas.Series.Add(series2);
            this.chartMasReservas.Size = new System.Drawing.Size(340, 361);
            this.chartMasReservas.TabIndex = 2;
            this.chartMasReservas.Text = "chart2";
            // 
            // chartSubsPerType
            // 
            this.chartSubsPerType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            chartArea3.Name = "ChartArea1";
            this.chartSubsPerType.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartSubsPerType.Legends.Add(legend3);
            this.chartSubsPerType.Location = new System.Drawing.Point(694, 164);
            this.chartSubsPerType.Name = "chartSubsPerType";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartSubsPerType.Series.Add(series3);
            this.chartSubsPerType.Size = new System.Drawing.Size(341, 365);
            this.chartSubsPerType.TabIndex = 1;
            this.chartSubsPerType.Text = "chart1";
            // 
            // cboYearSubsChart
            // 
            this.cboYearSubsChart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboYearSubsChart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboYearSubsChart.FormattingEnabled = true;
            this.cboYearSubsChart.Location = new System.Drawing.Point(3, 64);
            this.cboYearSubsChart.Name = "cboYearSubsChart";
            this.cboYearSubsChart.Size = new System.Drawing.Size(339, 21);
            this.cboYearSubsChart.TabIndex = 6;
            this.cboYearSubsChart.SelectedIndexChanged += new System.EventHandler(this.cboYearSubsChart_SelectedIndexChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.cboMonthReservas, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.cboYearReservas, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(348, 63);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(340, 24);
            this.tableLayoutPanel2.TabIndex = 9;
            // 
            // cboMonthReservas
            // 
            this.cboMonthReservas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMonthReservas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonthReservas.FormattingEnabled = true;
            this.cboMonthReservas.Location = new System.Drawing.Point(173, 3);
            this.cboMonthReservas.Name = "cboMonthReservas";
            this.cboMonthReservas.Size = new System.Drawing.Size(164, 21);
            this.cboMonthReservas.TabIndex = 9;
            // 
            // cboYearReservas
            // 
            this.cboYearReservas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboYearReservas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboYearReservas.FormattingEnabled = true;
            this.cboYearReservas.Location = new System.Drawing.Point(3, 3);
            this.cboYearReservas.Name = "cboYearReservas";
            this.cboYearReservas.Size = new System.Drawing.Size(164, 21);
            this.cboYearReservas.TabIndex = 8;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.label7, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(348, 33);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(340, 24);
            this.tableLayoutPanel3.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(164, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Año";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(173, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(164, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Mes";
            // 
            // StatsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "StatsControl";
            this.Size = new System.Drawing.Size(1044, 640);
            this.Load += new System.EventHandler(this.StatsControl_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartNewSubs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMasReservas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSubsPerType)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartNewSubs;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMasReservas;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSubsPerType;
        private System.Windows.Forms.ComboBox cboYearSubsChart;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ComboBox cboMonthReservas;
        private System.Windows.Forms.ComboBox cboYearReservas;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
    }
}
