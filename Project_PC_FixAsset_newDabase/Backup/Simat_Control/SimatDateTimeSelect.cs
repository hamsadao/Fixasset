using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SimatSoft.ControlBasic
{
    
    public partial class SimatDateTimeSelect : UserControl
    {
        public DataRow dataconfig;
        public DateTime  textvalue()
        {
            return dateTimePicker_Simat.Value; 
        }
        public SimatDateTimeSelect()
        {
            InitializeComponent();
            dateTimePicker_Simat.Value = System.DateTime.Now.Date ;   
        }
    }
}
