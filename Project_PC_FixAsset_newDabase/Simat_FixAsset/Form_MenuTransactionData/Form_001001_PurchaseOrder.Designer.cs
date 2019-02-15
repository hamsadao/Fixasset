namespace SimatSoft.FixAsset
{
    partial class Form_001001_PurchaseOrder
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
            this.sS_DataGridView_PurchaseOrder = new SimatSoft.CustomControl.SS_DataGridView();
            this.Line = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModelID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModelName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel_PurchaseOrder = new System.Windows.Forms.Panel();
            this.dateTimePicker_PO = new System.Windows.Forms.DateTimePicker();
            this.sS_MaskedTextBox_FacName = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.sS_MaskedTextBox_DepartmentName = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.sS_MaskedTextBox_SupplierName = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.sS_ComboBox_Type = new SimatSoft.CustomControl.SS_ComboBox();
            this.sS_MaskedTextBox_FacilityNo = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.sS_MaskedTextBox_DepartmentNo = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.sS_MaskedTextBox_Remark = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.sS_MaskedTextBox_SupplierNo = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.sS_MaskedTextBox_PONo = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.LBL_SupplierNo = new System.Windows.Forms.Label();
            this.LBL_CompanyNo = new System.Windows.Forms.Label();
            this.LBL_Remark = new System.Windows.Forms.Label();
            this.LBL_Type = new System.Windows.Forms.Label();
            this.LBL_DepartmentName = new System.Windows.Forms.Label();
            this.LBL_Date = new System.Windows.Forms.Label();
            this.LBL_PONo = new System.Windows.Forms.Label();
            this.toolStripStatusLabel_Record = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sS_DataGridView_PurchaseOrder)).BeginInit();
            this.panel_PurchaseOrder.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.sS_DataGridView_PurchaseOrder);
            this.panel2.Location = new System.Drawing.Point(1, 194);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(728, 248);
            this.panel2.TabIndex = 5;
            // 
            // sS_DataGridView_PurchaseOrder
            // 
            this.sS_DataGridView_PurchaseOrder.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.sS_DataGridView_PurchaseOrder.BackColorCellFocus = System.Drawing.Color.LightBlue;
            this.sS_DataGridView_PurchaseOrder.BackColorCellLeave = System.Drawing.Color.Honeydew;
            this.sS_DataGridView_PurchaseOrder.BackColorRow = System.Drawing.Color.HotPink;
            this.sS_DataGridView_PurchaseOrder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sS_DataGridView_PurchaseOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sS_DataGridView_PurchaseOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Line,
            this.ModelID,
            this.ModelName,
            this.Quantity,
            this.Price,
            this.Cost,
            this.Remark});
            this.sS_DataGridView_PurchaseOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sS_DataGridView_PurchaseOrder.Location = new System.Drawing.Point(0, 0);
            this.sS_DataGridView_PurchaseOrder.Name = "sS_DataGridView_PurchaseOrder";
            this.sS_DataGridView_PurchaseOrder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.sS_DataGridView_PurchaseOrder.Size = new System.Drawing.Size(724, 244);
            this.sS_DataGridView_PurchaseOrder.TabIndex = 0;
            this.sS_DataGridView_PurchaseOrder.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.sS_DataGridView_PurchaseOrder_CellBeginEdit);
            this.sS_DataGridView_PurchaseOrder.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.sS_DataGridView_PurchaseOrder_RowsAdded);
            this.sS_DataGridView_PurchaseOrder.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.sS_DataGridView_PurchaseOrder_UserDeletedRow);
            this.sS_DataGridView_PurchaseOrder.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.sS_DataGridView_PurchaseOrder_CellEndEdit);
            this.sS_DataGridView_PurchaseOrder.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.sS_DataGridView_PurchaseOrder_RowsRemoved);
            this.sS_DataGridView_PurchaseOrder.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.sS_DataGridView_PurchaseOrder_CellContentClick);
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
            // Quantity
            // 
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
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
            // panel_PurchaseOrder
            // 
            this.panel_PurchaseOrder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_PurchaseOrder.BackColor = System.Drawing.Color.Transparent;
            this.panel_PurchaseOrder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_PurchaseOrder.Controls.Add(this.dateTimePicker_PO);
            this.panel_PurchaseOrder.Controls.Add(this.sS_MaskedTextBox_FacName);
            this.panel_PurchaseOrder.Controls.Add(this.sS_MaskedTextBox_DepartmentName);
            this.panel_PurchaseOrder.Controls.Add(this.sS_MaskedTextBox_SupplierName);
            this.panel_PurchaseOrder.Controls.Add(this.sS_ComboBox_Type);
            this.panel_PurchaseOrder.Controls.Add(this.sS_MaskedTextBox_FacilityNo);
            this.panel_PurchaseOrder.Controls.Add(this.sS_MaskedTextBox_DepartmentNo);
            this.panel_PurchaseOrder.Controls.Add(this.sS_MaskedTextBox_Remark);
            this.panel_PurchaseOrder.Controls.Add(this.sS_MaskedTextBox_SupplierNo);
            this.panel_PurchaseOrder.Controls.Add(this.sS_MaskedTextBox_PONo);
            this.panel_PurchaseOrder.Controls.Add(this.LBL_SupplierNo);
            this.panel_PurchaseOrder.Controls.Add(this.LBL_CompanyNo);
            this.panel_PurchaseOrder.Controls.Add(this.LBL_Remark);
            this.panel_PurchaseOrder.Controls.Add(this.LBL_Type);
            this.panel_PurchaseOrder.Controls.Add(this.LBL_DepartmentName);
            this.panel_PurchaseOrder.Controls.Add(this.LBL_Date);
            this.panel_PurchaseOrder.Controls.Add(this.LBL_PONo);
            this.panel_PurchaseOrder.Location = new System.Drawing.Point(0, 0);
            this.panel_PurchaseOrder.Name = "panel_PurchaseOrder";
            this.panel_PurchaseOrder.Size = new System.Drawing.Size(729, 188);
            this.panel_PurchaseOrder.TabIndex = 4;
            // 
            // dateTimePicker_PO
            // 
            this.dateTimePicker_PO.Location = new System.Drawing.Point(189, 62);
            this.dateTimePicker_PO.Name = "dateTimePicker_PO";
            this.dateTimePicker_PO.Size = new System.Drawing.Size(128, 20);
            this.dateTimePicker_PO.TabIndex = 13;
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
            this.sS_MaskedTextBox_FacName.Location = new System.Drawing.Point(320, 158);
            this.sS_MaskedTextBox_FacName.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_FacName.Name = "sS_MaskedTextBox_FacName";
            this.sS_MaskedTextBox_FacName.Size = new System.Drawing.Size(188, 23);
            this.sS_MaskedTextBox_FacName.TabIndex = 12;
            this.sS_MaskedTextBox_FacName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sS_MaskedTextBox_FacilityNo_KeyDown);
            // 
            // sS_MaskedTextBox_DepartmentName
            // 
            this.sS_MaskedTextBox_DepartmentName.BackColor = System.Drawing.Color.LightCyan;
            this.sS_MaskedTextBox_DepartmentName.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_DepartmentName.BackColorOnLeave = System.Drawing.Color.LightCyan;
            this.sS_MaskedTextBox_DepartmentName.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_DepartmentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_DepartmentName.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sS_MaskedTextBox_DepartmentName.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_DepartmentName.IconError = null;
            this.sS_MaskedTextBox_DepartmentName.IconTrue = null;
            this.sS_MaskedTextBox_DepartmentName.Location = new System.Drawing.Point(320, 85);
            this.sS_MaskedTextBox_DepartmentName.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_DepartmentName.Name = "sS_MaskedTextBox_DepartmentName";
            this.sS_MaskedTextBox_DepartmentName.Size = new System.Drawing.Size(188, 23);
            this.sS_MaskedTextBox_DepartmentName.TabIndex = 9;
            this.sS_MaskedTextBox_DepartmentName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sS_MaskedTextBox_DepartmentNo_KeyDown);
            // 
            // sS_MaskedTextBox_SupplierName
            // 
            this.sS_MaskedTextBox_SupplierName.BackColor = System.Drawing.Color.LightCyan;
            this.sS_MaskedTextBox_SupplierName.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_SupplierName.BackColorOnLeave = System.Drawing.Color.LightCyan;
            this.sS_MaskedTextBox_SupplierName.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_SupplierName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_SupplierName.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_SupplierName.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_SupplierName.IconError = null;
            this.sS_MaskedTextBox_SupplierName.IconTrue = null;
            this.sS_MaskedTextBox_SupplierName.Location = new System.Drawing.Point(320, 35);
            this.sS_MaskedTextBox_SupplierName.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_SupplierName.Name = "sS_MaskedTextBox_SupplierName";
            this.sS_MaskedTextBox_SupplierName.Size = new System.Drawing.Size(188, 23);
            this.sS_MaskedTextBox_SupplierName.TabIndex = 7;
            this.sS_MaskedTextBox_SupplierName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sS_MaskedTextBox_SupplierNo_KeyDown);
            // 
            // sS_ComboBox_Type
            // 
            this.sS_ComboBox_Type.BackColor = System.Drawing.Color.Honeydew;
            this.sS_ComboBox_Type.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_ComboBox_Type.BackColorOnLeave = System.Drawing.Color.Honeydew;
            this.sS_ComboBox_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sS_ComboBox_Type.FormattingEnabled = true;
            this.sS_ComboBox_Type.Items.AddRange(new object[] {
            "PO"});
            this.sS_ComboBox_Type.Location = new System.Drawing.Point(189, 110);
            this.sS_ComboBox_Type.Name = "sS_ComboBox_Type";
            this.sS_ComboBox_Type.Size = new System.Drawing.Size(128, 21);
            this.sS_ComboBox_Type.TabIndex = 4;
            // 
            // sS_MaskedTextBox_FacilityNo
            // 
            this.sS_MaskedTextBox_FacilityNo.BackColor = System.Drawing.Color.Lavender;
            this.sS_MaskedTextBox_FacilityNo.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_FacilityNo.BackColorOnLeave = System.Drawing.Color.Lavender;
            this.sS_MaskedTextBox_FacilityNo.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_FacilityNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_FacilityNo.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_FacilityNo.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_FacilityNo.IconError = null;
            this.sS_MaskedTextBox_FacilityNo.IconTrue = null;
            this.sS_MaskedTextBox_FacilityNo.Location = new System.Drawing.Point(189, 158);
            this.sS_MaskedTextBox_FacilityNo.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_FacilityNo.Name = "sS_MaskedTextBox_FacilityNo";
            this.sS_MaskedTextBox_FacilityNo.Size = new System.Drawing.Size(128, 23);
            this.sS_MaskedTextBox_FacilityNo.TabIndex = 6;
            this.sS_MaskedTextBox_FacilityNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sS_MaskedTextBox_FacilityNo_KeyDown);
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
            this.sS_MaskedTextBox_DepartmentNo.Location = new System.Drawing.Point(189, 85);
            this.sS_MaskedTextBox_DepartmentNo.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_DepartmentNo.Name = "sS_MaskedTextBox_DepartmentNo";
            this.sS_MaskedTextBox_DepartmentNo.Size = new System.Drawing.Size(128, 23);
            this.sS_MaskedTextBox_DepartmentNo.TabIndex = 10;
            this.sS_MaskedTextBox_DepartmentNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sS_MaskedTextBox_DepartmentNo_KeyDown);
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
            this.sS_MaskedTextBox_Remark.Location = new System.Drawing.Point(189, 133);
            this.sS_MaskedTextBox_Remark.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_Remark.Name = "sS_MaskedTextBox_Remark";
            this.sS_MaskedTextBox_Remark.Size = new System.Drawing.Size(319, 23);
            this.sS_MaskedTextBox_Remark.TabIndex = 5;
            // 
            // sS_MaskedTextBox_SupplierNo
            // 
            this.sS_MaskedTextBox_SupplierNo.BackColor = System.Drawing.Color.Lavender;
            this.sS_MaskedTextBox_SupplierNo.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_SupplierNo.BackColorOnLeave = System.Drawing.Color.Lavender;
            this.sS_MaskedTextBox_SupplierNo.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_SupplierNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_SupplierNo.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_SupplierNo.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_SupplierNo.IconError = null;
            this.sS_MaskedTextBox_SupplierNo.IconTrue = null;
            this.sS_MaskedTextBox_SupplierNo.Location = new System.Drawing.Point(189, 35);
            this.sS_MaskedTextBox_SupplierNo.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_SupplierNo.Name = "sS_MaskedTextBox_SupplierNo";
            this.sS_MaskedTextBox_SupplierNo.Size = new System.Drawing.Size(128, 23);
            this.sS_MaskedTextBox_SupplierNo.TabIndex = 1;
            this.sS_MaskedTextBox_SupplierNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sS_MaskedTextBox_SupplierNo_KeyDown);
            // 
            // sS_MaskedTextBox_PONo
            // 
            this.sS_MaskedTextBox_PONo.BackColor = System.Drawing.Color.Honeydew;
            this.sS_MaskedTextBox_PONo.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_PONo.BackColorOnLeave = System.Drawing.Color.Honeydew;
            this.sS_MaskedTextBox_PONo.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_PONo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_PONo.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_PONo.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_PONo.IconError = null;
            this.sS_MaskedTextBox_PONo.IconTrue = null;
            this.sS_MaskedTextBox_PONo.Location = new System.Drawing.Point(189, 10);
            this.sS_MaskedTextBox_PONo.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_PONo.Name = "sS_MaskedTextBox_PONo";
            this.sS_MaskedTextBox_PONo.Size = new System.Drawing.Size(128, 23);
            this.sS_MaskedTextBox_PONo.TabIndex = 0;
            this.sS_MaskedTextBox_PONo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sS_MaskedTextBox_PONo_KeyDown);
            // 
            // LBL_SupplierNo
            // 
            this.LBL_SupplierNo.AutoSize = true;
            this.LBL_SupplierNo.Location = new System.Drawing.Point(55, 42);
            this.LBL_SupplierNo.Name = "LBL_SupplierNo";
            this.LBL_SupplierNo.Size = new System.Drawing.Size(65, 13);
            this.LBL_SupplierNo.TabIndex = 2;
            this.LBL_SupplierNo.Text = "Supplier No:";
            // 
            // LBL_CompanyNo
            // 
            this.LBL_CompanyNo.AutoSize = true;
            this.LBL_CompanyNo.ForeColor = System.Drawing.Color.Black;
            this.LBL_CompanyNo.Location = new System.Drawing.Point(55, 163);
            this.LBL_CompanyNo.Name = "LBL_CompanyNo";
            this.LBL_CompanyNo.Size = new System.Drawing.Size(54, 13);
            this.LBL_CompanyNo.TabIndex = 2;
            this.LBL_CompanyNo.Text = "Company:";
            // 
            // LBL_Remark
            // 
            this.LBL_Remark.AutoSize = true;
            this.LBL_Remark.Location = new System.Drawing.Point(55, 133);
            this.LBL_Remark.Name = "LBL_Remark";
            this.LBL_Remark.Size = new System.Drawing.Size(47, 13);
            this.LBL_Remark.TabIndex = 2;
            this.LBL_Remark.Text = "Remark:";
            // 
            // LBL_Type
            // 
            this.LBL_Type.AutoSize = true;
            this.LBL_Type.Location = new System.Drawing.Point(54, 109);
            this.LBL_Type.Name = "LBL_Type";
            this.LBL_Type.Size = new System.Drawing.Size(34, 13);
            this.LBL_Type.TabIndex = 2;
            this.LBL_Type.Text = "Type:";
            // 
            // LBL_DepartmentName
            // 
            this.LBL_DepartmentName.AutoSize = true;
            this.LBL_DepartmentName.Location = new System.Drawing.Point(55, 86);
            this.LBL_DepartmentName.Name = "LBL_DepartmentName";
            this.LBL_DepartmentName.Size = new System.Drawing.Size(65, 13);
            this.LBL_DepartmentName.TabIndex = 2;
            this.LBL_DepartmentName.Text = "Department:";
            // 
            // LBL_Date
            // 
            this.LBL_Date.AutoSize = true;
            this.LBL_Date.Location = new System.Drawing.Point(55, 63);
            this.LBL_Date.Name = "LBL_Date";
            this.LBL_Date.Size = new System.Drawing.Size(33, 13);
            this.LBL_Date.TabIndex = 2;
            this.LBL_Date.Text = "Date:";
            // 
            // LBL_PONo
            // 
            this.LBL_PONo.AutoSize = true;
            this.LBL_PONo.Location = new System.Drawing.Point(55, 20);
            this.LBL_PONo.Name = "LBL_PONo";
            this.LBL_PONo.Size = new System.Drawing.Size(45, 13);
            this.LBL_PONo.TabIndex = 2;
            this.LBL_PONo.Text = "PO No :";
            // 
            // toolStripStatusLabel_Record
            // 
            this.toolStripStatusLabel_Record.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabel_Record.Name = "toolStripStatusLabel_Record";
            this.toolStripStatusLabel_Record.Size = new System.Drawing.Size(79, 17);
            this.toolStripStatusLabel_Record.Text = "[1/All] records";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Highlight;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_Record});
            this.statusStrip1.Location = new System.Drawing.Point(0, 445);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(729, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Form_001001_PurchaseOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(210)))), ((int)(((byte)(238)))));
            this.ClientSize = new System.Drawing.Size(729, 467);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel_PurchaseOrder);
            this.Name = "Form_001001_PurchaseOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ID:001001(PurchaseOrder)";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_001001_PurchaseOrder_FormClosed);
            this.Activated += new System.EventHandler(this.Form_001001_PurchaseOrder_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_001001_PurchaseOrder_FormClosing);
            this.Load += new System.EventHandler(this.Form_001001_PurchaseOrder_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sS_DataGridView_PurchaseOrder)).EndInit();
            this.panel_PurchaseOrder.ResumeLayout(false);
            this.panel_PurchaseOrder.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel_PurchaseOrder;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_PONo;
        private System.Windows.Forms.Label LBL_PONo;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_SupplierNo;
        private System.Windows.Forms.Label LBL_SupplierNo;
        private System.Windows.Forms.Label LBL_DepartmentName;
        private System.Windows.Forms.Label LBL_Date;
        private System.Windows.Forms.Label LBL_Type;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_Remark;
        private System.Windows.Forms.Label LBL_Remark;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_DepartmentNo;
        private SimatSoft.CustomControl.SS_ComboBox sS_ComboBox_Type;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_FacilityNo;
        private System.Windows.Forms.Label LBL_CompanyNo;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_SupplierName;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_DepartmentName;
        private SimatSoft.CustomControl.SS_DataGridView sS_DataGridView_PurchaseOrder;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Record;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Line;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModelID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModelName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_FacName;
        private System.Windows.Forms.DateTimePicker dateTimePicker_PO;
    }
}