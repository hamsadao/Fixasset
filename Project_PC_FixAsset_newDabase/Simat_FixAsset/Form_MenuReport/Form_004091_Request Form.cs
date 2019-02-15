using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SimatSoft.DB.ORM;
using SimatSoft.CustomControl;
using Wilson.ORMapper;
using SimatSoft.ValidateData;
using SimatSoft.QueryManager;

namespace SimatSoft.FixAsset
{
    public partial class Form_004091_Request_Form : SS_PaintGradientForm
    {
        public Form_004091_Request_Form()
        {
            InitializeComponent();
        }

        private void Form_004091_Request_Form_Load(object sender, EventArgs e)
        {
            Function_InsertInfoToDatagrid();
        }

        private void Function_InsertInfoToDatagrid()
        {
            sS_DataGridView_Table.Rows.Clear();

            Object[] Rows = new Object[]{"Buildings","","","","","",""};
            sS_DataGridView_Table.Rows.Add(Rows);
            Rows = new Object[] { "Machinery & equipment", "", "", "", "", "", "" };
            sS_DataGridView_Table.Rows.Add(Rows);
            Rows = new Object[] { "Furniture & fixtures", "", "", "", "", "", "" };
            sS_DataGridView_Table.Rows.Add(Rows);
            Rows = new Object[] { "Nominal Value Assets", "", "", "", "", "", "" };
            sS_DataGridView_Table.Rows.Add(Rows);
            Rows = new Object[] { "Total-THB", "", "-", "-", "-", "-", "" };
            sS_DataGridView_Table.Rows.Add(Rows);

            sS_DataGridView_Table.Columns[0].ReadOnly = true;
        }

        private void sS_ButtonGlass_Generate_Click(object sender, EventArgs e)
        {

        }
    
    }
}