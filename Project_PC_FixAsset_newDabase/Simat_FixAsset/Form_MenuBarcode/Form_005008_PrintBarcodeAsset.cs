using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SimatSoft.FixAsset
{
    public partial class Form_005008_PrintBarcodeAsset : Form
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
        private void printDocument1_PrintPage(System.Object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }
        private void printButton_Click(System.Object sender, System.EventArgs e)
        {
            
        }
        public void Print()
        {
            System.Threading.Thread.Sleep(1000);
            CaptureScreen();
            printDocument1.Print(); 
        }
        public Form_005008_PrintBarcodeAsset()
        {
            InitializeComponent();
        }

        private void Form_005008_PrintBarcodeAsset_Shown(object sender, EventArgs e)
        {
           
        }

        private void BarcodeX1_Enter(object sender, EventArgs e)
        {

        }

        private void Form_005008_PrintBarcodeAsset_Activated(object sender, EventArgs e)
        {
            timer1.Enabled = true; 
        }

        private void Form_005008_PrintBarcodeAsset_Load(object sender, EventArgs e)
        {
            
        }

        public void GetAsseforPrint(string AssetNo, string AssetName)
        {
            lb_Code.Text = "Asset No.";
            lb_name.Text = "Asset Name";
            this.ln_assetName.Text = AssetName;
            this.ln_assetno.Text = AssetNo;
            this.BarcodeX1.Caption = AssetNo;
        }
        public void GetLocationforPrint(string LocationNo, string LocationName)
        {
            lb_Code.Text = "Location No.";
            lb_name.Text = "Location Name";
            this.ln_assetName.Text = LocationName;
            this.ln_assetno.Text = LocationNo;
            this.BarcodeX1.Caption = LocationNo;
        }

        public void GetBuildingforPrint(string BuildingNo, string BuildingName)
        {
            lb_Code.Text = "Building No.";
            lb_name.Text = "Building Name";
            this.ln_assetName.Text = BuildingName;
            this.ln_assetno.Text = BuildingNo;
            this.BarcodeX1.Caption = BuildingNo;
        }

        public void GetFloorforPrint(string FloorNo, string FloorName)
        {
            lb_Code.Text = "Floor No.";
            lb_name.Text = "Floor Name";
            this.ln_assetName.Text = FloorName;
            this.ln_assetno.Text = FloorNo;
            this.BarcodeX1.Caption = FloorNo;
        }

        public void GetCustodianforPrint(string CustodianNo, string CustodianName)
        {
            lb_Code.Text = "Custodian No.";
            lb_name.Text = "Custodian Name";
            this.ln_assetName.Text = CustodianName;
            this.ln_assetno.Text = CustodianNo;
            this.BarcodeX1.Caption = CustodianNo;
        }

        public void GetDepartmentforPrint(string DepartmentNo, string DepartmentName)
        {
            lb_Code.Text = "Department No.";
            lb_name.Text = "Department Name";
            this.ln_assetName.Text = DepartmentName;
            this.ln_assetno.Text = DepartmentNo;
            this.BarcodeX1.Caption = DepartmentNo;
        }

        public void GetmodelforPrint(string ModellNo, string ModellName)
        {
            lb_Code.Text = "Modell No.";
            lb_name.Text = "Modell Name";
            this.ln_assetName.Text = ModellName;
            this.ln_assetno.Text = ModellNo;
            this.BarcodeX1.Caption = ModellNo;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Print();
            timer1.Enabled = false;
            this.Close();  
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}