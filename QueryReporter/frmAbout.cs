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
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //Close the about form
            this.Close();
        }

        private void lnkSite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //navigate to the link using the client's web browser
            System.Diagnostics.Process.Start("http://taisoftware.com");
        }
    }
}
