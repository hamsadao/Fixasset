namespace SimatSoft.FixAsset
{
    partial class Form_001007_Upload_Download_HH
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_001007_Upload_Download_HH));
            this.checkBox_DownloadCheckStock = new System.Windows.Forms.CheckBox();
            this.checkBox_DownloadAsset = new System.Windows.Forms.CheckBox();
            this.groupBox_Download = new System.Windows.Forms.GroupBox();
            this.picBoxSync = new System.Windows.Forms.PictureBox();
            this.checkBox_UploadAsset = new System.Windows.Forms.CheckBox();
            this.groupBox_Upload = new System.Windows.Forms.GroupBox();
            this.checkBoxAssetpic = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox_UploadCompany = new System.Windows.Forms.CheckBox();
            this.checkBox_UploadSuplier = new System.Windows.Forms.CheckBox();
            this.checkBox_UploadPurchaseOrder = new System.Windows.Forms.CheckBox();
            this.checkBox_UploadArea = new System.Windows.Forms.CheckBox();
            this.checkBox_UploadFloor = new System.Windows.Forms.CheckBox();
            this.checkBox_UploadBuilding = new System.Windows.Forms.CheckBox();
            this.LBL_UploadSelected = new System.Windows.Forms.Label();
            this.dataGridView_Data = new System.Windows.Forms.DataGridView();
            this.lbl_StatusSync = new System.Windows.Forms.Label();
            this.imgLst_SelectFile = new System.Windows.Forms.ImageList(this.components);
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.LBL_FileComplete = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listView_Complete = new System.Windows.Forms.ListView();
            this.colNo = new System.Windows.Forms.ColumnHeader();
            this.colFileName = new System.Windows.Forms.ColumnHeader();
            this.colFileSize = new System.Windows.Forms.ColumnHeader();
            this.colStatus = new System.Windows.Forms.ColumnHeader();
            this.listView_Error = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.lbl_ShowStatus = new System.Windows.Forms.Label();
            this.LBL_TotalError = new System.Windows.Forms.Label();
            this.groupBox_Download.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSync)).BeginInit();
            this.groupBox_Upload.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Data)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBox_DownloadCheckStock
            // 
            this.checkBox_DownloadCheckStock.AutoSize = true;
            this.checkBox_DownloadCheckStock.Checked = true;
            this.checkBox_DownloadCheckStock.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_DownloadCheckStock.Location = new System.Drawing.Point(77, 55);
            this.checkBox_DownloadCheckStock.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_DownloadCheckStock.Name = "checkBox_DownloadCheckStock";
            this.checkBox_DownloadCheckStock.Size = new System.Drawing.Size(104, 21);
            this.checkBox_DownloadCheckStock.TabIndex = 7;
            this.checkBox_DownloadCheckStock.Tag = "1";
            this.checkBox_DownloadCheckStock.Text = "CheckStock";
            this.checkBox_DownloadCheckStock.UseVisualStyleBackColor = true;
            this.checkBox_DownloadCheckStock.CheckStateChanged += new System.EventHandler(this.checkBox_UploadAsset_CheckStateChanged);
            // 
            // checkBox_DownloadAsset
            // 
            this.checkBox_DownloadAsset.AutoSize = true;
            this.checkBox_DownloadAsset.Location = new System.Drawing.Point(77, 27);
            this.checkBox_DownloadAsset.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_DownloadAsset.Name = "checkBox_DownloadAsset";
            this.checkBox_DownloadAsset.Size = new System.Drawing.Size(137, 21);
            this.checkBox_DownloadAsset.TabIndex = 6;
            this.checkBox_DownloadAsset.Tag = "1";
            this.checkBox_DownloadAsset.Text = "AssetCheckstock";
            this.checkBox_DownloadAsset.UseVisualStyleBackColor = true;
            this.checkBox_DownloadAsset.CheckStateChanged += new System.EventHandler(this.checkBox_UploadAsset_CheckStateChanged);
            // 
            // groupBox_Download
            // 
            this.groupBox_Download.BackColor = System.Drawing.Color.Transparent;
            this.groupBox_Download.Controls.Add(this.checkBox_DownloadCheckStock);
            this.groupBox_Download.Controls.Add(this.checkBox_DownloadAsset);
            this.groupBox_Download.Location = new System.Drawing.Point(32, 15);
            this.groupBox_Download.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox_Download.Name = "groupBox_Download";
            this.groupBox_Download.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox_Download.Size = new System.Drawing.Size(527, 108);
            this.groupBox_Download.TabIndex = 12;
            this.groupBox_Download.TabStop = false;
            this.groupBox_Download.Text = "Download_From_Handheld";
            // 
            // picBoxSync
            // 
            this.picBoxSync.BackColor = System.Drawing.Color.Transparent;
            this.picBoxSync.Image = ((System.Drawing.Image)(resources.GetObject("picBoxSync.Image")));
            this.picBoxSync.Location = new System.Drawing.Point(516, 289);
            this.picBoxSync.Margin = new System.Windows.Forms.Padding(4);
            this.picBoxSync.Name = "picBoxSync";
            this.picBoxSync.Size = new System.Drawing.Size(32, 32);
            this.picBoxSync.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picBoxSync.TabIndex = 9;
            this.picBoxSync.TabStop = false;
            this.picBoxSync.Click += new System.EventHandler(this.picBoxSync_Click);
            // 
            // checkBox_UploadAsset
            // 
            this.checkBox_UploadAsset.AutoSize = true;
            this.checkBox_UploadAsset.Location = new System.Drawing.Point(76, 34);
            this.checkBox_UploadAsset.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_UploadAsset.Name = "checkBox_UploadAsset";
            this.checkBox_UploadAsset.Size = new System.Drawing.Size(65, 21);
            this.checkBox_UploadAsset.TabIndex = 0;
            this.checkBox_UploadAsset.Text = "Asset";
            this.checkBox_UploadAsset.UseVisualStyleBackColor = true;
            this.checkBox_UploadAsset.CheckedChanged += new System.EventHandler(this.checkBox_UploadAsset_CheckedChanged);
            this.checkBox_UploadAsset.CheckStateChanged += new System.EventHandler(this.checkBox_UploadAsset_CheckStateChanged);
            // 
            // groupBox_Upload
            // 
            this.groupBox_Upload.BackColor = System.Drawing.Color.Transparent;
            this.groupBox_Upload.Controls.Add(this.checkBoxAssetpic);
            this.groupBox_Upload.Controls.Add(this.checkBox2);
            this.groupBox_Upload.Controls.Add(this.checkBox1);
            this.groupBox_Upload.Controls.Add(this.checkBox_UploadCompany);
            this.groupBox_Upload.Controls.Add(this.checkBox_UploadSuplier);
            this.groupBox_Upload.Controls.Add(this.checkBox_UploadPurchaseOrder);
            this.groupBox_Upload.Controls.Add(this.checkBox_UploadArea);
            this.groupBox_Upload.Controls.Add(this.checkBox_UploadFloor);
            this.groupBox_Upload.Controls.Add(this.checkBox_UploadBuilding);
            this.groupBox_Upload.Controls.Add(this.checkBox_UploadAsset);
            this.groupBox_Upload.Location = new System.Drawing.Point(33, 130);
            this.groupBox_Upload.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox_Upload.Name = "groupBox_Upload";
            this.groupBox_Upload.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox_Upload.Size = new System.Drawing.Size(525, 151);
            this.groupBox_Upload.TabIndex = 13;
            this.groupBox_Upload.TabStop = false;
            this.groupBox_Upload.Text = "Upload_To_Handheld";
            // 
            // checkBoxAssetpic
            // 
            this.checkBoxAssetpic.AutoSize = true;
            this.checkBoxAssetpic.Location = new System.Drawing.Point(341, 91);
            this.checkBoxAssetpic.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxAssetpic.Name = "checkBoxAssetpic";
            this.checkBoxAssetpic.Size = new System.Drawing.Size(113, 21);
            this.checkBoxAssetpic.TabIndex = 4;
            this.checkBoxAssetpic.Text = "Asset Picture";
            this.checkBoxAssetpic.UseVisualStyleBackColor = true;
            this.checkBoxAssetpic.Visible = false;
            this.checkBoxAssetpic.CheckStateChanged += new System.EventHandler(this.checkBoxAssetpic_CheckStateChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(189, 32);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(68, 21);
            this.checkBox2.TabIndex = 3;
            this.checkBox2.Text = "Model";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            this.checkBox2.CheckStateChanged += new System.EventHandler(this.checkBox2_CheckStateChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(189, 96);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(60, 21);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "User";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckStateChanged += new System.EventHandler(this.checkBox1_CheckStateChanged);
            // 
            // checkBox_UploadCompany
            // 
            this.checkBox_UploadCompany.AutoSize = true;
            this.checkBox_UploadCompany.Location = new System.Drawing.Point(189, 64);
            this.checkBox_UploadCompany.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_UploadCompany.Name = "checkBox_UploadCompany";
            this.checkBox_UploadCompany.Size = new System.Drawing.Size(89, 21);
            this.checkBox_UploadCompany.TabIndex = 0;
            this.checkBox_UploadCompany.Text = "Company";
            this.checkBox_UploadCompany.UseVisualStyleBackColor = true;
            this.checkBox_UploadCompany.CheckStateChanged += new System.EventHandler(this.checkBox_UploadAsset_CheckStateChanged);
            // 
            // checkBox_UploadSuplier
            // 
            this.checkBox_UploadSuplier.AutoSize = true;
            this.checkBox_UploadSuplier.Enabled = false;
            this.checkBox_UploadSuplier.Location = new System.Drawing.Point(341, 63);
            this.checkBox_UploadSuplier.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_UploadSuplier.Name = "checkBox_UploadSuplier";
            this.checkBox_UploadSuplier.Size = new System.Drawing.Size(74, 21);
            this.checkBox_UploadSuplier.TabIndex = 0;
            this.checkBox_UploadSuplier.Text = "Suplier";
            this.checkBox_UploadSuplier.UseVisualStyleBackColor = true;
            this.checkBox_UploadSuplier.Visible = false;
            this.checkBox_UploadSuplier.CheckStateChanged += new System.EventHandler(this.checkBox_UploadAsset_CheckStateChanged);
            // 
            // checkBox_UploadPurchaseOrder
            // 
            this.checkBox_UploadPurchaseOrder.AutoSize = true;
            this.checkBox_UploadPurchaseOrder.Enabled = false;
            this.checkBox_UploadPurchaseOrder.Location = new System.Drawing.Point(341, 34);
            this.checkBox_UploadPurchaseOrder.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_UploadPurchaseOrder.Name = "checkBox_UploadPurchaseOrder";
            this.checkBox_UploadPurchaseOrder.Size = new System.Drawing.Size(131, 21);
            this.checkBox_UploadPurchaseOrder.TabIndex = 0;
            this.checkBox_UploadPurchaseOrder.Text = "Purchase Order";
            this.checkBox_UploadPurchaseOrder.UseVisualStyleBackColor = true;
            this.checkBox_UploadPurchaseOrder.Visible = false;
            this.checkBox_UploadPurchaseOrder.CheckStateChanged += new System.EventHandler(this.checkBox_UploadAsset_CheckStateChanged);
            // 
            // checkBox_UploadArea
            // 
            this.checkBox_UploadArea.AutoSize = true;
            this.checkBox_UploadArea.Location = new System.Drawing.Point(76, 122);
            this.checkBox_UploadArea.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_UploadArea.Name = "checkBox_UploadArea";
            this.checkBox_UploadArea.Size = new System.Drawing.Size(60, 21);
            this.checkBox_UploadArea.TabIndex = 0;
            this.checkBox_UploadArea.Text = "Area";
            this.checkBox_UploadArea.UseVisualStyleBackColor = true;
            this.checkBox_UploadArea.CheckStateChanged += new System.EventHandler(this.checkBox_UploadAsset_CheckStateChanged);
            // 
            // checkBox_UploadFloor
            // 
            this.checkBox_UploadFloor.AutoSize = true;
            this.checkBox_UploadFloor.Location = new System.Drawing.Point(76, 94);
            this.checkBox_UploadFloor.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_UploadFloor.Name = "checkBox_UploadFloor";
            this.checkBox_UploadFloor.Size = new System.Drawing.Size(62, 21);
            this.checkBox_UploadFloor.TabIndex = 0;
            this.checkBox_UploadFloor.Text = "Floor";
            this.checkBox_UploadFloor.UseVisualStyleBackColor = true;
            this.checkBox_UploadFloor.CheckStateChanged += new System.EventHandler(this.checkBox_UploadAsset_CheckStateChanged);
            // 
            // checkBox_UploadBuilding
            // 
            this.checkBox_UploadBuilding.AutoSize = true;
            this.checkBox_UploadBuilding.Location = new System.Drawing.Point(76, 64);
            this.checkBox_UploadBuilding.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_UploadBuilding.Name = "checkBox_UploadBuilding";
            this.checkBox_UploadBuilding.Size = new System.Drawing.Size(80, 21);
            this.checkBox_UploadBuilding.TabIndex = 0;
            this.checkBox_UploadBuilding.Text = "Building";
            this.checkBox_UploadBuilding.UseVisualStyleBackColor = true;
            this.checkBox_UploadBuilding.CheckStateChanged += new System.EventHandler(this.checkBox_UploadAsset_CheckStateChanged);
            // 
            // LBL_UploadSelected
            // 
            this.LBL_UploadSelected.AutoSize = true;
            this.LBL_UploadSelected.BackColor = System.Drawing.Color.Transparent;
            this.LBL_UploadSelected.Location = new System.Drawing.Point(29, 309);
            this.LBL_UploadSelected.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBL_UploadSelected.Name = "LBL_UploadSelected";
            this.LBL_UploadSelected.Size = new System.Drawing.Size(104, 17);
            this.LBL_UploadSelected.TabIndex = 1;
            this.LBL_UploadSelected.Text = "Table Seleted: ";
            // 
            // dataGridView_Data
            // 
            this.dataGridView_Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Data.Location = new System.Drawing.Point(561, 4);
            this.dataGridView_Data.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView_Data.Name = "dataGridView_Data";
            this.dataGridView_Data.Size = new System.Drawing.Size(31, 50);
            this.dataGridView_Data.TabIndex = 14;
            this.dataGridView_Data.Visible = false;
            // 
            // lbl_StatusSync
            // 
            this.lbl_StatusSync.AutoSize = true;
            this.lbl_StatusSync.Location = new System.Drawing.Point(371, 309);
            this.lbl_StatusSync.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_StatusSync.Name = "lbl_StatusSync";
            this.lbl_StatusSync.Size = new System.Drawing.Size(79, 17);
            this.lbl_StatusSync.TabIndex = 10;
            this.lbl_StatusSync.Text = "StatusSync";
            // 
            // imgLst_SelectFile
            // 
            this.imgLst_SelectFile.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgLst_SelectFile.ImageStream")));
            this.imgLst_SelectFile.TransparentColor = System.Drawing.Color.Transparent;
            this.imgLst_SelectFile.Images.SetKeyName(0, "free_icon_business_235.gif");
            this.imgLst_SelectFile.Images.SetKeyName(1, "free_icon_business_231.gif");
            this.imgLst_SelectFile.Images.SetKeyName(2, "Sync.gif");
            this.imgLst_SelectFile.Images.SetKeyName(3, "CopyFile.gif");
            this.imgLst_SelectFile.Images.SetKeyName(4, "kdisknav.gif");
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(33, 484);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(527, 21);
            this.progressBar1.TabIndex = 16;
            // 
            // LBL_FileComplete
            // 
            this.LBL_FileComplete.AutoSize = true;
            this.LBL_FileComplete.Location = new System.Drawing.Point(41, 337);
            this.LBL_FileComplete.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBL_FileComplete.Name = "LBL_FileComplete";
            this.LBL_FileComplete.Size = new System.Drawing.Size(71, 17);
            this.LBL_FileComplete.TabIndex = 17;
            this.LBL_FileComplete.Text = "Complete:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 519);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 17);
            this.label1.TabIndex = 17;
            this.label1.Text = "Errors:";
            // 
            // listView_Complete
            // 
            this.listView_Complete.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colNo,
            this.colFileName,
            this.colFileSize,
            this.colStatus});
            this.listView_Complete.FullRowSelect = true;
            this.listView_Complete.GridLines = true;
            this.listView_Complete.Location = new System.Drawing.Point(33, 357);
            this.listView_Complete.Margin = new System.Windows.Forms.Padding(4);
            this.listView_Complete.Name = "listView_Complete";
            this.listView_Complete.Size = new System.Drawing.Size(525, 118);
            this.listView_Complete.TabIndex = 18;
            this.listView_Complete.UseCompatibleStateImageBehavior = false;
            this.listView_Complete.View = System.Windows.Forms.View.Details;
            // 
            // colNo
            // 
            this.colNo.Text = "No";
            // 
            // colFileName
            // 
            this.colFileName.Text = "FileName";
            this.colFileName.Width = 150;
            // 
            // colFileSize
            // 
            this.colFileSize.Text = "FileSize";
            this.colFileSize.Width = 80;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            this.colStatus.Width = 100;
            // 
            // listView_Error
            // 
            this.listView_Error.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listView_Error.FullRowSelect = true;
            this.listView_Error.GridLines = true;
            this.listView_Error.Location = new System.Drawing.Point(32, 539);
            this.listView_Error.Margin = new System.Windows.Forms.Padding(4);
            this.listView_Error.Name = "listView_Error";
            this.listView_Error.Size = new System.Drawing.Size(525, 118);
            this.listView_Error.TabIndex = 18;
            this.listView_Error.UseCompatibleStateImageBehavior = false;
            this.listView_Error.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "No";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "FileName";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "FileSize";
            this.columnHeader3.Width = 80;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Status";
            this.columnHeader4.Width = 100;
            // 
            // lbl_ShowStatus
            // 
            this.lbl_ShowStatus.BackColor = System.Drawing.Color.Transparent;
            this.lbl_ShowStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbl_ShowStatus.ForeColor = System.Drawing.Color.ForestGreen;
            this.lbl_ShowStatus.Location = new System.Drawing.Point(28, 662);
            this.lbl_ShowStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_ShowStatus.Name = "lbl_ShowStatus";
            this.lbl_ShowStatus.Size = new System.Drawing.Size(223, 20);
            this.lbl_ShowStatus.TabIndex = 19;
            this.lbl_ShowStatus.Text = "...";
            this.lbl_ShowStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LBL_TotalError
            // 
            this.LBL_TotalError.BackColor = System.Drawing.Color.Transparent;
            this.LBL_TotalError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.LBL_TotalError.ForeColor = System.Drawing.Color.Maroon;
            this.LBL_TotalError.Location = new System.Drawing.Point(335, 662);
            this.LBL_TotalError.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBL_TotalError.Name = "LBL_TotalError";
            this.LBL_TotalError.Size = new System.Drawing.Size(225, 20);
            this.LBL_TotalError.TabIndex = 19;
            this.LBL_TotalError.Text = "...";
            this.LBL_TotalError.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Form_001007_Upload_Download_HH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(210)))), ((int)(((byte)(238)))));
            this.ClientSize = new System.Drawing.Size(589, 688);
            this.Controls.Add(this.LBL_TotalError);
            this.Controls.Add(this.lbl_ShowStatus);
            this.Controls.Add(this.listView_Error);
            this.Controls.Add(this.listView_Complete);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LBL_FileComplete);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.picBoxSync);
            this.Controls.Add(this.dataGridView_Data);
            this.Controls.Add(this.lbl_StatusSync);
            this.Controls.Add(this.LBL_UploadSelected);
            this.Controls.Add(this.groupBox_Upload);
            this.Controls.Add(this.groupBox_Download);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form_001007_Upload_Download_HH";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ID:001007(Upload/Download With Handheld)";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_001003_Upload_Download_HH_FormClosed);
            this.Enter += new System.EventHandler(this.Form_001007_Upload_Download_HH_Enter);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_001007_Upload_Download_HH_FormClosing);
            this.Load += new System.EventHandler(this.Form_001007_Upload_Download_HH_Load);
            this.groupBox_Download.ResumeLayout(false);
            this.groupBox_Download.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxSync)).EndInit();
            this.groupBox_Upload.ResumeLayout(false);
            this.groupBox_Upload.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Data)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox_DownloadCheckStock;
        private System.Windows.Forms.CheckBox checkBox_DownloadAsset;
        private System.Windows.Forms.GroupBox groupBox_Download;
        private System.Windows.Forms.CheckBox checkBox_UploadAsset;
        private System.Windows.Forms.GroupBox groupBox_Upload;
        private System.Windows.Forms.CheckBox checkBox_UploadArea;
        private System.Windows.Forms.CheckBox checkBox_UploadFloor;
        private System.Windows.Forms.CheckBox checkBox_UploadBuilding;
        private System.Windows.Forms.Label LBL_UploadSelected;
        private System.Windows.Forms.DataGridView dataGridView_Data;
        private System.Windows.Forms.CheckBox checkBox_UploadSuplier;
        private System.Windows.Forms.CheckBox checkBox_UploadPurchaseOrder;
        private System.Windows.Forms.CheckBox checkBox_UploadCompany;
        private System.Windows.Forms.PictureBox picBoxSync;
        private System.Windows.Forms.Label lbl_StatusSync;
        private System.Windows.Forms.ImageList imgLst_SelectFile;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label LBL_FileComplete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView_Complete;
        private System.Windows.Forms.ColumnHeader colNo;
        private System.Windows.Forms.ColumnHeader colFileName;
        private System.Windows.Forms.ColumnHeader colFileSize;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.ListView listView_Error;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label lbl_ShowStatus;
        private System.Windows.Forms.Label LBL_TotalError;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBoxAssetpic;
    }
}