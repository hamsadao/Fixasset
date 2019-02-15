namespace SimatSoft.ControlBasic
{
    partial class SimatDateTimeSelect
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dateTimePicker_Simat = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // dateTimePicker_Simat
            // 
            this.dateTimePicker_Simat.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dateTimePicker_Simat.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_Simat.Location = new System.Drawing.Point(0, 1);
            this.dateTimePicker_Simat.Name = "dateTimePicker_Simat";
            this.dateTimePicker_Simat.Size = new System.Drawing.Size(143, 20);
            this.dateTimePicker_Simat.TabIndex = 0;
            // 
            // SimatDateTimeSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dateTimePicker_Simat);
            this.Name = "SimatDateTimeSelect";
            this.Size = new System.Drawing.Size(144, 21);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker_Simat;
    }
}
