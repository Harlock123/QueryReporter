namespace TAIQueryReporter
{
    partial class frmAddFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddFilter));
            this.taig = new TAIGridControl2.TAIGridControl();
            this.theTabs = new System.Windows.Forms.TabControl();
            this.tpDates = new System.Windows.Forms.TabPage();
            this.btnDateFilterSet = new System.Windows.Forms.Button();
            this.rbDateIsNotNull = new System.Windows.Forms.RadioButton();
            this.rbDateIsNull = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBetweenUpper = new System.Windows.Forms.MaskedTextBox();
            this.txtBetweenLower = new System.Windows.Forms.MaskedTextBox();
            this.txtGreaterThan = new System.Windows.Forms.MaskedTextBox();
            this.txtLessThan = new System.Windows.Forms.MaskedTextBox();
            this.txtNotEqual = new System.Windows.Forms.MaskedTextBox();
            this.txtEqual = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tpNumbers = new System.Windows.Forms.TabPage();
            this.btnNumberFilterSet = new System.Windows.Forms.Button();
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
            this.rbNumberIsNotNull = new System.Windows.Forms.RadioButton();
            this.rbNumberIsNull = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.tpStrings = new System.Windows.Forms.TabPage();
            this.btnStringFilterSet = new System.Windows.Forms.Button();
            this.txtStringContains = new System.Windows.Forms.TextBox();
            this.txtStringEndsWith = new System.Windows.Forms.TextBox();
            this.txtStringStartsWith = new System.Windows.Forms.TextBox();
            this.txtStringNotEqual = new System.Windows.Forms.TextBox();
            this.txtStringEquals = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.rbStringIsNotNull = new System.Windows.Forms.RadioButton();
            this.rbStringIsNull = new System.Windows.Forms.RadioButton();
            this.label14 = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtClause = new System.Windows.Forms.TextBox();
            this.btnFieldBrowse = new System.Windows.Forms.Button();
            this.theTabs.SuspendLayout();
            this.tpDates.SuspendLayout();
            this.tpNumbers.SuspendLayout();
            this.tpStrings.SuspendLayout();
            this.SuspendLayout();
            // 
            // taig
            // 
            this.taig.AllowMultipleRowSelections = false;
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
            this.taig.Size = new System.Drawing.Size(528, 676);
            this.taig.TabIndex = 3;
            this.taig.TitleBackColor = System.Drawing.Color.Blue;
            this.taig.TitleFont = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.taig.TitleForeColor = System.Drawing.Color.White;
            this.taig.TitleText = "Fields to filter on";
            this.taig.TitleVisible = true;
            this.taig.XMLDataSetName = "Grid_Output";
            this.taig.XMLFileName = "";
            this.taig.XMLIncludeSchema = false;
            this.taig.XMLNameSpace = "TAI_Grid_Ouptut";
            this.taig.XMLTableName = "Table";
            this.taig.RowSelected += new TAIGridControl2.TAIGridControl.RowSelectedEventHandler(this.HandleRowSelected);
            // 
            // theTabs
            // 
            this.theTabs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.theTabs.Controls.Add(this.tpDates);
            this.theTabs.Controls.Add(this.tpNumbers);
            this.theTabs.Controls.Add(this.tpStrings);
            this.theTabs.Location = new System.Drawing.Point(536, 4);
            this.theTabs.Name = "theTabs";
            this.theTabs.SelectedIndex = 0;
            this.theTabs.Size = new System.Drawing.Size(472, 608);
            this.theTabs.TabIndex = 4;
            // 
            // tpDates
            // 
            this.tpDates.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tpDates.Controls.Add(this.btnDateFilterSet);
            this.tpDates.Controls.Add(this.rbDateIsNotNull);
            this.tpDates.Controls.Add(this.rbDateIsNull);
            this.tpDates.Controls.Add(this.label6);
            this.tpDates.Controls.Add(this.txtBetweenUpper);
            this.tpDates.Controls.Add(this.txtBetweenLower);
            this.tpDates.Controls.Add(this.txtGreaterThan);
            this.tpDates.Controls.Add(this.txtLessThan);
            this.tpDates.Controls.Add(this.txtNotEqual);
            this.tpDates.Controls.Add(this.txtEqual);
            this.tpDates.Controls.Add(this.label5);
            this.tpDates.Controls.Add(this.label4);
            this.tpDates.Controls.Add(this.label3);
            this.tpDates.Controls.Add(this.label2);
            this.tpDates.Controls.Add(this.label1);
            this.tpDates.Location = new System.Drawing.Point(4, 22);
            this.tpDates.Name = "tpDates";
            this.tpDates.Padding = new System.Windows.Forms.Padding(3);
            this.tpDates.Size = new System.Drawing.Size(464, 582);
            this.tpDates.TabIndex = 0;
            this.tpDates.Text = "Filter On Dates";
            // 
            // btnDateFilterSet
            // 
            this.btnDateFilterSet.Location = new System.Drawing.Point(88, 320);
            this.btnDateFilterSet.Name = "btnDateFilterSet";
            this.btnDateFilterSet.Size = new System.Drawing.Size(296, 23);
            this.btnDateFilterSet.TabIndex = 20;
            this.btnDateFilterSet.Text = "Build a Set of values for this filter";
            this.btnDateFilterSet.UseVisualStyleBackColor = true;
            this.btnDateFilterSet.Click += new System.EventHandler(this.btnDateFilterSet_Click);
            // 
            // rbDateIsNotNull
            // 
            this.rbDateIsNotNull.AutoSize = true;
            this.rbDateIsNotNull.Location = new System.Drawing.Point(320, 260);
            this.rbDateIsNotNull.Name = "rbDateIsNotNull";
            this.rbDateIsNotNull.Size = new System.Drawing.Size(84, 17);
            this.rbDateIsNotNull.TabIndex = 19;
            this.rbDateIsNotNull.TabStop = true;
            this.rbDateIsNotNull.Text = "Is Not NULL";
            this.rbDateIsNotNull.UseVisualStyleBackColor = true;
            this.rbDateIsNotNull.CheckedChanged += new System.EventHandler(this.HandleDatesNullNoNullCheckChanged);
            // 
            // rbDateIsNull
            // 
            this.rbDateIsNull.AutoSize = true;
            this.rbDateIsNull.Location = new System.Drawing.Point(320, 236);
            this.rbDateIsNull.Name = "rbDateIsNull";
            this.rbDateIsNull.Size = new System.Drawing.Size(64, 17);
            this.rbDateIsNull.TabIndex = 18;
            this.rbDateIsNull.TabStop = true;
            this.rbDateIsNull.Text = "Is NULL";
            this.rbDateIsNull.UseVisualStyleBackColor = true;
            this.rbDateIsNull.CheckedChanged += new System.EventHandler(this.HandleDatesNullNoNullCheckChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(164, 248);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(149, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Where the selected date field ";
            // 
            // txtBetweenUpper
            // 
            this.txtBetweenUpper.Location = new System.Drawing.Point(320, 200);
            this.txtBetweenUpper.Mask = "00/00/0000";
            this.txtBetweenUpper.Name = "txtBetweenUpper";
            this.txtBetweenUpper.Size = new System.Drawing.Size(84, 20);
            this.txtBetweenUpper.TabIndex = 16;
            this.txtBetweenUpper.ValidatingType = typeof(System.DateTime);
            this.txtBetweenUpper.TextChanged += new System.EventHandler(this.HandleDateTextChanged);
            // 
            // txtBetweenLower
            // 
            this.txtBetweenLower.Location = new System.Drawing.Point(320, 176);
            this.txtBetweenLower.Mask = "00/00/0000";
            this.txtBetweenLower.Name = "txtBetweenLower";
            this.txtBetweenLower.Size = new System.Drawing.Size(84, 20);
            this.txtBetweenLower.TabIndex = 15;
            this.txtBetweenLower.ValidatingType = typeof(System.DateTime);
            this.txtBetweenLower.TextChanged += new System.EventHandler(this.HandleDateTextChanged);
            // 
            // txtGreaterThan
            // 
            this.txtGreaterThan.Location = new System.Drawing.Point(320, 140);
            this.txtGreaterThan.Mask = "00/00/0000";
            this.txtGreaterThan.Name = "txtGreaterThan";
            this.txtGreaterThan.Size = new System.Drawing.Size(84, 20);
            this.txtGreaterThan.TabIndex = 14;
            this.txtGreaterThan.ValidatingType = typeof(System.DateTime);
            this.txtGreaterThan.TextChanged += new System.EventHandler(this.HandleDateTextChanged);
            // 
            // txtLessThan
            // 
            this.txtLessThan.Location = new System.Drawing.Point(320, 104);
            this.txtLessThan.Mask = "00/00/0000";
            this.txtLessThan.Name = "txtLessThan";
            this.txtLessThan.Size = new System.Drawing.Size(84, 20);
            this.txtLessThan.TabIndex = 13;
            this.txtLessThan.ValidatingType = typeof(System.DateTime);
            this.txtLessThan.TextChanged += new System.EventHandler(this.HandleDateTextChanged);
            // 
            // txtNotEqual
            // 
            this.txtNotEqual.Location = new System.Drawing.Point(320, 68);
            this.txtNotEqual.Mask = "00/00/0000";
            this.txtNotEqual.Name = "txtNotEqual";
            this.txtNotEqual.Size = new System.Drawing.Size(84, 20);
            this.txtNotEqual.TabIndex = 12;
            this.txtNotEqual.ValidatingType = typeof(System.DateTime);
            this.txtNotEqual.TextChanged += new System.EventHandler(this.HandleDateTextChanged);
            // 
            // txtEqual
            // 
            this.txtEqual.Location = new System.Drawing.Point(320, 32);
            this.txtEqual.Mask = "00/00/0000";
            this.txtEqual.Name = "txtEqual";
            this.txtEqual.Size = new System.Drawing.Size(84, 20);
            this.txtEqual.TabIndex = 11;
            this.txtEqual.ValidatingType = typeof(System.DateTime);
            this.txtEqual.TextChanged += new System.EventHandler(this.HandleDateTextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(72, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(241, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Where the selected date is not equal to this value";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(64, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(252, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Where the selected date falls between these values";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(72, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(242, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Where the selected date is greater than this value";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(88, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(227, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Where the selected date is less than this value";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Where the selected date is equal to this value";
            // 
            // tpNumbers
            // 
            this.tpNumbers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.tpNumbers.Controls.Add(this.btnNumberFilterSet);
            this.tpNumbers.Controls.Add(this.txtNumBetweenUpper);
            this.tpNumbers.Controls.Add(this.txtNumBetweenLower);
            this.tpNumbers.Controls.Add(this.txtNumGreaterThan);
            this.tpNumbers.Controls.Add(this.txtNumLessThan);
            this.tpNumbers.Controls.Add(this.txtNumNotEqual);
            this.tpNumbers.Controls.Add(this.txtNumEqual);
            this.tpNumbers.Controls.Add(this.label9);
            this.tpNumbers.Controls.Add(this.label10);
            this.tpNumbers.Controls.Add(this.label11);
            this.tpNumbers.Controls.Add(this.label12);
            this.tpNumbers.Controls.Add(this.label13);
            this.tpNumbers.Controls.Add(this.rbNumberIsNotNull);
            this.tpNumbers.Controls.Add(this.rbNumberIsNull);
            this.tpNumbers.Controls.Add(this.label8);
            this.tpNumbers.Location = new System.Drawing.Point(4, 22);
            this.tpNumbers.Name = "tpNumbers";
            this.tpNumbers.Padding = new System.Windows.Forms.Padding(3);
            this.tpNumbers.Size = new System.Drawing.Size(464, 582);
            this.tpNumbers.TabIndex = 1;
            this.tpNumbers.Text = "Filters On Numbers";
            // 
            // btnNumberFilterSet
            // 
            this.btnNumberFilterSet.Location = new System.Drawing.Point(88, 320);
            this.btnNumberFilterSet.Name = "btnNumberFilterSet";
            this.btnNumberFilterSet.Size = new System.Drawing.Size(296, 23);
            this.btnNumberFilterSet.TabIndex = 34;
            this.btnNumberFilterSet.Text = "Build a Set of values for this filter";
            this.btnNumberFilterSet.UseVisualStyleBackColor = true;
            this.btnNumberFilterSet.Click += new System.EventHandler(this.btnNumberFilterSet_Click);
            // 
            // txtNumBetweenUpper
            // 
            this.txtNumBetweenUpper.Location = new System.Drawing.Point(324, 200);
            this.txtNumBetweenUpper.Name = "txtNumBetweenUpper";
            this.txtNumBetweenUpper.Size = new System.Drawing.Size(100, 20);
            this.txtNumBetweenUpper.TabIndex = 33;
            this.txtNumBetweenUpper.TextChanged += new System.EventHandler(this.HandleTextChangedInNumbers);
            this.txtNumBetweenUpper.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HandleNumericKeyPress);
            // 
            // txtNumBetweenLower
            // 
            this.txtNumBetweenLower.Location = new System.Drawing.Point(324, 176);
            this.txtNumBetweenLower.Name = "txtNumBetweenLower";
            this.txtNumBetweenLower.Size = new System.Drawing.Size(100, 20);
            this.txtNumBetweenLower.TabIndex = 32;
            this.txtNumBetweenLower.TextChanged += new System.EventHandler(this.HandleTextChangedInNumbers);
            this.txtNumBetweenLower.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HandleNumericKeyPress);
            // 
            // txtNumGreaterThan
            // 
            this.txtNumGreaterThan.Location = new System.Drawing.Point(324, 140);
            this.txtNumGreaterThan.Name = "txtNumGreaterThan";
            this.txtNumGreaterThan.Size = new System.Drawing.Size(100, 20);
            this.txtNumGreaterThan.TabIndex = 31;
            this.txtNumGreaterThan.TextChanged += new System.EventHandler(this.HandleTextChangedInNumbers);
            this.txtNumGreaterThan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HandleNumericKeyPress);
            // 
            // txtNumLessThan
            // 
            this.txtNumLessThan.Location = new System.Drawing.Point(324, 104);
            this.txtNumLessThan.Name = "txtNumLessThan";
            this.txtNumLessThan.Size = new System.Drawing.Size(100, 20);
            this.txtNumLessThan.TabIndex = 30;
            this.txtNumLessThan.TextChanged += new System.EventHandler(this.HandleTextChangedInNumbers);
            this.txtNumLessThan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HandleNumericKeyPress);
            // 
            // txtNumNotEqual
            // 
            this.txtNumNotEqual.Location = new System.Drawing.Point(324, 68);
            this.txtNumNotEqual.Name = "txtNumNotEqual";
            this.txtNumNotEqual.Size = new System.Drawing.Size(100, 20);
            this.txtNumNotEqual.TabIndex = 29;
            this.txtNumNotEqual.TextChanged += new System.EventHandler(this.HandleTextChangedInNumbers);
            this.txtNumNotEqual.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HandleNumericKeyPress);
            // 
            // txtNumEqual
            // 
            this.txtNumEqual.Location = new System.Drawing.Point(324, 32);
            this.txtNumEqual.Name = "txtNumEqual";
            this.txtNumEqual.Size = new System.Drawing.Size(100, 20);
            this.txtNumEqual.TabIndex = 28;
            this.txtNumEqual.TextChanged += new System.EventHandler(this.HandleTextChangedInNumbers);
            this.txtNumEqual.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HandleNumericKeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(56, 72);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(255, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "Where the selected number is not equal to this value";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(48, 192);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(266, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "Where the selected number falls between these values";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(56, 144);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(256, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "Where the selected number is greater than this value";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(72, 108);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(241, 13);
            this.label12.TabIndex = 24;
            this.label12.Text = "Where the selected number is less than this value";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(76, 36);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(237, 13);
            this.label13.TabIndex = 23;
            this.label13.Text = "Where the selected number is equal to this value";
            // 
            // rbNumberIsNotNull
            // 
            this.rbNumberIsNotNull.AutoSize = true;
            this.rbNumberIsNotNull.Location = new System.Drawing.Point(320, 260);
            this.rbNumberIsNotNull.Name = "rbNumberIsNotNull";
            this.rbNumberIsNotNull.Size = new System.Drawing.Size(84, 17);
            this.rbNumberIsNotNull.TabIndex = 22;
            this.rbNumberIsNotNull.TabStop = true;
            this.rbNumberIsNotNull.Text = "Is Not NULL";
            this.rbNumberIsNotNull.UseVisualStyleBackColor = true;
            this.rbNumberIsNotNull.CheckedChanged += new System.EventHandler(this.HandleNumbersNullNoNullCheckChanged);
            // 
            // rbNumberIsNull
            // 
            this.rbNumberIsNull.AutoSize = true;
            this.rbNumberIsNull.Location = new System.Drawing.Point(320, 236);
            this.rbNumberIsNull.Name = "rbNumberIsNull";
            this.rbNumberIsNull.Size = new System.Drawing.Size(64, 17);
            this.rbNumberIsNull.TabIndex = 21;
            this.rbNumberIsNull.TabStop = true;
            this.rbNumberIsNull.Text = "Is NULL";
            this.rbNumberIsNull.UseVisualStyleBackColor = true;
            this.rbNumberIsNull.CheckedChanged += new System.EventHandler(this.HandleNumbersNullNoNullCheckChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(148, 248);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(165, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Where the selected numeric field ";
            // 
            // tpStrings
            // 
            this.tpStrings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tpStrings.Controls.Add(this.btnStringFilterSet);
            this.tpStrings.Controls.Add(this.txtStringContains);
            this.tpStrings.Controls.Add(this.txtStringEndsWith);
            this.tpStrings.Controls.Add(this.txtStringStartsWith);
            this.tpStrings.Controls.Add(this.txtStringNotEqual);
            this.tpStrings.Controls.Add(this.txtStringEquals);
            this.tpStrings.Controls.Add(this.label15);
            this.tpStrings.Controls.Add(this.label16);
            this.tpStrings.Controls.Add(this.label17);
            this.tpStrings.Controls.Add(this.label18);
            this.tpStrings.Controls.Add(this.label19);
            this.tpStrings.Controls.Add(this.rbStringIsNotNull);
            this.tpStrings.Controls.Add(this.rbStringIsNull);
            this.tpStrings.Controls.Add(this.label14);
            this.tpStrings.Location = new System.Drawing.Point(4, 22);
            this.tpStrings.Name = "tpStrings";
            this.tpStrings.Size = new System.Drawing.Size(464, 582);
            this.tpStrings.TabIndex = 2;
            this.tpStrings.Text = "Filters on Everything Else";
            // 
            // btnStringFilterSet
            // 
            this.btnStringFilterSet.Location = new System.Drawing.Point(88, 320);
            this.btnStringFilterSet.Name = "btnStringFilterSet";
            this.btnStringFilterSet.Size = new System.Drawing.Size(296, 23);
            this.btnStringFilterSet.TabIndex = 44;
            this.btnStringFilterSet.Text = "Build a Set of values for this filter";
            this.btnStringFilterSet.UseVisualStyleBackColor = true;
            this.btnStringFilterSet.Click += new System.EventHandler(this.btnStringFilterSet_Click);
            // 
            // txtStringContains
            // 
            this.txtStringContains.Location = new System.Drawing.Point(324, 176);
            this.txtStringContains.Name = "txtStringContains";
            this.txtStringContains.Size = new System.Drawing.Size(100, 20);
            this.txtStringContains.TabIndex = 43;
            this.txtStringContains.TextChanged += new System.EventHandler(this.HandleStringTextChanges);
            // 
            // txtStringEndsWith
            // 
            this.txtStringEndsWith.Location = new System.Drawing.Point(324, 140);
            this.txtStringEndsWith.Name = "txtStringEndsWith";
            this.txtStringEndsWith.Size = new System.Drawing.Size(100, 20);
            this.txtStringEndsWith.TabIndex = 42;
            this.txtStringEndsWith.TextChanged += new System.EventHandler(this.HandleStringTextChanges);
            // 
            // txtStringStartsWith
            // 
            this.txtStringStartsWith.Location = new System.Drawing.Point(324, 104);
            this.txtStringStartsWith.Name = "txtStringStartsWith";
            this.txtStringStartsWith.Size = new System.Drawing.Size(100, 20);
            this.txtStringStartsWith.TabIndex = 41;
            this.txtStringStartsWith.TextChanged += new System.EventHandler(this.HandleStringTextChanges);
            // 
            // txtStringNotEqual
            // 
            this.txtStringNotEqual.Location = new System.Drawing.Point(324, 68);
            this.txtStringNotEqual.Name = "txtStringNotEqual";
            this.txtStringNotEqual.Size = new System.Drawing.Size(100, 20);
            this.txtStringNotEqual.TabIndex = 40;
            this.txtStringNotEqual.TextChanged += new System.EventHandler(this.HandleStringTextChanges);
            // 
            // txtStringEquals
            // 
            this.txtStringEquals.Location = new System.Drawing.Point(324, 32);
            this.txtStringEquals.Name = "txtStringEquals";
            this.txtStringEquals.Size = new System.Drawing.Size(100, 20);
            this.txtStringEquals.TabIndex = 39;
            this.txtStringEquals.TextChanged += new System.EventHandler(this.HandleStringTextChanges);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(76, 72);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(239, 13);
            this.label15.TabIndex = 38;
            this.label15.Text = "Where the selected field is not equal to this value";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(104, 180);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(213, 13);
            this.label16.TabIndex = 37;
            this.label16.Text = "Where the selected field contains this value";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(100, 144);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(218, 13);
            this.label17.TabIndex = 36;
            this.label17.Text = "Where the selected field ends with this value";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(96, 108);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(220, 13);
            this.label18.TabIndex = 35;
            this.label18.Text = "Where the selected field starts with this value";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(96, 36);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(221, 13);
            this.label19.TabIndex = 34;
            this.label19.Text = "Where the selected field is equal to this value";
            // 
            // rbStringIsNotNull
            // 
            this.rbStringIsNotNull.AutoSize = true;
            this.rbStringIsNotNull.Location = new System.Drawing.Point(320, 240);
            this.rbStringIsNotNull.Name = "rbStringIsNotNull";
            this.rbStringIsNotNull.Size = new System.Drawing.Size(84, 17);
            this.rbStringIsNotNull.TabIndex = 25;
            this.rbStringIsNotNull.TabStop = true;
            this.rbStringIsNotNull.Text = "Is Not NULL";
            this.rbStringIsNotNull.UseVisualStyleBackColor = true;
            this.rbStringIsNotNull.CheckedChanged += new System.EventHandler(this.HandleStringNullNoNullCheckChanged);
            // 
            // rbStringIsNull
            // 
            this.rbStringIsNull.AutoSize = true;
            this.rbStringIsNull.Location = new System.Drawing.Point(320, 216);
            this.rbStringIsNull.Name = "rbStringIsNull";
            this.rbStringIsNull.Size = new System.Drawing.Size(64, 17);
            this.rbStringIsNull.TabIndex = 24;
            this.rbStringIsNull.TabStop = true;
            this.rbStringIsNull.Text = "Is NULL";
            this.rbStringIsNull.UseVisualStyleBackColor = true;
            this.rbStringIsNull.CheckedChanged += new System.EventHandler(this.HandleStringNullNoNullCheckChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(121, 228);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(191, 13);
            this.label14.TabIndex = 23;
            this.label14.Text = "Where the selected alphanumeric field ";
            // 
            // btnAccept
            // 
            this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAccept.Location = new System.Drawing.Point(928, 676);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 5;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(928, 704);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 712);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Generated Filter Clause";
            // 
            // txtClause
            // 
            this.txtClause.Location = new System.Drawing.Point(4, 688);
            this.txtClause.Name = "txtClause";
            this.txtClause.Size = new System.Drawing.Size(724, 20);
            this.txtClause.TabIndex = 20;
            // 
            // btnFieldBrowse
            // 
            this.btnFieldBrowse.Location = new System.Drawing.Point(596, 620);
            this.btnFieldBrowse.Name = "btnFieldBrowse";
            this.btnFieldBrowse.Size = new System.Drawing.Size(368, 24);
            this.btnFieldBrowse.TabIndex = 22;
            this.btnFieldBrowse.Text = "Open Field Browser on table containing selected field";
            this.btnFieldBrowse.UseVisualStyleBackColor = true;
            this.btnFieldBrowse.Click += new System.EventHandler(this.btnFieldBrowse_Click);
            // 
            // frmAddFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.ControlBox = false;
            this.Controls.Add(this.btnFieldBrowse);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtClause);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.theTabs);
            this.Controls.Add(this.taig);
            this.Name = "frmAddFilter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add a Filter to the query";
            this.theTabs.ResumeLayout(false);
            this.tpDates.ResumeLayout(false);
            this.tpDates.PerformLayout();
            this.tpNumbers.ResumeLayout(false);
            this.tpNumbers.PerformLayout();
            this.tpStrings.ResumeLayout(false);
            this.tpStrings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TAIGridControl2.TAIGridControl taig;
        private System.Windows.Forms.TabControl theTabs;
        private System.Windows.Forms.TabPage tpDates;
        private System.Windows.Forms.TabPage tpNumbers;
        private System.Windows.Forms.TabPage tpStrings;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.MaskedTextBox txtBetweenLower;
        private System.Windows.Forms.MaskedTextBox txtGreaterThan;
        private System.Windows.Forms.MaskedTextBox txtLessThan;
        private System.Windows.Forms.MaskedTextBox txtNotEqual;
        private System.Windows.Forms.MaskedTextBox txtEqual;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox txtBetweenUpper;
        private System.Windows.Forms.RadioButton rbDateIsNotNull;
        private System.Windows.Forms.RadioButton rbDateIsNull;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtClause;
        private System.Windows.Forms.RadioButton rbNumberIsNotNull;
        private System.Windows.Forms.RadioButton rbNumberIsNull;
        private System.Windows.Forms.Label label8;
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
        private System.Windows.Forms.TextBox txtStringContains;
        private System.Windows.Forms.TextBox txtStringEndsWith;
        private System.Windows.Forms.TextBox txtStringStartsWith;
        private System.Windows.Forms.TextBox txtStringNotEqual;
        private System.Windows.Forms.TextBox txtStringEquals;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.RadioButton rbStringIsNotNull;
        private System.Windows.Forms.RadioButton rbStringIsNull;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnFieldBrowse;
        private System.Windows.Forms.Button btnDateFilterSet;
        private System.Windows.Forms.Button btnNumberFilterSet;
        private System.Windows.Forms.Button btnStringFilterSet;
    }
}
