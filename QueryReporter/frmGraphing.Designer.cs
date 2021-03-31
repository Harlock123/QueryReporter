namespace TAIQueryReporter
{
    partial class frmGraphing
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Charting.Styles.Corners corners1 = new Telerik.Charting.Styles.Corners();
            Telerik.Charting.Styles.ChartMarginsLegend chartMarginsLegend1 = new Telerik.Charting.Styles.ChartMarginsLegend();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGraphing));
            Telerik.Charting.ChartSeries chartSeries1 = new Telerik.Charting.ChartSeries();
            Telerik.Charting.ChartSeries chartSeries2 = new Telerik.Charting.ChartSeries();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.theChart = new Telerik.WinControls.UI.RadChart();
            this.cblSeries = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cblValues = new System.Windows.Forms.CheckedListBox();
            this.btnGenerateChart = new System.Windows.Forms.Button();
            this.rbBar = new System.Windows.Forms.RadioButton();
            this.rbPie = new System.Windows.Forms.RadioButton();
            this.rbLine = new System.Windows.Forms.RadioButton();
            this.sbLblRotate = new System.Windows.Forms.HScrollBar();
            this.label3 = new System.Windows.Forms.Label();
            this.lbsbLblRotate = new System.Windows.Forms.Label();
            this.cmboScheme = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCopyToClipboard = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.theChart)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(932, 708);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(932, 684);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 2;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // theChart
            // 
            this.theChart.Appearance.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            corners1.BottomLeft = Telerik.Charting.Styles.CornerType.Round;
            corners1.BottomRight = Telerik.Charting.Styles.CornerType.Round;
            corners1.RoundSize = 6;
            corners1.TopLeft = Telerik.Charting.Styles.CornerType.Round;
            corners1.TopRight = Telerik.Charting.Styles.CornerType.Round;
            this.theChart.Appearance.Corners = corners1;
            this.theChart.Appearance.FillStyle.FillSettings.BackgroundImage = "{chart}";
            this.theChart.Appearance.FillStyle.FillSettings.ImageDrawMode = Telerik.Charting.Styles.ImageDrawMode.Flip;
            this.theChart.Appearance.FillStyle.FillSettings.ImageFlip = Telerik.Charting.Styles.ImageTileModes.FlipX;
            this.theChart.Appearance.FillStyle.FillType = Telerik.Charting.Styles.FillType.Image;
            this.theChart.ChartTitle.Appearance.FillStyle.MainColor = System.Drawing.Color.Empty;
            this.theChart.ChartTitle.Appearance.Position.AlignedPosition = Telerik.Charting.Styles.AlignedPositions.Top;
            this.theChart.ChartTitle.TextBlock.Appearance.TextProperties.Font = new System.Drawing.Font("Tahoma", 13F);
            this.theChart.Legend.Appearance.Border.Color = System.Drawing.Color.Transparent;
            chartMarginsLegend1.Right = ((Telerik.Charting.Styles.Unit)(resources.GetObject("chartMarginsLegend1.Right")));
            chartMarginsLegend1.Top = ((Telerik.Charting.Styles.Unit)(resources.GetObject("chartMarginsLegend1.Top")));
            this.theChart.Legend.Appearance.Dimensions.Margins = chartMarginsLegend1;
            this.theChart.Legend.Appearance.FillStyle.MainColor = System.Drawing.Color.Empty;
            this.theChart.Legend.Appearance.ItemMarkerAppearance.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(134)))), ((int)(((byte)(134)))));
            this.theChart.Legend.Appearance.ItemMarkerAppearance.Figure = "Square";
            this.theChart.Legend.Appearance.Position.AlignedPosition = Telerik.Charting.Styles.AlignedPositions.TopRight;
            this.theChart.Location = new System.Drawing.Point(188, 28);
            this.theChart.Name = "theChart";
            this.theChart.PlotArea.Appearance.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(134)))), ((int)(((byte)(134)))));
            this.theChart.PlotArea.Appearance.FillStyle.FillType = Telerik.Charting.Styles.FillType.Solid;
            this.theChart.PlotArea.Appearance.FillStyle.MainColor = System.Drawing.Color.White;
            this.theChart.PlotArea.XAxis.Appearance.Color = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(134)))), ((int)(((byte)(134)))));
            this.theChart.PlotArea.XAxis.Appearance.MajorGridLines.Color = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(222)))), ((int)(((byte)(227)))));
            this.theChart.PlotArea.XAxis.Appearance.MajorGridLines.PenStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.theChart.PlotArea.XAxis.Appearance.MajorTick.Color = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(134)))), ((int)(((byte)(134)))));
            this.theChart.PlotArea.XAxis.Appearance.TextAppearance.TextProperties.Color = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.theChart.PlotArea.XAxis.AxisLabel.TextBlock.Appearance.TextProperties.Color = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.theChart.PlotArea.XAxis.MinValue = 1D;
            this.theChart.PlotArea.YAxis.Appearance.Color = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(134)))), ((int)(((byte)(134)))));
            this.theChart.PlotArea.YAxis.Appearance.MajorGridLines.Color = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(222)))), ((int)(((byte)(227)))));
            this.theChart.PlotArea.YAxis.Appearance.MajorTick.Color = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(134)))), ((int)(((byte)(134)))));
            this.theChart.PlotArea.YAxis.Appearance.MinorGridLines.Color = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(239)))), ((int)(((byte)(241)))));
            this.theChart.PlotArea.YAxis.Appearance.MinorTick.Color = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(134)))), ((int)(((byte)(134)))));
            this.theChart.PlotArea.YAxis.Appearance.MinorTick.Width = 0F;
            this.theChart.PlotArea.YAxis.Appearance.TextAppearance.TextProperties.Color = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.theChart.PlotArea.YAxis.AxisLabel.TextBlock.Appearance.TextProperties.Color = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.theChart.PlotArea.YAxis.MaxValue = 100D;
            this.theChart.PlotArea.YAxis.Step = 10D;
            chartSeries1.Appearance.FillStyle.FillSettings.GradientMode = Telerik.Charting.Styles.GradientFillStyle.Vertical;
            chartSeries1.Appearance.FillStyle.MainColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(167)))), ((int)(((byte)(226)))));
            chartSeries1.Appearance.FillStyle.SecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(85)))), ((int)(((byte)(161)))));
            chartSeries1.Appearance.TextAppearance.TextProperties.Color = System.Drawing.Color.Black;
            chartSeries1.Name = "Series 1";
            chartSeries2.Appearance.FillStyle.FillSettings.GradientMode = Telerik.Charting.Styles.GradientFillStyle.Vertical;
            chartSeries2.Appearance.FillStyle.MainColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(87)))), ((int)(((byte)(60)))));
            chartSeries2.Appearance.FillStyle.SecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(38)))), ((int)(((byte)(37)))));
            chartSeries2.Appearance.TextAppearance.TextProperties.Color = System.Drawing.Color.Black;
            chartSeries2.Name = "Series 2";
            this.theChart.Series.AddRange(new Telerik.Charting.ChartSeries[] {
            chartSeries1,
            chartSeries2});
            this.theChart.Size = new System.Drawing.Size(816, 652);
            this.theChart.Skin = "Mac";
            this.theChart.TabIndex = 4;
            // 
            // cblSeries
            // 
            this.cblSeries.FormattingEnabled = true;
            this.cblSeries.Location = new System.Drawing.Point(4, 32);
            this.cblSeries.Name = "cblSeries";
            this.cblSeries.Size = new System.Drawing.Size(172, 139);
            this.cblSeries.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Select Columns that contain Series";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Select Column that contains Values";
            // 
            // cblValues
            // 
            this.cblValues.FormattingEnabled = true;
            this.cblValues.Location = new System.Drawing.Point(4, 196);
            this.cblValues.Name = "cblValues";
            this.cblValues.Size = new System.Drawing.Size(172, 139);
            this.cblValues.TabIndex = 7;
            // 
            // btnGenerateChart
            // 
            this.btnGenerateChart.Location = new System.Drawing.Point(4, 644);
            this.btnGenerateChart.Name = "btnGenerateChart";
            this.btnGenerateChart.Size = new System.Drawing.Size(172, 24);
            this.btnGenerateChart.TabIndex = 9;
            this.btnGenerateChart.Text = "Generate Chart";
            this.btnGenerateChart.UseVisualStyleBackColor = true;
            this.btnGenerateChart.Click += new System.EventHandler(this.btnGenerateChart_Click);
            // 
            // rbBar
            // 
            this.rbBar.AutoSize = true;
            this.rbBar.Checked = true;
            this.rbBar.Location = new System.Drawing.Point(68, 352);
            this.rbBar.Name = "rbBar";
            this.rbBar.Size = new System.Drawing.Size(41, 17);
            this.rbBar.TabIndex = 10;
            this.rbBar.TabStop = true;
            this.rbBar.Text = "Bar";
            this.rbBar.UseVisualStyleBackColor = true;
            this.rbBar.CheckedChanged += new System.EventHandler(this.HandleChartTypeCheckChanged);
            // 
            // rbPie
            // 
            this.rbPie.AutoSize = true;
            this.rbPie.Location = new System.Drawing.Point(68, 372);
            this.rbPie.Name = "rbPie";
            this.rbPie.Size = new System.Drawing.Size(40, 17);
            this.rbPie.TabIndex = 11;
            this.rbPie.Text = "Pie";
            this.rbPie.UseVisualStyleBackColor = true;
            this.rbPie.CheckedChanged += new System.EventHandler(this.HandleChartTypeCheckChanged);
            // 
            // rbLine
            // 
            this.rbLine.AutoSize = true;
            this.rbLine.Location = new System.Drawing.Point(68, 392);
            this.rbLine.Name = "rbLine";
            this.rbLine.Size = new System.Drawing.Size(45, 17);
            this.rbLine.TabIndex = 12;
            this.rbLine.Text = "Line";
            this.rbLine.UseVisualStyleBackColor = true;
            this.rbLine.CheckedChanged += new System.EventHandler(this.HandleChartTypeCheckChanged);
            // 
            // sbLblRotate
            // 
            this.sbLblRotate.Location = new System.Drawing.Point(188, 684);
            this.sbLblRotate.Maximum = 360;
            this.sbLblRotate.Name = "sbLblRotate";
            this.sbLblRotate.Size = new System.Drawing.Size(132, 17);
            this.sbLblRotate.TabIndex = 13;
            this.sbLblRotate.Scroll += new System.Windows.Forms.ScrollEventHandler(this.HandleLBScrollLblRotate);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(184, 708);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Rotate Series Labels";
            // 
            // lbsbLblRotate
            // 
            this.lbsbLblRotate.AutoSize = true;
            this.lbsbLblRotate.Location = new System.Drawing.Point(296, 708);
            this.lbsbLblRotate.Name = "lbsbLblRotate";
            this.lbsbLblRotate.Size = new System.Drawing.Size(13, 13);
            this.lbsbLblRotate.TabIndex = 15;
            this.lbsbLblRotate.Text = "0";
            // 
            // cmboScheme
            // 
            this.cmboScheme.FormattingEnabled = true;
            this.cmboScheme.Items.AddRange(new object[] {
            "Default",
            "Blue",
            "Brick",
            "Classic",
            "Colorful",
            "ExcelClassic",
            "Gradient",
            "Green",
            "Pastel",
            "Stacked",
            "Web20",
            "Office2007",
            "BabyBlue",
            "BlueStripes",
            "Web",
            "Wood",
            "DeepBlue",
            "DeepGreen",
            "DeepGray",
            "DeepRed",
            "GreenStripes",
            "GrayStripes"});
            this.cmboScheme.Location = new System.Drawing.Point(332, 684);
            this.cmboScheme.Name = "cmboScheme";
            this.cmboScheme.Size = new System.Drawing.Size(144, 21);
            this.cmboScheme.TabIndex = 16;
            this.cmboScheme.SelectedIndexChanged += new System.EventHandler(this.HandleSchemeChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(332, 708);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Select Color Scheme";
            // 
            // btnCopyToClipboard
            // 
            this.btnCopyToClipboard.Location = new System.Drawing.Point(4, 672);
            this.btnCopyToClipboard.Name = "btnCopyToClipboard";
            this.btnCopyToClipboard.Size = new System.Drawing.Size(172, 24);
            this.btnCopyToClipboard.TabIndex = 18;
            this.btnCopyToClipboard.Text = "Copy To Clipboard";
            this.btnCopyToClipboard.UseVisualStyleBackColor = true;
            this.btnCopyToClipboard.Click += new System.EventHandler(this.btnCopyToClipboard_Click);
            // 
            // frmGraphing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.ControlBox = false;
            this.Controls.Add(this.btnCopyToClipboard);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmboScheme);
            this.Controls.Add(this.lbsbLblRotate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.sbLblRotate);
            this.Controls.Add(this.rbLine);
            this.Controls.Add(this.rbPie);
            this.Controls.Add(this.rbBar);
            this.Controls.Add(this.btnGenerateChart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cblValues);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cblSeries);
            this.Controls.Add(this.theChart);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Name = "frmGraphing";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Graphing Interface";
            ((System.ComponentModel.ISupportInitialize)(this.theChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAccept;
        private Telerik.WinControls.UI.RadChart theChart;
        private System.Windows.Forms.CheckedListBox cblSeries;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox cblValues;
        private System.Windows.Forms.Button btnGenerateChart;
        private System.Windows.Forms.RadioButton rbBar;
        private System.Windows.Forms.RadioButton rbPie;
        private System.Windows.Forms.RadioButton rbLine;
        private System.Windows.Forms.HScrollBar sbLblRotate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbsbLblRotate;
        private System.Windows.Forms.ComboBox cmboScheme;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCopyToClipboard;
    }
}