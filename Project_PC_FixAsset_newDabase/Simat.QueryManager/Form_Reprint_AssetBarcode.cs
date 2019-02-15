using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SimatSoft.ControlBasic;
using SimatSoft.CustomControl;
using SimatSoft.DB.ORM;
using SimatSoft.QueryManager;

namespace Simatsoft.QueryManager
{
    public partial class Form_Reprint_AssetBarcode : Form
    {
        public string returnvalue = "";
        public Control Controlreturnvalue1 = null;
        public Control Controlreturnvalue2 = null;
        public Control Controlreturnvalue3 = null;
        public Control Controlreturnvalue4 = null;
        public Control Controlreturnvalue5 = null;
        public Control Controlreturnvalue6 = null;
        public Control Controlreturnvalue7 = null;
        public DataGridViewCell CellValue = null;
        public Class_PresentData clsmain = new Class_PresentData(); 

        public Form_Reprint_AssetBarcode()
        {
            InitializeComponent();
        }

        private void Form_Reprint_AssetBarcode_Load(object sender, EventArgs e)
        {

        }
    }
}