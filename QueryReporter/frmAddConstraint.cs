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
    public partial class frmAddConstraint : Form
    {
        
        private bool Semaphore = false;
        public string Clause = "";
        public ConstraintItem Constraint;

        #region " Struct"

        public struct ConstraintItem
        {
            private string cField;
            private string cType;
            private List<string> cValues;

            //Struct Constructor
            public ConstraintItem(string type, string field, List<string> values)
            {
                this.cType = type;
                this.cField = field;
                this.cValues = values;
            }

            //Property that gets/sets the constraint type (i.e. EQUAL, NOTEQUAL, etc.)
            public string ConstraintType
            {
                get
                {
                    return this.cType;
                }
                set
                {
                    this.cType = value;
                }
            }

            //Property that gets/sets the constraint field
            public string ConstraintField
            {
                get
                {
                    return this.cField;
                }
                set
                {
                    this.cField = value;
                }
            }

            //Property that gets/sets a list of the constraint values
            public List<string> ConstraintValues
            {
                get
                {
                    return this.cValues;
                }
                set
                {
                    this.cValues = value;
                }
            }
        }

        #endregion

        #region " Constructors"

        public frmAddConstraint(List<string> TheAggregates)
        {
            InitializeComponent();

            taig.Cols = 1;
            taig.set_HeaderLabel(0, "Aggregation to constrain");

            taig.Rows = 0;

            foreach (string s in TheAggregates)
            {
                taig.Rows += 1;
                taig.set_item(taig.Rows - 1, 0, s);
            }

            taig.AutoSizeCellsToContents = true;
            taig.Refresh();
        }

        public frmAddConstraint(List<string> TheAggregates, TAIObjectCanvas2.CanvasObject obj)
        {
            InitializeComponent();

            taig.Cols = 1;
            taig.set_HeaderLabel(0, "Aggregation to constrain");

            taig.Rows = 0;

            foreach (string s in TheAggregates)
            {
                taig.Rows += 1;
                taig.set_item(taig.Rows - 1, 0, s);
            }

            if (obj.MetaData2 != string.Empty)
            {
                ConstraintItem ci = new ConstraintItem();
                List<string> constraintValues = new List<string>();

                //parse through the meta info to papulate the ConstraintItem object
                string[] meta = obj.MetaData2.Split('|');
                string[] values = meta[2].Split(',');

                taig.AutoSizeCellsToContents = true;
                taig.Refresh();

                ci.ConstraintType = meta[0];
                ci.ConstraintField = meta[1];

                for (int i = 0; i < values.Length; i++)
                {
                    constraintValues.Add(values[i]);
                }

                ci.ConstraintValues = constraintValues;

                //Populate the appropriate text box according to the constraint type
                switch (ci.ConstraintType)
                {
                    case "EQUAL":
                        txtNumEqual.Text = ci.ConstraintValues[0];
                        break;
                    case "NOTEQUAL":
                        txtNumNotEqual.Text = ci.ConstraintValues[0];
                        break;
                    case "GREATERTHAN":
                        txtNumGreaterThan.Text = ci.ConstraintValues[0];
                        break;
                    case "LESSTHAN":
                        txtNumLessThan.Text = ci.ConstraintValues[0];
                        break;
                    case "BETWEEN":
                        txtNumBetweenLower.Text = ci.ConstraintValues[0];
                        txtNumBetweenUpper.Text = ci.ConstraintValues[1];
                        break;
                }

                //Find the corresponding row id and select the row (if a row was found)
                int row = taig.FindInColumn(ci.ConstraintField, taig.GetColumnIDByName("Aggregation to constrain"), false);

                if (row != -1)
                {
                    taig.SelectedRow = row;
                }

                //generate the SQL clause
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

        private void HandleTextChangedInNumbers(object sender, EventArgs e)
        {
            // clear the other text boxes
            if (!Semaphore)
            {
                Semaphore = !Semaphore;

                foreach (object o in this.Controls)
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
                string sql = "";
                ConstraintItem ci = new ConstraintItem();
                List<string> ciValues = new List<string>();
                if (taig.SelectedRow != -1)
                {

                    string isn = "YES";
                    //string isd = taig.get_item(taig.SelectedRow, "DATE");
                    //string isa = taig.get_item(taig.SelectedRow, "ALPHA");

                    if (isn == "YES")
                    {
                        sql = taig.get_item(taig.SelectedRow, "Aggregation to constrain") + " ";
                        ci.ConstraintField = taig.get_item(taig.SelectedRow, "Aggregation to constrain");

                        if (txtNumEqual.Text != "")
                        {
                            sql += "= " + txtNumEqual.Text + "";
                            ci.ConstraintType = "EQUAL";
                            ciValues.Add(txtNumEqual.Text);
                            ci.ConstraintValues = ciValues;
                        }

                        if (txtNumNotEqual.Text != "")
                        {
                            sql += "<> " + txtNumNotEqual.Text + "";
                            ci.ConstraintType = "NOTEQUAL";
                            ciValues.Add(txtNumNotEqual.Text);
                            ci.ConstraintValues = ciValues;
                        }

                        if (txtNumGreaterThan.Text != "")
                        {
                            sql += "> " + txtNumGreaterThan.Text + "";
                            ci.ConstraintType = "GREATERTHAN";
                            ciValues.Add(txtNumGreaterThan.Text);
                            ci.ConstraintValues = ciValues;
                        }

                        if (txtNumLessThan.Text != "")
                        {
                            sql += "< " + txtNumLessThan.Text + "";
                            ci.ConstraintType = "LESSTHAN";
                            ciValues.Add(txtNumLessThan.Text);
                            ci.ConstraintValues = ciValues;
                        }

                        if (txtNumBetweenLower.Text != "" && txtNumBetweenUpper.Text != "")
                        {
                            sql += "BETWEEN " + txtNumBetweenLower.Text + " AND " + txtNumBetweenUpper.Text + "";
                            ci.ConstraintType = "BETWEEN";
                            ciValues.Add(txtNumBetweenLower.Text);
                            ciValues.Add(txtNumBetweenUpper.Text);
                            ci.ConstraintValues = ciValues;
                        }
                    }
                }

                Constraint = ci;
                Clause = sql;
                txtClause.Text = sql;
            }
            catch (Exception ex)
            {
                showError("An error occurred while generating the query clause" + System.Environment.NewLine
                    + ex.ToString());
            }
        }

        private void showError(string errorMessage)
        {
            MessageBox.Show(errorMessage, "TAI Query Reporter", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        #endregion
     
    }
}
