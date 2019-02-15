namespace SimatSoft.FixAsset
{
    partial class Form_002010_Department
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.sS_DataGridView_Department = new SimatSoft.CustomControl.SS_DataGridView();
            this.panel_Department = new System.Windows.Forms.Panel();
            this.sS_MaskedTextBox_FacName = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.LBL_CompanyNo = new System.Windows.Forms.Label();
            this.sS_MaskedTextBox_FacilityNo = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.sS_MaskedTextBox_DepartmentName = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.LBL_DepartmentName = new System.Windows.Forms.Label();
            this.LBL_DepartmentNo = new System.Windows.Forms.Label();
            this.sS_MaskedTextBox_DepartmentNo = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_Record = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sS_DataGridView_Department)).BeginInit();
            this.panel_Department.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.sS_DataGridView_Department);
            this.panel2.Location = new System.Drawing.Point(4, 137);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(583, 340);
            this.panel2.TabIndex = 7;
            // 
            // sS_DataGridView_Department
            // 
            this.sS_DataGridView_Department.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.sS_DataGridView_Department.BackColorCellFocus = System.Drawing.Color.LightBlue;
            this.sS_DataGridView_Department.BackColorCellLeave = System.Drawing.Color.Honeydew;
            this.sS_DataGridView_Department.BackColorRow = System.Drawing.Color.HotPink;
            this.sS_DataGridView_Department.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sS_DataGridView_Department.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sS_DataGridView_Department.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sS_DataGridView_Department.Location = new System.Drawing.Point(0, 0);
            this.sS_DataGridView_Department.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sS_DataGridView_Department.Name = "sS_DataGridView_Department";
            this.sS_DataGridView_Department.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.sS_DataGridView_Department.Size = new System.Drawing.Size(579, 336);
            this.sS_DataGridView_Department.TabIndex = 0;
            this.sS_DataGridView_Department.Click += new System.EventHandler(this.sS_DataGridView_Department_Click);
            // 
            // panel_Department
            // 
            this.panel_Department.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_Department.BackColor = System.Drawing.Color.Transparent;
            this.panel_Department.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_Department.Controls.Add(this.sS_MaskedTextBox_FacName);
            this.panel_Department.Controls.Add(this.LBL_CompanyNo);
            this.panel_Department.Controls.Add(this.sS_MaskedTextBox_FacilityNo);
            this.panel_Department.Controls.Add(this.sS_MaskedTextBox_DepartmentName);
            this.panel_Department.Controls.Add(this.LBL_DepartmentName);
            this.panel_Department.Controls.Add(this.LBL_DepartmentNo);
            this.panel_Department.Controls.Add(this.sS_MaskedTextBox_DepartmentNo);
            this.panel_Department.Location = new System.Drawing.Point(3, 5);
            this.panel_Department.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel_Department.Name = "panel_Department";
            this.panel_Department.Size = new System.Drawing.Size(584, 123);
            this.panel_Department.TabIndex = 6;
            // 
            // sS_MaskedTextBox_FacName
            // 
            this.sS_MaskedTextBox_FacName.BackColor = System.Drawing.Color.LightCyan;
            this.sS_MaskedTextBox_FacName.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_FacName.BackColorOnLeave = System.Drawing.Color.LightCyan;
            this.sS_MaskedTextBox_FacName.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_FacName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_FacName.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_FacName.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_FacName.IconError = null;
            this.sS_MaskedTextBox_FacName.IconTrue = null;
            this.sS_MaskedTextBox_FacName.Location = new System.Drawing.Point(371, 76);
            this.sS_MaskedTextBox_FacName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sS_MaskedTextBox_FacName.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_FacName.Name = "sS_MaskedTextBox_FacName";
            this.sS_MaskedTextBox_FacName.ReadOnly = true;
            this.sS_MaskedTextBox_FacName.Size = new System.Drawing.Size(200, 26);
            this.sS_MaskedTextBox_FacName.TabIndex = 7;
            this.sS_MaskedTextBox_FacName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sS_MaskedTextBox_FacilityNo_KeyDown);
            // 
            // LBL_CompanyNo
            // 
            this.LBL_CompanyNo.AutoSize = true;
            this.LBL_CompanyNo.ForeColor = System.Drawing.Color.Black;
            this.LBL_CompanyNo.Location = new System.Drawing.Point(20, 76);
            this.LBL_CompanyNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBL_CompanyNo.Name = "LBL_CompanyNo";
            this.LBL_CompanyNo.Size = new System.Drawing.Size(71, 17);
            this.LBL_CompanyNo.TabIndex = 6;
            this.LBL_CompanyNo.Text = "Company:";
            // 
            // sS_MaskedTextBox_FacilityNo
            // 
            this.sS_MaskedTextBox_FacilityNo.BackColor = System.Drawing.Color.Lavender;
            this.sS_MaskedTextBox_FacilityNo.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_FacilityNo.BackColorOnLeave = System.Drawing.Color.Lavender;
            this.sS_MaskedTextBox_FacilityNo.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_FacilityNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_FacilityNo.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_FacilityNo.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_FacilityNo.IconError = null;
            this.sS_MaskedTextBox_FacilityNo.IconTrue = null;
            this.sS_MaskedTextBox_FacilityNo.Location = new System.Drawing.Point(167, 76);
            this.sS_MaskedTextBox_FacilityNo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sS_MaskedTextBox_FacilityNo.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_FacilityNo.Name = "sS_MaskedTextBox_FacilityNo";
            this.sS_MaskedTextBox_FacilityNo.ReadOnly = true;
            this.sS_MaskedTextBox_FacilityNo.Size = new System.Drawing.Size(199, 26);
            this.sS_MaskedTextBox_FacilityNo.TabIndex = 3;
            this.sS_MaskedTextBox_FacilityNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sS_MaskedTextBox_FacilityNo_KeyDown);
            // 
            // sS_MaskedTextBox_DepartmentName
            // 
            this.sS_MaskedTextBox_DepartmentName.BackColor = System.Drawing.Color.Lavender;
            this.sS_MaskedTextBox_DepartmentName.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_DepartmentName.BackColorOnLeave = System.Drawing.Color.Lavender;
            this.sS_MaskedTextBox_DepartmentName.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_DepartmentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_DepartmentName.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_DepartmentName.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_DepartmentName.IconError = null;
            this.sS_MaskedTextBox_DepartmentName.IconTrue = null;
            this.sS_MaskedTextBox_DepartmentName.Location = new System.Drawing.Point(167, 46);
            this.sS_MaskedTextBox_DepartmentName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sS_MaskedTextBox_DepartmentName.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_DepartmentName.Name = "sS_MaskedTextBox_DepartmentName";
            this.sS_MaskedTextBox_DepartmentName.Size = new System.Drawing.Size(404, 26);
            this.sS_MaskedTextBox_DepartmentName.TabIndex = 2;
            this.sS_MaskedTextBox_DepartmentName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.sS_MaskedTextBox_DepartmentName_KeyPress);
            // 
            // LBL_DepartmentName
            // 
            this.LBL_DepartmentName.AutoSize = true;
            this.LBL_DepartmentName.Location = new System.Drawing.Point(20, 46);
            this.LBL_DepartmentName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBL_DepartmentName.Name = "LBL_DepartmentName";
            this.LBL_DepartmentName.Size = new System.Drawing.Size(127, 17);
            this.LBL_DepartmentName.TabIndex = 2;
            this.LBL_DepartmentName.Text = "Department Name:";
            // 
            // LBL_DepartmentNo
            // 
            this.LBL_DepartmentNo.AutoSize = true;
            this.LBL_DepartmentNo.Location = new System.Drawing.Point(20, 14);
            this.LBL_DepartmentNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBL_DepartmentNo.Name = "LBL_DepartmentNo";
            this.LBL_DepartmentNo.Size = new System.Drawing.Size(108, 17);
            this.LBL_DepartmentNo.TabIndex = 2;
            this.LBL_DepartmentNo.Text = "Department No:";
            // 
            // sS_MaskedTextBox_DepartmentNo
            // 
            this.sS_MaskedTextBox_DepartmentNo.BackColor = System.Drawing.Color.Honeydew;
            this.sS_MaskedTextBox_DepartmentNo.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_DepartmentNo.BackColorOnLeave = System.Drawing.Color.Honeydew;
            this.sS_MaskedTextBox_DepartmentNo.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_DepartmentNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_DepartmentNo.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_DepartmentNo.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_DepartmentNo.IconError = null;
            this.sS_MaskedTextBox_DepartmentNo.IconTrue = null;
            this.sS_MaskedTextBox_DepartmentNo.Location = new System.Drawing.Point(167, 14);
            this.sS_MaskedTextBox_DepartmentNo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sS_MaskedTextBox_DepartmentNo.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_DepartmentNo.Name = "sS_MaskedTextBox_DepartmentNo";
            this.sS_MaskedTextBox_DepartmentNo.Size = new System.Drawing.Size(199, 26);
            this.sS_MaskedTextBox_DepartmentNo.TabIndex = 1;
            this.sS_MaskedTextBox_DepartmentNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.sS_MaskedTextBox_DepartmentNo_KeyPress);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_Record});
            this.statusStrip1.Location = new System.Drawing.Point(0, 481);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(589, 27);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel_Record
            // 
            this.toolStripStatusLabel_Record.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabel_Record.Name = "toolStripStatusLabel_Record";
            this.toolStripStatusLabel_Record.Size = new System.Drawing.Size(104, 22);
            this.toolStripStatusLabel_Record.Text = "[1/All] records";
            // 
            // Form_002010_Department
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(589, 508);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel_Department);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form_002010_Department";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ID:002010(Department)";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_002010_Department_FormClosed);
            this.Activated += new System.EventHandler(this.Form_002010_Department_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_002010_Department_FormClosing);
            this.Load += new System.EventHandler(this.Form_002010_Department_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sS_DataGridView_Department)).EndInit();
            this.panel_Department.ResumeLayout(false);
            this.panel_Department.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private SimatSoft.CustomControl.SS_DataGridView sS_DataGridView_Department;
        private System.Windows.Forms.Panel panel_Department;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_DepartmentName;
        private System.Windows.Forms.Label LBL_DepartmentName;
        private System.Windows.Forms.Label LBL_DepartmentNo;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_DepartmentNo;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Record;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_FacilityNo;
        private System.Windows.Forms.Label LBL_CompanyNo;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_FacName;

    }
}