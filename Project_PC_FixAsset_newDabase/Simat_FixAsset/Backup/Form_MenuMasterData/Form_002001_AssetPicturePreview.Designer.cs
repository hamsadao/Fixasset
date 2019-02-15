namespace SimatSoft.FixAsset
{
    partial class Form_002001_AssetPicturePreview
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
            this.pictureBox_Preview = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Preview)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_Preview
            // 
            this.pictureBox_Preview.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_Preview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox_Preview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox_Preview.Location = new System.Drawing.Point(-2, 0);
            this.pictureBox_Preview.Name = "pictureBox_Preview";
            this.pictureBox_Preview.Size = new System.Drawing.Size(294, 266);
            this.pictureBox_Preview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Preview.TabIndex = 0;
            this.pictureBox_Preview.TabStop = false;
            // 
            // Form_002001_AssetPicturePreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.pictureBox_Preview);
            this.Name = "Form_002001_AssetPicturePreview";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_002001_AssetPicturePreview";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_002001_AssetPicturePreview_FormClosing);
            this.Load += new System.EventHandler(this.Form_002001_AssetPicturePreview_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Preview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_Preview;
    }
}