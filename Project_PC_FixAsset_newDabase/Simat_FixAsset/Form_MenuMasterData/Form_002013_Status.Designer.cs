namespace SimatSoft.FixAsset
{
    partial class Form_002013_Status
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
            this.sS_DataGridView_Status = new SimatSoft.CustomControl.SS_DataGridView();
            this.panel_Status = new System.Windows.Forms.Panel();
            this.sS_MaskedTextBox_StatusName = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.LBL_StatusName = new System.Windows.Forms.Label();
            this.LBL_StatusID = new System.Windows.Forms.Label();
            this.sS_MaskedTextBox_StatusID = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_Record = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sS_DataGridView_Status)).BeginInit();
            this.panel_Status.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.sS_DataGridView_Status);
            this.panel2.Location = new System.Drawing.Point(3, 94);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(437, 294);
            this.panel2.TabIndex = 5;
            // 
            // sS_DataGridView_Status
            // 
            this.sS_DataGridView_Status.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.sS_DataGridView_Status.BackColorCellFocus = System.Drawing.Color.LightBlue;
            this.sS_DataGridView_Status.BackColorCellLeave = System.Drawing.Color.Honeydew;
            this.sS_DataGridView_Status.BackColorRow = System.Drawing.Color.HotPink;
            this.sS_DataGridView_Status.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sS_DataGridView_Status.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sS_DataGridView_Status.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sS_DataGridView_Status.Location = new System.Drawing.Point(0, 0);
            this.sS_DataGridView_Status.Name = "sS_DataGridView_Status";
            this.sS_DataGridView_Status.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.sS_DataGridView_Status.Size = new System.Drawing.Size(433, 290);
            this.sS_DataGridView_Status.TabIndex = 0;
            this.sS_DataGridView_Status.Click += new System.EventHandler(this.sS_DataGridView_Status_Click);
            // 
            // panel_Status
            // 
            this.panel_Status.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_Status.BackColor = System.Drawing.Color.Transparent;
            this.panel_Status.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_Status.Controls.Add(this.sS_MaskedTextBox_StatusName);
            this.panel_Status.Controls.Add(this.LBL_StatusName);
            this.panel_Status.Controls.Add(this.LBL_StatusID);
            this.panel_Status.Controls.Add(this.sS_MaskedTextBox_StatusID);
            this.panel_Status.Location = new System.Drawing.Point(1, 3);
            this.panel_Status.Name = "panel_Status";
            this.panel_Status.Size = new System.Drawing.Size(439, 85);
            this.panel_Status.TabIndex = 4;
            // 
            // sS_MaskedTextBox_StatusName
            // 
            this.sS_MaskedTextBox_StatusName.BackColor = System.Drawing.Color.Lavender;
            this.sS_MaskedTextBox_StatusName.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_StatusName.BackColorOnLeave = System.Drawing.Color.Lavender;
            this.sS_MaskedTextBox_StatusName.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_StatusName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_StatusName.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_StatusName.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_StatusName.IconError = null;
            this.sS_MaskedTextBox_StatusName.IconTrue = null;
            this.sS_MaskedTextBox_StatusName.Location = new System.Drawing.Point(115, 44);
            this.sS_MaskedTextBox_StatusName.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_StatusName.Name = "sS_MaskedTextBox_StatusName";
            this.sS_MaskedTextBox_StatusName.Size = new System.Drawing.Size(304, 23);
            this.sS_MaskedTextBox_StatusName.TabIndex = 2;
            // 
            // LBL_StatusName
            // 
            this.LBL_StatusName.AutoSize = true;
            this.LBL_StatusName.Location = new System.Drawing.Point(33, 51);
            this.LBL_StatusName.Name = "LBL_StatusName";
            this.LBL_StatusName.Size = new System.Drawing.Size(71, 13);
            this.LBL_StatusName.TabIndex = 2;
            this.LBL_StatusName.Text = "Status Name:";
            // 
            // LBL_StatusID
            // 
            this.LBL_StatusID.AutoSize = true;
            this.LBL_StatusID.Location = new System.Drawing.Point(33, 25);
            this.LBL_StatusID.Name = "LBL_StatusID";
            this.LBL_StatusID.Size = new System.Drawing.Size(54, 13);
            this.LBL_StatusID.TabIndex = 2;
            this.LBL_StatusID.Text = "Status ID:";
            // 
            // sS_MaskedTextBox_StatusID
            // 
            this.sS_MaskedTextBox_StatusID.BackColor = System.Drawing.Color.Honeydew;
            this.sS_MaskedTextBox_StatusID.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_StatusID.BackColorOnLeave = System.Drawing.Color.Honeydew;
            this.sS_MaskedTextBox_StatusID.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_StatusID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_StatusID.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_StatusID.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_StatusID.IconError = null;
            this.sS_MaskedTextBox_StatusID.IconTrue = null;
            this.sS_MaskedTextBox_StatusID.Location = new System.Drawing.Point(115, 18);
            this.sS_MaskedTextBox_StatusID.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_StatusID.Name = "sS_MaskedTextBox_StatusID";
            this.sS_MaskedTextBox_StatusID.Size = new System.Drawing.Size(150, 23);
            this.sS_MaskedTextBox_StatusID.TabIndex = 1;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_Record});
            this.statusStrip1.Location = new System.Drawing.Point(0, 391);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(442, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel_Record
            // 
            this.toolStripStatusLabel_Record.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabel_Record.Name = "toolStripStatusLabel_Record";
            this.toolStripStatusLabel_Record.Size = new System.Drawing.Size(79, 17);
            this.toolStripStatusLabel_Record.Text = "[1/All] records";
            // 
            // Form_002013_Status
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(442, 413);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel_Status);
            this.Name = "Form_002013_Status";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ID:002013(Status)";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_002013_Status_FormClosed);
            this.Activated += new System.EventHandler(this.Form_002013_Status_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_002013_Status_FormClosing);
            this.Load += new System.EventHandler(this.Form_002013_Status_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sS_DataGridView_Status)).EndInit();
            this.panel_Status.ResumeLayout(false);
            this.panel_Status.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private SimatSoft.CustomControl.SS_DataGridView sS_DataGridView_Status;
        private System.Windows.Forms.Panel panel_Status;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_StatusName;
        private System.Windows.Forms.Label LBL_StatusName;
        private System.Windows.Forms.Label LBL_StatusID;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_StatusID;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Record;
    }
}