namespace SimatSoft.FixAsset
{
    partial class Form_005001_Barcode_Asset
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
            this.sS_DataGridView_BarcodeAsset = new SimatSoft.CustomControl.SS_DataGridView();
            this.sS_MaskedTextBox_AssetID = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.label_AssetID = new System.Windows.Forms.Label();
            this.sS_MaskedTextBox_AssetName = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.sS_ButtonGlass1 = new SimatSoft.CustomControl.SS_ButtonGlass();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sS_DataGridView_BarcodeAsset)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label_Remark);
            this.panel2.Controls.Add(this.sS_MaskedTextBox_Remark);
            this.panel2.Controls.Add(this.sS_DataGridView_BarcodeAsset);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 88);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(564, 1);
            this.panel2.TabIndex = 1;
            // 
            // label_Remark
            // 
            this.label_Remark.AutoSize = true;
            this.label_Remark.Location = new System.Drawing.Point(58, 16);
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
            this.sS_MaskedTextBox_Remark.Location = new System.Drawing.Point(122, 6);
            this.sS_MaskedTextBox_Remark.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_Remark.Name = "sS_MaskedTextBox_Remark";
            this.sS_MaskedTextBox_Remark.Size = new System.Drawing.Size(309, 26);
            this.sS_MaskedTextBox_Remark.TabIndex = 10;
            this.sS_MaskedTextBox_Remark.Visible = false;
            // 
            // sS_DataGridView_BarcodeAsset
            // 
            this.sS_DataGridView_BarcodeAsset.AllowUserToAddRows = false;
            this.sS_DataGridView_BarcodeAsset.BackColorCellFocus = System.Drawing.Color.LightBlue;
            this.sS_DataGridView_BarcodeAsset.BackColorCellLeave = System.Drawing.Color.Honeydew;
            this.sS_DataGridView_BarcodeAsset.BackColorRow = System.Drawing.Color.HotPink;
            this.sS_DataGridView_BarcodeAsset.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sS_DataGridView_BarcodeAsset.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sS_DataGridView_BarcodeAsset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sS_DataGridView_BarcodeAsset.Location = new System.Drawing.Point(0, 0);
            this.sS_DataGridView_BarcodeAsset.Name = "sS_DataGridView_BarcodeAsset";
            this.sS_DataGridView_BarcodeAsset.RowTemplate.Height = 24;
            this.sS_DataGridView_BarcodeAsset.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.sS_DataGridView_BarcodeAsset.Size = new System.Drawing.Size(564, 1);
            this.sS_DataGridView_BarcodeAsset.TabIndex = 0;
            this.sS_DataGridView_BarcodeAsset.Visible = false;
            this.sS_DataGridView_BarcodeAsset.Click += new System.EventHandler(this.sS_DataGridView_BarcodeAsset_Click);
            // 
            // sS_MaskedTextBox_AssetID
            // 
            this.sS_MaskedTextBox_AssetID.BackColor = System.Drawing.Color.Honeydew;
            this.sS_MaskedTextBox_AssetID.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_AssetID.BackColorOnLeave = System.Drawing.Color.Honeydew;
            this.sS_MaskedTextBox_AssetID.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_AssetID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_AssetID.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_AssetID.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_AssetID.IconError = null;
            this.sS_MaskedTextBox_AssetID.IconTrue = null;
            this.sS_MaskedTextBox_AssetID.Location = new System.Drawing.Point(99, 20);
            this.sS_MaskedTextBox_AssetID.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_AssetID.Name = "sS_MaskedTextBox_AssetID";
            this.sS_MaskedTextBox_AssetID.ReadOnly = true;
            this.sS_MaskedTextBox_AssetID.Size = new System.Drawing.Size(331, 26);
            this.sS_MaskedTextBox_AssetID.TabIndex = 7;
            this.sS_MaskedTextBox_AssetID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.sS_MaskedTextBox_AssetID_KeyPress);
            this.sS_MaskedTextBox_AssetID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sS_MaskedTextBox_AssetID_KeyDown);
            // 
            // label_AssetID
            // 
            this.label_AssetID.AutoSize = true;
            this.label_AssetID.Location = new System.Drawing.Point(10, 25);
            this.label_AssetID.Name = "label_AssetID";
            this.label_AssetID.Size = new System.Drawing.Size(69, 17);
            this.label_AssetID.TabIndex = 9;
            this.label_AssetID.Text = "Asset No.";
            // 
            // sS_MaskedTextBox_AssetName
            // 
            this.sS_MaskedTextBox_AssetName.BackColor = System.Drawing.Color.LightCyan;
            this.sS_MaskedTextBox_AssetName.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_AssetName.BackColorOnLeave = System.Drawing.Color.Honeydew;
            this.sS_MaskedTextBox_AssetName.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_AssetName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_AssetName.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_AssetName.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_AssetName.IconError = null;
            this.sS_MaskedTextBox_AssetName.IconTrue = null;
            this.sS_MaskedTextBox_AssetName.Location = new System.Drawing.Point(99, 49);
            this.sS_MaskedTextBox_AssetName.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_AssetName.Name = "sS_MaskedTextBox_AssetName";
            this.sS_MaskedTextBox_AssetName.ReadOnly = true;
            this.sS_MaskedTextBox_AssetName.Size = new System.Drawing.Size(431, 26);
            this.sS_MaskedTextBox_AssetName.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.sS_ButtonGlass1);
            this.panel1.Controls.Add(this.sS_MaskedTextBox_AssetName);
            this.panel1.Controls.Add(this.label_AssetID);
            this.panel1.Controls.Add(this.sS_MaskedTextBox_AssetID);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(564, 88);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 17);
            this.label1.TabIndex = 43;
            this.label1.Text = "Asset Name";
            // 
            // sS_ButtonGlass1
            // 
            this.sS_ButtonGlass1.Location = new System.Drawing.Point(436, 20);
            this.sS_ButtonGlass1.Name = "sS_ButtonGlass1";
            this.sS_ButtonGlass1.Size = new System.Drawing.Size(94, 23);
            this.sS_ButtonGlass1.TabIndex = 42;
            this.sS_ButtonGlass1.Text = "Print Barcode";
            this.sS_ButtonGlass1.Click += new System.EventHandler(this.sS_ButtonGlass1_Click);
            // 
            // Form_005001_Barcode_Asset
            // 
            this.ClientSize = new System.Drawing.Size(564, 89);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form_005001_Barcode_Asset";
            this.Text = "ID:005001(Barcode Asset)";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_005001_Barcode_Asset_FormClosed);
            this.Activated += new System.EventHandler(this.Form_005001_Barcode_Asset_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_005001_Barcode_Asset_FormClosing);
            this.Load += new System.EventHandler(this.Form_005001_Barcode_Asset_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sS_DataGridView_BarcodeAsset)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_AssetID;
        private System.Windows.Forms.Label label_AssetID;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_AssetName;
        private System.Windows.Forms.Panel panel1;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_Remark;
        private System.Windows.Forms.Label label_Remark;
        private SimatSoft.CustomControl.SS_DataGridView sS_DataGridView_BarcodeAsset;
        private SimatSoft.CustomControl.SS_ButtonGlass sS_ButtonGlass1;
        private System.Windows.Forms.Label label1;

    }
}