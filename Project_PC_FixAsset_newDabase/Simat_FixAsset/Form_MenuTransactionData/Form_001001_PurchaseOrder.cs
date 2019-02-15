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
using Wilson.ORMapper;

namespace SimatSoft.FixAsset
{
    public partial class Form_001001_PurchaseOrder : SS_PaintGradientForm
    {
        private string Str_IDForm = "11";
        private int Int_CountObjDTs = 0;
        private Enum_Mode Enm_StateForm = Enum_Mode.Search;
        Class_AuthorizeState AuthorizeState = new Class_AuthorizeState();
        public bool Bool_FlagCheckReturn = false;
        System.Collections.ArrayList EditList = new System.Collections.ArrayList(); //เก็บ  Detail ที่ user ลบออกไปเวลา edit
        EditValue Value = new EditValue(); // Detail ที่ user ลบออกไป

        POHome POHomeObj = new POHome();

        private struct EditValue
        {
            public string Str_ModelID;
            public int Int_POSeq;
            public string Str_POID;
        }
        public Form_001001_PurchaseOrder()
        {
            InitializeComponent();
            DarkColor = Global.ConfigForm.Colr_BackColor;
            Function_IntitialControl();
            //Enm_StateForm = Enum_Mode.Search;
            //Global.Function_ToolStripSetUP(Enum_Mode.Search);

            AuthorizeState.Function_SetAuthorize(this.Name.Substring(5, 6).Replace("0", ""));
            AuthorizeState.Funtion_SetButtonAuthorize(Enm_StateForm);
        }
        private void Function_IntitialControl()
        {
            this.Text = Global.Function_Language(this, this, "ID:001001(Purchase Order)");
            LBL_PONo.Text = Global.Function_Language(this, LBL_PONo, " PO No:");
            LBL_SupplierNo.Text = Global.Function_Language(this, LBL_SupplierNo, "Supplier No:");
            LBL_Date.Text = Global.Function_Language(this, LBL_Date, "Date:");
            LBL_DepartmentName.Text = Global.Function_Language(this, LBL_DepartmentName, "Department Name:");
            LBL_Type.Text = Global.Function_Language(this, LBL_Type, "Type:");
            LBL_Remark.Text = Global.Function_Language(this, LBL_Remark, "Remark:");
            LBL_CompanyNo.Text = Global.Function_Language(this, LBL_CompanyNo, "Company No:");
        }
        private void Form_001001_PurchaseOrder_FormClosed(object sender, FormClosedEventArgs e)
        {
            Global.Function_RemoveTabStripButton(this.Tag);
        }
        public void Function_ExecuteTransaction(Enum_Mode mode)
        {
            try
            {
                ValidateuserinputData ValidateInput = new ValidateuserinputData(Global.ConfigPath.Str_AppPathValidate + "\\" + this.Name + ".xml", this);
                RunControlHome RunControlHomeObj =new RunControlHome();

                object[] Obj_PONo = new object[1] { sS_MaskedTextBox_PONo.Text };

                Wilson.ORMapper.Transaction ORTransaction = null;
                bool Bool_CheckExecuteComplete = false;
                int i = 0;
                switch (mode)
                {
                    case Enum_Mode.Search:
                        {
                            break;
                        }
                    case Enum_Mode.PreAdd:
                        {
                            Function_ClearData();
                            sS_MaskedTextBox_PONo.ReadOnly = true;
                            Function_SetReadOnlyControl(true);
                            Function_SetControlEnable(true);
                            sS_DataGridView_PurchaseOrder.ReadOnly = false;
                            //sS_MaskedTextBox_PONo.Text = RunControlHomeObj.Function_ExcuteGetrunningCommand("PORun");
                            sS_MaskedTextBox_PONo.Text = "";
                            sS_MaskedTextBox_PONo.ReadOnly = false;
                            sS_MaskedTextBox_Remark.ReadOnly = false;
                            //sS_MaskedTextBox_SupplierNo.Focus();
                            sS_MaskedTextBox_PONo.Focus();
                            Enm_StateForm = Enum_Mode.PreAdd;
                            break;
                        }
                    case Enum_Mode.Add:
                        if (sS_DataGridView_PurchaseOrder.Rows.Count > 1)
                        {
                            ORTransaction = Manager.Engine.BeginTransaction();
                            POHomeObj.Pohdobj.Poid = sS_MaskedTextBox_PONo.Text;
                            POHomeObj.Pohdobj.VendorID = sS_MaskedTextBox_SupplierNo.Text;
                            //POHomeObj.Pohdobj.PODate = Convert.ToDateTime(sS_MaskedTextBox_Date.Text);
                            POHomeObj.Pohdobj.PODate = Convert.ToDateTime(dateTimePicker_PO.Text);
                            POHomeObj.Pohdobj.DeptID = sS_MaskedTextBox_DepartmentNo.Text;
                            POHomeObj.Pohdobj.POType = sS_ComboBox_Type.SelectedItem.ToString();
                            POHomeObj.Pohdobj.Remark = sS_MaskedTextBox_Remark.Text;
                            POHomeObj.Pohdobj.FacCode = sS_MaskedTextBox_FacilityNo.Text;
                            POHomeObj.Pohdobj.StatusID = "NEW";
                            CheckDataInStatus("Status");

                            POHomeObj.Pohdobj.UserName = Global.ConfigDatabase.Str_UserID;

                            if (POHomeObj.AddHD(ORTransaction))
                                Bool_CheckExecuteComplete = true;
                            else
                            {
                                Bool_CheckExecuteComplete = false;
                                break;
                            }


                            for (i = 0; i < sS_DataGridView_PurchaseOrder.Rows.Count - 1; i++)
                            {
                                POHomeObj.Podtobj.Poid = sS_MaskedTextBox_PONo.Text;
                                POHomeObj.Podtobj.POSeq = int.Parse(sS_DataGridView_PurchaseOrder[0, i].Value.ToString());
                                POHomeObj.Podtobj.ModelID = sS_DataGridView_PurchaseOrder[1, i].Value.ToString();
                                POHomeObj.Podtobj.POQty = Math.Abs(Convert.ToInt32(sS_DataGridView_PurchaseOrder[3, i].Value.ToString()));
                                POHomeObj.Podtobj.POPrice = Convert.ToDecimal(sS_DataGridView_PurchaseOrder[4, i].Value.ToString());
                                POHomeObj.Podtobj.POCost = Convert.ToDecimal(sS_DataGridView_PurchaseOrder[3, i].Value) * Convert.ToDecimal(sS_DataGridView_PurchaseOrder[4, i].Value);
                                POHomeObj.Podtobj.Remark = Convert.ToString(sS_DataGridView_PurchaseOrder[6, i].Value);
                                POHomeObj.Podtobj.ReceiveQty = 0;

                                if (POHomeObj.AddDT(ORTransaction))
                                    Bool_CheckExecuteComplete = true;
                                else
                                {
                                    Bool_CheckExecuteComplete = false;
                                    break;
                                }
                            }
                            if (Bool_CheckExecuteComplete)
                            {
                                ORTransaction.Commit();
                                SS_MyMessageBox.ShowBox("Add data : " + sS_MaskedTextBox_PONo.Text + " Complete", "Add Data Information", DialogMode.OkOnly, this.Name, "000001", Obj_PONo, Global.Lang.Str_Language);
                                RunControlHomeObj.SaveRunControlID("PORun", sS_MaskedTextBox_PONo.Text);
                                Global.Bool_CheckComplete = true;
                                Enm_StateForm = Enum_Mode.PreAdd;
                                Function_ExecuteTransaction(Enum_Mode.Cancel);
                                //goto DEFAULT;
                            }
                            else
                            {
                                SS_MyMessageBox.ShowBox("Can not add data: " + sS_MaskedTextBox_PONo.Text + " !", "Warning", DialogMode.OkOnly, this.Name, "000002", Obj_PONo, Global.Lang.Str_Language);
                                Global.Bool_CheckComplete = false;
                                ORTransaction.Rollback();
                            }
                        }
                        else
                        {
                            SS_MyMessageBox.ShowBox("Please input Model in cell grid", "Warning",DialogMode.OkOnly,this.Name,"000010",Global.Lang.Str_Language);
                            sS_DataGridView_PurchaseOrder.Focus();
                            break;
                        }                       
                        break;
                    case Enum_Mode.PreEdit:
                        {
                            Function_SetReadOnlyControl(true);
                            Function_SetControlEnable(true);
                            sS_MaskedTextBox_PONo.ReadOnly = true;
                            sS_MaskedTextBox_SupplierNo.Focus();
                            sS_MaskedTextBox_Remark.ReadOnly = false;
                            sS_DataGridView_PurchaseOrder.ReadOnly = false;
                            sS_DataGridView_PurchaseOrder.Columns[0].ReadOnly = true;
                            Enm_StateForm = Enum_Mode.PreEdit;
                            break;
                        }
                    case Enum_Mode.Edit:
                        {
                            ORTransaction = Manager.Engine.BeginTransaction();
                                POHomeObj.Pohdobj.Poid = sS_MaskedTextBox_PONo.Text;
                                POHomeObj.Pohdobj.VendorID = sS_MaskedTextBox_SupplierNo.Text;
                                //POHomeObj.Pohdobj.PODate = Convert.ToDateTime(sS_MaskedTextBox_Date.Text);
                                POHomeObj.Pohdobj.PODate = Convert.ToDateTime(dateTimePicker_PO.Text);
                                POHomeObj.Pohdobj.DeptID = sS_MaskedTextBox_DepartmentNo.Text;
                                POHomeObj.Pohdobj.POType = sS_ComboBox_Type.Text;
                                POHomeObj.Pohdobj.Remark = sS_MaskedTextBox_Remark.Text;
                                POHomeObj.Pohdobj.FacCode = sS_MaskedTextBox_FacilityNo.Text;
                                POHomeObj.Pohdobj.UserName = Global.ConfigDatabase.Str_UserID;
                                POHomeObj.Pohdobj.StatusID = "NEW";

                                if (POHomeObj.EditHDTransaction(ORTransaction))
                                    Bool_CheckExecuteComplete = true;
                                else
                                {
                                    Bool_CheckExecuteComplete = false;
                                    break;
                                }

                                // 
                                for (i = 0; i < EditList.Count; i++)
                                {
                                    Value = (EditValue)EditList[i];

                                    POHomeObj.Podtobj.ModelID = Value.Str_ModelID;
                                    POHomeObj.Podtobj.Poid = Value.Str_POID;
                                    POHomeObj.Podtobj.POSeq = Value.Int_POSeq;

                                    if (POHomeObj.DeleteDT(ORTransaction))
                                    {
                                        Bool_CheckExecuteComplete = true;
                                        Int_CountObjDTs--;
                                    }
                                    else
                                    {
                                        Bool_CheckExecuteComplete = false;
                                    }
                                }
                                //

                                for (i = 0; i < Int_CountObjDTs; i++)
                                {
                                    POHomeObj.Podtobj.Poid = sS_MaskedTextBox_PONo.Text;
                                    POHomeObj.Podtobj.POSeq = int.Parse(sS_DataGridView_PurchaseOrder[0, i].Value.ToString());
                                    POHomeObj.Podtobj.ModelID = sS_DataGridView_PurchaseOrder[1, i].Value.ToString();
                                    POHomeObj.Podtobj.POQty = Math.Abs(Convert.ToInt32(sS_DataGridView_PurchaseOrder[3, i].Value.ToString()));
                                    POHomeObj.Podtobj.POPrice = Convert.ToDecimal(sS_DataGridView_PurchaseOrder[4, i].Value.ToString());
                                    POHomeObj.Podtobj.POCost = Convert.ToDecimal(sS_DataGridView_PurchaseOrder[3, i].Value) * Convert.ToDecimal(sS_DataGridView_PurchaseOrder[4, i].Value);
                                    POHomeObj.Podtobj.Remark = Convert.ToString(sS_DataGridView_PurchaseOrder[6, i].Value);
                                    POHomeObj.Podtobj.ReceiveQty = 0;

                                    if (POHomeObj.EditDT(ORTransaction))
                                    {
                                        Bool_CheckExecuteComplete = true;
                                    }
                                    else
                                    {
                                        Bool_CheckExecuteComplete = false;
                                    }
                                }

                                for (i = Int_CountObjDTs; i < sS_DataGridView_PurchaseOrder.Rows.Count - 1; i++)
                                {
                                    POHomeObj.Podtobj.Poid = sS_MaskedTextBox_PONo.Text;
                                    POHomeObj.Podtobj.POSeq = int.Parse(sS_DataGridView_PurchaseOrder[0, i].Value.ToString());
                                    POHomeObj.Podtobj.ModelID = sS_DataGridView_PurchaseOrder[1, i].Value.ToString();
                                    POHomeObj.Podtobj.POQty = Convert.ToInt32(sS_DataGridView_PurchaseOrder[3, i].Value.ToString());
                                    POHomeObj.Podtobj.POPrice = Convert.ToDecimal(sS_DataGridView_PurchaseOrder[4, i].Value.ToString());
                                    POHomeObj.Podtobj.POCost = Convert.ToDecimal(sS_DataGridView_PurchaseOrder[3, i].Value) * Convert.ToDecimal(sS_DataGridView_PurchaseOrder[4, i].Value);
                                    POHomeObj.Podtobj.Remark = Convert.ToString(sS_DataGridView_PurchaseOrder[6, i].Value);
                                    POHomeObj.Podtobj.ReceiveQty = 0;

                                    if (POHomeObj.AddDT(ORTransaction))
                                        Bool_CheckExecuteComplete = true;
                                    else
                                    {
                                        Bool_CheckExecuteComplete = false;
                                        break;
                                    }
                                }

                                if (Bool_CheckExecuteComplete)
                                {
                                    ORTransaction.Commit();
                                    SS_MyMessageBox.ShowBox("Edit data : " + sS_MaskedTextBox_PONo.Text + " Complete", "Edit Data Information", DialogMode.OkOnly, this.Name, "000003", Obj_PONo, Global.Lang.Str_Language);
                                    RunControlHomeObj.SaveRunControlID("PORun", sS_MaskedTextBox_PONo.Text);
                                    Global.Bool_CheckComplete = true;
                                    //goto DEFAULT;
                                }
                                else
                                {
                                    SS_MyMessageBox.ShowBox("Can not edit data : " + sS_MaskedTextBox_PONo.Text + " !", "Warning", DialogMode.OkOnly, this.Name, "000004", Obj_PONo, Global.Lang.Str_Language);
                                    Global.Bool_CheckComplete = false;
                                    ORTransaction.Rollback();

                                }
                                Enm_StateForm = Enum_Mode.Search;
                                Function_ExecuteTransaction(Enum_Mode.Cancel);
                           break;
                        }                       
                    case Enum_Mode.Delete:
                        if (Function_ChkStatus(Enum_Mode.Delete))
                        { }
                        else
                        {
                            if (SS_MyMessageBox.ShowBox("Do you want to delete : " + sS_MaskedTextBox_PONo.Text + " ?", "Delete Data Information", DialogMode.OkCancel, this.Name, "000005", Obj_PONo, Global.Lang.Str_Language) == DialogResult.OK)
                            {
                                Global.Bool_CheckComplete = true;
                                POHomeObj.Pohdobj.Poid = sS_MaskedTextBox_PONo.Text;
                                if (POHomeObj.Delete())
                                {
                                    SS_MyMessageBox.ShowBox("Delete data : " + sS_MaskedTextBox_PONo.Text + " ?", "Delete Data Information", DialogMode.OkOnly, this.Name, "000006", Obj_PONo, Global.Lang.Str_Language);
                                    Global.Bool_CheckComplete = true;
                                    Enm_StateForm = Enum_Mode.PreAdd;

                                }
                                else
                                {
                                    SS_MyMessageBox.ShowBox("Can not delete data : " + sS_MaskedTextBox_PONo.Text + " !", "Warning", DialogMode.OkOnly, this.Name, "000007", Obj_PONo, Global.Lang.Str_Language);
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
                            //goto DEFAULT;
                        }
                        break; 
                    case Enum_Mode.ShowData://                    
                        {
                             Manager.Engine.ClearTracking();
                            // sS_DataGridView_PurchaseOrder.Rows.Clear();
                             POHomeObj.Pohdobj = Manager.Engine.GetObject<Pohd>(sS_MaskedTextBox_PONo.Text);

                             sS_MaskedTextBox_SupplierNo.Text = POHomeObj.Pohdobj.VendorID;
                             sS_MaskedTextBox_SupplierName.Text = Global.FormOrder.Function_GetSupplierName(POHomeObj.Pohdobj.VendorID);
                            // sS_MaskedTextBox_Date.Text =  POHomeObj.Pohdobj.PODate.ToShortDateString();
                             dateTimePicker_PO.Text = POHomeObj.Pohdobj.PODate.ToShortDateString();
                             sS_MaskedTextBox_DepartmentNo.Text = POHomeObj.Pohdobj.DeptID;
                             sS_MaskedTextBox_DepartmentName.Text = Global.FormOrder.Function_GetDeptName(POHomeObj.Pohdobj.DeptID);
                             sS_ComboBox_Type.Text = POHomeObj.Pohdobj.POType;
                             sS_MaskedTextBox_FacilityNo.Text = POHomeObj.Pohdobj.FacCode;
                             sS_MaskedTextBox_FacName.Text = Global.FormOrder.Function_GetFacName(POHomeObj.Pohdobj.FacCode);
                             sS_MaskedTextBox_Remark.Text = POHomeObj.Pohdobj.Remark;

                             Int_CountObjDTs = POHomeObj.Pohdobj.Podts.Count;
                             sS_DataGridView_PurchaseOrder.Rows.Clear();

                             for (i = 0; i <= POHomeObj.Pohdobj.Podts.Count - 1; i++)
                             {
                                 POHomeObj.Podtobj = (Podt)POHomeObj.Pohdobj.Podts[i];
                                 Object[] Rows = new Object[] { POHomeObj.Podtobj.POSeq, POHomeObj.Podtobj.ModelID,Global.FormOrder.Function_GetModelName(POHomeObj.Podtobj.ModelID), POHomeObj.Podtobj.POQty,POHomeObj.Podtobj.POPrice,POHomeObj.Podtobj.POCost, POHomeObj.Podtobj.Remark };
                                    
                                 sS_DataGridView_PurchaseOrder.Rows.Add(Rows);
                                 sS_DataGridView_PurchaseOrder.Sort(sS_DataGridView_PurchaseOrder.Columns[0], ListSortDirection.Ascending);
                             }
                             Global.Function_SetButtonScreenAccess(Str_IDForm);
                             //Global.Function_ToolStripSetUP(Enum_Mode.CellClick);
                             sS_MaskedTextBox_PONo.ReadOnly = true;
                             sS_DataGridView_PurchaseOrder.ReadOnly = true;
                             break;
                        }

                    case Enum_Mode.Cancel:
                        if (Enm_StateForm == Enum_Mode.PreEdit)
                        {
                            Function_ExecuteTransaction(Enum_Mode.ShowData);
                            sS_MaskedTextBox_PONo.Focus();
                        }
                        if (Enm_StateForm == Enum_Mode.PreAdd)
                        {
                            Function_ClearData();
                            sS_MaskedTextBox_PONo.Focus();
                        }
                        if (Enm_StateForm == Enum_Mode.Search)
                        {
                            Function_ExecuteTransaction(Enum_Mode.ShowData);
                            sS_MaskedTextBox_PONo.Focus();
                        }
                        Function_SetReadOnlyControl(true);
                        Function_SetControlEnable(true);
                        Enm_StateForm = Enum_Mode.Search;
                        break;
                    DEFAULT:
                        Enm_StateForm = Enum_Mode.Search;
                        Function_ClearData();
                        sS_MaskedTextBox_PONo.ReadOnly = false;
                        Function_SetReadOnlyControl(true);
                        Function_SetControlEnable(false);
                        sS_DataGridView_PurchaseOrder.ReadOnly = true;
                        sS_MaskedTextBox_PONo.Focus();
                        break;
                }           
            }
            catch (Exception Ex)
            {
                SS_MyMessageBox.ShowBox(Ex.Message, "Error on Purchase Order Execute Transaction", DialogMode.Error_Cancel, Ex);
            }
        }
        private void Function_ClearData()
        {
            try
            {
                sS_MaskedTextBox_PONo.Text = "";
                sS_MaskedTextBox_SupplierNo.Text = "";
                sS_MaskedTextBox_SupplierName.Text = "";
                //sS_MaskedTextBox_Date.Text = "";
                sS_MaskedTextBox_DepartmentNo.Text = "";
                sS_MaskedTextBox_DepartmentName.Text = "";
                sS_MaskedTextBox_Remark.Text = "";
                sS_MaskedTextBox_FacilityNo.Text = "";
                sS_MaskedTextBox_FacName.Text = "";
                sS_ComboBox_Type.SelectedIndex = 0;
                sS_DataGridView_PurchaseOrder.Rows.Clear();               
            }
            catch (Exception Ex)
            {
                SS_MyMessageBox.ShowBox(Ex.Message, "Error On Purchase Order Clear Data in Control", DialogMode.Error_Cancel, Ex);
            }
        }
        public bool Function_ChkStatus(Enum_Mode mode)
        {
            object[] Obj_PONo = new object[1] { sS_MaskedTextBox_PONo.Text };
            if ((POHomeObj.Pohdobj.StatusID == "RECEIVE") || (POHomeObj.Pohdobj.StatusID == "CLOSE"))
            {
                Function_SetReadOnlyControl(false);
                switch (mode)
                {
                    case Enum_Mode.Delete:
                        {
                            SS_MyMessageBox.ShowBox("You does not delete data : " + sS_MaskedTextBox_PONo.Text + " ?", "Warning", DialogMode.OkOnly, this.Name, "000008", Obj_PONo, Global.Lang.Str_Language);
                            break;

                        }

                    case Enum_Mode.Edit:
                        {
                            SS_MyMessageBox.ShowBox("You does not edit data : " + sS_MaskedTextBox_PONo.Text + " ?", "Warning", DialogMode.OkOnly, this.Name, "000009", Obj_PONo, Global.Lang.Str_Language);
                            break;
                        }
                }
                return true;
            }
            else
                return false;
        }

        public void Function_ReadOnlyColumnDatagrid(bool Bool_StateControl)
        {
            sS_DataGridView_PurchaseOrder.Columns[0].ReadOnly = Bool_StateControl;
            sS_DataGridView_PurchaseOrder.Columns[2].ReadOnly = Bool_StateControl;
            sS_DataGridView_PurchaseOrder.Columns[4].ReadOnly = Bool_StateControl;
            sS_DataGridView_PurchaseOrder.Columns[5].ReadOnly = Bool_StateControl;

        }
       public void Function_SetReadOnlyControl(bool Bool_StateControl)
        {
            sS_MaskedTextBox_PONo.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_SupplierNo.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_SupplierName.ReadOnly = Bool_StateControl;
            //sS_MaskedTextBox_Date.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_DepartmentNo.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_DepartmentName.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_Remark.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_FacilityNo.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_FacName.ReadOnly = Bool_StateControl;
        }

        private void Function_SetControlEnable(bool Bool_StateControl)
        {
            sS_MaskedTextBox_SupplierNo.Enabled = Bool_StateControl;
            sS_MaskedTextBox_DepartmentNo.Enabled = Bool_StateControl;
            sS_MaskedTextBox_FacilityNo.Enabled = Bool_StateControl;
        }
        private void sS_MaskedTextBox_PONo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {
                    //Global.Function_ShowFormSearchOrder();
                    Global.FormOrder.Function_ShowFormSearch(Enum_TypeSearch.PO);

                    sS_MaskedTextBox_PONo.Text = Global.ReturnValue.Str_FormSearch;
                    if (Global.ReturnValue.Str_FormSearch != "")
                    {
                        Function_ExecuteTransaction(Enum_Mode.ShowData);
                        //Global.Function_ToolStripSetUP(Enum_Mode.CellClick);
                    }
                }
            }
            catch (Exception Ex)
            {
                SS_MyMessageBox.ShowBox(Ex.Message, "Error On Purchase Order Select PO", DialogMode.Error_Cancel, Ex);
            }
        }

        private void sS_DataGridView_PurchaseOrder_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Global.FormOrder.Function_PlusLineInDataGrid(e, sS_DataGridView_PurchaseOrder, Enm_StateForm);
        }

        private void sS_DataGridView_PurchaseOrder_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Global.FormOrder.Function_MultiplyPriceAndQty(e, sS_DataGridView_PurchaseOrder);
            
        }
        private void CheckDataInStatus(string Table)
        {
            switch (Table)
            {
                case "Status":
                    {
                        ObjectSet ObjSet_Status = Manager.Engine.GetObjectSet(typeof(Status), String.Empty);
                        Status StatusObj = (Status)ObjSet_Status.GetObject(POHomeObj.Pohdobj.StatusID);
                        if (StatusObj == null)
                        {
                            StatusObj = new Status();
                            StatusObj.ID = POHomeObj.Pohdobj.StatusID;
                            StatusObj.Name = StatusObj.ID;
                            StatusHome StatusHomeObj = new StatusHome();
                            StatusHomeObj.Statusobj = StatusObj;
                            StatusHomeObj.Add();
                        }
                        break;
                    }
            }
        }

        private void Form_001001_PurchaseOrder_Load(object sender, EventArgs e)
        {
            Global.Location.Int_CountForm = Global.Location.Int_CountForm + 0;
            Function_ClearData();
            Function_SetReadOnlyControl(true);
            Function_SetControlEnable(false);
            sS_DataGridView_PurchaseOrder.ReadOnly = true;
            Function_ReadOnlyColumnDatagrid(true);
        }

        private void sS_DataGridView_PurchaseOrder_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            Global.FormOrder.Function_ShiftRowsWhenDelete(e, sS_DataGridView_PurchaseOrder, Enm_StateForm);
        }

        private void sS_DataGridView_PurchaseOrder_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            //ถ้า user ทำการลบ rows ถ้าเป็น rows ที่มีอยู่ในดาต้าเบสให้ทำการเก็บค่าลง ArrayList
            if (Int_CountObjDTs != 1)
            {
                if (sS_DataGridView_PurchaseOrder.Rows.Count != 0)
                {
                    if (Convert.ToInt32(e.Row.Cells[0].Value) <= Int_CountObjDTs)
                    {
                        Value.Int_POSeq = Convert.ToInt32(e.Row.Cells[0].Value);
                        Value.Str_ModelID = e.Row.Cells[1].Value.ToString();
                        Value.Str_POID = sS_MaskedTextBox_PONo.Text;
                        EditList.Add(Value);

                    }
                }
            }

            else
            {
                SS_MyMessageBox.ShowBox("Can not delete data", "Information", DialogMode.OkOnly);
                for (int i = 0; i <= POHomeObj.Pohdobj.Podts.Count - 1; i++)
                {
                    POHomeObj.Podtobj = (Podt)POHomeObj.Pohdobj.Podts[i];
                    Object[] Rows = new Object[] { POHomeObj.Podtobj.POSeq, POHomeObj.Podtobj.ModelID, "", POHomeObj.Podtobj.POQty, POHomeObj.Podtobj.POPrice, POHomeObj.Podtobj.POCost, POHomeObj.Podtobj.Remark };

                    sS_DataGridView_PurchaseOrder.Rows.Add(Rows);
                }
                //Global.Function_ToolStripSetUP(Enum_Mode.CellClick);
            }

        }

        private void sS_MaskedTextBox_FacilityNo_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.F1) && ((Enm_StateForm == Enum_Mode.PreAdd) || (Enm_StateForm == Enum_Mode.PreEdit)))
            {
                SimatSoft.QueryManager.Form_Present Frm_Present = new SimatSoft.QueryManager.Form_Present();
                Frm_Present.Controlreturnvalue = sS_MaskedTextBox_FacilityNo;
                Frm_Present.Controlreturnvalue2 = sS_MaskedTextBox_FacName;
                Frm_Present.Show_Data("Screen", "002006");

                Frm_Present.ShowDialog();
                Frm_Present.Dispose();
            }
        }

        private void sS_MaskedTextBox_DepartmentNo_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.F1) && ((Enm_StateForm == Enum_Mode.PreAdd) || (Enm_StateForm == Enum_Mode.PreEdit)))
            {
                SimatSoft.QueryManager.Form_Present Frm_Present = new SimatSoft.QueryManager.Form_Present();
                Frm_Present.Controlreturnvalue = sS_MaskedTextBox_DepartmentNo;
                Frm_Present.Controlreturnvalue2 = sS_MaskedTextBox_DepartmentName;
                Frm_Present.Show_Data("Screen", "002010");

                Frm_Present.ShowDialog();
                Frm_Present.Dispose();
            }
        }

        private void sS_MaskedTextBox_SupplierNo_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.F1) && ((Enm_StateForm == Enum_Mode.PreAdd) || (Enm_StateForm == Enum_Mode.PreEdit)))
            {
                SimatSoft.QueryManager.Form_Present Frm_Present = new SimatSoft.QueryManager.Form_Present();
                Frm_Present.Controlreturnvalue = sS_MaskedTextBox_SupplierNo;
                Frm_Present.Controlreturnvalue2 = sS_MaskedTextBox_SupplierName;
                Frm_Present.Show_Data("Screen", "002005");

                Frm_Present.ShowDialog();
                Frm_Present.Dispose();
            }
        }

        private void sS_DataGridView_PurchaseOrder_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                SimatSoft.QueryManager.Form_Present Frm_Present = new SimatSoft.QueryManager.Form_Present();
                Frm_Present.Show_Data("Screen", "002002");
                TextBox TempTextBox = new TextBox();
                TextBox TempTextBox2 = new TextBox();
                TextBox TempTextBox3 = new TextBox();
                Frm_Present.Controlreturnvalue = TempTextBox;
                Frm_Present.Controlreturnvalue2 = TempTextBox2;
                Frm_Present.Controlreturnvalue3 = TempTextBox3;
                Frm_Present.ShowDialog();

                sS_DataGridView_PurchaseOrder[1, sS_DataGridView_PurchaseOrder.CurrentRow.Index].Value = TempTextBox.Text;
                sS_DataGridView_PurchaseOrder[2, sS_DataGridView_PurchaseOrder.CurrentRow.Index].Value = TempTextBox2.Text;
                sS_DataGridView_PurchaseOrder[4, sS_DataGridView_PurchaseOrder.CurrentRow.Index].Value = TempTextBox3.Text;
                Frm_Present.Dispose();

                sS_DataGridView_PurchaseOrder.CurrentCell = sS_DataGridView_PurchaseOrder[3, sS_DataGridView_PurchaseOrder.CurrentRow.Index];

            }
            Function_ReadOnlyColumnDatagrid(true);
        }

        private void Form_001001_PurchaseOrder_Activated(object sender, EventArgs e)
        {
            AuthorizeState.Funtion_SetButtonAuthorize(Enm_StateForm);
        }

        private void sS_DataGridView_PurchaseOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form_001001_PurchaseOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Global.Location.Int_CountForm > 0)
            {
                Global.Location.Int_CountForm = Global.Location.Int_CountForm - 1;
            }
            AuthorizeState.Funtion_SetButtonAuthorize(Enum_Mode.SetDefault);
        }

         
    }
 }