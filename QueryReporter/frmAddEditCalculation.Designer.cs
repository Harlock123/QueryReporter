namespace TAIQueryReporter
{
    partial class frmAddEditCalculation
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.rbSum = new System.Windows.Forms.RadioButton();
            this.rbCount = new System.Windows.Forms.RadioButton();
            this.rbDistinctCount = new System.Windows.Forms.RadioButton();
            this.rbAverage = new System.Windows.Forms.RadioButton();
            this.rbMinimum = new System.Windows.Forms.RadioButton();
            this.rbMaximum = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.lbFields = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbSelFields = new System.Windows.Forms.ListBox();
            this.btnTo = new System.Windows.Forms.Button();
            this.btnFrom = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtCalc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAlias = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbPreMoney = new System.Windows.Forms.RadioButton();
            this.rbPreInteger = new System.Windows.Forms.RadioButton();
            this.rbPreNone = new System.Windows.Forms.RadioButton();
            this.rbPreVarChar = new System.Windows.Forms.RadioButton();
            this.rbPreDateTime = new System.Windows.Forms.RadioButton();
            this.rbStDev = new System.Windows.Forms.RadioButton();
            this.rbStDevP = new System.Windows.Forms.RadioButton();
            this.rbVar = new System.Windows.Forms.RadioButton();
            this.rbVarP = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(548, 380);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 0;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(548, 404);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // rbSum
            // 
            this.rbSum.AutoSize = true;
            this.rbSum.Location = new System.Drawing.Point(20, 12);
            this.rbSum.Name = "rbSum";
            this.rbSum.Size = new System.Drawing.Size(46, 17);
            this.rbSum.TabIndex = 2;
            this.rbSum.TabStop = true;
            this.rbSum.Text = "Sum";
            this.rbSum.UseVisualStyleBackColor = true;
            this.rbSum.CheckedChanged += new System.EventHandler(this.rbSum_CheckedChanged);
            // 
            // rbCount
            // 
            this.rbCount.AutoSize = true;
            this.rbCount.Location = new System.Drawing.Point(20, 32);
            this.rbCount.Name = "rbCount";
            this.rbCount.Size = new System.Drawing.Size(53, 17);
            this.rbCount.TabIndex = 3;
            this.rbCount.TabStop = true;
            this.rbCount.Text = "Count";
            this.rbCount.UseVisualStyleBackColor = true;
            this.rbCount.CheckedChanged += new System.EventHandler(this.rbCount_CheckedChanged);
            // 
            // rbDistinctCount
            // 
            this.rbDistinctCount.AutoSize = true;
            this.rbDistinctCount.Location = new System.Drawing.Point(20, 52);
            this.rbDistinctCount.Name = "rbDistinctCount";
            this.rbDistinctCount.Size = new System.Drawing.Size(91, 17);
            this.rbDistinctCount.TabIndex = 4;
            this.rbDistinctCount.TabStop = true;
            this.rbDistinctCount.Text = "Distinct Count";
            this.rbDistinctCount.UseVisualStyleBackColor = true;
            this.rbDistinctCount.CheckedChanged += new System.EventHandler(this.rbDistinctCount_CheckedChanged);
            // 
            // rbAverage
            // 
            this.rbAverage.AutoSize = true;
            this.rbAverage.Location = new System.Drawing.Point(20, 72);
            this.rbAverage.Name = "rbAverage";
            this.rbAverage.Size = new System.Drawing.Size(65, 17);
            this.rbAverage.TabIndex = 5;
            this.rbAverage.TabStop = true;
            this.rbAverage.Text = "Average";
            this.rbAverage.UseVisualStyleBackColor = true;
            this.rbAverage.CheckedChanged += new System.EventHandler(this.rbAverage_CheckedChanged);
            // 
            // rbMinimum
            // 
            this.rbMinimum.AutoSize = true;
            this.rbMinimum.Location = new System.Drawing.Point(20, 92);
            this.rbMinimum.Name = "rbMinimum";
            this.rbMinimum.Size = new System.Drawing.Size(66, 17);
            this.rbMinimum.TabIndex = 6;
            this.rbMinimum.TabStop = true;
            this.rbMinimum.Text = "Minimum";
            this.rbMinimum.UseVisualStyleBackColor = true;
            this.rbMinimum.CheckedChanged += new System.EventHandler(this.rbMinimum_CheckedChanged);
            // 
            // rbMaximum
            // 
            this.rbMaximum.AutoSize = true;
            this.rbMaximum.Location = new System.Drawing.Point(20, 112);
            this.rbMaximum.Name = "rbMaximum";
            this.rbMaximum.Size = new System.Drawing.Size(69, 17);
            this.rbMaximum.TabIndex = 7;
            this.rbMaximum.TabStop = true;
            this.rbMaximum.Text = "Maximum";
            this.rbMaximum.UseVisualStyleBackColor = true;
            this.rbMaximum.CheckedChanged += new System.EventHandler(this.rbMaximum_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(136, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Available Fields For Calculation";
            // 
            // lbFields
            // 
            this.lbFields.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lbFields.FormattingEnabled = true;
            this.lbFields.Location = new System.Drawing.Point(136, 20);
            this.lbFields.Name = "lbFields";
            this.lbFields.Size = new System.Drawing.Size(220, 329);
            this.lbFields.TabIndex = 11;
            this.lbFields.SelectedIndexChanged += new System.EventHandler(this.lbFields_SelectedIndexChanged);
            this.lbFields.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.HandleFieldDoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(400, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Selected Fields For Calculation";
            // 
            // lbSelFields
            // 
            this.lbSelFields.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.lbSelFields.FormattingEnabled = true;
            this.lbSelFields.Location = new System.Drawing.Point(400, 20);
            this.lbSelFields.Name = "lbSelFields";
            this.lbSelFields.Size = new System.Drawing.Size(224, 329);
            this.lbSelFields.TabIndex = 13;
            this.lbSelFields.SelectedIndexChanged += new System.EventHandler(this.lbSelFields_MouseClicked);
            this.lbSelFields.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.HandleSelectedDoubleClick);
            // 
            // btnTo
            // 
            this.btnTo.Location = new System.Drawing.Point(360, 92);
            this.btnTo.Name = "btnTo";
            this.btnTo.Size = new System.Drawing.Size(36, 24);
            this.btnTo.TabIndex = 15;
            this.btnTo.Text = ">";
            this.btnTo.UseVisualStyleBackColor = true;
            this.btnTo.Click += new System.EventHandler(this.btnTo_Click);
            // 
            // btnFrom
            // 
            this.btnFrom.Location = new System.Drawing.Point(360, 120);
            this.btnFrom.Name = "btnFrom";
            this.btnFrom.Size = new System.Drawing.Size(36, 24);
            this.btnFrom.TabIndex = 16;
            this.btnFrom.Text = "<";
            this.btnFrom.UseVisualStyleBackColor = true;
            this.btnFrom.Click += new System.EventHandler(this.btnFrom_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(360, 156);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(36, 24);
            this.btnClear.TabIndex = 17;
            this.btnClear.Text = "Clr";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtCalc
            // 
            this.txtCalc.Location = new System.Drawing.Point(4, 392);
            this.txtCalc.Name = "txtCalc";
            this.txtCalc.Size = new System.Drawing.Size(536, 20);
            this.txtCalc.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 416);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Calculation";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 376);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Calculation Alias";
            // 
            // txtAlias
            // 
            this.txtAlias.Location = new System.Drawing.Point(4, 352);
            this.txtAlias.Name = "txtAlias";
            this.txtAlias.Size = new System.Drawing.Size(196, 20);
            this.txtAlias.TabIndex = 20;
            this.txtAlias.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbPreDateTime);
            this.groupBox1.Controls.Add(this.rbPreVarChar);
            this.groupBox1.Controls.Add(this.rbPreNone);
            this.groupBox1.Controls.Add(this.rbPreInteger);
            this.groupBox1.Controls.Add(this.rbPreMoney);
            this.groupBox1.Location = new System.Drawing.Point(7, 224);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(117, 122);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Preconvert options";
            // 
            // rbPreMoney
            // 
            this.rbPreMoney.AutoSize = true;
            this.rbPreMoney.Location = new System.Drawing.Point(24, 39);
            this.rbPreMoney.Name = "rbPreMoney";
            this.rbPreMoney.Size = new System.Drawing.Size(57, 17);
            this.rbPreMoney.TabIndex = 0;
            this.rbPreMoney.Text = "Money";
            this.rbPreMoney.UseVisualStyleBackColor = true;
            this.rbPreMoney.CheckedChanged += new System.EventHandler(this.HandlePreconvertCheckChanged);
            // 
            // rbPreInteger
            // 
            this.rbPreInteger.AutoSize = true;
            this.rbPreInteger.Location = new System.Drawing.Point(24, 59);
            this.rbPreInteger.Name = "rbPreInteger";
            this.rbPreInteger.Size = new System.Drawing.Size(58, 17);
            this.rbPreInteger.TabIndex = 1;
            this.rbPreInteger.Text = "Integer";
            this.rbPreInteger.UseVisualStyleBackColor = true;
            this.rbPreInteger.CheckedChanged += new System.EventHandler(this.HandlePreconvertCheckChanged);
            // 
            // rbPreNone
            // 
            this.rbPreNone.AutoSize = true;
            this.rbPreNone.Checked = true;
            this.rbPreNone.Location = new System.Drawing.Point(24, 19);
            this.rbPreNone.Name = "rbPreNone";
            this.rbPreNone.Size = new System.Drawing.Size(51, 17);
            this.rbPreNone.TabIndex = 2;
            this.rbPreNone.TabStop = true;
            this.rbPreNone.Text = "None";
            this.rbPreNone.UseVisualStyleBackColor = true;
            this.rbPreNone.CheckedChanged += new System.EventHandler(this.HandlePreconvertCheckChanged);
            // 
            // rbPreVarChar
            // 
            this.rbPreVarChar.AutoSize = true;
            this.rbPreVarChar.Location = new System.Drawing.Point(24, 79);
            this.rbPreVarChar.Name = "rbPreVarChar";
            this.rbPreVarChar.Size = new System.Drawing.Size(63, 17);
            this.rbPreVarChar.TabIndex = 3;
            this.rbPreVarChar.Text = "VarChar";
            this.rbPreVarChar.UseVisualStyleBackColor = true;
            this.rbPreVarChar.CheckedChanged += new System.EventHandler(this.HandlePreconvertCheckChanged);
            // 
            // rbPreDateTime
            // 
            this.rbPreDateTime.AutoSize = true;
            this.rbPreDateTime.Location = new System.Drawing.Point(24, 99);
            this.rbPreDateTime.Name = "rbPreDateTime";
            this.rbPreDateTime.Size = new System.Drawing.Size(71, 17);
            this.rbPreDateTime.TabIndex = 4;
            this.rbPreDateTime.Text = "DateTime";
            this.rbPreDateTime.UseVisualStyleBackColor = true;
            this.rbPreDateTime.CheckedChanged += new System.EventHandler(this.HandlePreconvertCheckChanged);
            // 
            // rbStDev
            // 
            this.rbStDev.AutoSize = true;
            this.rbStDev.Location = new System.Drawing.Point(20, 132);
            this.rbStDev.Name = "rbStDev";
            this.rbStDev.Size = new System.Drawing.Size(53, 17);
            this.rbStDev.TabIndex = 23;
            this.rbStDev.TabStop = true;
            this.rbStDev.Text = "Stdev";
            this.rbStDev.UseVisualStyleBackColor = true;
            // 
            // rbStDevP
            // 
            this.rbStDevP.AutoSize = true;
            this.rbStDevP.Location = new System.Drawing.Point(20, 152);
            this.rbStDevP.Name = "rbStDevP";
            this.rbStDevP.Size = new System.Drawing.Size(60, 17);
            this.rbStDevP.TabIndex = 24;
            this.rbStDevP.TabStop = true;
            this.rbStDevP.Text = "StdevP";
            this.rbStDevP.UseVisualStyleBackColor = true;
            // 
            // rbVar
            // 
            this.rbVar.AutoSize = true;
            this.rbVar.Location = new System.Drawing.Point(20, 172);
            this.rbVar.Name = "rbVar";
            this.rbVar.Size = new System.Drawing.Size(41, 17);
            this.rbVar.TabIndex = 25;
            this.rbVar.TabStop = true;
            this.rbVar.Text = "Var";
            this.rbVar.UseVisualStyleBackColor = true;
            // 
            // rbVarP
            // 
            this.rbVarP.AutoSize = true;
            this.rbVarP.Location = new System.Drawing.Point(20, 192);
            this.rbVarP.Name = "rbVarP";
            this.rbVarP.Size = new System.Drawing.Size(48, 17);
            this.rbVarP.TabIndex = 26;
            this.rbVarP.TabStop = true;
            this.rbVarP.Text = "VarP";
            this.rbVarP.UseVisualStyleBackColor = true;
            // 
            // frmAddEditCalculation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(629, 432);
            this.ControlBox = false;
            this.Controls.Add(this.rbVarP);
            this.Controls.Add(this.rbVar);
            this.Controls.Add(this.rbStDevP);
            this.Controls.Add(this.rbStDev);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAlias);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCalc);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnFrom);
            this.Controls.Add(this.btnTo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbSelFields);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbFields);
            this.Controls.Add(this.rbMaximum);
            this.Controls.Add(this.rbMinimum);
            this.Controls.Add(this.rbAverage);
            this.Controls.Add(this.rbDistinctCount);
            this.Controls.Add(this.rbCount);
            this.Controls.Add(this.rbSum);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Name = "frmAddEditCalculation";
            this.Text = "Add/Edit Calculated Field";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.RadioButton rbSum;
        private System.Windows.Forms.RadioButton rbCount;
        private System.Windows.Forms.RadioButton rbDistinctCount;
        private System.Windows.Forms.RadioButton rbAverage;
        private System.Windows.Forms.RadioButton rbMinimum;
        private System.Windows.Forms.RadioButton rbMaximum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbFields;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lbSelFields;
        private System.Windows.Forms.Button btnTo;
        private System.Windows.Forms.Button btnFrom;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtCalc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAlias;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbPreInteger;
        private System.Windows.Forms.RadioButton rbPreMoney;
        private System.Windows.Forms.RadioButton rbPreVarChar;
        private System.Windows.Forms.RadioButton rbPreNone;
        private System.Windows.Forms.RadioButton rbPreDateTime;
        private System.Windows.Forms.RadioButton rbStDev;
        private System.Windows.Forms.RadioButton rbStDevP;
        private System.Windows.Forms.RadioButton rbVar;
        private System.Windows.Forms.RadioButton rbVarP;
    }
}
