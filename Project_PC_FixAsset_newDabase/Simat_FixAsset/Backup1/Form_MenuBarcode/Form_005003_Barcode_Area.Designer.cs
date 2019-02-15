namespace SimatSoft.FixAsset
{
    partial class Form_005003_Barcode_Area
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
            this.label_Remark = new System.Windows.Forms.Label();
            this.sS_DataGridView_BarcodeArea = new SimatSoft.CustomControl.SS_DataGridView();
            this.sS_MaskedTextBox_Remark = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.sS_MaskedTextBox_AreaID = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.label_AreaID = new System.Windows.Forms.Label();
            this.sS_MaskedTextBox_AreaName = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.sS_ButtonGlass1 = new SimatSoft.CustomControl.SS_ButtonGlass();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sS_DataGridView_BarcodeArea)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label_Remark);
            this.panel2.Controls.Add(this.sS_DataGridView_BarcodeArea);
            this.panel2.Controls.Add(this.sS_MaskedTextBox_Remark);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 88);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(484, 0);
            this.panel2.TabIndex = 1;
            // 
            // label_Remark
            // 
            this.label_Remark.AutoSize = true;
            this.label_Remark.Location = new System.Drawing.Point(22, 6);
            this.label_Remark.Name = "label_Remark";
            this.label_Remark.Size = new System.Drawing.Size(61, 17);
            this.label_Remark.TabIndex = 11;
            this.label_Remark.Text = "Remark:";
            this.label_Remark.Visible = false;
            // 
            // sS_DataGridView_BarcodeArea
            // 
            this.sS_DataGridView_BarcodeArea.AllowUserToAddRows = false;
            this.sS_DataGridView_BarcodeArea.BackColorCellFocus = System.Drawing.Color.LightBlue;
            this.sS_DataGridView_BarcodeArea.BackColorCellLeave = System.Drawing.Color.Honeydew;
            this.sS_DataGridView_BarcodeArea.BackColorRow = System.Drawing.Color.HotPink;
            this.sS_DataGridView_BarcodeArea.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sS_DataGridView_BarcodeArea.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sS_DataGridView_BarcodeArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sS_DataGridView_BarcodeArea.Location = new System.Drawing.Point(0, 0);
            this.sS_DataGridView_BarcodeArea.Name = "sS_DataGridView_BarcodeArea";
            this.sS_DataGridView_BarcodeArea.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.sS_DataGridView_BarcodeArea.Size = new System.Drawing.Size(484, 0);
            this.sS_DataGridView_BarcodeArea.TabIndex = 0;
            this.sS_DataGridView_BarcodeArea.Visible = false;
            this.sS_DataGridView_BarcodeArea.Click += new System.EventHandler(this.sS_DataGridView_BarcodeArea_Click);
            // 
            // sS_MaskedTextBox_Remark
            // 
            this.sS_MaskedTextBox_Remark.BackColor = System.Drawing.Color.Lavender;
            this.sS_MaskedTextBox_Remark.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_Remark.BackColorOnLeave = System.Drawing.Color.Lavender;
            this.sS_MaskedTextBox_Remark.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_Remark.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_Remark.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_Remark.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_Remark.IconError = null;
            this.sS_MaskedTextBox_Remark.IconTrue = null;
            this.sS_MaskedTextBox_Remark.Location = new System.Drawing.Point(113, 6);
            this.sS_MaskedTextBox_Remark.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_Remark.Name = "sS_MaskedTextBox_Remark";
            this.sS_MaskedTextBox_Remark.Size = new System.Drawing.Size(312, 26);
            this.sS_MaskedTextBox_Remark.TabIndex = 10;
            this.sS_MaskedTextBox_Remark.Visible = false;
            // 
            // sS_MaskedTextBox_AreaID
            // 
            this.sS_MaskedTextBox_AreaID.BackColor = System.Drawing.Color.Honeydew;
            this.sS_MaskedTextBox_AreaID.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_AreaID.BackColorOnLeave = System.Drawing.Color.Honeydew;
            this.sS_MaskedTextBox_AreaID.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_AreaID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_AreaID.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_AreaID.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_AreaID.IconError = null;
            this.sS_MaskedTextBox_AreaID.IconTrue = null;
            this.sS_MaskedTextBox_AreaID.Location = new System.Drawing.Point(109, 20);
            this.sS_MaskedTextBox_AreaID.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_AreaID.Name = "sS_MaskedTextBox_AreaID";
            this.sS_MaskedTextBox_AreaID.ReadOnly = true;
            this.sS_MaskedTextBox_AreaID.Size = new System.Drawing.Size(235, 26);
            this.sS_MaskedTextBox_AreaID.TabIndex = 7;
            this.sS_MaskedTextBox_AreaID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sS_MaskedTextBox_AssetID_KeyDown);
            // 
            // label_AreaID
            // 
            this.label_AreaID.AutoSize = true;
            this.label_AreaID.Location = new System.Drawing.Point(20, 30);
            this.label_AreaID.Name = "label_AreaID";
            this.label_AreaID.Size = new System.Drawing.Size(68, 17);
            this.label_AreaID.TabIndex = 9;
            this.label_AreaID.Text = "Area No.:";
            // 
            // sS_MaskedTextBox_AreaName
            // 
            this.sS_MaskedTextBox_AreaName.BackColor = System.Drawing.Color.LightCyan;
            this.sS_MaskedTextBox_AreaName.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_AreaName.BackColorOnLeave = System.Drawing.Color.Honeydew;
            this.sS_MaskedTextBox_AreaName.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_AreaName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_AreaName.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_AreaName.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_AreaName.IconError = null;
            this.sS_MaskedTextBox_AreaName.IconTrue = null;
            this.sS_MaskedTextBox_AreaName.Location = new System.Drawing.Point(109, 51);
            this.sS_MaskedTextBox_AreaName.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_AreaName.Name = "sS_MaskedTextBox_AreaName";
            this.sS_MaskedTextBox_AreaName.ReadOnly = true;
            this.sS_MaskedTextBox_AreaName.Size = new System.Drawing.Size(335, 26);
            this.sS_MaskedTextBox_AreaName.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.sS_ButtonGlass1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.sS_MaskedTextBox_AreaName);
            this.panel1.Controls.Add(this.label_AreaID);
            this.panel1.Controls.Add(this.sS_MaskedTextBox_AreaID);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(484, 88);
            this.panel1.TabIndex = 0;
            // 
            // sS_ButtonGlass1
            // 
            this.sS_ButtonGlass1.Location = new System.Drawing.Point(350, 20);
            this.sS_ButtonGlass1.Name = "sS_ButtonGlass1";
            this.sS_ButtonGlass1.Size = new System.Drawing.Size(94, 23);
            this.sS_ButtonGlass1.TabIndex = 43;
            this.sS_ButtonGlass1.Text = "Print Barcode";
            this.sS_ButtonGlass1.Click += new System.EventHandler(this.sS_ButtonGlass1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Area Name:";
            // 
            // Form_005003_Barcode_Area
            // 
            this.ClientSize = new System.Drawing.Size(484, 88);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form_005003_Barcode_Area";
            this.Text = "ID:005003(Barcode Area)";
            this.Load += new System.EventHandler(this.Form_005001_Barcode_Asset_Load);
            this.Activated += new System.EventHandler(this.Form_005001_Barcode_Asset_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_005001_Barcode_Asset_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_005003_Barcode_Area_FormClosing);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sS_DataGridView_BarcodeArea)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_AreaID;
        private System.Windows.Forms.Label label_AreaID;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_AreaName;
        private System.Windows.Forms.Panel panel1;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_Remark;
        private System.Windows.Forms.Label label_Remark;
        private SimatSoft.CustomControl.SS_DataGridView sS_DataGridView_BarcodeArea;
        private System.Windows.Forms.Label label1;
        private SimatSoft.CustomControl.SS_ButtonGlass sS_ButtonGlass1;

    }
}