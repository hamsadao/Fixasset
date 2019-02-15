using System;
using System.Collections.Generic;
using System.Text;

namespace System.Windows.Forms.Samples
{
    class ClassTextbox: System.Windows.Forms.TextBox    
    {
        public Data.DataRow  dataconfig = null;

        public  void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ClassTextbox
            // 
            this.Click += new System.EventHandler(this.ClassTextbox_Click);
            this.ResumeLayout(false);

        }

        private void ClassTextbox_Click(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            t.SelectAll();

        }
    }
}
