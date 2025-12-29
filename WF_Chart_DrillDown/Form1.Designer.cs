using Syncfusion.Windows.Forms.Chart;
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Syncfusion.Windows.Forms;
using Syncfusion.Drawing;

namespace WF_Chart_DrillDown
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        bool isDrilledDown = false;
        private ChartControl chartControl1;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            chartControl1 = new ChartControl();
            ChartSeries chartSeries1 = new ChartSeries();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(Form1));
            this.SuspendLayout();    
            // 
            // chartControl1
            // 
            this.chartControl1.ChartArea.CursorLocation = new System.Drawing.Point(0, 0);
            this.chartControl1.ChartArea.CursorReDraw = false;
            this.chartControl1.DataSourceName = "";
            this.chartControl1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chartControl1.IsWindowLess = false;
            // 
            // 
            // 
            this.chartControl1.Legend.Location = new System.Drawing.Point(830, 75);
            this.chartControl1.Localize = null;
            this.chartControl1.Location = new System.Drawing.Point(8, 10);
            this.chartControl1.Name = "chartControl1";
            this.chartControl1.PrimaryXAxis.Crossing = double.NaN;
            this.chartControl1.PrimaryXAxis.Title = "Vehicles";
            this.chartControl1.PrimaryXAxis.Margin = true;
            this.chartControl1.PrimaryYAxis.Title = "Sales (%)";
            this.chartControl1.PrimaryYAxis.Crossing = double.NaN;
            this.chartControl1.PrimaryYAxis.ForceZero = true;
            this.chartControl1.PrimaryYAxis.Margin = true;
            chartSeries1.FancyToolTip.ResizeInsideSymbol = true;
            chartSeries1.Name = "Default";
            chartSeries1.Points.Add(0D, ((double)(18D)), ((double)(127D)), ((double)(112D)), ((double)(108D)));
            chartSeries1.Points.Add(1D, ((double)(56D)), ((double)(73D)), ((double)(61D)), ((double)(56D)));
            chartSeries1.Points.Add(2D, ((double)(4D)), ((double)(212D)), ((double)(82D)), ((double)(107D)));
            chartSeries1.Points.Add(3D, ((double)(50D)), ((double)(348D)), ((double)(55D)), ((double)(190D)));
            chartSeries1.Points.Add(4D, ((double)(87D)), ((double)(246D)), ((double)(136D)), ((double)(192D)));
            chartSeries1.Resolution = 0D;
            chartSeries1.StackingGroup = "Default Group";
            chartSeries1.Style.AltTagFormat = "";
            chartSeries1.Style.DrawTextShape = false;
            chartSeries1.Text = "Default";
            this.chartControl1.Series.Add(chartSeries1);
            this.chartControl1.Size = new System.Drawing.Size(934, 526);
            this.chartControl1.Indexed = true;
            this.chartControl1.Dock = DockStyle.Left;
            this.chartControl1.TabIndex = 2;
            this.chartControl1.Text = "chartControl1";
            // 
            // 
            // 
            this.chartControl1.Title.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chartControl1.Title.Name = "Default";
            this.chartControl1.Titles.Add(this.chartControl1.Title);
            this.chartControl1.ChartRegionClick += new Syncfusion.Windows.Forms.Chart.ChartRegionMouseEventHandler(this.chartControl1_ChartRegionClick);
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(954, 581);
            this.Controls.Add(this.chartControl1);
            this.MinimumSize = new System.Drawing.Size(461, 407);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Drilldown";
            InitializeChart();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void chartControl1_ChartRegionClick(object sender, Syncfusion.Windows.Forms.Chart.ChartRegionMouseEventArgs e)
        {
            if (e.Region.IsChartPoint)
            {
                if (!isDrilledDown)
                {
                    InitializeDrillDownChart(e.Region.PointIndex);
                }
                else
                {
                    InitializeChart();
                }
                isDrilledDown = !isDrilledDown;
            }

            this.chartControl1.Refresh();
        }

        #region InitializeDrillDownChart

        /// <summary>
        /// Initializes the ChartControl's data and sets the Chart type
        /// </summary>
        protected void InitializeDrillDownChart(int index)
        {
            ChartSeries series1 = new ChartSeries("Market Breakdown");
            series1.Name = "Market";
            series1.Text = series1.Name;
            string[] labelArray = null;

            switch (index)
            {
                case 0:
                    labelArray = new string[] { "Toyota", "Ford", "GM" };
                    this.chartControl1.Titles[0].Text = "Automobile sales in the SUV segment";
                    break;
                case 1:
                    labelArray = new string[] { "Toyota", "Ford", "GM" };
                    this.chartControl1.Titles[0].Text = "Automobile sales in the Car segment";
                    break;
                case 2:
                    labelArray = new string[] { "Mercedes", "Ford", "GM", "Chrysler" };
                    this.chartControl1.Titles[0].Text = "Automobile sales in the Pickup segment";

                    break;
                case 3:
                    labelArray = new string[] { "Nissan", "Ford", "GM" };
                    this.chartControl1.Titles[0].Text = "Automobile sales in the Minivan segment";
                    break;
                default:
                    labelArray = new string[] { "Toyota", "Ford", "GM" };
                    break;
            }

            int count = this.chartControl1.Series[0].Points[index].YValues.Length - 1;
            for (int i = 0; i < count; i++)
            {
                series1.Points.Add(i, this.chartControl1.Series[0].Points[index].YValues[i + 1]);
                series1.Styles[i].Text = labelArray[i] + " - " + this.chartControl1.Series[0].Points[index].YValues[i + 1].ToString() + " %";
            }

            series1.Style.TextOrientation = ChartTextOrientation.RegionCenter;
            series1.Style.DisplayText = true;

            series1.Type = ChartSeriesType.Pie;
           

            this.chartControl1.Series.Clear();
            this.chartControl1.Series.Add(series1);
        }
        #endregion

        #region InitializeChart

        protected void InitializeChart()
        {
            this.chartControl1.Series.Clear();

            ChartSeries series1 = new ChartSeries("Market");
            series1.Name = "Market";
            series1.Text = series1.Name;

            series1.Points.Add(0, 20, 50, 25, 25);//Only first Y value will be used by ColumnChart
            series1.Points.Add(1, 22, 50, 25, 35);
            series1.Points.Add(2, 23, 50, 25, 20, 20);
            series1.Points.Add(3, 24, 50, 25, 45);


            this.chartControl1.PrimaryXAxis.LabelsImpl = new LabelModel(new string[] { "", "SUV", "Car", "Pickup", "Minivan" });
            this.chartControl1.PrimaryXAxis.ValueType = ChartValueType.Custom;

            series1.Type = ChartSeriesType.Column;
            this.chartControl1.Series.Add(series1);
            this.chartControl1.Titles[0].Text = "Automobile Sales by Category";

            this.chartControl1.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            this.chartControl1.Legend.Visible = false;
            this.chartControl1.Series[0].Style.Border.Color = Color.Transparent;
        }
        #endregion

        #region LabelModel

        public class LabelModel : IChartAxisLabelModel
        {
            private string[] labels;

            public LabelModel(string[] labels)
            {
                this.labels = labels;
            }

            public ChartAxisLabel GetLabelAt(int index)
            {
                return new ChartAxisLabel(this.labels[index]);
            }

            public int Count
            {
                get
                {
                    return this.labels.GetLength(0);
                }
            }
        }

        #endregion


        #endregion
    }
}
