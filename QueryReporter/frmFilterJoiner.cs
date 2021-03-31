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
    public partial class frmFilterJoiner : Form
    {
        public List<TAIObjectCanvas2.CanvasObject> TheFilters = new List<TAIObjectCanvas2.CanvasObject>();
        public string filter = "";
        public TAIObjectCanvas2.CanvasObject TheFilterToConnectWith = null;
        public string TheConnectType = "";

        public frmFilterJoiner(List<TAIObjectCanvas2.CanvasObject> ExistingFilters, string filter2connect)
        {
            InitializeComponent();

            taig.Cols = 3;
            taig.Rows = 0;
            taig.set_HeaderLabel(0, "FILTER NAME");
            taig.set_HeaderLabel(1, "JOIN TYPE");
            taig.set_HeaderLabel(2, "FILTER CLAUSE");

            foreach (TAIObjectCanvas2.CanvasObject o in ExistingFilters)
            {
                taig.Rows += 1;

                taig.set_item(taig.Rows - 1, 0, o.Name);
                taig.set_item(taig.Rows - 1, 2, o.MetaData);
                taig.set_item(taig.Rows - 1, 1, "OR");

            }

            TheFilters = ExistingFilters;
            filter = filter2connect;

            taig.AutoSizeCellsToContents = true;
            taig.Refresh();


        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (chkAND.Checked)
            {
                TheConnectType = "AND";
                TheFilterToConnectWith = null;
            }
            else
            {
                if (taig.SelectedRow != -1)
                {
                    string filtname = taig.get_item(taig.SelectedRow, 0);
                    TheConnectType = "OR";
                    
                    foreach (TAIObjectCanvas2.CanvasObject o in TheFilters)
                    {
                        if (o.Name == filtname)
                        {
                            TheFilterToConnectWith = o;
                            break;
                        }
                    }
                }
                else
                {
                    //TheFilterToConnectWith = null;
                    //If no existing filter is selected, automatically join to the last filter in the list
                    string filtname = taig.get_item(taig.Rows - 1, 0);
                    TheConnectType = "OR";

                    foreach (TAIObjectCanvas2.CanvasObject o in TheFilters)
                    {
                        if (o.Name == filtname)
                        {
                            TheFilterToConnectWith = o;
                            break;
                        }
                    }

                    //TheConnectType = "OR";

                }

            }

            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            TheConnectType = "";
            TheFilterToConnectWith = null;
            
            this.Hide();
        }

        private void HandleCheckChanges(object sender, EventArgs e)
        {
            CheckBox b = (CheckBox)sender;

            if (b.Name == "chkAND" && b.Checked )
            {
                TheFilterToConnectWith = null;
            }
            
        }

        private void HandleRowSelected(object sender, int RowSelected)
        {
            string filtname = taig.get_item(taig.SelectedRow, 0);

            foreach (TAIObjectCanvas2.CanvasObject o in TheFilters)
            {
                if (o.Name == filtname)
                {
                    TheFilterToConnectWith = o;
                    break;
                }
            }

            chkAND.Checked = false;

            TheConnectType = taig.get_item(taig.SelectedRow, 1);

        }
    }
}
