using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SimatSoft.FixAsset
{
    public partial class Form_005009_Barcode : Form
    {

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern long BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);
        private Bitmap memoryImage;

        private void CaptureScreen()
        {
            Graphics mygraphics = this.CreateGraphics();
            Size s = this.Size;
            memoryImage = new Bitmap(s.Width, s.Height, mygraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            IntPtr dc1 = mygraphics.GetHdc();
            IntPtr dc2 = memoryGraphics.GetHdc();
            BitBlt(dc2, 0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height, dc1, 0, 0, 13369376);
            mygraphics.ReleaseHdc(dc1);
            memoryGraphics.ReleaseHdc(dc2);
        }
        public void Print()
        {
            System.Threading.Thread.Sleep(1000);
            CaptureScreen();
            printDocument.Print();  
           
        }
        public Form_005009_Barcode()
        {
            InitializeComponent();
        }
        public void GetAsseforPrint(string AssetNo, string AssetName,string Depart,string Date)
        {
            this.ln_assetName.Text = AssetName;
            this.ln_assetno.Text = AssetNo;
            this.Depart.Text = Depart; // BU (Location / Building)
            this.Date.Text = Date; // Invoice Date

            this.BarcodeX1.Caption = AssetNo;
        }

        private void Form_005009_Barcode_Activated(object sender, EventArgs e)
        {
            timer.Enabled = true;
        }

        private void Form_005009_Barcode_Load(object sender, EventArgs e)
        {
        
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Print();
            timer.Enabled = false;
            this.Close();  
        }

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BarcodeX1_Enter(object sender, EventArgs e)
        {

        }
    }
}






