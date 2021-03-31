using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.Charting;
using Telerik.WinControls.UI;

namespace TAIQueryReporter
{
    public partial class frmGraphing : Form
    {
        private bool Drawing = false;
        
        TAIGridControl2.TAIGridControl grid = null;

        public frmGraphing(TAIGridControl2.TAIGridControl gridresult)
        {
            InitializeComponent();

            grid = gridresult;

            cblSeries.Items.Clear();
            cblValues.Items.Clear();

            for (int i = 0; i < grid.Cols ; i++)
            {
                string v = grid.get_HeaderLabel(i);

                cblSeries.Items.Add(v);
                cblValues.Items.Add(v);
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnGenerateChart_Click(object sender, EventArgs e)
        {

            if (!Drawing)
            {

                Drawing = true;

                theChart.Series.Clear();

                List<GraphItem> thedataforthechart = new List<GraphItem>();

                string title = "";

                if (cblSeries.CheckedItems.Count != 0 && cblValues.CheckedItems.Count != 0)
                {
                    //ChartSeries chartSeries = new ChartSeries();


                    for (int r = 0; r < grid.Rows; r++)
                    {
                        // once for each row in the source grid

                        string series = "";

                        for (int c = 0; c < cblSeries.CheckedItems.Count; c++)
                        {
                            string tmp = grid.get_item(r, cblSeries.CheckedItems[c].ToString());

                            if (series != "")
                            {
                                series += "_" + tmp;

                                title += cblSeries.CheckedItems[c].ToString();
                            }
                            else
                            {
                                series = tmp;

                                title = cblSeries.CheckedItems[c].ToString();
                            }
                        }

                        //chartSeries.Name = title;

                        string valu = "";

                        for (int c = 0; c < cblValues.CheckedItems.Count; c++)
                        {
                            string tmp = grid.get_item(r, cblValues.CheckedItems[c].ToString());

                            valu = tmp;

                            title = cblValues.CheckedItems[c].ToString() + " by " + title;

                        }

                        double dvalue = 0.0;

                        double.TryParse(valu, out dvalue);

                        thedataforthechart.Add(new GraphItem(series, dvalue));

                        //chartSeries.AddItem(dvalue, series);

                    }

                    theChart.Series.ClearItems();

                    theChart.DataSource = thedataforthechart;
                    theChart.DataBind();
                    theChart.Series[0].DataYColumn = "TheValue";
                    //theChart.Series[0].DataXColumn = "TheName";
                    theChart.PlotArea.XAxis.DataLabelsColumn = "TheName";
                    theChart.PlotArea.XAxis.Appearance.TextAppearance.TextProperties.Font = new System.Drawing.Font("Ariel", 8);
                    theChart.PlotArea.XAxis.Appearance.LabelAppearance.Position.Auto = false;
                    theChart.PlotArea.XAxis.Appearance.LabelAppearance.Position.AlignedPosition = Telerik.Charting.Styles.AlignedPositions.Top;

                    theChart.PlotArea.XAxis.Appearance.LabelAppearance.RotationAngle = (float)sbLblRotate.Value;
                    theChart.PlotArea.XAxis.Appearance.LabelAppearance.Position.Y = 0;
                    theChart.PlotArea.XAxis.Appearance.LabelAppearance.Position.X = 0;
                    theChart.PlotArea.Appearance.Dimensions.Margins.Bottom = Telerik.Charting.Styles.Unit.Percentage(25);
                    theChart.PlotArea.Appearance.Dimensions.Margins.Top = Telerik.Charting.Styles.Unit.Percentage(9);
                    theChart.PlotArea.Appearance.Dimensions.Margins.Right = Telerik.Charting.Styles.Unit.Percentage(5);


                    if (rbBar.Checked)
                    {
                        theChart.Series[0].Type = ChartSeriesType.Bar;
                    }
                    else
                    {
                        if (rbPie.Checked)
                        {
                            theChart.Series[0].Type = ChartSeriesType.Pie;
                        }
                        else
                        {
                            if (rbLine.Checked)
                            {
                                theChart.Series[0].Type = ChartSeriesType.Line;
                            }
                        }
                    }

                    if (cmboScheme.SelectedIndex != -1)
                        theChart.Skin = cmboScheme.SelectedItem.ToString();



                    theChart.Legend.Visible = false;

                    theChart.ChartTitle.TextBlock.Text = title;
                    theChart.ChartTitle.TextBlock.Appearance.TextProperties.Color = Color.Black;

                    //theChart.Series.Add(chartSeries);

                    theChart.Refresh();
                    //Application.DoEvents();

                    //Clipboard.SetImage(theChart.GetBitmap());

                    Drawing = false;
                }

            }
        }

        private void HandleLBScrollLblRotate(object sender, ScrollEventArgs e)
        {

            lbsbLblRotate.Text = sbLblRotate.Value.ToString();
            
            btnGenerateChart_Click(sender, new EventArgs());
        }

        private void HandleSchemeChanged(object sender, EventArgs e)
        {
            btnGenerateChart_Click(sender, e);
        }

        private void btnCopyToClipboard_Click(object sender, EventArgs e)
        {
            Clipboard.SetImage(theChart.GetBitmap());
        }

        private void HandleChartTypeCheckChanged(object sender, EventArgs e)
        {
            btnGenerateChart_Click(sender, e);
        }
    }
}
