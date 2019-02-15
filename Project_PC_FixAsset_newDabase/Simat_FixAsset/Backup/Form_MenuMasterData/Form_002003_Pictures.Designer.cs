namespace SimatSoft.FixAsset
{
    partial class Form_002003_Pictures
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
            this.panel_Picture = new System.Windows.Forms.Panel();
            this.sS_MaskedTextBox_ModelName = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.sS_MaskedTextBox_AssetName = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.sS_MaskedTextBox_ModelNo = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.pictureBox_Picture = new System.Windows.Forms.PictureBox();
            this.button_Browse = new System.Windows.Forms.Button();
            this.LBL_Picture = new System.Windows.Forms.Label();
            this.sS_MaskedTextBox_Picture = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.sS_MaskedTextBox_AssetNo = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.LBL_ModelNo = new System.Windows.Forms.Label();
            this.LBL_AssetNo = new System.Windows.Forms.Label();
            this.sS_DataGridView_Picture = new SimatSoft.CustomControl.SS_DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_Record = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel_Picture.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sS_DataGridView_Picture)).BeginInit();
            this.panel2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Picture
            // 
            this.panel_Picture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_Picture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_Picture.Controls.Add(this.sS_MaskedTextBox_ModelName);
            this.panel_Picture.Controls.Add(this.sS_MaskedTextBox_AssetName);
            this.panel_Picture.Controls.Add(this.sS_MaskedTextBox_ModelNo);
            this.panel_Picture.Controls.Add(this.pictureBox_Picture);
            this.panel_Picture.Controls.Add(this.button_Browse);
            this.panel_Picture.Controls.Add(this.LBL_Picture);
            this.panel_Picture.Controls.Add(this.sS_MaskedTextBox_Picture);
            this.panel_Picture.Controls.Add(this.sS_MaskedTextBox_AssetNo);
            this.panel_Picture.Controls.Add(this.LBL_ModelNo);
            this.panel_Picture.Controls.Add(this.LBL_AssetNo);
            this.panel_Picture.Location = new System.Drawing.Point(1, 1);
            this.panel_Picture.Name = "panel_Picture";
            this.panel_Picture.Size = new System.Drawing.Size(438, 236);
            this.panel_Picture.TabIndex = 6;
            // 
            // sS_MaskedTextBox_ModelName
            // 
            this.sS_MaskedTextBox_ModelName.BackColor = System.Drawing.Color.LightCyan;
            this.sS_MaskedTextBox_ModelName.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_ModelName.BackColorOnLeave = System.Drawing.Color.LightCyan;
            this.sS_MaskedTextBox_ModelName.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_ModelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_ModelName.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_ModelName.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_ModelName.IconError = null;
            this.sS_MaskedTextBox_ModelName.IconTrue = null;
            this.sS_MaskedTextBox_ModelName.Location = new System.Drawing.Point(226, 29);
            this.sS_MaskedTextBox_ModelName.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_ModelName.Name = "sS_MaskedTextBox_ModelName";
            this.sS_MaskedTextBox_ModelName.ReadOnly = true;
            this.sS_MaskedTextBox_ModelName.Size = new System.Drawing.Size(127, 23);
            this.sS_MaskedTextBox_ModelName.TabIndex = 14;
            this.sS_MaskedTextBox_ModelName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sS_MaskedTextBox_ModelNo_KeyDown);
            // 
            // sS_MaskedTextBox_AssetName
            // 
            this.sS_MaskedTextBox_AssetName.BackColor = System.Drawing.Color.LightCyan;
            this.sS_MaskedTextBox_AssetName.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_AssetName.BackColorOnLeave = System.Drawing.Color.LightCyan;
            this.sS_MaskedTextBox_AssetName.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_AssetName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_AssetName.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_AssetName.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_AssetName.IconError = null;
            this.sS_MaskedTextBox_AssetName.IconTrue = null;
            this.sS_MaskedTextBox_AssetName.Location = new System.Drawing.Point(226, 4);
            this.sS_MaskedTextBox_AssetName.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_AssetName.Name = "sS_MaskedTextBox_AssetName";
            this.sS_MaskedTextBox_AssetName.ReadOnly = true;
            this.sS_MaskedTextBox_AssetName.Size = new System.Drawing.Size(127, 23);
            this.sS_MaskedTextBox_AssetName.TabIndex = 13;
            this.sS_MaskedTextBox_AssetName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sS_MaskedTextBox_AssetNo_KeyDown);
            // 
            // sS_MaskedTextBox_ModelNo
            // 
            this.sS_MaskedTextBox_ModelNo.BackColor = System.Drawing.Color.Honeydew;
            this.sS_MaskedTextBox_ModelNo.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_ModelNo.BackColorOnLeave = System.Drawing.Color.Honeydew;
            this.sS_MaskedTextBox_ModelNo.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_ModelNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_ModelNo.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_ModelNo.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_ModelNo.IconError = null;
            this.sS_MaskedTextBox_ModelNo.IconTrue = null;
            this.sS_MaskedTextBox_ModelNo.Location = new System.Drawing.Point(106, 29);
            this.sS_MaskedTextBox_ModelNo.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_ModelNo.Name = "sS_MaskedTextBox_ModelNo";
            this.sS_MaskedTextBox_ModelNo.ReadOnly = true;
            this.sS_MaskedTextBox_ModelNo.Size = new System.Drawing.Size(114, 23);
            this.sS_MaskedTextBox_ModelNo.TabIndex = 2;
            this.sS_MaskedTextBox_ModelNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sS_MaskedTextBox_ModelNo_KeyDown);
            // 
            // pictureBox_Picture
            // 
            this.pictureBox_Picture.BackColor = System.Drawing.Color.Honeydew;
            this.pictureBox_Picture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox_Picture.Location = new System.Drawing.Point(106, 78);
            this.pictureBox_Picture.Name = "pictureBox_Picture";
            this.pictureBox_Picture.Size = new System.Drawing.Size(247, 146);
            this.pictureBox_Picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox_Picture.TabIndex = 11;
            this.pictureBox_Picture.TabStop = false;
            // 
            // button_Browse
            // 
            this.button_Browse.Location = new System.Drawing.Point(355, 50);
            this.button_Browse.Name = "button_Browse";
            this.button_Browse.Size = new System.Drawing.Size(48, 26);
            this.button_Browse.TabIndex = 3;
            this.button_Browse.Text = "...";
            this.button_Browse.UseVisualStyleBackColor = true;
            this.button_Browse.Click += new System.EventHandler(this.button_Browse_Click);
            // 
            // LBL_Picture
            // 
            this.LBL_Picture.AutoSize = true;
            this.LBL_Picture.Location = new System.Drawing.Point(13, 53);
            this.LBL_Picture.Name = "LBL_Picture";
            this.LBL_Picture.Size = new System.Drawing.Size(43, 13);
            this.LBL_Picture.TabIndex = 9;
            this.LBL_Picture.Text = "Picture:";
            // 
            // sS_MaskedTextBox_Picture
            // 
            this.sS_MaskedTextBox_Picture.BackColor = System.Drawing.Color.Honeydew;
            this.sS_MaskedTextBox_Picture.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_Picture.BackColorOnLeave = System.Drawing.Color.Honeydew;
            this.sS_MaskedTextBox_Picture.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_Picture.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_Picture.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_Picture.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_Picture.IconError = null;
            this.sS_MaskedTextBox_Picture.IconTrue = null;
            this.sS_MaskedTextBox_Picture.Location = new System.Drawing.Point(106, 53);
            this.sS_MaskedTextBox_Picture.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_Picture.Name = "sS_MaskedTextBox_Picture";
            this.sS_MaskedTextBox_Picture.Size = new System.Drawing.Size(247, 23);
            this.sS_MaskedTextBox_Picture.TabIndex = 3;
            // 
            // sS_MaskedTextBox_AssetNo
            // 
            this.sS_MaskedTextBox_AssetNo.BackColor = System.Drawing.Color.Honeydew;
            this.sS_MaskedTextBox_AssetNo.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_AssetNo.BackColorOnLeave = System.Drawing.Color.Honeydew;
            this.sS_MaskedTextBox_AssetNo.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_AssetNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_AssetNo.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_AssetNo.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_AssetNo.IconError = null;
            this.sS_MaskedTextBox_AssetNo.IconTrue = null;
            this.sS_MaskedTextBox_AssetNo.Location = new System.Drawing.Point(106, 4);
            this.sS_MaskedTextBox_AssetNo.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_AssetNo.Name = "sS_MaskedTextBox_AssetNo";
            this.sS_MaskedTextBox_AssetNo.ReadOnly = true;
            this.sS_MaskedTextBox_AssetNo.Size = new System.Drawing.Size(114, 23);
            this.sS_MaskedTextBox_AssetNo.TabIndex = 1;
            this.sS_MaskedTextBox_AssetNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sS_MaskedTextBox_AssetNo_KeyDown);
            // 
            // LBL_ModelNo
            // 
            this.LBL_ModelNo.AutoSize = true;
            this.LBL_ModelNo.Location = new System.Drawing.Point(13, 29);
            this.LBL_ModelNo.Name = "LBL_ModelNo";
            this.LBL_ModelNo.Size = new System.Drawing.Size(56, 13);
            this.LBL_ModelNo.TabIndex = 2;
            this.LBL_ModelNo.Text = "Model No:";
            // 
            // LBL_AssetNo
            // 
            this.LBL_AssetNo.AutoSize = true;
            this.LBL_AssetNo.Location = new System.Drawing.Point(13, 4);
            this.LBL_AssetNo.Name = "LBL_AssetNo";
            this.LBL_AssetNo.Size = new System.Drawing.Size(53, 13);
            this.LBL_AssetNo.TabIndex = 2;
            this.LBL_AssetNo.Text = "Asset No:";
            // 
            // sS_DataGridView_Picture
            // 
            this.sS_DataGridView_Picture.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.sS_DataGridView_Picture.BackColorCellFocus = System.Drawing.Color.LightBlue;
            this.sS_DataGridView_Picture.BackColorCellLeave = System.Drawing.Color.Honeydew;
            this.sS_DataGridView_Picture.BackColorRow = System.Drawing.Color.HotPink;
            this.sS_DataGridView_Picture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sS_DataGridView_Picture.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sS_DataGridView_Picture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sS_DataGridView_Picture.Location = new System.Drawing.Point(0, 0);
            this.sS_DataGridView_Picture.Name = "sS_DataGridView_Picture";
            this.sS_DataGridView_Picture.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.sS_DataGridView_Picture.Size = new System.Drawing.Size(438, 151);
            this.sS_DataGridView_Picture.TabIndex = 0;
            this.sS_DataGridView_Picture.Click += new System.EventHandler(this.sS_DataGridView_Picture_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.sS_DataGridView_Picture);
            this.panel2.Location = new System.Drawing.Point(1, 238);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(438, 151);
            this.panel2.TabIndex = 7;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Highlight;
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
            // Form_002003_Pictures
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(210)))), ((int)(((byte)(238)))));
            this.ClientSize = new System.Drawing.Size(442, 413);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel_Picture);
            this.Name = "Form_002003_Pictures";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ID:002003(Pictures)";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_002003_Pictures_FormClosed);
            this.Activated += new System.EventHandler(this.Form_002003_Pictures_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_002003_Pictures_FormClosing);
            this.Load += new System.EventHandler(this.Form_002003_Pictures_Load);
            this.panel_Picture.ResumeLayout(false);
            this.panel_Picture.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sS_DataGridView_Picture)).EndInit();
            this.panel2.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_Picture;
        private System.Windows.Forms.Label LBL_AssetNo;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_AssetNo;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_Picture;
        private SimatSoft.CustomControl.SS_DataGridView sS_DataGridView_Picture;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Record;
        private System.Windows.Forms.Label LBL_Picture;
        private System.Windows.Forms.PictureBox pictureBox_Picture;
        private System.Windows.Forms.Button button_Browse;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_ModelNo;
        private System.Windows.Forms.Label LBL_ModelNo;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_AssetName;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_ModelName;
    }
}