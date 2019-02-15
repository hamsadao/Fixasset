using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Wilson.ORMapper;
using SimatSoft.DB.ORM;

namespace SimatSoft.FixAsset
{
    
    public partial class Form_003003_HistoryAssetTransferHD : Form
    {
        private Enum_Mode Enm_StateForm = Enum_Mode.SetDefault;
        Class_AuthorizeState AuthorizeState = new Class_AuthorizeState();
        public Form_003003_HistoryAssetTransferHD()
        {
            InitializeComponent();
            Function_IntitialControl();
            Global.Function_ToolStripSetUP(Enum_Mode.SetDefault);

            AuthorizeState.Function_SetAuthorize(this.Name.Substring(5, 6).Replace("0", ""));
            AuthorizeState.Funtion_SetButtonAuthorize(Enm_StateForm);
        }

        private void Function_IntitialControl()
        {
            this.Text = Global.Function_Language(this, this, "ID:003003(HistoryAssetTransferHD)");
        }
       
        private void Function_ShowData()
        {
            DataSet DS = new DataSet();
            DS = Manager.Engine.GetDataSet<AssetTransferHD>("");
            sS_DataGridView_HistoryAsset.DataSource = DS;
            sS_DataGridView_HistoryAsset.DataMember = "Table";
            Function_SetFlagInDataGrid();
            DS.Dispose();
            DS = null;
        }

        private void Form_003003_HistoryTransferHD_Load(object sender, EventArgs e)
        {
            Global.Location.Int_CountForm = Global.Location.Int_CountForm + 0;
            Function_ShowData();
        }

        private void Form_003003_HistoryTransferHD_FormClosed(object sender, FormClosedEventArgs e)
        {
            Global.Function_RemoveTabStripButton(this.Tag);
        }

        private void sS_DataGridView_HistoryAsset_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Form_003004_Detail Frm_Detail = new Form_003004_Detail();
            Frm_Detail.Function_ShowData(this.Name.Substring(5, 6).Replace("0", ""), sS_DataGridView_HistoryAsset[0, e.RowIndex].Value.ToString(), this.MdiParent);
        }

        private void Function_SetFlagInDataGrid()
        {
            if (sS_DataGridView_HistoryAsset.Rows.Count !=0)
            {
                for (int i = 0; i <= sS_DataGridView_HistoryAsset.Rows.Count - 1; i++)
                {
                    switch (sS_DataGridView_HistoryAsset[9, i].Value.ToString())
                    {
                        case "I":
                            sS_DataGridView_HistoryAsset[9, i].Value = "Internal Transfer";
                            break;
                        case"E":
                            sS_DataGridView_HistoryAsset[9, i].Value = "External Transfer";
                            break;
                    }
                }
            }
        }

        private void Form_003003_HistoryAssetTransferHD_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Global.Location.Int_CountForm > 0)
            {
                Global.Location.Int_CountForm = Global.Location.Int_CountForm - 1;
            }
        }
    }
}