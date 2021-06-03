using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace TAIQueryReporter
{
    public partial class frmSelectTableSource : Form
    {
        string _dbase = "";
        public string SelectedTableName = "";
        public List<string> SelectedColumnNames = new List<string>();

        public frmSelectTableSource(string Connection)
        {
            InitializeComponent();

            _dbase = Connection;

            PopulateTreeView();
        }

        public frmSelectTableSource(string Connection,string Tname, List<String> scols)
        {
            InitializeComponent();

            _dbase = Connection;

            PopulateTreeView();

            SelectedTableName = Tname;

            clbFields.Items.Clear();

            string sql = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + Tname + "' ORDER BY ORDINAL_POSITION";

            //SelectedTableName = e.Node.Text;

            SqlConnection cn = new SqlConnection(_dbase);
            cn.Open();

            SqlCommand cmd = new SqlCommand(sql, cn);

            SqlDataReader r = cmd.ExecuteReader();

            while (r.Read())
            {
                clbFields.Items.Add(r["COLUMN_NAME"] + "");
            }

            r.Close();
            cmd.Dispose();
            cn.Close();
            cn.Dispose();

            for (int i = 0; i < clbFields.Items.Count; i++)
            {
                string fn = clbFields.Items[i].ToString();

                if (scols.Contains(fn))
                {
                    clbFields.SetItemChecked(i, true);
                }
            }
        }

        private void PopulateTreeView()
        {
            TreeNode tbls = new TreeNode("Tables");
            tbls.Tag = "TOPMOST";

            TreeNode vews = new TreeNode("Views");
            vews.Tag = "TOPMOST";

            SqlConnection cn = new SqlConnection(_dbase);
            cn.Open();

            SqlCommand cmd = new SqlCommand("SELECT TABLE_NAME,TABLE_TYPE from INFORMATION_SCHEMA.Tables ORDER BY TABLE_NAME", cn);

            SqlDataReader r = cmd.ExecuteReader();

            while (r.Read())
            {
                string tn = r["TABLE_NAME"] + "";
                string ty = r["TABLE_TYPE"] + "";

                TreeNode tb = new TreeNode(tn);

                if (ty.StartsWith("BASE"))
                {
                    tbls.Nodes.Add(tb);
                }
                else
                {
                    vews.Nodes.Add(tb);
                }
            }

            r.Close();
            cmd.Dispose();
            cn.Close();
            cn.Dispose();

            tvTables.Nodes.Clear();
            tvTables.Nodes.Add(tbls);
            tvTables.Nodes.Add(vews);
        }

        private void HandleATableViewSelection(object sender, EventArgs e)
        {
            
        }

        private void HandleNoteDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if ((string)e.Node.Tag != "TOPMOST")
            {
                // we selected a table so lets show the columns in that table

                clbFields.Items.Clear();

                string sql = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + e.Node.Text + "' ORDER BY ORDINAL_POSITION";

                SelectedTableName = e.Node.Text;

                SqlConnection cn = new SqlConnection(_dbase);
                cn.Open();

                SqlCommand cmd = new SqlCommand(sql, cn);

                SqlDataReader r = cmd.ExecuteReader();

                while (r.Read())
                {
                    clbFields.Items.Add(r["COLUMN_NAME"] + "");
                }

                r.Close();
                cmd.Dispose();
                cn.Close();
                cn.Dispose();
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {

            SelectedColumnNames.Clear();

            foreach (object o in clbFields.CheckedItems )
            {
                string fldnam = Program.BraketizeKeywords(o.ToString());
                
                SelectedColumnNames.Add(fldnam.ToString());
            }
            
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SelectedColumnNames.Clear();
            SelectedTableName = "";
            this.Hide();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clbFields.Items.Count; i++)
            {
                clbFields.SetItemChecked(i, true);
            }                      
        }

        private void btnNone_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clbFields.Items.Count; i++)
            {
                clbFields.SetItemChecked(i, false);
            }
        }

        private void btnShowFieldBrowser_Click(object sender, EventArgs e)
        {
            if (SelectedTableName != "")
            {
                frmFieldBrowser frm = new frmFieldBrowser(_dbase, SelectedTableName);
                frm.ShowDialog();
            }
        }

        private void HandleSearchTreeChanges(object sender, EventArgs e)
        {
            TreeNode thenode = null;


            foreach (TreeNode t in tvTables.Nodes)
            {
                if (t.Nodes.Count != 0)
                {
                    foreach(TreeNode tt in t.Nodes)
                    {
                        if (tt.Text.ToUpper().Contains(txtSearchTree.Text.ToUpper()))
                        {
                            thenode = tt;
                            break;
                        }
                    }

                    if (thenode!=null)
                    {
                        tvTables.SelectedNode = thenode;
                        tvTables.TabIndex = 0;
                        
                        break;
                    }
                }
            }
        }
    }
}
