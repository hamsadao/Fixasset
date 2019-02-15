namespace SimatSoft.FixAsset
{
    partial class Form_003004_Detail
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
            this.sS_DataGridView_Detail = new SimatSoft.CustomControl.SS_DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.sS_DataGridView_SubDetail = new SimatSoft.CustomControl.SS_DataGridView();
            this.panel_PurchaseOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sS_DataGridView_Detail)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sS_DataGridView_SubDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_PurchaseOrder
            // 
            this.panel_PurchaseOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_PurchaseOrder.BackColor = System.Drawing.Color.Transparent;
            this.panel_PurchaseOrder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_PurchaseOrder.Controls.Add(this.sS_DataGridView_Detail);
            this.panel_PurchaseOrder.Location = new System.Drawing.Point(-2, 0);
            this.panel_PurchaseOrder.Name = "panel_PurchaseOrder";
            this.panel_PurchaseOrder.Size = new System.Drawing.Size(684, 220);
            this.panel_PurchaseOrder.TabIndex = 5;
            // 
            // sS_DataGridView_Detail
            // 
            this.sS_DataGridView_Detail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.sS_DataGridView_Detail.BackColorCellFocus = System.Drawing.Color.LightBlue;
            this.sS_DataGridView_Detail.BackColorCellLeave = System.Drawing.Color.Honeydew;
            this.sS_DataGridView_Detail.BackColorRow = System.Drawing.Color.HotPink;
            this.sS_DataGridView_Detail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sS_DataGridView_Detail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sS_DataGridView_Detail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sS_DataGridView_Detail.Location = new System.Drawing.Point(0, 0);
            this.sS_DataGridView_Detail.Name = "sS_DataGridView_Detail";
            this.sS_DataGridView_Detail.Size = new System.Drawing.Size(680, 216);
            this.sS_DataGridView_Detail.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.sS_DataGridView_SubDetail);
            this.panel1.Location = new System.Drawing.Point(0, 236);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(684, 266);
            this.panel1.TabIndex = 6;
            // 
            // sS_DataGridView_SubDetail
            // 
            this.sS_DataGridView_SubDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.sS_DataGridView_SubDetail.BackColorCellFocus = System.Drawing.Color.LightBlue;
            this.sS_DataGridView_SubDetail.BackColorCellLeave = System.Drawing.Color.Honeydew;
            this.sS_DataGridView_SubDetail.BackColorRow = System.Drawing.Color.HotPink;
            this.sS_DataGridView_SubDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sS_DataGridView_SubDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sS_DataGridView_SubDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sS_DataGridView_SubDetail.Location = new System.Drawing.Point(0, 0);
            this.sS_DataGridView_SubDetail.Name = "sS_DataGridView_SubDetail";
            this.sS_DataGridView_SubDetail.Size = new System.Drawing.Size(680, 262);
            this.sS_DataGridView_SubDetail.TabIndex = 1;
            // 
            // Form_003004_Detail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 500);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel_PurchaseOrder);
            this.Name = "Form_003004_Detail";
            this.Text = "[Form_Detail]";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_003004_Detail_FormClosed);
            this.Load += new System.EventHandler(this.Form_003004_Detail_Load);
            this.panel_PurchaseOrder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sS_DataGridView_Detail)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sS_DataGridView_SubDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_PurchaseOrder;
        private SimatSoft.CustomControl.SS_DataGridView sS_DataGridView_Detail;
        private System.Windows.Forms.Panel panel1;
        private SimatSoft.CustomControl.SS_DataGridView sS_DataGridView_SubDetail;
    }
}