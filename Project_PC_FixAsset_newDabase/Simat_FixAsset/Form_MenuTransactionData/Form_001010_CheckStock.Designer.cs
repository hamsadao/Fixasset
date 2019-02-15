namespace SimatSoft.FixAsset
{
    partial class Form_001010_CheckStock
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
            this.toolStripStatusLabel_Record = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.panel2 = new System.Windows.Forms.Panel();
            this.sS_DataGridView_CheckStock = new SimatSoft.CustomControl.SS_DataGridView();
            this.LBL_StockSystem = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.sS_DataGridView_Asset = new SimatSoft.CustomControl.SS_DataGridView();
            this.LBL_TypeName = new System.Windows.Forms.Label();
            this.sS_ComboBox_TypeName = new SimatSoft.CustomControl.SS_ComboBox();
            this.LBL_StockCheck = new System.Windows.Forms.Label();
            this.cmdClear = new System.Windows.Forms.Button();
            this.CmdAdd = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sS_DataGridView_CheckStock)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sS_DataGridView_Asset)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripStatusLabel_Record
            // 
            this.toolStripStatusLabel_Record.Name = "toolStripStatusLabel_Record";
            this.toolStripStatusLabel_Record.Size = new System.Drawing.Size(55, 17);
            this.toolStripStatusLabel_Record.Text = "Summary:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Highlight;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_Record});
            this.statusStrip1.Location = new System.Drawing.Point(0, 544);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(963, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.sS_DataGridView_CheckStock);
            this.panel2.Location = new System.Drawing.Point(1, 289);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(962, 252);
            this.panel2.TabIndex = 5;
            // 
            // sS_DataGridView_CheckStock
            // 
            this.sS_DataGridView_CheckStock.AllowUserToAddRows = false;
            this.sS_DataGridView_CheckStock.BackColorCellFocus = System.Drawing.Color.LightBlue;
            this.sS_DataGridView_CheckStock.BackColorCellLeave = System.Drawing.Color.Honeydew;
            this.sS_DataGridView_CheckStock.BackColorRow = System.Drawing.Color.HotPink;
            this.sS_DataGridView_CheckStock.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sS_DataGridView_CheckStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sS_DataGridView_CheckStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sS_DataGridView_CheckStock.Location = new System.Drawing.Point(0, 0);
            this.sS_DataGridView_CheckStock.Name = "sS_DataGridView_CheckStock";
            this.sS_DataGridView_CheckStock.RowTemplate.Height = 24;
            this.sS_DataGridView_CheckStock.Size = new System.Drawing.Size(958, 248);
            this.sS_DataGridView_CheckStock.TabIndex = 14;
            // 
            // LBL_StockSystem
            // 
            this.LBL_StockSystem.AutoSize = true;
            this.LBL_StockSystem.BackColor = System.Drawing.Color.Transparent;
            this.LBL_StockSystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.LBL_StockSystem.Location = new System.Drawing.Point(7, 9);
            this.LBL_StockSystem.Name = "LBL_StockSystem";
            this.LBL_StockSystem.Size = new System.Drawing.Size(88, 13);
            this.LBL_StockSystem.TabIndex = 13;
            this.LBL_StockSystem.Text = "Stock System:";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.sS_DataGridView_Asset);
            this.panel1.Location = new System.Drawing.Point(1, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(962, 212);
            this.panel1.TabIndex = 12;
            // 
            // sS_DataGridView_Asset
            // 
            this.sS_DataGridView_Asset.AllowUserToAddRows = false;
            this.sS_DataGridView_Asset.BackColorCellFocus = System.Drawing.Color.LightBlue;
            this.sS_DataGridView_Asset.BackColorCellLeave = System.Drawing.Color.Honeydew;
            this.sS_DataGridView_Asset.BackColorRow = System.Drawing.Color.HotPink;
            this.sS_DataGridView_Asset.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sS_DataGridView_Asset.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sS_DataGridView_Asset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sS_DataGridView_Asset.Location = new System.Drawing.Point(0, 0);
            this.sS_DataGridView_Asset.Name = "sS_DataGridView_Asset";
            this.sS_DataGridView_Asset.RowTemplate.Height = 24;
            this.sS_DataGridView_Asset.Size = new System.Drawing.Size(958, 208);
            this.sS_DataGridView_Asset.TabIndex = 2;
            // 
            // LBL_TypeName
            // 
            this.LBL_TypeName.AutoSize = true;
            this.LBL_TypeName.BackColor = System.Drawing.Color.Transparent;
            this.LBL_TypeName.Location = new System.Drawing.Point(145, 262);
            this.LBL_TypeName.Name = "LBL_TypeName";
            this.LBL_TypeName.Size = new System.Drawing.Size(62, 13);
            this.LBL_TypeName.TabIndex = 15;
            this.LBL_TypeName.Text = "TypeName:";
            // 
            // sS_ComboBox_TypeName
            // 
            this.sS_ComboBox_TypeName.BackColor = System.Drawing.Color.Honeydew;
            this.sS_ComboBox_TypeName.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_ComboBox_TypeName.BackColorOnLeave = System.Drawing.Color.Honeydew;
            this.sS_ComboBox_TypeName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sS_ComboBox_TypeName.FormattingEnabled = true;
            this.sS_ComboBox_TypeName.Location = new System.Drawing.Point(234, 262);
            this.sS_ComboBox_TypeName.Name = "sS_ComboBox_TypeName";
            this.sS_ComboBox_TypeName.Size = new System.Drawing.Size(168, 21);
            this.sS_ComboBox_TypeName.TabIndex = 16;
            this.sS_ComboBox_TypeName.SelectedIndexChanged += new System.EventHandler(this.sS_ComboBox_Status_SelectedIndexChanged);
            // 
            // LBL_StockCheck
            // 
            this.LBL_StockCheck.AutoSize = true;
            this.LBL_StockCheck.BackColor = System.Drawing.Color.Transparent;
            this.LBL_StockCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.LBL_StockCheck.Location = new System.Drawing.Point(7, 262);
            this.LBL_StockCheck.Name = "LBL_StockCheck";
            this.LBL_StockCheck.Size = new System.Drawing.Size(80, 13);
            this.LBL_StockCheck.TabIndex = 17;
            this.LBL_StockCheck.Text = "StockCheck:";
            // 
            // cmdClear
            // 
            this.cmdClear.Location = new System.Drawing.Point(409, 262);
            this.cmdClear.Name = "cmdClear";
            this.cmdClear.Size = new System.Drawing.Size(75, 23);
            this.cmdClear.TabIndex = 18;
            this.cmdClear.Text = "Clear";
            this.cmdClear.UseVisualStyleBackColor = true;
            this.cmdClear.Click += new System.EventHandler(this.cmdClear_Click);
            // 
            // CmdAdd
            // 
            this.CmdAdd.Location = new System.Drawing.Point(490, 262);
            this.CmdAdd.Name = "CmdAdd";
            this.CmdAdd.Size = new System.Drawing.Size(75, 23);
            this.CmdAdd.TabIndex = 19;
            this.CmdAdd.Text = "New Asset";
            this.CmdAdd.UseVisualStyleBackColor = true;
            this.CmdAdd.Click += new System.EventHandler(this.CmdAdd_Click);
            // 
            // Form_001010_CheckStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(210)))), ((int)(((byte)(238)))));
            this.ClientSize = new System.Drawing.Size(963, 566);
            this.Controls.Add(this.CmdAdd);
            this.Controls.Add(this.cmdClear);
            this.Controls.Add(this.LBL_StockCheck);
            this.Controls.Add(this.sS_ComboBox_TypeName);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LBL_TypeName);
            this.Controls.Add(this.LBL_StockSystem);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel2);
            this.Name = "Form_001010_CheckStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ID:001010(Check Stock)";
            this.Load += new System.EventHandler(this.Form_001009_CheckStock_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_001009_CheckStock_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_001010_CheckStock_FormClosing);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sS_DataGridView_CheckStock)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sS_DataGridView_Asset)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Record;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label LBL_StockSystem;
        private System.Windows.Forms.Panel panel1;
        private SimatSoft.CustomControl.SS_DataGridView sS_DataGridView_Asset;
        private SimatSoft.CustomControl.SS_DataGridView sS_DataGridView_CheckStock;
        private System.Windows.Forms.Label LBL_TypeName;
        private SimatSoft.CustomControl.SS_ComboBox sS_ComboBox_TypeName;
        private System.Windows.Forms.Label LBL_StockCheck;
        private System.Windows.Forms.Button cmdClear;
        private System.Windows.Forms.Button CmdAdd;
    }
}