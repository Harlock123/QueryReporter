using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace TAIQueryReporter
{
    class frmSelectDataSource : Form
    {
        private Button btnReadDBs;
        private ListBox lbDatabases;
        private Label label2;
        private Label label1;
        private TextBox txtPwd;
        private TextBox txtUname;
        private CheckBox chkTrustedConnection;
        private ListBox lbServers;
        private PictureBox pictureBox1;
        private Button btnAccept;
        private Button btnCancel;
        private Label label3;
        private Label label4;
        private Label label5;
        private ListBox lbPredefinedServers;

        public string ConnectionString = "";

        private void InitializeComponent()
        {
            this.btnReadDBs = new System.Windows.Forms.Button();
            this.lbDatabases = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.txtUname = new System.Windows.Forms.TextBox();
            this.chkTrustedConnection = new System.Windows.Forms.CheckBox();
            this.lbServers = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbPredefinedServers = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReadDBs
            // 
            this.btnReadDBs.Location = new System.Drawing.Point(336, 364);
            this.btnReadDBs.Name = "btnReadDBs";
            this.btnReadDBs.Size = new System.Drawing.Size(212, 24);
            this.btnReadDBs.TabIndex = 18;
            this.btnReadDBs.Text = "Read Databases";
            this.btnReadDBs.UseVisualStyleBackColor = true;
            this.btnReadDBs.Click += new System.EventHandler(this.btnReadDBs_Click);
            // 
            // lbDatabases
            // 
            this.lbDatabases.FormattingEnabled = true;
            this.lbDatabases.Location = new System.Drawing.Point(552, 240);
            this.lbDatabases.Name = "lbDatabases";
            this.lbDatabases.Size = new System.Drawing.Size(220, 238);
            this.lbDatabases.TabIndex = 17;
            this.lbDatabases.SelectedIndexChanged += new System.EventHandler(this.HandleDBSelection);
            this.lbDatabases.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.HandleMouseDoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(340, 344);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(340, 308);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "UserName";
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(340, 324);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Size = new System.Drawing.Size(204, 20);
            this.txtPwd.TabIndex = 14;
            // 
            // txtUname
            // 
            this.txtUname.Location = new System.Drawing.Point(340, 288);
            this.txtUname.Name = "txtUname";
            this.txtUname.Size = new System.Drawing.Size(204, 20);
            this.txtUname.TabIndex = 13;
            // 
            // chkTrustedConnection
            // 
            this.chkTrustedConnection.AutoSize = true;
            this.chkTrustedConnection.Checked = true;
            this.chkTrustedConnection.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTrustedConnection.Location = new System.Drawing.Point(340, 268);
            this.chkTrustedConnection.Name = "chkTrustedConnection";
            this.chkTrustedConnection.Size = new System.Drawing.Size(127, 17);
            this.chkTrustedConnection.TabIndex = 12;
            this.chkTrustedConnection.Text = "Use Trusted Connect";
            this.chkTrustedConnection.UseVisualStyleBackColor = true;
            // 
            // lbServers
            // 
            this.lbServers.FormattingEnabled = true;
            this.lbServers.Location = new System.Drawing.Point(332, 16);
            this.lbServers.Name = "lbServers";
            this.lbServers.Size = new System.Drawing.Size(220, 199);
            this.lbServers.TabIndex = 11;
            this.lbServers.SelectedIndexChanged += new System.EventHandler(this.HandleEnumServersIndexChange);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TAIQueryReporter.Properties.Resources.Question;
            this.pictureBox1.Location = new System.Drawing.Point(4, 84);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(320, 320);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(72, 428);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(76, 24);
            this.btnAccept.TabIndex = 20;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(200, 428);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(76, 24);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(332, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Available Servers";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(552, 224);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Databases on Selected Server";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(556, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(161, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Available Pre-configured Servers";
            // 
            // lbPredefinedServers
            // 
            this.lbPredefinedServers.FormattingEnabled = true;
            this.lbPredefinedServers.Location = new System.Drawing.Point(556, 16);
            this.lbPredefinedServers.Name = "lbPredefinedServers";
            this.lbPredefinedServers.Size = new System.Drawing.Size(220, 199);
            this.lbPredefinedServers.TabIndex = 24;
            this.lbPredefinedServers.SelectedIndexChanged += new System.EventHandler(this.HandlePreserverIndexChange);
            // 
            // frmSelectDataSource
            // 
            this.ClientSize = new System.Drawing.Size(779, 481);
            this.ControlBox = false;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbPredefinedServers);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnReadDBs);
            this.Controls.Add(this.lbDatabases);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.txtUname);
            this.Controls.Add(this.chkTrustedConnection);
            this.Controls.Add(this.lbServers);
            this.Name = "frmSelectDataSource";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Data Source";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public frmSelectDataSource()
        {
            InitializeComponent();
        }

        private string GenerateConnectionString()
        {
            string Connect = "";

            if (lbServers.SelectedIndex != -1)
            {
                Connect = "server=" + lbServers.SelectedItem.ToString() + ";";

                if (chkTrustedConnection.Checked)
                {
                    Connect += "Integrated Security=SSPI";
                }
                else
                {
                    Connect += "uid=" + txtUname.Text + ";pwd=" + txtPwd.Text;
                }

                if (lbDatabases.SelectedIndex != -1)
                {
                    Connect += ";Initial Catalog=" + lbDatabases.SelectedItem.ToString();
                }
            }
            else
            {
                if (lbPredefinedServers.SelectedIndex != -1)
                {
                    Connect = "server=" + lbPredefinedServers.SelectedItem.ToString() + ";";

                    if (chkTrustedConnection.Checked)
                    {
                        Connect += "Integrated Security=SSPI";
                    }
                    else
                    {
                        Connect += "uid=" + txtUname.Text + ";pwd=" + txtPwd.Text;
                    }

                    if (lbDatabases.SelectedIndex != -1)
                    {
                        Connect += ";Initial Catalog=" + lbDatabases.SelectedItem.ToString();
                    }
                }
            }
                        
            return Connect;
        }

        private void btnReadDBs_Click(object sender, EventArgs e)
        {
            lbDatabases.Items.Clear();

            try
            {
                string Connect = GenerateConnectionString();

                SqlConnection con = new SqlConnection(Connect);

                con.Open();

                SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_databases";
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lbDatabases.Items.Add((dr.GetString(0)));
                }

                dr.Dispose();
                cmd.Dispose();
                con.Close();
                con.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void HandleDBSelection(object sender, EventArgs e)
        {
            ConnectionString = GenerateConnectionString();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            ConnectionString = GenerateConnectionString();
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ConnectionString = "";
            this.Hide();
        }
        
        public void PopulateServers(List<string> svrs,List<string> presvrs)
        {
            lbServers.Items.Clear();
            lbPredefinedServers.Items.Clear();
            
            lbServers.Items.Add("(local)");

            foreach (string s in svrs)
            {
                lbServers.Items.Add(s);
            }

            foreach (string s in presvrs)
            {
                lbPredefinedServers.Items.Add(s);
            }           
        }

        private void HandleMouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lbDatabases.SelectedIndex != -1)
            {
                btnAccept_Click(sender, new EventArgs());
            }
        }

        private void HandleEnumServersIndexChange(object sender, EventArgs e)
        {
            
        }

        private void HandlePreserverIndexChange(object sender, EventArgs e)
        {

        }
    }
}
