namespace System.Windows.Forms.Samples
{
    partial class UserControl1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControl1));
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.button1 = new System.Windows.Forms.Button();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // monthCalendar
            // 
            this.monthCalendar.AccessibleDescription = null;
            this.monthCalendar.AccessibleName = null;
            resources.ApplyResources(this.monthCalendar, "monthCalendar");
            this.monthCalendar.BackgroundImage = null;
            this.monthCalendar.Font = null;
            this.monthCalendar.Name = "monthCalendar";
            // 
            // button1
            // 
            this.button1.AccessibleDescription = null;
            this.button1.AccessibleName = null;
            resources.ApplyResources(this.button1, "button1");
            this.button1.BackgroundImage = null;
            this.button1.Font = null;
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.AccessibleDescription = null;
            this.maskedTextBox1.AccessibleName = null;
            resources.ApplyResources(this.maskedTextBox1, "maskedTextBox1");
            this.maskedTextBox1.BackgroundImage = null;
            this.maskedTextBox1.Font = null;
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.ValidatingType = typeof(System.DateTime);
            // 
            // UserControl1
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.BackgroundImage = null;
            this.Controls.Add(this.monthCalendar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.maskedTextBox1);
            this.Font = null;
            this.Name = "UserControl1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MonthCalendar monthCalendar;
        private Button button1;
        private MaskedTextBox maskedTextBox1;

    }
}
