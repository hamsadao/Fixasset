namespace SimatSoft.FixAsset
{
    partial class Form_006001_UserAuthorize
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
            this.sS_DataGridView_UserAutolize = new SimatSoft.CustomControl.SS_DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDiselect = new System.Windows.Forms.Button();
            this.BtnSelect = new System.Windows.Forms.Button();
            this.sS_MaskedTextBox_FacName = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.sS_MaskedTextBox_DeptName = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.sS_MaskedTextBox_GroupName = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.sS_MaskedTextBox_FacCode = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.sS_MaskedTextBox_DeptNo = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.sS_MaskedTextBox_Group = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.sS_MaskedTextBox_Password = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.sS_MaskedTextBox_LastName = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.sS_MaskedTextBox_FirstName = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.sS_MaskedTextBox_UserID = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.LBL_Company = new System.Windows.Forms.Label();
            this.LBL_Department = new System.Windows.Forms.Label();
            this.LBL_Group = new System.Windows.Forms.Label();
            this.LBL_Password = new System.Windows.Forms.Label();
            this.LBL_Lastname = new System.Windows.Forms.Label();
            this.LBL_FirstName = new System.Windows.Forms.Label();
            this.LBL_UserID = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_Record = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sS_DataGridView_UserAutolize)).BeginInit();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.sS_DataGridView_UserAutolize);
            this.panel2.Location = new System.Drawing.Point(2, 210);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(639, 280);
            this.panel2.TabIndex = 11;
            // 
            // sS_DataGridView_UserAutolize
            // 
            this.sS_DataGridView_UserAutolize.AllowUserToAddRows = false;
            this.sS_DataGridView_UserAutolize.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.sS_DataGridView_UserAutolize.BackColorCellFocus = System.Drawing.Color.LightBlue;
            this.sS_DataGridView_UserAutolize.BackColorCellLeave = System.Drawing.Color.Honeydew;
            this.sS_DataGridView_UserAutolize.BackColorRow = System.Drawing.Color.HotPink;
            this.sS_DataGridView_UserAutolize.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.sS_DataGridView_UserAutolize.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sS_DataGridView_UserAutolize.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.sS_DataGridView_UserAutolize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sS_DataGridView_UserAutolize.Location = new System.Drawing.Point(0, 0);
            this.sS_DataGridView_UserAutolize.Name = "sS_DataGridView_UserAutolize";
            this.sS_DataGridView_UserAutolize.Size = new System.Drawing.Size(639, 280);
            this.sS_DataGridView_UserAutolize.TabIndex = 0;
            this.sS_DataGridView_UserAutolize.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.sS_DataGridView_UserAutolize_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ScreenAccess";
            this.Column1.Name = "Column1";
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "ScreenID";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "ScreenName";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Add";
            this.Column4.Name = "Column4";
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Delete";
            this.Column5.Name = "Column5";
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Edit";
            this.Column6.Name = "Column6";
            this.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnDiselect);
            this.panel1.Controls.Add(this.BtnSelect);
            this.panel1.Controls.Add(this.sS_MaskedTextBox_FacName);
            this.panel1.Controls.Add(this.sS_MaskedTextBox_DeptName);
            this.panel1.Controls.Add(this.sS_MaskedTextBox_GroupName);
            this.panel1.Controls.Add(this.sS_MaskedTextBox_FacCode);
            this.panel1.Controls.Add(this.sS_MaskedTextBox_DeptNo);
            this.panel1.Controls.Add(this.sS_MaskedTextBox_Group);
            this.panel1.Controls.Add(this.sS_MaskedTextBox_Password);
            this.panel1.Controls.Add(this.sS_MaskedTextBox_LastName);
            this.panel1.Controls.Add(this.sS_MaskedTextBox_FirstName);
            this.panel1.Controls.Add(this.sS_MaskedTextBox_UserID);
            this.panel1.Controls.Add(this.LBL_Company);
            this.panel1.Controls.Add(this.LBL_Department);
            this.panel1.Controls.Add(this.LBL_Group);
            this.panel1.Controls.Add(this.LBL_Password);
            this.panel1.Controls.Add(this.LBL_Lastname);
            this.panel1.Controls.Add(this.LBL_FirstName);
            this.panel1.Controls.Add(this.LBL_UserID);
            this.panel1.Location = new System.Drawing.Point(1, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(639, 214);
            this.panel1.TabIndex = 10;
            // 
            // btnDiselect
            // 
            this.btnDiselect.Location = new System.Drawing.Point(86, 183);
            this.btnDiselect.Name = "btnDiselect";
            this.btnDiselect.Size = new System.Drawing.Size(75, 23);
            this.btnDiselect.TabIndex = 31;
            this.btnDiselect.Text = "Diselect All";
            this.btnDiselect.UseVisualStyleBackColor = true;
            this.btnDiselect.Click += new System.EventHandler(this.btnDiselect_Click);
            // 
            // BtnSelect
            // 
            this.BtnSelect.Location = new System.Drawing.Point(5, 183);
            this.BtnSelect.Name = "BtnSelect";
            this.BtnSelect.Size = new System.Drawing.Size(75, 23);
            this.BtnSelect.TabIndex = 30;
            this.BtnSelect.Text = "Select All";
            this.BtnSelect.UseVisualStyleBackColor = true;
            this.BtnSelect.Click += new System.EventHandler(this.BtnSelect_Click);
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
            this.sS_MaskedTextBox_FacName.Location = new System.Drawing.Point(290, 152);
            this.sS_MaskedTextBox_FacName.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_FacName.Name = "sS_MaskedTextBox_FacName";
            this.sS_MaskedTextBox_FacName.ReadOnly = true;
            this.sS_MaskedTextBox_FacName.Size = new System.Drawing.Size(129, 23);
            this.sS_MaskedTextBox_FacName.TabIndex = 10;
            this.sS_MaskedTextBox_FacName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sS_MaskedTextBox_FacCode_KeyDown);
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
            this.sS_MaskedTextBox_DeptName.Location = new System.Drawing.Point(290, 128);
            this.sS_MaskedTextBox_DeptName.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_DeptName.Name = "sS_MaskedTextBox_DeptName";
            this.sS_MaskedTextBox_DeptName.ReadOnly = true;
            this.sS_MaskedTextBox_DeptName.Size = new System.Drawing.Size(129, 23);
            this.sS_MaskedTextBox_DeptName.TabIndex = 9;
            this.sS_MaskedTextBox_DeptName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sS_MaskedTextBox_DeptNo_KeyDown);
            // 
            // sS_MaskedTextBox_GroupName
            // 
            this.sS_MaskedTextBox_GroupName.BackColor = System.Drawing.Color.LightCyan;
            this.sS_MaskedTextBox_GroupName.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_GroupName.BackColorOnLeave = System.Drawing.Color.LightCyan;
            this.sS_MaskedTextBox_GroupName.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_GroupName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_GroupName.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_GroupName.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_GroupName.IconError = null;
            this.sS_MaskedTextBox_GroupName.IconTrue = null;
            this.sS_MaskedTextBox_GroupName.Location = new System.Drawing.Point(290, 104);
            this.sS_MaskedTextBox_GroupName.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_GroupName.Name = "sS_MaskedTextBox_GroupName";
            this.sS_MaskedTextBox_GroupName.ReadOnly = true;
            this.sS_MaskedTextBox_GroupName.Size = new System.Drawing.Size(129, 23);
            this.sS_MaskedTextBox_GroupName.TabIndex = 8;
            this.sS_MaskedTextBox_GroupName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sS_MaskedTextBox_Group_KeyDown);
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
            this.sS_MaskedTextBox_FacCode.Location = new System.Drawing.Point(157, 152);
            this.sS_MaskedTextBox_FacCode.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_FacCode.Name = "sS_MaskedTextBox_FacCode";
            this.sS_MaskedTextBox_FacCode.ReadOnly = true;
            this.sS_MaskedTextBox_FacCode.Size = new System.Drawing.Size(127, 23);
            this.sS_MaskedTextBox_FacCode.TabIndex = 7;
            this.sS_MaskedTextBox_FacCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sS_MaskedTextBox_FacCode_KeyDown);
            // 
            // sS_MaskedTextBox_DeptNo
            // 
            this.sS_MaskedTextBox_DeptNo.BackColor = System.Drawing.Color.Lavender;
            this.sS_MaskedTextBox_DeptNo.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_DeptNo.BackColorOnLeave = System.Drawing.Color.Lavender;
            this.sS_MaskedTextBox_DeptNo.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_DeptNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_DeptNo.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_DeptNo.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_DeptNo.IconError = null;
            this.sS_MaskedTextBox_DeptNo.IconTrue = null;
            this.sS_MaskedTextBox_DeptNo.Location = new System.Drawing.Point(157, 128);
            this.sS_MaskedTextBox_DeptNo.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_DeptNo.Name = "sS_MaskedTextBox_DeptNo";
            this.sS_MaskedTextBox_DeptNo.ReadOnly = true;
            this.sS_MaskedTextBox_DeptNo.Size = new System.Drawing.Size(127, 23);
            this.sS_MaskedTextBox_DeptNo.TabIndex = 6;
            this.sS_MaskedTextBox_DeptNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sS_MaskedTextBox_DeptNo_KeyDown);
            // 
            // sS_MaskedTextBox_Group
            // 
            this.sS_MaskedTextBox_Group.BackColor = System.Drawing.Color.Lavender;
            this.sS_MaskedTextBox_Group.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_Group.BackColorOnLeave = System.Drawing.Color.Lavender;
            this.sS_MaskedTextBox_Group.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_Group.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_Group.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_Group.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_Group.IconError = null;
            this.sS_MaskedTextBox_Group.IconTrue = null;
            this.sS_MaskedTextBox_Group.Location = new System.Drawing.Point(157, 104);
            this.sS_MaskedTextBox_Group.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_Group.Name = "sS_MaskedTextBox_Group";
            this.sS_MaskedTextBox_Group.ReadOnly = true;
            this.sS_MaskedTextBox_Group.Size = new System.Drawing.Size(127, 23);
            this.sS_MaskedTextBox_Group.TabIndex = 5;
            this.sS_MaskedTextBox_Group.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sS_MaskedTextBox_Group_KeyDown);
            // 
            // sS_MaskedTextBox_Password
            // 
            this.sS_MaskedTextBox_Password.BackColor = System.Drawing.Color.Honeydew;
            this.sS_MaskedTextBox_Password.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_Password.BackColorOnLeave = System.Drawing.Color.Honeydew;
            this.sS_MaskedTextBox_Password.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_Password.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_Password.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_Password.IconError = null;
            this.sS_MaskedTextBox_Password.IconTrue = null;
            this.sS_MaskedTextBox_Password.Location = new System.Drawing.Point(157, 80);
            this.sS_MaskedTextBox_Password.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_Password.Name = "sS_MaskedTextBox_Password";
            this.sS_MaskedTextBox_Password.Size = new System.Drawing.Size(127, 23);
            this.sS_MaskedTextBox_Password.TabIndex = 4;
            // 
            // sS_MaskedTextBox_LastName
            // 
            this.sS_MaskedTextBox_LastName.BackColor = System.Drawing.Color.Lavender;
            this.sS_MaskedTextBox_LastName.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_LastName.BackColorOnLeave = System.Drawing.Color.Lavender;
            this.sS_MaskedTextBox_LastName.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_LastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_LastName.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_LastName.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_LastName.IconError = null;
            this.sS_MaskedTextBox_LastName.IconTrue = null;
            this.sS_MaskedTextBox_LastName.Location = new System.Drawing.Point(157, 56);
            this.sS_MaskedTextBox_LastName.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_LastName.Name = "sS_MaskedTextBox_LastName";
            this.sS_MaskedTextBox_LastName.Size = new System.Drawing.Size(262, 23);
            this.sS_MaskedTextBox_LastName.TabIndex = 3;
            // 
            // sS_MaskedTextBox_FirstName
            // 
            this.sS_MaskedTextBox_FirstName.BackColor = System.Drawing.Color.Lavender;
            this.sS_MaskedTextBox_FirstName.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_FirstName.BackColorOnLeave = System.Drawing.Color.Lavender;
            this.sS_MaskedTextBox_FirstName.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_FirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_FirstName.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_FirstName.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_FirstName.IconError = null;
            this.sS_MaskedTextBox_FirstName.IconTrue = null;
            this.sS_MaskedTextBox_FirstName.Location = new System.Drawing.Point(157, 32);
            this.sS_MaskedTextBox_FirstName.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_FirstName.Name = "sS_MaskedTextBox_FirstName";
            this.sS_MaskedTextBox_FirstName.Size = new System.Drawing.Size(262, 23);
            this.sS_MaskedTextBox_FirstName.TabIndex = 2;
            // 
            // sS_MaskedTextBox_UserID
            // 
            this.sS_MaskedTextBox_UserID.BackColor = System.Drawing.Color.Honeydew;
            this.sS_MaskedTextBox_UserID.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_UserID.BackColorOnLeave = System.Drawing.Color.Honeydew;
            this.sS_MaskedTextBox_UserID.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_UserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_UserID.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_UserID.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_UserID.IconError = null;
            this.sS_MaskedTextBox_UserID.IconTrue = null;
            this.sS_MaskedTextBox_UserID.Location = new System.Drawing.Point(157, 8);
            this.sS_MaskedTextBox_UserID.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_UserID.Name = "sS_MaskedTextBox_UserID";
            this.sS_MaskedTextBox_UserID.Size = new System.Drawing.Size(127, 23);
            this.sS_MaskedTextBox_UserID.TabIndex = 1;
            this.sS_MaskedTextBox_UserID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sS_MaskedTextBox_UserID_KeyDown);
            // 
            // LBL_Company
            // 
            this.LBL_Company.AutoSize = true;
            this.LBL_Company.ForeColor = System.Drawing.Color.Black;
            this.LBL_Company.Location = new System.Drawing.Point(71, 152);
            this.LBL_Company.Name = "LBL_Company";
            this.LBL_Company.Size = new System.Drawing.Size(54, 13);
            this.LBL_Company.TabIndex = 0;
            this.LBL_Company.Text = "Company:";
            // 
            // LBL_Department
            // 
            this.LBL_Department.AutoSize = true;
            this.LBL_Department.Location = new System.Drawing.Point(71, 128);
            this.LBL_Department.Name = "LBL_Department";
            this.LBL_Department.Size = new System.Drawing.Size(65, 13);
            this.LBL_Department.TabIndex = 0;
            this.LBL_Department.Text = "Department:";
            // 
            // LBL_Group
            // 
            this.LBL_Group.AutoSize = true;
            this.LBL_Group.Location = new System.Drawing.Point(71, 104);
            this.LBL_Group.Name = "LBL_Group";
            this.LBL_Group.Size = new System.Drawing.Size(39, 13);
            this.LBL_Group.TabIndex = 0;
            this.LBL_Group.Text = "Group:";
            // 
            // LBL_Password
            // 
            this.LBL_Password.AutoSize = true;
            this.LBL_Password.Location = new System.Drawing.Point(71, 80);
            this.LBL_Password.Name = "LBL_Password";
            this.LBL_Password.Size = new System.Drawing.Size(56, 13);
            this.LBL_Password.TabIndex = 0;
            this.LBL_Password.Text = "Password:";
            // 
            // LBL_Lastname
            // 
            this.LBL_Lastname.AutoSize = true;
            this.LBL_Lastname.Location = new System.Drawing.Point(71, 56);
            this.LBL_Lastname.Name = "LBL_Lastname";
            this.LBL_Lastname.Size = new System.Drawing.Size(61, 13);
            this.LBL_Lastname.TabIndex = 0;
            this.LBL_Lastname.Text = "Last Name:";
            // 
            // LBL_FirstName
            // 
            this.LBL_FirstName.AutoSize = true;
            this.LBL_FirstName.Location = new System.Drawing.Point(71, 32);
            this.LBL_FirstName.Name = "LBL_FirstName";
            this.LBL_FirstName.Size = new System.Drawing.Size(60, 13);
            this.LBL_FirstName.TabIndex = 0;
            this.LBL_FirstName.Text = "First Name:";
            // 
            // LBL_UserID
            // 
            this.LBL_UserID.AutoSize = true;
            this.LBL_UserID.Location = new System.Drawing.Point(71, 8);
            this.LBL_UserID.Name = "LBL_UserID";
            this.LBL_UserID.Size = new System.Drawing.Size(46, 13);
            this.LBL_UserID.TabIndex = 0;
            this.LBL_UserID.Text = "User ID:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_Record});
            this.statusStrip1.Location = new System.Drawing.Point(0, 493);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(642, 22);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel_Record
            // 
            this.toolStripStatusLabel_Record.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabel_Record.Name = "toolStripStatusLabel_Record";
            this.toolStripStatusLabel_Record.Size = new System.Drawing.Size(79, 17);
            this.toolStripStatusLabel_Record.Text = "[1/All] records";
            // 
            // Form_006001_UserAuthorize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(210)))), ((int)(((byte)(238)))));
            this.ClientSize = new System.Drawing.Size(642, 515);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form_006001_UserAuthorize";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ID:006001(User Autolize)";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_006001_UserAutolize_FormClosed);
            this.Activated += new System.EventHandler(this.Form_006001_UserAuthorize_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_006001_UserAuthorize_FormClosing);
            this.Load += new System.EventHandler(this.Form_006001_UserAutolize_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sS_DataGridView_UserAutolize)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private SimatSoft.CustomControl.SS_DataGridView sS_DataGridView_UserAutolize;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Record;
        private System.Windows.Forms.Label LBL_FirstName;
        private System.Windows.Forms.Label LBL_UserID;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_FacName;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_DeptName;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_GroupName;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_FacCode;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_DeptNo;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_Group;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_Password;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_LastName;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_FirstName;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_UserID;
        private System.Windows.Forms.Label LBL_Company;
        private System.Windows.Forms.Label LBL_Department;
        private System.Windows.Forms.Label LBL_Group;
        private System.Windows.Forms.Label LBL_Password;
        private System.Windows.Forms.Label LBL_Lastname;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column5;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column6;
        private System.Windows.Forms.Button btnDiselect;
        private System.Windows.Forms.Button BtnSelect;
    }
}