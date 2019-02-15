namespace SimatSoft.FixAsset
{
    partial class Form_002007_Area
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
            this.sS_DataGridView_Area = new SimatSoft.CustomControl.SS_DataGridView();
            this.panel_Area = new System.Windows.Forms.Panel();
            this.sS_MaskedTextBox_FacName = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.sS_MaskedTextBox_FloorName = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.sS_MaskedTextBox_BuildName = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.sS_MaskedTextBox_BuildingNo = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.sS_MaskedTextBox_FloorNo = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.sS_MaskedTextBox_FacilityNo = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.sS_MaskedTextBox_AreaName = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.LBL_FloorNo = new System.Windows.Forms.Label();
            this.LBL_CompanyNo = new System.Windows.Forms.Label();
            this.LBL_BuildingNo = new System.Windows.Forms.Label();
            this.LBL_AreaName = new System.Windows.Forms.Label();
            this.LBL_AreaNo = new System.Windows.Forms.Label();
            this.sS_MaskedTextBox_AreaNo = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_Record = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.sS_DataGridView_Area)).BeginInit();
            this.panel_Area.SuspendLayout();
            this.panel2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sS_DataGridView_Area
            // 
            this.sS_DataGridView_Area.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sS_DataGridView_Area.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.sS_DataGridView_Area.BackColorCellFocus = System.Drawing.Color.LightBlue;
            this.sS_DataGridView_Area.BackColorCellLeave = System.Drawing.Color.Honeydew;
            this.sS_DataGridView_Area.BackColorRow = System.Drawing.Color.HotPink;
            this.sS_DataGridView_Area.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sS_DataGridView_Area.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sS_DataGridView_Area.Location = new System.Drawing.Point(-1, 0);
            this.sS_DataGridView_Area.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sS_DataGridView_Area.Name = "sS_DataGridView_Area";
            this.sS_DataGridView_Area.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.sS_DataGridView_Area.Size = new System.Drawing.Size(589, 268);
            this.sS_DataGridView_Area.TabIndex = 0;
            this.sS_DataGridView_Area.Click += new System.EventHandler(this.sS_DataGridView_Area_Click);
            // 
            // panel_Area
            // 
            this.panel_Area.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_Area.BackColor = System.Drawing.Color.Transparent;
            this.panel_Area.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_Area.Controls.Add(this.sS_MaskedTextBox_FacName);
            this.panel_Area.Controls.Add(this.sS_MaskedTextBox_FloorName);
            this.panel_Area.Controls.Add(this.sS_MaskedTextBox_BuildName);
            this.panel_Area.Controls.Add(this.sS_MaskedTextBox_BuildingNo);
            this.panel_Area.Controls.Add(this.sS_MaskedTextBox_FloorNo);
            this.panel_Area.Controls.Add(this.sS_MaskedTextBox_FacilityNo);
            this.panel_Area.Controls.Add(this.sS_MaskedTextBox_AreaName);
            this.panel_Area.Controls.Add(this.LBL_FloorNo);
            this.panel_Area.Controls.Add(this.LBL_CompanyNo);
            this.panel_Area.Controls.Add(this.LBL_BuildingNo);
            this.panel_Area.Controls.Add(this.LBL_AreaName);
            this.panel_Area.Controls.Add(this.LBL_AreaNo);
            this.panel_Area.Controls.Add(this.sS_MaskedTextBox_AreaNo);
            this.panel_Area.Location = new System.Drawing.Point(1, 4);
            this.panel_Area.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel_Area.Name = "panel_Area";
            this.panel_Area.Size = new System.Drawing.Size(584, 194);
            this.panel_Area.TabIndex = 4;
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
            this.sS_MaskedTextBox_FacName.Location = new System.Drawing.Point(335, 144);
            this.sS_MaskedTextBox_FacName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sS_MaskedTextBox_FacName.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_FacName.Name = "sS_MaskedTextBox_FacName";
            this.sS_MaskedTextBox_FacName.ReadOnly = true;
            this.sS_MaskedTextBox_FacName.Size = new System.Drawing.Size(229, 26);
            this.sS_MaskedTextBox_FacName.TabIndex = 10;
            this.sS_MaskedTextBox_FacName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sS_MaskedTextBox_FacilityNo_KeyDown);
            // 
            // sS_MaskedTextBox_FloorName
            // 
            this.sS_MaskedTextBox_FloorName.BackColor = System.Drawing.Color.LightCyan;
            this.sS_MaskedTextBox_FloorName.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_FloorName.BackColorOnLeave = System.Drawing.Color.LightCyan;
            this.sS_MaskedTextBox_FloorName.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_FloorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_FloorName.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_FloorName.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_FloorName.IconError = null;
            this.sS_MaskedTextBox_FloorName.IconTrue = null;
            this.sS_MaskedTextBox_FloorName.Location = new System.Drawing.Point(335, 112);
            this.sS_MaskedTextBox_FloorName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sS_MaskedTextBox_FloorName.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_FloorName.Name = "sS_MaskedTextBox_FloorName";
            this.sS_MaskedTextBox_FloorName.ReadOnly = true;
            this.sS_MaskedTextBox_FloorName.Size = new System.Drawing.Size(229, 26);
            this.sS_MaskedTextBox_FloorName.TabIndex = 9;
            this.sS_MaskedTextBox_FloorName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sS_MaskedTextBox_FloorNo_KeyDown);
            // 
            // sS_MaskedTextBox_BuildName
            // 
            this.sS_MaskedTextBox_BuildName.BackColor = System.Drawing.Color.LightCyan;
            this.sS_MaskedTextBox_BuildName.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_BuildName.BackColorOnLeave = System.Drawing.Color.LightCyan;
            this.sS_MaskedTextBox_BuildName.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_BuildName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_BuildName.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_BuildName.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_BuildName.IconError = null;
            this.sS_MaskedTextBox_BuildName.IconTrue = null;
            this.sS_MaskedTextBox_BuildName.Location = new System.Drawing.Point(335, 80);
            this.sS_MaskedTextBox_BuildName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sS_MaskedTextBox_BuildName.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_BuildName.Name = "sS_MaskedTextBox_BuildName";
            this.sS_MaskedTextBox_BuildName.ReadOnly = true;
            this.sS_MaskedTextBox_BuildName.Size = new System.Drawing.Size(229, 26);
            this.sS_MaskedTextBox_BuildName.TabIndex = 8;
            this.sS_MaskedTextBox_BuildName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sS_MaskedTextBox_BuildingNo_KeyDown);
            // 
            // sS_MaskedTextBox_BuildingNo
            // 
            this.sS_MaskedTextBox_BuildingNo.BackColor = System.Drawing.Color.Lavender;
            this.sS_MaskedTextBox_BuildingNo.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_BuildingNo.BackColorOnLeave = System.Drawing.Color.Lavender;
            this.sS_MaskedTextBox_BuildingNo.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_BuildingNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_BuildingNo.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_BuildingNo.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_BuildingNo.IconError = null;
            this.sS_MaskedTextBox_BuildingNo.IconTrue = null;
            this.sS_MaskedTextBox_BuildingNo.Location = new System.Drawing.Point(160, 80);
            this.sS_MaskedTextBox_BuildingNo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sS_MaskedTextBox_BuildingNo.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_BuildingNo.Name = "sS_MaskedTextBox_BuildingNo";
            this.sS_MaskedTextBox_BuildingNo.ReadOnly = true;
            this.sS_MaskedTextBox_BuildingNo.Size = new System.Drawing.Size(165, 26);
            this.sS_MaskedTextBox_BuildingNo.TabIndex = 3;
            this.sS_MaskedTextBox_BuildingNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sS_MaskedTextBox_BuildingNo_KeyDown);
            // 
            // sS_MaskedTextBox_FloorNo
            // 
            this.sS_MaskedTextBox_FloorNo.BackColor = System.Drawing.Color.Lavender;
            this.sS_MaskedTextBox_FloorNo.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_FloorNo.BackColorOnLeave = System.Drawing.Color.Lavender;
            this.sS_MaskedTextBox_FloorNo.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_FloorNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_FloorNo.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_FloorNo.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_FloorNo.IconError = null;
            this.sS_MaskedTextBox_FloorNo.IconTrue = null;
            this.sS_MaskedTextBox_FloorNo.Location = new System.Drawing.Point(160, 112);
            this.sS_MaskedTextBox_FloorNo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sS_MaskedTextBox_FloorNo.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_FloorNo.Name = "sS_MaskedTextBox_FloorNo";
            this.sS_MaskedTextBox_FloorNo.ReadOnly = true;
            this.sS_MaskedTextBox_FloorNo.Size = new System.Drawing.Size(165, 26);
            this.sS_MaskedTextBox_FloorNo.TabIndex = 4;
            this.sS_MaskedTextBox_FloorNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sS_MaskedTextBox_FloorNo_KeyDown);
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
            this.sS_MaskedTextBox_FacilityNo.Location = new System.Drawing.Point(160, 144);
            this.sS_MaskedTextBox_FacilityNo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sS_MaskedTextBox_FacilityNo.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_FacilityNo.Name = "sS_MaskedTextBox_FacilityNo";
            this.sS_MaskedTextBox_FacilityNo.ReadOnly = true;
            this.sS_MaskedTextBox_FacilityNo.Size = new System.Drawing.Size(165, 26);
            this.sS_MaskedTextBox_FacilityNo.TabIndex = 5;
            this.sS_MaskedTextBox_FacilityNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sS_MaskedTextBox_FacilityNo_KeyDown);
            // 
            // sS_MaskedTextBox_AreaName
            // 
            this.sS_MaskedTextBox_AreaName.BackColor = System.Drawing.Color.Lavender;
            this.sS_MaskedTextBox_AreaName.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_AreaName.BackColorOnLeave = System.Drawing.Color.Lavender;
            this.sS_MaskedTextBox_AreaName.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_AreaName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_AreaName.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_AreaName.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_AreaName.IconError = null;
            this.sS_MaskedTextBox_AreaName.IconTrue = null;
            this.sS_MaskedTextBox_AreaName.Location = new System.Drawing.Point(160, 47);
            this.sS_MaskedTextBox_AreaName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sS_MaskedTextBox_AreaName.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_AreaName.Name = "sS_MaskedTextBox_AreaName";
            this.sS_MaskedTextBox_AreaName.Size = new System.Drawing.Size(404, 26);
            this.sS_MaskedTextBox_AreaName.TabIndex = 2;
            this.sS_MaskedTextBox_AreaName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.sS_MaskedTextBox_AreaName_KeyPress);
            // 
            // LBL_FloorNo
            // 
            this.LBL_FloorNo.AutoSize = true;
            this.LBL_FloorNo.ForeColor = System.Drawing.Color.Black;
            this.LBL_FloorNo.Location = new System.Drawing.Point(15, 111);
            this.LBL_FloorNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBL_FloorNo.Name = "LBL_FloorNo";
            this.LBL_FloorNo.Size = new System.Drawing.Size(66, 17);
            this.LBL_FloorNo.TabIndex = 2;
            this.LBL_FloorNo.Text = "Floor No:";
            // 
            // LBL_CompanyNo
            // 
            this.LBL_CompanyNo.AutoSize = true;
            this.LBL_CompanyNo.ForeColor = System.Drawing.Color.Black;
            this.LBL_CompanyNo.Location = new System.Drawing.Point(15, 145);
            this.LBL_CompanyNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBL_CompanyNo.Name = "LBL_CompanyNo";
            this.LBL_CompanyNo.Size = new System.Drawing.Size(71, 17);
            this.LBL_CompanyNo.TabIndex = 2;
            this.LBL_CompanyNo.Text = "Company:";
            // 
            // LBL_BuildingNo
            // 
            this.LBL_BuildingNo.AutoSize = true;
            this.LBL_BuildingNo.Location = new System.Drawing.Point(15, 80);
            this.LBL_BuildingNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBL_BuildingNo.Name = "LBL_BuildingNo";
            this.LBL_BuildingNo.Size = new System.Drawing.Size(84, 17);
            this.LBL_BuildingNo.TabIndex = 2;
            this.LBL_BuildingNo.Text = "Building No:";
            // 
            // LBL_AreaName
            // 
            this.LBL_AreaName.AutoSize = true;
            this.LBL_AreaName.Location = new System.Drawing.Point(15, 47);
            this.LBL_AreaName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBL_AreaName.Name = "LBL_AreaName";
            this.LBL_AreaName.Size = new System.Drawing.Size(83, 17);
            this.LBL_AreaName.TabIndex = 2;
            this.LBL_AreaName.Text = "Area Name:";
            // 
            // LBL_AreaNo
            // 
            this.LBL_AreaNo.AutoSize = true;
            this.LBL_AreaNo.Location = new System.Drawing.Point(16, 14);
            this.LBL_AreaNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBL_AreaNo.Name = "LBL_AreaNo";
            this.LBL_AreaNo.Size = new System.Drawing.Size(64, 17);
            this.LBL_AreaNo.TabIndex = 2;
            this.LBL_AreaNo.Text = "Area No:";
            // 
            // sS_MaskedTextBox_AreaNo
            // 
            this.sS_MaskedTextBox_AreaNo.BackColor = System.Drawing.Color.Honeydew;
            this.sS_MaskedTextBox_AreaNo.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_AreaNo.BackColorOnLeave = System.Drawing.Color.Honeydew;
            this.sS_MaskedTextBox_AreaNo.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_AreaNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_AreaNo.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_AreaNo.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_AreaNo.IconError = null;
            this.sS_MaskedTextBox_AreaNo.IconTrue = null;
            this.sS_MaskedTextBox_AreaNo.Location = new System.Drawing.Point(160, 14);
            this.sS_MaskedTextBox_AreaNo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sS_MaskedTextBox_AreaNo.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_AreaNo.Name = "sS_MaskedTextBox_AreaNo";
            this.sS_MaskedTextBox_AreaNo.Size = new System.Drawing.Size(165, 26);
            this.sS_MaskedTextBox_AreaNo.TabIndex = 1;
            this.sS_MaskedTextBox_AreaNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.sS_MaskedTextBox_AreaNo_KeyPress);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.sS_DataGridView_Area);
            this.panel2.Location = new System.Drawing.Point(1, 206);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(585, 272);
            this.panel2.TabIndex = 5;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Highlight;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_Record});
            this.statusStrip1.Location = new System.Drawing.Point(0, 481);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(589, 27);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel_Record
            // 
            this.toolStripStatusLabel_Record.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabel_Record.Name = "toolStripStatusLabel_Record";
            this.toolStripStatusLabel_Record.Size = new System.Drawing.Size(104, 22);
            this.toolStripStatusLabel_Record.Text = "[1/All] records";
            // 
            // Form_002007_Area
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(589, 508);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel_Area);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form_002007_Area";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ID:002007(Area)";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_002007_Area_FormClosed);
            this.Activated += new System.EventHandler(this.Form_002007_Area_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_002007_Area_FormClosing);
            this.Load += new System.EventHandler(this.Form_002007_Area_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sS_DataGridView_Area)).EndInit();
            this.panel_Area.ResumeLayout(false);
            this.panel_Area.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SimatSoft.CustomControl.SS_DataGridView sS_DataGridView_Area;
        private System.Windows.Forms.Panel panel_Area;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_AreaName;
        private System.Windows.Forms.Label LBL_AreaName;
        private System.Windows.Forms.Label LBL_AreaNo;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_AreaNo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Record;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_FacilityNo;
        private System.Windows.Forms.Label LBL_CompanyNo;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_FloorNo;
        private System.Windows.Forms.Label LBL_FloorNo;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_BuildingNo;
        private System.Windows.Forms.Label LBL_BuildingNo;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_FacName;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_FloorName;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_BuildName;

    }
}