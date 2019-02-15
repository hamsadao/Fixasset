namespace SimatSoft.FixAsset
{
    partial class Form_001006_ExternalTransfer
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel_PurchaseOrder = new System.Windows.Forms.Panel();
            this.dateTimePicker_Date = new System.Windows.Forms.DateTimePicker();
            this.sS_MaskedTextBox_ToFacName = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.sS_MaskedTextBox_FromFacName = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.sS_MaskedTextBox_ToFacCode = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.sS_ComboBox_ExTransferType = new SimatSoft.CustomControl.SS_ComboBox();
            this.sS_MaskedTextBox_FromFacCode = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.sS_MaskedTextBox_Remark = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.sS_MaskedTextBox_TransferNo = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.LBL_Remark = new System.Windows.Forms.Label();
            this.LBL_Type = new System.Windows.Forms.Label();
            this.LBL_ToFacility = new System.Windows.Forms.Label();
            this.LBL_FromFacility = new System.Windows.Forms.Label();
            this.LBL_Date = new System.Windows.Forms.Label();
            this.LBL_TransferNo = new System.Windows.Forms.Label();
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
            this.LBL_Detail = new System.Windows.Forms.Label();
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
            this.panel_PurchaseOrder.Controls.Add(this.dateTimePicker_Date);
            this.panel_PurchaseOrder.Controls.Add(this.sS_MaskedTextBox_ToFacName);
            this.panel_PurchaseOrder.Controls.Add(this.sS_MaskedTextBox_FromFacName);
            this.panel_PurchaseOrder.Controls.Add(this.sS_MaskedTextBox_ToFacCode);
            this.panel_PurchaseOrder.Controls.Add(this.sS_ComboBox_ExTransferType);
            this.panel_PurchaseOrder.Controls.Add(this.sS_MaskedTextBox_FromFacCode);
            this.panel_PurchaseOrder.Controls.Add(this.sS_MaskedTextBox_Remark);
            this.panel_PurchaseOrder.Controls.Add(this.sS_MaskedTextBox_TransferNo);
            this.panel_PurchaseOrder.Controls.Add(this.LBL_Remark);
            this.panel_PurchaseOrder.Controls.Add(this.LBL_Type);
            this.panel_PurchaseOrder.Controls.Add(this.LBL_ToFacility);
            this.panel_PurchaseOrder.Controls.Add(this.LBL_FromFacility);
            this.panel_PurchaseOrder.Controls.Add(this.LBL_Date);
            this.panel_PurchaseOrder.Controls.Add(this.LBL_TransferNo);
            this.panel_PurchaseOrder.Location = new System.Drawing.Point(0, 0);
            this.panel_PurchaseOrder.Name = "panel_PurchaseOrder";
            this.panel_PurchaseOrder.Size = new System.Drawing.Size(814, 173);
            this.panel_PurchaseOrder.TabIndex = 4;
            // 
            // dateTimePicker_Date
            // 
            this.dateTimePicker_Date.Location = new System.Drawing.Point(189, 36);
            this.dateTimePicker_Date.Name = "dateTimePicker_Date";
            this.dateTimePicker_Date.Size = new System.Drawing.Size(133, 20);
            this.dateTimePicker_Date.TabIndex = 15;
            // 
            // sS_MaskedTextBox_ToFacName
            // 
            this.sS_MaskedTextBox_ToFacName.BackColor = System.Drawing.Color.LightCyan;
            this.sS_MaskedTextBox_ToFacName.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_ToFacName.BackColorOnLeave = System.Drawing.Color.LightCyan;
            this.sS_MaskedTextBox_ToFacName.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_ToFacName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_ToFacName.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_ToFacName.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_ToFacName.IconError = null;
            this.sS_MaskedTextBox_ToFacName.IconTrue = null;
            this.sS_MaskedTextBox_ToFacName.Location = new System.Drawing.Point(326, 108);
            this.sS_MaskedTextBox_ToFacName.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_ToFacName.Name = "sS_MaskedTextBox_ToFacName";
            this.sS_MaskedTextBox_ToFacName.Size = new System.Drawing.Size(182, 23);
            this.sS_MaskedTextBox_ToFacName.TabIndex = 14;
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
            this.sS_MaskedTextBox_FromFacName.Location = new System.Drawing.Point(326, 83);
            this.sS_MaskedTextBox_FromFacName.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_FromFacName.Name = "sS_MaskedTextBox_FromFacName";
            this.sS_MaskedTextBox_FromFacName.Size = new System.Drawing.Size(182, 23);
            this.sS_MaskedTextBox_FromFacName.TabIndex = 13;
            // 
            // sS_MaskedTextBox_ToFacCode
            // 
            this.sS_MaskedTextBox_ToFacCode.BackColor = System.Drawing.Color.Lavender;
            this.sS_MaskedTextBox_ToFacCode.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_ToFacCode.BackColorOnLeave = System.Drawing.Color.Honeydew;
            this.sS_MaskedTextBox_ToFacCode.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_ToFacCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_ToFacCode.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_ToFacCode.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_ToFacCode.IconError = null;
            this.sS_MaskedTextBox_ToFacCode.IconTrue = null;
            this.sS_MaskedTextBox_ToFacCode.Location = new System.Drawing.Point(189, 108);
            this.sS_MaskedTextBox_ToFacCode.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_ToFacCode.Name = "sS_MaskedTextBox_ToFacCode";
            this.sS_MaskedTextBox_ToFacCode.Size = new System.Drawing.Size(133, 23);
            this.sS_MaskedTextBox_ToFacCode.TabIndex = 12;
            // 
            // sS_ComboBox_ExTransferType
            // 
            this.sS_ComboBox_ExTransferType.BackColor = System.Drawing.Color.Honeydew;
            this.sS_ComboBox_ExTransferType.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_ComboBox_ExTransferType.BackColorOnLeave = System.Drawing.Color.Honeydew;
            this.sS_ComboBox_ExTransferType.FormattingEnabled = true;
            this.sS_ComboBox_ExTransferType.Items.AddRange(new object[] {
            "TRN"});
            this.sS_ComboBox_ExTransferType.Location = new System.Drawing.Point(189, 60);
            this.sS_ComboBox_ExTransferType.Name = "sS_ComboBox_ExTransferType";
            this.sS_ComboBox_ExTransferType.Size = new System.Drawing.Size(133, 21);
            this.sS_ComboBox_ExTransferType.TabIndex = 4;
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
            this.sS_MaskedTextBox_FromFacCode.Location = new System.Drawing.Point(189, 83);
            this.sS_MaskedTextBox_FromFacCode.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_FromFacCode.Name = "sS_MaskedTextBox_FromFacCode";
            this.sS_MaskedTextBox_FromFacCode.Size = new System.Drawing.Size(133, 23);
            this.sS_MaskedTextBox_FromFacCode.TabIndex = 10;
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
            this.sS_MaskedTextBox_Remark.Location = new System.Drawing.Point(189, 134);
            this.sS_MaskedTextBox_Remark.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_Remark.Multiline = true;
            this.sS_MaskedTextBox_Remark.Name = "sS_MaskedTextBox_Remark";
            this.sS_MaskedTextBox_Remark.Size = new System.Drawing.Size(319, 29);
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
            this.sS_MaskedTextBox_TransferNo.Location = new System.Drawing.Point(189, 10);
            this.sS_MaskedTextBox_TransferNo.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_TransferNo.Name = "sS_MaskedTextBox_TransferNo";
            this.sS_MaskedTextBox_TransferNo.Size = new System.Drawing.Size(133, 23);
            this.sS_MaskedTextBox_TransferNo.TabIndex = 0;
            this.sS_MaskedTextBox_TransferNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sS_MaskedTextBox_TransferNo_KeyDown);
            // 
            // LBL_Remark
            // 
            this.LBL_Remark.AutoSize = true;
            this.LBL_Remark.Location = new System.Drawing.Point(66, 134);
            this.LBL_Remark.Name = "LBL_Remark";
            this.LBL_Remark.Size = new System.Drawing.Size(47, 13);
            this.LBL_Remark.TabIndex = 2;
            this.LBL_Remark.Text = "Remark:";
            // 
            // LBL_Type
            // 
            this.LBL_Type.AutoSize = true;
            this.LBL_Type.Location = new System.Drawing.Point(66, 60);
            this.LBL_Type.Name = "LBL_Type";
            this.LBL_Type.Size = new System.Drawing.Size(34, 13);
            this.LBL_Type.TabIndex = 2;
            this.LBL_Type.Text = "Type:";
            // 
            // LBL_ToFacility
            // 
            this.LBL_ToFacility.AutoSize = true;
            this.LBL_ToFacility.Location = new System.Drawing.Point(66, 108);
            this.LBL_ToFacility.Name = "LBL_ToFacility";
            this.LBL_ToFacility.Size = new System.Drawing.Size(70, 13);
            this.LBL_ToFacility.TabIndex = 2;
            this.LBL_ToFacility.Text = "To Company:";
            // 
            // LBL_FromFacility
            // 
            this.LBL_FromFacility.AutoSize = true;
            this.LBL_FromFacility.Location = new System.Drawing.Point(66, 83);
            this.LBL_FromFacility.Name = "LBL_FromFacility";
            this.LBL_FromFacility.Size = new System.Drawing.Size(80, 13);
            this.LBL_FromFacility.TabIndex = 2;
            this.LBL_FromFacility.Text = "From Company:";
            // 
            // LBL_Date
            // 
            this.LBL_Date.AutoSize = true;
            this.LBL_Date.Location = new System.Drawing.Point(66, 36);
            this.LBL_Date.Name = "LBL_Date";
            this.LBL_Date.Size = new System.Drawing.Size(33, 13);
            this.LBL_Date.TabIndex = 2;
            this.LBL_Date.Text = "Date:";
            // 
            // LBL_TransferNo
            // 
            this.LBL_TransferNo.AutoSize = true;
            this.LBL_TransferNo.Location = new System.Drawing.Point(65, 17);
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 542);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(812, 22);
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
            this.panel2.Location = new System.Drawing.Point(1, 192);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(813, 159);
            this.panel2.TabIndex = 5;
            // 
            // sS_DataGridView_AssetTransferDT
            // 
            this.sS_DataGridView_AssetTransferDT.AllowUserToAddRows = false;
            this.sS_DataGridView_AssetTransferDT.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.sS_DataGridView_AssetTransferDT.BackColorCellFocus = System.Drawing.Color.LightBlue;
            this.sS_DataGridView_AssetTransferDT.BackColorCellLeave = System.Drawing.Color.Honeydew;
            this.sS_DataGridView_AssetTransferDT.BackColorRow = System.Drawing.Color.HotPink;
            this.sS_DataGridView_AssetTransferDT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.sS_DataGridView_AssetTransferDT.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.sS_DataGridView_AssetTransferDT.DefaultCellStyle = dataGridViewCellStyle2;
            this.sS_DataGridView_AssetTransferDT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sS_DataGridView_AssetTransferDT.Location = new System.Drawing.Point(0, 0);
            this.sS_DataGridView_AssetTransferDT.Name = "sS_DataGridView_AssetTransferDT";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.sS_DataGridView_AssetTransferDT.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.sS_DataGridView_AssetTransferDT.RowTemplate.Height = 24;
            this.sS_DataGridView_AssetTransferDT.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.sS_DataGridView_AssetTransferDT.Size = new System.Drawing.Size(809, 155);
            this.sS_DataGridView_AssetTransferDT.TabIndex = 1;
            this.sS_DataGridView_AssetTransferDT.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.sS_DataGridView_AssetTransferDT_RowEnter);
            // 
            // NO
            // 
            this.NO.FillWeight = 40.60914F;
            this.NO.HeaderText = "No";
            this.NO.Name = "NO";
            // 
            // ModelID
            // 
            this.ModelID.FillWeight = 108.4844F;
            this.ModelID.HeaderText = "ModelID";
            this.ModelID.Name = "ModelID";
            // 
            // ModelName
            // 
            this.ModelName.FillWeight = 108.4844F;
            this.ModelName.HeaderText = "ModelName";
            this.ModelName.Name = "ModelName";
            // 
            // Quantity
            // 
            this.Quantity.FillWeight = 108.4844F;
            this.Quantity.HeaderText = "Order Qty";
            this.Quantity.Name = "Quantity";
            // 
            // Column13
            // 
            this.Column13.FillWeight = 108.4844F;
            this.Column13.HeaderText = "Transfer Qty";
            this.Column13.Name = "Column13";
            // 
            // Price
            // 
            this.Price.FillWeight = 108.4844F;
            this.Price.HeaderText = "Price";
            this.Price.Name = "Price";
            // 
            // Cost
            // 
            this.Cost.FillWeight = 108.4844F;
            this.Cost.HeaderText = "Cost";
            this.Cost.Name = "Cost";
            // 
            // Remark
            // 
            this.Remark.FillWeight = 108.4844F;
            this.Remark.HeaderText = "Remark";
            this.Remark.Name = "Remark";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.sS_DataGridView_AssetTransferSerial);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 379);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(812, 163);
            this.panel1.TabIndex = 12;
            // 
            // sS_DataGridView_AssetTransferSerial
            // 
            this.sS_DataGridView_AssetTransferSerial.BackColorCellFocus = System.Drawing.Color.LightBlue;
            this.sS_DataGridView_AssetTransferSerial.BackColorCellLeave = System.Drawing.Color.Honeydew;
            this.sS_DataGridView_AssetTransferSerial.BackColorRow = System.Drawing.Color.HotPink;
            this.sS_DataGridView_AssetTransferSerial.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.sS_DataGridView_AssetTransferSerial.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
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
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.sS_DataGridView_AssetTransferSerial.DefaultCellStyle = dataGridViewCellStyle5;
            this.sS_DataGridView_AssetTransferSerial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sS_DataGridView_AssetTransferSerial.Location = new System.Drawing.Point(0, 0);
            this.sS_DataGridView_AssetTransferSerial.Name = "sS_DataGridView_AssetTransferSerial";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.sS_DataGridView_AssetTransferSerial.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.sS_DataGridView_AssetTransferSerial.RowTemplate.Height = 24;
            this.sS_DataGridView_AssetTransferSerial.Size = new System.Drawing.Size(808, 159);
            this.sS_DataGridView_AssetTransferSerial.TabIndex = 0;
            this.sS_DataGridView_AssetTransferSerial.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.sS_DataGridView_AssetTransferSerial_CellBeginEdit);
            this.sS_DataGridView_AssetTransferSerial.Leave += new System.EventHandler(this.sS_DataGridView_AssetTransferSerial_Leave);
            this.sS_DataGridView_AssetTransferSerial.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.sS_DataGridView_AssetTransferSerial_UserDeletedRow);
            this.sS_DataGridView_AssetTransferSerial.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.sS_DataGridView_AssetTransferSerial_CellEnter);
            // 
            // Column1
            // 
            this.Column1.FillWeight = 30.95629F;
            this.Column1.HeaderText = "No";
            this.Column1.Name = "Column1";
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 39;
            // 
            // Column2
            // 
            this.Column2.FillWeight = 61.70307F;
            this.Column2.HeaderText = "AssetNo";
            this.Column2.Name = "Column2";
            this.Column2.Width = 114;
            // 
            // Column3
            // 
            this.Column3.FillWeight = 61.70307F;
            this.Column3.HeaderText = "AssetName";
            this.Column3.Name = "Column3";
            this.Column3.Width = 103;
            // 
            // Column14
            // 
            this.Column14.FillWeight = 61.70307F;
            this.Column14.HeaderText = "SerialNo";
            this.Column14.Name = "Column14";
            this.Column14.Width = 101;
            // 
            // Column6
            // 
            this.Column6.FillWeight = 61.70307F;
            this.Column6.HeaderText = "From Building";
            this.Column6.Name = "Column6";
            this.Column6.Width = 114;
            // 
            // Column7
            // 
            this.Column7.FillWeight = 61.70307F;
            this.Column7.HeaderText = "To Building";
            this.Column7.Name = "Column7";
            this.Column7.Width = 113;
            // 
            // Column4
            // 
            this.Column4.FillWeight = 61.70307F;
            this.Column4.HeaderText = "From Floor";
            this.Column4.Name = "Column4";
            this.Column4.Width = 114;
            // 
            // Column5
            // 
            this.Column5.FillWeight = 61.70307F;
            this.Column5.HeaderText = "To Floor";
            this.Column5.Name = "Column5";
            this.Column5.Width = 113;
            // 
            // Column8
            // 
            this.Column8.FillWeight = 61.70307F;
            this.Column8.HeaderText = "From Area";
            this.Column8.Name = "Column8";
            this.Column8.Width = 114;
            // 
            // Column9
            // 
            this.Column9.FillWeight = 61.70307F;
            this.Column9.HeaderText = "To Area";
            this.Column9.Name = "Column9";
            this.Column9.Width = 113;
            // 
            // Column10
            // 
            this.Column10.FillWeight = 61.70307F;
            this.Column10.HeaderText = "From Custodain";
            this.Column10.Name = "Column10";
            this.Column10.Width = 114;
            // 
            // Column11
            // 
            this.Column11.FillWeight = 61.70307F;
            this.Column11.HeaderText = "To Custodain";
            this.Column11.Name = "Column11";
            this.Column11.Width = 113;
            // 
            // Column12
            // 
            this.Column12.FillWeight = 61.70307F;
            this.Column12.HeaderText = "Remark";
            this.Column12.Name = "Column12";
            this.Column12.Width = 114;
            // 
            // LBL_AssetDetail
            // 
            this.LBL_AssetDetail.AutoSize = true;
            this.LBL_AssetDetail.BackColor = System.Drawing.Color.Transparent;
            this.LBL_AssetDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.LBL_AssetDetail.Location = new System.Drawing.Point(12, 365);
            this.LBL_AssetDetail.Name = "LBL_AssetDetail";
            this.LBL_AssetDetail.Size = new System.Drawing.Size(79, 13);
            this.LBL_AssetDetail.TabIndex = 13;
            this.LBL_AssetDetail.Text = "Asset Detail:";
            // 
            // LBL_Detail
            // 
            this.LBL_Detail.AutoSize = true;
            this.LBL_Detail.BackColor = System.Drawing.Color.Transparent;
            this.LBL_Detail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.LBL_Detail.Location = new System.Drawing.Point(12, 176);
            this.LBL_Detail.Name = "LBL_Detail";
            this.LBL_Detail.Size = new System.Drawing.Size(44, 13);
            this.LBL_Detail.TabIndex = 13;
            this.LBL_Detail.Text = "Detail:";
            // 
            // Form_001006_ExternalTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(210)))), ((int)(((byte)(238)))));
            this.ClientSize = new System.Drawing.Size(812, 564);
            this.Controls.Add(this.LBL_AssetDetail);
            this.Controls.Add(this.LBL_Detail);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel_PurchaseOrder);
            this.Name = "Form_001006_ExternalTransfer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ID:001006(External Transfer)";
            this.Load += new System.EventHandler(this.Form_001006_ExternalTransfer_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_001006_ExternalTransfer_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_001006_ExternalTransfer_FormClosing);
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
        private System.Windows.Forms.Label LBL_FromFacility;
        private System.Windows.Forms.Label LBL_Date;
        private System.Windows.Forms.Label LBL_Type;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_Remark;
        private System.Windows.Forms.Label LBL_Remark;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_FromFacCode;
        private SimatSoft.CustomControl.SS_ComboBox sS_ComboBox_ExTransferType;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Record;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_ToFacCode;
        private System.Windows.Forms.Label LBL_ToFacility;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LBL_AssetDetail;
        private SimatSoft.CustomControl.SS_DataGridView sS_DataGridView_AssetTransferDT;
        private SimatSoft.CustomControl.SS_DataGridView sS_DataGridView_AssetTransferSerial;
        private System.Windows.Forms.Label LBL_Detail;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_ToFacName;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_FromFacName;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModelID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModelName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
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
    }
}