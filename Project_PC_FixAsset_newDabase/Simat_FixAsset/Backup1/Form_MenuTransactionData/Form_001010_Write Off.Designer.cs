namespace SimatSoft.FixAsset
{
    partial class Form_001010_WriteOff
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
            this.dateTimePicker_ReceivePODate = new System.Windows.Forms.DateTimePicker();
            this.sS_MaskedTextBox_FacName = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.sS_ComboBox_Type = new SimatSoft.CustomControl.SS_ComboBox();
            this.sS_MaskedTextBox_DeptName = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.panel_PurchaseOrder = new System.Windows.Forms.Panel();
            this.sS_MaskedTextBox_Facility = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.sS_MaskedTextBox_Remark = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.sS_MaskedTextBox_DepartmentNo = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.sS_MaskedTextBox_PO = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.LBL_CompanyNo = new System.Windows.Forms.Label();
            this.LBL_Remark = new System.Windows.Forms.Label();
            this.LBL_Type = new System.Windows.Forms.Label();
            this.LBL_DepartmentNo = new System.Windows.Forms.Label();
            this.LBL_Date = new System.Windows.Forms.Label();
            this.LBL_PONo = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_Record = new System.Windows.Forms.ToolStripStatusLabel();
            this.LBL_Detail = new System.Windows.Forms.Label();
            this.LBL_AssetDetail = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.sS_DataGridView_AssetReceive = new SimatSoft.CustomControl.SS_DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustodianID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.sS_DataGridView_ReceivePO = new SimatSoft.CustomControl.SS_DataGridView();
            this.Line = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModelID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModelName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel_PurchaseOrder.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sS_DataGridView_AssetReceive)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sS_DataGridView_ReceivePO)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker_ReceivePODate
            // 
            this.dateTimePicker_ReceivePODate.Location = new System.Drawing.Point(175, 62);
            this.dateTimePicker_ReceivePODate.Name = "dateTimePicker_ReceivePODate";
            this.dateTimePicker_ReceivePODate.Size = new System.Drawing.Size(128, 20);
            this.dateTimePicker_ReceivePODate.TabIndex = 24;
            // 
            // sS_MaskedTextBox_FacName
            // 
            this.sS_MaskedTextBox_FacName.BackColor = System.Drawing.Color.LightCyan;
            this.sS_MaskedTextBox_FacName.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_FacName.BackColorOnLeave = System.Drawing.Color.LightCyan;
            this.sS_MaskedTextBox_FacName.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_FacName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_FacName.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_FacName.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_FacName.IconError = null;
            this.sS_MaskedTextBox_FacName.IconTrue = null;
            this.sS_MaskedTextBox_FacName.Location = new System.Drawing.Point(306, 148);
            this.sS_MaskedTextBox_FacName.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_FacName.Name = "sS_MaskedTextBox_FacName";
            this.sS_MaskedTextBox_FacName.Size = new System.Drawing.Size(196, 23);
            this.sS_MaskedTextBox_FacName.TabIndex = 22;
            // 
            // sS_ComboBox_Type
            // 
            this.sS_ComboBox_Type.BackColor = System.Drawing.Color.Honeydew;
            this.sS_ComboBox_Type.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_ComboBox_Type.BackColorOnLeave = System.Drawing.Color.Honeydew;
            this.sS_ComboBox_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sS_ComboBox_Type.FormattingEnabled = true;
            this.sS_ComboBox_Type.Items.AddRange(new object[] {
            "WRO",
            "SALE"});
            this.sS_ComboBox_Type.Location = new System.Drawing.Point(176, 84);
            this.sS_ComboBox_Type.Name = "sS_ComboBox_Type";
            this.sS_ComboBox_Type.Size = new System.Drawing.Size(128, 21);
            this.sS_ComboBox_Type.TabIndex = 19;
            // 
            // sS_MaskedTextBox_DeptName
            // 
            this.sS_MaskedTextBox_DeptName.BackColor = System.Drawing.Color.LightCyan;
            this.sS_MaskedTextBox_DeptName.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_DeptName.BackColorOnLeave = System.Drawing.Color.LightCyan;
            this.sS_MaskedTextBox_DeptName.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_DeptName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_DeptName.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_DeptName.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_DeptName.IconError = null;
            this.sS_MaskedTextBox_DeptName.IconTrue = null;
            this.sS_MaskedTextBox_DeptName.Location = new System.Drawing.Point(306, 36);
            this.sS_MaskedTextBox_DeptName.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_DeptName.Name = "sS_MaskedTextBox_DeptName";
            this.sS_MaskedTextBox_DeptName.Size = new System.Drawing.Size(196, 23);
            this.sS_MaskedTextBox_DeptName.TabIndex = 18;
            // 
            // panel_PurchaseOrder
            // 
            this.panel_PurchaseOrder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_PurchaseOrder.BackColor = System.Drawing.Color.Transparent;
            this.panel_PurchaseOrder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_PurchaseOrder.Controls.Add(this.dateTimePicker_ReceivePODate);
            this.panel_PurchaseOrder.Controls.Add(this.sS_MaskedTextBox_FacName);
            this.panel_PurchaseOrder.Controls.Add(this.sS_ComboBox_Type);
            this.panel_PurchaseOrder.Controls.Add(this.sS_MaskedTextBox_DeptName);
            this.panel_PurchaseOrder.Controls.Add(this.sS_MaskedTextBox_Facility);
            this.panel_PurchaseOrder.Controls.Add(this.sS_MaskedTextBox_Remark);
            this.panel_PurchaseOrder.Controls.Add(this.sS_MaskedTextBox_DepartmentNo);
            this.panel_PurchaseOrder.Controls.Add(this.sS_MaskedTextBox_PO);
            this.panel_PurchaseOrder.Controls.Add(this.LBL_CompanyNo);
            this.panel_PurchaseOrder.Controls.Add(this.LBL_Remark);
            this.panel_PurchaseOrder.Controls.Add(this.LBL_Type);
            this.panel_PurchaseOrder.Controls.Add(this.LBL_DepartmentNo);
            this.panel_PurchaseOrder.Controls.Add(this.LBL_Date);
            this.panel_PurchaseOrder.Controls.Add(this.LBL_PONo);
            this.panel_PurchaseOrder.Location = new System.Drawing.Point(2, 0);
            this.panel_PurchaseOrder.Name = "panel_PurchaseOrder";
            this.panel_PurchaseOrder.Size = new System.Drawing.Size(981, 189);
            this.panel_PurchaseOrder.TabIndex = 21;
            // 
            // sS_MaskedTextBox_Facility
            // 
            this.sS_MaskedTextBox_Facility.BackColor = System.Drawing.Color.Lavender;
            this.sS_MaskedTextBox_Facility.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_Facility.BackColorOnLeave = System.Drawing.Color.Lavender;
            this.sS_MaskedTextBox_Facility.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_Facility.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_Facility.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_Facility.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_Facility.IconError = null;
            this.sS_MaskedTextBox_Facility.IconTrue = null;
            this.sS_MaskedTextBox_Facility.Location = new System.Drawing.Point(175, 148);
            this.sS_MaskedTextBox_Facility.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_Facility.Name = "sS_MaskedTextBox_Facility";
            this.sS_MaskedTextBox_Facility.Size = new System.Drawing.Size(128, 23);
            this.sS_MaskedTextBox_Facility.TabIndex = 14;
            this.sS_MaskedTextBox_Facility.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sS_MaskedTextBox_Facility_KeyDown);
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
            this.sS_MaskedTextBox_Remark.Location = new System.Drawing.Point(175, 108);
            this.sS_MaskedTextBox_Remark.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_Remark.Multiline = true;
            this.sS_MaskedTextBox_Remark.Name = "sS_MaskedTextBox_Remark";
            this.sS_MaskedTextBox_Remark.Size = new System.Drawing.Size(327, 37);
            this.sS_MaskedTextBox_Remark.TabIndex = 12;
            // 
            // sS_MaskedTextBox_DepartmentNo
            // 
            this.sS_MaskedTextBox_DepartmentNo.BackColor = System.Drawing.Color.Lavender;
            this.sS_MaskedTextBox_DepartmentNo.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_DepartmentNo.BackColorOnLeave = System.Drawing.Color.Lavender;
            this.sS_MaskedTextBox_DepartmentNo.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_DepartmentNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_DepartmentNo.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_DepartmentNo.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_DepartmentNo.IconError = null;
            this.sS_MaskedTextBox_DepartmentNo.IconTrue = null;
            this.sS_MaskedTextBox_DepartmentNo.Location = new System.Drawing.Point(175, 36);
            this.sS_MaskedTextBox_DepartmentNo.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_DepartmentNo.Name = "sS_MaskedTextBox_DepartmentNo";
            this.sS_MaskedTextBox_DepartmentNo.Size = new System.Drawing.Size(128, 23);
            this.sS_MaskedTextBox_DepartmentNo.TabIndex = 10;
            this.sS_MaskedTextBox_DepartmentNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sS_MaskedTextBox_DepartmentNo_KeyDown);
            // 
            // sS_MaskedTextBox_PO
            // 
            this.sS_MaskedTextBox_PO.BackColor = System.Drawing.Color.Honeydew;
            this.sS_MaskedTextBox_PO.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_PO.BackColorOnLeave = System.Drawing.Color.Honeydew;
            this.sS_MaskedTextBox_PO.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_PO.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_PO.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_PO.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_PO.IconError = null;
            this.sS_MaskedTextBox_PO.IconTrue = null;
            this.sS_MaskedTextBox_PO.Location = new System.Drawing.Point(175, 11);
            this.sS_MaskedTextBox_PO.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_PO.Name = "sS_MaskedTextBox_PO";
            this.sS_MaskedTextBox_PO.Size = new System.Drawing.Size(128, 23);
            this.sS_MaskedTextBox_PO.TabIndex = 4;
            // 
            // LBL_CompanyNo
            // 
            this.LBL_CompanyNo.AutoSize = true;
            this.LBL_CompanyNo.ForeColor = System.Drawing.Color.Black;
            this.LBL_CompanyNo.Location = new System.Drawing.Point(49, 148);
            this.LBL_CompanyNo.Name = "LBL_CompanyNo";
            this.LBL_CompanyNo.Size = new System.Drawing.Size(57, 13);
            this.LBL_CompanyNo.TabIndex = 2;
            this.LBL_CompanyNo.Text = "Company :";
            // 
            // LBL_Remark
            // 
            this.LBL_Remark.AutoSize = true;
            this.LBL_Remark.Location = new System.Drawing.Point(50, 108);
            this.LBL_Remark.Name = "LBL_Remark";
            this.LBL_Remark.Size = new System.Drawing.Size(47, 13);
            this.LBL_Remark.TabIndex = 2;
            this.LBL_Remark.Text = "Remark:";
            // 
            // LBL_Type
            // 
            this.LBL_Type.AutoSize = true;
            this.LBL_Type.Location = new System.Drawing.Point(50, 84);
            this.LBL_Type.Name = "LBL_Type";
            this.LBL_Type.Size = new System.Drawing.Size(34, 13);
            this.LBL_Type.TabIndex = 2;
            this.LBL_Type.Text = "Type:";
            // 
            // LBL_DepartmentNo
            // 
            this.LBL_DepartmentNo.AutoSize = true;
            this.LBL_DepartmentNo.Location = new System.Drawing.Point(50, 36);
            this.LBL_DepartmentNo.Name = "LBL_DepartmentNo";
            this.LBL_DepartmentNo.Size = new System.Drawing.Size(68, 13);
            this.LBL_DepartmentNo.TabIndex = 2;
            this.LBL_DepartmentNo.Text = "Department :";
            // 
            // LBL_Date
            // 
            this.LBL_Date.AutoSize = true;
            this.LBL_Date.Location = new System.Drawing.Point(49, 62);
            this.LBL_Date.Name = "LBL_Date";
            this.LBL_Date.Size = new System.Drawing.Size(33, 13);
            this.LBL_Date.TabIndex = 2;
            this.LBL_Date.Text = "Date:";
            // 
            // LBL_PONo
            // 
            this.LBL_PONo.AutoSize = true;
            this.LBL_PONo.Location = new System.Drawing.Point(50, 16);
            this.LBL_PONo.Name = "LBL_PONo";
            this.LBL_PONo.Size = new System.Drawing.Size(45, 13);
            this.LBL_PONo.TabIndex = 2;
            this.LBL_PONo.Text = "PO No :";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Highlight;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_Record});
            this.statusStrip1.Location = new System.Drawing.Point(0, 393);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(989, 22);
            this.statusStrip1.TabIndex = 23;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel_Record
            // 
            this.toolStripStatusLabel_Record.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabel_Record.Name = "toolStripStatusLabel_Record";
            this.toolStripStatusLabel_Record.Size = new System.Drawing.Size(79, 17);
            this.toolStripStatusLabel_Record.Text = "[1/All] records";
            // 
            // LBL_Detail
            // 
            this.LBL_Detail.AutoSize = true;
            this.LBL_Detail.Location = new System.Drawing.Point(0, 192);
            this.LBL_Detail.Name = "LBL_Detail";
            this.LBL_Detail.Size = new System.Drawing.Size(34, 13);
            this.LBL_Detail.TabIndex = 20;
            this.LBL_Detail.Text = "Detail";
            // 
            // LBL_AssetDetail
            // 
            this.LBL_AssetDetail.AutoSize = true;
            this.LBL_AssetDetail.Location = new System.Drawing.Point(-1, 380);
            this.LBL_AssetDetail.Name = "LBL_AssetDetail";
            this.LBL_AssetDetail.Size = new System.Drawing.Size(66, 13);
            this.LBL_AssetDetail.TabIndex = 19;
            this.LBL_AssetDetail.Text = "Asset Detail:";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.sS_DataGridView_AssetReceive);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 415);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(989, 148);
            this.panel1.TabIndex = 24;
            // 
            // sS_DataGridView_AssetReceive
            // 
            this.sS_DataGridView_AssetReceive.AllowUserToDeleteRows = false;
            this.sS_DataGridView_AssetReceive.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.sS_DataGridView_AssetReceive.BackColorCellFocus = System.Drawing.Color.LightBlue;
            this.sS_DataGridView_AssetReceive.BackColorCellLeave = System.Drawing.Color.Honeydew;
            this.sS_DataGridView_AssetReceive.BackColorRow = System.Drawing.Color.HotPink;
            this.sS_DataGridView_AssetReceive.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sS_DataGridView_AssetReceive.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sS_DataGridView_AssetReceive.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.CustodianID,
            this.Column12});
            this.sS_DataGridView_AssetReceive.Location = new System.Drawing.Point(0, 0);
            this.sS_DataGridView_AssetReceive.Name = "sS_DataGridView_AssetReceive";
            this.sS_DataGridView_AssetReceive.Size = new System.Drawing.Size(982, 144);
            this.sS_DataGridView_AssetReceive.TabIndex = 2;
            this.sS_DataGridView_AssetReceive.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.sS_DataGridView_AssetReceive_CellBeginEdit);
            this.sS_DataGridView_AssetReceive.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.sS_DataGridView_AssetReceive_RowsAdded);
            // 
            // No
            // 
            this.No.FillWeight = 50F;
            this.No.HeaderText = "No.";
            this.No.Name = "No";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Asset No";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Asset Name";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "ModelID";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "SerialNo";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "FloorID";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "BuildingID";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "AreaID";
            this.Column8.Name = "Column8";
            // 
            // CustodianID
            // 
            this.CustodianID.HeaderText = "CustodianID";
            this.CustodianID.Name = "CustodianID";
            // 
            // Column12
            // 
            this.Column12.HeaderText = "Remark";
            this.Column12.Name = "Column12";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.sS_DataGridView_ReceivePO);
            this.panel2.Location = new System.Drawing.Point(3, 208);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(980, 169);
            this.panel2.TabIndex = 22;
            // 
            // sS_DataGridView_ReceivePO
            // 
            this.sS_DataGridView_ReceivePO.AllowUserToDeleteRows = false;
            this.sS_DataGridView_ReceivePO.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.sS_DataGridView_ReceivePO.BackColorCellFocus = System.Drawing.Color.LightBlue;
            this.sS_DataGridView_ReceivePO.BackColorCellLeave = System.Drawing.Color.Honeydew;
            this.sS_DataGridView_ReceivePO.BackColorRow = System.Drawing.Color.HotPink;
            this.sS_DataGridView_ReceivePO.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sS_DataGridView_ReceivePO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sS_DataGridView_ReceivePO.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Line,
            this.ModelID,
            this.ModelName,
            this.Column1,
            this.Price,
            this.Cost,
            this.Remark});
            this.sS_DataGridView_ReceivePO.Location = new System.Drawing.Point(-2, -2);
            this.sS_DataGridView_ReceivePO.Name = "sS_DataGridView_ReceivePO";
            this.sS_DataGridView_ReceivePO.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.sS_DataGridView_ReceivePO.Size = new System.Drawing.Size(976, 169);
            this.sS_DataGridView_ReceivePO.TabIndex = 1;
            this.sS_DataGridView_ReceivePO.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.sS_DataGridView_ReceivePO_CellBeginEdit);
            this.sS_DataGridView_ReceivePO.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.sS_DataGridView_ReceivePO_RowEnter);
            this.sS_DataGridView_ReceivePO.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.sS_DataGridView_ReceivePO_RowsAdded);
            this.sS_DataGridView_ReceivePO.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.sS_DataGridView_ReceivePO_CellEndEdit);
            // 
            // Line
            // 
            this.Line.HeaderText = "Line";
            this.Line.Name = "Line";
            // 
            // ModelID
            // 
            this.ModelID.HeaderText = "ModelID";
            this.ModelID.Name = "ModelID";
            // 
            // ModelName
            // 
            this.ModelName.HeaderText = "ModelName";
            this.ModelName.Name = "ModelName";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Receive Qty";
            this.Column1.Name = "Column1";
            // 
            // Price
            // 
            this.Price.HeaderText = "Price";
            this.Price.Name = "Price";
            // 
            // Cost
            // 
            this.Cost.HeaderText = "Cost";
            this.Cost.Name = "Cost";
            // 
            // Remark
            // 
            this.Remark.HeaderText = "Remark";
            this.Remark.Name = "Remark";
            // 
            // Form_001010_WriteOff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 563);
            this.Controls.Add(this.LBL_AssetDetail);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel_PurchaseOrder);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.LBL_Detail);
            this.Controls.Add(this.panel1);
            this.Name = "Form_001010_WriteOff";
            this.Text = "Form_001010_WriteOff";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_001010_WriteOff_FormClosed);
            this.Activated += new System.EventHandler(this.Form_001010_WriteOff_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_001010_WriteOff_FormClosing);
            this.Load += new System.EventHandler(this.Form_001010_WriteOff_Load);
            this.panel_PurchaseOrder.ResumeLayout(false);
            this.panel_PurchaseOrder.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sS_DataGridView_AssetReceive)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sS_DataGridView_ReceivePO)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker_ReceivePODate;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_FacName;
        private SimatSoft.CustomControl.SS_ComboBox sS_ComboBox_Type;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_DeptName;
        private System.Windows.Forms.Panel panel_PurchaseOrder;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_Facility;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_Remark;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_DepartmentNo;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_PO;
        private System.Windows.Forms.Label LBL_CompanyNo;
        private System.Windows.Forms.Label LBL_Remark;
        private System.Windows.Forms.Label LBL_Type;
        private System.Windows.Forms.Label LBL_DepartmentNo;
        private System.Windows.Forms.Label LBL_Date;
        private System.Windows.Forms.Label LBL_PONo;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Record;
        private System.Windows.Forms.Label LBL_Detail;
        private System.Windows.Forms.Label LBL_AssetDetail;
        private System.Windows.Forms.Panel panel1;
        private SimatSoft.CustomControl.SS_DataGridView sS_DataGridView_AssetReceive;
        private System.Windows.Forms.Panel panel2;
        private SimatSoft.CustomControl.SS_DataGridView sS_DataGridView_ReceivePO;
        private System.Windows.Forms.DataGridViewTextBoxColumn Line;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModelID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModelName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustodianID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;

    }
}