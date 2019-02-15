namespace SimatSoft.FixAsset
{
    partial class Form_005005_Barcode_Floor
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
            this.sS_MaskedTextBox_Remark = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.sS_DataGridView_BarcodeFloor = new SimatSoft.CustomControl.SS_DataGridView();
            this.sS_MaskedTextBox_FloorID = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.label_FloorID = new System.Windows.Forms.Label();
            this.sS_MaskedTextBox_FloorName = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.sS_ButtonGlass1 = new SimatSoft.CustomControl.SS_ButtonGlass();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sS_DataGridView_BarcodeFloor)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label_Remark);
            this.panel2.Controls.Add(this.sS_MaskedTextBox_Remark);
            this.panel2.Controls.Add(this.sS_DataGridView_BarcodeFloor);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 88);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(485, 2);
            this.panel2.TabIndex = 1;
            // 
            // label_Remark
            // 
            this.label_Remark.AutoSize = true;
            this.label_Remark.Location = new System.Drawing.Point(22, 49);
            this.label_Remark.Name = "label_Remark";
            this.label_Remark.Size = new System.Drawing.Size(61, 17);
            this.label_Remark.TabIndex = 11;
            this.label_Remark.Text = "Remark:";
            this.label_Remark.Visible = false;
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
            this.sS_MaskedTextBox_Remark.Location = new System.Drawing.Point(106, 58);
            this.sS_MaskedTextBox_Remark.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_Remark.Name = "sS_MaskedTextBox_Remark";
            this.sS_MaskedTextBox_Remark.Size = new System.Drawing.Size(312, 26);
            this.sS_MaskedTextBox_Remark.TabIndex = 10;
            this.sS_MaskedTextBox_Remark.Visible = false;
            // 
            // sS_DataGridView_BarcodeFloor
            // 
            this.sS_DataGridView_BarcodeFloor.AllowUserToAddRows = false;
            this.sS_DataGridView_BarcodeFloor.BackColorCellFocus = System.Drawing.Color.LightBlue;
            this.sS_DataGridView_BarcodeFloor.BackColorCellLeave = System.Drawing.Color.Honeydew;
            this.sS_DataGridView_BarcodeFloor.BackColorRow = System.Drawing.Color.HotPink;
            this.sS_DataGridView_BarcodeFloor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sS_DataGridView_BarcodeFloor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sS_DataGridView_BarcodeFloor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sS_DataGridView_BarcodeFloor.Location = new System.Drawing.Point(0, 0);
            this.sS_DataGridView_BarcodeFloor.Name = "sS_DataGridView_BarcodeFloor";
            this.sS_DataGridView_BarcodeFloor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.sS_DataGridView_BarcodeFloor.Size = new System.Drawing.Size(485, 2);
            this.sS_DataGridView_BarcodeFloor.TabIndex = 0;
            this.sS_DataGridView_BarcodeFloor.Visible = false;
            this.sS_DataGridView_BarcodeFloor.Click += new System.EventHandler(this.sS_DataGridView_BarcodeFloor_Click);
            // 
            // sS_MaskedTextBox_FloorID
            // 
            this.sS_MaskedTextBox_FloorID.BackColor = System.Drawing.Color.Honeydew;
            this.sS_MaskedTextBox_FloorID.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_FloorID.BackColorOnLeave = System.Drawing.Color.Honeydew;
            this.sS_MaskedTextBox_FloorID.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_FloorID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_FloorID.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_FloorID.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_FloorID.IconError = null;
            this.sS_MaskedTextBox_FloorID.IconTrue = null;
            this.sS_MaskedTextBox_FloorID.Location = new System.Drawing.Point(117, 20);
            this.sS_MaskedTextBox_FloorID.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_FloorID.Name = "sS_MaskedTextBox_FloorID";
            this.sS_MaskedTextBox_FloorID.ReadOnly = true;
            this.sS_MaskedTextBox_FloorID.Size = new System.Drawing.Size(244, 26);
            this.sS_MaskedTextBox_FloorID.TabIndex = 7;
            this.sS_MaskedTextBox_FloorID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sS_MaskedTextBox_AssetID_KeyDown);
            // 
            // label_FloorID
            // 
            this.label_FloorID.AutoSize = true;
            this.label_FloorID.Location = new System.Drawing.Point(10, 30);
            this.label_FloorID.Name = "label_FloorID";
            this.label_FloorID.Size = new System.Drawing.Size(66, 17);
            this.label_FloorID.TabIndex = 9;
            this.label_FloorID.Text = "Floor No:";
            // 
            // sS_MaskedTextBox_FloorName
            // 
            this.sS_MaskedTextBox_FloorName.BackColor = System.Drawing.Color.LightCyan;
            this.sS_MaskedTextBox_FloorName.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_FloorName.BackColorOnLeave = System.Drawing.Color.Honeydew;
            this.sS_MaskedTextBox_FloorName.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_FloorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_FloorName.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_FloorName.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_FloorName.IconError = null;
            this.sS_MaskedTextBox_FloorName.IconTrue = null;
            this.sS_MaskedTextBox_FloorName.Location = new System.Drawing.Point(117, 53);
            this.sS_MaskedTextBox_FloorName.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_FloorName.Name = "sS_MaskedTextBox_FloorName";
            this.sS_MaskedTextBox_FloorName.ReadOnly = true;
            this.sS_MaskedTextBox_FloorName.Size = new System.Drawing.Size(344, 26);
            this.sS_MaskedTextBox_FloorName.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.sS_ButtonGlass1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.sS_MaskedTextBox_FloorName);
            this.panel1.Controls.Add(this.label_FloorID);
            this.panel1.Controls.Add(this.sS_MaskedTextBox_FloorID);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(485, 88);
            this.panel1.TabIndex = 0;
            // 
            // sS_ButtonGlass1
            // 
            this.sS_ButtonGlass1.Location = new System.Drawing.Point(367, 20);
            this.sS_ButtonGlass1.Name = "sS_ButtonGlass1";
            this.sS_ButtonGlass1.Size = new System.Drawing.Size(94, 23);
            this.sS_ButtonGlass1.TabIndex = 45;
            this.sS_ButtonGlass1.Text = "Print Barcode";
            this.sS_ButtonGlass1.Click += new System.EventHandler(this.sS_ButtonGlass1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Floor Name:";
            // 
            // Form_005005_Barcode_Floor
            // 
            this.ClientSize = new System.Drawing.Size(485, 90);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form_005005_Barcode_Floor";
            this.Text = "ID:005005(Barcode Floor)";
            this.Load += new System.EventHandler(this.Form_005001_Barcode_Asset_Load);
            this.Activated += new System.EventHandler(this.Form_005001_Barcode_Asset_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_005001_Barcode_Asset_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_005005_Barcode_Floor_FormClosing);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sS_DataGridView_BarcodeFloor)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_FloorID;
        private System.Windows.Forms.Label label_FloorID;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_FloorName;
        private System.Windows.Forms.Panel panel1;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_Remark;
        private System.Windows.Forms.Label label_Remark;
        private SimatSoft.CustomControl.SS_DataGridView sS_DataGridView_BarcodeFloor;
        private System.Windows.Forms.Label label1;
        private SimatSoft.CustomControl.SS_ButtonGlass sS_ButtonGlass1;

    }
}