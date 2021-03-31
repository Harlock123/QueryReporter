namespace TAIQueryReporter
{
    partial class frmAddEditLookup
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
            this.btnAccept = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.lbFields = new System.Windows.Forms.ListBox();
            this.lbTables = new System.Windows.Forms.ListBox();
            this.lbJoinFields = new System.Windows.Forms.ListBox();
            this.lbReturnFields = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.rbLeftOuter = new System.Windows.Forms.RadioButton();
            this.rbInner = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(908, 488);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(88, 24);
            this.btnAccept.TabIndex = 1;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(908, 516);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(88, 24);
            this.Cancel.TabIndex = 2;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // lbFields
            // 
            this.lbFields.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.lbFields.FormattingEnabled = true;
            this.lbFields.Location = new System.Drawing.Point(8, 24);
            this.lbFields.Name = "lbFields";
            this.lbFields.Size = new System.Drawing.Size(244, 420);
            this.lbFields.TabIndex = 6;
            // 
            // lbTables
            // 
            this.lbTables.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.lbTables.FormattingEnabled = true;
            this.lbTables.Location = new System.Drawing.Point(256, 24);
            this.lbTables.Name = "lbTables";
            this.lbTables.Size = new System.Drawing.Size(244, 420);
            this.lbTables.TabIndex = 7;
            this.lbTables.SelectedIndexChanged += new System.EventHandler(this.HandleTableSelection);
            // 
            // lbJoinFields
            // 
            this.lbJoinFields.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lbJoinFields.FormattingEnabled = true;
            this.lbJoinFields.Location = new System.Drawing.Point(504, 24);
            this.lbJoinFields.Name = "lbJoinFields";
            this.lbJoinFields.Size = new System.Drawing.Size(244, 420);
            this.lbJoinFields.TabIndex = 8;
            // 
            // lbReturnFields
            // 
            this.lbReturnFields.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lbReturnFields.FormattingEnabled = true;
            this.lbReturnFields.Location = new System.Drawing.Point(752, 24);
            this.lbReturnFields.Name = "lbReturnFields";
            this.lbReturnFields.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbReturnFields.Size = new System.Drawing.Size(244, 420);
            this.lbReturnFields.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Available Fields For Index";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(256, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Available Tables For Indexing Into";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(504, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Fields In Table To Index Against";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(752, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Fields To Return On A Match";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(16, 448);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(228, 32);
            this.label5.TabIndex = 14;
            this.label5.Text = "Step 1... Select the field you want to use as the index field";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(264, 448);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(228, 32);
            this.label6.TabIndex = 15;
            this.label6.Text = "Step 2... Select the table you want to index into";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(512, 448);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(228, 32);
            this.label7.TabIndex = 16;
            this.label7.Text = "Step 3... Select the field in this table that you want to index against";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(760, 448);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(228, 32);
            this.label8.TabIndex = 17;
            this.label8.Text = "Step 4... Finally select the field you want the index to return";
            // 
            // rbLeftOuter
            // 
            this.rbLeftOuter.AutoSize = true;
            this.rbLeftOuter.Checked = true;
            this.rbLeftOuter.Location = new System.Drawing.Point(20, 488);
            this.rbLeftOuter.Name = "rbLeftOuter";
            this.rbLeftOuter.Size = new System.Drawing.Size(547, 17);
            this.rbLeftOuter.TabIndex = 18;
            this.rbLeftOuter.TabStop = true;
            this.rbLeftOuter.Text = "Fields in Base Table and fields in Match Table or empty (NULL) values in match ta" +
                "ble where no match is found.";
            this.rbLeftOuter.UseVisualStyleBackColor = true;
            // 
            // rbInner
            // 
            this.rbInner.AutoSize = true;
            this.rbInner.Location = new System.Drawing.Point(20, 508);
            this.rbInner.Name = "rbInner";
            this.rbInner.Size = new System.Drawing.Size(650, 17);
            this.rbInner.TabIndex = 19;
            this.rbInner.Text = "Fields in base table and fields in match table only. If match table fields do not" +
                " exist then resulting row in Base table is also not returned";
            this.rbInner.UseVisualStyleBackColor = true;
            // 
            // frmAddEditLookup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1000, 541);
            this.ControlBox = false;
            this.Controls.Add(this.rbInner);
            this.Controls.Add(this.rbLeftOuter);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbReturnFields);
            this.Controls.Add(this.lbJoinFields);
            this.Controls.Add(this.lbTables);
            this.Controls.Add(this.lbFields);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.btnAccept);
            this.Name = "frmAddEditLookup";
            this.Text = "Add / Edit Lookup (Join)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.ListBox lbFields;
        private System.Windows.Forms.ListBox lbTables;
        private System.Windows.Forms.ListBox lbJoinFields;
        private System.Windows.Forms.ListBox lbReturnFields;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton rbLeftOuter;
        private System.Windows.Forms.RadioButton rbInner;
    }
}
