namespace SimatSoft.FixAsset
{
    partial class Form_005009_Barcode
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_005009_Barcode));
            this.ln_assetno = new System.Windows.Forms.Label();
            this.ln_assetName = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.BarcodeX1 = new AxBARCODEXLib.AxBarcodeX();
            this.Date = new System.Windows.Forms.Label();
            this.Depart = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.BarcodeX1)).BeginInit();
            this.SuspendLayout();
            // 
            // ln_assetno
            // 
            this.ln_assetno.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ln_assetno.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ln_assetno.Location = new System.Drawing.Point(3, 50);
            this.ln_assetno.Margin = new System.Windows.Forms.Padding(0);
            this.ln_assetno.Name = "ln_assetno";
            this.ln_assetno.Size = new System.Drawing.Size(139, 20);
            this.ln_assetno.TabIndex = 26;
            this.ln_assetno.Text = "..";
            this.ln_assetno.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ln_assetno.UseWaitCursor = true;
            // 
            // ln_assetName
            // 
            this.ln_assetName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ln_assetName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ln_assetName.Location = new System.Drawing.Point(2, 32);
            this.ln_assetName.Margin = new System.Windows.Forms.Padding(0);
            this.ln_assetName.Name = "ln_assetName";
            this.ln_assetName.Size = new System.Drawing.Size(156, 17);
            this.ln_assetName.TabIndex = 25;
            this.ln_assetName.Text = "..";
            this.ln_assetName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ln_assetName.UseWaitCursor = true;
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // printDocument
            // 
            this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument_PrintPage);
            // 
            // BarcodeX1
            // 
            this.BarcodeX1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.BarcodeX1.Enabled = true;
            this.BarcodeX1.Location = new System.Drawing.Point(0, 87);
            this.BarcodeX1.Margin = new System.Windows.Forms.Padding(0);
            this.BarcodeX1.Name = "BarcodeX1";
            this.BarcodeX1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("BarcodeX1.OcxState")));
            this.BarcodeX1.Size = new System.Drawing.Size(189, 25);
            this.BarcodeX1.TabIndex = 29;
            this.BarcodeX1.UseWaitCursor = true;
            this.BarcodeX1.Enter += new System.EventHandler(this.BarcodeX1_Enter);
            // 
            // Date
            // 
            this.Date.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Date.AutoSize = true;
            this.Date.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Date.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Date.Location = new System.Drawing.Point(84, 18);
            this.Date.Name = "Date";
            this.Date.Size = new System.Drawing.Size(23, 9);
            this.Date.TabIndex = 30;
            this.Date.Text = ".........";
            this.Date.UseWaitCursor = true;
            this.Date.Click += new System.EventHandler(this.label1_Click);
            // 
            // Depart
            // 
            this.Depart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Depart.AutoSize = true;
            this.Depart.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Depart.Location = new System.Drawing.Point(47, 18);
            this.Depart.Name = "Depart";
            this.Depart.Size = new System.Drawing.Size(23, 9);
            this.Depart.TabIndex = 31;
            this.Depart.Text = ".........";
            this.Depart.UseWaitCursor = true;
            // 
            // Form_005009_Barcode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(159, 98);
            this.ControlBox = false;
            this.Controls.Add(this.Depart);
            this.Controls.Add(this.Date);
            this.Controls.Add(this.BarcodeX1);
            this.Controls.Add(this.ln_assetno);
            this.Controls.Add(this.ln_assetName);
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form_005009_Barcode";
            this.TransparencyKey = System.Drawing.Color.Black;
            this.UseWaitCursor = true;
            this.Load += new System.EventHandler(this.Form_005009_Barcode_Load);
            this.Activated += new System.EventHandler(this.Form_005009_Barcode_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.BarcodeX1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ln_assetno;
        private System.Windows.Forms.Label ln_assetName;
        public System.Windows.Forms.Timer timer;
        private System.Drawing.Printing.PrintDocument printDocument;
        public AxBARCODEXLib.AxBarcodeX BarcodeX1;
        private System.Windows.Forms.Label Date;
        private System.Windows.Forms.Label Depart;
    }
}