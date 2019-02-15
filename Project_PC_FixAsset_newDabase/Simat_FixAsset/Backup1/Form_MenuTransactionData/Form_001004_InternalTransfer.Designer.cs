namespace SimatSoft.FixAsset
{
    partial class Form_001004_InternalTransfer
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
            this.sS_MaskedTextBox_FromFacName = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.sS_MaskedTextBox_FromFacCode = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.LBL_FormCompany = new System.Windows.Forms.Label();
            this.dateTimePicker_Date = new System.Windows.Forms.DateTimePicker();
            this.sS_MaskedTextBox_ToDeptName = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.sS_MaskedTextBox_FromDeptName = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.sS_MaskedTextBox_ToDept = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.sS_ComboBox_Type = new SimatSoft.CustomControl.SS_ComboBox();
            this.sS_MaskedTextBox_FromDept = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.sS_MaskedTextBox_Remark = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.sS_MaskedTextBox_TransferNo = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.LBL_Remark = new System.Windows.Forms.Label();
            this.LBL_Type = new System.Windows.Forms.Label();
            this.LBL_ToDepartment = new System.Windows.Forms.Label();
            this.LBL_FormDepartment = new System.Windows.Forms.Label();
            this.LBL_Date = new System.Windows.Forms.Label();
            this.LBL_TransferNo = new System.Windows.Forms.Label();
            this.LBL_Detail = new System.Windows.Forms.Label();
            this.toolStripStatusLabel_Record = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.panel2 = new System.Windows.Forms.Panel();
            this.sS_DataGridView_AssetTransferDT = new SimatSoft.CustomControl.SS_DataGridView();
            this.NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModelID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModelName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.sS_DataGridView_AssetTransferSerial = new SimatSoft.CustomControl.SS_DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LBL_AssetDetail = new System.Windows.Forms.Label();
            this.panel_PurchaseOrder.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sS_DataGridView_AssetTransferDT)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sS_DataGridView_AssetTransferSerial)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_PurchaseOrder
            // 
            this.panel_PurchaseOrder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_PurchaseOrder.BackColor = System.Drawing.Color.Transparent;
            this.panel_PurchaseOrder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_PurchaseOrder.Controls.Add(this.sS_MaskedTextBox_FromFacName);
            this.panel_PurchaseOrder.Controls.Add(this.sS_MaskedTextBox_FromFacCode);
            this.panel_PurchaseOrder.Controls.Add(this.LBL_FormCompany);
            this.panel_PurchaseOrder.Controls.Add(this.dateTimePicker_Date);
            this.panel_PurchaseOrder.Controls.Add(this.sS_MaskedTextBox_ToDeptName);
            this.panel_PurchaseOrder.Controls.Add(this.sS_MaskedTextBox_FromDeptName);
            this.panel_PurchaseOrder.Controls.Add(this.sS_MaskedTextBox_ToDept);
            this.panel_PurchaseOrder.Controls.Add(this.sS_ComboBox_Type);
            this.panel_PurchaseOrder.Controls.Add(this.sS_MaskedTextBox_FromDept);
            this.panel_PurchaseOrder.Controls.Add(this.sS_MaskedTextBox_Remark);
            this.panel_PurchaseOrder.Controls.Add(this.sS_MaskedTextBox_TransferNo);
            this.panel_PurchaseOrder.Controls.Add(this.LBL_Remark);
            this.panel_PurchaseOrder.Controls.Add(this.LBL_Type);
            this.panel_PurchaseOrder.Controls.Add(this.LBL_ToDepartment);
            this.panel_PurchaseOrder.Controls.Add(this.LBL_FormDepartment);
            this.panel_PurchaseOrder.Controls.Add(this.LBL_Date);
            this.panel_PurchaseOrder.Controls.Add(this.LBL_TransferNo);
            this.panel_PurchaseOrder.Location = new System.Drawing.Point(0, 0);
            this.panel_PurchaseOrder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel_PurchaseOrder.Name = "panel_PurchaseOrder";
            this.panel_PurchaseOrder.Size = new System.Drawing.Size(1107, 248);
            this.panel_PurchaseOrder.TabIndex = 4;
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
            this.sS_MaskedTextBox_FromFacName.Location = new System.Drawing.Point(432, 212);
            this.sS_MaskedTextBox_FromFacName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sS_MaskedTextBox_FromFacName.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_FromFacName.Name = "sS_MaskedTextBox_FromFacName";
            this.sS_MaskedTextBox_FromFacName.Size = new System.Drawing.Size(248, 26);
            this.sS_MaskedTextBox_FromFacName.TabIndex = 21;
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
            this.sS_MaskedTextBox_FromFacCode.Location = new System.Drawing.Point(252, 212);
            this.sS_MaskedTextBox_FromFacCode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sS_MaskedTextBox_FromFacCode.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_FromFacCode.Name = "sS_MaskedTextBox_FromFacCode";
            this.sS_MaskedTextBox_FromFacCode.Size = new System.Drawing.Size(175, 26);
            this.sS_MaskedTextBox_FromFacCode.TabIndex = 20;
            // 
            // LBL_FormCompany
            // 
            this.LBL_FormCompany.AutoSize = true;
            this.LBL_FormCompany.Location = new System.Drawing.Point(71, 212);
            this.LBL_FormCompany.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBL_FormCompany.Name = "LBL_FormCompany";
            this.LBL_FormCompany.Size = new System.Drawing.Size(71, 17);
            this.LBL_FormCompany.TabIndex = 19;
            this.LBL_FormCompany.Text = "Company:";
            // 
            // dateTimePicker_Date
            // 
            this.dateTimePicker_Date.Location = new System.Drawing.Point(252, 39);
            this.dateTimePicker_Date.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTimePicker_Date.Name = "dateTimePicker_Date";
            this.dateTimePicker_Date.Size = new System.Drawing.Size(175, 22);
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
            this.sS_MaskedTextBox_ToDeptName.Location = new System.Drawing.Point(432, 133);
            this.sS_MaskedTextBox_ToDeptName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sS_MaskedTextBox_ToDeptName.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_ToDeptName.Name = "sS_MaskedTextBox_ToDeptName";
            this.sS_MaskedTextBox_ToDeptName.Size = new System.Drawing.Size(248, 26);
            this.sS_MaskedTextBox_ToDeptName.TabIndex = 14;
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
            this.sS_MaskedTextBox_FromDeptName.Location = new System.Drawing.Point(432, 100);
            this.sS_MaskedTextBox_FromDeptName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sS_MaskedTextBox_FromDeptName.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_FromDeptName.Name = "sS_MaskedTextBox_FromDeptName";
            this.sS_MaskedTextBox_FromDeptName.Size = new System.Drawing.Size(248, 26);
            this.sS_MaskedTextBox_FromDeptName.TabIndex = 13;
            // 
            // sS_MaskedTextBox_ToDept
            // 
            this.sS_MaskedTextBox_ToDept.BackColor = System.Drawing.Color.Lavender;
            this.sS_MaskedTextBox_ToDept.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_ToDept.BackColorOnLeave = System.Drawing.Color.Lavender;
            this.sS_MaskedTextBox_ToDept.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_ToDept.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_ToDept.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_ToDept.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_ToDept.IconError = null;
            this.sS_MaskedTextBox_ToDept.IconTrue = null;
            this.sS_MaskedTextBox_ToDept.Location = new System.Drawing.Point(252, 133);
            this.sS_MaskedTextBox_ToDept.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sS_MaskedTextBox_ToDept.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_ToDept.Name = "sS_MaskedTextBox_ToDept";
            this.sS_MaskedTextBox_ToDept.Size = new System.Drawing.Size(175, 26);
            this.sS_MaskedTextBox_ToDept.TabIndex = 12;
            this.sS_MaskedTextBox_ToDept.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sS_MaskedTextBox_ToDept_KeyDown);
            // 
            // sS_ComboBox_Type
            // 
            this.sS_ComboBox_Type.BackColor = System.Drawing.Color.Honeydew;
            this.sS_ComboBox_Type.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_ComboBox_Type.BackColorOnLeave = System.Drawing.Color.Honeydew;
            this.sS_ComboBox_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sS_ComboBox_Type.FormattingEnabled = true;
            this.sS_ComboBox_Type.Items.AddRange(new object[] {
            "TRN"});
            this.sS_ComboBox_Type.Location = new System.Drawing.Point(252, 69);
            this.sS_ComboBox_Type.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sS_ComboBox_Type.Name = "sS_ComboBox_Type";
            this.sS_ComboBox_Type.Size = new System.Drawing.Size(175, 24);
            this.sS_ComboBox_Type.TabIndex = 4;
            // 
            // sS_MaskedTextBox_FromDept
            // 
            this.sS_MaskedTextBox_FromDept.BackColor = System.Drawing.Color.Lavender;
            this.sS_MaskedTextBox_FromDept.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_FromDept.BackColorOnLeave = System.Drawing.Color.Lavender;
            this.sS_MaskedTextBox_FromDept.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_FromDept.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_FromDept.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_FromDept.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_FromDept.IconError = null;
            this.sS_MaskedTextBox_FromDept.IconTrue = null;
            this.sS_MaskedTextBox_FromDept.Location = new System.Drawing.Point(252, 100);
            this.sS_MaskedTextBox_FromDept.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sS_MaskedTextBox_FromDept.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_FromDept.Name = "sS_MaskedTextBox_FromDept";
            this.sS_MaskedTextBox_FromDept.Size = new System.Drawing.Size(175, 26);
            this.sS_MaskedTextBox_FromDept.TabIndex = 10;
            this.sS_MaskedTextBox_FromDept.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sS_MaskedTextBox_FromDept_KeyDown);
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
            this.sS_MaskedTextBox_Remark.Location = new System.Drawing.Point(252, 169);
            this.sS_MaskedTextBox_Remark.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sS_MaskedTextBox_Remark.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_Remark.Multiline = true;
            this.sS_MaskedTextBox_Remark.Name = "sS_MaskedTextBox_Remark";
            this.sS_MaskedTextBox_Remark.Size = new System.Drawing.Size(428, 35);
            this.sS_MaskedTextBox_Remark.TabIndex = 5;
            // 
            // sS_MaskedTextBox_TransferNo
            // 
            this.sS_MaskedTextBox_TransferNo.BackColor = System.Drawing.Color.Honeydew;
            this.sS_MaskedTextBox_TransferNo.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_TransferNo.BackColorOnLeave = System.Drawing.Color.Honeydew;
            this.sS_MaskedTextBox_TransferNo.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_TransferNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_TransferNo.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_TransferNo.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_TransferNo.IconError = null;
            this.sS_MaskedTextBox_TransferNo.IconTrue = null;
            this.sS_MaskedTextBox_TransferNo.Location = new System.Drawing.Point(252, 6);
            this.sS_MaskedTextBox_TransferNo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sS_MaskedTextBox_TransferNo.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_TransferNo.Name = "sS_MaskedTextBox_TransferNo";
            this.sS_MaskedTextBox_TransferNo.Size = new System.Drawing.Size(175, 26);
            this.sS_MaskedTextBox_TransferNo.TabIndex = 0;
            this.sS_MaskedTextBox_TransferNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sS_MaskedTextBox_TransferNo_KeyDown);
            // 
            // LBL_Remark
            // 
            this.LBL_Remark.AutoSize = true;
            this.LBL_Remark.Location = new System.Drawing.Point(71, 169);
            this.LBL_Remark.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBL_Remark.Name = "LBL_Remark";
            this.LBL_Remark.Size = new System.Drawing.Size(61, 17);
            this.LBL_Remark.TabIndex = 2;
            this.LBL_Remark.Text = "Remark:";
            // 
            // LBL_Type
            // 
            this.LBL_Type.AutoSize = true;
            this.LBL_Type.Location = new System.Drawing.Point(71, 69);
            this.LBL_Type.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBL_Type.Name = "LBL_Type";
            this.LBL_Type.Size = new System.Drawing.Size(44, 17);
            this.LBL_Type.TabIndex = 2;
            this.LBL_Type.Text = "Type:";
            // 
            // LBL_ToDepartment
            // 
            this.LBL_ToDepartment.AutoSize = true;
            this.LBL_ToDepartment.Location = new System.Drawing.Point(71, 133);
            this.LBL_ToDepartment.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBL_ToDepartment.Name = "LBL_ToDepartment";
            this.LBL_ToDepartment.Size = new System.Drawing.Size(107, 17);
            this.LBL_ToDepartment.TabIndex = 2;
            this.LBL_ToDepartment.Text = "To Department:";
            // 
            // LBL_FormDepartment
            // 
            this.LBL_FormDepartment.AutoSize = true;
            this.LBL_FormDepartment.Location = new System.Drawing.Point(71, 100);
            this.LBL_FormDepartment.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBL_FormDepartment.Name = "LBL_FormDepartment";
            this.LBL_FormDepartment.Size = new System.Drawing.Size(122, 17);
            this.LBL_FormDepartment.TabIndex = 2;
            this.LBL_FormDepartment.Text = "Form Department:";
            // 
            // LBL_Date
            // 
            this.LBL_Date.AutoSize = true;
            this.LBL_Date.Location = new System.Drawing.Point(71, 37);
            this.LBL_Date.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBL_Date.Name = "LBL_Date";
            this.LBL_Date.Size = new System.Drawing.Size(42, 17);
            this.LBL_Date.TabIndex = 2;
            this.LBL_Date.Text = "Date:";
            // 
            // LBL_TransferNo
            // 
            this.LBL_TransferNo.AutoSize = true;
            this.LBL_TransferNo.Location = new System.Drawing.Point(71, 6);
            this.LBL_TransferNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBL_TransferNo.Name = "LBL_TransferNo";
            this.LBL_TransferNo.Size = new System.Drawing.Size(92, 17);
            this.LBL_TransferNo.TabIndex = 2;
            this.LBL_TransferNo.Text = "Transfer No :";
            // 
            // LBL_Detail
            // 
            this.LBL_Detail.AutoSize = true;
            this.LBL_Detail.BackColor = System.Drawing.Color.Transparent;
            this.LBL_Detail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.LBL_Detail.Location = new System.Drawing.Point(15, 252);
            this.LBL_Detail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBL_Detail.Name = "LBL_Detail";
            this.LBL_Detail.Size = new System.Drawing.Size(55, 17);
            this.LBL_Detail.TabIndex = 13;
            this.LBL_Detail.Text = "Detail:";
            // 
            // toolStripStatusLabel_Record
            // 
            this.toolStripStatusLabel_Record.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabel_Record.Name = "toolStripStatusLabel_Record";
            this.toolStripStatusLabel_Record.Size = new System.Drawing.Size(104, 22);
            this.toolStripStatusLabel_Record.Text = "[1/All] records";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Highlight;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_Record});
            this.statusStrip1.Location = new System.Drawing.Point(0, 695);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1107, 27);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.sS_DataGridView_AssetTransferDT);
            this.panel2.Location = new System.Drawing.Point(1, 277);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1105, 182);
            this.panel2.TabIndex = 5;
            // 
            // sS_DataGridView_AssetTransferDT
            // 
            this.sS_DataGridView_AssetTransferDT.AllowUserToAddRows = false;
            this.sS_DataGridView_AssetTransferDT.AllowUserToDeleteRows = false;
            this.sS_DataGridView_AssetTransferDT.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.sS_DataGridView_AssetTransferDT.BackColorCellFocus = System.Drawing.Color.LightBlue;
            this.sS_DataGridView_AssetTransferDT.BackColorCellLeave = System.Drawing.Color.Honeydew;
            this.sS_DataGridView_AssetTransferDT.BackColorRow = System.Drawing.Color.HotPink;
            this.sS_DataGridView_AssetTransferDT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sS_DataGridView_AssetTransferDT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sS_DataGridView_AssetTransferDT.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NO,
            this.ModelID,
            this.ModelName,
            this.Quantity,
            this.Column13,
            this.Price,
            this.Cost,
            this.Remark});
            this.sS_DataGridView_AssetTransferDT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sS_DataGridView_AssetTransferDT.Location = new System.Drawing.Point(0, 0);
            this.sS_DataGridView_AssetTransferDT.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sS_DataGridView_AssetTransferDT.Name = "sS_DataGridView_AssetTransferDT";
            this.sS_DataGridView_AssetTransferDT.RowTemplate.Height = 24;
            this.sS_DataGridView_AssetTransferDT.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.sS_DataGridView_AssetTransferDT.Size = new System.Drawing.Size(1101, 178);
            this.sS_DataGridView_AssetTransferDT.TabIndex = 1;
            this.sS_DataGridView_AssetTransferDT.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.sS_DataGridView_AssetTransferDT_RowEnter);
            // 
            // NO
            // 
            this.NO.FillWeight = 23.52579F;
            this.NO.HeaderText = "No";
            this.NO.Name = "NO";
            // 
            // ModelID
            // 
            this.ModelID.FillWeight = 40.56534F;
            this.ModelID.HeaderText = "ModelID";
            this.ModelID.Name = "ModelID";
            // 
            // ModelName
            // 
            this.ModelName.FillWeight = 41.38847F;
            this.ModelName.HeaderText = "ModelName";
            this.ModelName.Name = "ModelName";
            // 
            // Quantity
            // 
            this.Quantity.FillWeight = 37.17005F;
            this.Quantity.HeaderText = "Order Qty";
            this.Quantity.Name = "Quantity";
            // 
            // Column13
            // 
            this.Column13.FillWeight = 36.0535F;
            this.Column13.HeaderText = "Transfer Qty";
            this.Column13.Name = "Column13";
            // 
            // Price
            // 
            this.Price.FillWeight = 35.28868F;
            this.Price.HeaderText = "Price";
            this.Price.Name = "Price";
            // 
            // Cost
            // 
            this.Cost.FillWeight = 35.28868F;
            this.Cost.HeaderText = "Cost";
            this.Cost.Name = "Cost";
            // 
            // Remark
            // 
            this.Remark.FillWeight = 70.37436F;
            this.Remark.HeaderText = "Remark";
            this.Remark.Name = "Remark";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.sS_DataGridView_AssetTransferSerial);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 487);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1107, 208);
            this.panel1.TabIndex = 12;
            // 
            // sS_DataGridView_AssetTransferSerial
            // 
            this.sS_DataGridView_AssetTransferSerial.BackColorCellFocus = System.Drawing.Color.LightBlue;
            this.sS_DataGridView_AssetTransferSerial.BackColorCellLeave = System.Drawing.Color.Honeydew;
            this.sS_DataGridView_AssetTransferSerial.BackColorRow = System.Drawing.Color.HotPink;
            this.sS_DataGridView_AssetTransferSerial.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sS_DataGridView_AssetTransferSerial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.sS_DataGridView_AssetTransferSerial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column14,
            this.Column6,
            this.Column7,
            this.Column4,
            this.Column5,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12});
            this.sS_DataGridView_AssetTransferSerial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sS_DataGridView_AssetTransferSerial.Location = new System.Drawing.Point(0, 0);
            this.sS_DataGridView_AssetTransferSerial.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sS_DataGridView_AssetTransferSerial.Name = "sS_DataGridView_AssetTransferSerial";
            this.sS_DataGridView_AssetTransferSerial.RowTemplate.Height = 24;
            this.sS_DataGridView_AssetTransferSerial.Size = new System.Drawing.Size(1103, 204);
            this.sS_DataGridView_AssetTransferSerial.TabIndex = 0;
            this.sS_DataGridView_AssetTransferSerial.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.sS_DataGridView_AssetTransferSerial_CellBeginEdit);
            this.sS_DataGridView_AssetTransferSerial.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.sS_DataGridView_AssetTransferSerial_CellMouseDown);
            this.sS_DataGridView_AssetTransferSerial.Leave += new System.EventHandler(this.sS_DataGridView_AssetTransferSerial_Leave);
            this.sS_DataGridView_AssetTransferSerial.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.sS_DataGridView_AssetTransferSerial_UserDeletedRow);
            this.sS_DataGridView_AssetTransferSerial.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.sS_DataGridView_AssetTransferSerial_CellEnter);
            this.sS_DataGridView_AssetTransferSerial.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.sS_DataGridView_AssetTransferSerial_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.FillWeight = 40F;
            this.Column1.HeaderText = "No";
            this.Column1.Name = "Column1";
            this.Column1.Width = 54;
            // 
            // Column2
            // 
            this.Column2.FillWeight = 83.58714F;
            this.Column2.HeaderText = "AssetNo";
            this.Column2.Name = "Column2";
            this.Column2.Width = 114;
            // 
            // Column3
            // 
            this.Column3.FillWeight = 83.58714F;
            this.Column3.HeaderText = "AssetName";
            this.Column3.Name = "Column3";
            this.Column3.Width = 113;
            // 
            // Column14
            // 
            this.Column14.FillWeight = 83.58714F;
            this.Column14.HeaderText = "SerialNo";
            this.Column14.Name = "Column14";
            this.Column14.Width = 101;
            // 
            // Column6
            // 
            this.Column6.FillWeight = 83.58714F;
            this.Column6.HeaderText = "From Building";
            this.Column6.Name = "Column6";
            this.Column6.Width = 114;
            // 
            // Column7
            // 
            this.Column7.FillWeight = 83.58714F;
            this.Column7.HeaderText = "To Building";
            this.Column7.Name = "Column7";
            this.Column7.Width = 113;
            // 
            // Column4
            // 
            this.Column4.FillWeight = 83.58714F;
            this.Column4.HeaderText = "From Floor";
            this.Column4.Name = "Column4";
            this.Column4.Width = 114;
            // 
            // Column5
            // 
            this.Column5.FillWeight = 83.58714F;
            this.Column5.HeaderText = "To Floor";
            this.Column5.Name = "Column5";
            this.Column5.Width = 113;
            // 
            // Column8
            // 
            this.Column8.FillWeight = 83.58714F;
            this.Column8.HeaderText = "From Area";
            this.Column8.Name = "Column8";
            this.Column8.Width = 114;
            // 
            // Column9
            // 
            this.Column9.FillWeight = 83.58714F;
            this.Column9.HeaderText = "To Area";
            this.Column9.Name = "Column9";
            this.Column9.Width = 113;
            // 
            // Column10
            // 
            this.Column10.FillWeight = 83.58714F;
            this.Column10.HeaderText = "From Custodain";
            this.Column10.Name = "Column10";
            this.Column10.Width = 114;
            // 
            // Column11
            // 
            this.Column11.FillWeight = 83.58714F;
            this.Column11.HeaderText = "To Custodain";
            this.Column11.Name = "Column11";
            this.Column11.Width = 113;
            // 
            // Column12
            // 
            this.Column12.FillWeight = 83.58714F;
            this.Column12.HeaderText = "Remark";
            this.Column12.Name = "Column12";
            this.Column12.Width = 114;
            // 
            // LBL_AssetDetail
            // 
            this.LBL_AssetDetail.AutoSize = true;
            this.LBL_AssetDetail.BackColor = System.Drawing.Color.Transparent;
            this.LBL_AssetDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.LBL_AssetDetail.Location = new System.Drawing.Point(15, 465);
            this.LBL_AssetDetail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBL_AssetDetail.Name = "LBL_AssetDetail";
            this.LBL_AssetDetail.Size = new System.Drawing.Size(100, 17);
            this.LBL_AssetDetail.TabIndex = 13;
            this.LBL_AssetDetail.Text = "Asset Detail:";
            // 
            // Form_001004_InternalTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(210)))), ((int)(((byte)(238)))));
            this.ClientSize = new System.Drawing.Size(1107, 722);
            this.Controls.Add(this.LBL_AssetDetail);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.LBL_Detail);
            this.Controls.Add(this.panel_PurchaseOrder);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form_001004_InternalTransfer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ID:001004(Internal Transfer)";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_001004_InternalTransfer_FormClosed);
            this.Activated += new System.EventHandler(this.Form_001004_InternalTransfer_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_001004_InternalTransfer_FormClosing);
            this.Load += new System.EventHandler(this.Form_001004_InternalTransfer_Load);
            this.panel_PurchaseOrder.ResumeLayout(false);
            this.panel_PurchaseOrder.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sS_DataGridView_AssetTransferDT)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sS_DataGridView_AssetTransferSerial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_PurchaseOrder;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_TransferNo;
        private System.Windows.Forms.Label LBL_TransferNo;
        private System.Windows.Forms.Label LBL_FormDepartment;
        private System.Windows.Forms.Label LBL_Date;
        private System.Windows.Forms.Label LBL_Type;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_Remark;
        private System.Windows.Forms.Label LBL_Remark;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_FromDept;
        private SimatSoft.CustomControl.SS_ComboBox sS_ComboBox_Type;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Record;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_ToDept;
        private System.Windows.Forms.Label LBL_ToDepartment;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LBL_Detail;
        private System.Windows.Forms.Label LBL_AssetDetail;
        private SimatSoft.CustomControl.SS_DataGridView sS_DataGridView_AssetTransferDT;
        private SimatSoft.CustomControl.SS_DataGridView sS_DataGridView_AssetTransferSerial;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_ToDeptName;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_FromDeptName;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Date;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_FromFacName;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_FromFacCode;
        private System.Windows.Forms.Label LBL_FormCompany;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModelID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModelName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
    }
}