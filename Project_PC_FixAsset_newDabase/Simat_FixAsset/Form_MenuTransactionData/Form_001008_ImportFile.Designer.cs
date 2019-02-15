namespace SimatSoft.FixAsset
{
    partial class Form_001008_ImportFile
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
            this.panel_PurchaseOrder = new System.Windows.Forms.Panel();
            this.sS_MaskedTextBox_FacCode = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.sS_ButtonGlass_Browse = new SimatSoft.CustomControl.SS_ButtonGlass();
            this.sS_MaskedTextBox_PathFile = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.LBL_FilePath = new System.Windows.Forms.Label();
            this.LBL_Company = new System.Windows.Forms.Label();
            this.LBL_FileType = new System.Windows.Forms.Label();
            this.sS_ComboBox_FileType = new SimatSoft.CustomControl.SS_ComboBox();
            this.checkBox_Floor = new System.Windows.Forms.CheckBox();
            this.checkBox_Area = new System.Windows.Forms.CheckBox();
            this.checkBox_Building = new System.Windows.Forms.CheckBox();
            this.checkBox_Supplier = new System.Windows.Forms.CheckBox();
            this.checkBox_PurchaseOrder = new System.Windows.Forms.CheckBox();
            this.checkBox_Asset = new System.Windows.Forms.CheckBox();
            this.groupBox_TableOfImport = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel_PurchaseOrder.SuspendLayout();
            this.groupBox_TableOfImport.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_PurchaseOrder
            // 
            this.panel_PurchaseOrder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_PurchaseOrder.BackColor = System.Drawing.Color.Transparent;
            this.panel_PurchaseOrder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_PurchaseOrder.Controls.Add(this.sS_MaskedTextBox_FacCode);
            this.panel_PurchaseOrder.Controls.Add(this.sS_ButtonGlass_Browse);
            this.panel_PurchaseOrder.Controls.Add(this.sS_MaskedTextBox_PathFile);
            this.panel_PurchaseOrder.Controls.Add(this.LBL_FilePath);
            this.panel_PurchaseOrder.Controls.Add(this.LBL_Company);
            this.panel_PurchaseOrder.Controls.Add(this.LBL_FileType);
            this.panel_PurchaseOrder.Controls.Add(this.sS_ComboBox_FileType);
            this.panel_PurchaseOrder.Location = new System.Drawing.Point(0, 0);
            this.panel_PurchaseOrder.Name = "panel_PurchaseOrder";
            this.panel_PurchaseOrder.Size = new System.Drawing.Size(449, 112);
            this.panel_PurchaseOrder.TabIndex = 4;
            // 
            // sS_MaskedTextBox_FacCode
            // 
            this.sS_MaskedTextBox_FacCode.BackColor = System.Drawing.Color.Lavender;
            this.sS_MaskedTextBox_FacCode.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_FacCode.BackColorOnLeave = System.Drawing.Color.Lavender;
            this.sS_MaskedTextBox_FacCode.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_FacCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_FacCode.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_FacCode.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_FacCode.IconError = null;
            this.sS_MaskedTextBox_FacCode.IconTrue = null;
            this.sS_MaskedTextBox_FacCode.Location = new System.Drawing.Point(93, 42);
            this.sS_MaskedTextBox_FacCode.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_FacCode.Name = "sS_MaskedTextBox_FacCode";
            this.sS_MaskedTextBox_FacCode.Size = new System.Drawing.Size(121, 23);
            this.sS_MaskedTextBox_FacCode.TabIndex = 5;
            // 
            // sS_ButtonGlass_Browse
            // 
            this.sS_ButtonGlass_Browse.Location = new System.Drawing.Point(373, 13);
            this.sS_ButtonGlass_Browse.Name = "sS_ButtonGlass_Browse";
            this.sS_ButtonGlass_Browse.Size = new System.Drawing.Size(51, 23);
            this.sS_ButtonGlass_Browse.TabIndex = 4;
            this.sS_ButtonGlass_Browse.Text = "Browse";
            this.sS_ButtonGlass_Browse.Click += new System.EventHandler(this.sS_ButtonGlass_Browse_Click);
            // 
            // sS_MaskedTextBox_PathFile
            // 
            this.sS_MaskedTextBox_PathFile.BackColor = System.Drawing.Color.Honeydew;
            this.sS_MaskedTextBox_PathFile.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_PathFile.BackColorOnLeave = System.Drawing.Color.Honeydew;
            this.sS_MaskedTextBox_PathFile.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_PathFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_PathFile.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_PathFile.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_PathFile.IconError = null;
            this.sS_MaskedTextBox_PathFile.IconTrue = null;
            this.sS_MaskedTextBox_PathFile.Location = new System.Drawing.Point(93, 13);
            this.sS_MaskedTextBox_PathFile.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_PathFile.Name = "sS_MaskedTextBox_PathFile";
            this.sS_MaskedTextBox_PathFile.Size = new System.Drawing.Size(274, 23);
            this.sS_MaskedTextBox_PathFile.TabIndex = 3;
            // 
            // LBL_FilePath
            // 
            this.LBL_FilePath.AutoSize = true;
            this.LBL_FilePath.Location = new System.Drawing.Point(24, 18);
            this.LBL_FilePath.Name = "LBL_FilePath";
            this.LBL_FilePath.Size = new System.Drawing.Size(51, 13);
            this.LBL_FilePath.TabIndex = 2;
            this.LBL_FilePath.Text = "File Path:";
            // 
            // LBL_Company
            // 
            this.LBL_Company.AutoSize = true;
            this.LBL_Company.Location = new System.Drawing.Point(24, 50);
            this.LBL_Company.Name = "LBL_Company";
            this.LBL_Company.Size = new System.Drawing.Size(54, 13);
            this.LBL_Company.TabIndex = 2;
            this.LBL_Company.Text = "Company:";
            // 
            // LBL_FileType
            // 
            this.LBL_FileType.AutoSize = true;
            this.LBL_FileType.Location = new System.Drawing.Point(24, 77);
            this.LBL_FileType.Name = "LBL_FileType";
            this.LBL_FileType.Size = new System.Drawing.Size(53, 13);
            this.LBL_FileType.TabIndex = 2;
            this.LBL_FileType.Text = "File Type:";
            // 
            // sS_ComboBox_FileType
            // 
            this.sS_ComboBox_FileType.BackColor = System.Drawing.Color.Honeydew;
            this.sS_ComboBox_FileType.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_ComboBox_FileType.BackColorOnLeave = System.Drawing.Color.Honeydew;
            this.sS_ComboBox_FileType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sS_ComboBox_FileType.FormattingEnabled = true;
            this.sS_ComboBox_FileType.Items.AddRange(new object[] {
            "CSV"});
            this.sS_ComboBox_FileType.Location = new System.Drawing.Point(93, 69);
            this.sS_ComboBox_FileType.Name = "sS_ComboBox_FileType";
            this.sS_ComboBox_FileType.Size = new System.Drawing.Size(121, 21);
            this.sS_ComboBox_FileType.TabIndex = 1;
            this.sS_ComboBox_FileType.SelectedIndexChanged += new System.EventHandler(this.sS_ComboBox_FileType_SelectedIndexChanged);
            // 
            // checkBox_Floor
            // 
            this.checkBox_Floor.AutoSize = true;
            this.checkBox_Floor.Location = new System.Drawing.Point(89, 106);
            this.checkBox_Floor.Name = "checkBox_Floor";
            this.checkBox_Floor.Size = new System.Drawing.Size(49, 17);
            this.checkBox_Floor.TabIndex = 0;
            this.checkBox_Floor.Text = "Floor";
            this.checkBox_Floor.UseVisualStyleBackColor = true;
            this.checkBox_Floor.CheckStateChanged += new System.EventHandler(this.checkBox_Asset_CheckStateChanged);
            // 
            // checkBox_Area
            // 
            this.checkBox_Area.AutoSize = true;
            this.checkBox_Area.Location = new System.Drawing.Point(89, 83);
            this.checkBox_Area.Name = "checkBox_Area";
            this.checkBox_Area.Size = new System.Drawing.Size(48, 17);
            this.checkBox_Area.TabIndex = 0;
            this.checkBox_Area.Text = "Area";
            this.checkBox_Area.UseVisualStyleBackColor = true;
            this.checkBox_Area.CheckStateChanged += new System.EventHandler(this.checkBox_Asset_CheckStateChanged);
            // 
            // checkBox_Building
            // 
            this.checkBox_Building.AutoSize = true;
            this.checkBox_Building.Location = new System.Drawing.Point(89, 60);
            this.checkBox_Building.Name = "checkBox_Building";
            this.checkBox_Building.Size = new System.Drawing.Size(63, 17);
            this.checkBox_Building.TabIndex = 0;
            this.checkBox_Building.Text = "Building";
            this.checkBox_Building.UseVisualStyleBackColor = true;
            this.checkBox_Building.CheckStateChanged += new System.EventHandler(this.checkBox_Asset_CheckStateChanged);
            // 
            // checkBox_Supplier
            // 
            this.checkBox_Supplier.AutoSize = true;
            this.checkBox_Supplier.Location = new System.Drawing.Point(88, 129);
            this.checkBox_Supplier.Name = "checkBox_Supplier";
            this.checkBox_Supplier.Size = new System.Drawing.Size(64, 17);
            this.checkBox_Supplier.TabIndex = 0;
            this.checkBox_Supplier.Text = "Supplier";
            this.checkBox_Supplier.UseVisualStyleBackColor = true;
            this.checkBox_Supplier.CheckStateChanged += new System.EventHandler(this.checkBox_Asset_CheckStateChanged);
            // 
            // checkBox_PurchaseOrder
            // 
            this.checkBox_PurchaseOrder.AutoSize = true;
            this.checkBox_PurchaseOrder.Enabled = false;
            this.checkBox_PurchaseOrder.Location = new System.Drawing.Point(237, 60);
            this.checkBox_PurchaseOrder.Name = "checkBox_PurchaseOrder";
            this.checkBox_PurchaseOrder.Size = new System.Drawing.Size(100, 17);
            this.checkBox_PurchaseOrder.TabIndex = 0;
            this.checkBox_PurchaseOrder.Text = "Purchase Order";
            this.checkBox_PurchaseOrder.UseVisualStyleBackColor = true;
            this.checkBox_PurchaseOrder.Visible = false;
            this.checkBox_PurchaseOrder.CheckStateChanged += new System.EventHandler(this.checkBox_Asset_CheckStateChanged);
            // 
            // checkBox_Asset
            // 
            this.checkBox_Asset.AutoSize = true;
            this.checkBox_Asset.Location = new System.Drawing.Point(89, 37);
            this.checkBox_Asset.Name = "checkBox_Asset";
            this.checkBox_Asset.Size = new System.Drawing.Size(52, 17);
            this.checkBox_Asset.TabIndex = 0;
            this.checkBox_Asset.Text = "Asset";
            this.checkBox_Asset.UseVisualStyleBackColor = true;
            this.checkBox_Asset.CheckStateChanged += new System.EventHandler(this.checkBox_Asset_CheckStateChanged);
            // 
            // groupBox_TableOfImport
            // 
            this.groupBox_TableOfImport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_TableOfImport.BackColor = System.Drawing.Color.Transparent;
            this.groupBox_TableOfImport.Controls.Add(this.checkBox_Asset);
            this.groupBox_TableOfImport.Controls.Add(this.checkBox_Floor);
            this.groupBox_TableOfImport.Controls.Add(this.checkBox_PurchaseOrder);
            this.groupBox_TableOfImport.Controls.Add(this.checkBox_Area);
            this.groupBox_TableOfImport.Controls.Add(this.checkBox_Supplier);
            this.groupBox_TableOfImport.Controls.Add(this.checkBox_Building);
            this.groupBox_TableOfImport.Location = new System.Drawing.Point(6, 118);
            this.groupBox_TableOfImport.Name = "groupBox_TableOfImport";
            this.groupBox_TableOfImport.Size = new System.Drawing.Size(437, 188);
            this.groupBox_TableOfImport.TabIndex = 6;
            this.groupBox_TableOfImport.TabStop = false;
            this.groupBox_TableOfImport.Text = "Table Of Import";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(12, 315);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            // 
            // Form_001008_ImportFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(210)))), ((int)(((byte)(238)))));
            this.ClientSize = new System.Drawing.Size(452, 337);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox_TableOfImport);
            this.Controls.Add(this.panel_PurchaseOrder);
            this.Name = "Form_001008_ImportFile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ID:001008(Import File)";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_001004_ImportFile_FormClosed);
            this.Enter += new System.EventHandler(this.Form_001008_ImportFile_Enter);
            this.Activated += new System.EventHandler(this.Form_001008_ImportFile_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_001008_ImportFile_FormClosing);
            this.Load += new System.EventHandler(this.Form_001008_ImportFile_Load);
            this.panel_PurchaseOrder.ResumeLayout(false);
            this.panel_PurchaseOrder.PerformLayout();
            this.groupBox_TableOfImport.ResumeLayout(false);
            this.groupBox_TableOfImport.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_PurchaseOrder;
        private System.Windows.Forms.Label LBL_FileType;
        private SimatSoft.CustomControl.SS_ComboBox sS_ComboBox_FileType;
        private System.Windows.Forms.CheckBox checkBox_Supplier;
        private System.Windows.Forms.CheckBox checkBox_PurchaseOrder;
        private System.Windows.Forms.CheckBox checkBox_Asset;
        private System.Windows.Forms.CheckBox checkBox_Floor;
        private System.Windows.Forms.CheckBox checkBox_Area;
        private System.Windows.Forms.CheckBox checkBox_Building;
        private System.Windows.Forms.Label LBL_FilePath;
        private SimatSoft.CustomControl.SS_ButtonGlass sS_ButtonGlass_Browse;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_PathFile;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_FacCode;
        private System.Windows.Forms.Label LBL_Company;
        private System.Windows.Forms.GroupBox groupBox_TableOfImport;
        private System.Windows.Forms.Label label2;
    }
}