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
    public partial class frmAddSyntheticFields : Form 
    {
        
        public string Dbase = "";
        private List<string> tnames = new List<string>();
        public string Clause = "";
        private bool Semaphore = false;
        public SyntheticItem SelectedSynthItem = new SyntheticItem();

        #region " Struct"

        public struct SyntheticItem
        {
            private string synthType;
            private string synthAlias;
            private List<string> synthFields;
            private List<string> synthTables;
            private string synthX;
            private string synthY;

            //struct constructor
            public SyntheticItem(string type, string alias, List<string> fields, List<string> tables, string x, string y)
            {
                this.synthType = type;
                this.synthAlias = alias;
                this.synthFields = fields;
                this.synthTables = tables;
                this.synthX = x;
                this.synthY = y;
            }

            //Struct properties
            
            //The type of Action being performed (i.e. Addition, DATEPART, etc.)
            public string SyntheticType
            {
                get
                {
                    return synthType;
                }
                set
                {
                    synthType = value;
                }
            }

            //The alias name provided to the synthetic field
            public string SyntheticAlias
            {
                get
                {
                    return synthAlias;
                }
                set
                {
                    synthAlias = value;
                }
            }

            //A list of the database fields involved in the construction of the synthetic field
            public List<string> SyntheticFields
            {
                get
                {
                    return synthFields;
                }
                set
                {
                    synthFields =  value;
                }
            }

            //A list of the database tables involved in the construction of the synthetic field
            public List<string> SyntheticTables
            {
                get
                {
                    return synthTables;
                }
                set
                {
                    synthTables = value;
                }
            }

            //The x value used for LEFT, RIGHT, and SUBSTRING actions
            public string SyntheticX
            {
                get
                {
                    return synthX;
                }
                set
                {
                    synthX = value;
                }
            }

            //The y value used for SUBSTRING
            public string SyntheticY
            {
                get
                {
                    return synthY;
                }
                set
                {
                    synthY = value;
                }
            }

            //Custom ToString() method for the SyntheticItem
            public override string ToString()
            {
                string siString = "";
                siString += "TYPE: " + this.SyntheticType + " ALIAS: " + this.SyntheticAlias;

                if (this.SyntheticTables.Count > 0)
                {
                    for (int i = 0; i < this.SyntheticFields.Count; i++)
                    {
                        siString += " FIELD: " + this.SyntheticTables[i] + "." + this.SyntheticFields[i] + ",";
                    }

                    siString = siString.Substring(0, siString.Length - 1);

                    siString += " X: " + this.SyntheticX + " Y: " + this.SyntheticY;
                }

                return siString;
            }

            //Method that returns a list of the database fields with their corresponding tables used in the construction of the synthetic field. 
            public List<string> GetFieldsWithTable()
            {
                List<string> fieldsWithTables = new List<string>();
                if ((this.SyntheticTables.Count == this.SyntheticFields.Count) && this.SyntheticTables.Count != 0)
                {
                    for (int i = 0; i < this.SyntheticTables.Count; i++)
                    {
                        fieldsWithTables.Add(this.SyntheticTables[i] + "." + this.SyntheticFields[i]);
                    }
                }
                return fieldsWithTables;
            }

        }

        #endregion

        #region " Class Constructors"
        
        public frmAddSyntheticFields(string Connection, List<string> TableNames)
        {
            InitializeComponent();

            Dbase = Connection;
            tnames = TableNames;
        }

        public frmAddSyntheticFields(string Connection, List<string> TableNames, TAIObjectCanvas2.CanvasObject obj)
        {
            InitializeComponent();

            Dbase = Connection;
            tnames = TableNames;

            //Check if saved data is stored in the object
            if (obj.MetaData2 != string.Empty)
            {
                string[] meta = obj.MetaData2.Split("|".ToCharArray());

                PopulateExistingSyntheticField(meta);
            }
            else
            {
                ShowError("Unable to load object data.");
            }
        }

        #endregion

        #region " Events"

        private void btnAccept_Click(object sender, EventArgs e)
        {
            Clause = txtCalc.Text;
            
            //Hide the form
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clause = "";
            
            //Hide the form
            this.Hide();
        }

        //Event that havdles when the text of txtAlias is changed
        private void HandleAliasTextChanged(object sender, EventArgs e)
        {
            //Generate new query clause
            GenerateSynthClause(sender, taig.SelectedRow);
        }

        //Event that handles when a radio button is checked/unchecked
        private void HandleCheckChanged(object sender, EventArgs e)
        {
            
            if (!Semaphore)
            {
                Semaphore = true;

                //Repopulate the grid depending on current selection
                taig.PopulateGridWithData(Dbase, GenerateSelectionClause());

                //Generate new query clause
                GenerateSynthClause(sender, taig.SelectedRow);

                Semaphore = false;
            }

        }

        //Event that handles a keyboard button press
        private void HandleKeyPress(object sender, KeyPressEventArgs e)
        {
            string c = e.KeyChar.ToString();

            if (c == "0" || c == "1" || c == "2" || c == "3" || c == "4" || c == "5" || c == "6" || c == "7" || c == "8" || c == "9" || c == "\b")
            {
                e.Handled = false;

                //Generate new query clause
                GenerateSynthClause(sender, taig.SelectedRow);
            }
            else
            {
                e.Handled = true;
            }
        }

        #endregion

        #region " Methods"

        private string GenerateSelectionClause()
        {
            
            string sql = "";

            sql = "SELECT COLUMN_NAME,DATA_TYPE,ORDINAL_POSITION, TABLE_NAME FROM (select COLUMN_NAME,DATA_TYPE,ORDINAL_POSITION,TABLE_NAME," +
                    "case WHEN NUMERIC_PRECISION IS NULL THEN 'NO' ELSE 'YES' END as 'ISNUMERIC'," +
                    "case WHEN DATETIME_PRECISION IS NULL THEN 'NO' ELSE 'YES' END as 'ISDATE'," +
                    "case WHEN CHARACTER_MAXIMUM_LENGTH IS NULL THEN 'NO' ELSE 'YES' END as 'ISALPHA' " +
                    "from INFORMATION_SCHEMA.COLUMNS ";

            //append table names to the sql query
            string tableClause = "WHERE ";

            for (int i = 0; i < tnames.Count; i++)
            {
                //If a lookup table was provided, get the base table name
                if (tnames[i].Contains(':'))
                {
                    string[] lkTable = tnames[i].Split(":".ToCharArray());
                    tableClause += "TABLE_NAME = '" + lkTable[lkTable.Length - 1] + "' OR ";
                }
                else
                {
                    tableClause += "TABLE_NAME = '" + tnames[i] + "' OR ";
                }
            }

            //strip off trailing 'OR '
            tableClause = tableClause.Substring(0, tableClause.Length - 3);

            //Add Alias
            tableClause += " ) A ";

            sql += tableClause;

            if (rbMathAdd.Checked || rbMathDivide.Checked || rbMathMultiply.Checked || rbMathSubtract.Checked)
            {
                sql += "WHERE ISNUMERIC = 'YES' ";
            }

            if (rbDatePartDayOfYear.Checked || rbDatePartDays.Checked ||
                rbDatePartMonths.Checked || rbDatePartQuarter.Checked ||
                rbDatePartWeekOfYear.Checked || rbDatePartYears.Checked ||
                rbCalAgeBetween2Dates.Checked || rbDatePartCalcAge.Checked)
            {
                sql += "WHERE ISDATE = 'YES' ";
            }

            if (rbToLowerCase.Checked || rbToUpperCase.Checked || rbPullXAtY.Checked || rbPullXLeft.Checked || rbPullXRight.Checked || rbConCat.Checked )
            {
                sql += "WHERE ISALPHA = 'YES' ";
            }

            sql += "ORDER BY ORDINAL_POSITION";

            return sql;

        }

        private void GenerateSynthClause(object sender, int RowSelected)
        {
            GenerateSynthClause();
        }

        private void GenerateSynthClause()
        {

            SyntheticItem si = new SyntheticItem();
            si.SyntheticFields = new List<string>();
            si.SyntheticTables = new List<string>();
            string synth = "";

            if (rbMathAdd.Checked || rbMathDivide.Checked || rbMathMultiply.Checked || rbMathSubtract.Checked || rbConCat.Checked )
            {
                synth = "(";
                string op = "";

                if (rbMathAdd.Checked || rbConCat.Checked )
                {
                    si.SyntheticType = "ADDITION";
                    op = "+";
                }

                if (rbMathDivide.Checked)
                {
                    si.SyntheticType = "DIVISION";
                    op = @"\";
                }

                if (rbMathMultiply.Checked)
                {
                    si.SyntheticType = "MULTIPLICATION";
                    op = "*";
                }

                if (rbMathSubtract.Checked)
                {
                    si.SyntheticType = "SUBTRACTION";
                    op = "-";
                }

                foreach (object o in taig.SelectedRows)
                {
                    int row = (int)o;
                    si.SyntheticFields.Add(taig.get_item(row, "COLUMN_NAME"));
                    si.SyntheticTables.Add(GetLookupTableFromBaseTable(taig.get_item(row, "TABLE_NAME")));
                    synth += GetLookupTableFromBaseTable(taig.get_item(row, "TABLE_NAME")) + "." +  Program.BraketizeKeywords(taig.get_item(row, "COLUMN_NAME")) + op;
                }

                // strip off the trailing op
                if (synth.EndsWith(op))
                {
                    synth = synth.Substring(0, synth.Length - 1);
                }

                synth += ") AS '" + txtAlias.Text + "'";
                si.SyntheticAlias = txtAlias.Text;
            }

            if (rbDatePartDayOfYear.Checked || rbDatePartDays.Checked ||
                rbDatePartMonths.Checked || rbDatePartQuarter.Checked ||
                rbDatePartWeekOfYear.Checked || rbDatePartYears.Checked ||
                rbDatePartCalcAge.Checked || rbCalAgeBetween2Dates.Checked)
            {

                string field = GetLookupTableFromBaseTable(taig.get_item(taig.SelectedRow, "TABLE_NAME")) + "." + Program.BraketizeKeywords(taig.get_item(taig.SelectedRow, "COLUMN_NAME"));
                si.SyntheticFields.Add(taig.get_item(taig.SelectedRow, "COLUMN_NAME"));
                si.SyntheticTables.Add(GetLookupTableFromBaseTable(taig.get_item(taig.SelectedRow, "TABLE_NAME")));

                if (rbDatePartDayOfYear.Checked)
                {
                    si.SyntheticType = "DATEPART - DAY OF YEAR";
                    synth = "DATEPART(DAYOFYEAR," + field + ") AS '" + txtAlias.Text + "'";
                }

                if (rbDatePartDays.Checked)
                {
                    si.SyntheticType = "DATEPART - DAY";
                    synth = "DATEPART(DAY," + field + ") AS '" + txtAlias.Text + "'";
                }

                if (rbDatePartMonths.Checked)
                {
                    si.SyntheticType = "DATEPART - MONTH";
                    synth = "DATEPART(MONTH," + field + ") AS '" + txtAlias.Text + "'";
                }

                if (rbDatePartQuarter.Checked)
                {
                    si.SyntheticType = "DATEPART - QUARTER";
                    synth = "DATEPART(QUARTER," + field + ") AS '" + txtAlias.Text + "'";
                }

                if (rbDatePartWeekOfYear.Checked)
                {
                    si.SyntheticType = "DATEPART - WEEK";
                    synth = "DATEPART(WEEK," + field + ") AS '" + txtAlias.Text + "'";
                }

                if (rbDatePartYears.Checked)
                {
                    si.SyntheticType = "DATEPART - YEAR";
                    synth = "DATEPART(YEAR," + field + ") AS '" + txtAlias.Text + "'";
                }

                if (rbDatePartCalcAge.Checked)
                {
                    si.SyntheticType = "DATEDIFF - FROM NOW";
                    synth = "FLOOR(DATEDIFF(day, " + field + ", GETDATE()) / 365.25) AS '" + txtAlias.Text + "'";
                }

                if (rbCalAgeBetween2Dates.Checked && taig.SelectedRows.Count > 1)
                {
                    field = GetLookupTableFromBaseTable(taig.get_item((int)taig.SelectedRows[0], "TABLE_NAME")) + "." + Program.BraketizeKeywords(taig.get_item((int)taig.SelectedRows[0], "COLUMN_NAME"));
                    si.SyntheticFields.Add(taig.get_item((int)taig.SelectedRows[0], "COLUMN_NAME"));
                    si.SyntheticTables.Add(GetLookupTableFromBaseTable(taig.get_item((int)taig.SelectedRows[0], "TABLE_NAME")));
                    string field2 = Program.BraketizeKeywords( taig.get_item((int)taig.SelectedRows[1], "COLUMN_NAME"));
                    si.SyntheticFields.Add(taig.get_item((int)taig.SelectedRows[1], "COLUMN_NAME"));
                    si.SyntheticTables.Add(GetLookupTableFromBaseTable(taig.get_item((int)taig.SelectedRows[1], "TABLE_NAME")));
                    si.SyntheticType = "DATEDIFF - FROM TWO DATES";
                    synth = "FLOOR(DATEDIFF(day, " + field + "," + field2 + ") / 365.25) AS '" + txtAlias.Text + "'";

                }

                si.SyntheticAlias = txtAlias.Text;
            }

            if (rbToLowerCase.Checked || rbToUpperCase.Checked || rbPullXAtY.Checked || rbPullXLeft.Checked || rbPullXRight.Checked)
            {
                string field = GetLookupTableFromBaseTable(taig.get_item(taig.SelectedRow, "TABLE_NAME")) + "." + Program.BraketizeKeywords(taig.get_item(taig.SelectedRow, "COLUMN_NAME"));
                si.SyntheticFields.Add(taig.get_item(taig.SelectedRow, "COLUMN_NAME"));
                si.SyntheticTables.Add(GetLookupTableFromBaseTable(taig.get_item(taig.SelectedRow, "TABLE_NAME")));

                if (rbToLowerCase.Checked)
                {
                    si.SyntheticType = "TO LOWER CASE";
                    synth = "LOWER(" + field + ") AS '" + txtAlias.Text + "'";
                }

                if (rbToUpperCase.Checked)
                {
                    si.SyntheticType = "TO UPPER CASE";
                    synth = "UPPER(" + field + ") AS '" + txtAlias.Text + "'";
                }

                if (rbPullXLeft.Checked)
                {
                    si.SyntheticType = "LEFT";
                    synth = "LEFT(" + field + "," + txtX.Text + ") AS '" + txtAlias.Text + "'";
                }

                if (rbPullXRight.Checked)
                {
                    si.SyntheticType = "RIGHT";
                    synth = "RIGHT(" + field + "," + txtX.Text + ") AS '" + txtAlias.Text + "'";
                }

                if (rbPullXAtY.Checked)
                {
                    si.SyntheticType = "SUBSTRING";
                    synth = "SUBSTRING(" + field + "," + txtY.Text + "," + txtX.Text + ") AS '" + txtAlias.Text + "'";
                }

                si.SyntheticAlias = txtAlias.Text;
            }

            si.SyntheticX = txtX.Text;
            si.SyntheticY = txtY.Text;
            SelectedSynthItem = si;
            txtCalc.Text = synth;
        }

        //Method that gets the assigned lookup table based on tnames
        private string GetLookupTableFromBaseTable(string bTable)
        {
            
            Dictionary<string, string> lookupTables = new Dictionary<string, string>();
            
            foreach (string table in tnames)
            {
                if (table.Contains(':'))
                {
                    string[] splitTable = table.Split(':');
                    lookupTables.Add(splitTable[0], splitTable[1]);
                }
            }

            if (lookupTables.ContainsValue(bTable))
            {              
                string lt = "";

                //Get the corresponding key
                foreach (KeyValuePair<string, string> kvp in lookupTables)
                {
                    if (kvp.Value == bTable)
                    {
                        lt = kvp.Key;
                        break;
                    }
                }

                return lt;
            }
            else
            {
                return bTable;
            }

        }

        //Method that populates an existing synthetic field item
        private void PopulateExistingSyntheticField(string[] meta)
        {

            int i = 0;
            SyntheticItem si = new SyntheticItem();

            //meta should always be a 6, but add check to avoid error
            while (i < meta.Length && (i % 6 == 0))
            {
                si.SyntheticAlias = meta[i++];
                si.SyntheticType = meta[i++];
                string[] sFields = meta[i++].Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                si.SyntheticFields = sFields.ToList<string>();
                string[] sTables = meta[i++].Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                si.SyntheticTables = sTables.ToList<string>();
                si.SyntheticX = meta[i++];
                si.SyntheticY = meta[i++];
            }

            SelectedSynthItem = si;

            //Check the appropriate radio button based on the SyntheticType
            switch (SelectedSynthItem.SyntheticType)
            {
                case "ADDITION":
                    rbMathAdd.Checked = true;
                    break;
                case "DIVISION":
                    rbMathDivide.Checked = true;
                    break;
                case "MULTIPLICATION":
                    rbMathMultiply.Checked = true;
                    break;
                case "SUBTRACTION":
                    rbMathSubtract.Checked = true;
                    break;
                case "DATEPART - DAY OF YEAR":
                    rbDatePartDayOfYear.Checked = true;
                    break;
                case "DATEPART - DAY":
                    rbDatePartDays.Checked = true;
                    break;
                case "DATEPART - MONTH":
                    rbDatePartMonths.Checked = true;
                    break;
                case "DATEPART - QUARTER":
                    rbDatePartMonths.Checked = true;
                    break;
                case "DATEPART - WEEK":
                    rbDatePartWeekOfYear.Checked = true;
                    break;
                case "DATEPART - YEAR":
                    rbDatePartYears.Checked = true;
                    break;
                case "DATEDIFF - FROM NOW":
                    rbDatePartCalcAge.Checked = true;
                    break;
                case "DATEDIFF - FROM TWO DATES":
                    rbCalAgeBetween2Dates.Checked = true;
                    break;
                case "TO LOWER CASE":
                    rbToLowerCase.Checked = true;
                    break;
                case "TO UPPER CASE":
                    rbToUpperCase.Checked = true;
                    break;
                case "LEFT":
                    rbPullXLeft.Checked = true;
                    break;
                case "RIGHT":
                    rbPullXRight.Checked = true;
                    break;
                case "SUBSTRING":
                    rbPullXAtY.Checked = true;
                    break;
            }

            //Set the alias, x, and y values
            txtAlias.Text = si.SyntheticAlias;
            txtX.Text = si.SyntheticX;
            txtY.Text = si.SyntheticY;

            //Select all grid rows (needed for an iteration through the rows)
            taig.SelectAllRows();

            //Get a list of the fields (with table) used for the synthetic items construction
            List<string> fieldsWithTable = si.GetFieldsWithTable();

            System.Collections.ArrayList selectedRowIDs = new System.Collections.ArrayList();

            //Loop through the selected grid rows to determine if the row contains the table.field used for the synthetic items construction
            foreach (int rowID in taig.SelectedRows)
            {
                string field = taig.get_item(rowID, "COLUMN_NAME");
                string table = GetLookupTableFromBaseTable(taig.get_item(rowID, "TABLE_NAME"));

                if (fieldsWithTable.Contains(table + "." + field))
                {
                    selectedRowIDs.Add(rowID);
                }
            }

            //Now, deselect all grid rows & select only the rows that contained a match
            taig.DeSelectAllRows();
            taig.SelectRows(selectedRowIDs);

            //Generate the query clause
            GenerateSynthClause();
        }

        //Displays an error message to the user
        private void ShowError(string errorMessage)
        {
            MessageBox.Show("An error has occurred. Please try again." + System.Environment.NewLine
                + "If the error persists, please contact software support." + System.Environment.NewLine
                + errorMessage, "TAI Query Reporter Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        #endregion
 
    }
}
