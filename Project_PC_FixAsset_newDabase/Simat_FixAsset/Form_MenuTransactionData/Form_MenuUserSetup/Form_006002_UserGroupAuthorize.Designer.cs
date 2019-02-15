namespace SimatSoft.FixAsset
{
    partial class Form_006002_UserGroupAuthorize
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
            this.sS_DataGridView_UserGroupAutolize = new SimatSoft.CustomControl.SS_DataGridView();
            this.Column6 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDiselect = new System.Windows.Forms.Button();
            this.BtnSelect = new System.Windows.Forms.Button();
            this.sS_MaskedTextBox_FacName = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.sS_MaskedTextBox_FacCode = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.sS_MaskedTextBox_GroupName = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.sS_MaskedTextBox_GroupID = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.LBL_Company = new System.Windows.Forms.Label();
            this.LBL_GroupName = new System.Windows.Forms.Label();
            this.LBL_GroupID = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_Record = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sS_DataGridView_UserGroupAutolize)).BeginInit();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.sS_DataGridView_UserGroupAutolize);
            this.panel2.Location = new System.Drawing.Point(0, 132);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(596, 255);
            this.panel2.TabIndex = 11;
            // 
            // sS_DataGridView_UserGroupAutolize
            // 
            this.sS_DataGridView_UserGroupAutolize.AllowUserToAddRows = false;
            this.sS_DataGridView_UserGroupAutolize.AllowUserToDeleteRows = false;
            this.sS_DataGridView_UserGroupAutolize.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.sS_DataGridView_UserGroupAutolize.BackColorCellFocus = System.Drawing.Color.LightBlue;
            this.sS_DataGridView_UserGroupAutolize.BackColorCellLeave = System.Drawing.Color.Honeydew;
            this.sS_DataGridView_UserGroupAutolize.BackColorRow = System.Drawing.Color.HotPink;
            this.sS_DataGridView_UserGroupAutolize.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.sS_DataGridView_UserGroupAutolize.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sS_DataGridView_UserGroupAutolize.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column6,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column5,
            this.Column4});
            this.sS_DataGridView_UserGroupAutolize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sS_DataGridView_UserGroupAutolize.Location = new System.Drawing.Point(0, 0);
            this.sS_DataGridView_UserGroupAutolize.Name = "sS_DataGridView_UserGroupAutolize";
            this.sS_DataGridView_UserGroupAutolize.Size = new System.Drawing.Size(596, 255);
            this.sS_DataGridView_UserGroupAutolize.TabIndex = 0;
            this.sS_DataGridView_UserGroupAutolize.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.sS_DataGridView_UserGroupAutolize_CellContentClick);
            // 
            // Column6
            // 
            this.Column6.HeaderText = "ScreenAccess";
            this.Column6.Name = "Column6";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ScreenID";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Screen Name";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Add";
            this.Column3.Name = "Column3";
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Delete";
            this.Column5.Name = "Column5";
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Edit";
            this.Column4.Name = "Column4";
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnDiselect);
            this.panel1.Controls.Add(this.BtnSelect);
            this.panel1.Controls.Add(this.sS_MaskedTextBox_FacName);
            this.panel1.Controls.Add(this.sS_MaskedTextBox_FacCode);
            this.panel1.Controls.Add(this.sS_MaskedTextBox_GroupName);
            this.panel1.Controls.Add(this.sS_MaskedTextBox_GroupID);
            this.panel1.Controls.Add(this.LBL_Company);
            this.panel1.Controls.Add(this.LBL_GroupName);
            this.panel1.Controls.Add(this.LBL_GroupID);
            this.panel1.Location = new System.Drawing.Point(1, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(596, 127);
            this.panel1.TabIndex = 10;
            // 
            // btnDiselect
            // 
            this.btnDiselect.Location = new System.Drawing.Point(90, 97);
            this.btnDiselect.Name = "btnDiselect";
            this.btnDiselect.Size = new System.Drawing.Size(75, 23);
            this.btnDiselect.TabIndex = 33;
            this.btnDiselect.Text = "Diselect All";
            this.btnDiselect.UseVisualStyleBackColor = true;
            this.btnDiselect.Click += new System.EventHandler(this.btnDiselect_Click);
            // 
            // BtnSelect
            // 
            this.BtnSelect.Location = new System.Drawing.Point(9, 97);
            this.BtnSelect.Name = "BtnSelect";
            this.BtnSelect.Size = new System.Drawing.Size(75, 23);
            this.BtnSelect.TabIndex = 32;
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
            this.sS_MaskedTextBox_FacName.Location = new System.Drawing.Point(257, 63);
            this.sS_MaskedTextBox_FacName.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_FacName.Name = "sS_MaskedTextBox_FacName";
            this.sS_MaskedTextBox_FacName.ReadOnly = true;
            this.sS_MaskedTextBox_FacName.Size = new System.Drawing.Size(130, 23);
            this.sS_MaskedTextBox_FacName.TabIndex = 4;
            this.sS_MaskedTextBox_FacName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sS_MaskedTextBox_FacCode_KeyDown);
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
            this.sS_MaskedTextBox_FacCode.Location = new System.Drawing.Point(128, 63);
            this.sS_MaskedTextBox_FacCode.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_FacCode.Name = "sS_MaskedTextBox_FacCode";
            this.sS_MaskedTextBox_FacCode.ReadOnly = true;
            this.sS_MaskedTextBox_FacCode.Size = new System.Drawing.Size(127, 23);
            this.sS_MaskedTextBox_FacCode.TabIndex = 3;
            this.sS_MaskedTextBox_FacCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sS_MaskedTextBox_FacCode_KeyDown);
            // 
            // sS_MaskedTextBox_GroupName
            // 
            this.sS_MaskedTextBox_GroupName.BackColor = System.Drawing.Color.Lavender;
            this.sS_MaskedTextBox_GroupName.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_GroupName.BackColorOnLeave = System.Drawing.Color.Lavender;
            this.sS_MaskedTextBox_GroupName.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_GroupName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_GroupName.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_GroupName.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_GroupName.IconError = null;
            this.sS_MaskedTextBox_GroupName.IconTrue = null;
            this.sS_MaskedTextBox_GroupName.Location = new System.Drawing.Point(128, 39);
            this.sS_MaskedTextBox_GroupName.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_GroupName.Name = "sS_MaskedTextBox_GroupName";
            this.sS_MaskedTextBox_GroupName.Size = new System.Drawing.Size(127, 23);
            this.sS_MaskedTextBox_GroupName.TabIndex = 2;
            // 
            // sS_MaskedTextBox_GroupID
            // 
            this.sS_MaskedTextBox_GroupID.BackColor = System.Drawing.Color.Honeydew;
            this.sS_MaskedTextBox_GroupID.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_GroupID.BackColorOnLeave = System.Drawing.Color.Honeydew;
            this.sS_MaskedTextBox_GroupID.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_GroupID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_GroupID.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_GroupID.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_GroupID.IconError = null;
            this.sS_MaskedTextBox_GroupID.IconTrue = null;
            this.sS_MaskedTextBox_GroupID.Location = new System.Drawing.Point(128, 15);
            this.sS_MaskedTextBox_GroupID.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_GroupID.Name = "sS_MaskedTextBox_GroupID";
            this.sS_MaskedTextBox_GroupID.Size = new System.Drawing.Size(127, 23);
            this.sS_MaskedTextBox_GroupID.TabIndex = 1;
            this.sS_MaskedTextBox_GroupID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sS_MaskedTextBox_GroupID_KeyDown);
            // 
            // LBL_Company
            // 
            this.LBL_Company.AutoSize = true;
            this.LBL_Company.ForeColor = System.Drawing.Color.Maroon;
            this.LBL_Company.Location = new System.Drawing.Point(45, 63);
            this.LBL_Company.Name = "LBL_Company";
            this.LBL_Company.Size = new System.Drawing.Size(54, 13);
            this.LBL_Company.TabIndex = 0;
            this.LBL_Company.Text = "Company:";
            // 
            // LBL_GroupName
            // 
            this.LBL_GroupName.AutoSize = true;
            this.LBL_GroupName.Location = new System.Drawing.Point(45, 39);
            this.LBL_GroupName.Name = "LBL_GroupName";
            this.LBL_GroupName.Size = new System.Drawing.Size(70, 13);
            this.LBL_GroupName.TabIndex = 0;
            this.LBL_GroupName.Text = "Group Name:";
            // 
            // LBL_GroupID
            // 
            this.LBL_GroupID.AutoSize = true;
            this.LBL_GroupID.Location = new System.Drawing.Point(45, 15);
            this.LBL_GroupID.Name = "LBL_GroupID";
            this.LBL_GroupID.Size = new System.Drawing.Size(53, 13);
            this.LBL_GroupID.TabIndex = 0;
            this.LBL_GroupID.Text = "Group ID:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_Record});
            this.statusStrip1.Location = new System.Drawing.Point(0, 390);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(599, 22);
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
            // Form_006002_UserGroupAuthorize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(210)))), ((int)(((byte)(238)))));
            this.ClientSize = new System.Drawing.Size(599, 412);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form_006002_UserGroupAuthorize";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ID:006002(UserGroup Autorize)";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_006002_UserGroupAutolize_FormClosed);
            this.Activated += new System.EventHandler(this.Form_006002_UserGroupAuthorize_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_006002_UserGroupAuthorize_FormClosing);
            this.Load += new System.EventHandler(this.Form_006002_UserGroupAutolize_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sS_DataGridView_UserGroupAutolize)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private SimatSoft.CustomControl.SS_DataGridView sS_DataGridView_UserGroupAutolize;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Record;
        private System.Windows.Forms.Label LBL_GroupName;
        private System.Windows.Forms.Label LBL_GroupID;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_FacCode;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_GroupName;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_GroupID;
        private System.Windows.Forms.Label LBL_Company;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_FacName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column5;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column4;
        private System.Windows.Forms.Button btnDiselect;
        private System.Windows.Forms.Button BtnSelect;
    }
}