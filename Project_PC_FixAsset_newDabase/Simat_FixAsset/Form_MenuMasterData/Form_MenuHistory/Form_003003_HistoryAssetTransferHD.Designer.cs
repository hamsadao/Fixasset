namespace SimatSoft.FixAsset
{
    partial class Form_003003_HistoryAssetTransferHD
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
            this.sS_DataGridView1 = new SimatSoft.CustomControl.SS_DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_Record = new System.Windows.Forms.ToolStripStatusLabel();
            this.sS_DataGridView_HistoryAsset = new SimatSoft.CustomControl.SS_DataGridView();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sS_DataGridView1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sS_DataGridView_HistoryAsset)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.sS_DataGridView1);
            this.panel2.Location = new System.Drawing.Point(-1, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(582, 360);
            this.panel2.TabIndex = 5;
            // 
            // sS_DataGridView1
            // 
            this.sS_DataGridView1.BackColorCellFocus = System.Drawing.Color.LightBlue;
            this.sS_DataGridView1.BackColorCellLeave = System.Drawing.Color.Honeydew;
            this.sS_DataGridView1.BackColorRow = System.Drawing.Color.HotPink;
            this.sS_DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sS_DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sS_DataGridView1.Location = new System.Drawing.Point(-1, -2);
            this.sS_DataGridView1.Name = "sS_DataGridView1";
            this.sS_DataGridView1.Size = new System.Drawing.Size(582, 564);
            this.sS_DataGridView1.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Highlight;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_Record});
            this.statusStrip1.Location = new System.Drawing.Point(0, 350);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(581, 22);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel_Record
            // 
            this.toolStripStatusLabel_Record.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabel_Record.Name = "toolStripStatusLabel_Record";
            this.toolStripStatusLabel_Record.Size = new System.Drawing.Size(79, 17);
            this.toolStripStatusLabel_Record.Text = "[1/All] records";
            // 
            // sS_DataGridView_HistoryAsset
            // 
            this.sS_DataGridView_HistoryAsset.AllowUserToAddRows = false;
            this.sS_DataGridView_HistoryAsset.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.sS_DataGridView_HistoryAsset.BackColorCellFocus = System.Drawing.Color.LightBlue;
            this.sS_DataGridView_HistoryAsset.BackColorCellLeave = System.Drawing.Color.Honeydew;
            this.sS_DataGridView_HistoryAsset.BackColorRow = System.Drawing.Color.HotPink;
            this.sS_DataGridView_HistoryAsset.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sS_DataGridView_HistoryAsset.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sS_DataGridView_HistoryAsset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sS_DataGridView_HistoryAsset.Location = new System.Drawing.Point(0, 0);
            this.sS_DataGridView_HistoryAsset.Name = "sS_DataGridView_HistoryAsset";
            this.sS_DataGridView_HistoryAsset.Size = new System.Drawing.Size(841, 566);
            this.sS_DataGridView_HistoryAsset.TabIndex = 0;
            this.sS_DataGridView_HistoryAsset.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.sS_DataGridView_HistoryAsset_CellDoubleClick);
            // 
            // Form_003003_HistoryAssetTransferHD
            // 
            this.ClientSize = new System.Drawing.Size(841, 566);
            this.Controls.Add(this.sS_DataGridView_HistoryAsset);
            this.Name = "Form_003003_HistoryAssetTransferHD";
            this.Text = "ID:003003(HistoryAssetTransferHD)";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_003003_HistoryTransferHD_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_003003_HistoryAssetTransferHD_FormClosing);
            this.Load += new System.EventHandler(this.Form_003003_HistoryTransferHD_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sS_DataGridView1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sS_DataGridView_HistoryAsset)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private SimatSoft.CustomControl.SS_DataGridView sS_DataGridView1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Record;
        private SimatSoft.CustomControl.SS_DataGridView sS_DataGridView_HistoryAsset;
    }
}