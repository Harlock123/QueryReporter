namespace TAIQueryReporter
{
    partial class frmAddSyntheticFields
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddSyntheticFields));
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.taig = new TAIGridControl2.TAIGridControl();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAlias = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCalc = new System.Windows.Forms.TextBox();
            this.rbMathAdd = new System.Windows.Forms.RadioButton();
            this.rbMathSubtract = new System.Windows.Forms.RadioButton();
            this.rbMathMultiply = new System.Windows.Forms.RadioButton();
            this.rbMathDivide = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.rbDatePartYears = new System.Windows.Forms.RadioButton();
            this.rbDatePartMonths = new System.Windows.Forms.RadioButton();
            this.rbDatePartDays = new System.Windows.Forms.RadioButton();
            this.rbDatePartQuarter = new System.Windows.Forms.RadioButton();
            this.rbDatePartDayOfYear = new System.Windows.Forms.RadioButton();
            this.rbDatePartWeekOfYear = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.rbToUpperCase = new System.Windows.Forms.RadioButton();
            this.rbToLowerCase = new System.Windows.Forms.RadioButton();
            this.rbPullXLeft = new System.Windows.Forms.RadioButton();
            this.rbPullXRight = new System.Windows.Forms.RadioButton();
            this.txtX = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.rbPullXAtY = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.txtY = new System.Windows.Forms.TextBox();
            this.rbDatePartCalcAge = new System.Windows.Forms.RadioButton();
            this.rbCalAgeBetween2Dates = new System.Windows.Forms.RadioButton();
            this.rbConCat = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btnAccept
            // 
            this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAccept.Location = new System.Drawing.Point(756, 548);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 24;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(756, 572);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 23;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
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
            this.taig.Location = new System.Drawing.Point(300, 4);
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
            this.taig.Size = new System.Drawing.Size(528, 508);
            this.taig.TabIndex = 25;
            this.taig.TitleBackColor = System.Drawing.Color.Blue;
            this.taig.TitleFont = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.taig.TitleForeColor = System.Drawing.Color.White;
            this.taig.TitleText = "Fields to apply the synthetic creation to.";
            this.taig.TitleVisible = true;
            this.taig.XMLDataSetName = "Grid_Output";
            this.taig.XMLFileName = "";
            this.taig.XMLIncludeSchema = false;
            this.taig.XMLNameSpace = "TAI_Grid_Ouptut";
            this.taig.XMLTableName = "Table";
            this.taig.RowSelected += new TAIGridControl2.TAIGridControl.RowSelectedEventHandler(this.GenerateSynthClause);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 540);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Synthetic Field Alias";
            // 
            // txtAlias
            // 
            this.txtAlias.Location = new System.Drawing.Point(4, 516);
            this.txtAlias.Name = "txtAlias";
            this.txtAlias.Size = new System.Drawing.Size(196, 20);
            this.txtAlias.TabIndex = 21;
            this.txtAlias.TextChanged += new System.EventHandler(this.HandleAliasTextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 580);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Synthetic Field Creation Syntax";
            // 
            // txtCalc
            // 
            this.txtCalc.Location = new System.Drawing.Point(4, 556);
            this.txtCalc.Name = "txtCalc";
            this.txtCalc.Size = new System.Drawing.Size(536, 20);
            this.txtCalc.TabIndex = 22;
            // 
            // rbMathAdd
            // 
            this.rbMathAdd.AutoSize = true;
            this.rbMathAdd.Location = new System.Drawing.Point(16, 28);
            this.rbMathAdd.Name = "rbMathAdd";
            this.rbMathAdd.Size = new System.Drawing.Size(201, 17);
            this.rbMathAdd.TabIndex = 1;
            this.rbMathAdd.TabStop = true;
            this.rbMathAdd.Text = "Add Multiple Numeric Fields Together";
            this.rbMathAdd.UseVisualStyleBackColor = true;
            this.rbMathAdd.CheckedChanged += new System.EventHandler(this.HandleCheckChanged);
            // 
            // rbMathSubtract
            // 
            this.rbMathSubtract.AutoSize = true;
            this.rbMathSubtract.Location = new System.Drawing.Point(16, 48);
            this.rbMathSubtract.Name = "rbMathSubtract";
            this.rbMathSubtract.Size = new System.Drawing.Size(253, 17);
            this.rbMathSubtract.TabIndex = 2;
            this.rbMathSubtract.TabStop = true;
            this.rbMathSubtract.Text = "Subtract Multiple Numeric Fields from each other";
            this.rbMathSubtract.UseVisualStyleBackColor = true;
            this.rbMathSubtract.CheckedChanged += new System.EventHandler(this.HandleCheckChanged);
            // 
            // rbMathMultiply
            // 
            this.rbMathMultiply.AutoSize = true;
            this.rbMathMultiply.Location = new System.Drawing.Point(16, 68);
            this.rbMathMultiply.Name = "rbMathMultiply";
            this.rbMathMultiply.Size = new System.Drawing.Size(217, 17);
            this.rbMathMultiply.TabIndex = 3;
            this.rbMathMultiply.TabStop = true;
            this.rbMathMultiply.Text = "Multiply Multiple Numeric Fields Together";
            this.rbMathMultiply.UseVisualStyleBackColor = true;
            this.rbMathMultiply.CheckedChanged += new System.EventHandler(this.HandleCheckChanged);
            // 
            // rbMathDivide
            // 
            this.rbMathDivide.AutoSize = true;
            this.rbMathDivide.Location = new System.Drawing.Point(16, 88);
            this.rbMathDivide.Name = "rbMathDivide";
            this.rbMathDivide.Size = new System.Drawing.Size(240, 17);
            this.rbMathDivide.TabIndex = 4;
            this.rbMathDivide.TabStop = true;
            this.rbMathDivide.Text = "Divide Multiple Numeric Fields into each other";
            this.rbMathDivide.UseVisualStyleBackColor = true;
            this.rbMathDivide.CheckedChanged += new System.EventHandler(this.HandleCheckChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Simple Math Functions";
            // 
            // rbDatePartYears
            // 
            this.rbDatePartYears.AutoSize = true;
            this.rbDatePartYears.Location = new System.Drawing.Point(16, 136);
            this.rbDatePartYears.Name = "rbDatePartYears";
            this.rbDatePartYears.Size = new System.Drawing.Size(132, 17);
            this.rbDatePartYears.TabIndex = 6;
            this.rbDatePartYears.TabStop = true;
            this.rbDatePartYears.Text = "Get the Year of a Date";
            this.rbDatePartYears.UseVisualStyleBackColor = true;
            this.rbDatePartYears.CheckedChanged += new System.EventHandler(this.HandleCheckChanged);
            // 
            // rbDatePartMonths
            // 
            this.rbDatePartMonths.AutoSize = true;
            this.rbDatePartMonths.Location = new System.Drawing.Point(16, 156);
            this.rbDatePartMonths.Name = "rbDatePartMonths";
            this.rbDatePartMonths.Size = new System.Drawing.Size(140, 17);
            this.rbDatePartMonths.TabIndex = 7;
            this.rbDatePartMonths.TabStop = true;
            this.rbDatePartMonths.Text = "Get the Month of a Date";
            this.rbDatePartMonths.UseVisualStyleBackColor = true;
            this.rbDatePartMonths.CheckedChanged += new System.EventHandler(this.HandleCheckChanged);
            // 
            // rbDatePartDays
            // 
            this.rbDatePartDays.AutoSize = true;
            this.rbDatePartDays.Location = new System.Drawing.Point(16, 176);
            this.rbDatePartDays.Name = "rbDatePartDays";
            this.rbDatePartDays.Size = new System.Drawing.Size(129, 17);
            this.rbDatePartDays.TabIndex = 8;
            this.rbDatePartDays.TabStop = true;
            this.rbDatePartDays.Text = "Get the Day of a Date";
            this.rbDatePartDays.UseVisualStyleBackColor = true;
            this.rbDatePartDays.CheckedChanged += new System.EventHandler(this.HandleCheckChanged);
            // 
            // rbDatePartQuarter
            // 
            this.rbDatePartQuarter.AutoSize = true;
            this.rbDatePartQuarter.Location = new System.Drawing.Point(16, 236);
            this.rbDatePartQuarter.Name = "rbDatePartQuarter";
            this.rbDatePartQuarter.Size = new System.Drawing.Size(200, 17);
            this.rbDatePartQuarter.TabIndex = 11;
            this.rbDatePartQuarter.TabStop = true;
            this.rbDatePartQuarter.Text = "Get the Quarter of the Year of a Date";
            this.rbDatePartQuarter.UseVisualStyleBackColor = true;
            this.rbDatePartQuarter.CheckedChanged += new System.EventHandler(this.HandleCheckChanged);
            // 
            // rbDatePartDayOfYear
            // 
            this.rbDatePartDayOfYear.AutoSize = true;
            this.rbDatePartDayOfYear.Location = new System.Drawing.Point(16, 196);
            this.rbDatePartDayOfYear.Name = "rbDatePartDayOfYear";
            this.rbDatePartDayOfYear.Size = new System.Drawing.Size(184, 17);
            this.rbDatePartDayOfYear.TabIndex = 9;
            this.rbDatePartDayOfYear.TabStop = true;
            this.rbDatePartDayOfYear.Text = "Get the Day of the Year of a Date";
            this.rbDatePartDayOfYear.UseVisualStyleBackColor = true;
            this.rbDatePartDayOfYear.CheckedChanged += new System.EventHandler(this.HandleCheckChanged);
            // 
            // rbDatePartWeekOfYear
            // 
            this.rbDatePartWeekOfYear.AutoSize = true;
            this.rbDatePartWeekOfYear.Location = new System.Drawing.Point(16, 216);
            this.rbDatePartWeekOfYear.Name = "rbDatePartWeekOfYear";
            this.rbDatePartWeekOfYear.Size = new System.Drawing.Size(194, 17);
            this.rbDatePartWeekOfYear.TabIndex = 10;
            this.rbDatePartWeekOfYear.TabStop = true;
            this.rbDatePartWeekOfYear.Text = "Get the Week of the Year of a Date";
            this.rbDatePartWeekOfYear.UseVisualStyleBackColor = true;
            this.rbDatePartWeekOfYear.CheckedChanged += new System.EventHandler(this.HandleCheckChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Simple Date Functions";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 308);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Simple String Functions";
            // 
            // rbToUpperCase
            // 
            this.rbToUpperCase.AutoSize = true;
            this.rbToUpperCase.Location = new System.Drawing.Point(16, 328);
            this.rbToUpperCase.Name = "rbToUpperCase";
            this.rbToUpperCase.Size = new System.Drawing.Size(81, 17);
            this.rbToUpperCase.TabIndex = 14;
            this.rbToUpperCase.TabStop = true;
            this.rbToUpperCase.Text = "Upper Case";
            this.rbToUpperCase.UseVisualStyleBackColor = true;
            this.rbToUpperCase.CheckedChanged += new System.EventHandler(this.HandleCheckChanged);
            // 
            // rbToLowerCase
            // 
            this.rbToLowerCase.AutoSize = true;
            this.rbToLowerCase.Location = new System.Drawing.Point(16, 348);
            this.rbToLowerCase.Name = "rbToLowerCase";
            this.rbToLowerCase.Size = new System.Drawing.Size(81, 17);
            this.rbToLowerCase.TabIndex = 15;
            this.rbToLowerCase.TabStop = true;
            this.rbToLowerCase.Text = "Lower Case";
            this.rbToLowerCase.UseVisualStyleBackColor = true;
            this.rbToLowerCase.CheckedChanged += new System.EventHandler(this.HandleCheckChanged);
            // 
            // rbPullXLeft
            // 
            this.rbPullXLeft.AutoSize = true;
            this.rbPullXLeft.Location = new System.Drawing.Point(16, 368);
            this.rbPullXLeft.Name = "rbPullXLeft";
            this.rbPullXLeft.Size = new System.Drawing.Size(184, 17);
            this.rbPullXLeft.TabIndex = 16;
            this.rbPullXLeft.TabStop = true;
            this.rbPullXLeft.Text = "Pull X Characters from Left of field";
            this.rbPullXLeft.UseVisualStyleBackColor = true;
            this.rbPullXLeft.CheckedChanged += new System.EventHandler(this.HandleCheckChanged);
            // 
            // rbPullXRight
            // 
            this.rbPullXRight.AutoSize = true;
            this.rbPullXRight.Location = new System.Drawing.Point(16, 388);
            this.rbPullXRight.Name = "rbPullXRight";
            this.rbPullXRight.Size = new System.Drawing.Size(191, 17);
            this.rbPullXRight.TabIndex = 17;
            this.rbPullXRight.TabStop = true;
            this.rbPullXRight.Text = "Pull X Characters from Right of field";
            this.rbPullXRight.UseVisualStyleBackColor = true;
            this.rbPullXRight.CheckedChanged += new System.EventHandler(this.HandleCheckChanged);
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(216, 364);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(68, 20);
            this.txtX.TabIndex = 19;
            this.txtX.TextChanged += new System.EventHandler(this.HandleAliasTextChanged);
            this.txtX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HandleKeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(216, 384);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 44;
            this.label6.Text = "X";
            // 
            // rbPullXAtY
            // 
            this.rbPullXAtY.AutoSize = true;
            this.rbPullXAtY.Location = new System.Drawing.Point(16, 408);
            this.rbPullXAtY.Name = "rbPullXAtY";
            this.rbPullXAtY.Size = new System.Drawing.Size(181, 17);
            this.rbPullXAtY.TabIndex = 18;
            this.rbPullXAtY.TabStop = true;
            this.rbPullXAtY.Text = "Pull X Characters Starting From Y";
            this.rbPullXAtY.UseVisualStyleBackColor = true;
            this.rbPullXAtY.CheckedChanged += new System.EventHandler(this.HandleCheckChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(216, 420);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 13);
            this.label7.TabIndex = 47;
            this.label7.Text = "Y";
            // 
            // txtY
            // 
            this.txtY.Location = new System.Drawing.Point(216, 400);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(68, 20);
            this.txtY.TabIndex = 20;
            this.txtY.TextChanged += new System.EventHandler(this.HandleAliasTextChanged);
            this.txtY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HandleKeyPress);
            // 
            // rbDatePartCalcAge
            // 
            this.rbDatePartCalcAge.AutoSize = true;
            this.rbDatePartCalcAge.Location = new System.Drawing.Point(16, 256);
            this.rbDatePartCalcAge.Name = "rbDatePartCalcAge";
            this.rbDatePartCalcAge.Size = new System.Drawing.Size(188, 17);
            this.rbDatePartCalcAge.TabIndex = 12;
            this.rbDatePartCalcAge.TabStop = true;
            this.rbDatePartCalcAge.Text = "Calculate Age in Years from Today";
            this.rbDatePartCalcAge.UseVisualStyleBackColor = true;
            // 
            // rbCalAgeBetween2Dates
            // 
            this.rbCalAgeBetween2Dates.AutoSize = true;
            this.rbCalAgeBetween2Dates.Location = new System.Drawing.Point(16, 276);
            this.rbCalAgeBetween2Dates.Name = "rbCalAgeBetween2Dates";
            this.rbCalAgeBetween2Dates.Size = new System.Drawing.Size(268, 17);
            this.rbCalAgeBetween2Dates.TabIndex = 48;
            this.rbCalAgeBetween2Dates.TabStop = true;
            this.rbCalAgeBetween2Dates.Text = "Calculate Age in Years between two selected dates";
            this.rbCalAgeBetween2Dates.UseVisualStyleBackColor = true;
            // 
            // rbConCat
            // 
            this.rbConCat.AutoSize = true;
            this.rbConCat.Location = new System.Drawing.Point(16, 427);
            this.rbConCat.Name = "rbConCat";
            this.rbConCat.Size = new System.Drawing.Size(142, 17);
            this.rbConCat.TabIndex = 49;
            this.rbConCat.TabStop = true;
            this.rbConCat.Text = "Concatinate String Fields";
            this.rbConCat.UseVisualStyleBackColor = true;
            this.rbConCat.CheckedChanged += new System.EventHandler(this.HandleCheckChanged);
            // 
            // frmAddSyntheticFields
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(833, 597);
            this.ControlBox = false;
            this.Controls.Add(this.rbConCat);
            this.Controls.Add(this.rbCalAgeBetween2Dates);
            this.Controls.Add(this.rbDatePartCalcAge);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtY);
            this.Controls.Add(this.rbPullXAtY);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtX);
            this.Controls.Add(this.rbPullXRight);
            this.Controls.Add(this.rbPullXLeft);
            this.Controls.Add(this.rbToLowerCase);
            this.Controls.Add(this.rbToUpperCase);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rbDatePartWeekOfYear);
            this.Controls.Add(this.rbDatePartDayOfYear);
            this.Controls.Add(this.rbDatePartQuarter);
            this.Controls.Add(this.rbDatePartDays);
            this.Controls.Add(this.rbDatePartMonths);
            this.Controls.Add(this.rbDatePartYears);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rbMathDivide);
            this.Controls.Add(this.rbMathMultiply);
            this.Controls.Add(this.rbMathSubtract);
            this.Controls.Add(this.rbMathAdd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAlias);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCalc);
            this.Controls.Add(this.taig);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Name = "frmAddSyntheticFields";
            this.Text = "Add Synthetic Field";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private TAIGridControl2.TAIGridControl taig;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAlias;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCalc;
        private System.Windows.Forms.RadioButton rbMathAdd;
        private System.Windows.Forms.RadioButton rbMathSubtract;
        private System.Windows.Forms.RadioButton rbMathMultiply;
        private System.Windows.Forms.RadioButton rbMathDivide;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbDatePartYears;
        private System.Windows.Forms.RadioButton rbDatePartMonths;
        private System.Windows.Forms.RadioButton rbDatePartDays;
        private System.Windows.Forms.RadioButton rbDatePartQuarter;
        private System.Windows.Forms.RadioButton rbDatePartDayOfYear;
        private System.Windows.Forms.RadioButton rbDatePartWeekOfYear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rbToUpperCase;
        private System.Windows.Forms.RadioButton rbToLowerCase;
        private System.Windows.Forms.RadioButton rbPullXLeft;
        private System.Windows.Forms.RadioButton rbPullXRight;
        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton rbPullXAtY;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtY;
        private System.Windows.Forms.RadioButton rbDatePartCalcAge;
        private System.Windows.Forms.RadioButton rbCalAgeBetween2Dates;
        private System.Windows.Forms.RadioButton rbConCat;
    }
}
