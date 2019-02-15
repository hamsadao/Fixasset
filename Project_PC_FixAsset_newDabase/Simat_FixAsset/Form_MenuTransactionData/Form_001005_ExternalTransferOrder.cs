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
    public partial class Form_001005_ExternalTransferOrder : SS_PaintGradientForm
    {
        POHome POHomeObj = new POHome();
        private int Int_CountObjDTs = 0;
        DataView dtV_Type = new DataView();
        private Enum_Mode Enm_StateForm = Enum_Mode.Search;
        Class_AuthorizeState AuthorizeState = new Class_AuthorizeState();
        System.Collections.ArrayList EditList = new System.Collections.ArrayList();
        EditValue Value = new EditValue();
        private struct EditValue
        {
            public string Str_TransferID;
            public string Str_ModelID;
            public string Str_AssetID;
            public int Int_TransferLine;
        }

        public Form_001005_ExternalTransferOrder()
        {
            InitializeComponent();
            //Set Color statusBar//
            // statusStrip1.BackColor = Global.ConfigForm.Colr_ColorStatus;
            
            DarkColor = Global.ConfigForm.Colr_BackColor;
            Function_IntitialControl();
            //Global.Function_ToolStripSetUP(Enum_Mode.Search);

            AuthorizeState.Function_SetAuthorize(this.Name.Substring(5, 6).Replace("0", ""));
            AuthorizeState.Funtion_SetButtonAuthorize(Enm_StateForm);
        }
        private void Function_IntitialControl()
        {
            this.Text = Global.Function_Language(this, this, "ID:001005(External Transfer Order)");
            LBL_TransferNo.Text = Global.Function_Language(this, LBL_TransferNo, "Transfer No:");
            LBL_Date.Text = Global.Function_Language(this, LBL_Date, "Date:");
            LBL_Type.Text =Global.Function_Language(this,LBL_Type,"Type:");
            LBL_FormCompany.Text = Global.Function_Language(this, LBL_FormCompany, "From Company:");
            LBL_ToCompany.Text = Global.Function_Language(this, LBL_ToCompany, "To Company:");
            LBL_Remark.Text = Global.Function_Language(this, LBL_Remark, "Remark:");

            // Get Type for Internal Transfer
            DataSet ds = (DataSet)Manager.Engine.GetDataSet<SimatSoft.DB.ORM.Type>(" TypeGroup = 'EXTT'");
            dtV_Type = new DataView(ds.Tables[0]);
            sS_ComboBox_TransferType.DataSource = dtV_Type;
            sS_ComboBox_TransferType.ValueMember = "typeName";
            sS_ComboBox_TransferType.DisplayMember = "Name";
        }

        private void Form_001005_ExternalTransferOrder_FormClosed(object sender, FormClosedEventArgs e)
        {
            Global.Function_RemoveTabStripButton(this.Tag);
        }
        private void Function_ClearData()
        {
            sS_MaskedTextBox_TransferID.Text = "";
            sS_MaskedTextBox_FromFacCode.Text = "";
            sS_MaskedTextBox_FromFacName.Text = "";
            sS_MaskedTextBox_ToFacCode.Text = "";
            sS_MaskedTextBox_ToFacName.Text = "";
            sS_MaskedTextBox_Remark.Text = "";
            sS_ComboBox_TransferType.SelectedIndex = 0;

            sS_DataGridView_ExternalTransferOrder.Rows.Clear();
        }

        private void Function_ReadOnlyControlDatagrid(bool Bool_StateControl)
        {
            //sS_DataGridView_InternalTransferOrder.Columns[0].ReadOnly = Bool_StateControl;
            sS_DataGridView_ExternalTransferOrder.Columns[2].ReadOnly = Bool_StateControl;
            sS_DataGridView_ExternalTransferOrder.Columns[4].ReadOnly = Bool_StateControl;
            sS_DataGridView_ExternalTransferOrder.Columns[5].ReadOnly = Bool_StateControl;
        }

        private void Function_ReadOnlyControl(bool Bool_StateControl)
        {
            sS_MaskedTextBox_FromFacCode.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_FromFacName.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_ToFacCode.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_ToFacName.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_Remark.ReadOnly = Bool_StateControl;
        }
        private void Function_EnableControl(bool Bool_StateControl)
        {
            dateTimePicker_Date.Enabled = Bool_StateControl;
            sS_ComboBox_TransferType.Enabled = Bool_StateControl;
        }
        public void Function_ExecuteTransaction(Enum_Mode Enum_mode)
        {
            try
            {
                RunControlHome RunControlHomeObj = new RunControlHome();
                AssetTransferHome AssetTransferHomeObj = new AssetTransferHome();
                Wilson.ORMapper.Transaction ORTransaction = null;
                bool Bool_CheckExecuteComplete = false;
                object[] Obj_TransferID = new object[1] { sS_MaskedTextBox_TransferID.Text };
                int i=0, j=0;
                string qry;

                switch (Enum_mode)
                {
                    case Enum_Mode.Search:
                        break;

                    case Enum_Mode.PreAdd:
                        Function_ClearData();
                        sS_MaskedTextBox_TransferID.ReadOnly = true;
                        sS_MaskedTextBox_Remark.ReadOnly = false;
                        Function_EnableControl(true);
                        sS_DataGridView_ExternalTransferOrder.ReadOnly = false;
                        ///// Edit on 04-01-09
                        //sS_MaskedTextBox_TransferID.Text = RunControlHomeObj.Function_ExcuteGetrunningCommand("TransferRun");
                        sS_MaskedTextBox_TransferID.Text = RunControlHomeObj.Function_ExcuteGetrunningCommand_1("CurrentRun", 4); // External transfer use current runNo. field same with Internaltransfer
                        ///////
                        sS_MaskedTextBox_FromFacCode.Focus();
                        Enm_StateForm = Enum_Mode.PreAdd;
                        break;

                    case Enum_Mode.Add:
                        if (sS_DataGridView_ExternalTransferOrder.Rows.Count > 1)
                        {
                            ORTransaction = Manager.Engine.BeginTransaction();

                            
                            // 24-12-08 Add depID////
                            AssetTransferHomeObj.AssetTransferHDObj.FromDeptID = "-";
                            AssetTransferHomeObj.AssetTransferHDObj.ToDeptID = "-";
                            ///////////

                            // Add TransferHD
                            AssetTransferHomeObj.AssetTransferHDObj.TransferID = sS_MaskedTextBox_TransferID.Text;
                            //AssetTransferHomeObj.AssetTransferHDObj.TransferDate = Convert.ToDateTime(sS_MaskedTextBox_Date.Text);
                            AssetTransferHomeObj.AssetTransferHDObj.TransferDate = Convert.ToDateTime(dateTimePicker_Date.Text);
                            AssetTransferHomeObj.AssetTransferHDObj.FromFacCode = sS_MaskedTextBox_FromFacCode.Text;
                            AssetTransferHomeObj.AssetTransferHDObj.ToFacCode = sS_MaskedTextBox_ToFacCode.Text;
                            AssetTransferHomeObj.AssetTransferHDObj.TransferType = Funciton_TransferType();
                            AssetTransferHomeObj.AssetTransferHDObj.Remark = sS_MaskedTextBox_Remark.Text;
                            AssetTransferHomeObj.AssetTransferHDObj.UserName = Global.ConfigDatabase.Str_UserID;
                            AssetTransferHomeObj.AssetTransferHDObj.TransferFlag = "E";
                            AssetTransferHomeObj.AssetTransferHDObj.StatusID = "NEW";

                            if (AssetTransferHomeObj.AddHD(ORTransaction))
                                Bool_CheckExecuteComplete = true;
                            else
                                Bool_CheckExecuteComplete = false;

                            //Loop Add AssetTransferDetail
/*                            for (i = 0; i < sS_DataGridView_ExternalTransferOrder.Rows.Count - 1; i++)
                            {
                                AssetTransferHomeObj.AssetTransferDTObj.TransferID = sS_MaskedTextBox_TransferID.Text;
                                AssetTransferHomeObj.AssetTransferDTObj.TransferSeq = Convert.ToInt32(sS_DataGridView_ExternalTransferOrder[0, i].Value);
                                AssetTransferHomeObj.AssetTransferDTObj.ModelID = sS_DataGridView_ExternalTransferOrder[1, i].Value.ToString();
                                AssetTransferHomeObj.AssetTransferDTObj.OrderQty = Convert.ToInt32(sS_DataGridView_ExternalTransferOrder[3, i].Value);
                                AssetTransferHomeObj.AssetTransferDTObj.TransferPrice = Convert.ToDecimal(sS_DataGridView_ExternalTransferOrder[4, i].Value);
                                AssetTransferHomeObj.AssetTransferDTObj.TransferCost = Convert.ToDecimal(sS_DataGridView_ExternalTransferOrder[5, i].Value);
                                AssetTransferHomeObj.AssetTransferDTObj.Remark = Convert.ToString(sS_DataGridView_ExternalTransferOrder[6, i].Value);
                                AssetTransferHomeObj.AssetTransferDTObj.TransferQty = 0;

                                if (AssetTransferHomeObj.AddDT(ORTransaction))
                                    Bool_CheckExecuteComplete = true;
                                else
                                    Bool_CheckExecuteComplete = false;
                            }
 * */
                            Bool_CheckExecuteComplete = Function_AddDataTransferToDB(ORTransaction);

                            if (Bool_CheckExecuteComplete)
                            {
                                ORTransaction.Commit();
                                SS_MyMessageBox.ShowBox("Receive data : " + sS_MaskedTextBox_TransferID.Text + " Complete", "Add Data Information", DialogMode.OkOnly, this.Name, "000001", Obj_TransferID, Global.Lang.Str_Language);
                                 
                                // Edit on 04-01-09
                               // RunControlHomeObj.SaveRunControlID("TransferRun", sS_MaskedTextBox_TransferID.Text);
                               RunControlHomeObj.SaveRunControlID_1("CurrentRun", sS_MaskedTextBox_TransferID.Text, 4); //External transfer use current runNo. field same with Internaltransfer (RunID=4)
                                ////////////

                                Global.Bool_CheckComplete = true;
                                Enm_StateForm = Enum_Mode.PreAdd;
                                Function_ExecuteTransaction(Enum_Mode.Cancel);
                                //goto DEFAULT;

                            }
                            else
                            {
                                SS_MyMessageBox.ShowBox("Cannot receive data : " + sS_MaskedTextBox_TransferID.Text, "Warning", DialogMode.OkOnly, this.Name, "000002", Obj_TransferID, Global.Lang.Str_Language);
                                Global.Bool_CheckComplete = false;
                                ORTransaction.Rollback();
                            }
                        }
                        else
                        {
                            SS_MyMessageBox.ShowBox("Please input Model in datagrid", "Warning", DialogMode.OkOnly,this.Name,"000008",Global.Lang.Str_Language);
                            sS_DataGridView_ExternalTransferOrder.Focus();
                            break;
                        }
                        break;

                    case Enum_Mode.PreEdit:
                        sS_MaskedTextBox_Remark.ReadOnly = false;
                        sS_MaskedTextBox_TransferID.ReadOnly = true;
                        sS_MaskedTextBox_FromFacCode.Focus();
                        sS_DataGridView_ExternalTransferOrder.ReadOnly = false;
                        sS_DataGridView_ExternalTransferOrder.Columns[0].ReadOnly = true;
                        Enm_StateForm = Enum_Mode.PreEdit;
                        break;

                    case Enum_Mode.Edit:
                        ORTransaction = Manager.Engine.BeginTransaction();

                        // 26-01-09 Edit depID////
                        AssetTransferHomeObj.AssetTransferHDObj.FromDeptID = "-";
                        AssetTransferHomeObj.AssetTransferHDObj.ToDeptID = "-";
                        ///////////

                        // Edit AssetTransferHD

                        AssetTransferHomeObj.AssetTransferHDObj.TransferID = sS_MaskedTextBox_TransferID.Text;
                        //AssetTransferHomeObj.AssetTransferHDObj.TransferDate = Convert.ToDateTime(sS_MaskedTextBox_Date.Text);
                        AssetTransferHomeObj.AssetTransferHDObj.TransferDate = Convert.ToDateTime(dateTimePicker_Date.Text);
                        AssetTransferHomeObj.AssetTransferHDObj.FromFacCode = sS_MaskedTextBox_FromFacCode.Text;
                        AssetTransferHomeObj.AssetTransferHDObj.ToFacCode = sS_MaskedTextBox_ToFacCode.Text;
                        AssetTransferHomeObj.AssetTransferHDObj.TransferType = Funciton_TransferType();
                        AssetTransferHomeObj.AssetTransferHDObj.Remark = sS_MaskedTextBox_Remark.Text;
                        AssetTransferHomeObj.AssetTransferHDObj.UserName = Global.ConfigDatabase.Str_UserID;
                        AssetTransferHomeObj.AssetTransferHDObj.TransferFlag = "E";
                        AssetTransferHomeObj.AssetTransferHDObj.StatusID = "NEW";

                        if (AssetTransferHomeObj.EditHD(ORTransaction))
                            Bool_CheckExecuteComplete = true;
                        else
                            Bool_CheckExecuteComplete = false;

                        //Delete AssetTransferSerial
                        qry = "DELETE FROM AssetTransferSerial " +
                                " WHERE TransferID = '" + sS_MaskedTextBox_TransferID.Text + "' ";
                        Manager.Engine.ExecuteCommand(qry);


                        //Delete AssetTransfer
                        qry = "DELETE FROM AssetTransfer " +
                                " WHERE TransferID = '" + sS_MaskedTextBox_TransferID.Text + "' ";
                        Manager.Engine.ExecuteCommand(qry);

                        //Delete AssetTransferDT
                        qry = "DELETE FROM AssetTransferDT " +
                                " WHERE TransferID = '" + sS_MaskedTextBox_TransferID.Text + "' ";
                        Manager.Engine.ExecuteCommand(qry);

                        //Delete Rows in table when user delete row from database
/*                        for (i = 0; i <= EditList.Count - 1; i++)
                        {
                            Value = (EditValue)EditList[i];
                            AssetTransferHomeObj.AssetTransferDTObj.TransferID = Value.Str_TransferID;
                            AssetTransferHomeObj.AssetTransferDTObj.TransferSeq = Value.Int_TransferSeq;
                            AssetTransferHomeObj.AssetTransferDTObj.ModelID = Value.Str_ModelID;

                            if (AssetTransferHomeObj.DeleteDT(ORTransaction))
                            {
                                Bool_CheckExecuteComplete = true;
                                Int_CountObjDTs--;
                            }
                            else
                                Bool_CheckExecuteComplete = false;

                        }
                        // Update AssetTransferDT when user edit data in row detail
                        for (i = 0; i <= Int_CountObjDTs - 1; i++)
                        {
                            AssetTransferHomeObj.AssetTransferDTObj.TransferID = sS_MaskedTextBox_TransferID.Text;
                            AssetTransferHomeObj.AssetTransferDTObj.TransferSeq = Convert.ToInt32(sS_DataGridView_ExternalTransferOrder[0, i].Value);
                            AssetTransferHomeObj.AssetTransferDTObj.ModelID = sS_DataGridView_ExternalTransferOrder[1, i].Value.ToString();
                            AssetTransferHomeObj.AssetTransferDTObj.OrderQty = Convert.ToInt32(sS_DataGridView_ExternalTransferOrder[3, i].Value);
                            AssetTransferHomeObj.AssetTransferDTObj.TransferPrice = Convert.ToDecimal(sS_DataGridView_ExternalTransferOrder[4, i].Value);
                            AssetTransferHomeObj.AssetTransferDTObj.TransferCost = Convert.ToDecimal(sS_DataGridView_ExternalTransferOrder[5, i].Value);
                            AssetTransferHomeObj.AssetTransferDTObj.Remark = Convert.ToString(sS_DataGridView_ExternalTransferOrder[6, i].Value);
                            AssetTransferHomeObj.AssetTransferDTObj.TransferQty = 0;

                            if (AssetTransferHomeObj.EditDT(ORTransaction))
                                Bool_CheckExecuteComplete = true;
                            else
                                Bool_CheckExecuteComplete = false;
                        }

                        //Insert row to database when user add row detail in datagrid

                        for (i = Int_CountObjDTs; i < sS_DataGridView_ExternalTransferOrder.Rows.Count - 1; i++)
                        {
                            AssetTransferHomeObj.AssetTransferDTObj.TransferID = sS_MaskedTextBox_TransferID.Text;
                            AssetTransferHomeObj.AssetTransferDTObj.TransferSeq = Convert.ToInt32(sS_DataGridView_ExternalTransferOrder[0, i].Value);
                            AssetTransferHomeObj.AssetTransferDTObj.ModelID = sS_DataGridView_ExternalTransferOrder[1, i].Value.ToString();
                            AssetTransferHomeObj.AssetTransferDTObj.OrderQty = Convert.ToInt32(sS_DataGridView_ExternalTransferOrder[3, i].Value);
                            AssetTransferHomeObj.AssetTransferDTObj.TransferPrice = Convert.ToDecimal(sS_DataGridView_ExternalTransferOrder[4, i].Value);
                            AssetTransferHomeObj.AssetTransferDTObj.TransferCost = Convert.ToDecimal(sS_DataGridView_ExternalTransferOrder[5, i].Value);
                            AssetTransferHomeObj.AssetTransferDTObj.Remark = Convert.ToString(sS_DataGridView_ExternalTransferOrder[6, i].Value);
                            AssetTransferHomeObj.AssetTransferDTObj.TransferQty = 0;

                            if (AssetTransferHomeObj.AddDT(ORTransaction))
                                Bool_CheckExecuteComplete = true;
                            else
                                Bool_CheckExecuteComplete = false;
                        }
*/
                        Bool_CheckExecuteComplete = Function_AddDataTransferToDB(ORTransaction);
                        if (Bool_CheckExecuteComplete)
                        {
                            ORTransaction.Commit();
                            SS_MyMessageBox.ShowBox("Edit data : " + sS_MaskedTextBox_TransferID.Text + "Complete", "Edit Data Information", DialogMode.OkOnly, this.Name, "000003", Obj_TransferID, Global.Lang.Str_Language);
                            
                            // Edit on 06-01-09 Editting, Don't update Current Running number
                            //RunControlHomeObj.SaveRunControlID("TransferRun", sS_MaskedTextBox_TransferID.Text);
                            
                            Global.Bool_CheckComplete = true;
                            //goto DEFAULT;
                        }
                        else
                        {
                            SS_MyMessageBox.ShowBox("Cannot edit data : " + sS_MaskedTextBox_TransferID.Text, "Warning", DialogMode.OkOnly, this.Name, "000004", Obj_TransferID, Global.Lang.Str_Language);
                            Global.Bool_CheckComplete = false;
                            
                            //ORTransaction.Rollback();
                        }
                        Enm_StateForm = Enum_Mode.Search;
                        Function_ExecuteTransaction(Enum_Mode.Cancel);

                        break;
                    case Enum_Mode.Delete:
                        if (SS_MyMessageBox.ShowBox("Do you want to delete : " + sS_MaskedTextBox_TransferID.Text + " ?", "Delete Data Information", DialogMode.OkCancel, this.Name, "000005", Obj_TransferID, Global.Lang.Str_Language) == DialogResult.OK)
                        {
                            ORTransaction = Manager.Engine.BeginTransaction();
                            Global.Bool_CheckComplete = true;
                            AssetTransferHomeObj.AssetTransferHDObj.TransferID = sS_MaskedTextBox_TransferID.Text;
                            AssetTransferHomeObj.AssetTransferHDObj.TransferDate = Convert.ToDateTime(dateTimePicker_Date.Text);
                            AssetTransferHomeObj.AssetTransferHDObj.Remark = sS_MaskedTextBox_Remark.Text;
                            AssetTransferHomeObj.AssetTransferHDObj.UserName = Global.ConfigDatabase.Str_UserID;
                            AssetTransferHomeObj.AssetTransferHDObj.FromFacCode = sS_MaskedTextBox_FromFacCode.Text;
                            AssetTransferHomeObj.AssetTransferHDObj.ToFacCode = sS_MaskedTextBox_FromFacCode.Text;
                            AssetTransferHomeObj.AssetTransferHDObj.TransferFlag = "E";
                            AssetTransferHomeObj.AssetTransferHDObj.TransferType = Funciton_TransferType();
                            AssetTransferHomeObj.AssetTransferHDObj.StatusID = "DELETE";

                            if (AssetTransferHomeObj.EditHD(ORTransaction))
//                            if (AssetTransferHomeObj.Delete())
                                SS_MyMessageBox.ShowBox("Delete data : " + sS_MaskedTextBox_TransferID.Text + "complete", "Delete Data Information", DialogMode.OkOnly, this.Name, "000006", Obj_TransferID, Global.Lang.Str_Language);
                            else
                                SS_MyMessageBox.ShowBox("Cannot delete data : " + sS_MaskedTextBox_TransferID.Text + " !", "Warning", DialogMode.OkOnly, this.Name, "000007", Obj_TransferID, Global.Lang.Str_Language);
                        }
                        //else
                        //{
                        //    Global.Bool_CheckComplete = false;
                        //    Enm_StateForm = Enum_Mode.PreEdit;
                        //    Function_ExecuteTransaction(Enum_Mode.Cancel);
                        //}
                        //break;
                        goto DEFAULT;
                       
                    case Enum_Mode.ShowData:

                        Manager.Engine.ClearTracking();
                        AssetTransferHomeObj.AssetTransferHDObj = Manager.Engine.GetObject<AssetTransferHD>(sS_MaskedTextBox_TransferID.Text);

                        sS_MaskedTextBox_TransferID.Text = AssetTransferHomeObj.AssetTransferHDObj.TransferID;
                        //sS_MaskedTextBox_Date.Text = AssetTransferHomeObj.AssetTransferHDObj.TransferDate.ToShortDateString();
                        dateTimePicker_Date.Text = AssetTransferHomeObj.AssetTransferHDObj.TransferDate.ToShortDateString();
                        sS_ComboBox_TransferType.SelectedIndex = Function_GetTypeIndex(AssetTransferHomeObj.AssetTransferHDObj.TransferType);
                        sS_MaskedTextBox_FromFacCode.Text = AssetTransferHomeObj.AssetTransferHDObj.FromFacCode;
                        sS_MaskedTextBox_FromFacName.Text = Global.FormOrder.Function_GetFacName(AssetTransferHomeObj.AssetTransferHDObj.FromFacCode);
                        sS_MaskedTextBox_ToFacCode.Text = AssetTransferHomeObj.AssetTransferHDObj.ToFacCode;
                        sS_MaskedTextBox_ToFacName.Text = Global.FormOrder.Function_GetFacName(AssetTransferHomeObj.AssetTransferHDObj.ToFacCode);
                        sS_MaskedTextBox_Remark.Text = AssetTransferHomeObj.AssetTransferHDObj.Remark;

                        //เก็บจำนวน Detail ก่อนทำการแก้ไข
/*                        Int_CountObjDTs = AssetTransferHomeObj.AssetTransferHDObj.AssetTransferDTs.Count;
                        sS_DataGridView_ExternalTransferOrder.Rows.Clear();

                        //Loop Add Detail to Datagrid

                        if (AssetTransferHomeObj.AssetTransferHDObj.AssetTransferDTs.Count == 0)//กรณีเป็น 0 เมื่อทำการ save และทำการโหลดข้อมูลเลยแล้วไม่โชว์ Datails
                        {
                            Wilson.ORMapper.ObjectSet<AssetTransferDT> AssetTransferObj = Manager.Engine.GetObjectSet<AssetTransferDT>("TransferID ='" + sS_MaskedTextBox_TransferID.Text + "'");
                            for (int j = 0; j < AssetTransferObj.Count; j++)
                            {
                                Object[] rows = new Object[]{AssetTransferObj[j].TransferSeq,AssetTransferObj[j].ModelID,Global.FormOrder.Function_GetModelName(AssetTransferObj[j].ModelID),
                                    AssetTransferObj[j].OrderQty,AssetTransferObj[j].TransferPrice,
                                    AssetTransferObj[j].TransferCost,AssetTransferObj[j].Remark};

                                sS_DataGridView_ExternalTransferOrder.Rows.Add(rows);
                                sS_DataGridView_ExternalTransferOrder.Sort(sS_DataGridView_ExternalTransferOrder.Columns[0], ListSortDirection.Ascending);
                            }
                        }
                        else
                        {
                            for (i = 0; i < AssetTransferHomeObj.AssetTransferHDObj.AssetTransferDTs.Count; i++)
                            {
                                AssetTransferHomeObj.AssetTransferDTObj = (AssetTransferDT)AssetTransferHomeObj.AssetTransferHDObj.AssetTransferDTs[i];
                                Object[] rows = new Object[] {AssetTransferHomeObj.AssetTransferDTObj.TransferSeq,
                                                           AssetTransferHomeObj.AssetTransferDTObj.ModelID,Global.FormOrder.Function_GetModelName(AssetTransferHomeObj.AssetTransferDTObj.ModelID),
                                                            AssetTransferHomeObj.AssetTransferDTObj.OrderQty,
                                                            AssetTransferHomeObj.AssetTransferDTObj.TransferPrice,
                                                            AssetTransferHomeObj.AssetTransferDTObj.TransferCost,
                                                            AssetTransferHomeObj.AssetTransferDTObj.Remark};

                                sS_DataGridView_ExternalTransferOrder.Rows.Add(rows);
                                sS_DataGridView_ExternalTransferOrder.Sort(sS_DataGridView_ExternalTransferOrder.Columns[0], ListSortDirection.Ascending);
                            }
                        }
 */
                        //เก็บจำนวน Detail ก่อนทำการแก้ไข ::: CEVA
                        sS_DataGridView_ExternalTransferOrder.Rows.Clear();

                        //Loop Add Detail to Datagrid
                        Wilson.ORMapper.ObjectSet<AssetTransferDT> AssetTransferDTObj = Manager.Engine.GetObjectSet<AssetTransferDT>("TransferID = '" + sS_MaskedTextBox_TransferID.Text + "'");
                        string whCondition = "TransferID = '" + sS_MaskedTextBox_TransferID.Text + "'";
                        for (i = 0; i < AssetTransferDTObj.Count; i++)
                        {
                            AssetTransferHomeObj.AssetTransferDTObj = (AssetTransferDT)AssetTransferHomeObj.AssetTransferHDObj.AssetTransferDTs[i];
                            string modelCon = " AND ModelID = '" + AssetTransferHomeObj.AssetTransferDTObj.ModelID + "'";
                            Wilson.ORMapper.ObjectSet<AssetTransferSerial> AssetTransferObj = Manager.Engine.GetObjectSet<AssetTransferSerial>(whCondition + modelCon);
                            for (j = 0; j < AssetTransferObj.Count; j++)
                            {
                                //Object[] rows = new Object[] {AssetTransferObj[j].TransferLine,
                                //                            AssetTransferObj[j].ModelID,
                                //                            Global.FormOrder.Function_GetModelName(AssetTransferObj[j].ModelID),
                                //                            AssetTransferObj[j].AssetID,
                                //                            Global.FormOrder.Function_GetAssetPrice(AssetTransferObj[j].AssetID),
                                //                            Global.FormOrder.Function_GetAssetPrice(AssetTransferObj[j].AssetID),
                                //                            AssetTransferObj[j].Remark};

                               
                                //Edit on 06-01-09 for CEVA
                                Object[] rows = new Object[] {AssetTransferObj[j].TransferLine,
                                                            AssetTransferObj[j].AssetID,
                                                            AssetTransferObj[j].ModelID,
                                                            Global.FormOrder.Function_GetModelName(AssetTransferObj[j].ModelID),
                                                            Global.FormOrder.Function_GetAssetPrice(AssetTransferObj[j].AssetID),
                                                            Global.FormOrder.Function_GetAssetPrice(AssetTransferObj[j].AssetID),
                                                            AssetTransferObj[j].Remark};

                                sS_DataGridView_ExternalTransferOrder.Rows.Add(rows);
                                sS_DataGridView_ExternalTransferOrder.Sort(sS_DataGridView_ExternalTransferOrder.Columns[0], ListSortDirection.Ascending);
                                Int_CountObjDTs++;
                            }
                        }

                        Global.Function_ToolStripSetUP(Enum_Mode.CellClick);
                        sS_MaskedTextBox_TransferID.ReadOnly = true;
                        break;
                    case Enum_Mode.Cancel:
                        if (Enm_StateForm == Enum_Mode.PreEdit)
                        {
                            Function_ExecuteTransaction(Enum_Mode.ShowData);
                            sS_MaskedTextBox_TransferID.Focus();
                        }
                        if (Enm_StateForm == Enum_Mode.PreAdd)
                        {
                            Function_ClearData();
                            sS_MaskedTextBox_TransferID.Focus();
                        }
                        
                        Function_ReadOnlyControl(true);
                        Function_EnableControl(false);
                        sS_DataGridView_ExternalTransferOrder.ReadOnly = true;
                        Enm_StateForm = Enum_Mode.Search;
                        break;
                        //goto DEFAULT;
                    DEFAULT:
                        Enm_StateForm = Enum_Mode.Search;
                        Function_ClearData();
                        sS_MaskedTextBox_TransferID.ReadOnly = false;
                        sS_MaskedTextBox_TransferID.Focus();
                        break;
                }
            }
            catch (Exception Ex)
            {
                SS_MyMessageBox.ShowBox(Ex.Message, "Error on Internal Transfer Order Execute Transaction", DialogMode.Error_Cancel, Ex);
            }
        }
        private string Funciton_TransferType()
        {
            string Str_TempTransferType = "";
            switch (sS_ComboBox_TransferType.SelectedIndex)
            {
                case 0:
                    Str_TempTransferType = "Transfer";
                    break;
                //case 1:
                //    Str_TempTransferType = "OUT";
                //    break;
            }
           Str_TempTransferType = ((System.Data.DataRowView)(sS_ComboBox_TransferType.SelectedItem)).Row.ItemArray[0].ToString(); // Type ID
           // Str_TempTransferType = ((System.Data.DataRowView)(sS_ComboBox_TransferType.SelectedItem)).Row.ItemArray[1].ToString(); // Type Name
            return Str_TempTransferType;
        }

        private int Function_GetTypeIndex(string Str_TempTransferType)
        {
            for (int i = 0; i < sS_ComboBox_TransferType.Items.Count; i++)
            {
                string tmp = ((System.Data.DataRowView)sS_ComboBox_TransferType.Items[i]).Row.ItemArray[0].ToString();
                if (Str_TempTransferType == tmp)
                    return i;
            }

            return 0;
        }


        private void sS_DataGridView_ExternalTransferOrder_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Global.FormOrder.Function_PlusLineInDataGrid(e, sS_DataGridView_ExternalTransferOrder, Enm_StateForm);
        }

        private void sS_MaskedTextBox_TransferID_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {
                    Global.FormOrder.Function_ShowFormSearch(Enum_TypeSearch.ExTransfer);
                    sS_MaskedTextBox_TransferID.Text = Global.ReturnValue.Str_FormSearch;
                    if (Global.ReturnValue.Str_FormSearch != "")
                    {
                        Function_ExecuteTransaction(Enum_Mode.ShowData);
                    }
                }
            }
            catch (Exception Ex)
            {
                SS_MyMessageBox.ShowBox(Ex.Message, "Error On Internal Transfer Order Select PO", DialogMode.Error_Cancel, Ex);
            }
        }

        private void sS_DataGridView_ExternalTransferOrder_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            Global.FormOrder.Function_ShiftRowsWhenDelete(e, sS_DataGridView_ExternalTransferOrder, Enm_StateForm);
        }

        private void sS_DataGridView_ExternalTransferOrder_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            if (sS_DataGridView_ExternalTransferOrder.Rows.Count != 0)
            {
                if (Convert.ToInt32(e.Row.Cells[0].Value) <= Int_CountObjDTs)
                {
                    Value.Str_TransferID = sS_MaskedTextBox_TransferID.Text;
                    Value.Int_TransferLine = Convert.ToInt32(e.Row.Cells[0].Value);
                    Value.Str_ModelID = e.Row.Cells[1].Value.ToString();
                    Value.Str_AssetID = e.Row.Cells[3].Value.ToString();
                    EditList.Add(Value);
                }
            }
        }

        private void sS_DataGridView_ExternalTransferOrder_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Global.FormOrder.Function_MultiplyPriceAndQty(e, sS_DataGridView_ExternalTransferOrder);
        }

        private void sS_MaskedTextBox_FromFacCode_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.F1) && ((Enm_StateForm == Enum_Mode.PreAdd) || (Enm_StateForm == Enum_Mode.PreEdit)))
            {
                SimatSoft.QueryManager.Form_Present Frm_Present = new SimatSoft.QueryManager.Form_Present();
                Frm_Present.Controlreturnvalue = sS_MaskedTextBox_FromFacCode;
                Frm_Present.Controlreturnvalue2 = sS_MaskedTextBox_FromFacName;
                Frm_Present.Show_Data("Screen", "002006");

                Frm_Present.ShowDialog();
                Frm_Present.Dispose();
            }
        }

        private void sS_MaskedTextBox_ToFacCode_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.F1) && ((Enm_StateForm == Enum_Mode.PreAdd) || (Enm_StateForm == Enum_Mode.PreEdit)))
            {
                SimatSoft.QueryManager.Form_Present Frm_Present = new SimatSoft.QueryManager.Form_Present();
                Frm_Present.Controlreturnvalue = sS_MaskedTextBox_ToFacCode;
                Frm_Present.Controlreturnvalue2 = sS_MaskedTextBox_ToFacName;
                Frm_Present.Show_Data("Screen", "002006");

                Frm_Present.ShowDialog();
                Frm_Present.Dispose();
            }
        }

        private void sS_DataGridView_ExternalTransferOrder_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
          /*  if ((e.ColumnIndex == 1)&&((Enm_StateForm ==Enum_Mode.PreAdd)||(Enm_StateForm ==Enum_Mode.PreEdit)))
            {
                SimatSoft.QueryManager.Form_Present Frm_Present = new SimatSoft.QueryManager.Form_Present();
                Frm_Present.Show_Data("Screen", "002002");
                TextBox TempTextBox = new TextBox();
                TextBox TempTextBox2 = new TextBox();
                //TextBox TempTextBox3 = new TextBox();
                Frm_Present.Controlreturnvalue = TempTextBox;
                Frm_Present.Controlreturnvalue2 = TempTextBox2;
                //Frm_Present.Controlreturnvalue3 = TempTextBox3;
                Frm_Present.ShowDialog();

                sS_DataGridView_ExternalTransferOrder[1, sS_DataGridView_ExternalTransferOrder.CurrentRow.Index].Value = TempTextBox.Text;
                sS_DataGridView_ExternalTransferOrder[2, sS_DataGridView_ExternalTransferOrder.CurrentRow.Index].Value = TempTextBox2.Text;
                //sS_DataGridView_ExternalTransferOrder[4, sS_DataGridView_ExternalTransferOrder.CurrentRow.Index].Value = TempTextBox3.Text;
                Frm_Present.Dispose();

                //sS_DataGridView_ExternalTransferOrder.CurrentCell = sS_DataGridView_ExternalTransferOrder[3, sS_DataGridView_ExternalTransferOrder.CurrentRow.Index];
            }*/
            // Asset ID + Price & Cost with qty = 1
            //if ((e.ColumnIndex == 3) && ((Enm_StateForm == Enum_Mode.PreAdd) || (Enm_StateForm == Enum_Mode.PreEdit)))
            if ((e.ColumnIndex == 1) && ((Enm_StateForm == Enum_Mode.PreAdd) || (Enm_StateForm == Enum_Mode.PreEdit)))
            {
                SimatSoft.QueryManager.Form_Present Frm_Present = new SimatSoft.QueryManager.Form_Present();

                TextBox TempTextBox3 = new TextBox();
                TextBox TempTextBox4 = new TextBox();
                Frm_Present.Controlreturnvalue = TempTextBox3;
                Frm_Present.Controlreturnvalue6 = TempTextBox4;

                //string qry = " modelid = '" + sS_DataGridView_ExternalTransferOrder[1, sS_DataGridView_ExternalTransferOrder.CurrentRow.Index].Value.ToString() + "'";
                //Frm_Present.Show_Data("Screen", "002001",qry);
                //Frm_Present.ShowDialog();

                //eEdit on 25-12-08 

                string qry = " FacCode = '" + sS_MaskedTextBox_FromFacCode.Text.Trim() + "' ";
                Frm_Present.Show_Data("Screen", "002001", qry);
               
                Frm_Present.ShowDialog();
                string str_sql = "SELECT Model.modelID,Model.modelName FROM Asset INNER JOIN Model ON Asset.modelID = Model.modelID AND Asset.AssetID = '" + TempTextBox3.Text + "' ";
                DataSet Ds = Manager.Engine.GetDataSet(str_sql);
                if (Ds.Tables[0].Rows.Count > 0)
                {
                    sS_DataGridView_ExternalTransferOrder[2, sS_DataGridView_ExternalTransferOrder.CurrentRow.Index].Value = Ds.Tables[0].Rows[0][0].ToString().Trim(); // ModelID.
                    sS_DataGridView_ExternalTransferOrder[3, sS_DataGridView_ExternalTransferOrder.CurrentRow.Index].Value = Ds.Tables[0].Rows[0][1].ToString().Trim(); // ModelName.
                }
                else
                {
                    sS_DataGridView_ExternalTransferOrder[2, sS_DataGridView_ExternalTransferOrder.CurrentRow.Index].Value = "-"; // ModelID.
                    sS_DataGridView_ExternalTransferOrder[3, sS_DataGridView_ExternalTransferOrder.CurrentRow.Index].Value = "-"; // ModelName.
                }


                sS_DataGridView_ExternalTransferOrder[1, sS_DataGridView_ExternalTransferOrder.CurrentRow.Index].Value = TempTextBox3.Text;
                sS_DataGridView_ExternalTransferOrder[4, sS_DataGridView_ExternalTransferOrder.CurrentRow.Index].Value = TempTextBox4.Text;
                sS_DataGridView_ExternalTransferOrder[5, sS_DataGridView_ExternalTransferOrder.CurrentRow.Index].Value = TempTextBox4.Text;
                Frm_Present.Dispose();

                sS_DataGridView_ExternalTransferOrder.CurrentCell = sS_DataGridView_ExternalTransferOrder[6, sS_DataGridView_ExternalTransferOrder.CurrentRow.Index];

            }
            Function_ReadOnlyControlDatagrid(true);
        }

        private void Form_001005_ExternalTransferOrder_Activated(object sender, EventArgs e)
        {
            AuthorizeState.Funtion_SetButtonAuthorize(Enm_StateForm);
        }

        private void Form_001005_ExternalTransferOrder_Load(object sender, EventArgs e)
        {
            Global.Location.Int_CountForm = Global.Location.Int_CountForm + 0;
            Function_ClearData();
            sS_DataGridView_ExternalTransferOrder.ReadOnly = true;
            sS_MaskedTextBox_TransferID.ReadOnly = true;
            Function_ReadOnlyControl(true);
            Function_EnableControl(false);
            Function_InsertInfoToDatagrid();
        }

        private void Form_001005_ExternalTransferOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Global.Location.Int_CountForm > 0)
            {
                Global.Location.Int_CountForm = Global.Location.Int_CountForm - 1;
            }
            AuthorizeState.Funtion_SetButtonAuthorize(Enum_Mode.SetDefault);
        }

        private void Function_InsertInfoToDatagrid()
        {
            sS_DataGridView_Table.Rows.Clear();

            Object[] Rows = new Object[] { "Buildings", "", "", "", "", "", "" };
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

        private void Function_ManageData()
        {
            int i = 0;
            string qry = "DELETE FROM TMPAssetTransferDaTa";

            Manager.Engine.ExecuteCommand(qry);

            // Loop for Add TMPAssetTransferData
            for (i = 0; i < sS_DataGridView_ExternalTransferOrder.Rows.Count - 1; i++)
            {
                string trnid, modelid, assetid, trncost, trnprice, trnline;

                trnid = sS_MaskedTextBox_TransferID.Text;
                trnline = sS_DataGridView_ExternalTransferOrder[0, i].Value.ToString();
                modelid = sS_DataGridView_ExternalTransferOrder[2, i].Value.ToString();
                assetid = sS_DataGridView_ExternalTransferOrder[1, i].Value.ToString();
                trnprice = sS_DataGridView_ExternalTransferOrder[4, i].Value.ToString();
                trncost = sS_DataGridView_ExternalTransferOrder[5, i].Value.ToString();

                try
                {
                    qry = "INSERT INTO TMPAssetTransferDaTa (TransferID, TransferLine, modelID, assetID, TransferCost, TransferPrice) " +
                    "VALUES ('" + trnid + "'," + trnline + ",'" + modelid + "','" + assetid + "'," + trncost + "," + trnprice + ")";

                    Manager.Engine.ExecuteCommand(qry);
                }
                catch { }
            }



        }

        private void sS_DataGridView_Table_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 2) || (e.ColumnIndex == 3))
            {
                double cost = 0.0;
                double accm = 0.0;
                double dif = 0.0;
                cost = GetDoubleDataFromGrid(2, e.RowIndex, sS_DataGridView_Table);
                accm = GetDoubleDataFromGrid(3, e.RowIndex, sS_DataGridView_Table);
                dif = cost - accm;

                // Edit Price Format on 12-03-09
                //sS_DataGridView_Table[4, e.RowIndex].Value = dif.ToString();
                sS_DataGridView_Table[4, e.RowIndex].Value = string.Format("{0:#,0.00}", Convert.ToDouble(dif));
                //sS_DataGridView_Table[5, e.RowIndex].Value = dif.ToString();
                sS_DataGridView_Table[5, e.RowIndex].Value = string.Format("{0:#,0.00}", Convert.ToDouble(dif));
                sS_DataGridView_Table[6, e.RowIndex].Value = "0.00";

                //// Additional Price Format on 12-03-09
                sS_DataGridView_Table[2, e.RowIndex].Value = string.Format("{0:#,0.00}", Convert.ToDouble(cost));
                sS_DataGridView_Table[3, e.RowIndex].Value = string.Format("{0:#,0.00}", Convert.ToDouble(accm));

                for (int j = 4; j <= 6; j++)
                {
                    double total = 0.0, value = 0.0;
                    for (int i = 0; i < 4; i++)
                    {
                        value = GetDoubleDataFromGrid(j, i, sS_DataGridView_Table);
                        total += value;
                    }
                    // sS_DataGridView_Table[j, 4].Value = total.ToString();
                    sS_DataGridView_Table[j, 4].Value = string.Format("{0:#,0.00}", Convert.ToDouble(total));
                }

            }

            if ((e.ColumnIndex == 4) || (e.ColumnIndex == 5))
            {
                double NetBook = 0.0;
                double Transfer = 0.0;
                double dif = 0.0;
                NetBook = GetDoubleDataFromGrid(4, e.RowIndex, sS_DataGridView_Table);
                Transfer = GetDoubleDataFromGrid(5, e.RowIndex, sS_DataGridView_Table);
                dif = Transfer - NetBook;

                //sS_DataGridView_Table[6, e.RowIndex].Value = dif.ToString();
                sS_DataGridView_Table[6, e.RowIndex].Value = string.Format("{0:#,0.00}", Convert.ToDouble(dif));
                
                // Additional
                sS_DataGridView_Table[4, e.RowIndex].Value = string.Format("{0:#,0.00}", Convert.ToDouble(NetBook));
                sS_DataGridView_Table[5, e.RowIndex].Value = string.Format("{0:#,0.00}", Convert.ToDouble(Transfer));
                
                for (int j = 4; j <= 6; j++)
                {
                    double total = 0.0, value = 0.0;
                    for (int i = 0; i < 4; i++)
                    {
                        value = GetDoubleDataFromGrid(j, i, sS_DataGridView_Table);
                        total += value;
                    }
                    // sS_DataGridView_Table[j, 4].Value = total.ToString();
                    sS_DataGridView_Table[j, 4].Value = string.Format("{0:#,0.00}", Convert.ToDouble(total));
                }

            }

            if ((e.ColumnIndex != 1) && (e.ColumnIndex != 6))
            {
                double total = 0.0, value = 0.0;
                for (int i = 0; i < 4; i++)
                {
                    try
                    {
                        value = Convert.ToDouble(sS_DataGridView_Table[e.ColumnIndex, i].Value);
                    }
                    catch
                    {
                        value = 0.0;
                    }
                    total += value;
                }
                // sS_DataGridView_Table[e.ColumnIndex, 4].Value = total.ToString();
                sS_DataGridView_Table[e.ColumnIndex, 4].Value = string.Format("{0:#,0.00}", Convert.ToDouble(total));
            }

        }

        private double GetDoubleDataFromGrid(int iCol, int iRow, SS_DataGridView sGrid)
        {
            double result = 0.0;

            try
            {
                result = Convert.ToDouble(sGrid[iCol, iRow].Value);
            }
            catch { }

            return result;
        }

        private void sS_ButtonGlass1_Click(object sender, EventArgs e)
        {
            SimatSoft.ReportManagerWinForm.Class_SimatReport_WinForm Cls_Report = new SimatSoft.ReportManagerWinForm.Class_SimatReport_WinForm();
            Cls_Report.Engine = SimatSoft.DB.ORM.Manager.Engine;
            Cls_Report.Dbname = Global.ConfigDatabase.Str_Database;
            Cls_Report.Username = Global.ConfigDatabase.Str_UserServerName;
            Cls_Report.UserPassword = Global.ConfigDatabase.Str_Password;
            Cls_Report.Servername = "ReportRM";
            Cls_Report.SelectionFormula = "{AssetTransferHD.TransferId} = '" + sS_MaskedTextBox_TransferID.Text + "'";

            // Put data to parameter
            object[] ObjParam = new object[36] { "@DocName",
                                                 "@DocNo",
                                                 "@DocNumber",
                                                 "@BU_From",
                                                 "@BU_To",
                                                 "@CreateDate",
                                                 "@BU",
                                                 "@R1C1","@R1C2","@R1C3","@R1C4","@R1C5","@R1C6",
                                                 "@R2C1","@R2C2","@R2C3","@R2C4","@R2C5","@R2C6",
                                                 "@R3C1","@R3C2","@R3C3","@R3C4","@R3C5","@R3C6",
                                                 "@R4C1","@R4C2","@R4C3","@R4C4","@R4C5","@R4C6",
                                                         "@R5C2","@R5C3","@R5C4","@R5C5","@R5C6"};

            string DocType, DocName, DocNo, DocNum, BUFrom, BUTo, CreateDt, BU, R1, R2, R3, R4;
            double R12, R13, R14, R15, R16, R22, R23, R24, R25, R26, R32, R33, R34, R35, R36;
            double R42, R43, R44, R45, R46, R52, R53, R54, R55, R56;

            DocName = DocNo = DocNum = BUFrom = BUTo = CreateDt = BU = R1 = R2 = R3 = R4 = "";
            R12 = R13 = R14 = R15 = R16 = R22 = R23 = R24 = R25 = R26 = R32 = R33 = R34 = R35 = R36 = 0;
            R42 = R43 = R44 = R45 = R46 = R52 = R53 = R54 = R55 = R56 = 0;

            // Doc Name
            DocType = ((DataRowView)(sS_ComboBox_TransferType.SelectedItem)).Row.ItemArray[1].ToString();
            DocName = DocType + " REQUEST";

            // Doc No , Create Date
            dateTimePicker_Date.Format = DateTimePickerFormat.Short;
            CreateDt = dateTimePicker_Date.Text;
            string year = CreateDt.Substring(CreateDt.Length - 4, 4);
            DocNo = DocType + " Request No.";
            DocNum = sS_MaskedTextBox_TransferID.Text;

            // BU From
            BUFrom = sS_MaskedTextBox_FromFacName.Text + " (" + sS_MaskedTextBox_FromFacCode.Text + ")";

            // BU To
            BUTo = sS_MaskedTextBox_ToFacName.Text + " (" + sS_MaskedTextBox_ToFacCode.Text + ")";

            // BU
            BU = sS_MaskedTextBox_FromFacCode.Text;

            // Data in Table 
            // 1st Column
            R1 = sS_DataGridView_Table[1, 0].Value.ToString();
            R2 = sS_DataGridView_Table[1, 1].Value.ToString();
            R3 = sS_DataGridView_Table[1, 2].Value.ToString();
            R4 = sS_DataGridView_Table[1, 3].Value.ToString();

            // 2nd Column
            R12 = GetDoubleDataFromGrid(2, 0, sS_DataGridView_Table);
            R22 = GetDoubleDataFromGrid(2, 1, sS_DataGridView_Table);
            R32 = GetDoubleDataFromGrid(2, 2, sS_DataGridView_Table);
            R42 = GetDoubleDataFromGrid(2, 3, sS_DataGridView_Table);
            R52 = GetDoubleDataFromGrid(2, 4, sS_DataGridView_Table);

            // 3rd Column
            R13 = GetDoubleDataFromGrid(3, 0, sS_DataGridView_Table);
            R23 = GetDoubleDataFromGrid(3, 1, sS_DataGridView_Table);
            R33 = GetDoubleDataFromGrid(3, 2, sS_DataGridView_Table);
            R43 = GetDoubleDataFromGrid(3, 3, sS_DataGridView_Table);
            R53 = GetDoubleDataFromGrid(3, 4, sS_DataGridView_Table);

            // 4st Column
            R14 = GetDoubleDataFromGrid(4, 0, sS_DataGridView_Table);
            R24 = GetDoubleDataFromGrid(4, 1, sS_DataGridView_Table);
            R34 = GetDoubleDataFromGrid(4, 2, sS_DataGridView_Table);
            R44 = GetDoubleDataFromGrid(4, 3, sS_DataGridView_Table);
            R54 = GetDoubleDataFromGrid(4, 4, sS_DataGridView_Table);

            // 5st Column
            R15 = GetDoubleDataFromGrid(5, 0, sS_DataGridView_Table);
            R25 = GetDoubleDataFromGrid(5, 1, sS_DataGridView_Table);
            R35 = GetDoubleDataFromGrid(5, 2, sS_DataGridView_Table);
            R45 = GetDoubleDataFromGrid(5, 3, sS_DataGridView_Table);
            R55 = GetDoubleDataFromGrid(5, 4, sS_DataGridView_Table);

            // 6st Column
            R16 = GetDoubleDataFromGrid(6, 0, sS_DataGridView_Table);
            R26 = GetDoubleDataFromGrid(6, 1, sS_DataGridView_Table);
            R36 = GetDoubleDataFromGrid(6, 2, sS_DataGridView_Table);
            R46 = GetDoubleDataFromGrid(6, 3, sS_DataGridView_Table);
            R56 = GetDoubleDataFromGrid(6, 4, sS_DataGridView_Table);



            object[] ObjValue = new object[36] { DocName, DocNo, DocNum, BUFrom, BUTo, CreateDt, BU,
                                                 R1,R12,R13,R14,R15,R16,
                                                 R2,R22,R23,R24,R25,R26,
                                                 R3,R32,R33,R34,R35,R36,
                                                 R4,R42,R43,R44,R45,R46,
                                                 R52,R53,R54,R55,R56 };



            Cls_Report.DisplayReport("TransferOrderForm-Q.xml", this.MdiParent, ObjParam, ObjValue);
            dateTimePicker_Date.Format = DateTimePickerFormat.Long;

        }

        private bool Function_AddDataTransferToDB(Wilson.ORMapper.Transaction ORTransaction)
        {
            AssetTransferHome AssetTransferHomeObj = new AssetTransferHome();
            bool Bool_CheckExecuteComplete = false;

            int i = 0;
            // Loop for Add AssetTransferDT & AssetTransfer (Initial)
            Function_ManageData();

            string qry = "SELECT modelID, count(modelID),SUM(TransferCost), SUM(TransferPrice) From TMPAssetTransferDaTa " +
                "Where TransferID = '" + sS_MaskedTextBox_TransferID.Text + "' Group By modelID";
           
            // Edit 26-12-08
            //string qry = "SELECT assetID AS modelID, count(assetID),SUM(TransferCost), SUM(TransferPrice) From TMPAssetTransferDaTa " +
            //    "Where TransferID = '" + sS_MaskedTextBox_TransferID.Text + "' Group By assetID";


            DataSet ds = new DataSet();
            ds = Manager.Engine.GetDataSet(qry);

            if (ds.Tables[0].Rows.Count > 0)
            {
                int seq = 1;
                for (i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    seq = i + 1;
                    AssetTransferHomeObj.AssetTransferDTObj.TransferID = sS_MaskedTextBox_TransferID.Text;
                    AssetTransferHomeObj.AssetTransferDTObj.TransferSeq = i + 1;
                    AssetTransferHomeObj.AssetTransferDTObj.ModelID = ds.Tables[0].Rows[i][0].ToString();
                    AssetTransferHomeObj.AssetTransferDTObj.OrderQty = Convert.ToInt32(ds.Tables[0].Rows[i][1]);
                    AssetTransferHomeObj.AssetTransferDTObj.TransferCost = Convert.ToDecimal(ds.Tables[0].Rows[i][2]);
                    AssetTransferHomeObj.AssetTransferDTObj.TransferPrice = Convert.ToDecimal(ds.Tables[0].Rows[i][3]);
                    AssetTransferHomeObj.AssetTransferDTObj.TransferQty = 0;

                    if (AssetTransferHomeObj.AddDT(ORTransaction))
                        Bool_CheckExecuteComplete = true;
                    else
                        Bool_CheckExecuteComplete = false;

                    AssetTransferHomeObj.AssetTransferObj.TransferID = sS_MaskedTextBox_TransferID.Text;
                    AssetTransferHomeObj.AssetTransferObj.TransferSeq = i + 1;
                    AssetTransferHomeObj.AssetTransferObj.ModelID = ds.Tables[0].Rows[i][0].ToString();
                    AssetTransferHomeObj.AssetTransferObj.TransferCost = Convert.ToDecimal(ds.Tables[0].Rows[i][2]);
                    AssetTransferHomeObj.AssetTransferObj.TransferPrice = Convert.ToDecimal(ds.Tables[0].Rows[i][3]);
                    AssetTransferHomeObj.AssetTransferObj.TransferQty = 0;

                    if (AssetTransferHomeObj.AddTransfer(ORTransaction))
                        Bool_CheckExecuteComplete = true;
                    else
                        Bool_CheckExecuteComplete = false;

                    string u_Qry = "UPDATE TMPAssetTransferDaTa SET TransferSeq = " + seq.ToString() +
                        " WHERE TransferID = '" + sS_MaskedTextBox_TransferID.Text + "' " +
                        " AND ModelID = '" + ds.Tables[0].Rows[i][0].ToString() + "'";
                    // Edit 26-12-08

                    //string u_Qry = "UPDATE TMPAssetTransferDaTa SET TransferSeq = " + seq.ToString() +
                    //    " WHERE TransferID = '" + sS_MaskedTextBox_TransferID.Text + "' " +
                    //    " AND assetID = '" + ds.Tables[0].Rows[i][0].ToString() + "'";


                    Manager.Engine.ExecuteCommand(u_Qry);
                }
                ds.Dispose();
            }

            // Loop for Add AssetTransferSerial
            for (i = 0; i < sS_DataGridView_ExternalTransferOrder.Rows.Count - 1; i++)
            {
                AssetTransferHomeObj.AssetTransferSerialObj.TransferID = sS_MaskedTextBox_TransferID.Text;
                AssetTransferHomeObj.AssetTransferSerialObj.TransferLine = Convert.ToInt32(sS_DataGridView_ExternalTransferOrder[0, i].Value);
                //AssetTransferHomeObj.AssetTransferSerialObj.ModelID = sS_DataGridView_ExternalTransferOrder[1, i].Value.ToString();
                //AssetTransferHomeObj.AssetTransferSerialObj.AssetID = sS_DataGridView_ExternalTransferOrder[3, i].Value.ToString();
                // Edit 26-12-08
                AssetTransferHomeObj.AssetTransferSerialObj.ModelID = sS_DataGridView_ExternalTransferOrder[2, i].Value.ToString();
                AssetTransferHomeObj.AssetTransferSerialObj.AssetID = sS_DataGridView_ExternalTransferOrder[1, i].Value.ToString();
                ///////
                AssetTransferHomeObj.AssetTransferSerialObj.AreaID = " ";
                try
                {
                    AssetTransferHomeObj.AssetTransferSerialObj.Remark = sS_DataGridView_ExternalTransferOrder[6, i].Value.ToString();
                }
                catch
                {
                    AssetTransferHomeObj.AssetTransferSerialObj.Remark = "-";
                }

                // Find TransferSeq
                string query = "SELECT TransferSeq From TMPAssetTransferDaTa " +
                    "Where TransferID = '" + sS_MaskedTextBox_TransferID.Text + "'  " +
                    "AND ModelID = '" + sS_DataGridView_ExternalTransferOrder[2, i].Value.ToString() + "'";
                // Edit 26-12-08
                //string query = "SELECT TransferSeq From TMPAssetTransferDaTa " +
                //   "Where TransferID = '" + sS_MaskedTextBox_TransferID.Text + "'  " +
                //   "AND assetID = '" + sS_DataGridView_ExternalTransferOrder[1, i].Value.ToString() + "'";
                ////////

                DataSet dsm = new DataSet();
                dsm = Manager.Engine.GetDataSet(query);
                if (dsm.Tables[0].Rows.Count > 0)
                {
                    AssetTransferHomeObj.AssetTransferSerialObj.TransferSeq = Convert.ToInt32(dsm.Tables[0].Rows[0][0]);
                }

                if (AssetTransferHomeObj.AddTransferSerial(ORTransaction))
                    Bool_CheckExecuteComplete = true;
                else
                    Bool_CheckExecuteComplete = false;
            }

            return Bool_CheckExecuteComplete;
        }

    }
 }