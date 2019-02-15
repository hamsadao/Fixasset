namespace SimatSoft.FixAsset
{
    partial class Form_002006_Company
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_Record = new System.Windows.Forms.ToolStripStatusLabel();
            this.sS_DataGridView_Facility = new SimatSoft.CustomControl.SS_DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.sS_MaskedTextBox_FacilityName = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.panel_Facility = new System.Windows.Forms.Panel();
            this.sS_MaskedTextBox_Phone = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.sS_MaskedTextBox_City = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.sS_MaskedTextBox_Address2 = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.sS_MaskedTextBox_Address1 = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.LBL_Phone = new System.Windows.Forms.Label();
            this.LBL_City = new System.Windows.Forms.Label();
            this.LBL_Address2 = new System.Windows.Forms.Label();
            this.LBL_Address1 = new System.Windows.Forms.Label();
            this.LBL_CompanyName = new System.Windows.Forms.Label();
            this.LBL_CompanyNo = new System.Windows.Forms.Label();
            this.sS_MaskedTextBox_FacilityNo = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sS_DataGridView_Facility)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel_Facility.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Highlight;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_Record});
            this.statusStrip1.Location = new System.Drawing.Point(0, 481);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(707, 27);
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
            // sS_DataGridView_Facility
            // 
            this.sS_DataGridView_Facility.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.sS_DataGridView_Facility.BackColorCellFocus = System.Drawing.Color.LightBlue;
            this.sS_DataGridView_Facility.BackColorCellLeave = System.Drawing.Color.Honeydew;
            this.sS_DataGridView_Facility.BackColorRow = System.Drawing.Color.HotPink;
            this.sS_DataGridView_Facility.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sS_DataGridView_Facility.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sS_DataGridView_Facility.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sS_DataGridView_Facility.Location = new System.Drawing.Point(0, 0);
            this.sS_DataGridView_Facility.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sS_DataGridView_Facility.Name = "sS_DataGridView_Facility";
            this.sS_DataGridView_Facility.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.sS_DataGridView_Facility.Size = new System.Drawing.Size(705, 272);
            this.sS_DataGridView_Facility.TabIndex = 0;
            this.sS_DataGridView_Facility.Click += new System.EventHandler(this.sS_DataGridView_Facility_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.sS_DataGridView_Facility);
            this.panel2.Location = new System.Drawing.Point(3, 207);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(705, 272);
            this.panel2.TabIndex = 13;
            // 
            // sS_MaskedTextBox_FacilityName
            // 
            this.sS_MaskedTextBox_FacilityName.BackColor = System.Drawing.Color.Lavender;
            this.sS_MaskedTextBox_FacilityName.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_FacilityName.BackColorOnLeave = System.Drawing.Color.Lavender;
            this.sS_MaskedTextBox_FacilityName.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_FacilityName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_FacilityName.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_FacilityName.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_FacilityName.IconError = null;
            this.sS_MaskedTextBox_FacilityName.IconTrue = null;
            this.sS_MaskedTextBox_FacilityName.Location = new System.Drawing.Point(145, 42);
            this.sS_MaskedTextBox_FacilityName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sS_MaskedTextBox_FacilityName.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_FacilityName.Name = "sS_MaskedTextBox_FacilityName";
            this.sS_MaskedTextBox_FacilityName.Size = new System.Drawing.Size(404, 26);
            this.sS_MaskedTextBox_FacilityName.TabIndex = 2;
            this.sS_MaskedTextBox_FacilityName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.sS_MaskedTextBox_FacilityName_KeyPress);
            // 
            // panel_Facility
            // 
            this.panel_Facility.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_Facility.BackColor = System.Drawing.Color.Transparent;
            this.panel_Facility.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_Facility.Controls.Add(this.sS_MaskedTextBox_Phone);
            this.panel_Facility.Controls.Add(this.sS_MaskedTextBox_City);
            this.panel_Facility.Controls.Add(this.sS_MaskedTextBox_Address2);
            this.panel_Facility.Controls.Add(this.sS_MaskedTextBox_Address1);
            this.panel_Facility.Controls.Add(this.sS_MaskedTextBox_FacilityName);
            this.panel_Facility.Controls.Add(this.LBL_Phone);
            this.panel_Facility.Controls.Add(this.LBL_City);
            this.panel_Facility.Controls.Add(this.LBL_Address2);
            this.panel_Facility.Controls.Add(this.LBL_Address1);
            this.panel_Facility.Controls.Add(this.LBL_CompanyName);
            this.panel_Facility.Controls.Add(this.LBL_CompanyNo);
            this.panel_Facility.Controls.Add(this.sS_MaskedTextBox_FacilityNo);
            this.panel_Facility.Location = new System.Drawing.Point(1, 1);
            this.panel_Facility.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel_Facility.Name = "panel_Facility";
            this.panel_Facility.Size = new System.Drawing.Size(704, 197);
            this.panel_Facility.TabIndex = 12;
            // 
            // sS_MaskedTextBox_Phone
            // 
            this.sS_MaskedTextBox_Phone.BackColor = System.Drawing.Color.Lavender;
            this.sS_MaskedTextBox_Phone.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_Phone.BackColorOnLeave = System.Drawing.Color.Lavender;
            this.sS_MaskedTextBox_Phone.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_Phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_Phone.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_Phone.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_Phone.IconError = null;
            this.sS_MaskedTextBox_Phone.IconTrue = null;
            this.sS_MaskedTextBox_Phone.Location = new System.Drawing.Point(145, 160);
            this.sS_MaskedTextBox_Phone.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sS_MaskedTextBox_Phone.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_Phone.Name = "sS_MaskedTextBox_Phone";
            this.sS_MaskedTextBox_Phone.Size = new System.Drawing.Size(199, 26);
            this.sS_MaskedTextBox_Phone.TabIndex = 6;
            // 
            // sS_MaskedTextBox_City
            // 
            this.sS_MaskedTextBox_City.BackColor = System.Drawing.Color.Lavender;
            this.sS_MaskedTextBox_City.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_City.BackColorOnLeave = System.Drawing.Color.Lavender;
            this.sS_MaskedTextBox_City.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_City.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_City.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_City.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_City.IconError = null;
            this.sS_MaskedTextBox_City.IconTrue = null;
            this.sS_MaskedTextBox_City.Location = new System.Drawing.Point(145, 130);
            this.sS_MaskedTextBox_City.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sS_MaskedTextBox_City.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_City.Name = "sS_MaskedTextBox_City";
            this.sS_MaskedTextBox_City.Size = new System.Drawing.Size(199, 26);
            this.sS_MaskedTextBox_City.TabIndex = 5;
            // 
            // sS_MaskedTextBox_Address2
            // 
            this.sS_MaskedTextBox_Address2.BackColor = System.Drawing.Color.Lavender;
            this.sS_MaskedTextBox_Address2.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_Address2.BackColorOnLeave = System.Drawing.Color.Lavender;
            this.sS_MaskedTextBox_Address2.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_Address2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_Address2.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_Address2.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_Address2.IconError = null;
            this.sS_MaskedTextBox_Address2.IconTrue = null;
            this.sS_MaskedTextBox_Address2.Location = new System.Drawing.Point(145, 101);
            this.sS_MaskedTextBox_Address2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sS_MaskedTextBox_Address2.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_Address2.Name = "sS_MaskedTextBox_Address2";
            this.sS_MaskedTextBox_Address2.Size = new System.Drawing.Size(404, 26);
            this.sS_MaskedTextBox_Address2.TabIndex = 4;
            // 
            // sS_MaskedTextBox_Address1
            // 
            this.sS_MaskedTextBox_Address1.BackColor = System.Drawing.Color.Lavender;
            this.sS_MaskedTextBox_Address1.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_Address1.BackColorOnLeave = System.Drawing.Color.Lavender;
            this.sS_MaskedTextBox_Address1.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_Address1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_Address1.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_Address1.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_Address1.IconError = null;
            this.sS_MaskedTextBox_Address1.IconTrue = null;
            this.sS_MaskedTextBox_Address1.Location = new System.Drawing.Point(145, 71);
            this.sS_MaskedTextBox_Address1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sS_MaskedTextBox_Address1.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_Address1.Name = "sS_MaskedTextBox_Address1";
            this.sS_MaskedTextBox_Address1.Size = new System.Drawing.Size(404, 26);
            this.sS_MaskedTextBox_Address1.TabIndex = 3;
            // 
            // LBL_Phone
            // 
            this.LBL_Phone.AutoSize = true;
            this.LBL_Phone.Location = new System.Drawing.Point(36, 162);
            this.LBL_Phone.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBL_Phone.Name = "LBL_Phone";
            this.LBL_Phone.Size = new System.Drawing.Size(53, 17);
            this.LBL_Phone.TabIndex = 2;
            this.LBL_Phone.Text = "Phone:";
            // 
            // LBL_City
            // 
            this.LBL_City.AutoSize = true;
            this.LBL_City.Location = new System.Drawing.Point(36, 135);
            this.LBL_City.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBL_City.Name = "LBL_City";
            this.LBL_City.Size = new System.Drawing.Size(35, 17);
            this.LBL_City.TabIndex = 2;
            this.LBL_City.Text = "City:";
            // 
            // LBL_Address2
            // 
            this.LBL_Address2.AutoSize = true;
            this.LBL_Address2.Location = new System.Drawing.Point(36, 108);
            this.LBL_Address2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBL_Address2.Name = "LBL_Address2";
            this.LBL_Address2.Size = new System.Drawing.Size(72, 17);
            this.LBL_Address2.TabIndex = 2;
            this.LBL_Address2.Text = "Address2:";
            // 
            // LBL_Address1
            // 
            this.LBL_Address1.AutoSize = true;
            this.LBL_Address1.Location = new System.Drawing.Point(36, 80);
            this.LBL_Address1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBL_Address1.Name = "LBL_Address1";
            this.LBL_Address1.Size = new System.Drawing.Size(72, 17);
            this.LBL_Address1.TabIndex = 2;
            this.LBL_Address1.Text = "Address1:";
            // 
            // LBL_CompanyName
            // 
            this.LBL_CompanyName.AutoSize = true;
            this.LBL_CompanyName.Location = new System.Drawing.Point(36, 53);
            this.LBL_CompanyName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBL_CompanyName.Name = "LBL_CompanyName";
            this.LBL_CompanyName.Size = new System.Drawing.Size(112, 17);
            this.LBL_CompanyName.TabIndex = 2;
            this.LBL_CompanyName.Text = "Company Name:";
            // 
            // LBL_CompanyNo
            // 
            this.LBL_CompanyNo.AutoSize = true;
            this.LBL_CompanyNo.Location = new System.Drawing.Point(36, 18);
            this.LBL_CompanyNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBL_CompanyNo.Name = "LBL_CompanyNo";
            this.LBL_CompanyNo.Size = new System.Drawing.Size(93, 17);
            this.LBL_CompanyNo.TabIndex = 2;
            this.LBL_CompanyNo.Text = "Company No:";
            // 
            // sS_MaskedTextBox_FacilityNo
            // 
            this.sS_MaskedTextBox_FacilityNo.BackColor = System.Drawing.Color.Honeydew;
            this.sS_MaskedTextBox_FacilityNo.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_FacilityNo.BackColorOnLeave = System.Drawing.Color.Honeydew;
            this.sS_MaskedTextBox_FacilityNo.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_FacilityNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_FacilityNo.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_FacilityNo.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_FacilityNo.IconError = null;
            this.sS_MaskedTextBox_FacilityNo.IconTrue = null;
            this.sS_MaskedTextBox_FacilityNo.Location = new System.Drawing.Point(145, 12);
            this.sS_MaskedTextBox_FacilityNo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sS_MaskedTextBox_FacilityNo.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_FacilityNo.Name = "sS_MaskedTextBox_FacilityNo";
            this.sS_MaskedTextBox_FacilityNo.Size = new System.Drawing.Size(199, 26);
            this.sS_MaskedTextBox_FacilityNo.TabIndex = 1;
            this.sS_MaskedTextBox_FacilityNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.sS_MaskedTextBox_FacilityNo_KeyPress);
            // 
            // Form_002006_Company
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(210)))), ((int)(((byte)(238)))));
            this.ClientSize = new System.Drawing.Size(707, 508);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel_Facility);
            this.Controls.Add(this.statusStrip1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form_002006_Company";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ID:002006(Company)";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_002006_Facility_FormClosed);
            this.Activated += new System.EventHandler(this.Form_002006_Facility_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_002006_Company_FormClosing);
            this.Load += new System.EventHandler(this.Form_002006_Facility_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sS_DataGridView_Facility)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel_Facility.ResumeLayout(false);
            this.panel_Facility.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Record;
        private SimatSoft.CustomControl.SS_DataGridView sS_DataGridView_Facility;
        private System.Windows.Forms.Panel panel2;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_FacilityName;
        private System.Windows.Forms.Panel panel_Facility;
        private System.Windows.Forms.Label LBL_CompanyName;
        private System.Windows.Forms.Label LBL_CompanyNo;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_FacilityNo;
        private System.Windows.Forms.Label LBL_Phone;
        private System.Windows.Forms.Label LBL_City;
        private System.Windows.Forms.Label LBL_Address2;
        private System.Windows.Forms.Label LBL_Address1;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_Address2;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_Address1;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_Phone;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_City;
    }
}