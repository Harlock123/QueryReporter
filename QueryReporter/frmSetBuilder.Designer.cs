namespace TAIQueryReporter
{
    partial class frmSetBuilder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSetBuilder));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.taig = new TAIGridControl2.TAIGridControl();
            this.btnSelectSubQuery = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.txtClause = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(932, 704);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 50;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAccept.Location = new System.Drawing.Point(932, 676);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 49;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // taig
            // 
            this.taig.AlternateColoration = false;
            this.taig.AlternateColorationAltColor = System.Drawing.Color.MediumSpringGreen;
            this.taig.AlternateColorationBaseColor = System.Drawing.Color.AntiqueWhite;
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
            this.taig.Location = new System.Drawing.Point(8, 32);
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
            this.taig.Size = new System.Drawing.Size(704, 608);
            this.taig.TabIndex = 51;
            this.taig.TitleBackColor = System.Drawing.Color.Blue;
            this.taig.TitleFont = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.taig.TitleForeColor = System.Drawing.Color.White;
            this.taig.TitleText = "Results from Sub Select Query";
            this.taig.TitleVisible = true;
            this.taig.XMLDataSetName = "Grid_Output";
            this.taig.XMLFileName = "";
            this.taig.XMLIncludeSchema = false;
            this.taig.XMLNameSpace = "TAI_Grid_Ouptut";
            this.taig.XMLTableName = "Table";
            this.taig.CellDoubleClicked += new TAIGridControl2.TAIGridControl.CellDoubleClickedEventHandler(this.HandleCellDoubleClicked);
            this.taig.ColumnSelected += new TAIGridControl2.TAIGridControl.ColumnSelectedEventHandler(this.HandleColumnSelected);
            // 
            // btnSelectSubQuery
            // 
            this.btnSelectSubQuery.Location = new System.Drawing.Point(8, 4);
            this.btnSelectSubQuery.Name = "btnSelectSubQuery";
            this.btnSelectSubQuery.Size = new System.Drawing.Size(184, 24);
            this.btnSelectSubQuery.TabIndex = 52;
            this.btnSelectSubQuery.Text = "Select Source Query for Sub Select";
            this.btnSelectSubQuery.UseVisualStyleBackColor = true;
            this.btnSelectSubQuery.Click += new System.EventHandler(this.btnSelectSubQuery_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 644);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 13);
            this.label1.TabIndex = 53;
            this.label1.Text = "Select The column that contains the sets values";
            // 
            // ofd
            // 
            this.ofd.FileName = "openFileDialog1";
            // 
            // txtClause
            // 
            this.txtClause.Location = new System.Drawing.Point(4, 688);
            this.txtClause.Name = "txtClause";
            this.txtClause.Size = new System.Drawing.Size(888, 20);
            this.txtClause.TabIndex = 54;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 712);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 55;
            this.label2.Text = "Generated Filter Clause";
            // 
            // frmSetBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtClause);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSelectSubQuery);
            this.Controls.Add(this.taig);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Name = "frmSetBuilder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Set Builder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAccept;
        private TAIGridControl2.TAIGridControl taig;
        private System.Windows.Forms.Button btnSelectSubQuery;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.TextBox txtClause;
        private System.Windows.Forms.Label label2;
    }
}
