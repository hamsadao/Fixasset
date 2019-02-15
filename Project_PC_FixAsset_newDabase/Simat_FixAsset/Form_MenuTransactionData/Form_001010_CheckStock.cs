using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SimatSoft.CustomControl;
using SimatSoft.DB.ORM;
using SimatSoft.ValidateData;

namespace SimatSoft.FixAsset
{
    public partial class Form_001010_CheckStock : SS_PaintGradientForm
    {
        POHome POHomeObj = new POHome();
        DataSet Ds = new DataSet();
        CheckStockHome CheckStockObj = new CheckStockHome();
        public Form_001010_CheckStock()
        {
            InitializeComponent();
            DarkColor = Global.ConfigForm.Colr_BackColor;
            Function_IntitialControl();
            Global.Function_ToolStripSetUP(Enum_Mode.Search);
        }
        private void Function_IntitialControl()
        {
            this.Text = Global.Function_Language(this, this, "ID:001009(Check Stock)");
            LBL_TypeName.Text = Global.Function_Language(this, LBL_TypeName, "Type:");
            LBL_StockSystem.Text = Global.Function_Language(this, LBL_StockSystem, "StockSystem:");
            LBL_StockCheck.Text = Global.Function_Language(this, LBL_StockCheck, "StockCheck:");
        }

        private void Form_001009_CheckStock_FormClosed(object sender, FormClosedEventArgs e)
        {
            Global.Function_RemoveTabStripButton(this.Tag);
        }
        private void Function_ShowDataInDatagridview()
        {
            //string sql = "SELECT CheckStock.AssetID, Asset.AssetName, Asset.SerialNo, CheckStock.modelID AS CheckModelID, CheckStock.buildID AS CheckBuildID, " +
            //             "CheckStock.floorID AS CheckFloorID, CheckStock.areaID AS CheckAreaID, CheckStock.Remark, Asset.modelID , Asset.deptID, Asset.floorID , " +
            //             "Asset.buildID , Asset.areaID , CheckStock.UserName, CheckStock.CreatedDate, Type.typeName " +
            //             "FROM CheckStock INNER JOIN " +
            //             "Asset ON CheckStock.AssetID = Asset.AssetID LEFT OUTER JOIN " +
            //             " Type ON CheckStock.type = Type.typeID";

            string sql = "SELECT DISTINCT  CheckStock.AssetID, Asset.AssetName, Asset.SerialNo, CheckStock.modelID AS CheckModelID," +
                        " CheckStock.buildID AS CheckBuildID, CheckStock.floorID AS CheckFloorID, CheckStock.areaID AS CheckAreaID, " +
                        " CheckStock.Remark, Asset.modelID, Asset.deptID, Asset.floorID, " +
                        " Asset.buildID, Asset.areaID, CheckStock.UserName, CheckStock.CreatedDate FROM   CheckStock LEFT OUTER JOIN " +
                        " Asset ON CheckStock.AssetID = Asset.AssetID  LEFT OUTER JOIN " +
                        " Type ON CheckStock.type = Type.typeID";

            Ds = Manager.Engine.GetDataSet(sql);
            sS_DataGridView_CheckStock.DataSource = Ds;
            sS_DataGridView_CheckStock.DataMember = "Table";
        }
        private void Function_ShowDataInDatagridOnSelectCombo(string Str_TypeName)
        {
            //string sql = "SELECT CheckStock.AssetID, Asset.AssetName, Asset.SerialNo, CheckStock.modelID AS CheckModelID, CheckStock.buildID AS CheckBuildID, " +
            //             "CheckStock.floorID AS CheckFloorID, CheckStock.areaID AS CheckAreaID, CheckStock.Remark, Asset.modelID , Asset.deptID, Asset.floorID , " +
            //             "Asset.buildID , Asset.areaID , CheckStock.UserName, CheckStock.CreatedDate, Type.typeName " +
            //             "FROM CheckStock INNER JOIN Asset ON CheckStock.AssetID = Asset.AssetID LEFT OUTER JOIN " +
            //             " Type ON CheckStock.type = Type.typeID " +
            //             " WHERE (TypeName = '" + Str_TypeName + "')";

            string sql = "SELECT DISTINCT  CheckStock.AssetID, Asset.AssetName, Asset.SerialNo, CheckStock.modelID AS CheckModelID," +
            " CheckStock.buildID AS CheckBuildID, CheckStock.floorID AS CheckFloorID, CheckStock.areaID AS CheckAreaID, " +
            " CheckStock.Remark, Asset.modelID, Asset.deptID, Asset.floorID, " +
            " Asset.buildID, Asset.areaID, CheckStock.UserName, CheckStock.CreatedDate FROM   CheckStock LEFT OUTER JOIN " +
            " Asset ON CheckStock.AssetID = Asset.AssetID  LEFT OUTER JOIN " +
            " Type ON CheckStock.type = Type.typeID  WHERE (TypeName = '" + Str_TypeName + "')";

            Ds = Manager.Engine.GetDataSet(sql);
            sS_DataGridView_CheckStock.DataSource = Ds;
            sS_DataGridView_CheckStock.DataMember = "Table";
            toolStripStatusLabel_Record.Text = "Summary:" + sS_DataGridView_CheckStock.Rows.Count;
        }
        private void Function_ShowAssetInDatagrid()
        {
            string sql = "SELECT * FROM Asset";
            Ds = Manager.Engine.GetDataSet(sql);
            sS_DataGridView_Asset.DataSource = Ds;
            sS_DataGridView_Asset.DataMember = "Table";
        }
        private void Function_ShowDataInCombo()
        {
            string sql = "SELECT typeID,typeName from type";
            Ds = Manager.Engine.GetDataSet(sql);
            for (int i = 0; i <= Ds.Tables[0].Rows.Count - 1; i++)
            {
                sS_ComboBox_TypeName.Items.Add(Ds.Tables[0].Rows[i].ItemArray[1].ToString());
            }

        }
        private void Form_001009_CheckStock_Load(object sender, EventArgs e)
        {
            Global.Location.Int_CountForm = Global.Location.Int_CountForm + 0;
            Function_ShowDataInDatagridview();
            Function_ShowAssetInDatagrid();
            Function_ShowDataInCombo();
            toolStripStatusLabel_Record.Text = "Summary:" + sS_DataGridView_CheckStock.Rows.Count;
        }
        private void sS_ComboBox_Status_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sS_ComboBox_TypeName.SelectedItem != null)
            {
                Function_ShowDataInDatagridOnSelectCombo(sS_ComboBox_TypeName.SelectedItem.ToString());
            }
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            List<CheckStock> CheckStockCollection = new List<CheckStock>();
            CheckStock TempCheckStock = new CheckStock();
            foreach (DataGridViewRow TempDataGridRow in this.sS_DataGridView_CheckStock.Rows)
            {
                TempCheckStock = Manager.Engine.GetObject<CheckStock>(TempDataGridRow.Cells[0].Value.ToString());
                CheckStockCollection.Add(TempCheckStock);
            }
                Wilson.ORMapper.Transaction ORTransaction = Manager.Engine.BeginTransaction();

                if (CheckStockObj.Delete(ORTransaction, CheckStockCollection))
                {
                    ORTransaction.Commit();
                    SS_MyMessageBox.ShowBox("Delete data complete", "Delete Data Information", DialogMode.OkOnly, this.Name, "000012", Global.Lang.Str_Language);
                    Function_ShowDataInDatagridview();
                }
                else
                {
                    SS_MyMessageBox.ShowBox("Can not delete data ", "Warning", DialogMode.OkOnly, this.Name, "000013", Global.Lang.Str_Language);
                }
        }

        private void Form_001010_CheckStock_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Global.Location.Int_CountForm > 0)
            {
                Global.Location.Int_CountForm = Global.Location.Int_CountForm - 1;
            }
        }

        private void CmdAdd_Click(object sender, EventArgs e)
        {
            Form_001010_AssetCheckStock frm = new Form_001010_AssetCheckStock();
            frm.Show();
        }
    }
 }