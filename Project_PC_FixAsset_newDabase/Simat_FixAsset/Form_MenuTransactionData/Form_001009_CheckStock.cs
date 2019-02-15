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
    public partial class Form_001009_CheckStock : SS_PaintGradientForm
    {
        POHome POHomeObj = new POHome();
        DataSet Ds = new DataSet();
        public Form_001009_CheckStock()
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
            string sql ="SELECT Asset.AssetID, Asset.AssetName, Asset.SerialNo, Asset.modelID, Asset.deptID, Asset.buildID, Asset.floorID, Asset.areaID, Asset.AssetPrice, " +
                      " CheckStock.buildID AS checkBuildid, CheckStock.floorID AS checkFloorid, CheckStock.areaID AS CheckAreaid, CheckStock.Remark, " +
                      " CheckStock.UserName, CheckStock.CreatedDate, Type.typeName " +
                       " FROM Type INNER JOIN " +
                       " CheckStock ON Type.typeID = CheckStock.Type RIGHT OUTER JOIN " +
                       " Asset ON CheckStock.AssetID = Asset.AssetID " ;
            Ds = Manager.Engine.GetDataSet(sql);
            sS_DataGridView_CheckStock.DataSource = Ds;
            sS_DataGridView_CheckStock.DataMember = "Table";
        }
        private void Function_ShowDataInDatagridOnSelectCombo(string Str_TypeName)
        {
            string sql = "SELECT Asset.AssetID, Asset.AssetName, Asset.SerialNo, Asset.modelID, Asset.deptID, Asset.buildID, Asset.floorID, Asset.areaID, Asset.AssetPrice, " +
                      " CheckStock.buildID AS checkBuildid, CheckStock.floorID AS checkFloorid, CheckStock.areaID AS CheckAreaid, CheckStock.Remark, " +
                      " CheckStock.UserName, CheckStock.CreatedDate, Type.typeName " +
                       " FROM Type INNER JOIN " +
                       " CheckStock ON Type.typeID = CheckStock.Type RIGHT OUTER JOIN " +
                       " Asset ON CheckStock.AssetID = Asset.AssetID " +
                       "WHERE (Type.typeName = '" + Str_TypeName + "')";
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

      
    }
 }