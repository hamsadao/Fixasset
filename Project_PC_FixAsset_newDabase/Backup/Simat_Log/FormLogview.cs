using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SimatSoft.Log
{
    public partial class FormLogview : Form
    {
        public Exception ex;
        public FormLogview(Exception e)
        {
            InitializeComponent();
            if (e != null)
            {
                ex = e;
                textBoxResult.Text = ex.Message;
            }
        }
        public FormLogview(String  e)
        {
                  InitializeComponent();
                textBoxResult.Text = e;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                Classlogfile.Writelogfile(saveFileDialog1.FileName, ex.Message);
            }
        }

    }
}