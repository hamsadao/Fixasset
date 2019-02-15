using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.comboBox1.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Prints input = new Prints();
           // input.SetPort1 = "COM" + (comboBox1.SelectedIndex+1);
            input.PrintInform("111", "AAA", "111", "111", "aaa");

            MessageBox.Show("Message: "+input.ToString());

        }
    }
}