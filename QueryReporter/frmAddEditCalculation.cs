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
    public partial class frmAddEditCalculation : Form
    {
        public string Dbase = "";
        public string CalcClause = "";
        public List<CalculationItem> SelectedFields = new List<CalculationItem>();

        #region " Structs"

        public struct CalculationItem
        {
            private string calcType;
            private string calcAlias;
            private string calcField;
            private string calcTable;

            //struct constructor
            public CalculationItem(string type, string alias, string field, string table)
            {
                this.calcType = type;
                this.calcAlias = alias;
                this.calcField = field;
                this.calcTable = table;
            }

            //Struct properties
            
            //The type of calculation to be performed (SUM, COUNT, MAX, MIN, AVG, or DISTINCT COUNT)
            public string CalculationType
            {
                get
                {
                    return calcType;
                }
                set
                {
                    calcType = value;
                }
            }

            //The alias name provided to the calculation field
            public string CalculationAlias
            {
                get
                {
                    return calcAlias;
                }
                set
                {
                    calcAlias = value;
                }
            }

            //The database field that the calculation is taking place on
            public string CalculationField
            {
                get
                {
                    return calcField;
                }
                set
                {
                    calcField = value;
                }
            }

            //The database table that the calculation field belongs to
            public string CalculationTable
            {
                get
                {
                    return calcTable;
                }
                set
                {
                    calcTable = value;
                }
            }
        }

        #endregion

        #region " Constructors"

        public frmAddEditCalculation(string Connection, List<string> fields)
        {
            InitializeComponent();

            Dbase = Connection;

            foreach (string s in fields)
            {
                lbFields.Items.Add(s);
            }
        }

        public frmAddEditCalculation(string Connection, List<string> fields, TAIObjectCanvas2.CanvasObject obj)
        {

            InitializeComponent();

            Dbase = Connection;

            foreach (string s in fields)
            {
                lbFields.Items.Add(s);
            }

            //Check if saved data is stored in the object
            if (obj.MetaData2 != String.Empty)
            {
                string[] meta = obj.MetaData2.Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                PopulateExistingCalculations(meta);
            }
            else
            {
                ShowError("Unable to load object data.");
            }
        }
        
        #endregion

        #region " Events"

        //Button Events

        private void btnAccept_Click(object sender, EventArgs e)
        {
            //Hide the form
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //Clear the clause & selected fields
            SelectedFields.RemoveRange(0, SelectedFields.Count);
            CalcClause = "";
            this.Hide();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //Clear the selected fields and regenerate the query clause
            lbSelFields.Items.Clear();
            txtAlias.Text = "";
            SelectedFields.RemoveRange(0, SelectedFields.Count);
            RegenClause();
        }

        private void btnFrom_Click(object sender, EventArgs e)
        {
            if (lbSelFields.SelectedIndex != -1)
            {
                //Get the index of the selected item & remove from the selected list & selected fields
                int i = lbSelFields.SelectedIndex;
                SelectedFields.RemoveAt(i);
                lbSelFields.Items.Remove(lbSelFields.SelectedItem);
            }

            RegenClause();
        }

        private void btnTo_Click(object sender, EventArgs e)
        {
            //When adding a new calc field, make sure to save the previously selected field (if any) 
            //then add the new item to the selected field list

            if (lbFields.SelectedIndex != -1)
            {
               
                string[] arr = lbFields.SelectedItem.ToString().Split('.');

                string aa = "";

                foreach (string a in arr)
                {
                    if (aa == "")
                    {
                        aa = Program.BraketizeKeywords(a);
                    }
                    else
                    {
                        aa += "." + Program.BraketizeKeywords(a);
                    }
                }
 
                
                lbSelFields.Items.Add(aa);

                //Update current items info
                if (lbSelFields.SelectedIndex != -1)
                {
                    CalculationItem item = SelectedFields[lbSelFields.SelectedIndex];

                    //Get the field & table name
                    string[] fieldWithTable = lbSelFields.SelectedItem.ToString().Split('.');

                    item.CalculationTable = fieldWithTable[0];
                    item.CalculationField = fieldWithTable[1];

                    SelectedFields.RemoveAt(lbSelFields.SelectedIndex);
                    SelectedFields.Insert(lbSelFields.SelectedIndex, item);
                }

                //Initialize & Add the new item to the SelectedFields List
                CalculationItem newItem = new CalculationItem();
                newItem.CalculationType = GetSelectedRadioCalc();

                string[] newFieldWithTable = lbFields.SelectedItem.ToString().Split('.');
                newItem.CalculationTable = newFieldWithTable[0];

                // make sure the field name does not have spaces if so bracket it

                string nfwt = Program.BraketizeKeywords(newFieldWithTable[1]);

                newItem.CalculationField = nfwt;

                SelectedFields.Add(newItem);
                lbSelFields.SelectedIndex = lbSelFields.Items.Count - 1;
            }

            RegenClause();
        }

        //Listbox Events

        private void lbFields_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbFields.SelectedIndex != -1)
            {
                lbSelFields.SelectedIndex = -1;
            }
        }

        private void lbSelFields_MouseClicked(object sender, EventArgs e)
        {
            //Get the new index & show the selected items values
            if (lbSelFields.SelectedIndex != -1)
            {
                int i = lbSelFields.SelectedIndex;
                CalculationItem ci = SelectedFields[i];
                txtAlias.Text = ci.CalculationAlias;

                switch (ci.CalculationType)
                {
                    case "AVG(":
                        rbAverage.Checked = true;
                        break;
                    case "COUNT(":
                        rbCount.Checked = true;
                        break;
                    case "COUNT DISTINCT(":
                        rbDistinctCount.Checked = true;
                        break;
                    case "MAX(":
                        rbMaximum.Checked = true;
                        break;
                    case "MIN(":
                        rbMinimum.Checked = true;
                        break;
                    case "SUM(":
                        rbSum.Checked = true;
                        break;
                }
            }
        }

        //Mouse Click Events

        private void HandleFieldDoubleClick(object sender, MouseEventArgs e)
        {
            //When a item in the fields list is double clicked, call btnTo_click to add the item to the selected list
            if (lbFields.SelectedIndex != -1)
            {
                btnTo_Click(sender, e);
            }
        }

        private void HandleSelectedDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (lbSelFields.SelectedIndex != -1)
                {
                    //Get the index of the selected item & remove item from the SelectedFields List & listbox
                    int i = lbSelFields.SelectedIndex;
                    SelectedFields.RemoveAt(i);
                    lbSelFields.Items.Remove(lbSelFields.SelectedItem);
                }

                RegenClause();
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        //Radio Button Events

        //Update an item's calculation type when a specific radio button is checked
        private void rbCount_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCount.Checked)
            {
                UpdateCalculationType();
            }
        }

        private void rbSum_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSum.Checked)
            {
                UpdateCalculationType();
            }
        }

        private void rbDistinctCount_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDistinctCount.Checked)
            {
                UpdateCalculationType();
            }
        }

        private void rbAverage_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAverage.Checked)
            {
                UpdateCalculationType();
            }
        }

        private void rbMinimum_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMinimum.Checked)
            {
                UpdateCalculationType();
            }
        }

        private void rbMaximum_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMaximum.Checked)
            {
                UpdateCalculationType();
            }
        }

        //Text Box Events

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (lbSelFields.SelectedIndex != -1)
            {
                CalculationItem selectedItem = SelectedFields[lbSelFields.SelectedIndex];
                selectedItem.CalculationAlias = txtAlias.Text;
                SelectedFields.RemoveAt(lbSelFields.SelectedIndex);
                SelectedFields.Insert(lbSelFields.SelectedIndex, selectedItem);
                RegenClause();
            }
        }

        #endregion

        #region " Methods"

        private string GenerateClause()
        {
            string ret = "";

            foreach (CalculationItem ci in SelectedFields)
            {

                if (rbPreNone.Checked)
                {

                    ret += ci.CalculationType + " " + ci.CalculationTable + "." + ci.CalculationField
                        + " ) AS '" + ci.CalculationAlias + "', ";
                }
                else if (rbPreMoney.Checked )
                {
                    ret += ci.CalculationType + " CAST(" + ci.CalculationTable + "." + ci.CalculationField
                          + " as MONEY)) AS '" + ci.CalculationAlias + "', ";
                }
                else if (rbPreInteger.Checked)
                {
                     ret += ci.CalculationType + " CAST(" + ci.CalculationTable + "." + ci.CalculationField
                          + " as BIGINT)) AS '" + ci.CalculationAlias + "', ";
                
                }
                else if (rbPreVarChar.Checked)
                {
                    ret += ci.CalculationType + " CAST(" + ci.CalculationTable + "." + ci.CalculationField
                         + " as VARCHAR(255))) AS '" + ci.CalculationAlias + "', ";
                
                }
                else if (rbPreDateTime.Checked)
                {
                    ret += ci.CalculationType + " CAST(" + ci.CalculationTable + "." + ci.CalculationField
                         + " as DATETIME)) AS '" + ci.CalculationAlias + "', ";

                }
            }

            //Remove any trailing commas
            if (ret.Length != 0)
            {
                ret = ret.Substring(0, ret.Length - 2);
            }

            return ret;
        }

        private string GetSelectedRadioCalc()
        {
            string myCalc = string.Empty;

            if (rbAverage.Checked)
                myCalc = "AVG(";
            else if (rbCount.Checked)
                myCalc = "COUNT(";
            else if (rbDistinctCount.Checked)
                myCalc = "COUNT(DISTINCT";
            else if (rbMaximum.Checked)
                myCalc = "MAX(";
            else if (rbMinimum.Checked)
                myCalc = "MIN(";
            else if (rbSum.Checked)
                myCalc = "SUM(";
            else if (rbVar.Checked)
                myCalc = "VAR(";
            else if (rbVarP.Checked)
                myCalc = "VARP(";
            else if (rbStDev.Checked)
                myCalc = "STDEV(";
            else if (rbStDevP.Checked)
                myCalc = "STDEVP(";

            return myCalc;
        }

        private void PopulateExistingCalculations(string[] meta)
        {
            
            List<CalculationItem> allMeta = new List<CalculationItem>();
            int i = 0;

            //meta should always be a multiple of 4, but add check to avoid error
            while (i < meta.Length && (i % 4 == 0))
            {
                CalculationItem ci = new CalculationItem();

                ci.CalculationType = meta[i++];
                ci.CalculationAlias = meta[i++];
                ci.CalculationField = meta[i++];
                ci.CalculationTable = meta[i++];

                allMeta.Add(ci);
            }

            SelectedFields = allMeta;

            //add each previously selected calculation field to the selected list box
            foreach (CalculationItem c in allMeta)
            {
                lbSelFields.Items.Add(c.CalculationTable + "." + c.CalculationField);
            }

            //Automatically select the first item in lbSelFields
            if (lbSelFields.Items.Count > 0)
            {
                lbSelFields.SelectedIndex = 0;
                CalculationItem ci = SelectedFields[0];
                txtAlias.Text = ci.CalculationAlias;

                switch (ci.CalculationType)
                {
                    case "AVG(":
                        rbAverage.Checked = true;
                        break;
                    case "COUNT(":
                        rbCount.Checked = true;
                        break;
                    case "COUNT DISTINCT(":
                        rbDistinctCount.Checked = true;
                        break;
                    case "MAX(":
                        rbMaximum.Checked = true;
                        break;
                    case "MIN(":
                        rbMinimum.Checked = true;
                        break;
                    case "SUM(":
                        rbSum.Checked = true;
                        break;
                    case "VAR(":
                        rbVar.Checked = true;
                        break;
                    case "VARP(":
                        rbVarP.Checked = true;
                        break;
                    case "STDEV(":
                        rbStDev.Checked = true;
                        break;
                    case "STDEVP(":
                        rbStDevP.Checked  = true;
                        break;
                }
            }

            RegenClause();
        }

        private void RegenClause()
        {
            txtCalc.Text = GenerateClause();
            CalcClause = txtCalc.Text;
        }

        private void ShowError(string errorMessage)
        {
            MessageBox.Show("An error has occurred. Please try again." + System.Environment.NewLine
                + "If the error persists, please contact software support." + System.Environment.NewLine
                + errorMessage, "TAI Query Reporter Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void UpdateCalculationType()
        {
            if (lbSelFields.SelectedIndex != -1 && lbSelFields.Items.Count > 0)
            {
                int i = lbSelFields.SelectedIndex;
                CalculationItem ci = SelectedFields[i];
                ci.CalculationType = GetSelectedRadioCalc();
                SelectedFields.RemoveAt(i);
                SelectedFields.Insert(i, ci);
                RegenClause();
            }
        }       

        #endregion

        private void HandlePreconvertCheckChanged(object sender, EventArgs e)
        {
            RegenClause();
        }


    }
}
