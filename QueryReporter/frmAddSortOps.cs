using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace TAIQueryReporter
{
    public partial class frmAddSortOps : Form
    {

        List<string> TheFields = new List<string>();
        List<string> TheSorts = new List<string>();

        public string Clause = "";
        public List<SortItem> SortedItems = new List<SortItem>();

        #region " Struct"

        public struct SortItem
        {
            private string sField;
            private string sDirection;

            public SortItem(string field, string direction)
            {
                this.sField = field;
                this.sDirection = direction;
            }

            public string SortField
            {
                get
                {
                    return this.sField;
                }
                set
                {
                    this.sField = value;
                }
            }

            public string SortDirection
            {
                get
                {
                    return this.sDirection;
                }
                set
                {
                    this.sDirection = value;
                }
            }
        }

        #endregion

        #region " Constructors"

        public frmAddSortOps(List<string> flds)
        {
            InitializeComponent();

            taig.Cols = 3;
            taig.Rows = 0;
            taig.set_HeaderLabel(0, "FIELD");
            taig.set_HeaderLabel(1, "SORT");
            taig.set_HeaderLabel(2, "DIRECTION");

            foreach (string s in flds)
            {
                taig.Rows += 1;
                taig.set_item(taig.Rows - 1, 0, s);
                taig.set_item(taig.Rows - 1, 1, "NO");
            }

            taig.AutoSizeCellsToContents = true;
            taig.Refresh();

            TheFields = flds;
        }

        public frmAddSortOps(List<string> flds, TAIObjectCanvas2.CanvasObject obj)
        {
            InitializeComponent();

            taig.Cols = 3;
            taig.Rows = 0;
            taig.set_HeaderLabel(0, "FIELD");
            taig.set_HeaderLabel(1, "SORT");
            taig.set_HeaderLabel(2, "DIRECTION");

            foreach (string s in flds)
            {
                taig.Rows += 1;
                taig.set_item(taig.Rows - 1, 0, s);
                taig.set_item(taig.Rows - 1, 1, "NO");
            }

            taig.AutoSizeCellsToContents = true;
            taig.Refresh();

            TheFields = flds;

            if (obj.MetaData2 != string.Empty)
            {
                //Each sorted field is separated by a |
                string[] meta = obj.MetaData2.Split('|');
                populateData(meta);
                GenerateClause();
            }
            else
            {
                showError("Unable to load object data");
            }

        }

        #endregion

        #region " Events"

        private void btnAccept_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clause = "";
            this.Hide();
        }

        private void HandleCellDoubleClicked(object sender, int RowClicked, int ColumnClicked)
        {
            try
            {
                if (ColumnClicked == 1)
                {
                    string s = taig.get_item(RowClicked, 1);
                    string ss = taig.get_item(RowClicked, 2);
                    string f = taig.get_item(RowClicked, 0);

                    if (s == "NO")
                    {
                        s = "YES";
                        ss = "ASC";
                    }
                    else
                    {
                        s = "NO";
                        ss = "";
                    }

                    taig.set_item(RowClicked, 1, s);
                    taig.set_item(RowClicked, 2, ss);

                    if (s == "YES")
                    {
                        TheSorts.Remove(f);
                        TheSorts.Add(f);
                    }
                    else
                    {
                        TheSorts.Remove(f);
                    }

                    GenerateClause();
                }

                if (ColumnClicked == 2)
                {
                    string s = taig.get_item(RowClicked, 1);
                    string ss = taig.get_item(RowClicked, 2);
                    string f = taig.get_item(RowClicked, 0);

                    if (ss == "ASC")
                    {
                        ss = "DESC";
                    }
                    else
                    {
                        if (ss == "DESC")
                        {
                            ss = "ASC";
                        }
                    }
                    taig.set_item(RowClicked, 1, s);
                    taig.set_item(RowClicked, 2, ss);

                    GenerateClause();
                }
            }
            catch (Exception ex)
            {
                showError("An error has occurred" + System.Environment.NewLine
                                + ex.Message);
            }
        }

        #endregion

        #region " Methods"

        //Generated the query clause
        private void GenerateClause()
        {
            try
            {
                string cl = "";

                //Clear all existing items, they will be regenerated
                SortedItems.Clear();

                foreach (string s in TheSorts)
                {
                    for (int i = 0; i < taig.Rows; i++)
                    {
                        if (taig.get_item(i, 0) == s)
                        {
                            cl += s + " " + taig.get_item(i, 2) + ",";
                            SortItem si = new SortItem(s, taig.get_item(i, 2));
                            SortedItems.Add(si);
                            break;
                        }
                    }
                }

                if (cl != "")
                {
                    cl = "ORDER BY " + cl.Substring(0, cl.Length - 1);
                }

                txtClause.Text = cl;
                Clause = cl;
            }
            catch (Exception ex)
            {
                showError("Unable to generate the query clause" + System.Environment.NewLine
                                + ex.Message);
            }
        }

        //populates an existing sort item's data
        private void populateData(string[] meta)
        {
            try
            {
                ArrayList rowIDs = new ArrayList();

                //populate SortedItems list
                for (int i = 0; i < meta.Length; i++)
                {
                    string[] sortedField = meta[i].Split(',');
                    SortItem si = new SortItem(sortedField[0], sortedField[1]);
                    SortedItems.Add(si);
                }

                foreach (SortItem s in SortedItems)
                {
                    //select the row in the grid & set the sort properties
                    int rowID = taig.FindInColumn(s.SortField, taig.GetColumnIDByName("FIELD"), false);

                    if (rowID != -1)
                    {
                        taig.set_item(rowID, taig.GetColumnIDByName("SORT"), "YES");
                        taig.set_item(rowID, taig.GetColumnIDByName("DIRECTION"), s.SortDirection);
                        rowIDs.Add(rowID);
                        TheSorts.Add(s.SortField);
                    }
                }

                //highlight all selected fields
                taig.SelectRows(rowIDs);
            }
            catch (Exception ex)
            {
                showError("Unable to load the sort item's data" + System.Environment.NewLine
                                + ex.Message);
            }
        }

        //Display an error message to the user
        private void showError(string errorMessage)
        {
            MessageBox.Show(errorMessage, "TAI Query Reporter", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        #endregion

    }
}
