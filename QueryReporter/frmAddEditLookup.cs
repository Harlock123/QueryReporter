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
    public partial class frmAddEditLookup : Form
    {

        public string Dbase = "";
        public List<string> Fields = new List<string>();
        public string TableName = "";
        public string FieldName = "";
        public string JoinField = "";
        public string JoinType = "";


        public frmAddEditLookup(string Connection, List<string> fields, TAIObjectCanvas2.CanvasObject obj)
        {
            InitializeComponent();

            Dbase = Connection;

            foreach (string s in fields)
            {
                lbFields.Items.Add(s);

            }

            SqlConnection cn = new SqlConnection(Dbase);
            cn.Open();

            SqlCommand cmd = new SqlCommand("SELECT TABLE_NAME,TABLE_TYPE from INFORMATION_SCHEMA.Tables ORDER BY TABLE_NAME", cn);

            SqlDataReader r = cmd.ExecuteReader();

            while (r.Read())
            {
                string tn = r["TABLE_NAME"] + "";

                lbTables.Items.Add(tn);

            }
            r.Close();
            cmd.Dispose();
            cn.Close();
            cn.Dispose();

            string[] meta = obj.MetaData.Split(System.Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            if (meta.GetUpperBound(0) == 4)
            {
                
                string[] jt = meta[4].Split(":".ToCharArray());
                string[] idxf = meta[0].Split(":".ToCharArray());
                string[] jtbl = meta[1].Split(":".ToCharArray());
                string[] jf = meta[2].Split(":".ToCharArray());
                string[] rf = meta[3].Split(":".ToCharArray());


                lbFields.SelectedItem = idxf[1];
                lbTables.SelectedItem = jtbl[1];
                HandleTableSelection(this, new EventArgs());
                lbJoinFields.SelectedItem = jf[1];

                string[] rff = rf[1].Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                foreach (string s in rff)
                {
                    lbReturnFields.SelectedItems.Add(s);

                }



                //foreach (string s in lbFields.Items)
                //{
                //    if (s == idxf[1])
                //    {
                //        lbFields.SelectedItems.Add(s);// = s;
                //    }
                //}

                //foreach (string s in lbTables.Items)
                //{
                //    if (s == jtbl[1])
                //    {
                //        lbTables.SelectedItems.Add(s);// = s;
                //    }
                //}

                //HandleTableSelection(this, new EventArgs());

                //foreach (string s in lbJoinFields.Items)
                //{
                //    if (s == jf[1])
                //    {
                //        lbJoinFields.SelectedItems.Add(s);// = s;
                //    }
                //}


                //string look = jt[1] + " " + jtbl[1] + " AS " + lt + " ON ";

                //// if we are looking up against a lookup already we need to not prepend the base table name
                //if (idxf[1].Split(".".ToCharArray()).GetUpperBound(0) == 0)
                //    look += GetBaseQueryTableName() + "." + idxf[1] + "=" + lt + "." + jf[1] + System.Environment.NewLine;
                //else
                //    look += idxf[1] + "=" + lt + "." + jf[1] + System.Environment.NewLine;

                //TheLookups += look;

                //string[] rff = rf[1].Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                //for (int i = 0; i <= rff.GetUpperBound(0); i++)
                //{
                //    string fline = lt + "." + rff[i] + " AS '" + idxf[1] + "_" + rff[i] + "'";

                //    if (i < rff.GetUpperBound(0))
                //        fline += "," + System.Environment.NewLine;

                //    if (i == 0)
                //        TheFields += "," + System.Environment.NewLine + fline;
                //    else
                //        TheFields += fline;

                //}

            }

        }
        
        public frmAddEditLookup(string Connection, List<string> fields)
        {
            InitializeComponent();

            Dbase = Connection;

            foreach (string s in fields)
            {
                lbFields.Items.Add(s);
                
            }

            SqlConnection cn = new SqlConnection(Dbase);
            cn.Open();

            SqlCommand cmd = new SqlCommand("SELECT TABLE_NAME,TABLE_TYPE from INFORMATION_SCHEMA.Tables ORDER BY TABLE_NAME", cn);

            SqlDataReader r = cmd.ExecuteReader();

            while (r.Read())
            {
                string tn = r["TABLE_NAME"] + "";

                lbTables.Items.Add(tn);

            }
            r.Close();
            cmd.Dispose();
            cn.Close();
            cn.Dispose();
            
        }

        public frmAddEditLookup(string Connection, List<string> fields, bool HC)
        {
            InitializeComponent();

            // this will be the entry point for Hard Coded lookups...
            // the end result will be a SELECT TOP 1 query 

            Dbase = Connection;

            foreach (string s in fields)
            {
                lbFields.Items.Add(s);

            }

            rbInner.Visible = false;
            rbLeftOuter.Visible = false;

            SqlConnection cn = new SqlConnection(Dbase);
            cn.Open();

            SqlCommand cmd = new SqlCommand("SELECT TABLE_NAME,TABLE_TYPE from INFORMATION_SCHEMA.Tables ORDER BY TABLE_NAME", cn);

            SqlDataReader r = cmd.ExecuteReader();

            while (r.Read())
            {
                string tn = r["TABLE_NAME"] + "";

                lbTables.Items.Add(tn);

            }
            r.Close();
            cmd.Dispose();
            cn.Close();
            cn.Dispose();

        }

        public frmAddEditLookup(string Connection, List<string> fields, bool HC, TAIObjectCanvas2.CanvasObject obj)
        {
            InitializeComponent();

            Dbase = Connection;

            foreach (string s in fields)
            {
                lbFields.Items.Add(s);

            }

            rbInner.Visible = false;
            rbLeftOuter.Visible = false;

            SqlConnection cn = new SqlConnection(Dbase);
            cn.Open();

            SqlCommand cmd = new SqlCommand("SELECT TABLE_NAME,TABLE_TYPE from INFORMATION_SCHEMA.Tables ORDER BY TABLE_NAME", cn);

            SqlDataReader r = cmd.ExecuteReader();

            while (r.Read())
            {
                string tn = r["TABLE_NAME"] + "";

                lbTables.Items.Add(tn);

            }
            r.Close();
            cmd.Dispose();
            cn.Close();
            cn.Dispose();

            string[] meta = obj.MetaData.Split(System.Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            if (meta.GetUpperBound(0) == 4)
            {

                string[] jt = meta[4].Split(":".ToCharArray());
                string[] idxf = meta[0].Split(":".ToCharArray());
                string[] jtbl = meta[1].Split(":".ToCharArray());
                string[] jf = meta[2].Split(":".ToCharArray());
                string[] rf = meta[3].Split(":".ToCharArray());


                lbFields.SelectedItem = idxf[1];
                lbTables.SelectedItem = jtbl[1];
                HandleTableSelection(this, new EventArgs());
                lbJoinFields.SelectedItem = jf[1];

                string[] rff = rf[1].Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                foreach (string s in rff)
                {
                    lbReturnFields.SelectedItems.Add(s);

                }
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (lbFields.SelectedIndex != -1)
                FieldName = Program.BraketizeKeywords(lbFields.SelectedItem.ToString());

            if (lbTables.SelectedIndex != -1)
                TableName = lbTables.SelectedItem.ToString();

            if (lbJoinFields.SelectedIndex != -1)
                JoinField = Program.BraketizeKeywords(lbJoinFields.SelectedItem.ToString());

            if (lbReturnFields.SelectedIndex != -1)
            {
                Fields.Clear();
                for (int i = 0; i < lbReturnFields.SelectedItems.Count; i++)
                {

                    string fld = lbReturnFields.SelectedItems[i].ToString();

                    if (fld.Replace(" ", "") != fld)
                        fld = "[" + fld + "]";


                    Fields.Add(fld);
                }
            }

            if (rbInner.Visible)
            {

                if (rbLeftOuter.Checked)
                {
                    JoinType = "LEFT OUTER JOIN";
                }
                else
                {
                    JoinType = "INNER JOIN";
                }
            }
            else
            {
                JoinType = "INLINE";
            }
            
            this.Hide();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            TableName = "";
            FieldName = "";
            JoinField = "";
            Fields = new List<string>();

            this.Hide();
        }

        private void HandleTableSelection(object sender, EventArgs e)
        {
            if (lbTables.SelectedIndex != -1)
            {
                TableName = lbTables.SelectedItem.ToString(); 
                
                lbJoinFields.Items.Clear();
                lbReturnFields.Items.Clear();

                string sql = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + TableName + "' ORDER BY ORDINAL_POSITION";

                SqlConnection cn = new SqlConnection(Dbase);
                cn.Open();

                SqlCommand cmd = new SqlCommand(sql, cn);

                SqlDataReader r = cmd.ExecuteReader();

                while (r.Read())
                {
                    lbJoinFields.Items.Add(r["COLUMN_NAME"] + "");
                    lbReturnFields.Items.Add(r["COLUMN_NAME"] + "");

                }

                r.Close();
                cmd.Dispose();
                cn.Close();
                cn.Dispose();


            }
        }
               
    }
}
