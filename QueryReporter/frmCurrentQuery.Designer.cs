namespace TAIQueryReporter
{
    partial class frmCurrentQuery
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCurrentQuery));
            this.tais = new TAISyntaxColorizer.TAISyntaxColorizer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tais
            // 
            this.tais.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tais.AutoSize = true;
            this.tais.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.tais.ConstantKeyWords = "MONEY,BIGINT,DATETIME,VARCHAR,YEAR,QUARTER,MONTH,DAYOFYEAR,DAY,WEEK,WEEKDAY,HOUR," +
                "MINUTE,SECOND,MILLISECOND,YY,QQ,MM,DY,DD,WK,DW,HH,MI,SS,MS";
            this.tais.FunctionKeyWords = resources.GetString("tais.FunctionKeyWords");
            this.tais.KeyWords = "SELECT,FROM,WHERE,ORDER,GROUP,BY,TOP,LIMIT,AS,ASC,DESC,AND,OR,NOT,NULL,IS,IN,LIKE" +
                ",LEFT,RIGHT,FULL,INNER,OUTER,JOIN,ON,CASE,WHEN,THEN,ELSE,END,HAVING";
            this.tais.Location = new System.Drawing.Point(9, 9);
            this.tais.MatchCase = false;
            this.tais.Name = "tais";
            this.tais.Size = new System.Drawing.Size(735, 425);
            this.tais.TabIndex = 0;
            this.tais.WhiteSpaceMatch = "[^\\,\\?\\|\\[\\]\\(\\)\\{\\}\\$\\n\\r\\t\\v\\x20]+";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tais);
            this.panel1.Location = new System.Drawing.Point(10, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(754, 446);
            this.panel1.TabIndex = 1;
            // 
            // frmCurrentQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(777, 479);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(793, 517);
            this.Name = "frmCurrentQuery";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Text = "Current Query";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TAISyntaxColorizer.TAISyntaxColorizer tais;
        private System.Windows.Forms.Panel panel1;
    }
}