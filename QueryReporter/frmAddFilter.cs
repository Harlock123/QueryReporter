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
    public partial class frmAddFilter : Form
    {
        
        private string Dbase = "";
        private List<string> tnames = new List<string>();
        public string Clause = "";
        private bool Semaphore = false;
        public FilterItem Filter = new FilterItem();

        #region " Structs"

        public struct FilterItem
        {
            private FilterTypes fiType;
            private List<string> fiValue;
            private string fiField;
            private int rowID;

            public enum FilterTypes
            {
                EqualDate,
                NotEqualDate,
                GreaterThanDate,
                LessThanDate,
                BetweenDates,
                EqualNumber,
                NotEqualNumber,
                GreaterThanNumber,
                LessThanNumber,
                BetweenNumbers,
                EqualAlphaNumeric,
                NotEqualAlphaNumeric,
                StartsWithAlphaNumeric,
                EndsWithAlphaNumeric,
                ContainsAlphaNumeric,
                AllowNull,
                NotNull,
                None
            }

            public FilterItem(FilterTypes type, List<string> values, string field, int row)
            {
                this.fiType = type;
                this.fiValue = values;
                this.fiField = field;
                this.rowID = row;
            }

            public FilterTypes FilterType
            {
                get
                {
                    return this.fiType;
                }
                set
                {
                    this.fiType = value;
                }
            }

            public List<string> FilterValues
            {
                get
                {
                    return this.fiValue;
                }
                set
                {
                    this.fiValue = value;
                }
            }

            public string FilterField
            {
                get
                {
                    return this.fiField;
                }
                set
                {
                    this.fiField = value;
                }
            }

            public int GridRowID
            {
                get
                {
                    return this.rowID;
                }
                set
                {
                    this.rowID = value;
                }
            }
        }

        #endregion

        #region " Constructors"

        public frmAddFilter(string Connection, List<string> TableNames)
        {
            InitializeComponent();

            Dbase = Connection;
            tnames = TableNames;

            taig.PopulateGridWithData(Dbase, GenerateSelectionClause());
        }

        public frmAddFilter(string Connection, List<string> TableNames, TAIObjectCanvas2.CanvasObject obj)
        {
            InitializeComponent();

            Dbase = Connection;
            tnames = TableNames;

            taig.PopulateGridWithData(Dbase, GenerateSelectionClause());

            if (obj.MetaData2 != string.Empty)
            {
                string[] fields = obj.MetaData2.Split('|');
                FilterItem fi = new FilterItem();
                List<string> values = new List<string>();
                fi.GridRowID = int.Parse(fields[0].ToString());
                fi.FilterType = getFilterTypeFromString(fields[1]);
                fi.FilterField = fields[2];
                if (fi.FilterType != FilterItem.FilterTypes.None && fi.FilterType != FilterItem.FilterTypes.AllowNull && fi.FilterType != FilterItem.FilterTypes.NotNull)
                {
                    string[] fieldvalues = fields[3].Split(',');
                    foreach (string v in fieldvalues)
                    {
                        values.Add(v);
                    }
                    fi.FilterValues = values;
                }

                populateData(fi);
                Filter = fi;
                GenerateClauseFromObject();
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
            Clause = txtClause.Text;
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clause = "";
            this.Hide();
        }

        private void btnDateFilterSet_Click(object sender, EventArgs e)
        {
            if (taig.SelectedRow == -1)
            {
                MessageBox.Show("You have to select something to filter on first...");
            }
            else
            {
                string field = taig.get_item(taig.SelectedRow, "COLUMN");
                frmSetBuilder frm = new frmSetBuilder("DATE", field);

                frm.ShowDialog();

                if (frm.Clause != "")
                {
                    Clause = frm.Clause;
                    txtClause.Text = Clause;
                }
            }
        }

        private void btnFieldBrowse_Click(object sender, EventArgs e)
        {
            if (taig.SelectedRow != -1)
            {
                string tname = taig.get_item(taig.SelectedRow, "TNAME");
                frmFieldBrowser frm = new frmFieldBrowser(Dbase, tname);

                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("You have to select a field to browse the table containing that field...");
            }
        }

        private void btnNumberFilterSet_Click(object sender, EventArgs e)
        {
            if (taig.SelectedRow == -1)
            {
                MessageBox.Show("You have to select something to filter on first...");
            }
            else
            {
                string field = taig.get_item(taig.SelectedRow, "COLUMN");

                frmSetBuilder frm = new frmSetBuilder("NUM", field);

                frm.ShowDialog();
                if (frm.Clause != "")
                {
                    Clause = frm.Clause;
                    txtClause.Text = Clause;
                }
            }
        }

        private void btnStringFilterSet_Click(object sender, EventArgs e)
        {
            if (taig.SelectedRow == -1)
            {
                MessageBox.Show("You have to select something to filter on first...");
            }
            else
            {
                string field = taig.get_item(taig.SelectedRow, "COLUMN");

                frmSetBuilder frm = new frmSetBuilder("STRING", field);

                frm.ShowDialog();
                if (frm.Clause != "")
                {
                    Clause = frm.Clause;
                    txtClause.Text = Clause;
                }
            }
        }

        private void HandleDatesNullNoNullCheckChanged(object sender, EventArgs e)
        {
            if (!Semaphore)
            {
                Semaphore = !Semaphore;

                foreach (object o in tpDates.Controls)
                {
                    if (o.GetType().ToString().ToUpper() == "SYSTEM.WINDOWS.FORMS.MASKEDTEXTBOX")
                    {
                        System.Windows.Forms.MaskedTextBox t = (System.Windows.Forms.MaskedTextBox)o;
                        t.Text = "";
                    }
                }

                Semaphore = !Semaphore;

                GenerateClause();
            }
        }

        private void HandleDateTextChanged(object sender, EventArgs e)
        {
            // clear the other text boxes
            if (!Semaphore)
            {
                Semaphore = !Semaphore;

                rbDateIsNotNull.Checked = false;
                rbDateIsNull.Checked = false;

                foreach (object o in tpDates.Controls)
                {
                    if (o.GetType().ToString().ToUpper() == "SYSTEM.WINDOWS.FORMS.MASKEDTEXTBOX")
                    {
                        if (o != sender)
                        {
                            System.Windows.Forms.MaskedTextBox ss = (System.Windows.Forms.MaskedTextBox)sender;
                            System.Windows.Forms.MaskedTextBox t = (System.Windows.Forms.MaskedTextBox)o;

                            if (ss.Name == "txtBetweenLower" || ss.Name == "txtBetweenUpper")
                            {
                                if (t.Name != "txtBetweenLower" && t.Name != "txtBetweenUpper")
                                {
                                    t.Text = "";
                                }
                            }
                            else
                            {
                                t.Text = "";
                            }
                        }
                    }
                }
            }

            Semaphore = !Semaphore;

            GenerateClause();
        }

        private void HandleNumbersNullNoNullCheckChanged(object sender, EventArgs e)
        {
            if (!Semaphore)
            {
                Semaphore = !Semaphore;

                foreach (object o in tpNumbers.Controls)
                {
                    if (o.GetType().ToString().ToUpper() == "SYSTEM.WINDOWS.FORMS.TEXTBOX")
                    {
                        System.Windows.Forms.TextBox t = (System.Windows.Forms.TextBox)o;
                        t.Text = "";
                    }
                }
                Semaphore = !Semaphore;

                GenerateClause();
            }
        }

        private void HandleNumericKeyPress(object sender, KeyPressEventArgs e)
        {
            string c = e.KeyChar.ToString();

            if (c == "0" || c == "1" || c == "2" || c == "3" || c == "4" || c == "5" || c == "6" || c == "7" || c == "8" || c == "9" || c == "." || c == "\b")
            {
                e.Handled = false;
            }
            else
            {


                e.Handled = true;
            }
        }

        private void HandleRowSelected(object sender, int RowSelected)
        {
            string isn = taig.get_item(RowSelected, "NUM");
            string isd = taig.get_item(RowSelected, "DATE");
            string isa = taig.get_item(RowSelected, "ALPHA");

            if (isd == "YES")
            {
                theTabs.SelectedIndex = 0;
            }
            else
            {
                if (isn == "YES")
                {
                    theTabs.SelectedIndex = 1;
                }
                else
                {
                    theTabs.SelectedIndex = 2;
                }
            }
        }

        private void HandleStringNullNoNullCheckChanged(object sender, EventArgs e)
        {
            if (!Semaphore)
            {
                Semaphore = !Semaphore;

                foreach (object o in tpStrings.Controls)
                {
                    if (o.GetType().ToString().ToUpper() == "SYSTEM.WINDOWS.FORMS.TEXTBOX")
                    {
                        System.Windows.Forms.TextBox t = (System.Windows.Forms.TextBox)o;
                        t.Text = "";
                    }
                }
                Semaphore = !Semaphore;

                GenerateClause();
            }
        }

        private void HandleStringTextChanges(object sender, EventArgs e)
        {
            // clear the other text boxes
            if (!Semaphore)
            {
                Semaphore = !Semaphore;

                rbStringIsNull.Checked = false;
                rbStringIsNotNull.Checked = false;

                foreach (object o in tpStrings.Controls)
                {
                    if (o.GetType().ToString().ToUpper() == "SYSTEM.WINDOWS.FORMS.TEXTBOX")
                    {
                        if (o != sender)
                        {
                            System.Windows.Forms.TextBox t = (System.Windows.Forms.TextBox)o;
                            t.Text = "";
                        }
                    }
                }

                Semaphore = !Semaphore;

                GenerateClause();
            }
        }

        private void HandleTextChangedInNumbers(object sender, EventArgs e)
        {
            // clear the other text boxes
            if (!Semaphore)
            {
                Semaphore = !Semaphore;

                rbNumberIsNotNull.Checked = false;
                rbNumberIsNull.Checked = false;

                foreach (object o in tpNumbers.Controls)
                {
                    if (o.GetType().ToString().ToUpper() == "SYSTEM.WINDOWS.FORMS.TEXTBOX")
                    {
                        if (o != sender)
                        {

                            System.Windows.Forms.TextBox ss = (System.Windows.Forms.TextBox)sender;
                            System.Windows.Forms.TextBox t = (System.Windows.Forms.TextBox)o;

                            if (ss.Name == "txtNumBetweenLower" || ss.Name == "txtNumBetweenUpper")
                            {
                                if (t.Name != "txtNumBetweenLower" && t.Name != "txtNumBetweenUpper")
                                {
                                    t.Text = "";
                                }

                            }
                            else
                            {
                                t.Text = "";
                            }
                        }
                    }
                }
                Semaphore = !Semaphore;

                GenerateClause();
            }
        }

        #endregion

        #region " Methods"

        private void GenerateClause()
        {
            try
            {
                FilterItem fi = new FilterItem();
                List<string> filterValues = new List<string>();
                string sql = "";

                if (taig.SelectedRow != -1)
                {
                    string isn = taig.get_item(taig.SelectedRow, "NUM");
                    string isd = taig.get_item(taig.SelectedRow, "DATE");
                    string isa = taig.get_item(taig.SelectedRow, "ALPHA");
                    string it = taig.get_item(taig.SelectedRow, "COLUMN");

                    string[] itt = it.Split(".".ToCharArray());

                    foreach (string ittt in itt)
                    {

                        string itttt = Program.BraketizeKeywords(ittt);

                        if (fi.FilterField + "" != "")
                        {
                            fi.FilterField += "." + itttt;
                        }
                        else
                        {
                            fi.FilterField += itttt;
                        }
                    }

                    
                    fi.GridRowID = taig.SelectedRow;

                    sql = fi.FilterField + " ";

                    if (isd == "YES")
                    {
                        //theTabs.SelectedIndex = 0;

                        //sql = taig.get_item(taig.SelectedRow, "COLUMN") + " ";

                        if (rbDateIsNotNull.Checked)
                        {
                            sql += "IS NOT NULL";
                            fi.FilterType = FilterItem.FilterTypes.NotNull;
                        }

                        if (rbDateIsNull.Checked)
                        {
                            sql += "IS NULL";
                            fi.FilterType = FilterItem.FilterTypes.AllowNull;
                        }

                        if (txtEqual.Text != "  /  /")
                        {
                            sql += "= '" + txtEqual.Text + "'";
                            fi.FilterType = FilterItem.FilterTypes.EqualDate;
                            filterValues.Add(txtEqual.Text);
                            fi.FilterValues = filterValues;
                        }

                        if (txtNotEqual.Text != "  /  /")
                        {
                            sql += "<> '" + txtNotEqual.Text + "'";
                            fi.FilterType = FilterItem.FilterTypes.NotEqualDate;
                            filterValues.Add(txtNotEqual.Text);
                            fi.FilterValues = filterValues;
                        }

                        if (txtGreaterThan.Text != "  /  /")
                        {
                            sql += "> '" + txtGreaterThan.Text + "'";
                            fi.FilterType = FilterItem.FilterTypes.GreaterThanDate;
                            filterValues.Add(txtGreaterThan.Text);
                            fi.FilterValues = filterValues;
                        }

                        if (txtLessThan.Text != "  /  /")
                        {
                            sql += "< '" + txtLessThan.Text + "'";
                            fi.FilterType = FilterItem.FilterTypes.LessThanDate;
                            filterValues.Add(txtLessThan.Text);
                            fi.FilterValues = filterValues;
                        }

                        if (txtBetweenLower.Text != "  /  /" && txtBetweenUpper.Text != "  /  /")
                        {
                            sql += "BETWEEN '" + txtBetweenLower.Text + "' AND '" + txtBetweenUpper.Text + "'";
                            fi.FilterType = FilterItem.FilterTypes.BetweenDates;
                            filterValues.Add(txtBetweenLower.Text);
                            filterValues.Add(txtBetweenUpper.Text);
                            fi.FilterValues = filterValues;
                        }

                    }
                    else
                    {
                        if (isn == "YES")
                        {
                            //sql = taig.get_item(taig.SelectedRow, "COLUMN") + " ";

                            if (rbNumberIsNotNull.Checked)
                            {
                                sql += "IS NOT NULL";
                                fi.FilterType = FilterItem.FilterTypes.NotNull;
                            }

                            if (rbNumberIsNull.Checked)
                            {
                                sql += "IS NULL";
                                fi.FilterType = FilterItem.FilterTypes.AllowNull;
                            }

                            if (txtNumEqual.Text != "")
                            {
                                sql += "= " + txtNumEqual.Text + "";
                                fi.FilterType = FilterItem.FilterTypes.EqualNumber;
                                filterValues.Add(txtNumEqual.Text);
                                fi.FilterValues = filterValues;
                            }

                            if (txtNumNotEqual.Text != "")
                            {
                                sql += "<> " + txtNumNotEqual.Text + "";
                                fi.FilterType = FilterItem.FilterTypes.NotEqualNumber;
                                filterValues.Add(txtNumNotEqual.Text);
                                fi.FilterValues = filterValues;
                            }

                            if (txtNumGreaterThan.Text != "")
                            {
                                sql += "> " + txtNumGreaterThan.Text + "";
                                fi.FilterType = FilterItem.FilterTypes.GreaterThanNumber;
                                filterValues.Add(txtNumGreaterThan.Text);
                                fi.FilterValues = filterValues;
                            }

                            if (txtNumLessThan.Text != "")
                            {
                                sql += "< " + txtNumLessThan.Text + "";
                                fi.FilterType = FilterItem.FilterTypes.LessThanNumber;
                                filterValues.Add(txtNumLessThan.Text);
                                fi.FilterValues = filterValues;
                            }

                            if (txtNumBetweenLower.Text != "" && txtNumBetweenUpper.Text != "")
                            {
                                sql += "BETWEEN " + txtNumBetweenLower.Text + " AND " + txtNumBetweenUpper.Text + "";
                                fi.FilterType = FilterItem.FilterTypes.BetweenNumbers;
                                filterValues.Add(txtNumBetweenLower.Text);
                                filterValues.Add(txtNumBetweenUpper.Text);
                                fi.FilterValues = filterValues;
                            }

                        }
                        else
                        {
                            //sql = taig.get_item(taig.SelectedRow, "COLUMN") + " ";

                            if (rbStringIsNotNull.Checked)
                            {
                                sql += "IS NOT NULL";
                                fi.FilterType = FilterItem.FilterTypes.NotNull;
                            }

                            if (rbStringIsNull.Checked)
                            {
                                sql += "IS NULL";
                                fi.FilterType = FilterItem.FilterTypes.AllowNull;
                            }

                            if (txtStringEquals.Text != "")
                            {
                                sql += "= '" + txtStringEquals.Text + "'";
                                fi.FilterType = FilterItem.FilterTypes.EqualAlphaNumeric;
                                filterValues.Add(txtStringEquals.Text);
                                fi.FilterValues = filterValues;
                            }

                            if (txtStringNotEqual.Text != "")
                            {
                                sql += "<> '" + txtStringNotEqual.Text + "'";
                                fi.FilterType = FilterItem.FilterTypes.NotEqualAlphaNumeric;
                                filterValues.Add(txtStringNotEqual.Text);
                                fi.FilterValues = filterValues;
                            }

                            if (txtStringContains.Text != "")
                            {
                                sql += "LIKE '%" + txtStringContains.Text + "%'";
                                fi.FilterType = FilterItem.FilterTypes.ContainsAlphaNumeric;
                                filterValues.Add(txtStringContains.Text);
                                fi.FilterValues = filterValues;
                            }

                            if (txtStringStartsWith.Text != "")
                            {
                                sql += "LIKE '" + txtStringStartsWith.Text + "%'";
                                fi.FilterType = FilterItem.FilterTypes.StartsWithAlphaNumeric;
                                filterValues.Add(txtStringStartsWith.Text);
                                fi.FilterValues = filterValues;
                            }

                            if (txtStringEndsWith.Text != "")
                            {
                                sql += "LIKE '%" + txtStringEndsWith.Text + "'";
                                fi.FilterType = FilterItem.FilterTypes.EndsWithAlphaNumeric;
                                filterValues.Add(txtStringEndsWith.Text);
                                fi.FilterValues = filterValues;
                            }

                        }
                    }

                }

                Clause = sql;
                Filter = fi;
                txtClause.Text = sql;
            }
            catch (Exception ex)
            {
                showError("An error occurred while generating the query clause" + System.Environment.NewLine + ex.Message);
            }
        }

        private void GenerateClauseFromObject()
        {
            try
            {
                string sql = "";
                FilterItem fi = Filter;

                switch (fi.FilterType)
                {
                    case FilterItem.FilterTypes.AllowNull:
                        sql += fi.FilterField + "IS NULL";
                        break;
                    case FilterItem.FilterTypes.NotNull:
                        sql += fi.FilterField + "IS NOT NULL";
                        break;
                    case FilterItem.FilterTypes.EqualDate:
                        sql += fi.FilterField + " = '" + fi.FilterValues[0] + "'";
                        break;
                    case FilterItem.FilterTypes.NotEqualDate:
                        sql += fi.FilterField + " != '" + fi.FilterValues[0] + "'";
                        break;
                    case FilterItem.FilterTypes.GreaterThanDate:
                        sql += fi.FilterField + " > '" + fi.FilterValues[0] + "'";
                        break;
                    case FilterItem.FilterTypes.LessThanDate:
                        sql += fi.FilterField + " < '" + fi.FilterValues[0] + "'";
                        break;
                    case FilterItem.FilterTypes.BetweenDates:
                        sql += " (" + fi.FilterField + " BETWEEN '" + fi.FilterValues[0] + "' AND '" + fi.FilterValues[1] + "') ";
                        break;
                    case FilterItem.FilterTypes.EqualNumber:
                        sql += fi.FilterField + " = " + fi.FilterValues[0];
                        break;
                    case FilterItem.FilterTypes.NotEqualNumber:
                        sql += fi.FilterField + " != " + fi.FilterValues[0];
                        break;
                    case FilterItem.FilterTypes.GreaterThanNumber:
                        sql += fi.FilterField + " > " + fi.FilterValues[0];
                        break;
                    case FilterItem.FilterTypes.LessThanNumber:
                        sql += fi.FilterField + " < " + fi.FilterValues[0];
                        break;
                    case FilterItem.FilterTypes.BetweenNumbers:
                        sql += "(" + fi.FilterField + " BETWEEN " + fi.FilterValues[0] + " AND " + fi.FilterValues[1] + ") ";
                        break;
                    case FilterItem.FilterTypes.EqualAlphaNumeric:
                        sql += fi.FilterField + " = '" + fi.FilterValues[0] + "'";
                        break;
                    case FilterItem.FilterTypes.NotEqualAlphaNumeric:
                        sql += fi.FilterField + " != '" + fi.FilterValues[0] + "'";
                        break;
                    case FilterItem.FilterTypes.StartsWithAlphaNumeric:
                        sql += fi.FilterField + " LIKE '" + fi.FilterValues[0] + "%'";
                        break;
                    case FilterItem.FilterTypes.EndsWithAlphaNumeric:
                        sql += fi.FilterField + " LIKE '%" + fi.FilterValues[0] + "'";
                        break;
                    case FilterItem.FilterTypes.ContainsAlphaNumeric:
                        sql += fi.FilterField + " LIKE '%" + fi.FilterValues[0] + "%'";
                        break;
                }

                sql += " OR ";

                if (sql.EndsWith(" OR "))
                {
                    sql = sql.Substring(0, sql.Length - 4);
                }

                txtClause.Text = sql;
            }
            catch (Exception ex)
            {
                showError("An error occurred while generating the query clause" + System.Environment.NewLine + ex.Message);
            }
        }

        private string GenerateSelectionClause()
        {
            string sql = "";
            int t = 0;
            
            try
            {
                foreach (string tn in tnames)
                {
                    string[] tnn = tn.Split(":".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                    if (tnn.GetUpperBound(0) == 0)
                    {
                        // we are on the first string so
                        sql = "SELECT '" + tn + "' as 'TNAME','" + tn + ".' + COLUMN_NAME as 'COLUMN',DATA_TYPE," +
                        "ORDINAL_POSITION as 'POS',ISNUMERIC as 'NUM',ISDATE as 'DATE',ISALPHA as 'ALPHA' " +
                        "FROM (select COLUMN_NAME,DATA_TYPE,ORDINAL_POSITION," +
                        "case WHEN NUMERIC_PRECISION IS NULL THEN 'NO' ELSE 'YES' END as 'ISNUMERIC'," +
                        "case WHEN DATETIME_PRECISION IS NULL THEN 'NO' ELSE 'YES' END as 'ISDATE'," +
                        "case WHEN CHARACTER_MAXIMUM_LENGTH IS NULL THEN 'NO' ELSE 'YES' END as 'ISALPHA' " +
                        "from INFORMATION_SCHEMA.COLUMNS " +
                        "where TABLE_NAME = '" + tn + "' ) A" + t.ToString() + " ";
                    }
                    else
                    {
                        sql += "UNION " + System.Environment.NewLine +
                        "SELECT '" + tnn[1] + "' as 'TNAME','" + tnn[0] + ".' + COLUMN_NAME as 'COLUMN',DATA_TYPE," +
                        "ORDINAL_POSITION as 'POS',ISNUMERIC as 'NUM',ISDATE as 'DATE',ISALPHA as 'ALPHA' " +
                        "FROM (select COLUMN_NAME,DATA_TYPE,ORDINAL_POSITION," +
                        "case WHEN NUMERIC_PRECISION IS NULL THEN 'NO' ELSE 'YES' END as 'ISNUMERIC'," +
                        "case WHEN DATETIME_PRECISION IS NULL THEN 'NO' ELSE 'YES' END as 'ISDATE'," +
                        "case WHEN CHARACTER_MAXIMUM_LENGTH IS NULL THEN 'NO' ELSE 'YES' END as 'ISALPHA' " +
                        "from INFORMATION_SCHEMA.COLUMNS " +
                        "where TABLE_NAME = '" + tnn[1] + "' ) A" + t.ToString() + " ";
                    }

                    t += 1;

                }

                //sql = "SELECT '" + tnames[0] + ".' + COLUMN_NAME as 'COLUMN',DATA_TYPE," +
                //        "ORDINAL_POSITION as 'POS',ISNUMERIC as 'NUM',ISDATE as 'DATE',ISALPHA as 'ALPHA' " +
                //        "FROM (select COLUMN_NAME,DATA_TYPE,ORDINAL_POSITION," +
                //        "case WHEN NUMERIC_PRECISION IS NULL THEN 'NO' ELSE 'YES' END as 'ISNUMERIC'," +
                //        "case WHEN DATETIME_PRECISION IS NULL THEN 'NO' ELSE 'YES' END as 'ISDATE'," +
                //        "case WHEN CHARACTER_MAXIMUM_LENGTH IS NULL THEN 'NO' ELSE 'YES' END as 'ISALPHA' " +
                //        "from INFORMATION_SCHEMA.COLUMNS " +
                //        "where TABLE_NAME = '" + tnames[0] + "' ) A ";

                sql += "ORDER BY [COLUMN],ORDINAL_POSITION";

                return sql;
            }
            catch (Exception ex)
            {
                showError("An error occurred while generating the selection query" + System.Environment.NewLine + ex.Message);
                return sql;
            }
        }

        private FilterItem.FilterTypes getFilterTypeFromString(string type)
        {
            switch (type)
            {
                case "EqualDate":
                    return FilterItem.FilterTypes.EqualDate;
                case "NotEqualDate":
                    return FilterItem.FilterTypes.NotEqualDate;
                case "GreaterThanDate":
                    return FilterItem.FilterTypes.GreaterThanDate;
                case "LessThanDate":
                    return FilterItem.FilterTypes.LessThanDate;
                case "BetweenDates":
                    return FilterItem.FilterTypes.BetweenDates;
                case "EqualNumber":
                    return FilterItem.FilterTypes.EqualNumber;
                case "NotEqualNumber":
                    return FilterItem.FilterTypes.NotEqualNumber;
                case "GreaterThanNumber":
                    return FilterItem.FilterTypes.GreaterThanNumber;
                case "LessThanNumber":
                    return FilterItem.FilterTypes.LessThanNumber;
                case "BetweenNumbers":
                    return FilterItem.FilterTypes.BetweenNumbers;
                case "EqualAlphaNumeric":
                    return FilterItem.FilterTypes.EqualAlphaNumeric;
                case "NotEqualAlphaNumeric":
                    return FilterItem.FilterTypes.NotEqualAlphaNumeric;
                case "StartsWithAlphaNumeric":
                    return FilterItem.FilterTypes.StartsWithAlphaNumeric;
                case "EndsWithAlphaNumeric":
                    return FilterItem.FilterTypes.EndsWithAlphaNumeric;
                case "ContainsAlphaNumeric":
                    return FilterItem.FilterTypes.ContainsAlphaNumeric;
                case "AllowNull":
                    return FilterItem.FilterTypes.AllowNull;
                case "NotNull":
                    return FilterItem.FilterTypes.NotNull;
                default:
                    return FilterItem.FilterTypes.None;
            }
        }

        private void populateData(FilterItem filter)
        {
            try
            {
                bool isDate = false;
                bool isNumeric = false;
                bool isAlphaNumeric = false;
                FilterItem fi = filter;

                taig.SelectedRow = fi.GridRowID;

                if (taig.get_item(fi.GridRowID, "NUM") == "YES")
                {
                    isNumeric = true;
                    theTabs.SelectedIndex = 1;
                }
                else if (taig.get_item(fi.GridRowID, "DATE") == "YES")
                {
                    isDate = true;
                    theTabs.SelectedIndex = 0;
                }
                else if (taig.get_item(fi.GridRowID, "ALPHA") == "YES")
                {
                    isAlphaNumeric = true;
                    theTabs.SelectedIndex = 2;
                }

                switch (fi.FilterType)
                {
                    case FilterItem.FilterTypes.AllowNull:
                        if (isDate)
                        {
                            rbDateIsNull.Checked = true;
                        }
                        else if (isNumeric)
                        {
                            rbNumberIsNull.Checked = true;
                        }
                        else if (isAlphaNumeric)
                        {
                            rbStringIsNull.Checked = true;
                        }
                        break;
                    case FilterItem.FilterTypes.NotNull:
                        if (isDate)
                        {
                            rbDateIsNotNull.Checked = true;
                        }
                        else if (isNumeric)
                        {
                            rbNumberIsNotNull.Checked = true;
                        }
                        else if (isAlphaNumeric)
                        {
                            rbStringIsNotNull.Checked = true;
                        }
                        break;
                    case FilterItem.FilterTypes.EqualDate:
                        txtEqual.Text = fi.FilterValues[0];
                        break;
                    case FilterItem.FilterTypes.NotEqualDate:
                        txtNotEqual.Text = fi.FilterValues[0];
                        break;
                    case FilterItem.FilterTypes.GreaterThanDate:
                        txtGreaterThan.Text = fi.FilterValues[0];
                        break;
                    case FilterItem.FilterTypes.LessThanDate:
                        txtLessThan.Text = fi.FilterValues[0];
                        break;
                    case FilterItem.FilterTypes.BetweenDates:
                        txtBetweenLower.Text = fi.FilterValues[0];
                        txtBetweenUpper.Text = fi.FilterValues[1];
                        break;
                    case FilterItem.FilterTypes.EqualNumber:
                        txtNumEqual.Text = fi.FilterValues[0];
                        break;
                    case FilterItem.FilterTypes.NotEqualNumber:
                        txtNumNotEqual.Text = fi.FilterValues[0];
                        break;
                    case FilterItem.FilterTypes.GreaterThanNumber:
                        txtNumGreaterThan.Text = fi.FilterValues[0];
                        break;
                    case FilterItem.FilterTypes.LessThanNumber:
                        txtNumLessThan.Text = fi.FilterValues[0];
                        break;
                    case FilterItem.FilterTypes.BetweenNumbers:
                        txtNumBetweenLower.Text = fi.FilterValues[0];
                        txtNumBetweenUpper.Text = fi.FilterValues[1];
                        break;
                    case FilterItem.FilterTypes.EqualAlphaNumeric:
                        txtStringEquals.Text = fi.FilterValues[0];
                        break;
                    case FilterItem.FilterTypes.NotEqualAlphaNumeric:
                        txtStringNotEqual.Text = fi.FilterValues[0];
                        break;
                    case FilterItem.FilterTypes.StartsWithAlphaNumeric:
                        txtStringStartsWith.Text = fi.FilterValues[0];
                        break;
                    case FilterItem.FilterTypes.EndsWithAlphaNumeric:
                        txtStringEndsWith.Text = fi.FilterValues[0];
                        break;
                    case FilterItem.FilterTypes.ContainsAlphaNumeric:
                        txtStringContains.Text = fi.FilterValues[0];
                        break;
                }
            }
            catch (Exception ex)
            {
                showError("An error occurred while loading the object's data" + System.Environment.NewLine + ex.Message);
            }
        }

        private void showError(string errorMessage)
        {
            MessageBox.Show(errorMessage, "TAI Query Reporter", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        #endregion
       
    }
}
