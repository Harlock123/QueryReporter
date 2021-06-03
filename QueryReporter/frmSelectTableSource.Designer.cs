namespace TAIQueryReporter
{
    partial class frmSelectTableSource
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.clbFields = new System.Windows.Forms.CheckedListBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tvTables = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAll = new System.Windows.Forms.Button();
            this.btnNone = new System.Windows.Forms.Button();
            this.btnShowFieldBrowser = new System.Windows.Forms.Button();
            this.txtSearchTree = new System.Windows.Forms.TextBox();
            this.lblnumrecs = new System.Windows.Forms.Label();
            this.lblnumrecsdesc = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // clbFields
            // 
            this.clbFields.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.clbFields.FormattingEnabled = true;
            this.clbFields.Location = new System.Drawing.Point(284, 36);
            this.clbFields.Name = "clbFields";
            this.clbFields.Size = new System.Drawing.Size(316, 514);
            this.clbFields.TabIndex = 1;
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(608, 4);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(88, 24);
            this.btnAccept.TabIndex = 2;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(608, 32);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 24);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tvTables
            // 
            this.tvTables.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tvTables.Location = new System.Drawing.Point(0, 36);
            this.tvTables.Name = "tvTables";
            this.tvTables.Size = new System.Drawing.Size(280, 516);
            this.tvTables.TabIndex = 4;
            this.tvTables.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.HandleNoteDoubleClick);
            this.tvTables.DoubleClick += new System.EventHandler(this.HandleATableViewSelection);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Available Tables and Views";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(284, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Columns in Selected Table or View";
            // 
            // btnAll
            // 
            this.btnAll.Location = new System.Drawing.Point(496, 12);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(48, 23);
            this.btnAll.TabIndex = 7;
            this.btnAll.Text = "All";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // btnNone
            // 
            this.btnNone.Location = new System.Drawing.Point(548, 12);
            this.btnNone.Name = "btnNone";
            this.btnNone.Size = new System.Drawing.Size(48, 23);
            this.btnNone.TabIndex = 8;
            this.btnNone.Text = "None";
            this.btnNone.UseVisualStyleBackColor = true;
            this.btnNone.Click += new System.EventHandler(this.btnNone_Click);
            // 
            // btnShowFieldBrowser
            // 
            this.btnShowFieldBrowser.Location = new System.Drawing.Point(608, 72);
            this.btnShowFieldBrowser.Name = "btnShowFieldBrowser";
            this.btnShowFieldBrowser.Size = new System.Drawing.Size(88, 24);
            this.btnShowFieldBrowser.TabIndex = 9;
            this.btnShowFieldBrowser.Text = "Field Browser";
            this.btnShowFieldBrowser.UseVisualStyleBackColor = true;
            this.btnShowFieldBrowser.Click += new System.EventHandler(this.btnShowFieldBrowser_Click);
            // 
            // txtSearchTree
            // 
            this.txtSearchTree.Location = new System.Drawing.Point(144, 12);
            this.txtSearchTree.Name = "txtSearchTree";
            this.txtSearchTree.Size = new System.Drawing.Size(95, 20);
            this.txtSearchTree.TabIndex = 10;
            this.txtSearchTree.TextChanged += new System.EventHandler(this.HandleSearchTreeChanges);
            // 
            // lblnumrecs
            // 
            this.lblnumrecs.AutoSize = true;
            this.lblnumrecs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnumrecs.Location = new System.Drawing.Point(606, 107);
            this.lblnumrecs.Name = "lblnumrecs";
            this.lblnumrecs.Size = new System.Drawing.Size(16, 16);
            this.lblnumrecs.TabIndex = 11;
            this.lblnumrecs.Text = "0";
            // 
            // lblnumrecsdesc
            // 
            this.lblnumrecsdesc.AutoSize = true;
            this.lblnumrecsdesc.Location = new System.Drawing.Point(605, 123);
            this.lblnumrecsdesc.Name = "lblnumrecsdesc";
            this.lblnumrecsdesc.Size = new System.Drawing.Size(88, 13);
            this.lblnumrecsdesc.TabIndex = 12;
            this.lblnumrecsdesc.Text = "Records in Table";
            // 
            // frmSelectTableSource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(702, 555);
            this.ControlBox = false;
            this.Controls.Add(this.lblnumrecsdesc);
            this.Controls.Add(this.lblnumrecs);
            this.Controls.Add(this.txtSearchTree);
            this.Controls.Add(this.btnShowFieldBrowser);
            this.Controls.Add(this.btnNone);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tvTables);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.clbFields);
            this.Name = "frmSelectTableSource";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Table and Fields";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clbFields;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TreeView tvTables;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Button btnNone;
        private System.Windows.Forms.Button btnShowFieldBrowser;
        private System.Windows.Forms.TextBox txtSearchTree;
        private System.Windows.Forms.Label lblnumrecs;
        private System.Windows.Forms.Label lblnumrecsdesc;
    }
}
