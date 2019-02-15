namespace SimatSoft.FixAsset
{
    partial class Form_005004_Barcode_Building
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
            this.label_Remark = new System.Windows.Forms.Label();
            this.sS_DataGridView_BarcodeBuild = new SimatSoft.CustomControl.SS_DataGridView();
            this.sS_MaskedTextBox_Remark = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.sS_MaskedTextBox_BuildID = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.label_BuildID = new System.Windows.Forms.Label();
            this.sS_MaskedTextBox_BuildName = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.sS_ButtonGlass1 = new SimatSoft.CustomControl.SS_ButtonGlass();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sS_DataGridView_BarcodeBuild)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label_Remark);
            this.panel2.Controls.Add(this.sS_DataGridView_BarcodeBuild);
            this.panel2.Controls.Add(this.sS_MaskedTextBox_Remark);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 88);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(463, 0);
            this.panel2.TabIndex = 1;
            // 
            // label_Remark
            // 
            this.label_Remark.AutoSize = true;
            this.label_Remark.Location = new System.Drawing.Point(27, 53);
            this.label_Remark.Name = "label_Remark";
            this.label_Remark.Size = new System.Drawing.Size(61, 17);
            this.label_Remark.TabIndex = 11;
            this.label_Remark.Text = "Remark:";
            this.label_Remark.Visible = false;
            // 
            // sS_DataGridView_BarcodeBuild
            // 
            this.sS_DataGridView_BarcodeBuild.AllowUserToAddRows = false;
            this.sS_DataGridView_BarcodeBuild.BackColorCellFocus = System.Drawing.Color.LightBlue;
            this.sS_DataGridView_BarcodeBuild.BackColorCellLeave = System.Drawing.Color.Honeydew;
            this.sS_DataGridView_BarcodeBuild.BackColorRow = System.Drawing.Color.HotPink;
            this.sS_DataGridView_BarcodeBuild.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sS_DataGridView_BarcodeBuild.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sS_DataGridView_BarcodeBuild.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sS_DataGridView_BarcodeBuild.Location = new System.Drawing.Point(0, 0);
            this.sS_DataGridView_BarcodeBuild.Name = "sS_DataGridView_BarcodeBuild";
            this.sS_DataGridView_BarcodeBuild.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.sS_DataGridView_BarcodeBuild.Size = new System.Drawing.Size(463, 0);
            this.sS_DataGridView_BarcodeBuild.TabIndex = 0;
            this.sS_DataGridView_BarcodeBuild.Visible = false;
            this.sS_DataGridView_BarcodeBuild.Click += new System.EventHandler(this.sS_DataGridView_BarcodeBuild_Click);
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
            this.sS_MaskedTextBox_Remark.Location = new System.Drawing.Point(106, 43);
            this.sS_MaskedTextBox_Remark.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_Remark.Name = "sS_MaskedTextBox_Remark";
            this.sS_MaskedTextBox_Remark.Size = new System.Drawing.Size(312, 26);
            this.sS_MaskedTextBox_Remark.TabIndex = 10;
            this.sS_MaskedTextBox_Remark.Visible = false;
            // 
            // sS_MaskedTextBox_BuildID
            // 
            this.sS_MaskedTextBox_BuildID.BackColor = System.Drawing.Color.Honeydew;
            this.sS_MaskedTextBox_BuildID.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_BuildID.BackColorOnLeave = System.Drawing.Color.Honeydew;
            this.sS_MaskedTextBox_BuildID.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_BuildID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_BuildID.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_BuildID.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_BuildID.IconError = null;
            this.sS_MaskedTextBox_BuildID.IconTrue = null;
            this.sS_MaskedTextBox_BuildID.Location = new System.Drawing.Point(106, 20);
            this.sS_MaskedTextBox_BuildID.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_BuildID.Name = "sS_MaskedTextBox_BuildID";
            this.sS_MaskedTextBox_BuildID.ReadOnly = true;
            this.sS_MaskedTextBox_BuildID.Size = new System.Drawing.Size(240, 26);
            this.sS_MaskedTextBox_BuildID.TabIndex = 7;
            this.sS_MaskedTextBox_BuildID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sS_MaskedTextBox_AssetID_KeyDown);
            // 
            // label_BuildID
            // 
            this.label_BuildID.AutoSize = true;
            this.label_BuildID.Location = new System.Drawing.Point(10, 25);
            this.label_BuildID.Name = "label_BuildID";
            this.label_BuildID.Size = new System.Drawing.Size(65, 17);
            this.label_BuildID.TabIndex = 9;
            this.label_BuildID.Text = "Build No:";
            // 
            // sS_MaskedTextBox_BuildName
            // 
            this.sS_MaskedTextBox_BuildName.BackColor = System.Drawing.Color.LightCyan;
            this.sS_MaskedTextBox_BuildName.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_BuildName.BackColorOnLeave = System.Drawing.Color.Honeydew;
            this.sS_MaskedTextBox_BuildName.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_BuildName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_BuildName.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_BuildName.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_BuildName.IconError = null;
            this.sS_MaskedTextBox_BuildName.IconTrue = null;
            this.sS_MaskedTextBox_BuildName.Location = new System.Drawing.Point(106, 49);
            this.sS_MaskedTextBox_BuildName.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_BuildName.Name = "sS_MaskedTextBox_BuildName";
            this.sS_MaskedTextBox_BuildName.ReadOnly = true;
            this.sS_MaskedTextBox_BuildName.Size = new System.Drawing.Size(340, 26);
            this.sS_MaskedTextBox_BuildName.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.sS_ButtonGlass1);
            this.panel1.Controls.Add(this.sS_MaskedTextBox_BuildName);
            this.panel1.Controls.Add(this.label_BuildID);
            this.panel1.Controls.Add(this.sS_MaskedTextBox_BuildID);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(463, 88);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 17);
            this.label1.TabIndex = 45;
            this.label1.Text = "Build Name:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // sS_ButtonGlass1
            // 
            this.sS_ButtonGlass1.Location = new System.Drawing.Point(352, 20);
            this.sS_ButtonGlass1.Name = "sS_ButtonGlass1";
            this.sS_ButtonGlass1.Size = new System.Drawing.Size(94, 23);
            this.sS_ButtonGlass1.TabIndex = 44;
            this.sS_ButtonGlass1.Text = "Print Barcode";
            this.sS_ButtonGlass1.Click += new System.EventHandler(this.sS_ButtonGlass1_Click);
            // 
            // Form_005004_Barcode_Building
            // 
            this.ClientSize = new System.Drawing.Size(463, 86);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form_005004_Barcode_Building";
            this.Text = "ID:005004(Barcode Building)";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_005001_Barcode_Asset_FormClosed);
            this.Activated += new System.EventHandler(this.Form_005001_Barcode_Asset_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_005004_Barcode_Building_FormClosing);
            this.Load += new System.EventHandler(this.Form_005001_Barcode_Asset_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sS_DataGridView_BarcodeBuild)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_BuildID;
        private System.Windows.Forms.Label label_BuildID;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_BuildName;
        private System.Windows.Forms.Panel panel1;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_Remark;
        private System.Windows.Forms.Label label_Remark;
        private SimatSoft.CustomControl.SS_DataGridView sS_DataGridView_BarcodeBuild;
        private System.Windows.Forms.Label label1;
        private SimatSoft.CustomControl.SS_ButtonGlass sS_ButtonGlass1;

    }
}