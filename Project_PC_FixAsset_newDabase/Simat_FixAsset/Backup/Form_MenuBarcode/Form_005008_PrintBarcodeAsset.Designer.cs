namespace SimatSoft.FixAsset
{
    partial class Form_005008_PrintBarcodeAsset
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_005008_PrintBarcodeAsset));
            this.BarcodeX1 = new AxBARCODEXLib.AxBarcodeX();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.lb_name = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lb_Code = new System.Windows.Forms.Label();
            this.ln_assetName = new System.Windows.Forms.Label();
            this.ln_assetno = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.BarcodeX1)).BeginInit();
            this.SuspendLayout();
            // 
            // BarcodeX1
            // 
            this.BarcodeX1.Enabled = true;
            this.BarcodeX1.Location = new System.Drawing.Point(5, 15);
            this.BarcodeX1.Name = "BarcodeX1";
            this.BarcodeX1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("BarcodeX1.OcxState")));
            this.BarcodeX1.Size = new System.Drawing.Size(247, 38);
            this.BarcodeX1.TabIndex = 17;
            this.BarcodeX1.UseWaitCursor = true;
            this.BarcodeX1.Enter += new System.EventHandler(this.BarcodeX1_Enter);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // lb_name
            // 
            this.lb_name.AutoSize = true;
            this.lb_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lb_name.Location = new System.Drawing.Point(21, 69);
            this.lb_name.Name = "lb_name";
            this.lb_name.Size = new System.Drawing.Size(82, 13);
            this.lb_name.TabIndex = 18;
            this.lb_name.Text = "Asset Name :";
            this.lb_name.UseWaitCursor = true;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lb_Code
            // 
            this.lb_Code.AutoSize = true;
            this.lb_Code.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lb_Code.Location = new System.Drawing.Point(21, 56);
            this.lb_Code.Name = "lb_Code";
            this.lb_Code.Size = new System.Drawing.Size(82, 13);
            this.lb_Code.TabIndex = 19;
            this.lb_Code.Text = "Asset No.    :";
            this.lb_Code.UseWaitCursor = true;
            // 
            // ln_assetName
            // 
            this.ln_assetName.AutoSize = true;
            this.ln_assetName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.ln_assetName.Location = new System.Drawing.Point(109, 69);
            this.ln_assetName.Name = "ln_assetName";
            this.ln_assetName.Size = new System.Drawing.Size(15, 13);
            this.ln_assetName.TabIndex = 20;
            this.ln_assetName.Text = "..";
            this.ln_assetName.UseWaitCursor = true;
            // 
            // ln_assetno
            // 
            this.ln_assetno.AutoSize = true;
            this.ln_assetno.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.ln_assetno.Location = new System.Drawing.Point(109, 56);
            this.ln_assetno.Name = "ln_assetno";
            this.ln_assetno.Size = new System.Drawing.Size(15, 13);
            this.ln_assetno.TabIndex = 21;
            this.ln_assetno.Text = "..";
            this.ln_assetno.UseWaitCursor = true;
            // 
            // Form_005008_PrintBarcodeAsset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(283, 103);
            this.ControlBox = false;
            this.Controls.Add(this.ln_assetno);
            this.Controls.Add(this.ln_assetName);
            this.Controls.Add(this.lb_Code);
            this.Controls.Add(this.lb_name);
            this.Controls.Add(this.BarcodeX1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_005008_PrintBarcodeAsset";
            this.TransparencyKey = System.Drawing.Color.Black;
            this.UseWaitCursor = true;
            this.Load += new System.EventHandler(this.Form_005008_PrintBarcodeAsset_Load);
            this.Shown += new System.EventHandler(this.Form_005008_PrintBarcodeAsset_Shown);
            this.Activated += new System.EventHandler(this.Form_005008_PrintBarcodeAsset_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.BarcodeX1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public AxBARCODEXLib.AxBarcodeX BarcodeX1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Label lb_name;
        public System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lb_Code;
        private System.Windows.Forms.Label ln_assetName;
        private System.Windows.Forms.Label ln_assetno;

    }
}