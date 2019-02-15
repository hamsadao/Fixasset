namespace SimatSoft.FixAsset
{
    partial class Form_002002_Model
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
            this.panel_Model = new System.Windows.Forms.Panel();
            this.LBL_Brand = new System.Windows.Forms.Label();
            this.sS_MaskedTextBox_Brand = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.sS_MaskedTextBox_Value = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.sS_MaskedTextBox_ModelName = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.LBL_Value = new System.Windows.Forms.Label();
            this.LBL_ModelName = new System.Windows.Forms.Label();
            this.LBL_ModelNo = new System.Windows.Forms.Label();
            this.sS_MaskedTextBox_ModelNo = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_Record = new System.Windows.Forms.ToolStripStatusLabel();
            this.sS_DataGridView_Model = new SimatSoft.CustomControl.SS_DataGridView();
            this.panel2.SuspendLayout();
            this.panel_Model.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sS_DataGridView_Model)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.sS_DataGridView_Model);
            this.panel2.Location = new System.Drawing.Point(4, 187);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(756, 277);
            this.panel2.TabIndex = 6;
            // 
            // panel_Model
            // 
            this.panel_Model.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_Model.BackColor = System.Drawing.Color.Transparent;
            this.panel_Model.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_Model.Controls.Add(this.LBL_Brand);
            this.panel_Model.Controls.Add(this.sS_MaskedTextBox_Brand);
            this.panel_Model.Controls.Add(this.sS_MaskedTextBox_Value);
            this.panel_Model.Controls.Add(this.sS_MaskedTextBox_ModelName);
            this.panel_Model.Controls.Add(this.LBL_Value);
            this.panel_Model.Controls.Add(this.LBL_ModelName);
            this.panel_Model.Controls.Add(this.LBL_ModelNo);
            this.panel_Model.Controls.Add(this.sS_MaskedTextBox_ModelNo);
            this.panel_Model.Location = new System.Drawing.Point(1, 4);
            this.panel_Model.Margin = new System.Windows.Forms.Padding(4);
            this.panel_Model.Name = "panel_Model";
            this.panel_Model.Size = new System.Drawing.Size(759, 175);
            this.panel_Model.TabIndex = 5;
            // 
            // LBL_Brand
            // 
            this.LBL_Brand.AutoSize = true;
            this.LBL_Brand.Location = new System.Drawing.Point(40, 94);
            this.LBL_Brand.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBL_Brand.Name = "LBL_Brand";
            this.LBL_Brand.Size = new System.Drawing.Size(46, 17);
            this.LBL_Brand.TabIndex = 5;
            this.LBL_Brand.Text = "Brand";
            // 
            // sS_MaskedTextBox_Brand
            // 
            this.sS_MaskedTextBox_Brand.BackColor = System.Drawing.Color.Lavender;
            this.sS_MaskedTextBox_Brand.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_Brand.BackColorOnLeave = System.Drawing.Color.Honeydew;
            this.sS_MaskedTextBox_Brand.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_Brand.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_Brand.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_Brand.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_Brand.IconError = null;
            this.sS_MaskedTextBox_Brand.IconTrue = null;
            this.sS_MaskedTextBox_Brand.Location = new System.Drawing.Point(164, 87);
            this.sS_MaskedTextBox_Brand.Margin = new System.Windows.Forms.Padding(4);
            this.sS_MaskedTextBox_Brand.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_Brand.Name = "sS_MaskedTextBox_Brand";
            this.sS_MaskedTextBox_Brand.Size = new System.Drawing.Size(199, 26);
            this.sS_MaskedTextBox_Brand.TabIndex = 3;
            this.sS_MaskedTextBox_Brand.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.sS_MaskedTextBox_Brand_KeyPress);
            // 
            // sS_MaskedTextBox_Value
            // 
            this.sS_MaskedTextBox_Value.BackColor = System.Drawing.Color.Lavender;
            this.sS_MaskedTextBox_Value.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_Value.BackColorOnLeave = System.Drawing.Color.Lavender;
            this.sS_MaskedTextBox_Value.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_Value.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_Value.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_Value.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_Value.IconError = null;
            this.sS_MaskedTextBox_Value.IconTrue = null;
            this.sS_MaskedTextBox_Value.Location = new System.Drawing.Point(164, 123);
            this.sS_MaskedTextBox_Value.Margin = new System.Windows.Forms.Padding(4);
            this.sS_MaskedTextBox_Value.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_Value.Name = "sS_MaskedTextBox_Value";
            this.sS_MaskedTextBox_Value.Size = new System.Drawing.Size(199, 26);
            this.sS_MaskedTextBox_Value.TabIndex = 4;
            this.sS_MaskedTextBox_Value.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.sS_MaskedTextBox_Value_KeyPress);
            // 
            // sS_MaskedTextBox_ModelName
            // 
            this.sS_MaskedTextBox_ModelName.BackColor = System.Drawing.Color.Lavender;
            this.sS_MaskedTextBox_ModelName.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_ModelName.BackColorOnLeave = System.Drawing.Color.Lavender;
            this.sS_MaskedTextBox_ModelName.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_ModelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_ModelName.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_ModelName.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_ModelName.IconError = null;
            this.sS_MaskedTextBox_ModelName.IconTrue = null;
            this.sS_MaskedTextBox_ModelName.Location = new System.Drawing.Point(164, 52);
            this.sS_MaskedTextBox_ModelName.Margin = new System.Windows.Forms.Padding(4);
            this.sS_MaskedTextBox_ModelName.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_ModelName.Name = "sS_MaskedTextBox_ModelName";
            this.sS_MaskedTextBox_ModelName.Size = new System.Drawing.Size(404, 26);
            this.sS_MaskedTextBox_ModelName.TabIndex = 2;
            this.sS_MaskedTextBox_ModelName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.sS_MaskedTextBox_ModelName_KeyPress);
            // 
            // LBL_Value
            // 
            this.LBL_Value.AutoSize = true;
            this.LBL_Value.Location = new System.Drawing.Point(40, 132);
            this.LBL_Value.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBL_Value.Name = "LBL_Value";
            this.LBL_Value.Size = new System.Drawing.Size(48, 17);
            this.LBL_Value.TabIndex = 2;
            this.LBL_Value.Text = "Value:";
            // 
            // LBL_ModelName
            // 
            this.LBL_ModelName.AutoSize = true;
            this.LBL_ModelName.Location = new System.Drawing.Point(40, 60);
            this.LBL_ModelName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBL_ModelName.Name = "LBL_ModelName";
            this.LBL_ModelName.Size = new System.Drawing.Size(91, 17);
            this.LBL_ModelName.TabIndex = 2;
            this.LBL_ModelName.Text = "Model Name:";
            // 
            // LBL_ModelNo
            // 
            this.LBL_ModelNo.AutoSize = true;
            this.LBL_ModelNo.Location = new System.Drawing.Point(40, 23);
            this.LBL_ModelNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBL_ModelNo.Name = "LBL_ModelNo";
            this.LBL_ModelNo.Size = new System.Drawing.Size(72, 17);
            this.LBL_ModelNo.TabIndex = 2;
            this.LBL_ModelNo.Text = "Model No:";
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
            this.sS_MaskedTextBox_ModelNo.Location = new System.Drawing.Point(164, 16);
            this.sS_MaskedTextBox_ModelNo.Margin = new System.Windows.Forms.Padding(4);
            this.sS_MaskedTextBox_ModelNo.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_ModelNo.Name = "sS_MaskedTextBox_ModelNo";
            this.sS_MaskedTextBox_ModelNo.Size = new System.Drawing.Size(199, 26);
            this.sS_MaskedTextBox_ModelNo.TabIndex = 1;
            this.sS_MaskedTextBox_ModelNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.sS_MaskedTextBox_ModelNo_KeyPress);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_Record});
            this.statusStrip1.Location = new System.Drawing.Point(0, 469);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(764, 27);
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
            // sS_DataGridView_Model
            // 
            this.sS_DataGridView_Model.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.sS_DataGridView_Model.BackColorCellFocus = System.Drawing.Color.LightBlue;
            this.sS_DataGridView_Model.BackColorCellLeave = System.Drawing.Color.Honeydew;
            this.sS_DataGridView_Model.BackColorRow = System.Drawing.Color.HotPink;
            this.sS_DataGridView_Model.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sS_DataGridView_Model.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sS_DataGridView_Model.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sS_DataGridView_Model.Location = new System.Drawing.Point(0, 0);
            this.sS_DataGridView_Model.Margin = new System.Windows.Forms.Padding(4);
            this.sS_DataGridView_Model.Name = "sS_DataGridView_Model";
            this.sS_DataGridView_Model.RowTemplate.Height = 24;
            this.sS_DataGridView_Model.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.sS_DataGridView_Model.Size = new System.Drawing.Size(752, 273);
            this.sS_DataGridView_Model.TabIndex = 0;
            this.sS_DataGridView_Model.Click += new System.EventHandler(this.sS_DataGridView_Model_Click);
            // 
            // Form_002002_Model
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(764, 496);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel_Model);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form_002002_Model";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ID:002002(Model)";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_002002_Model_FormClosed);
            this.Activated += new System.EventHandler(this.Form_002002_Model_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_002002_Model_FormClosing);
            this.Load += new System.EventHandler(this.Form_002002_Model_Load);
            this.panel2.ResumeLayout(false);
            this.panel_Model.ResumeLayout(false);
            this.panel_Model.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sS_DataGridView_Model)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel_Model;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_ModelName;
        private System.Windows.Forms.Label LBL_Value;
        private System.Windows.Forms.Label LBL_ModelName;
        private System.Windows.Forms.Label LBL_ModelNo;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_ModelNo;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_Value;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Record;
        private System.Windows.Forms.Label LBL_Brand;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_Brand;
        private SimatSoft.CustomControl.SS_DataGridView sS_DataGridView_Model;
    }
}