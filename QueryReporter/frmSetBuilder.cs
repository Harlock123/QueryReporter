using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using TAIObjectCanvas2;
using System.IO;

namespace TAIQueryReporter
{
    public partial class frmSetBuilder : Form
    {

        public string Clause = "";
        string TheType = "";
        string FieldName = "";

        private TAIObjectCanvas2.ObjectCanvas oc1 = new ObjectCanvas();

        string ConnectionString = "";
        
        public frmSetBuilder(string typ, string fname)
        {
            InitializeComponent();

            TheType = typ;
            FieldName = fname;

        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clause = "";
            
            this.Hide();
        }

        private string GetBaseQueryTableName()
        {
            string ret = "";

            foreach (CanvasObject ob in oc1.TheCanvasObjects)
            {
                if (ob.Name == "DATASOURCE")
                {
                    ret = ob.MetaData;
                    break;
                }
            }

            return ret;
        }

        private void GenerateSQLCode()
        {
            string sql = "";

            string PrePrequil = "SELECT ";

            string Prequil = " ";
            string TheLookups = "";
            string TheFields = "";
            string TheCalcs = "";
            string TheWhere = "";
            string TheSynths = "";
            string JustSynths = "";
            string JustHavings = "";
            string FromTBL = "";
            string GroupClause = "";
            string LimiterClause = "";
            string OrderClause = "";

            string JustFields = "";

            int lkup = 0;

            foreach (CanvasObject ob in oc1.TheCanvasObjects)
            {
                if (ob.Name == "DATASOURCE")
                {
                    FromTBL = "FROM " + ob.MetaData;

                    string[] flds = ob.MetaData2.Split("|".ToCharArray());

                    string fline = "";

                    foreach (string s in flds)
                    {
                        fline += ob.MetaData + "." + s + ",";

                        if (fline.Length > 70)
                        {
                            TheFields += fline + System.Environment.NewLine;
                            fline = "";
                        }

                    }

                    if (fline != "")
                    {
                        TheFields += fline;
                        fline = "";

                        if (TheFields.EndsWith(System.Environment.NewLine))
                        {
                            TheFields = TheFields.Substring(0, TheFields.Length - System.Environment.NewLine.Length);
                        }

                        if (TheFields.EndsWith(","))
                        {
                            TheFields = TheFields.Substring(0, TheFields.Length - 1);
                        }
                    }
                    else
                    {
                        // strip off a trailing newline and trailing "," character if necessary

                        if (TheFields.EndsWith(System.Environment.NewLine))
                        {
                            TheFields = TheFields.Substring(0, TheFields.Length - System.Environment.NewLine.Length);
                        }

                        if (TheFields.EndsWith(","))
                        {
                            TheFields = TheFields.Substring(0, TheFields.Length - 1);
                        }

                    }

                    JustFields = TheFields;
                }

                if (ob.Name.StartsWith("LOOKUP"))
                {
                    string[] meta = ob.MetaData.Split(System.Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                    if (meta.GetUpperBound(0) == 4)
                    {
                        string lt = "LT" + lkup.ToString();
                        lkup += 1;

                        string[] jt = meta[4].Split(":".ToCharArray());
                        string[] idxf = meta[0].Split(":".ToCharArray());
                        string[] jtbl = meta[1].Split(":".ToCharArray());
                        string[] jf = meta[2].Split(":".ToCharArray());
                        string[] rf = meta[3].Split(":".ToCharArray());

                        string look = jt[1] + " " + jtbl[1] + " AS " + lt + " ON ";

                        // if we are looking up against a lookup already we need to not prepend the base table name
                        if (idxf[1].Split(".".ToCharArray()).GetUpperBound(0) == 0)
                            look += GetBaseQueryTableName() + "." + idxf[1] + "=" + lt + "." + jf[1] + System.Environment.NewLine;
                        else
                            look += idxf[1] + "=" + lt + "." + jf[1] + System.Environment.NewLine;

                        TheLookups += look;

                        string[] rff = rf[1].Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                        for (int i = 0; i <= rff.GetUpperBound(0); i++)
                        {
                            string fline = lt + "." + rff[i] + " AS '" + idxf[1] + "_" + rff[i] + "'";

                            JustFields += "," + lt + "." + rff[i];

                            if (i < rff.GetUpperBound(0))
                                fline += "," + System.Environment.NewLine;

                            if (i == 0)
                                TheFields += "," + System.Environment.NewLine + fline;
                            else
                                TheFields += fline;

                        }

                    }

                }

                if (ob.Name.StartsWith("HCLOOKUP"))
                {
                    string[] meta = ob.MetaData.Split(System.Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                    if (meta.GetUpperBound(0) == 4)
                    {
                        string lt = "LT" + lkup.ToString();
                        lkup += 1;

                        string[] jt = meta[4].Split(":".ToCharArray());
                        string[] idxf = meta[0].Split(":".ToCharArray());
                        string[] jtbl = meta[1].Split(":".ToCharArray());
                        string[] jf = meta[2].Split(":".ToCharArray());
                        string[] rf = meta[3].Split(":".ToCharArray());
                        
                        string[] rff = rf[1].Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                        for (int i = 0; i <= rff.GetUpperBound(0); i++)
                        {

                            string basequeryfieldwithtable = GetBaseQueryTableName() + "." + idxf[1];


                            string fline = "(SELECT TOP 1 " + rff[i] + " FROM " + jtbl[1] + " WHERE " +
                                basequeryfieldwithtable + "=" + jtbl[1] + "." + jf[1] + ") AS " +
                                "'" + idxf[1] + "_" + rff[i] + "'";


                            if (!JustFields.Contains(basequeryfieldwithtable))
                                JustFields += "," + basequeryfieldwithtable;

                            if (i < rff.GetUpperBound(0))
                                fline += "," + System.Environment.NewLine;

                            if (i == 0)
                                TheFields += "," + System.Environment.NewLine + fline;
                            else
                                TheFields += fline;

                        }

                    }

                }

                if (ob.Name.StartsWith("LIMITER"))
                {
                    LimiterClause += ob.MetaData + System.Environment.NewLine;

                }

                if (ob.Name.StartsWith("CALC"))
                {
                    TheCalcs += ob.MetaData + "," + System.Environment.NewLine;

                }

                if (ob.Name.StartsWith("FILTER"))
                {
                    TheWhere += ob.MetaData + " AND " + System.Environment.NewLine;

                }

                if (ob.Name.StartsWith("SYNTH"))
                {

                    string clause = ob.MetaData;

                    TheSynths += clause + "," + System.Environment.NewLine;

                    JustSynths += clause.Substring(0, clause.IndexOf(" AS '")) + "," + System.Environment.NewLine;

                }

                if (ob.Name.StartsWith("SORT"))
                {
                    OrderClause = ob.MetaData + System.Environment.NewLine;

                }

                if (ob.Name.StartsWith("CONSTRAINT"))
                {

                    string clause = ob.MetaData;

                    if (JustHavings == "")
                    {
                        JustHavings += "HAVING " + clause;
                    }
                    else
                    {
                        JustHavings += " AND " + clause;
                    }

                }

                if (ob.Name.StartsWith("ROLLUP"))
                {
                    //GroupClause  += ob.MetaData;

                    GroupClause += "GROUP BY" + System.Environment.NewLine + JustFields;

                }

            }

            // clean up the where clause
            if (TheWhere != "")
            {
                TheWhere = TheWhere.Trim();

                if (TheWhere.EndsWith(" AND"))
                {
                    TheWhere = TheWhere.Substring(0, TheWhere.Length - 4);
                }

                TheWhere = "WHERE " + TheWhere;

            }


            // Strip a trailing ,/n if there is one
            if (TheFields.EndsWith("," + System.Environment.NewLine))
            {
                TheFields = TheFields.Substring(0, TheFields.Length - 3);
            }

            // Strip a trailing ,/n if there is one
            if (TheCalcs.EndsWith("," + System.Environment.NewLine))
            {
                TheCalcs = TheCalcs.Substring(0, TheCalcs.Length - 3);
            }

            // Strip a trailing ,/n if there is one
            if (TheSynths.EndsWith("," + System.Environment.NewLine))
            {
                TheSynths = TheSynths.Substring(0, TheSynths.Length - 3);
            }

            // Strip a trailing ,/n if there is one
            if (JustSynths.EndsWith("," + System.Environment.NewLine))
            {
                JustSynths = JustSynths.Substring(0, JustSynths.Length - 3);
            }

            if (TheSynths != "")
            {
                TheFields += "," + System.Environment.NewLine + TheSynths;

                if (GroupClause != "")
                {
                    GroupClause += "," + System.Environment.NewLine + JustSynths;
                }
            }

            if (TheCalcs != "")
            {
                TheFields += "," + System.Environment.NewLine + TheCalcs;
            }


            sql = PrePrequil + LimiterClause + Prequil + System.Environment.NewLine +
                TheFields + System.Environment.NewLine +
                FromTBL + System.Environment.NewLine +
                TheLookups + System.Environment.NewLine +
                TheWhere + System.Environment.NewLine +
                GroupClause + System.Environment.NewLine +
                JustHavings + System.Environment.NewLine +
                OrderClause;

            taig.PopulateGridWithData(ConnectionString, sql);

            //tais.Text = sql.Trim();
        }

        private void btnSelectSubQuery_Click(object sender, EventArgs e)
        {
            Stream myStream;

            ofd.DefaultExt = "TAI Query Reporter Files|*.TQR";
            ofd.Title = "Open a saved TAI Query Reporter file";

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //btnClearCurrentQuery_Click(sender, e);

                oc1.ClearObjects();

                if ((myStream = ofd.OpenFile()) != null)
                {
                    StreamReader wText = new StreamReader(myStream);

                    string ln = "";

                    // skip the first two lines
                    ln = wText.ReadLine();
                    ln = wText.ReadLine();

                    // read the connection string
                    ConnectionString  = wText.ReadLine();

                    // skip a line
                    wText.ReadLine();

                    // read the number of canvas objects
                    ln = wText.ReadLine();

                    int num = int.Parse(ln);

                    for (int tt = 0; tt < num; tt++)
                    {
                        string name = wText.ReadLine();
                        string loc = wText.ReadLine();

                        string meta = "";
                        string meta2 = "";
                        string meta3 = "";

                        if (name.StartsWith("LOOKUP") || name.StartsWith("HCLOOKUP"))
                        {
                            string m = wText.ReadLine();
                            while (m != "")
                            {
                                meta += m + System.Environment.NewLine;
                                m = wText.ReadLine();
                            }
                            meta2 = "";

                        }
                        else
                        {
                            meta = wText.ReadLine();
                            meta2 = wText.ReadLine();
                        }

                        meta3 = wText.ReadLine();
                        string sz = wText.ReadLine();

                        ln = wText.ReadLine();
                        int c = int.Parse(ln);

                        Color fg = Color.FromArgb(c);

                        ln = wText.ReadLine();
                        c = int.Parse(ln);

                        Color bg = Color.FromArgb(c);

                        loc = loc.Replace("{", "").Replace("}", "");
                        string[] ll = loc.Split(",".ToCharArray());

                        string xx = ll[0].Replace("X=", "");
                        string yy = ll[1].Replace("Y=", "");

                        CanvasObject ob = new CanvasObject(oc1, name, meta, meta2, meta3, int.Parse(xx), int.Parse(yy), fg, bg);

                        oc1.AddObject(ob);

                    }

                    // skip a line
                    wText.ReadLine();

                    // read the number of canvas connections
                    ln = wText.ReadLine();
                    num = int.Parse(ln);

                    for (int tt = 0; tt < num; tt++)
                    {
                        ln = wText.ReadLine();
                        int c = int.Parse(ln);

                        Color bg = Color.FromArgb(c);

                        ln = wText.ReadLine();
                        int lw = int.Parse(ln);

                        string cty = wText.ReadLine();

                        string stnode = wText.ReadLine();
                        string ednode = wText.ReadLine();

                        CanvasObjectConnection cn = new CanvasObjectConnection(stnode, ednode, bg, lw, ConnectionType.DotArrow);

                        oc1.AddConnection(cn);

                    }

                    myStream.Close();
                }

                

                GenerateSQLCode();


            }
        }

        private void HandleCellDoubleClicked(object sender, int RowClicked, int ColumnClicked)
        {
            if (taig.SelectedColumn != -1)
            {
                int col = taig.SelectedColumn;

                Clause = FieldName + " IN (";

                for (int row = 0; row < taig.Rows; row++)
                {
                    string v = taig.get_item(row, col);

                    if (TheType == "DATE" || TheType == "STRING")
                    {
                        Clause += "'" + v + "'";

                    }
                    else
                    {
                        Clause += v;
                    }

                    if (row != taig.Rows - 1)
                    {
                        Clause += ",";
                    }
                    else
                    {
                        Clause += ")";
                    }

                }

                txtClause.Text = Clause;
            }
        }

        private void HandleColumnSelected(object sender, int ColumnIndex)
        {
            if (taig.SelectedColumn != -1)
            {
                int col = taig.SelectedColumn;

                Clause = FieldName + " IN (";

                for (int row = 0; row < taig.Rows; row++)
                {
                    string v = taig.get_item(row, col);

                    if (TheType == "DATE" || TheType == "STRING")
                    {
                        Clause += "'" + v + "'";

                    }
                    else
                    {
                        Clause += v;
                    }

                    if (row != taig.Rows - 1)
                    {
                        Clause += ",";
                    }
                    else
                    {
                        Clause += ")";
                    }

                }

                txtClause.Text = Clause;
            }
        }

    }
}
