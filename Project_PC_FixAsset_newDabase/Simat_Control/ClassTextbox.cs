using System;
using System.Collections.Generic;
using System.Text;
using System.Data ;
using System.Windows.Forms;
namespace SimatSoft.ControlBasic
{
    public class ClassTextbox : System.Windows.Forms.TextBox    
    {
        public DataRow  dataconfig;

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
