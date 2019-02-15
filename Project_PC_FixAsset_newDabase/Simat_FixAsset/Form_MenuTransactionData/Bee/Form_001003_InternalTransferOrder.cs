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
    public partial class Form_001003_InternalTransferOrder : SS_PaintGradientForm
    {
        POHome POHomeObj = new POHome();
        private int Int_CountObjDTs = 0;
        private string currentNo = "";
        System.Collections.ArrayList EditList = new System.Collections.ArrayList();
        private Enum_Mode Enm_StateForm = Enum_Mode.Search;
        Class_AuthorizeState AuthorizeState = new Class_AuthorizeState();
        EditValue Value = new EditValue();
        private struct EditValue
        {
            public string Str_TransferID;
            public int Int_TransferSeq;
            public string Str_ModelID;
        }

        public Form_001003_InternalTransferOrder()
        {
            InitializeComponent();
            DarkColor = Global.ConfigForm.Colr_BackColor;
            Function_IntitialControl();
            //Global.Function_ToolStripSetUP(Enum_Mode.Search);

            AuthorizeState.Function_SetAuthorize(this.Name.Substring(5, 6).Replace("0", ""));
            AuthorizeState.Funtion_SetButtonAuthorize(Enm_StateForm);
        }
        private void Function_IntitialControl()
        {
            this.Text = Global.Function_Language(this, this, "ID:001003(Internal Transfer Order)");
            LBL_TransferNo.Text = Global.Function_Language(this, LBL_TransferNo, " Transfer No:");
            LBL_Date.Text =Global.Function_Language(this,LBL_Date,"Date:");
            LBL_Type.Text = Global.Function_Language(this, LBL_Type, "Type:");
            LBL_FormDepartment.Text =Global.Function_Language(this,LBL_FormDepartment,"From Department:");
            LBL_ToDepartment.Text =Global.Function_Language(this,LBL_ToDepartment,"To Department:");
            LBL_Remark.Text =Global.Function_Language(this,LBL_Remark,"Remark:");
         }
        private void Form_001003_InternalTransferOrder_FormClosed(object sender, FormClosedEventArgs e)
        {
            Global.Function_RemoveTabStripButton(this.Tag);
        }
        private void Function_EnableControl(bool Bool_StateControl)
        {
            sS_ComboBox_TransferType.Enabled = Bool_StateControl;
            dateTimePicker_Date.Enabled = Bool_StateControl;
        }

        private void Function_ClearData()
        {
            sS_MaskedTextBox_TransferID.Text = "";
            sS_MaskedTextBox_FromDeptID.Text = "";
            sS_MaskedTextBox_FromDeptName.Text = "";
            sS_MaskedTextBox_ToDeptID.Text = "";
            sS_MaskedTextBox_ToDeptName.Text = "";
            sS_MaskedTextBox_Remark.Text = "";
            sS_MaskedTextBox_FromFacCode.Text = "";
            sS_MaskedTextBox_FromFacName.Text = "";
            sS_ComboBox_TransferType.SelectedIndex = 0;

            sS_DataGridView_InternalTransferOrder.Rows.Clear();
        }

        private void Function_ReadOnlyControlDatagrid(bool Bool_StateControl)
        {
            //sS_DataGridView_InternalTransferOrder.Columns[0].ReadOnly = Bool_StateControl;
            //sS_DataGridView_InternalTransferOrder.Columns[1].ReadOnly = Bool_StateControl;
            sS_DataGridView_InternalTransferOrder.Columns[2].ReadOnly = Bool_StateControl;
            sS_DataGridView_InternalTransferOrder.Columns[3].ReadOnly = Bool_StateControl;
            //sS_DataGridView_InternalTransferOrder.Columns[2].ReadOnly = Bool_StateControl;
            sS_DataGridView_InternalTransferOrder.Columns[4].ReadOnly = Bool_StateControl;
            //sS_DataGridView_InternalTransferOrder.Columns[5].ReadOnly = Bool_StateControl;
        }

        private void Function_ReadOnlyControl(bool Bool_StateControl)
        {
            sS_MaskedTextBox_FromDeptID.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_FromDeptName.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_ToDeptID.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_ToDeptName.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_Remark.ReadOnly = Bool_StateControl;
        }

        public void Function_ExecuteTransaction(Enum_Mode Enum_mode)
        {
            try
            {
                RunControlHome RunControlHomeObj = new RunControlHome();
                AssetTransferHome AssetTransferHomeObj = new AssetTransferHome();
                bool Bool_CheckExecuteComplete = false;
                Wilson.ORMapper.Transaction ORTransaction = null;
                int i = 0;
                object[] Obj_TransferID = new object[1] { sS_MaskedTextBox_TransferID.Text };

                switch (Enum_mode)
                {
                    case Enum_Mode.Search:
                        break;

                    case Enum_Mode.PreAdd:
                        Function_ClearData();
                        sS_MaskedTextBox_TransferID.ReadOnly = true;
                        Function_ReadOnlyControl(false);
                        Function_EnableControl(true);
                        sS_DataGridView_InternalTransferOrder.ReadOnly = false;

                        sS_MaskedTextBox_TransferID.Text = Function_GetNextRunningNo();
                        //sS_MaskedTextBox_TransferID.Text = RunControlHomeObj.Function_ExcuteGetrunningCommand("TransferRun");
                        sS_MaskedTextBox_FromDeptID.Focus();
                        Enm_StateForm = Enum_Mode.PreAdd;
                        break;

                    case Enum_Mode.Add:
                        
                        if (sS_DataGridView_InternalTransferOrder.Rows.Count > 1)
                        {
                            ORTransaction = Manager.Engine.BeginTransaction();
                            
                            //Add AssetTransferHD
                            AssetTransferHomeObj.AssetTransferHDObj.TransferID = sS_MaskedTextBox_TransferID.Text;
                            //AssetTransferHomeObj.AssetTransferHDObj.TransferDate =Convert.ToDateTime(sS_MaskedTextBox_Date.Text);
                            AssetTransferHomeObj.AssetTransferHDObj.TransferDate = Convert.ToDateTime(dateTimePicker_Date.Text);
                            AssetTransferHomeObj.AssetTransferHDObj.FromDeptID = sS_MaskedTextBox_FromDeptID.Text;
                            AssetTransferHomeObj.AssetTransferHDObj.ToDeptID = sS_MaskedTextBox_ToDeptID.Text;
                            AssetTransferHomeObj.AssetTransferHDObj.Remark = sS_MaskedTextBox_Remark.Text;
                            AssetTransferHomeObj.AssetTransferHDObj.UserName = Global.ConfigDatabase.Str_UserID;
                            AssetTransferHomeObj.AssetTransferHDObj.TransferFlag = "I";
                            AssetTransferHomeObj.AssetTransferHDObj.TransferType = Funciton_TransferType();
                            AssetTransferHomeObj.AssetTransferHDObj.StatusID = "NEW";
                            AssetTransferHomeObj.AssetTransferHDObj.FromFacCode = sS_MaskedTextBox_FromFacCode.Text;
                            AssetTransferHomeObj.AssetTransferHDObj.ToFacCode = sS_MaskedTextBox_FromFacCode.Text;

                            if (AssetTransferHomeObj.AddHD(ORTransaction))
                                Bool_CheckExecuteComplete = true;
                            else
                                Bool_CheckExecuteComplete = false;

                            // Loop for Add AssetTransferDT

                            for (i = 0; i < sS_DataGridView_InternalTransferOrder.Rows.Count - 1; i++)
                            {
                                AssetTransferHomeObj.AssetTransferDTObj.TransferID = sS_MaskedTextBox_TransferID.Text;
                                AssetTransferHomeObj.AssetTransferDTObj.TransferSeq = Convert.ToInt32(sS_DataGridView_InternalTransferOrder[0, i].Value);
                                AssetTransferHomeObj.AssetTransferDTObj.ModelID = sS_DataGridView_InternalTransferOrder[1, i].Value.ToString();
                                AssetTransferHomeObj.AssetTransferDTObj.OrderQty = Convert.ToInt32(sS_DataGridView_InternalTransferOrder[3, i].Value);
                                AssetTransferHomeObj.AssetTransferDTObj.TransferPrice = Convert.ToDecimal(sS_DataGridView_InternalTransferOrder[4, i].Value);
                                AssetTransferHomeObj.AssetTransferDTObj.TransferCost = Convert.ToDecimal(sS_DataGridView_InternalTransferOrder[5, i].Value);
                                AssetTransferHomeObj.AssetTransferDTObj.Remark = Convert.ToString(sS_DataGridView_InternalTransferOrder[6, i].Value);
                                AssetTransferHomeObj.AssetTransferDTObj.TransferQty = 0;

                                if (AssetTransferHomeObj.AddDT(ORTransaction))
                                    Bool_CheckExecuteComplete = true;
                                else
                                    Bool_CheckExecuteComplete = false;
                            }

                            if (Bool_CheckExecuteComplete)
                            {
                                Function_SaveCurrentRunningNo(currentNo);
                                ORTransaction.Commit();
                                SS_MyMessageBox.ShowBox("Receive data : " + sS_MaskedTextBox_TransferID.Text + " Complete", "Add Data Information", DialogMode.OkOnly, this.Name, "000001", Obj_TransferID, Global.Lang.Str_Language);
                                RunControlHomeObj.SaveRunControlID("TransferRun", sS_MaskedTextBox_TransferID.Text);
                                Global.Bool_CheckComplete = true;

                                Enm_StateForm = Enum_Mode.PreAdd;
                                Function_ExecuteTransaction(Enum_Mode.Cancel);
                                // goto DEFAULT;

                            }
                            else
                            {
                                SS_MyMessageBox.ShowBox("Can not receive data : " + sS_MaskedTextBox_TransferID.Text, "Warning", DialogMode.OkOnly, this.Name, "000002", Obj_TransferID, Global.Lang.Str_Language);
                                Global.Bool_CheckComplete = true;
                                ORTransaction.Rollback();
                            }
                        }
                        else
                        {
                            SS_MyMessageBox.ShowBox("Please input Model in cell grid", "Warning", DialogMode.OkOnly,this.Name,"000008",Global.Lang.Str_Language);
                            sS_DataGridView_InternalTransferOrder.Focus();
                            break;
                        }
                        break;

                    case Enum_Mode.PreEdit:
                        Function_ReadOnlyControl(false);
                        Function_EnableControl(true);
                        sS_MaskedTextBox_TransferID.ReadOnly = true;
                        sS_DataGridView_InternalTransferOrder.ReadOnly = false;
                        sS_DataGridView_InternalTransferOrder.Columns[0].ReadOnly = true;
                        Enm_StateForm = Enum_Mode.PreEdit;
                        break;

                    case Enum_Mode.Edit:
                        ORTransaction = Manager.Engine.BeginTransaction();

                        //Edit AssetTransferHD

                        AssetTransferHomeObj.AssetTransferHDObj.TransferID = sS_MaskedTextBox_TransferID.Text;
                        //AssetTransferHomeObj.AssetTransferHDObj.TransferDate = Convert.ToDateTime(sS_MaskedTextBox_Date.Text);
                        AssetTransferHomeObj.AssetTransferHDObj.TransferDate = Convert.ToDateTime(dateTimePicker_Date.Text);
                        AssetTransferHomeObj.AssetTransferHDObj.FromDeptID = sS_MaskedTextBox_FromDeptID.Text;
                        AssetTransferHomeObj.AssetTransferHDObj.ToDeptID = sS_MaskedTextBox_ToDeptID.Text;
                        AssetTransferHomeObj.AssetTransferHDObj.Remark = sS_MaskedTextBox_Remark.Text;
                        AssetTransferHomeObj.AssetTransferHDObj.UserName = Global.ConfigDatabase.Str_UserID;
                        AssetTransferHomeObj.AssetTransferHDObj.FromFacCode = sS_MaskedTextBox_FromFacCode.Text;
                        AssetTransferHomeObj.AssetTransferHDObj.ToFacCode = sS_MaskedTextBox_FromFacCode.Text;
                        AssetTransferHomeObj.AssetTransferHDObj.TransferFlag = "I";
                        AssetTransferHomeObj.AssetTransferHDObj.TransferType = Funciton_TransferType();
                        AssetTransferHomeObj.AssetTransferHDObj.StatusID = "NEW";

                        if (AssetTransferHomeObj.EditHD(ORTransaction))
                            Bool_CheckExecuteComplete = true;
                        else
                            Bool_CheckExecuteComplete = false;

                        //Delete Rows in table when user delete row from database
                        for (i = 0; i <= EditList.Count - 1; i++)
                        {
                            Value =(EditValue)EditList[i];
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
                            AssetTransferHomeObj.AssetTransferDTObj.TransferSeq = Convert.ToInt32(sS_DataGridView_InternalTransferOrder[0, i].Value);
                            AssetTransferHomeObj.AssetTransferDTObj.ModelID = sS_DataGridView_InternalTransferOrder[1, i].Value.ToString();
                            AssetTransferHomeObj.AssetTransferDTObj.OrderQty =Convert.ToInt32(sS_DataGridView_InternalTransferOrder[3,i].Value);
                            AssetTransferHomeObj.AssetTransferDTObj.TransferPrice = Convert.ToDecimal(sS_DataGridView_InternalTransferOrder[4, i].Value);
                            AssetTransferHomeObj.AssetTransferDTObj.TransferCost = Convert.ToDecimal(sS_DataGridView_InternalTransferOrder[5, i].Value);
                            AssetTransferHomeObj.AssetTransferDTObj.Remark = Convert.ToString(sS_DataGridView_InternalTransferOrder[6, i].Value);
                            AssetTransferHomeObj.AssetTransferDTObj.TransferQty = 0;

                            if (AssetTransferHomeObj.EditDT(ORTransaction))
                                Bool_CheckExecuteComplete = true;
                            else
                                Bool_CheckExecuteComplete = false;
                        }

                        //Insert row to database when user add row detail in datagrid

                        for (i = Int_CountObjDTs; i < sS_DataGridView_InternalTransferOrder.Rows.Count - 1; i++)
                        {
                            AssetTransferHomeObj.AssetTransferDTObj.TransferID = sS_MaskedTextBox_TransferID.Text;
                            AssetTransferHomeObj.AssetTransferDTObj.TransferSeq = Convert.ToInt32(sS_DataGridView_InternalTransferOrder[0, i].Value);
                            AssetTransferHomeObj.AssetTransferDTObj.ModelID = sS_DataGridView_InternalTransferOrder[1, i].Value.ToString();
                            AssetTransferHomeObj.AssetTransferDTObj.OrderQty = Convert.ToInt32(sS_DataGridView_InternalTransferOrder[3, i].Value);
                            AssetTransferHomeObj.AssetTransferDTObj.TransferPrice = Convert.ToDecimal(sS_DataGridView_InternalTransferOrder[4, i].Value);
                            AssetTransferHomeObj.AssetTransferDTObj.TransferCost = Convert.ToDecimal(sS_DataGridView_InternalTransferOrder[5, i].Value);
                            AssetTransferHomeObj.AssetTransferDTObj.Remark = Convert.ToString(sS_DataGridView_InternalTransferOrder[6, i].Value);
                            AssetTransferHomeObj.AssetTransferDTObj.TransferQty = 0;

                            if (AssetTransferHomeObj.AddDT(ORTransaction))
                                Bool_CheckExecuteComplete = true;
                            else
                                Bool_CheckExecuteComplete = false;
                        }

                        if (Bool_CheckExecuteComplete)
                        {
                            ORTransaction.Commit();
                            SS_MyMessageBox.ShowBox("Edit data : " + sS_MaskedTextBox_TransferID.Text + "Complete", "Edit Data Information", DialogMode.OkOnly, this.Name, "000003", Obj_TransferID, Global.Lang.Str_Language);
                            RunControlHomeObj.SaveRunControlID("TransferRun", sS_MaskedTextBox_TransferID.Text);
                            Global.Bool_CheckComplete = true;
                            //goto DEFAULT;
                        }
                        else
                        {
                            SS_MyMessageBox.ShowBox("Can not edit data : " + sS_MaskedTextBox_TransferID.Text, "Warning", DialogMode.OkOnly, this.Name, "000004", Obj_TransferID, Global.Lang.Str_Language);
                            Global.Bool_CheckComplete = false;
                            ORTransaction.Rollback();
                        }
                        Enm_StateForm = Enum_Mode.Search;
                        Function_ExecuteTransaction(Enum_Mode.Cancel);
                        break;
                    case Enum_Mode.Delete:
                        if (SS_MyMessageBox.ShowBox("Do you want to delete : " + sS_MaskedTextBox_TransferID.Text + " ?", "Delete Data Information", DialogMode.OkCancel, this.Name, "000005", Obj_TransferID, Global.Lang.Str_Language) == DialogResult.OK)
                        {
                            Global.Bool_CheckComplete = true;
                            AssetTransferHomeObj.AssetTransferHDObj.TransferID = sS_MaskedTextBox_TransferID.Text;

                            if (AssetTransferHomeObj.Delete())
                            {
                                SS_MyMessageBox.ShowBox("Delete data : " + sS_MaskedTextBox_TransferID.Text + " ?", "Delete Data Information", DialogMode.OkOnly, this.Name, "000006", Obj_TransferID, Global.Lang.Str_Language);
                                Global.Bool_CheckComplete = true;
                                Enm_StateForm = Enum_Mode.PreAdd;
    
                            }
                            else
                            {
                                SS_MyMessageBox.ShowBox("Can not delete data : " + sS_MaskedTextBox_TransferID.Text + " !", "Warning", DialogMode.OkOnly, this.Name, "000007", Obj_TransferID, Global.Lang.Str_Language);
                                Global.Bool_CheckComplete = false;
                                Enm_StateForm = Enum_Mode.PreEdit;
                            }
                            Function_ExecuteTransaction(Enum_Mode.Cancel);
                        }
                        else
                        {
                            Global.Bool_CheckComplete = false;
                            Enm_StateForm = Enum_Mode.PreEdit;
                            Function_ExecuteTransaction(Enum_Mode.Cancel);
                        }
                        break;
                        //goto DEFAULT;

                    case Enum_Mode.ShowData:
                        Manager.Engine.ClearTracking();

                        AssetTransferHomeObj.AssetTransferHDObj = Manager.Engine.GetObject<AssetTransferHD>(sS_MaskedTextBox_TransferID.Text);

                        sS_MaskedTextBox_TransferID.Text = AssetTransferHomeObj.AssetTransferHDObj.TransferID;
                        //sS_MaskedTextBox_Date.Text = AssetTransferHomeObj.AssetTransferHDObj.TransferDate.ToShortDateString();
                        dateTimePicker_Date.Text = AssetTransferHomeObj.AssetTransferHDObj.TransferDate.ToShortDateString();
                        sS_ComboBox_TransferType.SelectedIndex = Global.FormOrder.Function_SetType(AssetTransferHomeObj.AssetTransferHDObj.TransferType);
                        sS_MaskedTextBox_FromDeptID.Text = AssetTransferHomeObj.AssetTransferHDObj.FromDeptID;
                        sS_MaskedTextBox_FromDeptName.Text = Global.FormOrder.Function_GetDeptName(AssetTransferHomeObj.AssetTransferHDObj.FromDeptID);
                        sS_MaskedTextBox_ToDeptID.Text = AssetTransferHomeObj.AssetTransferHDObj.ToDeptID;
                        sS_MaskedTextBox_ToDeptName.Text = Global.FormOrder.Function_GetDeptName(AssetTransferHomeObj.AssetTransferHDObj.ToDeptID);
                        sS_MaskedTextBox_Remark.Text = AssetTransferHomeObj.AssetTransferHDObj.Remark;
                        sS_MaskedTextBox_FromFacCode.Text = AssetTransferHomeObj.AssetTransferHDObj.FromFacCode;
                        sS_MaskedTextBox_FromFacName.Text = Global.FormOrder.Function_GetFacName(AssetTransferHomeObj.AssetTransferHDObj.FromFacCode);

                        //เก็บจำนวน Detail ก่อนทำการแก้ไข
                        Int_CountObjDTs = AssetTransferHomeObj.AssetTransferHDObj.AssetTransferDTs.Count;
                        sS_DataGridView_InternalTransferOrder.Rows.Clear();

                        //Loop Add Detail to Datagrid
                        if (AssetTransferHomeObj.AssetTransferHDObj.AssetTransferDTs.Count == 0)
                        {
                            Wilson.ORMapper.ObjectSet<AssetTransferDT> AssetTransferObj = Manager.Engine.GetObjectSet<AssetTransferDT>("TransferID = '" + sS_MaskedTextBox_TransferID.Text + "'");
                            for (int j = 0; j < AssetTransferObj.Count; j++)
                            {
                                Object[] rows = new Object[] {AssetTransferObj[j].TransferSeq,AssetTransferObj[j].ModelID,
                                                            Global.FormOrder.Function_GetModelName(AssetTransferObj[j].ModelID),
                                                            AssetTransferObj[j].OrderQty,AssetTransferObj[j].TransferPrice,
                                                            AssetTransferObj[j].TransferCost,AssetTransferObj[j].Remark};
                            }
                        }
                        else
                        {
                            for (i = 0; i < AssetTransferHomeObj.AssetTransferHDObj.AssetTransferDTs.Count; i++)
                            {
                                AssetTransferHomeObj.AssetTransferDTObj = (AssetTransferDT)AssetTransferHomeObj.AssetTransferHDObj.AssetTransferDTs[i];
                                Object[] rows = new Object[] {AssetTransferHomeObj.AssetTransferDTObj.TransferSeq,
                                                           AssetTransferHomeObj.AssetTransferDTObj.ModelID,
                                                            Global.FormOrder.Function_GetModelName(AssetTransferHomeObj.AssetTransferDTObj.ModelID),
                                                            AssetTransferHomeObj.AssetTransferDTObj.OrderQty,
                                                            AssetTransferHomeObj.AssetTransferDTObj.TransferPrice,
                                                            AssetTransferHomeObj.AssetTransferDTObj.TransferCost,
                                                            AssetTransferHomeObj.AssetTransferDTObj.Remark};

                                sS_DataGridView_InternalTransferOrder.Rows.Add(rows);
                                sS_DataGridView_InternalTransferOrder.Sort(sS_DataGridView_InternalTransferOrder.Columns[0], ListSortDirection.Ascending);

                            }
                        }
                        
                        Global.Function_ToolStripSetUP(Enum_Mode.CellClick);
                        sS_MaskedTextBox_TransferID.ReadOnly = true;
                        sS_DataGridView_InternalTransferOrder.ReadOnly = true;
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
                        if (Enm_StateForm == Enum_Mode.Search)
                        {
                            Function_ExecuteTransaction(Enum_Mode.ShowData);
                            sS_MaskedTextBox_TransferID.Focus();
                        }
                        Function_ReadOnlyControl(true);
                        Function_EnableControl(false);
                        sS_DataGridView_InternalTransferOrder.ReadOnly = true;
                        Enm_StateForm = Enum_Mode.Search;
                        break;

                    default:
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

        private void sS_DataGridView_InternalTransferOrder_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Global.FormOrder.Function_PlusLineInDataGrid(e, sS_DataGridView_InternalTransferOrder, Enm_StateForm);
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
            return Str_TempTransferType;
        }

        private void sS_MaskedTextBox_TransferID_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {
                    Global.FormOrder.Function_ShowFormSearch(Enum_TypeSearch.InTransfer);
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

        private void sS_DataGridView_InternalTransferOrder_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            if (sS_DataGridView_InternalTransferOrder.Rows.Count != 0)
            {
                if (Convert.ToInt32(e.Row.Cells[0].Value) <= Int_CountObjDTs)
                {
                    Value.Str_TransferID = sS_MaskedTextBox_TransferID.Text;
                    Value.Int_TransferSeq = Convert.ToInt32(e.Row.Cells[0].Value);
                    Value.Str_ModelID = e.Row.Cells[1].Value.ToString();
                    EditList.Add(Value);
                }
            }
        }

        private void sS_DataGridView_InternalTransferOrder_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            Global.FormOrder.Function_ShiftRowsWhenDelete(e, sS_DataGridView_InternalTransferOrder, Enm_StateForm);
        }

        private void sS_DataGridView_InternalTransferOrder_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //Global.FormOrder.Function_MultiplyPriceAndQty(e,sS_DataGridView_InternalTransferOrder);
        }

     
        private void sS_MaskedTextBox_FromDeptID_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.F1) && ((Enm_StateForm == Enum_Mode.PreAdd) || (Enm_StateForm == Enum_Mode.PreEdit)))
            {
                SimatSoft.QueryManager.Form_Present Frm_Present = new SimatSoft.QueryManager.Form_Present();
                Frm_Present.Controlreturnvalue = sS_MaskedTextBox_FromDeptID;
                Frm_Present.Controlreturnvalue2 = sS_MaskedTextBox_FromDeptName;
                Frm_Present.Show_Data("Screen", "002010");

                Frm_Present.ShowDialog();
                Frm_Present.Dispose();
            }
        }

        private void sS_MaskedTextBox_ToDeptID_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.F1) && ((Enm_StateForm == Enum_Mode.PreAdd) || (Enm_StateForm == Enum_Mode.PreEdit)))
            {
                SimatSoft.QueryManager.Form_Present Frm_Present = new SimatSoft.QueryManager.Form_Present();
                Frm_Present.Controlreturnvalue = sS_MaskedTextBox_ToDeptID;
                Frm_Present.Controlreturnvalue2 = sS_MaskedTextBox_ToDeptName;
                Frm_Present.Show_Data("Screen", "002010");

                Frm_Present.ShowDialog();
                Frm_Present.Dispose();
            }
        }

        private void sS_DataGridView_InternalTransferOrder_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if ((e.ColumnIndex == 0)&&((Enm_StateForm ==Enum_Mode.PreAdd)||(Enm_StateForm ==Enum_Mode.PreEdit)))
            {
                SimatSoft.QueryManager.Form_Present Frm_Present = new SimatSoft.QueryManager.Form_Present();
                TextBox TempTextBox = new TextBox();
                TextBox TempTextBox2 = new TextBox();
                TextBox TempTextBox3 = new TextBox();
                TextBox TempTextBox4 = new TextBox();
                Frm_Present.Controlreturnvalue = TempTextBox;
                Frm_Present.Controlreturnvalue2 = TempTextBox2;
                Frm_Present.Controlreturnvalue6 = TempTextBox3;
                Frm_Present.Controlreturnvalue7 = TempTextBox4;
                string qry = "deptid = '" + sS_MaskedTextBox_FromDeptID.Text + "'";
                Frm_Present.Show_Data("Screen", "002001",qry);
               
                Frm_Present.ShowDialog();

                sS_DataGridView_InternalTransferOrder[1, sS_DataGridView_InternalTransferOrder.CurrentRow.Index].Value = TempTextBox.Text;
                sS_DataGridView_InternalTransferOrder[2, sS_DataGridView_InternalTransferOrder.CurrentRow.Index].Value = TempTextBox2.Text;
                sS_DataGridView_InternalTransferOrder[3, sS_DataGridView_InternalTransferOrder.CurrentRow.Index].Value = TempTextBox3.Text;
                sS_DataGridView_InternalTransferOrder[4, sS_DataGridView_InternalTransferOrder.CurrentRow.Index].Value = TempTextBox4.Text;
                Frm_Present.Dispose();

                sS_DataGridView_InternalTransferOrder.CurrentCell = sS_DataGridView_InternalTransferOrder[3, sS_DataGridView_InternalTransferOrder.CurrentRow.Index];
            }
            Function_ReadOnlyControlDatagrid(true);

        }

        private void Form_001003_InternalTransferOrder_Activated(object sender, EventArgs e)
        {
            AuthorizeState.Funtion_SetButtonAuthorize(Enm_StateForm);
        }

        private void Form_001003_InternalTransferOrder_Load(object sender, EventArgs e)
        {
            Global.Location.Int_CountForm = Global.Location.Int_CountForm + 0;
            Function_ClearData();
            sS_DataGridView_InternalTransferOrder.ReadOnly = true;
            sS_MaskedTextBox_TransferID.ReadOnly = true;
            Function_ReadOnlyControl(true);
            Function_EnableControl(false);
            Function_InsertInfoToDatagrid();

            //sS_DataGridView_InternalTransferOrder.Columns[1].ReadOnly = true;
            sS_DataGridView_InternalTransferOrder.Columns[2].ReadOnly = true;
            sS_DataGridView_InternalTransferOrder.Columns[3].ReadOnly = true;
            sS_DataGridView_InternalTransferOrder.Columns[4].ReadOnly = true;

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

        private void Form_001003_InternalTransferOrder_FormClosing(object sender, FormClosingEventArgs e)
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

        private string Function_GetNextRunningNo()
        {
            string nextNo = "";
            try
            {
                string qry = "SELECT Prefix, CurrentRun FROM SysRunNo WHERE RunID = 4"; // Internal Transfer

                DataSet ds = new DataSet();
                ds = Manager.Engine.GetDataSet(qry);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    string prefix = ds.Tables[0].Rows[0][0].ToString();
                    int current = Convert.ToInt32(ds.Tables[0].Rows[0][1]);
                    int lenght = ds.Tables[0].Rows[0][1].ToString().Length;
                    current++;
                    string str_current = current.ToString();
                    string runningid = "";
                    if (lenght > str_current.Length)
                    {
                        for (int i = 0; i < lenght - current.ToString().Length; i++)
                            runningid += "0";
                        runningid += str_current;
                    }
                    currentNo = runningid;
                    nextNo = prefix + runningid;
                }

            }
            catch { }

            return nextNo;
        }

        private void Function_SaveCurrentRunningNo(string runid)
        {
            try
            {
                string qry = "UPDATE SysRunNo SET CurrentRun = '" + runid +
                             "' WHERE RunId = 4"; // Internal Transfer 

                Manager.Engine.ExecuteCommand(qry);
            }
            catch { }

        }
    }
 }