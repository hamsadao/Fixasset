namespace SimatSoft.FixAsset
{
    partial class Form_001011_Search
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
            this.sS_DataGridView_Search = new SimatSoft.CustomControl.SS_DataGridView();
            this.panel_PurchaseOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sS_DataGridView_Search)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_PurchaseOrder
            // 
            this.panel_PurchaseOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_PurchaseOrder.BackColor = System.Drawing.Color.Transparent;
            this.panel_PurchaseOrder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_PurchaseOrder.Controls.Add(this.sS_DataGridView_Search);
            this.panel_PurchaseOrder.Location = new System.Drawing.Point(-3, 0);
            this.panel_PurchaseOrder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel_PurchaseOrder.Name = "panel_PurchaseOrder";
            this.panel_PurchaseOrder.Size = new System.Drawing.Size(1139, 603);
            this.panel_PurchaseOrder.TabIndex = 5;
            // 
            // sS_DataGridView_Search
            // 
            this.sS_DataGridView_Search.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.sS_DataGridView_Search.BackColorCellFocus = System.Drawing.Color.LightBlue;
            this.sS_DataGridView_Search.BackColorCellLeave = System.Drawing.Color.Honeydew;
            this.sS_DataGridView_Search.BackColorRow = System.Drawing.Color.HotPink;
            this.sS_DataGridView_Search.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sS_DataGridView_Search.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sS_DataGridView_Search.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sS_DataGridView_Search.Location = new System.Drawing.Point(0, 0);
            this.sS_DataGridView_Search.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sS_DataGridView_Search.Name = "sS_DataGridView_Search";
            this.sS_DataGridView_Search.RowTemplate.Height = 24;
            this.sS_DataGridView_Search.Size = new System.Drawing.Size(1135, 599);
            this.sS_DataGridView_Search.TabIndex = 1;
            this.sS_DataGridView_Search.DoubleClick += new System.EventHandler(this.sS_DataGridView_Search_DoubleClick);
            // 
            // Form_001011_Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 604);
            this.Controls.Add(this.panel_PurchaseOrder);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form_001011_Search";
            this.Text = "Form_001011_Search";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_003002_SearchPO_FormClosed);
            this.Load += new System.EventHandler(this.Form_003002_SearchPO_Load);
            this.panel_PurchaseOrder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sS_DataGridView_Search)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_PurchaseOrder;
        private SimatSoft.CustomControl.SS_DataGridView sS_DataGridView_Search;
    }
}