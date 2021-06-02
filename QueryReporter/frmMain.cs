using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using TAIObjectCanvas2;
using System.IO;
using System.Security.Cryptography;


namespace TAIQueryReporter
{
    public partial class frmMain : Form
    {

        private frmStartup _sFrm = new frmStartup();
        private CanvasObject objbeingedited = null;

        List<string> ServerInstances = new List<string>();
        List<string> PreSetServerInstances = new List<string>();
        List<string> EncryptedServers = new List<string>();

        public bool Enumerate = false;

        #region " Constructor"

        // FB 5433 5/17/2012 - ttheobald 
        // Autoload and execute a query file when placed on the command-line
        // usage: TaiQueryReporter /q filename.qry
        private bool AutoloadQueryFile()
        {
            bool bQueryFileLoaded = false;
            // Get the query file to auto load from the command line
            bool bQueryFile = false; // Is the next arg a Query Filename?
            bool bExecute = false;  // Execute query on load
            string strQueryFileName = "";
            foreach (string arg in Environment.GetCommandLineArgs())
            {
                if (bQueryFile)
                {
                    strQueryFileName = arg;
                    bQueryFile = false;
                }
                if (arg.Trim().Equals("/q")) bQueryFile = true;
                if (arg.Trim().Equals("/e")) bExecute = true;
                if (arg.Trim().ToUpper().Equals("/H") || arg.Trim().ToUpper().Equals("-H"))
                    MessageBox.Show("usage: TaiQueryReporter [/q queryfilename] [/e] " + Environment.NewLine +
                                    "/q queryfilename  -  specify a query filename to load when the application loads " + Environment.NewLine +
                                    "/e  -  execute the query when the application loads",
                                    "TAIQueryReporter", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            // if we have a query file to load, then load it
            if (strQueryFileName.Length > 0)
            {
                OpenQueryFile(strQueryFileName);
                if (bExecute) btnExecute_Click(null, null);  // Call Execute button click to Execute the query
                bQueryFileLoaded = true;
            }
            return bQueryFileLoaded;
        }

        public frmMain()
        {
            InitializeComponent();

            tais.Text = "SELECT A FROM B WHERE C = D ORDER BY A GROUP BY A";

            this.Text += " " + Application.ProductVersion.ToString();

            ReadIni();

            // FB 5433 5/17/2012 - ttheobald
            if (AutoloadQueryFile()) 
                Enumerate = false;  

            if (Enumerate)
            {
                ShowStartup();

                SqlDataSourceEnumerator instance = System.Data.Sql.SqlDataSourceEnumerator.Instance;
                DataTable svs = instance.GetDataSources();

                foreach (System.Data.DataRow row in svs.Rows)
                {
                    ServerInstances.Add(row["ServerName"].ToString());
                }

                svs = null;
                instance = null;

                HideStartup();
            }

            ttip.IsBalloon = false;
            ttip.ToolTipIcon = ToolTipIcon.Info;
            ttip.BackColor = Color.Yellow;

            oc1.cmenu = cm;
        
        }

        #endregion

        #region " Events"

        //Button Events

        private void btlAddLookup_Click(object sender, EventArgs e)
        {
            if (txtConnectionString.Text != String.Empty)
            {
                List<string> flds = getFieldsInBaseTable();

                AppendLookupFields(flds);

                if (flds.Count != 0)
                {
                    frmAddEditLookup frm = new frmAddEditLookup(decodeConnection(), flds);
                    frm.ShowDialog();

                    if (frm.Fields.Count != 0 && frm.FieldName != "" && frm.TableName != "" && frm.JoinField != "")
                    {
                        // we have selected a valid join
                        string Meta = "INDEXFIELD:" + frm.FieldName + System.Environment.NewLine;
                        string fields = "";

                        Meta += "INDEXTABLE:" + frm.TableName + System.Environment.NewLine;
                        Meta += "INDEXAGAINST:" + frm.JoinField + System.Environment.NewLine;
                        Meta += "INDEXRETURNS:";

                        foreach (string s in frm.Fields)
                        {
                            fields += s + ",";
                        }

                        // strip the last , off the thing
                        fields = fields.Substring(0, fields.Length - 1);

                        Meta += fields + System.Environment.NewLine;
                        Meta += "JOINTYPE:" + frm.JoinType;

                        int lkps = CountExistingLookups();

                        TAIObjectCanvas2.CanvasObject ob = new TAIObjectCanvas2.CanvasObject(oc1, "LOOKUP_" + lkps.ToString(), Meta, 10, 10 + (lkps * 20), Color.FromArgb(255, 128, 255, 255), Color.Black);

                        oc1.AddObject(ob);
                        oc1.AddConnection("LOOKUP_" + lkps.ToString().Replace("[","").Replace("]",""), "DATASOURCE", Color.Black, ConnectionType.DotArrow);

                        GenerateSQLCode();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please connect to a server before adding a lookup.",
                                "TAIQueryReporter", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAddCalculation_Click(object sender, EventArgs e)
        {
            if (txtConnectionString.Text != String.Empty)
            {
                List<string> flds = getFieldsInBaseTableWithBaseTableName();

                AppendLookupFields(flds);

                frmAddEditCalculation frm = new frmAddEditCalculation(decodeConnection(), flds);
                frm.ShowDialog();

                if (frm.CalcClause != "")
                {
                    int cc = CountExistingCalcs();
                    string meta = "";

                    TAIObjectCanvas2.CanvasObject ob = new TAIObjectCanvas2.CanvasObject(oc1, "CALC_" + cc.ToString(), frm.CalcClause, 100, 10 + (cc * 20), Color.FromArgb(255, 255, 224, 192), Color.Black);
                    ob.MetaData = frm.CalcClause;

                    foreach (frmAddEditCalculation.CalculationItem ci in frm.SelectedFields)
                    {
                        meta += ci.CalculationType + "|" + ci.CalculationAlias + "|" + ci.CalculationField + "|" + ci.CalculationTable + "|";
                    }

                    meta = meta.Substring(0, meta.Length - 1);

                    ob.MetaData2 = meta;

                    oc1.AddObject(ob);
                    oc1.AddConnection("CALC_" + cc.ToString(), "DATASOURCE", Color.Black, ConnectionType.DotArrow);

                    GenerateSQLCode();
                }
            }
            else
            {
                MessageBox.Show("Please connect to a server before adding a calculation.",
                                "TAIQueryReporter", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAddConstraint_Click(object sender, EventArgs e)
        {
            if (txtConnectionString.Text != String.Empty)
            {
                List<string> agg = new List<string>();

                foreach (CanvasObject o in oc1.TheCanvasObjects)
                {
                    if (o.Name.StartsWith("CALC") || o.Name.StartsWith("SYNTH"))
                    {
                        // we have a cal or an synth so lets get the field from its metadata
                        string m = o.MetaData;

                        string[] fields = m.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                        string[] spl = { " AS" };

                        for (int i = 0; i < fields.Length; i++)
                        {
                            string[] mm = fields[i].Split(spl, StringSplitOptions.RemoveEmptyEntries);
                            agg.Add(mm[0]);
                        }
                    }
                }

                frmAddConstraint frm = new frmAddConstraint(agg);
                frm.ShowDialog();

                if (frm.Clause != "")
                {
                    // lets add a synth clause
                    int cc = CountExistingConstraints();
                    string meta = "";

                    TAIObjectCanvas2.CanvasObject ob = new TAIObjectCanvas2.CanvasObject(oc1, "CONSTRAINT_" + cc.ToString(), frm.Clause, 400, 300 - (cc * 20), Color.FromArgb(255, 192, 192, 255), Color.Black);

                    frmAddConstraint.ConstraintItem ci = new frmAddConstraint.ConstraintItem();

                    ci = frm.Constraint;
                    meta += ci.ConstraintType + "|" + ci.ConstraintField + "|";

                    foreach (string item in ci.ConstraintValues)
                    {
                        meta += item + ",";
                    }

                    meta = meta.Substring(0, meta.Length - 1);

                    ob.MetaData2 = meta;

                    oc1.AddObject(ob);
                    oc1.AddConnection("CONSTRAINT_" + cc.ToString(), "DATASOURCE", Color.Black, ConnectionType.DotArrow);

                    GenerateSQLCode();
                }
            }
            else
            {
                MessageBox.Show("Please connect to a server before adding a constraint.",
                                "TAIQueryReporter", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAdd_Distinct_Click(object sender, EventArgs e)
        {
            if (txtConnectionString.Text != String.Empty)
            {
                if (CountExistingDistinct() == 0)
                {
                    string gb = "DISTINCT";

                    TAIObjectCanvas2.CanvasObject ob = new TAIObjectCanvas2.CanvasObject(oc1, "DISTINCT", gb, 320, 300, Color.SkyBlue, Color.Black);

                    oc1.AddObject(ob);
                    oc1.AddConnection("DISTINCT", "DATASOURCE", Color.Black, ConnectionType.DotArrow);

                    GenerateSQLCode();
                }
            }
            else
            {
                MessageBox.Show("Please connect to a server first.",
                                "TAIQueryReporter", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAddFilter_Click(object sender, EventArgs e)
        {
            if (txtConnectionString.Text != String.Empty)
            {
                frmAddFilter frm = new frmAddFilter(decodeConnection(), GetListOfTableNames());
                frm.ShowDialog();

                if (frm.Clause != "")
                {
                    // here we should prompt to add to existing filter or add as an and
                    int cc = CountExistingFilter();
                    frmAddFilter.FilterItem FilteredItem = new frmAddFilter.FilterItem();
                    string meta = "";

                    FilteredItem = frm.Filter;

                    meta += FilteredItem.GridRowID.ToString() + "|" + FilteredItem.FilterType.ToString() + "|" + FilteredItem.FilterField + "|";

                    if (FilteredItem.FilterValues != null)
                    {
                        foreach (string s in FilteredItem.FilterValues)
                        {
                            meta += s + ",";
                        }
                        meta = meta.Substring(0, meta.Length - 1);
                    }
                    else
                    {
                        meta = meta.Substring(0, meta.Length - 1);
                    }

                    if (cc == 1)
                    {
                        TAIObjectCanvas2.CanvasObject ob = new TAIObjectCanvas2.CanvasObject(oc1, "FILTER_" + cc.ToString(), frm.Clause, 400, 10 + (cc * 20), Color.FromArgb(255, 255, 128, 128), Color.Black);
                        ob.MetaData2 = meta;

                        oc1.AddObject(ob);
                        oc1.AddConnection("FILTER_" + cc.ToString(), "DATASOURCE", Color.Black, ConnectionType.DotArrow);

                        GenerateSQLCode();
                    }
                    else
                    {
                        // here we have at least one filter already so we need to show the filter joiner
                        List<CanvasObject> thefilts = new List<CanvasObject>();

                        foreach (CanvasObject o in oc1.TheCanvasObjects)
                        {
                            if (o.Name.StartsWith("FILTER_"))
                            {
                                thefilts.Add(o);
                            }
                        }

                        frmFilterJoiner frm1 = new frmFilterJoiner(thefilts, frm.Clause);
                        frm1.ShowDialog();

                        if (frm1.TheConnectType != "")
                        {
                            if (frm1.TheConnectType == "AND")
                            {
                                TAIObjectCanvas2.CanvasObject ob = new TAIObjectCanvas2.CanvasObject(oc1, "FILTER_" + cc.ToString(), frm.Clause, 400, 10 + (cc * 20), Color.FromArgb(255, 255, 128, 128), Color.Black);

                                ob.MetaData2 = meta;

                                oc1.AddObject(ob);
                                oc1.AddConnection("FILTER_" + cc.ToString(), "DATASOURCE", Color.Black, ConnectionType.DotArrow);

                                GenerateSQLCode();
                            }
                            else
                            {
                                // we need to or it with something already there
                                foreach (CanvasObject o in oc1.TheCanvasObjects)
                                {
                                    if (o.Name == frm1.TheFilterToConnectWith.Name)
                                    {
                                        TAIObjectCanvas2.CanvasObject ob = new TAIObjectCanvas2.CanvasObject(oc1, "FILTER_" + cc.ToString(), frm.Clause, 400, 10 + (cc * 50), Color.FromArgb(255, 255, 128, 128), Color.Black);
                                        ob.MetaData2 = meta;
                                        ob.MetaData3 = o.Name;
                                        oc1.AddObject(ob);
                                        oc1.AddConnection("FILTER_" + cc.ToString(), "DATASOURCE", Color.Black, ConnectionType.DotArrow);
                                        break;
                                    }
                                }

                                GenerateSQLCode();
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please connect to a server before adding a filter.",
                                "TAIQueryReporter", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAddLimiter_Click(object sender, EventArgs e)
        {
            frmAddLimiter frm = new frmAddLimiter();
            frm.ShowDialog();

            if (frm.Clause != "")
            {
                // lets add a limiter, we can only have one so we will remove it and re-add it
                foreach (CanvasObject o in oc1.TheCanvasObjects)
                {
                    if (o.Name == "LIMITER")
                    {
                        oc1.RemoveObject("LIMITER");
                        break;
                    }
                }

                TAIObjectCanvas2.CanvasObject ob = new TAIObjectCanvas2.CanvasObject(oc1, "LIMITER", frm.Clause, 100, 150, Color.FromArgb(255, 192, 192, 0), Color.Black);

                ob.MetaData2 = frm.Limiter;

                oc1.AddObject(ob);
                oc1.AddConnection("LIMITER", "DATASOURCE", Color.Black, ConnectionType.DotArrow);

                GenerateSQLCode();
            }
        }

        private void btnAddRollup_Click(object sender, EventArgs e)
        {
            if (txtConnectionString.Text != String.Empty)
            {
                if (CountExistingRollup() == 0)
                {
                    List<string> flds = getFieldsInBaseTableWithBaseTableName();
                    string gb = "GROUP BY  {All Selected Fields}";

                    AppendLookupFields(flds);

                    TAIObjectCanvas2.CanvasObject ob = new TAIObjectCanvas2.CanvasObject(oc1, "ROLLUP", gb, 600, 150, Color.FromArgb(255, 128, 128, 255), Color.Black);

                    oc1.AddObject(ob);
                    oc1.AddConnection("DATASOURCE", "ROLLUP", Color.Black, ConnectionType.DotArrow);

                    GenerateSQLCode();
                }
                else
                {
                    // we have a rollup already so lets remove it and call add rollup recursively
                    oc1.RemoveObject("ROLLUP");
                    btnAddRollup_Click(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Please connect to a server before adding a rollup.",
                                "TAIQueryReporter", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAddSortOperation_Click(object sender, EventArgs e)
        {
            frmAddSortOps frm = new frmAddSortOps(GetListOfSelectedFieldsAndLookupsAndCalcsAndSynths());
            frm.ShowDialog();

            if (frm.Clause != "")
            {
                // we can only have one so we will remove it and re-add it
                foreach (CanvasObject o in oc1.TheCanvasObjects)
                {
                    if (o.Name == "SORT")
                    {
                        oc1.RemoveObject("SORT");
                        break;
                    }
                }

                TAIObjectCanvas2.CanvasObject ob = new TAIObjectCanvas2.CanvasObject(oc1, "SORT", frm.Clause, 500, 200, Color.FromArgb(255, 255, 128, 255), Color.Black);

                //get the meta info
                string meta = "";
                List<frmAddSortOps.SortItem> si = new List<frmAddSortOps.SortItem>();

                si = frm.SortedItems;

                if (si.Count > 0)
                {
                    foreach (frmAddSortOps.SortItem s in si)
                    {
                        meta += s.SortField + "," + s.SortDirection + "|";
                    }
                }

                //trim remaining |
                meta = meta.Substring(0, meta.Length - 1);

                //Set the MetaData2 of the object
                ob.MetaData2 = meta;

                oc1.AddObject(ob);
                oc1.AddConnection("SORT", "DATASOURCE", Color.Black, ConnectionType.DotArrow);

                GenerateSQLCode();
            }
        }

        private void btnAddSyntheticField_Click(object sender, EventArgs e)
        {
            frmAddSyntheticFields frm = new frmAddSyntheticFields(decodeConnection(), GetListOfTableNames());
            frm.ShowDialog();

            frmAddSyntheticFields.SyntheticItem si = frm.SelectedSynthItem;

            if (frm.Clause != "")
            {
                // lets add a synth clause
                int cc = CountExistingSynth();

                TAIObjectCanvas2.CanvasObject ob = new TAIObjectCanvas2.CanvasObject(oc1, "SYNTH_" + cc.ToString(), frm.Clause, 100, 300 - (cc * 20), Color.FromArgb(255, 255, 255, 128), Color.Black);

                string meta = si.SyntheticAlias + "|" + si.SyntheticType + "|";

                if (si.SyntheticFields.Count > 0)
                {
                    for (int i = 0; i < si.SyntheticFields.Count; i++)
                    {
                        meta += si.SyntheticFields[i] + ",";
                    }

                    //remove trailing comma
                    meta = meta.Substring(0, meta.Length - 1);
                    meta += "|";
                }

                if (si.SyntheticTables.Count > 0)
                {
                    for (int i = 0; i < si.SyntheticTables.Count; i++)
                    {
                        meta += si.SyntheticTables[i] + ",";
                    }

                    //remove trailing comma
                    meta = meta.Substring(0, meta.Length - 1);
                    meta += "|";
                }

                meta += si.SyntheticX + "|" + si.SyntheticY;

                //trim trailing pipe
                ob.MetaData2 = meta;
                oc1.AddObject(ob);

                oc1.AddConnection("SYNTH_" + cc.ToString(), "DATASOURCE", Color.Black, ConnectionType.DotArrow);

                GenerateSQLCode();
            }
        }

        private void btnClearCurrentQuery_Click(object sender, EventArgs e)
        {
            oc1.ClearObjects();
            oc1.Refresh();
            GenerateSQLCode();
        }

        private void BtnConnect2AServer_Click(object sender, EventArgs e)
        {
            frmSelectDataSource sd = new frmSelectDataSource();

            sd.PopulateServers(ServerInstances, PreSetServerInstances);
            sd.ShowDialog();

            if (sd.ConnectionString != "")
            {
                txtConnectionString.Text = sd.ConnectionString;
            }

            sd = null;
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (txtConnectionString.Text != String.Empty)
            {
                theTabs.SelectedTab = tbResult;

                taigResults.ShowProgressBar = true;
                taigResults.PopulateGridWithData(decodeConnection(), tais.Text);
            }
            else
            {
                MessageBox.Show("Please connect to a server before running a query.",
                                "TAIQueryReporter", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnGraphResults_Click(object sender, EventArgs e)
        {
            frmGraphing frm = new frmGraphing(taigResults);
            frm.ShowDialog();
        }

        private void btnHCLookup_Click(object sender, EventArgs e)
        {
            if (txtConnectionString.Text != String.Empty)
            {
                List<string> flds = getFieldsInBaseTable();

                AppendLookupFields(flds);

                if (flds.Count != 0)
                {
                    frmAddEditLookup frm = new frmAddEditLookup(txtConnectionString.Text, flds, true);
                    frm.ShowDialog();

                    if (frm.Fields.Count != 0 && frm.FieldName != "" && frm.TableName != "" && frm.JoinField != "")
                    {
                        // we have selected a valid join
                        string Meta = "INDEXFIELD:" + frm.FieldName + System.Environment.NewLine;

                        Meta += "INDEXTABLE:" + frm.TableName + System.Environment.NewLine;
                        Meta += "INDEXAGAINST:" + frm.JoinField + System.Environment.NewLine;
                        Meta += "INDEXRETURNS:";

                        string fields = "";

                        foreach (string s in frm.Fields)
                        {
                            fields += s + ",";
                        }

                        // strip the last , off the thing

                        fields = fields.Substring(0, fields.Length - 1);

                        Meta += fields + System.Environment.NewLine;
                        Meta += "JOINTYPE:" + frm.JoinType;

                        int lkps = CountExistingHCLookups();

                        TAIObjectCanvas2.CanvasObject ob = new TAIObjectCanvas2.CanvasObject(oc1, "HCLOOKUP_" + lkps.ToString(), Meta, 10, 300 - (lkps * 20), Color.FromArgb(255, 128, 255, 192), Color.Black);

                        oc1.AddObject(ob);
                        oc1.AddConnection("HCLOOKUP_" + lkps.ToString(), "DATASOURCE", Color.Black, ConnectionType.DotArrow);

                        GenerateSQLCode();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please connect to a server before adding an HCLookup.",
                                "TAIQueryReporter", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private string decodeConnection()
        {
            if (Program.TheEncryptedConnectionString != "")
            {
                return Decrypt(txtConnectionString.Text);
            }
            else
            {
                return txtConnectionString.Text;
            }
        }

        private void btnSelectTableSource_Click(object sender, EventArgs e)
        {
            //Check if the connection string is empty
            if (txtConnectionString.Text != String.Empty)
            {
                
                frmSelectTableSource frm = new frmSelectTableSource(decodeConnection());
                string fields = "";

                frm.ShowDialog();

                foreach (string s in frm.SelectedColumnNames)
                {
                    fields += s + "|";
                }

                if (fields != "")
                {
                    fields = fields.Substring(0, fields.Length - 1);
                }

                if (frm.SelectedTableName != "")
                {
                    TAIObjectCanvas2.CanvasObject ob = new TAIObjectCanvas2.CanvasObject(oc1, "DATASOURCE", frm.SelectedTableName, fields, 200, 150, Color.FromArgb(255, 128, 255, 128), Color.Black);

                    foreach (CanvasObject o in oc1.TheCanvasObjects)
                    {
                        if (o.Name == "DATASOURCE")
                        {
                            oc1.TheCanvasObjects.Remove(o);
                            break;
                        }
                    }

                    oc1.AddObject(ob);

                    GenerateSQLCode();
                }
            }
            else
            {
                MessageBox.Show("Please connect to a server before selecting the table source.",
                                "TAIQueryReporter", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //Menu Events

        private void currentQueryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCurrentQuery frm = new frmCurrentQuery(tais.Text);
            frm.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Exit the application
            Application.Exit();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        // FB 5433 5/17/2012 - ttheobald Move Open Query file to a subroutine so that it can be reused
        private void OpenQueryFile(string strFileName)
        {
            try
            {
                if (strFileName != null)
                {
                    StreamReader wText = new StreamReader(strFileName);
                    string ln = "";

                    // skip the first two lines
                    ln = wText.ReadLine();
                    ln = wText.ReadLine();

                    // read the connection string
                    txtConnectionString.Text = wText.ReadLine();

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

                    wText.Close();
                }

                GenerateSQLCode();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error loading " + strFileName + Environment.NewLine + Environment.NewLine + e.Message,
                    "TAIQueryReporter", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ofd.DefaultExt = "TAI Query Reporter Files|*.TQR";
            ofd.Title = "Open a saved TAI Query Reporter file";

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                btnClearCurrentQuery_Click(sender, e);
                OpenQueryFile(ofd.FileName);   // FB 5433 5/17/2012 - ttheobald Move Open Query file to a subroutine so that it can be reused
            }
        }


        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream;

            //sfd.DefaultExt = ".TQR";
            sfd.Title = "Select the name to save this query as....";

            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if ((myStream = sfd.OpenFile()) != null)
                {
                    System.IO.TextWriter wText = new StreamWriter(myStream);

                    // first save the header
                    wText.WriteLine("TAI Query Reporter Save File");
                    wText.WriteLine("Connection String");
                    wText.WriteLine(txtConnectionString.Text);
                    wText.WriteLine("Number Of Objects");
                    wText.WriteLine(oc1.TheCanvasObjects.Count.ToString());

                    foreach (CanvasObject o in oc1.TheCanvasObjects)
                    {
                        wText.WriteLine(o.Name);
                        wText.WriteLine(o.Location.ToString());
                        wText.WriteLine(o.MetaData.Trim());
                        wText.WriteLine(o.MetaData2.Trim());
                        wText.WriteLine(o.MetaData3.Trim());
                        wText.WriteLine(o.ObjectSize.ToString());
                        wText.WriteLine(o.BackColor.ToArgb().ToString());
                        wText.WriteLine(o.ForeColor.ToArgb().ToString());
                    }

                    wText.WriteLine("Number Of Connections");
                    wText.WriteLine(oc1.TheCanvasObjectConnections.Count.ToString());

                    foreach (CanvasObjectConnection o in oc1.TheCanvasObjectConnections)
                    {
                        wText.WriteLine(o.ConnectorColor.ToArgb().ToString());
                        wText.WriteLine(o.LineWeight.ToString());
                        wText.WriteLine(o.ConnectType.ToString());
                        wText.WriteLine(o.StartNodeName);
                        wText.WriteLine(o.EndNodeName);
                    }

                    wText.Flush();
                    wText.Close();
                    wText = null;
                }
            }
        }

        private void versionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout frm = new frmAbout();
            frm.ShowDialog();
        }

        //Canvas Object Events

        private void HandleHoverOverCanvas(object sender)
        {
            oc1.ContextMenu = null;

            ttip.Hide(oc1);
        }

        private void HandleHoverOverShape(object sender, TAIObjectCanvas2.CanvasObject shape)
        {
            oc1.ContextMenu = null;

            if (shape.Name == "DATASOURCE")
            {
                string TheFields = "";
                string[] flds = shape.MetaData2.Split("|".ToCharArray());
                string fline = "";

                foreach (string s in flds)
                {
                    fline += s + ",";

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

                string ttext = "DATASOURCE" + System.Environment.NewLine +
                                shape.MetaData + System.Environment.NewLine +
                                TheFields;

                ttip.Show(ttext, oc1);
            }

            if (shape.Name.StartsWith("LOOKUP"))
            {
                string ttext = "LOOKUP" + System.Environment.NewLine +
                                shape.MetaData;

                ttip.Show(ttext, oc1);
            }

            if (shape.Name.StartsWith("HCLOOKUP"))
            {
                string ttext = "HARD CODED LOOKUP" + System.Environment.NewLine +
                                shape.MetaData;

                ttip.Show(ttext, oc1);
            }

            if (shape.Name.StartsWith("CALC"))
            {
                string ttext = "CALCULATION" + System.Environment.NewLine +
                                shape.MetaData;

                ttip.Show(ttext, oc1);
            }

            if (shape.Name.StartsWith("FILTER"))
            {
                string ttext = "FILTER" + System.Environment.NewLine +
                                shape.MetaData;

                ttip.Show(ttext, oc1);
            }

            if (shape.Name.StartsWith("DISTINCT"))
            {
                string ttext = "DISTINCT" + System.Environment.NewLine +
                                shape.MetaData;

                ttip.Show(ttext, oc1);
            }

            if (shape.Name.StartsWith("SYNTH"))
            {
                string ttext = "SYNTHETIC FIELD" + System.Environment.NewLine +
                                shape.MetaData;

                ttip.Show(ttext, oc1);
            }

            if (shape.Name.StartsWith("ROLLUP"))
            {
                string ttext = "ROLLUP" + System.Environment.NewLine +
                                shape.MetaData;

                ttip.Show(ttext, oc1);
            }

            if (shape.Name.StartsWith("CONSTRAINT"))
            {
                string ttext = "CONSTRAINT" + System.Environment.NewLine +
                                shape.MetaData;

                ttip.Show(ttext, oc1);
            }

            if (shape.Name.StartsWith("LIMITER"))
            {
                string ttext = "LIMITER" + System.Environment.NewLine +
                                shape.MetaData;

                ttip.Show(ttext, oc1);
            }

            if (shape.Name.StartsWith("SORT"))
            {
                string ttext = "SORT" + System.Environment.NewLine +
                                shape.MetaData;

                ttip.Show(ttext, oc1);
            }
        }

        private void HandleShapeDoubleClicked(object sender, CanvasObject DoubleClickedObject)
        {
            if (DoubleClickedObject.Name == "DATASOURCE")
            {
                string tname = DoubleClickedObject.MetaData;
                string[] flds = DoubleClickedObject.MetaData2.Split("|".ToCharArray());
                List<string> lflds = new List<string>();

                foreach (string s in flds)
                {
                    lflds.Add(s);
                }

                frmSelectTableSource frm = new frmSelectTableSource(decodeConnection(), tname, lflds);
                frm.ShowDialog();

                if (frm.SelectedTableName != "")
                {
                    // reload the source
                    string fields = "";

                    foreach (string s in frm.SelectedColumnNames)
                    {
                        fields += s + "|";
                    }

                    if (fields != "")
                    {
                        fields = fields.Substring(0, fields.Length - 1);
                    }

                    TAIObjectCanvas2.CanvasObject ob = new TAIObjectCanvas2.CanvasObject(oc1, "DATASOURCE", frm.SelectedTableName, fields, 100, 100, Color.Green, Color.Black);

                    foreach (CanvasObject o in oc1.TheCanvasObjects)
                    {
                        if (o.Name == "DATASOURCE")
                        {
                            o.MetaData = ob.MetaData;
                            o.MetaData2 = ob.MetaData2;
                            o.MetaData3 = ob.MetaData3;
                        }
                    }

                    GenerateSQLCode();
                }
            }

            if (DoubleClickedObject.Name.StartsWith("LOOKUP"))
            {
                List<string> flds = getFieldsInBaseTable();

                AppendLookupFields(flds);

                frmAddEditLookup frm = new frmAddEditLookup(decodeConnection(), flds, DoubleClickedObject);
                frm.ShowDialog();

                if (frm.Fields.Count != 0 && frm.FieldName != "" && frm.TableName != "" && frm.JoinField != "")
                {
                    // we have selected a valid join
                    string Meta = "INDEXFIELD:" + frm.FieldName + System.Environment.NewLine;
                    string fields = "";

                    Meta += "INDEXTABLE:" + frm.TableName + System.Environment.NewLine;
                    Meta += "INDEXAGAINST:" + frm.JoinField + System.Environment.NewLine;
                    Meta += "INDEXRETURNS:";

                    foreach (string s in frm.Fields)
                    {
                        fields += s + ",";
                    }

                    // strip the last , off the thing

                    fields = fields.Substring(0, fields.Length - 1);

                    Meta += fields + System.Environment.NewLine;
                    Meta += "JOINTYPE:" + frm.JoinType;

                    DoubleClickedObject.MetaData = Meta;

                    GenerateSQLCode();
                }
            }

            if (DoubleClickedObject.Name.StartsWith("CALC"))
            {

                List<string> flds = getFieldsInBaseTableWithBaseTableName();

                AppendLookupFields(flds);

                frmAddEditCalculation frm = new frmAddEditCalculation(decodeConnection(), flds, DoubleClickedObject);
                frm.ShowDialog();

                if (frm.CalcClause != "" && frm.Dbase != "" && frm.SelectedFields.Count != 0)
                {
                    TAIObjectCanvas2.CanvasObject ob = DoubleClickedObject;

                    foreach (frmAddEditCalculation.CalculationItem ci in frm.SelectedFields)
                    {
                        ob.MetaData += ci.CalculationAlias + "|" + ci.CalculationType
                                    + "|" + ci.CalculationField + "|"
                                    + ci.CalculationTable + "|";
                    }

                    ob.MetaData2 = ob.MetaData.Substring(0, ob.MetaData.Length - 1);
                    ob.MetaData = frm.CalcClause;

                    GenerateSQLCode();
                }
            }

            if (DoubleClickedObject.Name.StartsWith("LIMITER"))
            {
                frmAddLimiter frm = new frmAddLimiter(DoubleClickedObject);
                frm.ShowDialog();

                if (frm.Clause != "")
                {
                    TAIObjectCanvas2.CanvasObject ob = DoubleClickedObject;

                    ob.MetaData = frm.Clause;
                    ob.MetaData2 = frm.Limiter;

                    GenerateSQLCode();
                }
            }

            if (DoubleClickedObject.Name.StartsWith("SYNTH"))
            {
                frmAddSyntheticFields frm = new frmAddSyntheticFields(decodeConnection(), GetListOfTableNames(), DoubleClickedObject);
                frm.ShowDialog();
                frmAddSyntheticFields.SyntheticItem si = frm.SelectedSynthItem;

                if (frm.Clause != "" && frm.Dbase != "" && si.ToString() != string.Empty)
                {
                    TAIObjectCanvas2.CanvasObject ob = DoubleClickedObject;

                    ob.MetaData = si.SyntheticAlias + "|" + si.SyntheticType + "|";

                    if (si.SyntheticFields.Count > 0)
                    {
                        for (int i = 0; i < si.SyntheticFields.Count; i++)
                        {
                            ob.MetaData += si.SyntheticFields[i] + ",";
                        }

                        //remove trailing comma
                        ob.MetaData = ob.MetaData.Substring(0, ob.MetaData.Length - 1);
                        ob.MetaData += "|";
                    }

                    if (si.SyntheticTables.Count > 0)
                    {
                        for (int i = 0; i < si.SyntheticTables.Count; i++)
                        {
                            ob.MetaData += si.SyntheticTables[i] + ",";
                        }

                        //remove trailing comma
                        ob.MetaData = ob.MetaData.Substring(0, ob.MetaData.Length - 1);
                        ob.MetaData += "|";
                    }

                    //remove trailing pipe
                    ob.MetaData = ob.MetaData.Substring(0, ob.MetaData.Length - 1);
                    ob.MetaData2 = frm.Clause;

                    GenerateSQLCode();
                }
            }

            if (DoubleClickedObject.Name.StartsWith("FILTER"))
            {
                frmAddFilter frm = new frmAddFilter(decodeConnection(), GetListOfTableNames(), DoubleClickedObject);
                frm.ShowDialog();

                if (frm.Clause != "")
                {
                    // here we should prompt to add to existing filter or add as an and
                    TAIObjectCanvas2.CanvasObject ob = DoubleClickedObject;
                    int cc = CountExistingFilter();
                    frmAddFilter.FilterItem FilteredItem = new frmAddFilter.FilterItem();
                    string meta = "";

                    FilteredItem = frm.Filter;

                    meta += FilteredItem.GridRowID.ToString() + "|" + FilteredItem.FilterType.ToString() + "|" + FilteredItem.FilterField + "|";

                    if (FilteredItem.FilterValues != null)
                    {
                        foreach (string s in FilteredItem.FilterValues)
                        {
                            meta += s + ",";
                        }

                        meta = meta.Substring(0, meta.Length - 1);
                    }
                    else
                    {
                        meta = meta.Substring(0, meta.Length - 1);
                    }

                    ob.MetaData = frm.Clause;
                    ob.MetaData2 = meta;

                    // here we have at least one filter already so we need to show the filter joiner
                    if (cc > 1)
                    {
                        List<CanvasObject> thefilts = new List<CanvasObject>();

                        foreach (CanvasObject o in oc1.TheCanvasObjects)
                        {
                            //Don't add the doubleclickedobject to the filter list
                            if (o.Name.StartsWith("FILTER_") && o.Name != ob.Name)
                            {
                                thefilts.Add(o);
                            }
                        }

                        if(thefilts.Count > 0)
                        {
                            frmFilterJoiner frm1 = new frmFilterJoiner(thefilts, frm.Clause);
                            frm1.ShowDialog();

                            if (frm1.TheConnectType != "")
                            {
                                if (frm1.TheConnectType == "AND")
                                {
                                    //remove the reference to another filter
                                    ob.MetaData3 = "";
                                }
                                else
                                {
                                    // we need to or it with something already there
                                    foreach (CanvasObject o in oc1.TheCanvasObjects)
                                    {
                                        if (o.Name == frm1.TheFilterToConnectWith.Name)
                                        {
                                            //Add link to another filter (this is to "OR" them together)
                                            ob.MetaData3 = o.Name;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    GenerateSQLCode();
                }
            }

            if (DoubleClickedObject.Name.StartsWith("CONSTRAINT"))
            {
                List<string> agg = new List<string>();

                foreach (CanvasObject o in oc1.TheCanvasObjects)
                {
                    if (o.Name.StartsWith("CALC") || o.Name.StartsWith("SYNTH"))
                    {
                        // we have a cal or an synth so lets get the field from its metadata
                        string m = o.MetaData;

                        //First, split on "," since calc can have multiple fields
                        string[] fields = m.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                        string[] spl = { "AS" };

                        for (int i = 0; i < fields.Length; i++)
                        {
                            string[] mm = fields[i].Split(spl, StringSplitOptions.RemoveEmptyEntries);
                            agg.Add(mm[0]);
                        }
                    }
                }

                frmAddConstraint frm = new frmAddConstraint(agg, DoubleClickedObject);
                frm.ShowDialog();

                if (frm.Clause != "")
                {
                    // lets add a synth clause
                    TAIObjectCanvas2.CanvasObject ob = DoubleClickedObject;
                    string meta = "";
                    frmAddConstraint.ConstraintItem ci = new frmAddConstraint.ConstraintItem();

                    ci = frm.Constraint;
                    meta += ci.ConstraintType + "|" + ci.ConstraintField + "|";

                    foreach (string item in ci.ConstraintValues)
                    {
                        meta += item + ",";
                    }

                    meta = meta.Substring(0, meta.Length - 1);
                    ob.MetaData = frm.Clause;
                    ob.MetaData2 = meta;

                    GenerateSQLCode();
                }
            }

            if (DoubleClickedObject.Name.StartsWith("ROLLUP"))
            {
                //Can only have one Rollup (group by). so call the add rollup click event
                btnAddRollup.PerformClick();
            }

            if (DoubleClickedObject.Name.StartsWith("SORT"))
            {
                frmAddSortOps frm = new frmAddSortOps(GetListOfSelectedFieldsAndLookupsAndCalcsAndSynths(), DoubleClickedObject);
                frm.ShowDialog();

                if (frm.Clause != "")
                {
                    // we can only have one so we will remove it and re-add it
                    foreach (CanvasObject o in oc1.TheCanvasObjects)
                    {
                        if (o.Name == "SORT")
                        {
                            oc1.RemoveObject("SORT");
                            break;
                        }
                    }

                    TAIObjectCanvas2.CanvasObject ob = new TAIObjectCanvas2.CanvasObject(oc1, "SORT", frm.Clause, 500, 200, Color.FromArgb(255, 255, 128, 255), Color.Black);

                    //get the meta info
                    string meta = "";
                    List<frmAddSortOps.SortItem> si = new List<frmAddSortOps.SortItem>();

                    si = frm.SortedItems;

                    if (si.Count > 0)
                    {
                        foreach (frmAddSortOps.SortItem s in si)
                        {
                            meta += s.SortField + "," + s.SortDirection + "|";
                        }
                    }

                    //remove remaining |
                    meta = meta.Substring(0, meta.Length - 1);

                    //Set the MetaData2 of the object
                    ob.MetaData2 = meta;

                    oc1.AddObject(ob);
                    oc1.AddConnection("SORT", "DATASOURCE", Color.Black, ConnectionType.DotArrow);

                    GenerateSQLCode();
                }
            }

            if (DoubleClickedObject.Name.StartsWith("HCLOOKUP"))
            {
                List<string> flds = getFieldsInBaseTable();

                AppendLookupFields(flds);

                frmAddEditLookup frm = new frmAddEditLookup(decodeConnection(), flds, true, DoubleClickedObject);
                frm.ShowDialog();

                if (frm.Fields.Count != 0 && frm.FieldName != "" && frm.TableName != "" && frm.JoinField != "")
                {
                    // we have selected a valid join
                    string Meta = "INDEXFIELD:" + frm.FieldName + System.Environment.NewLine;

                    Meta += "INDEXTABLE:" + frm.TableName + System.Environment.NewLine;
                    Meta += "INDEXAGAINST:" + frm.JoinField + System.Environment.NewLine;
                    Meta += "INDEXRETURNS:";

                    string fields = "";

                    foreach (string s in frm.Fields)
                    {
                        fields += s + ",";
                    }

                    // strip the last , off the thing
                    fields = fields.Substring(0, fields.Length - 1);

                    Meta += fields + System.Environment.NewLine;
                    Meta += "JOINTYPE:" + frm.JoinType;

                    DoubleClickedObject.MetaData = Meta;

                    GenerateSQLCode();
                }
            }
        }

        //Canvas Menu Events

        private void deleteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            CanvasObject o = oc1.ObjectUnderMouse;
            string oName = o.Name;

            if (o.Name == "DATASOURCE")
            {
                btnClearCurrentQuery_Click(sender, e);
            }

            if (o.Name.StartsWith("CALC") || o.Name.StartsWith("SYNTH") ||
                o.Name.StartsWith("ROLLU") || o.Name.StartsWith("LOOKUP") ||
                o.Name.StartsWith("FILTER") || o.Name.StartsWith("CONSTRAINT") ||
                o.Name.StartsWith("SORT") || o.Name.StartsWith("LIMITER") || o.Name.StartsWith("HCLOOKUP") || o.Name.StartsWith("DISTINCT"))
            {
                oc1.RemoveObject(o.Name);
            }

            //If filter, remove any metadata3 (if any) references from the remaining filter items
            if (o.Name.StartsWith("FILTER"))
            {
                foreach (CanvasObject ob in oc1.TheCanvasObjects)
                {
                    if (ob.Name.StartsWith("FILTER"))
                    {
                        if (ob.MetaData3 == o.Name)
                        {
                            ob.MetaData3 = string.Empty;
                        }
                    }
                }
            }

            GenerateSQLCode();
        }

        private void editToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            objbeingedited = oc1.ObjectUnderMouse;

            HandleShapeDoubleClicked(sender, objbeingedited);
        }

        #endregion

        #region " Methods"

        private void AppendLookupFields(List<string> flds)
        {
            int lkup = 0;

            foreach (CanvasObject ob in oc1.TheCanvasObjects)
            {
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
                        string[] rff = rf[1].Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                        for (int i = 0; i <= rff.GetUpperBound(0); i++)
                        {
                            string fline = lt + "." + rff[i];

                            flds.Add(fline);
                        }
                    }
                }
            }
        }

        private int CountExistingCalcs()
        {
            int ret = 0;

            foreach (CanvasObject ob in oc1.TheCanvasObjects)
            {
                if (ob.Name.StartsWith("CALC"))
                {
                    string[] arr = ob.Name.Split("_".ToCharArray());

                    int num = int.Parse(arr[1]);

                    if (num > ret)
                    {
                        ret = num;
                    }
                }
            }

            ret += 1;

            return ret;
        }

        private int CountExistingConstraints()
        {
            int ret = 0;

            foreach (CanvasObject ob in oc1.TheCanvasObjects)
            {
                if (ob.Name.StartsWith("CONSTRAINT"))
                {
                    string[] arr = ob.Name.Split("_".ToCharArray());

                    int num = int.Parse(arr[1]);

                    if (num > ret)
                    {
                        ret = num;
                    }
                }
            }

            ret += 1;

            return ret;
        }

        private int CountExistingDistinct()
        {
            int ret = 0;

            foreach (CanvasObject ob in oc1.TheCanvasObjects)
            {
                if (ob.Name.StartsWith("DISTINCT"))
                {
                    ret += 1;
                    break;
                }
            }

            return ret;
        }

        private int CountExistingFilter()
        {
            int ret = 0;

            foreach (CanvasObject ob in oc1.TheCanvasObjects)
            {
                if (ob.Name.StartsWith("FILTER"))
                {
                    string[] arr = ob.Name.Split("_".ToCharArray());
                    int num = int.Parse(arr[1]);

                    if (num > ret)
                    {
                        ret = num;
                    }
                }
            }

            ret += 1;

            return ret;
        }

        private int CountExistingHCLookups()
        {
            int ret = 0;

            foreach (CanvasObject ob in oc1.TheCanvasObjects)
            {
                if (ob.Name.StartsWith("HCLOOKUP"))
                {
                    string[] arr = ob.Name.Split("_".ToCharArray());
                    int num = int.Parse(arr[1]);

                    if (num > ret)
                    {
                        ret = num;
                    }
                }
            }

            ret += 1;

            return ret;
        }

        private int CountExistingLookups()
        {
            int ret = 0;

            foreach (CanvasObject ob in oc1.TheCanvasObjects)
            {
                if (ob.Name.StartsWith("LOOKUP"))
                {
                    string[] arr = ob.Name.Split("_".ToCharArray());
                    int num = int.Parse(arr[1]);

                    if (num > ret)
                    {
                        ret = num;
                    }
                }
            }

            ret += 1;

            return ret;
        }

        private int CountExistingRollup()
        {
            int ret = 0;

            foreach (CanvasObject ob in oc1.TheCanvasObjects)
            {
                if (ob.Name.StartsWith("ROLLUP"))
                {
                    ret += 1;
                    break;
                }
            }

            return ret;
        }

        private int CountExistingSynth()
        {
            int ret = 0;

            foreach (CanvasObject ob in oc1.TheCanvasObjects)
            {
                if (ob.Name.StartsWith("SYNTH"))
                {
                    string[] arr = ob.Name.Split("_".ToCharArray());
                    int num = int.Parse(arr[1]);

                    if (num > ret)
                    {
                        ret = num;
                    }
                }
            }

            ret += 1;

            return ret;
        }

        private void GenerateSQLCode()
        {
            string sql = "";
            string PrePrequil = "SELECT ";
            string Prequil = "";
            string TheLookups = "";
            string TheFields = "";
            string TheCalcs = "";
            string TheWhere = "";
            string TheSynths = "";
            string JustSynths = "";
            string JustHavings = "";
            string FromTBL = "";
            string GroupClause = "";
            //string HCGroup = "";
            string LimiterClause = "";
            string OrderClause = "";
            string JustFields = ""; 
            int lkup = 0;
            List<CanvasObject> filterObjects = new List<CanvasObject>();

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
                            string fline = lt + "." + rff[i] + " AS '" + idxf[1] + "_" + rff[i].Replace("[","").Replace("]","") + "'";

                            JustFields += "," + lt + "." + rff[i];

                            if (i < rff.GetUpperBound(0))
                            {
                                fline += "," + System.Environment.NewLine;
                            }

                            if (i == 0)
                            {
                                TheFields += "," + System.Environment.NewLine + fline;
                            }
                            else
                            {
                                TheFields += fline;
                            }
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

                        //string look = jt[1] + " " + jtbl[1] + " AS " + lt + " ON ";

                        //// if we are looking up against a lookup already we need to not prepend the base table name
                        //if (idxf[1].Split(".".ToCharArray()).GetUpperBound(0) == 0)
                        //    look += GetBaseQueryTableName() + "." + idxf[1] + "=" + lt + "." + jf[1] + System.Environment.NewLine;
                        //else
                        //    look += idxf[1] + "=" + lt + "." + jf[1] + System.Environment.NewLine;

                        //TheLookups += look;

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
                            {
                                fline += "," + System.Environment.NewLine;
                            }

                            if (i == 0)
                            {
                                TheFields += "," + System.Environment.NewLine + fline;
                            }
                            else
                            {
                                TheFields += fline;
                            }
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
                    filterObjects.Add(ob);
                }

                if (ob.Name.StartsWith("DISTINCT"))
                {
                    PrePrequil += " DISTINCT ";
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

            TheWhere = generateWhereClause(filterObjects);

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

            string[] q = sql.Split(System.Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            string newQuery = "";

            for (int i = 0; i < q.Length; i++)
            {
                newQuery += q[i] + System.Environment.NewLine;
            }
            tais.Text = newQuery;

            //tais.Text = sql.Trim();
        }

        //Generate the where clause of the sql query
        private string generateWhereClause(List<CanvasObject> filterObjects)
        {
            List<List<CanvasObject>> filters = new List<List<CanvasObject>>();
            List<List<CanvasObject>> copyFilters = new List<List<CanvasObject>>();
            List<CanvasObject> CopyFilterObjects = new List<CanvasObject>();
            string TheWhere = "";

            try
            {
                //Get a copy of the original filter objects & store into a new list             
                foreach (CanvasObject c in filterObjects)
                {
                    CopyFilterObjects.Add(c);
                }

                //Get all objects that are not linked to another object
                if (filterObjects.Count > 0)
                {
                    //For each object, if the MetaData3 property is blank, add the object to filterList and then remove it from out copy of the filter objects
                    foreach (CanvasObject c in filterObjects)
                    {
                        if (c.MetaData3 == string.Empty)
                        {
                            List<CanvasObject> filterList = new List<CanvasObject>();
                            filterList.Add(c);
                            filters.Add(filterList);
                            CopyFilterObjects.Remove(c);
                        }
                    }
                }

                //int count = filterObjects.Count;
                int t = CopyFilterObjects.Count;

                //Copy all of the data in filters into copyFilters
                foreach (List<CanvasObject> co in filters)
                {
                    copyFilters.Add(co);
                }

                //While copyFilterObjects still contains items
                while (t > 0)
                {
                    //Get the first item in the list
                    CanvasObject co = CopyFilterObjects[0];

                    //Iterate through each List<CanvasObject> in copyFilters
                    foreach (List<CanvasObject> item in copyFilters)
                    {
                        //Iterate though the list of canvas objects
                        foreach (CanvasObject o in item)
                        {
                            //If the object's name matches co's metadata3, co will be ORed with the object
                            if (co.MetaData3 == o.Name)
                            {
                                filters[copyFilters.IndexOf(item)].Add(co);
                                CopyFilterObjects.Remove(co);
                                t = CopyFilterObjects.Count;
                                break;
                            }
                        }
                    }
                }

                //Iterate through the list & build the clause
                foreach (List<CanvasObject> item in filters)
                {
                    TheWhere += "( ";
                    foreach (CanvasObject o in item)
                    {
                        TheWhere += o.MetaData + " OR ";
                    }
                    if (TheWhere.EndsWith(" OR "))
                    {
                        TheWhere = TheWhere.Substring(0, TheWhere.Length - 4);
                    }
                    TheWhere += ") AND ";
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

                return TheWhere;
            }
            catch (Exception ex)
            {
                //Display an error message & return an empty string
                MessageBox.Show("An error has occurred while generating the SQL query: " + System.Environment.NewLine
                    + ex.Message, "TAI Query Reporter", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return string.Empty;
            }
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

        private List<string> getFieldsInBaseTable()
        {
            List<string> flds = new List<string>();

            string sql = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '"
                        + GetBaseQueryTableName() + "' ORDER BY ORDINAL_POSITION";

            SqlConnection cn = new SqlConnection(decodeConnection());
            cn.Open();

            SqlCommand cmd = new SqlCommand(sql, cn);
            SqlDataReader r = cmd.ExecuteReader();

            while (r.Read())
            {
                flds.Add(r["COLUMN_NAME"] + "");
            }

            r.Close();
            cmd.Dispose();
            cn.Close();
            cn.Dispose();

            return flds;
        }

        private List<string> getFieldsInBaseTableWithBaseTableName()
        {
            List<string> flds = new List<string>();

            string tname = GetBaseQueryTableName();
            string sql = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '"
                + tname + "' ORDER BY ORDINAL_POSITION";

            SqlConnection cn = new SqlConnection(decodeConnection());
            cn.Open();

            SqlCommand cmd = new SqlCommand(sql, cn);
            SqlDataReader r = cmd.ExecuteReader();

            while (r.Read())
            {
                flds.Add(tname + "." + r["COLUMN_NAME"] + "");
            }

            r.Close();
            cmd.Dispose();
            cn.Close();
            cn.Dispose();

            return flds;
        }

        private List<string> GetListOfSelectedFieldsAndLookupsAndCalcsAndSynths()
        {
            List<string> ret = new List<string>();
            int lkup = 0;
            string[] split = new string[1] { " AS " };

            foreach (CanvasObject ob in oc1.TheCanvasObjects)
            {
                if (ob.Name == "DATASOURCE")
                {
                    // lets enumerate the base fields with the tablename being employed

                    string tname = ob.MetaData;
                    string[] flds = ob.MetaData2.Split("|".ToCharArray());

                    foreach (string s in flds)
                    {
                        ret.Add(ob.MetaData + "." + s + "");
                    }
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
                        {
                            look += GetBaseQueryTableName() + "." + idxf[1] + "=" + lt + "." + jf[1] + System.Environment.NewLine;
                        }
                        else
                        {
                            look += idxf[1] + "=" + lt + "." + jf[1] + System.Environment.NewLine;
                        }

                        string[] rff = rf[1].Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                        for (int i = 0; i <= rff.GetUpperBound(0); i++)
                        {
                            string fline = lt + "." + rff[i];
                            ret.Add(fline);
                        }
                    }
                }

                if (ob.Name.StartsWith("CALC"))
                {
                    string[] s = ob.MetaData.Split(split, StringSplitOptions.RemoveEmptyEntries);

                    ret.Add(s[0]);
                }

                if (ob.Name.StartsWith("SYNTH"))
                {
                    string[] s = ob.MetaData.Split(split, StringSplitOptions.RemoveEmptyEntries);

                    ret.Add(s[0]);
                }
            }

            return ret;
        }

        private List<string> GetListOfTableNames()
        {
            List<string> ret = new List<string>();

            ret.Add(GetBaseQueryTableName());

            foreach (CanvasObject o in oc1.TheCanvasObjects)
            {
                if (o.Name.StartsWith("LOOKUP_"))
                {
                    // we have a lookup so lets figure out what LTX it is and get it in the mix
                    string[] ar = o.Name.Split("_".ToCharArray());

                    // ar[1] will contain the lookup number
                    int lkupnum = int.Parse(ar[1]) - 1;
                    string lkup = "LT" + lkupnum.ToString();

                    // lets figure out what the base table for this lookup is

                    ar = o.MetaData.Split(System.Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                    string basetblname = "";

                    foreach (string meta in ar)
                    {
                        if (meta.StartsWith("INDEXTABLE:"))
                        {
                            // here we can decode the base table from the lookup 

                            basetblname = meta.Substring(11);
                            break;
                        }
                    }

                    ret.Add(lkup + ":" + basetblname);
                }
            }

            return ret;
        }

        private void HideStartup()
        {
            _sFrm.Close();
        }

        private void ReadIni()
        {
            StreamReader myStream;

            if ((myStream = File.OpenText("QUERYREPORTER.INI")) != null)
            {
                string ln = "";

                while (myStream.Peek() != -1)
                {
                    ln = myStream.ReadLine();

                    if (ln.ToUpper().StartsWith("ENUMERATE="))
                    {
                        if (ln.ToUpper().Substring(10) == "YES")
                            Enumerate = true;
                    }

                    if (ln.ToUpper().StartsWith("SERVER="))
                    {
                        PreSetServerInstances.Add(ln.Substring(7));
                    }

                    if (ln.ToUpper().StartsWith("ENCRYPTEDSERVER="))
                    {
                        // We have an encrypted server entry lets defauklt to that one

                        var TheEString = ln.Substring(23);

                        Program.TheEncryptedConnectionString = TheEString;

                        EncryptedServers.Add(Decrypt(TheEString));
                        txtConnectionString.Text = TheEString;

                        // we have an encrypted SERVER connection setting
                        // Deactivate the selection of a server

                        BtnConnect2AServer.Enabled = false;

                    }
                }
            }

            myStream.Close();
            myStream.Dispose();
        }

        private void ShowStartup()
        {
            _sFrm.Show();
            _sFrm.Refresh();
            Application.DoEvents();
        }

        #endregion

        private void HandletBarScroll(object sender, EventArgs e)
        {
            int v = tbarFontSize.Value;

            Font f = new Font("Courier New", v);

            tais.CodeFont = f;
        }

        public static string encrypt(string encryptString)
        {
            string EncryptionKey = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            byte[] clearBytes = Encoding.Unicode.GetBytes(encryptString);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] {
            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
        });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    encryptString = Convert.ToBase64String(ms.ToArray());
                }
            }
            return encryptString;
        }

        public static string Decrypt(string cipherText)
        {
            string EncryptionKey = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] {
            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
        });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }

    }
}
