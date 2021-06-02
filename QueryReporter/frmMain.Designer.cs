namespace TAIQueryReporter
{
    partial class frmMain
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            System.Drawing.StringFormat stringFormat2 = new System.Drawing.StringFormat();
            this.tais = new TAISyntaxColorizer.TAISyntaxColorizer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.oc1 = new TAIObjectCanvas2.ObjectCanvas();
            this.theTabs = new System.Windows.Forms.TabControl();
            this.tbInterface = new System.Windows.Forms.TabPage();
            this.tbResult = new System.Windows.Forms.TabPage();
            this.btnGraphResults = new System.Windows.Forms.Button();
            this.taigResults = new TAIGridControl2.TAIGridControl();
            this.txtConnectionString = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnConnect2AServer = new System.Windows.Forms.Button();
            this.btnSelectTableSource = new System.Windows.Forms.Button();
            this.ttip = new System.Windows.Forms.ToolTip(this.components);
            this.btnExecute = new System.Windows.Forms.Button();
            this.btlAddLookup = new System.Windows.Forms.Button();
            this.cm = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddCalculation = new System.Windows.Forms.Button();
            this.btnAddRollup = new System.Windows.Forms.Button();
            this.btnAddSyntheticField = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.versionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.currentQueryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.btnClearCurrentQuery = new System.Windows.Forms.Button();
            this.btnAddFilter = new System.Windows.Forms.Button();
            this.btnAddConstraint = new System.Windows.Forms.Button();
            this.btnAddLimiter = new System.Windows.Forms.Button();
            this.btnAddSortOperation = new System.Windows.Forms.Button();
            this.btnHCLookup = new System.Windows.Forms.Button();
            this.tbarFontSize = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd_Distinct = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.theTabs.SuspendLayout();
            this.tbInterface.SuspendLayout();
            this.tbResult.SuspendLayout();
            this.cm.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbarFontSize)).BeginInit();
            this.SuspendLayout();
            // 
            // tais
            // 
            this.tais.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tais.ConstantKeyWords = "MONEY,BIGINT,DATETIME,VARCHAR,YEAR,QUARTER,MONTH,DAYOFYEAR,DAY,WEEK,WEEKDAY,HOUR," +
    "MINUTE,SECOND,MILLISECOND,YY,QQ,MM,DY,DD,WK,DW,HH,MI,SS,MS";
            this.tais.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tais.FunctionKeyWords = resources.GetString("tais.FunctionKeyWords");
            this.tais.KeyWords = "SELECT,FROM,WHERE,ORDER,GROUP,BY,TOP,LIMIT,AS,ASC,DESC,AND,OR,NOT,NULL,IS,IN,LIKE" +
    ",LEFT,RIGHT,FULL,INNER,OUTER,JOIN,ON,CASE,WHEN,THEN,ELSE,END,HAVING";
            this.tais.Location = new System.Drawing.Point(0, 0);
            this.tais.MatchCase = false;
            this.tais.Name = "tais";
            this.tais.Size = new System.Drawing.Size(834, 303);
            this.tais.TabIndex = 0;
            this.tais.WhiteSpaceMatch = "[^\\,\\?\\|\\[\\]\\(\\)\\{\\}\\$\\n\\r\\t\\v\\x20]+";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(4);
            this.panel1.Size = new System.Drawing.Size(842, 644);
            this.panel1.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.Highlight;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(4, 4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.oc1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tais);
            this.splitContainer1.Size = new System.Drawing.Size(834, 636);
            this.splitContainer1.SplitterDistance = 329;
            this.splitContainer1.TabIndex = 0;
            // 
            // oc1
            // 
            this.oc1.DisplayDataSubMenuItem = false;
            this.oc1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.oc1.Location = new System.Drawing.Point(0, 0);
            this.oc1.MoveConnectedObjectOnParentDrag = false;
            this.oc1.Name = "oc1";
            this.oc1.NodeEnlargeOnHover = true;
            this.oc1.Size = new System.Drawing.Size(834, 329);
            this.oc1.TabIndex = 2;
            this.oc1.TheCanvasObjects = ((System.Collections.Generic.List<TAIObjectCanvas2.CanvasObject>)(resources.GetObject("oc1.TheCanvasObjects")));
            this.oc1.HoverOverCanvas += new TAIObjectCanvas2.ObjectCanvas.HoverOverCanvasHandler(this.HandleHoverOverCanvas);
            this.oc1.HoverOverShape += new TAIObjectCanvas2.ObjectCanvas.HoverOverShapeHandler(this.HandleHoverOverShape);
            this.oc1.ShapeDoubleClicked += new TAIObjectCanvas2.ObjectCanvas.ShapeDoubleClickedHandler(this.HandleShapeDoubleClicked);
            // 
            // theTabs
            // 
            this.theTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.theTabs.Controls.Add(this.tbInterface);
            this.theTabs.Controls.Add(this.tbResult);
            this.theTabs.Location = new System.Drawing.Point(148, 56);
            this.theTabs.Name = "theTabs";
            this.theTabs.SelectedIndex = 0;
            this.theTabs.Size = new System.Drawing.Size(856, 676);
            this.theTabs.TabIndex = 11;
            // 
            // tbInterface
            // 
            this.tbInterface.Controls.Add(this.panel1);
            this.tbInterface.Location = new System.Drawing.Point(4, 22);
            this.tbInterface.Name = "tbInterface";
            this.tbInterface.Padding = new System.Windows.Forms.Padding(3);
            this.tbInterface.Size = new System.Drawing.Size(848, 650);
            this.tbInterface.TabIndex = 0;
            this.tbInterface.Text = "Interface";
            this.tbInterface.UseVisualStyleBackColor = true;
            // 
            // tbResult
            // 
            this.tbResult.Controls.Add(this.btnGraphResults);
            this.tbResult.Controls.Add(this.taigResults);
            this.tbResult.Location = new System.Drawing.Point(4, 22);
            this.tbResult.Name = "tbResult";
            this.tbResult.Padding = new System.Windows.Forms.Padding(3);
            this.tbResult.Size = new System.Drawing.Size(848, 650);
            this.tbResult.TabIndex = 1;
            this.tbResult.Text = "Results";
            this.tbResult.UseVisualStyleBackColor = true;
            // 
            // btnGraphResults
            // 
            this.btnGraphResults.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGraphResults.Location = new System.Drawing.Point(712, 0);
            this.btnGraphResults.Name = "btnGraphResults";
            this.btnGraphResults.Size = new System.Drawing.Size(133, 24);
            this.btnGraphResults.TabIndex = 22;
            this.btnGraphResults.Text = "Graph Results";
            this.btnGraphResults.UseVisualStyleBackColor = true;
            this.btnGraphResults.Click += new System.EventHandler(this.btnGraphResults_Click);
            // 
            // taigResults
            // 
            this.taigResults.AlternateColoration = false;
            this.taigResults.AlternateColorationAltColor = System.Drawing.Color.MediumSpringGreen;
            this.taigResults.AlternateColorationBaseColor = System.Drawing.Color.AntiqueWhite;
            this.taigResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.taigResults.BorderColor = System.Drawing.Color.Black;
            this.taigResults.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.taigResults.CellOutlines = true;
            this.taigResults.ColBackColorEdit = System.Drawing.Color.Yellow;
            this.taigResults.Cols = 0;
            this.taigResults.DefaultBackgroundColor = System.Drawing.Color.AntiqueWhite;
            this.taigResults.DefaultCellFont = new System.Drawing.Font("Arial", 9F);
            this.taigResults.DefaultForegroundColor = System.Drawing.Color.Black;
            this.taigResults.Delimiter = ",";
            this.taigResults.ExcelAlternateColoration = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(255)))), ((int)(((byte)(204)))));
            this.taigResults.ExcelAutoFitColumn = true;
            this.taigResults.ExcelAutoFitRow = true;
            this.taigResults.ExcelFilename = "";
            this.taigResults.ExcelIncludeColumnHeaders = true;
            this.taigResults.ExcelKeepAlive = true;
            this.taigResults.ExcelMatchGridColorScheme = true;
            this.taigResults.ExcelMaximized = true;
            this.taigResults.ExcelMaxRowsPerSheet = 30000;
            this.taigResults.ExcelOutlineCells = true;
            this.taigResults.ExcelPageOrientation = 1;
            this.taigResults.ExcelShowBorders = false;
            this.taigResults.ExcelUseAlternateRowColor = true;
            this.taigResults.ExcelWorksheetName = "Grid Output";
            this.taigResults.GridEditMode = TAIGridControl2.TAIGridControl.GridEditModes.KeyReturn;
            this.taigResults.GridHeaderBackColor = System.Drawing.Color.LightBlue;
            this.taigResults.GridHeaderFont = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.taigResults.GridHeaderForeColor = System.Drawing.Color.Black;
            this.taigResults.GridHeaderHeight = 16;
            stringFormat2.Alignment = System.Drawing.StringAlignment.Near;
            stringFormat2.HotkeyPrefix = System.Drawing.Text.HotkeyPrefix.None;
            stringFormat2.LineAlignment = System.Drawing.StringAlignment.Near;
            stringFormat2.Trimming = System.Drawing.StringTrimming.Character;
            this.taigResults.GridHeaderStringFormat = stringFormat2;
            this.taigResults.GridheaderVisible = true;
            this.taigResults.Location = new System.Drawing.Point(3, 24);
            this.taigResults.Name = "taigResults";
            this.taigResults.PageSettings = null;
            this.taigResults.PaginationSize = 0;
            this.taigResults.Rows = 0;
            this.taigResults.ScrollInterval = 5;
            this.taigResults.SelectedColBackColor = System.Drawing.Color.MediumSlateBlue;
            this.taigResults.SelectedColForeColor = System.Drawing.Color.LightGray;
            this.taigResults.SelectedColumn = -1;
            this.taigResults.SelectedRow = -1;
            this.taigResults.SelectedRowBackColor = System.Drawing.Color.Blue;
            this.taigResults.SelectedRowForeColor = System.Drawing.Color.White;
            this.taigResults.SelectedRows = ((System.Collections.ArrayList)(resources.GetObject("taigResults.SelectedRows")));
            this.taigResults.Size = new System.Drawing.Size(842, 623);
            this.taigResults.TabIndex = 0;
            this.taigResults.TitleBackColor = System.Drawing.Color.Blue;
            this.taigResults.TitleFont = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.taigResults.TitleForeColor = System.Drawing.Color.White;
            this.taigResults.TitleText = "Results";
            this.taigResults.TitleVisible = true;
            this.taigResults.XMLDataSetName = "Grid_Output";
            this.taigResults.XMLFileName = "";
            this.taigResults.XMLIncludeSchema = false;
            this.taigResults.XMLNameSpace = "TAI_Grid_Ouptut";
            this.taigResults.XMLTableName = "Table";
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.Location = new System.Drawing.Point(256, 30);
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.Size = new System.Drawing.Size(744, 20);
            this.txtConnectionString.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(160, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Connection String";
            // 
            // BtnConnect2AServer
            // 
            this.BtnConnect2AServer.Location = new System.Drawing.Point(8, 28);
            this.BtnConnect2AServer.Name = "BtnConnect2AServer";
            this.BtnConnect2AServer.Size = new System.Drawing.Size(132, 24);
            this.BtnConnect2AServer.TabIndex = 13;
            this.BtnConnect2AServer.Text = "Connect to a Server";
            this.BtnConnect2AServer.UseVisualStyleBackColor = true;
            this.BtnConnect2AServer.Click += new System.EventHandler(this.BtnConnect2AServer_Click);
            // 
            // btnSelectTableSource
            // 
            this.btnSelectTableSource.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnSelectTableSource.Location = new System.Drawing.Point(8, 92);
            this.btnSelectTableSource.Name = "btnSelectTableSource";
            this.btnSelectTableSource.Size = new System.Drawing.Size(132, 24);
            this.btnSelectTableSource.TabIndex = 14;
            this.btnSelectTableSource.Text = "Select Table Source";
            this.btnSelectTableSource.UseVisualStyleBackColor = false;
            this.btnSelectTableSource.Click += new System.EventHandler(this.btnSelectTableSource_Click);
            // 
            // btnExecute
            // 
            this.btnExecute.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnExecute.Location = new System.Drawing.Point(8, 440);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(132, 24);
            this.btnExecute.TabIndex = 15;
            this.btnExecute.Text = "Execute Query";
            this.btnExecute.UseVisualStyleBackColor = false;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // btlAddLookup
            // 
            this.btlAddLookup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btlAddLookup.Location = new System.Drawing.Point(8, 120);
            this.btlAddLookup.Name = "btlAddLookup";
            this.btlAddLookup.Size = new System.Drawing.Size(132, 24);
            this.btlAddLookup.TabIndex = 16;
            this.btlAddLookup.Text = "Add Lookup (Join)";
            this.btlAddLookup.UseVisualStyleBackColor = false;
            this.btlAddLookup.Click += new System.EventHandler(this.btlAddLookup_Click);
            // 
            // cm
            // 
            this.cm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.cm.Name = "cm";
            this.cm.Size = new System.Drawing.Size(108, 48);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click_1);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click_1);
            // 
            // btnAddCalculation
            // 
            this.btnAddCalculation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnAddCalculation.Location = new System.Drawing.Point(8, 176);
            this.btnAddCalculation.Name = "btnAddCalculation";
            this.btnAddCalculation.Size = new System.Drawing.Size(132, 24);
            this.btnAddCalculation.TabIndex = 17;
            this.btnAddCalculation.Text = "Add Calculation";
            this.btnAddCalculation.UseVisualStyleBackColor = false;
            this.btnAddCalculation.Click += new System.EventHandler(this.btnAddCalculation_Click);
            // 
            // btnAddRollup
            // 
            this.btnAddRollup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnAddRollup.Location = new System.Drawing.Point(7, 269);
            this.btnAddRollup.Name = "btnAddRollup";
            this.btnAddRollup.Size = new System.Drawing.Size(133, 24);
            this.btnAddRollup.TabIndex = 18;
            this.btnAddRollup.Text = "Add Rollup";
            this.btnAddRollup.UseVisualStyleBackColor = false;
            this.btnAddRollup.Click += new System.EventHandler(this.btnAddRollup_Click);
            // 
            // btnAddSyntheticField
            // 
            this.btnAddSyntheticField.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAddSyntheticField.Location = new System.Drawing.Point(8, 204);
            this.btnAddSyntheticField.Name = "btnAddSyntheticField";
            this.btnAddSyntheticField.Size = new System.Drawing.Size(132, 24);
            this.btnAddSyntheticField.TabIndex = 19;
            this.btnAddSyntheticField.Text = "Add Synthetic Field";
            this.btnAddSyntheticField.UseVisualStyleBackColor = false;
            this.btnAddSyntheticField.Click += new System.EventHandler(this.btnAddSyntheticField_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.informationToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1008, 24);
            this.menuStrip1.TabIndex = 20;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // informationToolStripMenuItem
            // 
            this.informationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.versionToolStripMenuItem,
            this.currentQueryToolStripMenuItem});
            this.informationToolStripMenuItem.Name = "informationToolStripMenuItem";
            this.informationToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.informationToolStripMenuItem.Text = "Information";
            // 
            // versionToolStripMenuItem
            // 
            this.versionToolStripMenuItem.Name = "versionToolStripMenuItem";
            this.versionToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.versionToolStripMenuItem.Text = "Version";
            this.versionToolStripMenuItem.Click += new System.EventHandler(this.versionToolStripMenuItem_Click);
            // 
            // currentQueryToolStripMenuItem
            // 
            this.currentQueryToolStripMenuItem.Name = "currentQueryToolStripMenuItem";
            this.currentQueryToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.currentQueryToolStripMenuItem.Text = "Current Query";
            this.currentQueryToolStripMenuItem.Click += new System.EventHandler(this.currentQueryToolStripMenuItem_Click);
            // 
            // ofd
            // 
            this.ofd.FileName = "openFileDialog1";
            // 
            // btnClearCurrentQuery
            // 
            this.btnClearCurrentQuery.Location = new System.Drawing.Point(7, 57);
            this.btnClearCurrentQuery.Name = "btnClearCurrentQuery";
            this.btnClearCurrentQuery.Size = new System.Drawing.Size(133, 24);
            this.btnClearCurrentQuery.TabIndex = 21;
            this.btnClearCurrentQuery.Text = "Clear Current Query";
            this.btnClearCurrentQuery.UseVisualStyleBackColor = true;
            this.btnClearCurrentQuery.Click += new System.EventHandler(this.btnClearCurrentQuery_Click);
            // 
            // btnAddFilter
            // 
            this.btnAddFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnAddFilter.Location = new System.Drawing.Point(8, 296);
            this.btnAddFilter.Name = "btnAddFilter";
            this.btnAddFilter.Size = new System.Drawing.Size(132, 24);
            this.btnAddFilter.TabIndex = 22;
            this.btnAddFilter.Text = "Add Filter";
            this.btnAddFilter.UseVisualStyleBackColor = false;
            this.btnAddFilter.Click += new System.EventHandler(this.btnAddFilter_Click);
            // 
            // btnAddConstraint
            // 
            this.btnAddConstraint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnAddConstraint.Location = new System.Drawing.Point(7, 324);
            this.btnAddConstraint.Name = "btnAddConstraint";
            this.btnAddConstraint.Size = new System.Drawing.Size(133, 24);
            this.btnAddConstraint.TabIndex = 23;
            this.btnAddConstraint.Text = "Add Constraint";
            this.btnAddConstraint.UseVisualStyleBackColor = false;
            this.btnAddConstraint.Click += new System.EventHandler(this.btnAddConstraint_Click);
            // 
            // btnAddLimiter
            // 
            this.btnAddLimiter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnAddLimiter.Location = new System.Drawing.Point(7, 232);
            this.btnAddLimiter.Name = "btnAddLimiter";
            this.btnAddLimiter.Size = new System.Drawing.Size(133, 24);
            this.btnAddLimiter.TabIndex = 24;
            this.btnAddLimiter.Text = "Add Limiter Field";
            this.btnAddLimiter.UseVisualStyleBackColor = false;
            this.btnAddLimiter.Click += new System.EventHandler(this.btnAddLimiter_Click);
            // 
            // btnAddSortOperation
            // 
            this.btnAddSortOperation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnAddSortOperation.Location = new System.Drawing.Point(7, 352);
            this.btnAddSortOperation.Name = "btnAddSortOperation";
            this.btnAddSortOperation.Size = new System.Drawing.Size(133, 24);
            this.btnAddSortOperation.TabIndex = 25;
            this.btnAddSortOperation.Text = "Add Sorting Ops";
            this.btnAddSortOperation.UseVisualStyleBackColor = false;
            this.btnAddSortOperation.Click += new System.EventHandler(this.btnAddSortOperation_Click);
            // 
            // btnHCLookup
            // 
            this.btnHCLookup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnHCLookup.Location = new System.Drawing.Point(8, 148);
            this.btnHCLookup.Name = "btnHCLookup";
            this.btnHCLookup.Size = new System.Drawing.Size(132, 24);
            this.btnHCLookup.TabIndex = 26;
            this.btnHCLookup.Text = "Add HCLookup (select)";
            this.btnHCLookup.UseVisualStyleBackColor = false;
            this.btnHCLookup.Click += new System.EventHandler(this.btnHCLookup_Click);
            // 
            // tbarFontSize
            // 
            this.tbarFontSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbarFontSize.Location = new System.Drawing.Point(101, 621);
            this.tbarFontSize.Maximum = 16;
            this.tbarFontSize.Minimum = 6;
            this.tbarFontSize.Name = "tbarFontSize";
            this.tbarFontSize.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbarFontSize.Size = new System.Drawing.Size(45, 104);
            this.tbarFontSize.TabIndex = 27;
            this.tbarFontSize.Value = 12;
            this.tbarFontSize.Scroll += new System.EventHandler(this.HandletBarScroll);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(85, 614);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Font Size";
            // 
            // btnAdd_Distinct
            // 
            this.btnAdd_Distinct.BackColor = System.Drawing.Color.SkyBlue;
            this.btnAdd_Distinct.Location = new System.Drawing.Point(7, 382);
            this.btnAdd_Distinct.Name = "btnAdd_Distinct";
            this.btnAdd_Distinct.Size = new System.Drawing.Size(133, 24);
            this.btnAdd_Distinct.TabIndex = 29;
            this.btnAdd_Distinct.Text = "Add Distinct";
            this.btnAdd_Distinct.UseVisualStyleBackColor = false;
            this.btnAdd_Distinct.Click += new System.EventHandler(this.btnAdd_Distinct_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.btnAdd_Distinct);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbarFontSize);
            this.Controls.Add(this.btnHCLookup);
            this.Controls.Add(this.btnAddSortOperation);
            this.Controls.Add(this.btnAddLimiter);
            this.Controls.Add(this.btnAddConstraint);
            this.Controls.Add(this.btnAddFilter);
            this.Controls.Add(this.btnClearCurrentQuery);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.btnAddSyntheticField);
            this.Controls.Add(this.btnAddRollup);
            this.Controls.Add(this.btnAddCalculation);
            this.Controls.Add(this.btlAddLookup);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.btnSelectTableSource);
            this.Controls.Add(this.BtnConnect2AServer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtConnectionString);
            this.Controls.Add(this.theTabs);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "Query Reporter ";
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.theTabs.ResumeLayout(false);
            this.tbInterface.ResumeLayout(false);
            this.tbResult.ResumeLayout(false);
            this.cm.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbarFontSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TAISyntaxColorizer.TAISyntaxColorizer tais;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private TAIObjectCanvas2.ObjectCanvas oc1;
        private System.Windows.Forms.TabControl theTabs;
        private System.Windows.Forms.TabPage tbInterface;
        private System.Windows.Forms.TabPage tbResult;
        private TAIGridControl2.TAIGridControl taigResults;
        private System.Windows.Forms.TextBox txtConnectionString;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnConnect2AServer;
        private System.Windows.Forms.Button btnSelectTableSource;
        private System.Windows.Forms.ToolTip ttip;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.Button btlAddLookup;
        private System.Windows.Forms.ContextMenuStrip cm;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Button btnAddCalculation;
        private System.Windows.Forms.Button btnAddRollup;
        private System.Windows.Forms.Button btnAddSyntheticField;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem versionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem currentQueryToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog sfd;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.Button btnClearCurrentQuery;
        private System.Windows.Forms.Button btnAddFilter;
        private System.Windows.Forms.Button btnAddConstraint;
        private System.Windows.Forms.Button btnAddLimiter;
        private System.Windows.Forms.Button btnAddSortOperation;
        private System.Windows.Forms.Button btnHCLookup;
        private System.Windows.Forms.Button btnGraphResults;
        private System.Windows.Forms.TrackBar tbarFontSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdd_Distinct;
    }
}

