using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SimatSoft.DB.ORM;
using SimatSoft.CustomControl;

namespace SimatSoft.FixAsset
{
    public partial class Form_003004_Detail : Form
    {
        public bool Bool_FlagCheckReturn = false;
        public Enum_TypeSearch Type = Enum_TypeSearch.PO;
        public string Str_ModelID = "";

        public Form_003004_Detail()
        {
            InitializeComponent();
        }

        private void Form_003004_Detail_Load(object sender, EventArgs e)
        {
            DataSet Ds_TempDataSet = new DataSet();
            string Str_SQL;
            try
            {
                switch (Type)
                {
                    case Enum_TypeSearch.PODT:
                        {
                            Str_SQL = "SELECT * From PODT";
                            Ds_TempDataSet = Manager.Engine.GetDataSet(Str_SQL);
                            sS_DataGridView_Detail.DataSource = Ds_TempDataSet;
                            sS_DataGridView_Detail.DataMember = "Table";

                            break;
                        }
                    case Enum_TypeSearch.AssetTransferDT:
                        {
                            Str_SQL = "SELECT* From AssetTransferDT";
                            Ds_TempDataSet = Manager.Engine.GetDataSet(Str_SQL);
                            sS_DataGridView_Detail.DataSource = Ds_TempDataSet;
                            sS_DataGridView_Detail.DataMember = "Table";
                            break;
                        }
                   
                }
            }
            catch (Exception Ex) { throw Ex; }                   
        
        }

        public void Function_ShowData(string Str_FormID, string Str_ObjectID, Form Frm_Parent)
        {
            Point Loc;
            DataSet DS_TempDsDetail = new DataSet();
            DataSet DS_TempDsSubDetail = new DataSet();
            switch (Str_FormID)
            {
                case "32":
                    DS_TempDsDetail = Manager.Engine.GetDataSet<Podt>("POID = '" + Str_ObjectID + "'");
                    DS_TempDsSubDetail = Manager.Engine.GetDataSet<AssetReceive>("POID = '" + Str_ObjectID + "'");
                    break;
                case "33":
                    DS_TempDsDetail = Manager.Engine.GetDataSet<AssetTransferDT>("TransferID = '" + Str_ObjectID + "'");
                    DS_TempDsSubDetail = Manager.Engine.GetDataSet<AssetTransferSerial>("TransferID = '" + Str_ObjectID + "'");
                    break;
             }

             sS_DataGridView_Detail.DataSource = DS_TempDsDetail;
             sS_DataGridView_Detail.DataMember = "Table";
             sS_DataGridView_SubDetail.DataSource = DS_TempDsSubDetail;
             sS_DataGridView_SubDetail.DataMember = "Table";

            this.MdiParent = Frm_Parent;

            Loc = Global.SetLocation(this.Location.X, this.Width, this.Location.Y);

            int Int_TempIDForm = Global.ConfigForm.Int_IDForm++;

            this.Show();
            this.Tag = Int_TempIDForm;
            this.Location = Loc;
            Global.Function_AddTabStripButton(Int_TempIDForm, this.Name);
        }

        private void Form_003004_Detail_FormClosed(object sender, FormClosedEventArgs e)
        {
            Global.Function_RemoveTabStripButton(this.Tag);
        }
    }
}