using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TAIQueryReporter
{
    public partial class frmFieldBrowser : Form
    {

        private string tname = "";
        private string dbase = "";

        public frmFieldBrowser(string ConnectionString, string TName)
        {
            InitializeComponent();

            dbase = ConnectionString;
            tname = TName;

            PopulateSample();

        }

        private void PopulateSample()
        {
            string sql = "SELECT TOP 1000 * FROM " + tname + " ";

            taig.PopulateGridWithData(dbase, sql);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
