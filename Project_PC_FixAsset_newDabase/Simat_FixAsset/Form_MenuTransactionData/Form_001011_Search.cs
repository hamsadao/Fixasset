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
    public partial class Form_001011_Search : Form
    {
        public bool Bool_FlagCheckReturn = false;
        public Enum_TypeSearch Type = Enum_TypeSearch.PO;
        public string Str_ModelID = "";
        public string Str_DeptID = "";
        public string Str_FloorID = "";
        public string Str_BuildID = "";
        public string Str_FacCode = "";
       
        public Form_001011_Search()
        {
            InitializeComponent();
        }
        private void Form_003002_SearchPO_Load(object sender, EventArgs e)
        {
            DataSet Ds_TempDataSet = new DataSet();
            string Str_SQL;
            try
            {
                switch (Type)
                {
                   case Enum_TypeSearch.Floor:
                        {
                            Str_SQL = "Select floorID,floorName  From Floor WHERE buildID ='" + Str_BuildID + "' and FacCode ='" + Str_FacCode + "'";
                            Ds_TempDataSet = Manager.Engine.GetDataSet(Str_SQL);
                            sS_DataGridView_Search.DataSource = Ds_TempDataSet;
                            sS_DataGridView_Search.DataMember = "Table";
                            break;
                        }
                    case Enum_TypeSearch.Area:
                        {
                            Str_SQL = "Select AreaID,AreaName  From Area WHERE floorID = '" + Str_FloorID + "' and buildID ='" + Str_BuildID + "' and FacCode ='" + Str_FacCode + "'";
                            Ds_TempDataSet = Manager.Engine.GetDataSet(Str_SQL);
                            sS_DataGridView_Search.DataSource = Ds_TempDataSet;
                            sS_DataGridView_Search.DataMember = "Table";
                            break;
                        }
                    case Enum_TypeSearch.PO:
                        {
                            string[] Str_ColumnPO = { "POID", "vendorID", "POType", "PODate", "Username", "Remark", "FacCode", "StatusID", "DeptID" };
                            Ds_TempDataSet = Manager.Engine.GetDataSet<Pohd>("StatusID = 'NEW' OR StatusID ='RECEIVE'", Str_ColumnPO);
                            sS_DataGridView_Search.DataSource = Ds_TempDataSet;
                            sS_DataGridView_Search.DataMember = "Table";
                            break;
                        }
                    case Enum_TypeSearch.InTransfer:
                        {
                            string[] Str_ColumnTransfer ={ "TransferID", "TransferType", "FromDeptID", "ToDeptID", "TransferDate", "Username", "TransferFlag", "StatusID", "Remark" };
                            Ds_TempDataSet = Manager.Engine.GetDataSet<AssetTransferHD>("StatusID !='CLOSE' and StatusID != 'DELETE' and TransferFlag='I'",Str_ColumnTransfer);
                            sS_DataGridView_Search.DataSource = Ds_TempDataSet;
                            sS_DataGridView_Search.DataMember = "Table";
                            break;
                        }
                    case Enum_TypeSearch.TransferOrder:
                        {
                            string[] Str_ColumnTransfer ={ "TransferID", "TransferType", "FromDeptID", "ToDeptID", "TransferDate", "Username", "TransferFlag", "StatusID", "Remark" };
                            Ds_TempDataSet = Manager.Engine.GetDataSet<AssetTransferHD>("StatusID = 'NEW' and TransferFlag='I'", Str_ColumnTransfer);
                            sS_DataGridView_Search.DataSource = Ds_TempDataSet;
                            sS_DataGridView_Search.DataMember = "Table";
                            break;
                        }
                    case Enum_TypeSearch.TransferSerial:
                        {
                            Str_SQL = "SELECT Asset.modelID, Asset.AssetID, Asset.AssetName, Asset.SerialNo, Asset.buildID, Asset.floorID,Asset.areaID, Asset.CustodianID, Asset.Remark " +
                                             "FROM Asset INNER JOIN Model ON Asset.modelID = Model.modelID WHERE Asset.modelID ='" + Str_ModelID + "' and Asset.DeptID ='" + Str_DeptID + "'" +
                                             "ORDER BY Asset.modelID";

                            Ds_TempDataSet = Manager.Engine.GetDataSet(Str_SQL);
                            sS_DataGridView_Search.DataSource = Ds_TempDataSet;
                            sS_DataGridView_Search.DataMember = "Table";
                            break;
                        }
                    case Enum_TypeSearch.ExTransferSerial:
                        {
                            Str_SQL = "SELECT Asset.modelID, Asset.AssetID, Asset.AssetName, Asset.SerialNo, Asset.buildID, Asset.floorID,Asset.areaID, Asset.CustodianID, Asset.Remark " +
                                             "FROM Asset INNER JOIN Model ON Asset.modelID = Model.modelID WHERE Asset.modelID ='" + Str_ModelID + "'and Asset.FacCode ='" + Str_FacCode + "'" +
                                             "ORDER BY Asset.modelID";

                            Ds_TempDataSet = Manager.Engine.GetDataSet(Str_SQL);
                            sS_DataGridView_Search.DataSource = Ds_TempDataSet;
                            sS_DataGridView_Search.DataMember = "Table";
                            break;
                        }
                    case Enum_TypeSearch.ExTransfer:
                        {
                            string[] Str_ColumnTransfer ={ "TransferID", "TransferType", "FromFacCode", "ToFacCode", "TransferDate", "Username", "TransferFlag", "StatusID", "Remark" };
                            Ds_TempDataSet = Manager.Engine.GetDataSet<AssetTransferHD>("StatusID !='CLOSE' and TransferFlag='E'", Str_ColumnTransfer);
                            sS_DataGridView_Search.DataSource = Ds_TempDataSet;
                            sS_DataGridView_Search.DataMember = "Table";
                            break;
                        }
                    case Enum_TypeSearch.PODT:
                        {
                            Str_SQL = "SELECT * From PODT";
                            Ds_TempDataSet = Manager.Engine.GetDataSet(Str_SQL);
                            sS_DataGridView_Search.DataSource = Ds_TempDataSet;
                            sS_DataGridView_Search.DataMember = "Table";
                            break;
                        }
                    case Enum_TypeSearch.AssetTransferDT:
                        {
                            Str_SQL = "SELECT* From AssetTransferDT";
                            Ds_TempDataSet = Manager.Engine.GetDataSet(Str_SQL);
                            sS_DataGridView_Search.DataSource = Ds_TempDataSet;
                            sS_DataGridView_Search.DataMember = "Table";
                            break;
                        }
                   
                }
            }
            catch (Exception Ex) { throw Ex; }                   
        }

        private void sS_DataGridView_Search_DoubleClick(object sender, EventArgs e)
        {
            if (sS_DataGridView_Search[0, sS_DataGridView_Search.CurrentRow.Index].Value.ToString() != null)
            {
                Funtion_SetReturnValue();
                Bool_FlagCheckReturn = true;
                this.Close();
            }
        }
        private void Form_003002_SearchPO_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(Bool_FlagCheckReturn ==false)
                if (sS_DataGridView_Search.Rows.Count != 0)
                {
                    if (Convert.ToString(sS_DataGridView_Search[0, sS_DataGridView_Search.CurrentRow.Index].Value) != null)
                    {
                        Global.ReturnValue.Str_FormSearch = sS_DataGridView_Search[0, sS_DataGridView_Search.CurrentRow.Index].Value.ToString();
                    }
                }
        }
        private void Funtion_SetReturnValue()
        {
            switch (Type)
            {
                case Enum_TypeSearch.PO:
                case Enum_TypeSearch.InTransfer:
                case Enum_TypeSearch.ExTransfer:
                case Enum_TypeSearch.TransferOrder:
                    Global.ReturnValue.Str_FormSearch = sS_DataGridView_Search[0, sS_DataGridView_Search.CurrentRow.Index].Value.ToString();
                    break;
                case Enum_TypeSearch.TransferSerial:
                    Global.ReturnValue.Str_ModelID = sS_DataGridView_Search[0, sS_DataGridView_Search.CurrentRow.Index].Value.ToString();
                    Global.ReturnValue.Str_AssetNo = sS_DataGridView_Search[1, sS_DataGridView_Search.CurrentRow.Index].Value.ToString();
                    Global.ReturnValue.Str_AssetName = sS_DataGridView_Search[2, sS_DataGridView_Search.CurrentRow.Index].Value.ToString();
                    Global.ReturnValue.Str_SerialNo = sS_DataGridView_Search[3, sS_DataGridView_Search.CurrentRow.Index].Value.ToString();
                    Global.ReturnValue.Str_BuildID = sS_DataGridView_Search[4, sS_DataGridView_Search.CurrentRow.Index].Value.ToString();
                    Global.ReturnValue.Str_FloorID = sS_DataGridView_Search[5, sS_DataGridView_Search.CurrentRow.Index].Value.ToString();
                    Global.ReturnValue.Str_AreaID = sS_DataGridView_Search[6, sS_DataGridView_Search.CurrentRow.Index].Value.ToString();
                    Global.ReturnValue.Str_CustodianID = Convert.ToString(sS_DataGridView_Search[7, sS_DataGridView_Search.CurrentRow.Index].Value);
                      break;
                 case Enum_TypeSearch.ExTransferSerial:
                      Global.ReturnValue.Str_AssetNo = sS_DataGridView_Search[1, sS_DataGridView_Search.CurrentRow.Index].Value.ToString();
                      Global.ReturnValue.Str_AssetName = sS_DataGridView_Search[2, sS_DataGridView_Search.CurrentRow.Index].Value.ToString();
                      Global.ReturnValue.Str_SerialNo = sS_DataGridView_Search[3, sS_DataGridView_Search.CurrentRow.Index].Value.ToString();
                      Global.ReturnValue.Str_BuildID = sS_DataGridView_Search[4, sS_DataGridView_Search.CurrentRow.Index].Value.ToString();
                      Global.ReturnValue.Str_FloorID = sS_DataGridView_Search[5, sS_DataGridView_Search.CurrentRow.Index].Value.ToString();
                      Global.ReturnValue.Str_AreaID = sS_DataGridView_Search[6, sS_DataGridView_Search.CurrentRow.Index].Value.ToString();
                      Global.ReturnValue.Str_CustodianID = Convert.ToString(sS_DataGridView_Search[7, sS_DataGridView_Search.CurrentRow.Index].Value);
                      break;
                case Enum_TypeSearch.Floor:
                      Global.ReturnValue.Str_FloorID = sS_DataGridView_Search[0, sS_DataGridView_Search.CurrentRow.Index].Value.ToString();
                      break;
                case Enum_TypeSearch.Area:
                      Global.ReturnValue.Str_AreaID = sS_DataGridView_Search[0, sS_DataGridView_Search.CurrentRow.Index].Value.ToString();
                      break;
              
            }
        }
    }
}