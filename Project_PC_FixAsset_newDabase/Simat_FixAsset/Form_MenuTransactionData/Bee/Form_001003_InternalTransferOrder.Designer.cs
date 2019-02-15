namespace SimatSoft.FixAsset
{
    partial class Form_001003_InternalTransferOrder
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
            this.sS_DataGridView_Table = new SimatSoft.CustomControl.SS_DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sS_DataGridView_InternalTransferOrder = new SimatSoft.CustomControl.SS_DataGridView();
            this.panel_PurchaseOrder = new System.Windows.Forms.Panel();
            this.sS_ButtonGlass1 = new SimatSoft.CustomControl.SS_ButtonGlass();
            this.sS_MaskedTextBox_FromFacName = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.sS_MaskedTextBox_FromFacCode = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.LBL_FormCompany = new System.Windows.Forms.Label();
            this.dateTimePicker_Date = new System.Windows.Forms.DateTimePicker();
            this.sS_MaskedTextBox_ToDeptName = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.sS_MaskedTextBox_FromDeptName = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.sS_MaskedTextBox_ToDeptID = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.sS_ComboBox_TransferType = new SimatSoft.CustomControl.SS_ComboBox();
            this.sS_MaskedTextBox_FromDeptID = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.sS_MaskedTextBox_Remark = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.sS_MaskedTextBox_TransferID = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.LBL_Remark = new System.Windows.Forms.Label();
            this.LBL_Type = new System.Windows.Forms.Label();
            this.LBL_ToDepartment = new System.Windows.Forms.Label();
            this.LBL_FormDepartment = new System.Windows.Forms.Label();
            this.LBL_Date = new System.Windows.Forms.Label();
            this.LBL_TransferNo = new System.Windows.Forms.Label();
            this.toolStripStatusLabel_Record = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AssetID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AssetName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sS_DataGridView_Table)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sS_DataGridView_InternalTransferOrder)).BeginInit();
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
            this.panel2.Controls.Add(this.sS_DataGridView_Table);
            this.panel2.Controls.Add(this.sS_DataGridView_InternalTransferOrder);
            this.panel2.Location = new System.Drawing.Point(1, 204);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(874, 266);
            this.panel2.TabIndex = 5;
            // 
            // sS_DataGridView_Table
            // 
            this.sS_DataGridView_Table.AllowUserToAddRows = false;
            this.sS_DataGridView_Table.AllowUserToDeleteRows = false;
            this.sS_DataGridView_Table.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.sS_DataGridView_Table.BackColorCellFocus = System.Drawing.Color.LightBlue;
            this.sS_DataGridView_Table.BackColorCellLeave = System.Drawing.Color.Honeydew;
            this.sS_DataGridView_Table.BackColorRow = System.Drawing.Color.HotPink;
            this.sS_DataGridView_Table.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sS_DataGridView_Table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sS_DataGridView_Table.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column7,
            this.Column6,
            this.Column8});
            this.sS_DataGridView_Table.Location = new System.Drawing.Point(0, 118);
            this.sS_DataGridView_Table.Name = "sS_DataGridView_Table";
            this.sS_DataGridView_Table.Size = new System.Drawing.Size(872, 146);
            this.sS_DataGridView_Table.TabIndex = 51;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Description";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Account-Number";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Cost-Book Value";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Accumulted Depre\'n";
            this.Column5.Name = "Column5";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Net Book Value";
            this.Column7.Name = "Column7";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Transfer Value";
            this.Column6.Name = "Column6";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Loss/(Profit) on Transfer/Liq.";
            this.Column8.Name = "Column8";
            // 
            // sS_DataGridView_InternalTransferOrder
            // 
            this.sS_DataGridView_InternalTransferOrder.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.sS_DataGridView_InternalTransferOrder.BackColorCellFocus = System.Drawing.Color.LightBlue;
            this.sS_DataGridView_InternalTransferOrder.BackColorCellLeave = System.Drawing.Color.Honeydew;
            this.sS_DataGridView_InternalTransferOrder.BackColorRow = System.Drawing.Color.HotPink;
            this.sS_DataGridView_InternalTransferOrder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sS_DataGridView_InternalTransferOrder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.AssetID,
            this.AssetName,
            this.Column1,
            this.Remark});
            this.sS_DataGridView_InternalTransferOrder.Location = new System.Drawing.Point(-2, -2);
            this.sS_DataGridView_InternalTransferOrder.MultiSelect = false;
            this.sS_DataGridView_InternalTransferOrder.Name = "sS_DataGridView_InternalTransferOrder";
            this.sS_DataGridView_InternalTransferOrder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.sS_DataGridView_InternalTransferOrder.Size = new System.Drawing.Size(874, 114);
            this.sS_DataGridView_InternalTransferOrder.TabIndex = 0;
            this.sS_DataGridView_InternalTransferOrder.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.sS_DataGridView_InternalTransferOrder_CellBeginEdit);
            this.sS_DataGridView_InternalTransferOrder.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.sS_DataGridView_InternalTransferOrder_RowsAdded);
            this.sS_DataGridView_InternalTransferOrder.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.sS_DataGridView_InternalTransferOrder_UserDeletedRow);
            this.sS_DataGridView_InternalTransferOrder.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.sS_DataGridView_InternalTransferOrder_CellEndEdit);
            this.sS_DataGridView_InternalTransferOrder.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.sS_DataGridView_InternalTransferOrder_RowsRemoved);
            // 
            // panel_PurchaseOrder
            // 
            this.panel_PurchaseOrder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_PurchaseOrder.BackColor = System.Drawing.Color.Transparent;
            this.panel_PurchaseOrder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_PurchaseOrder.Controls.Add(this.sS_ButtonGlass1);
            this.panel_PurchaseOrder.Controls.Add(this.sS_MaskedTextBox_FromFacName);
            this.panel_PurchaseOrder.Controls.Add(this.sS_MaskedTextBox_FromFacCode);
            this.panel_PurchaseOrder.Controls.Add(this.LBL_FormCompany);
            this.panel_PurchaseOrder.Controls.Add(this.dateTimePicker_Date);
            this.panel_PurchaseOrder.Controls.Add(this.sS_MaskedTextBox_ToDeptName);
            this.panel_PurchaseOrder.Controls.Add(this.sS_MaskedTextBox_FromDeptName);
            this.panel_PurchaseOrder.Controls.Add(this.sS_MaskedTextBox_ToDeptID);
            this.panel_PurchaseOrder.Controls.Add(this.sS_ComboBox_TransferType);
            this.panel_PurchaseOrder.Controls.Add(this.sS_MaskedTextBox_FromDeptID);
            this.panel_PurchaseOrder.Controls.Add(this.sS_MaskedTextBox_Remark);
            this.panel_PurchaseOrder.Controls.Add(this.sS_MaskedTextBox_TransferID);
            this.panel_PurchaseOrder.Controls.Add(this.LBL_Remark);
            this.panel_PurchaseOrder.Controls.Add(this.LBL_Type);
            this.panel_PurchaseOrder.Controls.Add(this.LBL_ToDepartment);
            this.panel_PurchaseOrder.Controls.Add(this.LBL_FormDepartment);
            this.panel_PurchaseOrder.Controls.Add(this.LBL_Date);
            this.panel_PurchaseOrder.Controls.Add(this.LBL_TransferNo);
            this.panel_PurchaseOrder.Location = new System.Drawing.Point(0, 0);
            this.panel_PurchaseOrder.Name = "panel_PurchaseOrder";
            this.panel_PurchaseOrder.Size = new System.Drawing.Size(875, 198);
            this.panel_PurchaseOrder.TabIndex = 4;
            // 
            // sS_ButtonGlass1
            // 
            this.sS_ButtonGlass1.Location = new System.Drawing.Point(772, 10);
            this.sS_ButtonGlass1.Name = "sS_ButtonGlass1";
            this.sS_ButtonGlass1.Size = new System.Drawing.Size(94, 23);
            this.sS_ButtonGlass1.TabIndex = 42;
            this.sS_ButtonGlass1.Text = "Print";
            // 
            // sS_MaskedTextBox_FromFacName
            // 
            this.sS_MaskedTextBox_FromFacName.BackColor = System.Drawing.Color.LightCyan;
            this.sS_MaskedTextBox_FromFacName.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_FromFacName.BackColorOnLeave = System.Drawing.Color.LightCyan;
            this.sS_MaskedTextBox_FromFacName.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_FromFacName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_FromFacName.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_FromFacName.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_FromFacName.IconError = null;
            this.sS_MaskedTextBox_FromFacName.IconTrue = null;
            this.sS_MaskedTextBox_FromFacName.Location = new System.Drawing.Point(320, 166);
            this.sS_MaskedTextBox_FromFacName.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_FromFacName.Name = "sS_MaskedTextBox_FromFacName";
            this.sS_MaskedTextBox_FromFacName.Size = new System.Drawing.Size(187, 23);
            this.sS_MaskedTextBox_FromFacName.TabIndex = 18;
            // 
            // sS_MaskedTextBox_FromFacCode
            // 
            this.sS_MaskedTextBox_FromFacCode.BackColor = System.Drawing.Color.Lavender;
            this.sS_MaskedTextBox_FromFacCode.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_FromFacCode.BackColorOnLeave = System.Drawing.Color.Lavender;
            this.sS_MaskedTextBox_FromFacCode.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_FromFacCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_FromFacCode.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_FromFacCode.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_FromFacCode.IconError = null;
            this.sS_MaskedTextBox_FromFacCode.IconTrue = null;
            this.sS_MaskedTextBox_FromFacCode.Location = new System.Drawing.Point(185, 166);
            this.sS_MaskedTextBox_FromFacCode.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_FromFacCode.Name = "sS_MaskedTextBox_FromFacCode";
            this.sS_MaskedTextBox_FromFacCode.Size = new System.Drawing.Size(132, 23);
            this.sS_MaskedTextBox_FromFacCode.TabIndex = 17;
            this.sS_MaskedTextBox_FromFacCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sS_MaskedTextBox_FromFacCode_KeyDown);
            // 
            // LBL_FormCompany
            // 
            this.LBL_FormCompany.AutoSize = true;
            this.LBL_FormCompany.Location = new System.Drawing.Point(63, 166);
            this.LBL_FormCompany.Name = "LBL_FormCompany";
            this.LBL_FormCompany.Size = new System.Drawing.Size(54, 13);
            this.LBL_FormCompany.TabIndex = 16;
            this.LBL_FormCompany.Text = "Company:";
            // 
            // dateTimePicker_Date
            // 
            this.dateTimePicker_Date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_Date.Location = new System.Drawing.Point(185, 37);
            this.dateTimePicker_Date.Name = "dateTimePicker_Date";
            this.dateTimePicker_Date.Size = new System.Drawing.Size(132, 20);
            this.dateTimePicker_Date.TabIndex = 15;
            // 
            // sS_MaskedTextBox_ToDeptName
            // 
            this.sS_MaskedTextBox_ToDeptName.BackColor = System.Drawing.Color.LightCyan;
            this.sS_MaskedTextBox_ToDeptName.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_ToDeptName.BackColorOnLeave = System.Drawing.Color.LightCyan;
            this.sS_MaskedTextBox_ToDeptName.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_ToDeptName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_ToDeptName.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_ToDeptName.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_ToDeptName.IconError = null;
            this.sS_MaskedTextBox_ToDeptName.IconTrue = null;
            this.sS_MaskedTextBox_ToDeptName.Location = new System.Drawing.Point(321, 112);
            this.sS_MaskedTextBox_ToDeptName.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_ToDeptName.Name = "sS_MaskedTextBox_ToDeptName";
            this.sS_MaskedTextBox_ToDeptName.Size = new System.Drawing.Size(186, 23);
            this.sS_MaskedTextBox_ToDeptName.TabIndex = 14;
            this.sS_MaskedTextBox_ToDeptName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sS_MaskedTextBox_ToDeptID_KeyDown);
            // 
            // sS_MaskedTextBox_FromDeptName
            // 
            this.sS_MaskedTextBox_FromDeptName.BackColor = System.Drawing.Color.LightCyan;
            this.sS_MaskedTextBox_FromDeptName.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_FromDeptName.BackColorOnLeave = System.Drawing.Color.LightCyan;
            this.sS_MaskedTextBox_FromDeptName.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_FromDeptName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_FromDeptName.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_FromDeptName.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_FromDeptName.IconError = null;
            this.sS_MaskedTextBox_FromDeptName.IconTrue = null;
            this.sS_MaskedTextBox_FromDeptName.Location = new System.Drawing.Point(321, 86);
            this.sS_MaskedTextBox_FromDeptName.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_FromDeptName.Name = "sS_MaskedTextBox_FromDeptName";
            this.sS_MaskedTextBox_FromDeptName.Size = new System.Drawing.Size(186, 23);
            this.sS_MaskedTextBox_FromDeptName.TabIndex = 13;
            this.sS_MaskedTextBox_FromDeptName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sS_MaskedTextBox_FromDeptID_KeyDown);
            // 
            // sS_MaskedTextBox_ToDeptID
            // 
            this.sS_MaskedTextBox_ToDeptID.BackColor = System.Drawing.Color.Lavender;
            this.sS_MaskedTextBox_ToDeptID.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_ToDeptID.BackColorOnLeave = System.Drawing.Color.Lavender;
            this.sS_MaskedTextBox_ToDeptID.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_ToDeptID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_ToDeptID.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_ToDeptID.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_ToDeptID.IconError = null;
            this.sS_MaskedTextBox_ToDeptID.IconTrue = null;
            this.sS_MaskedTextBox_ToDeptID.Location = new System.Drawing.Point(185, 112);
            this.sS_MaskedTextBox_ToDeptID.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_ToDeptID.Name = "sS_MaskedTextBox_ToDeptID";
            this.sS_MaskedTextBox_ToDeptID.Size = new System.Drawing.Size(132, 23);
            this.sS_MaskedTextBox_ToDeptID.TabIndex = 12;
            this.sS_MaskedTextBox_ToDeptID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sS_MaskedTextBox_ToDeptID_KeyDown);
            // 
            // sS_ComboBox_TransferType
            // 
            this.sS_ComboBox_TransferType.BackColor = System.Drawing.Color.Honeydew;
            this.sS_ComboBox_TransferType.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_ComboBox_TransferType.BackColorOnLeave = System.Drawing.Color.Honeydew;
            this.sS_ComboBox_TransferType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sS_ComboBox_TransferType.FormattingEnabled = true;
            this.sS_ComboBox_TransferType.Items.AddRange(new object[] {
            "TRN"});
            this.sS_ComboBox_TransferType.Location = new System.Drawing.Point(185, 61);
            this.sS_ComboBox_TransferType.Name = "sS_ComboBox_TransferType";
            this.sS_ComboBox_TransferType.Size = new System.Drawing.Size(132, 21);
            this.sS_ComboBox_TransferType.TabIndex = 4;
            // 
            // sS_MaskedTextBox_FromDeptID
            // 
            this.sS_MaskedTextBox_FromDeptID.BackColor = System.Drawing.Color.Lavender;
            this.sS_MaskedTextBox_FromDeptID.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_FromDeptID.BackColorOnLeave = System.Drawing.Color.Lavender;
            this.sS_MaskedTextBox_FromDeptID.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_FromDeptID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_FromDeptID.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_FromDeptID.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_FromDeptID.IconError = null;
            this.sS_MaskedTextBox_FromDeptID.IconTrue = null;
            this.sS_MaskedTextBox_FromDeptID.Location = new System.Drawing.Point(185, 86);
            this.sS_MaskedTextBox_FromDeptID.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_FromDeptID.Name = "sS_MaskedTextBox_FromDeptID";
            this.sS_MaskedTextBox_FromDeptID.Size = new System.Drawing.Size(132, 23);
            this.sS_MaskedTextBox_FromDeptID.TabIndex = 10;
            this.sS_MaskedTextBox_FromDeptID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sS_MaskedTextBox_FromDeptID_KeyDown);
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
            this.sS_MaskedTextBox_Remark.Location = new System.Drawing.Point(185, 139);
            this.sS_MaskedTextBox_Remark.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_Remark.Multiline = true;
            this.sS_MaskedTextBox_Remark.Name = "sS_MaskedTextBox_Remark";
            this.sS_MaskedTextBox_Remark.Size = new System.Drawing.Size(322, 23);
            this.sS_MaskedTextBox_Remark.TabIndex = 5;
            // 
            // sS_MaskedTextBox_TransferID
            // 
            this.sS_MaskedTextBox_TransferID.BackColor = System.Drawing.Color.Honeydew;
            this.sS_MaskedTextBox_TransferID.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_TransferID.BackColorOnLeave = System.Drawing.Color.Honeydew;
            this.sS_MaskedTextBox_TransferID.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_TransferID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_TransferID.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_TransferID.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_TransferID.IconError = null;
            this.sS_MaskedTextBox_TransferID.IconTrue = null;
            this.sS_MaskedTextBox_TransferID.Location = new System.Drawing.Point(185, 10);
            this.sS_MaskedTextBox_TransferID.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_TransferID.Name = "sS_MaskedTextBox_TransferID";
            this.sS_MaskedTextBox_TransferID.Size = new System.Drawing.Size(132, 23);
            this.sS_MaskedTextBox_TransferID.TabIndex = 0;
            this.sS_MaskedTextBox_TransferID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sS_MaskedTextBox_TransferID_KeyDown);
            // 
            // LBL_Remark
            // 
            this.LBL_Remark.AutoSize = true;
            this.LBL_Remark.Location = new System.Drawing.Point(63, 139);
            this.LBL_Remark.Name = "LBL_Remark";
            this.LBL_Remark.Size = new System.Drawing.Size(47, 13);
            this.LBL_Remark.TabIndex = 2;
            this.LBL_Remark.Text = "Remark:";
            // 
            // LBL_Type
            // 
            this.LBL_Type.AutoSize = true;
            this.LBL_Type.Location = new System.Drawing.Point(63, 61);
            this.LBL_Type.Name = "LBL_Type";
            this.LBL_Type.Size = new System.Drawing.Size(34, 13);
            this.LBL_Type.TabIndex = 2;
            this.LBL_Type.Text = "Type:";
            // 
            // LBL_ToDepartment
            // 
            this.LBL_ToDepartment.AutoSize = true;
            this.LBL_ToDepartment.Location = new System.Drawing.Point(63, 112);
            this.LBL_ToDepartment.Name = "LBL_ToDepartment";
            this.LBL_ToDepartment.Size = new System.Drawing.Size(81, 13);
            this.LBL_ToDepartment.TabIndex = 2;
            this.LBL_ToDepartment.Text = "To Department:";
            // 
            // LBL_FormDepartment
            // 
            this.LBL_FormDepartment.AutoSize = true;
            this.LBL_FormDepartment.Location = new System.Drawing.Point(63, 86);
            this.LBL_FormDepartment.Name = "LBL_FormDepartment";
            this.LBL_FormDepartment.Size = new System.Drawing.Size(91, 13);
            this.LBL_FormDepartment.TabIndex = 2;
            this.LBL_FormDepartment.Text = "From Department:";
            // 
            // LBL_Date
            // 
            this.LBL_Date.AutoSize = true;
            this.LBL_Date.Location = new System.Drawing.Point(64, 35);
            this.LBL_Date.Name = "LBL_Date";
            this.LBL_Date.Size = new System.Drawing.Size(33, 13);
            this.LBL_Date.TabIndex = 2;
            this.LBL_Date.Text = "Date:";
            // 
            // LBL_TransferNo
            // 
            this.LBL_TransferNo.AutoSize = true;
            this.LBL_TransferNo.Location = new System.Drawing.Point(63, 10);
            this.LBL_TransferNo.Name = "LBL_TransferNo";
            this.LBL_TransferNo.Size = new System.Drawing.Size(69, 13);
            this.LBL_TransferNo.TabIndex = 2;
            this.LBL_TransferNo.Text = "Transfer No :";
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 473);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(875, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // No
            // 
            this.No.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.No.HeaderText = "No";
            this.No.Name = "No";
            this.No.ReadOnly = true;
            this.No.Width = 46;
            // 
            // AssetID
            // 
            this.AssetID.FillWeight = 60.9137F;
            this.AssetID.HeaderText = "Asset Number";
            this.AssetID.Name = "AssetID";
            // 
            // AssetName
            // 
            this.AssetName.FillWeight = 133.5552F;
            this.AssetName.HeaderText = "Description";
            this.AssetName.Name = "AssetName";
            // 
            // Column1
            // 
            this.Column1.FillWeight = 71.97586F;
            this.Column1.HeaderText = "Price";
            this.Column1.Name = "Column1";
            // 
            // Remark
            // 
            this.Remark.FillWeight = 133.5552F;
            this.Remark.HeaderText = "Remark";
            this.Remark.Name = "Remark";
            // 
            // Form_001003_InternalTransferOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(210)))), ((int)(((byte)(238)))));
            this.ClientSize = new System.Drawing.Size(875, 495);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel_PurchaseOrder);
            this.Name = "Form_001003_InternalTransferOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ID:001003(Internal Transfer Order)";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_001003_InternalTransferOrder_FormClosed);
            this.Activated += new System.EventHandler(this.Form_001003_InternalTransferOrder_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_001003_InternalTransferOrder_FormClosing);
            this.Load += new System.EventHandler(this.Form_001003_InternalTransferOrder_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sS_DataGridView_Table)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sS_DataGridView_InternalTransferOrder)).EndInit();
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
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_TransferID;
        private System.Windows.Forms.Label LBL_TransferNo;
        private System.Windows.Forms.Label LBL_FormDepartment;
        private System.Windows.Forms.Label LBL_Date;
        private System.Windows.Forms.Label LBL_Type;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_Remark;
        private System.Windows.Forms.Label LBL_Remark;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_FromDeptID;
        private SimatSoft.CustomControl.SS_ComboBox sS_ComboBox_TransferType;
        private SimatSoft.CustomControl.SS_DataGridView sS_DataGridView_InternalTransferOrder;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Record;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_ToDeptID;
        private System.Windows.Forms.Label LBL_ToDepartment;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_ToDeptName;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_FromDeptName;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Date;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_FromFacName;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_FromFacCode;
        private System.Windows.Forms.Label LBL_FormCompany;
        private SimatSoft.CustomControl.SS_ButtonGlass sS_ButtonGlass1;
        private SimatSoft.CustomControl.SS_DataGridView sS_DataGridView_Table;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn AssetID;
        private System.Windows.Forms.DataGridViewTextBoxColumn AssetName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
    }
}