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
    public partial class frmAddLimiter : Form
    {
        public string Clause = "";
        public string Limiter = "";

        public frmAddLimiter()
        {
            InitializeComponent();
        }

        public frmAddLimiter(TAIObjectCanvas2.CanvasObject obj)
        {
            InitializeComponent();

            if (obj.MetaData2 != string.Empty)
            {
                txtLimit.Text = obj.MetaData2;
            }
            else
            {
                MessageBox.Show("Unable to load object data", "TAI Query Reporter", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void btnAccept_Click(object sender, EventArgs e)
        {
            Limiter = txtLimit.Text;
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clause = "";

            this.Hide();
        }

        private void HandleTextChanged(object sender, EventArgs e)
        {
            Clause = "TOP " + txtLimit.Text;
            Limiter = txtLimit.Text;
            txtClause.Text = Clause;
        }

        private void HandleKeyPress(object sender, KeyPressEventArgs e)
        {
            string c = e.KeyChar.ToString();

            if (c == "0" || c == "1" || c == "2" || c == "3" || c == "4" || c == "5" || c == "6" || c == "7" || c == "8" || c == "9" || c == "\b")
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
