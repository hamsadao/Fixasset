namespace SimatSoft.FixAsset
{
    partial class Form_005010_Barcode_Asset_New
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.sS_ButtonExit = new SimatSoft.CustomControl.SS_ButtonGlass();
            this.sS_ButtonPrint = new SimatSoft.CustomControl.SS_ButtonGlass();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.sS_MaskedTextBox_AssetIDTo = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sS_ButtonGlass1 = new SimatSoft.CustomControl.SS_ButtonGlass();
            this.label_AssetID = new System.Windows.Forms.Label();
            this.sS_MaskedTextBox_AssetID = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.ColChk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgvAssetList = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssetList)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.sS_ButtonExit);
            this.panel1.Controls.Add(this.sS_ButtonPrint);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(879, 560);
            this.panel1.TabIndex = 1;
            // 
            // sS_ButtonExit
            // 
            this.sS_ButtonExit.Location = new System.Drawing.Point(763, 499);
            this.sS_ButtonExit.Name = "sS_ButtonExit";
            this.sS_ButtonExit.Size = new System.Drawing.Size(94, 23);
            this.sS_ButtonExit.TabIndex = 5;
            this.sS_ButtonExit.Text = "Exit";
            this.sS_ButtonExit.Click += new System.EventHandler(this.sS_ButtonExit_Click);
            // 
            // sS_ButtonPrint
            // 
            this.sS_ButtonPrint.Location = new System.Drawing.Point(663, 499);
            this.sS_ButtonPrint.Name = "sS_ButtonPrint";
            this.sS_ButtonPrint.Size = new System.Drawing.Size(94, 23);
            this.sS_ButtonPrint.TabIndex = 4;
            this.sS_ButtonPrint.Text = "Print";
            this.sS_ButtonPrint.Click += new System.EventHandler(this.sS_ButtonPrint_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvAssetList);
            this.groupBox2.Location = new System.Drawing.Point(10, 91);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(832, 402);
            this.groupBox2.TabIndex = 45;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Result";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.sS_MaskedTextBox_AssetIDTo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.sS_ButtonGlass1);
            this.groupBox1.Controls.Add(this.label_AssetID);
            this.groupBox1.Controls.Add(this.sS_MaskedTextBox_AssetID);
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(724, 75);
            this.groupBox1.TabIndex = 44;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Criteria";
            // 
            // sS_MaskedTextBox_AssetIDTo
            // 
            this.sS_MaskedTextBox_AssetIDTo.BackColor = System.Drawing.Color.Honeydew;
            this.sS_MaskedTextBox_AssetIDTo.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_AssetIDTo.BackColorOnLeave = System.Drawing.Color.Honeydew;
            this.sS_MaskedTextBox_AssetIDTo.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_AssetIDTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_AssetIDTo.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_AssetIDTo.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_AssetIDTo.IconError = null;
            this.sS_MaskedTextBox_AssetIDTo.IconTrue = null;
            this.sS_MaskedTextBox_AssetIDTo.Location = new System.Drawing.Point(374, 30);
            this.sS_MaskedTextBox_AssetIDTo.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_AssetIDTo.Name = "sS_MaskedTextBox_AssetIDTo";
            this.sS_MaskedTextBox_AssetIDTo.Size = new System.Drawing.Size(140, 23);
            this.sS_MaskedTextBox_AssetIDTo.TabIndex = 2;
            this.sS_MaskedTextBox_AssetIDTo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sS_MaskedTextBox_AssetIDTo_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(293, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 48;
            this.label1.Text = "To Asset No. :";
            // 
            // sS_ButtonGlass1
            // 
            this.sS_ButtonGlass1.Location = new System.Drawing.Point(539, 30);
            this.sS_ButtonGlass1.Name = "sS_ButtonGlass1";
            this.sS_ButtonGlass1.Size = new System.Drawing.Size(94, 23);
            this.sS_ButtonGlass1.TabIndex = 3;
            this.sS_ButtonGlass1.Text = "Show";
            this.sS_ButtonGlass1.Click += new System.EventHandler(this.sS_ButtonGlass1_Click);
            // 
            // label_AssetID
            // 
            this.label_AssetID.AutoSize = true;
            this.label_AssetID.Location = new System.Drawing.Point(27, 35);
            this.label_AssetID.Name = "label_AssetID";
            this.label_AssetID.Size = new System.Drawing.Size(59, 13);
            this.label_AssetID.TabIndex = 46;
            this.label_AssetID.Text = "Asset No. :";
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
            this.sS_MaskedTextBox_AssetID.Location = new System.Drawing.Point(92, 30);
            this.sS_MaskedTextBox_AssetID.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_AssetID.Name = "sS_MaskedTextBox_AssetID";
            this.sS_MaskedTextBox_AssetID.Size = new System.Drawing.Size(140, 23);
            this.sS_MaskedTextBox_AssetID.TabIndex = 1;
            this.sS_MaskedTextBox_AssetID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sS_MaskedTextBox_AssetID_KeyDown);
            // 
            // ColChk
            // 
            this.ColChk.HeaderText = "";
            this.ColChk.Name = "ColChk";
            this.ColChk.Width = 50;
            // 
            // dgvAssetList
            // 
            this.dgvAssetList.AllowUserToAddRows = false;
            this.dgvAssetList.AllowUserToDeleteRows = false;
            this.dgvAssetList.AllowUserToResizeColumns = false;
            this.dgvAssetList.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvAssetList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAssetList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAssetList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColChk});
            this.dgvAssetList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dgvAssetList.Location = new System.Drawing.Point(15, 19);
            this.dgvAssetList.Name = "dgvAssetList";
            this.dgvAssetList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAssetList.Size = new System.Drawing.Size(799, 364);
            this.dgvAssetList.TabIndex = 0;
            this.dgvAssetList.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAssetList_CellValueChanged);
            this.dgvAssetList.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvAssetList_CellPainting);
            this.dgvAssetList.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvAssetList_CurrentCellDirtyStateChanged);
            // 
            // Form_005010_Barcode_Asset_New
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 538);
            this.Controls.Add(this.panel1);
            this.Name = "Form_005010_Barcode_Asset_New";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ID:005010(Barcode Asset New)";
            this.Load += new System.EventHandler(this.Form_005001_Barcode_Asset_New_Load);
            this.Activated += new System.EventHandler(this.Form_005010_Barcode_Asset_New_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_005010_Barcode_Asset_New_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_005010_Barcode_Asset_New_FormClosing);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssetList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_AssetIDTo;
        private System.Windows.Forms.Label label1;
        private SimatSoft.CustomControl.SS_ButtonGlass sS_ButtonGlass1;
        private System.Windows.Forms.Label label_AssetID;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_AssetID;
        private System.Windows.Forms.GroupBox groupBox2;
        private SimatSoft.CustomControl.SS_ButtonGlass sS_ButtonExit;
        private SimatSoft.CustomControl.SS_ButtonGlass sS_ButtonPrint;
        private System.Windows.Forms.DataGridView dgvAssetList;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColChk;
    }
}