using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TAIQueryReporter
{
    public partial class frmCurrentQuery : Form
    {
        public frmCurrentQuery()
        {
            InitializeComponent();
        }
        public frmCurrentQuery(string query)
        {
            InitializeComponent();

            //remove blank lines from the query
            string[] q = query.Split(System.Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            string newQuery = "";

            for (int i = 0; i < q.Length; i++)
            {
                    newQuery += q[i] + System.Environment.NewLine;
            }
            tais.Text = newQuery;
        }
    }
}
