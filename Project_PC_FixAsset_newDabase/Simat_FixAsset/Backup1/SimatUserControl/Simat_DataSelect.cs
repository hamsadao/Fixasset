using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace System.Windows.Forms.Samples
{
    public partial class Simat_DataSelect : UserControl
    {
        public string textvalue() 
        {
            return maskedTextBox1.Text; 
        }
        public Simat_DataSelect()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            monthCalendar.Visible = true;
            this.Size = new System.Drawing.Size(177, 185); 
        }
        private void monthCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            monthCalendar.Visible = false;
            maskedTextBox1.Text = monthCalendar.SelectionEnd.ToString("dd/MM/yyyy");
            this.Tag = maskedTextBox1.Text;
            this.privatedatevalue = monthCalendar.SelectionEnd.ToString("dd/MM/yyyy");
            this.Size = new System.Drawing.Size(177, 25); 
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            this.Tag = maskedTextBox1.Text;
            this.privatedatevalue = maskedTextBox1.Text;
        }

        private void maskedTextBox1_Leave(object sender, EventArgs e)
        {
            this.Tag = maskedTextBox1.Text;
            this.privatedatevalue = maskedTextBox1.Text;
        }

        private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.Tag = maskedTextBox1.Text;
            this.privatedatevalue = maskedTextBox1.Text;
        }

        private void monthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {

        }
       
    }
}