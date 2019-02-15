namespace SimatSoft.ReportManagerWinForm
{
    partial class Form_MainReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_MainReport));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_PreviewReport = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton20 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.Reportname = new System.Windows.Forms.ToolStripComboBox();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.classComboBox1 = new SimatSoft.ControlBasic.ClassComboBox();
            this.simatDateTimeSelect1 = new SimatSoft.ControlBasic.SimatDateTimeSelect();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer1.Size = new System.Drawing.Size(1284, 713);
            this.splitContainer1.SplitterDistance = 39;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 7;
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_PreviewReport,
            this.toolStripSeparator10,
            this.toolStripButton1,
            this.toolStripSeparator12,
            this.toolStripButton20,
            this.toolStripSplitButton1,
            this.Reportname});
            this.toolStrip2.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1284, 26);
            this.toolStrip2.TabIndex = 7;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButton_PreviewReport
            // 
            this.toolStripButton_PreviewReport.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_PreviewReport.Image")));
            this.toolStripButton_PreviewReport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_PreviewReport.Name = "toolStripButton_PreviewReport";
            this.toolStripButton_PreviewReport.Size = new System.Drawing.Size(100, 23);
            this.toolStripButton_PreviewReport.Text = "Print report";
            this.toolStripButton_PreviewReport.Click += new System.EventHandler(this.toolStripButton_PreviewReport_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 26);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(51, 23);
            this.toolStripButton1.Text = "Exit";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click_1);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(6, 26);
            // 
            // toolStripButton20
            // 
            this.toolStripButton20.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.toolStripButton20.Name = "toolStripButton20";
            this.toolStripButton20.Size = new System.Drawing.Size(97, 23);
            this.toolStripButton20.Text = "Report name";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Overflow = System.Windows.Forms.ToolStripItemOverflow.Always;
            this.toolStripSplitButton1.Size = new System.Drawing.Size(181, 22);
            this.toolStripSplitButton1.Text = "&Add or Remove Buttons";
            // 
            // Reportname
            // 
            this.Reportname.Name = "Reportname";
            this.Reportname.Size = new System.Drawing.Size(332, 26);
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.AutoScroll = true;
            this.splitContainer4.Panel1.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.splitContainer4.Panel1.Controls.Add(this.classComboBox1);
            this.splitContainer4.Panel1.Controls.Add(this.simatDateTimeSelect1);
            this.splitContainer4.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer4_Panel1_Paint);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.crystalReportViewer1);
            this.splitContainer4.Size = new System.Drawing.Size(1284, 673);
            this.splitContainer4.SplitterDistance = 155;
            this.splitContainer4.SplitterWidth = 1;
            this.splitContainer4.TabIndex = 6;
            // 
            // classComboBox1
            // 
            this.classComboBox1.FormattingEnabled = true;
            this.classComboBox1.Location = new System.Drawing.Point(633, 47);
            this.classComboBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.classComboBox1.Name = "classComboBox1";
            this.classComboBox1.Size = new System.Drawing.Size(183, 24);
            this.classComboBox1.TabIndex = 5;
            this.classComboBox1.Visible = false;
            // 
            // simatDateTimeSelect1
            // 
            this.simatDateTimeSelect1.Location = new System.Drawing.Point(395, 47);
            this.simatDateTimeSelect1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.simatDateTimeSelect1.Name = "simatDateTimeSelect1";
            this.simatDateTimeSelect1.Size = new System.Drawing.Size(192, 26);
            this.simatDateTimeSelect1.TabIndex = 0;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.SelectionFormula = "";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1284, 517);
            this.crystalReportViewer1.TabIndex = 4;
            this.crystalReportViewer1.ViewTimeSelectionFormula = "";
            this.crystalReportViewer1.Visible = false;
            // 
            // Form_MainReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 713);
            this.Controls.Add(this.splitContainer1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form_MainReport";
            this.Text = "Main Report";
            this.Deactivate += new System.EventHandler(this.Form_MainReport_Deactivate);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_MainReport_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_MainReport_FormClosing);
            this.Load += new System.EventHandler(this.Form_MainReport_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton_PreviewReport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripButton toolStripButton20;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.ToolStripComboBox Reportname;
        private SimatSoft.ControlBasic.SimatDateTimeSelect simatDateTimeSelect1;
        private SimatSoft.ControlBasic.ClassComboBox classComboBox1;

    }
}