namespace TAIQueryReporter
{
    partial class frmAddConstraint
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
            System.Drawing.StringFormat stringFormat1 = new System.Drawing.StringFormat();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddConstraint));
            this.taig = new TAIGridControl2.TAIGridControl();
            this.txtNumBetweenUpper = new System.Windows.Forms.TextBox();
            this.txtNumBetweenLower = new System.Windows.Forms.TextBox();
            this.txtNumGreaterThan = new System.Windows.Forms.TextBox();
            this.txtNumLessThan = new System.Windows.Forms.TextBox();
            this.txtNumNotEqual = new System.Windows.Forms.TextBox();
            this.txtNumEqual = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtClause = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // taig
            // 
            this.taig.AlternateColoration = false;
            this.taig.AlternateColorationAltColor = System.Drawing.Color.MediumSpringGreen;
            this.taig.AlternateColorationBaseColor = System.Drawing.Color.AntiqueWhite;
            this.taig.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.taig.BorderColor = System.Drawing.Color.Black;
            this.taig.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.taig.CellOutlines = true;
            this.taig.ColBackColorEdit = System.Drawing.Color.Yellow;
            this.taig.Cols = 0;
            this.taig.DefaultBackgroundColor = System.Drawing.Color.AntiqueWhite;
            this.taig.DefaultCellFont = new System.Drawing.Font("Arial", 9F);
            this.taig.DefaultForegroundColor = System.Drawing.Color.Black;
            this.taig.Delimiter = ",";
            this.taig.ExcelAlternateColoration = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(255)))), ((int)(((byte)(204)))));
            this.taig.ExcelAutoFitColumn = true;
            this.taig.ExcelAutoFitRow = true;
            this.taig.ExcelFilename = "";
            this.taig.ExcelIncludeColumnHeaders = true;
            this.taig.ExcelKeepAlive = true;
            this.taig.ExcelMatchGridColorScheme = true;
            this.taig.ExcelMaximized = true;
            this.taig.ExcelMaxRowsPerSheet = 30000;
            this.taig.ExcelOutlineCells = true;
            this.taig.ExcelPageOrientation = 1;
            this.taig.ExcelShowBorders = false;
            this.taig.ExcelUseAlternateRowColor = true;
            this.taig.ExcelWorksheetName = "Grid Output";
            this.taig.GridEditMode = TAIGridControl2.TAIGridControl.GridEditModes.KeyReturn;
            this.taig.GridHeaderBackColor = System.Drawing.Color.LightBlue;
            this.taig.GridHeaderFont = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.taig.GridHeaderForeColor = System.Drawing.Color.Black;
            this.taig.GridHeaderHeight = 16;
            stringFormat1.Alignment = System.Drawing.StringAlignment.Near;
            stringFormat1.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
            stringFormat1.LineAlignment = System.Drawing.StringAlignment.Near;
            stringFormat1.Trimming = System.Drawing.StringTrimming.Character;
            this.taig.GridHeaderStringFormat = stringFormat1;
            this.taig.GridheaderVisible = true;
            this.taig.Location = new System.Drawing.Point(4, 4);
            this.taig.Name = "taig";
            this.taig.PageSettings = null;
            this.taig.PaginationSize = 0;
            this.taig.Rows = 0;
            this.taig.ScrollInterval = 5;
            this.taig.SelectedColBackColor = System.Drawing.Color.MediumSlateBlue;
            this.taig.SelectedColForeColor = System.Drawing.Color.LightGray;
            this.taig.SelectedColumn = -1;
            this.taig.SelectedRow = -1;
            this.taig.SelectedRowBackColor = System.Drawing.Color.Blue;
            this.taig.SelectedRowForeColor = System.Drawing.Color.White;
            this.taig.SelectedRows = ((System.Collections.ArrayList)(resources.GetObject("taig.SelectedRows")));
            this.taig.Size = new System.Drawing.Size(528, 528);
            this.taig.TabIndex = 4;
            this.taig.TitleBackColor = System.Drawing.Color.Blue;
            this.taig.TitleFont = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.taig.TitleForeColor = System.Drawing.Color.White;
            this.taig.TitleText = "Aggregation Fields to build the constraint against";
            this.taig.TitleVisible = true;
            this.taig.XMLDataSetName = "Grid_Output";
            this.taig.XMLFileName = "";
            this.taig.XMLIncludeSchema = false;
            this.taig.XMLNameSpace = "TAI_Grid_Ouptut";
            this.taig.XMLTableName = "Table";
            // 
            // txtNumBetweenUpper
            // 
            this.txtNumBetweenUpper.Location = new System.Drawing.Point(844, 336);
            this.txtNumBetweenUpper.Name = "txtNumBetweenUpper";
            this.txtNumBetweenUpper.Size = new System.Drawing.Size(100, 20);
            this.txtNumBetweenUpper.TabIndex = 44;
            this.txtNumBetweenUpper.TextChanged += new System.EventHandler(this.HandleTextChangedInNumbers);
            this.txtNumBetweenUpper.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HandleNumericKeyPress);
            // 
            // txtNumBetweenLower
            // 
            this.txtNumBetweenLower.Location = new System.Drawing.Point(844, 312);
            this.txtNumBetweenLower.Name = "txtNumBetweenLower";
            this.txtNumBetweenLower.Size = new System.Drawing.Size(100, 20);
            this.txtNumBetweenLower.TabIndex = 43;
            this.txtNumBetweenLower.TextChanged += new System.EventHandler(this.HandleTextChangedInNumbers);
            this.txtNumBetweenLower.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HandleNumericKeyPress);
            // 
            // txtNumGreaterThan
            // 
            this.txtNumGreaterThan.Location = new System.Drawing.Point(844, 276);
            this.txtNumGreaterThan.Name = "txtNumGreaterThan";
            this.txtNumGreaterThan.Size = new System.Drawing.Size(100, 20);
            this.txtNumGreaterThan.TabIndex = 42;
            this.txtNumGreaterThan.TextChanged += new System.EventHandler(this.HandleTextChangedInNumbers);
            this.txtNumGreaterThan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HandleNumericKeyPress);
            // 
            // txtNumLessThan
            // 
            this.txtNumLessThan.Location = new System.Drawing.Point(844, 240);
            this.txtNumLessThan.Name = "txtNumLessThan";
            this.txtNumLessThan.Size = new System.Drawing.Size(100, 20);
            this.txtNumLessThan.TabIndex = 41;
            this.txtNumLessThan.TextChanged += new System.EventHandler(this.HandleTextChangedInNumbers);
            this.txtNumLessThan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HandleNumericKeyPress);
            // 
            // txtNumNotEqual
            // 
            this.txtNumNotEqual.Location = new System.Drawing.Point(844, 204);
            this.txtNumNotEqual.Name = "txtNumNotEqual";
            this.txtNumNotEqual.Size = new System.Drawing.Size(100, 20);
            this.txtNumNotEqual.TabIndex = 40;
            this.txtNumNotEqual.TextChanged += new System.EventHandler(this.HandleTextChangedInNumbers);
            this.txtNumNotEqual.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HandleNumericKeyPress);
            // 
            // txtNumEqual
            // 
            this.txtNumEqual.Location = new System.Drawing.Point(844, 168);
            this.txtNumEqual.Name = "txtNumEqual";
            this.txtNumEqual.Size = new System.Drawing.Size(100, 20);
            this.txtNumEqual.TabIndex = 39;
            this.txtNumEqual.TextChanged += new System.EventHandler(this.HandleTextChangedInNumbers);
            this.txtNumEqual.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HandleNumericKeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(576, 208);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(255, 13);
            this.label9.TabIndex = 38;
            this.label9.Text = "Where the selected number is not equal to this value";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(568, 328);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(266, 13);
            this.label10.TabIndex = 37;
            this.label10.Text = "Where the selected number falls between these values";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(576, 280);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(256, 13);
            this.label11.TabIndex = 36;
            this.label11.Text = "Where the selected number is greater than this value";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(592, 244);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(241, 13);
            this.label12.TabIndex = 35;
            this.label12.Text = "Where the selected number is less than this value";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(596, 172);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(237, 13);
            this.label13.TabIndex = 34;
            this.label13.Text = "Where the selected number is equal to this value";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 592);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 13);
            this.label7.TabIndex = 48;
            this.label7.Text = "Generated Filter Clause";
            // 
            // txtClause
            // 
            this.txtClause.Location = new System.Drawing.Point(4, 568);
            this.txtClause.Name = "txtClause";
            this.txtClause.Size = new System.Drawing.Size(724, 20);
            this.txtClause.TabIndex = 47;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(928, 584);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 46;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAccept.Location = new System.Drawing.Point(928, 556);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 45;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // frmAddConstraint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 612);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtClause);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.txtNumBetweenUpper);
            this.Controls.Add(this.txtNumBetweenLower);
            this.Controls.Add(this.txtNumGreaterThan);
            this.Controls.Add(this.txtNumLessThan);
            this.Controls.Add(this.txtNumNotEqual);
            this.Controls.Add(this.txtNumEqual);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.taig);
            this.Name = "frmAddConstraint";
            this.Text = "Add a constraint to the query";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TAIGridControl2.TAIGridControl taig;
        private System.Windows.Forms.TextBox txtNumBetweenUpper;
        private System.Windows.Forms.TextBox txtNumBetweenLower;
        private System.Windows.Forms.TextBox txtNumGreaterThan;
        private System.Windows.Forms.TextBox txtNumLessThan;
        private System.Windows.Forms.TextBox txtNumNotEqual;
        private System.Windows.Forms.TextBox txtNumEqual;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtClause;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAccept;
    }
}
