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
    public partial class Form_002011_Custodian : SS_PaintGradientForm
    {
        private Enum_Mode Enm_StateForm = Enum_Mode.Search;
        private string currentNo = "";
        Class_AuthorizeState AuthorizeState = new Class_AuthorizeState();
        public Form_002011_Custodian()
        {
            InitializeComponent();
            DarkColor = Global.ConfigForm.Colr_BackColor;
            Function_IntitialControl();
            Global.Function_ToolStripSetUP(Enum_Mode.Search);

            AuthorizeState.Function_SetAuthorize(this.Name.Substring(5, 6).Replace("0", ""));
            AuthorizeState.Funtion_SetButtonAuthorize(Enm_StateForm);
        }
        private void Function_IntitialControl()
        {
            this.Text = Global.Function_Language(this, this, "ID:002011(Custodian)");
            LBL_CustodianNo.Text = Global.Function_Language(this, LBL_CustodianNo, " Custodian No:");
            LBL_LastName.Text = Global.Function_Language(this, LBL_LastName, "LastName:");
            LBL_FirstName.Text = Global.Function_Language(this, LBL_FirstName, "FirstName:");
            LBL_DepartmentNo.Text = Global.Function_Language(this, LBL_DepartmentNo, "Department No:");
            LBL_CompanyNo.Text = Global.Function_Language(this, LBL_CompanyNo, "Company:");
            LBL_Remark.Text = Global.Function_Language(this, LBL_Remark, "Remark:");
        }
        private void Form_002011_Customer_Load(object sender, EventArgs e)
        {
            Global.Location.Int_CountForm = Global.Location.Int_CountForm + 0;
            Function_ShowDataInDatagridView();
            ///eDIT 07-01-09
            sS_MaskedTextBox_CustodianNo.ReadOnly = false;
            sS_MaskedTextBox_FirstName.ReadOnly = false;
            /////////////
            Function_SetReadOnlyControl(true);
            Function_ClearData();
        }
        public void Function_ExecuteTransaction(Enum_Mode mode)
        {
            try
            {
                CustodianHome CustodianHomeObj = new CustodianHome();
                ValidateuserinputData ValidateInput = new ValidateuserinputData(Global.ConfigPath.Str_AppPathValidate + "\\" + this.Name + ".xml", this);
                object[] Obj_CustodianNo = new object[1] { sS_MaskedTextBox_CustodianNo.Text };
                object[] Obj_CustodianRow = new object[1] {sS_DataGridView_Custodian.SelectedRows.Count};
                switch (mode)
                {
                    case Enum_Mode.Search:
                        {
                            break;
                        }
                    case Enum_Mode.PreAdd:
                        Function_ClearData();
                        Function_SetReadOnlyControl(false);
                        sS_MaskedTextBox_CustodianNo.Text = Function_GetNextRunningNo();
                        sS_MaskedTextBox_CustodianNo.ReadOnly = false;
                        sS_MaskedTextBox_CustodianNo.Focus();
                        Enm_StateForm = Enum_Mode.PreAdd;
                        break;
                    case Enum_Mode.Add:
                            if (ValidateInput.ValidateData(Global.Lang.Str_Language))
                            {
                                CustodianHomeObj.Custodianobj.ID = sS_MaskedTextBox_CustodianNo.Text;
                                CustodianHomeObj.Custodianobj.FirstName = sS_MaskedTextBox_FirstName.Text;
                                CustodianHomeObj.Custodianobj.LastName = sS_MaskedTextBox_LastName.Text;
                                CustodianHomeObj.Custodianobj.DeptID = sS_MaskedTextBox_DepartmentNo.Text;
                                CustodianHomeObj.Custodianobj.FacCode = sS_MaskedTextBox_FacilityNo.Text;
                                CustodianHomeObj.Custodianobj.Remark = sS_MaskedTextBox_Remark.Text;

                                Custodian CustodianObj = new Custodian();
                                CustodianObj = Manager.Engine.GetObject<Custodian>(sS_MaskedTextBox_CustodianNo.Text);
                                if (CustodianObj != null)
                                {
                                    SS_MyMessageBox.ShowBox("CustodianNo : " + sS_MaskedTextBox_CustodianNo.Text + " is duplicate data", "Warning", DialogMode.OkOnly, this.Name, "000010", Obj_CustodianNo, Global.Lang.Str_Language);
                                    Global.Bool_CheckComplete = false;
                                    sS_MaskedTextBox_CustodianNo.Focus();
                                    break;
                                }
                                else
                                {
                                    if (CustodianHomeObj.Add())
                                    {
                                        Function_SaveCurrentRunningNo(currentNo);
                                        SS_MyMessageBox.ShowBox("Add data : " + sS_MaskedTextBox_CustodianNo.Text + " Complete", "Add Data Information", DialogMode.OkOnly, this.Name, "000001", Obj_CustodianNo, Global.Lang.Str_Language);
                                        Global.Bool_CheckComplete = true;
                                        Enm_StateForm = Enum_Mode.PreAdd;
                                        Function_ExecuteTransaction(Enum_Mode.Cancel);
                                    }
                                    else
                                    {
                                        SS_MyMessageBox.ShowBox("Can not add data: " + sS_MaskedTextBox_CustodianNo.Text + " !", "Warning", DialogMode.OkOnly, this.Name, "000002", Obj_CustodianNo, Global.Lang.Str_Language);
                                        Global.Bool_CheckComplete = false;
                                        goto DEFAULT;
                                    }
                                }
                            }
                            else
                                Global.Bool_CheckComplete = false;
                                break;
                    case Enum_Mode.PreEdit:
                        Function_SetReadOnlyControl(false);
                        sS_MaskedTextBox_FirstName.Focus();
                        Enm_StateForm = Enum_Mode.PreEdit;
                        break;
                    case Enum_Mode.Edit:
                        {
                            if (ValidateInput.ValidateData(Global.Lang.Str_Language))
                            {
                                CustodianHomeObj.Custodianobj.ID = sS_MaskedTextBox_CustodianNo.Text;
                                CustodianHomeObj.Custodianobj.FirstName = sS_MaskedTextBox_FirstName.Text;
                                CustodianHomeObj.Custodianobj.LastName = sS_MaskedTextBox_LastName.Text;
                                CustodianHomeObj.Custodianobj.DeptID = sS_MaskedTextBox_DepartmentNo.Text;
                                CustodianHomeObj.Custodianobj.FacCode = sS_MaskedTextBox_FacilityNo.Text;
                                CustodianHomeObj.Custodianobj.Remark = sS_MaskedTextBox_Remark.Text;
                                if (CustodianHomeObj.Edit())
                                {
                                    SS_MyMessageBox.ShowBox("Edit data : " + sS_MaskedTextBox_CustodianNo.Text + " Complete", "Edit Data Information", DialogMode.OkOnly, this.Name, "000003", Obj_CustodianNo, Global.Lang.Str_Language);
                                    Global.Bool_CheckComplete = true;
                                }
                                else
                                {
                                    SS_MyMessageBox.ShowBox("Can not edit data : " + sS_MaskedTextBox_CustodianNo.Text + " !", "Warning", DialogMode.OkOnly, this.Name, "000004", Obj_CustodianNo, Global.Lang.Str_Language);
                                    Global.Bool_CheckComplete = false;
                                }
                                Enm_StateForm = Enum_Mode.PreEdit;
                                Function_ExecuteTransaction(Enum_Mode.Cancel);
                                Function_ShowDataInDatagridView();
                                //goto DEFAULT;
                            }
                            else
                                Global.Bool_CheckComplete = false;
                                break;
                        }
                    case Enum_Mode.Delete:
                        {
                            if (sS_DataGridView_Custodian.SelectedRows.Count > 1)
                            {
                                List<Custodian> CustodianCollection = new List<Custodian>();
                                Custodian TempkCustodian = new Custodian();
                                foreach (DataGridViewRow TempDataGridRow in sS_DataGridView_Custodian.SelectedRows)
                                {
                                    TempkCustodian =Manager.Engine.GetObject<Custodian>(TempDataGridRow.Cells[0].Value.ToString());
                                    CustodianCollection.Add(TempkCustodian);
                                }
                                 if (SS_MyMessageBox.ShowBox("Do you want to delete data" + sS_DataGridView_Custodian.SelectedRows.Count + "record ?", "Delete Data Information", DialogMode.OkCancel, this.Name, "000014", Obj_CustodianRow, Global.Lang.Str_Language) == DialogResult.OK)
                            {

                                Wilson.ORMapper.Transaction ORTransaction = Manager.Engine.BeginTransaction();

                                if (CustodianHomeObj.Delete(ORTransaction, CustodianCollection))
                                {
                                    ORTransaction.Commit();
                                    SS_MyMessageBox.ShowBox("Delete data complete", "Delete Data Information", DialogMode.OkOnly, this.Name, "000012", Global.Lang.Str_Language);
                                    Global.Bool_CheckComplete = true;

                                    Enm_StateForm = Enum_Mode.PreAdd;
                                    Function_ShowDataInDatagridView();
                                }
                                else
                                {
                                    SS_MyMessageBox.ShowBox("Can not delete data ", "Warning", DialogMode.OkOnly, this.Name, "000013", Global.Lang.Str_Language);
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
                            }
                            else
                            {
                                if (sS_MaskedTextBox_CustodianNo.Text != "")
                                {
                                    if (SS_MyMessageBox.ShowBox("Do you want to delete : " + sS_MaskedTextBox_CustodianNo.Text + " ?", "Delete Data Information", DialogMode.OkCancel, this.Name, "000005", Obj_CustodianNo, Global.Lang.Str_Language) == DialogResult.OK)
                                    {
                                        Global.Bool_CheckComplete = true;
                                        CustodianHomeObj.Custodianobj.ID = sS_MaskedTextBox_CustodianNo.Text;
                                        if (CustodianHomeObj.Delete())
                                        {
                                            SS_MyMessageBox.ShowBox("Delete: " + sS_MaskedTextBox_CustodianNo.Text + "complete", "Delete Data Information", DialogMode.OkOnly, this.Name, "000006", Obj_CustodianNo, Global.Lang.Str_Language);
                                            Global.Bool_CheckComplete = true;

                                            Enm_StateForm = Enum_Mode.PreAdd;
                                            Function_ShowDataInDatagridView();
                                        }
                                        else
                                        {
                                            SS_MyMessageBox.ShowBox("Can not delete data : " + sS_MaskedTextBox_CustodianNo.Text + " !", "Warning", DialogMode.OkOnly, this.Name, "000007", Obj_CustodianNo, Global.Lang.Str_Language);
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
                                else
                                    Global.Bool_CheckComplete = false;
                            }
                                break;
                        }
                    case Enum_Mode.ShowData://
                        if (sS_DataGridView_Custodian.Rows.Count > 0)
                        {
                            sS_MaskedTextBox_CustodianNo.ReadOnly = true;
                            sS_MaskedTextBox_CustodianNo.Text = sS_DataGridView_Custodian[0, sS_DataGridView_Custodian.CurrentRow.Index].Value.ToString();
                            Custodian CustodianObj = new Custodian();
                            CustodianObj = Manager.Engine.GetObject<Custodian>(sS_MaskedTextBox_CustodianNo.Text);
                            if (CustodianObj != null)
                            {
                                sS_MaskedTextBox_FirstName.Text = CustodianObj.FirstName;
                                sS_MaskedTextBox_LastName.Text = CustodianObj.LastName;
                                sS_MaskedTextBox_DepartmentNo.Text = CustodianObj.DeptID;
                                sS_MaskedTextBox_DeptName.Text = Global.FormOrder.Function_GetDeptName(CustodianObj.DeptID);
                                sS_MaskedTextBox_Remark.Text = CustodianObj.Remark;
                                sS_MaskedTextBox_FacilityNo.Text = CustodianObj.FacCode;
                                sS_MaskedTextBox_FacName.Text = Global.FormOrder.Function_GetFacName(CustodianObj.FacCode);
                            }
                            sS_MaskedTextBox_CustodianNo.Focus();
                        }
                        break;
                    case Enum_Mode.ShowData_search://
                        if (sS_DataGridView_Custodian.Rows.Count > 0)
                        {
                            sS_MaskedTextBox_CustodianNo.ReadOnly = true;
                           // sS_MaskedTextBox_CustodianNo.Text = sS_DataGridView_Custodian[0, sS_DataGridView_Custodian.CurrentRow.Index].Value.ToString();
                            Custodian CustodianObj = new Custodian();
                            CustodianObj = Manager.Engine.GetObject<Custodian>(sS_MaskedTextBox_CustodianNo.Text);
                            if (CustodianObj != null)
                            {
                                sS_MaskedTextBox_FirstName.Text = CustodianObj.FirstName;
                                sS_MaskedTextBox_LastName.Text = CustodianObj.LastName;
                                sS_MaskedTextBox_DepartmentNo.Text = CustodianObj.DeptID;
                                sS_MaskedTextBox_DeptName.Text = Global.FormOrder.Function_GetDeptName(CustodianObj.DeptID);
                                sS_MaskedTextBox_Remark.Text = CustodianObj.Remark;
                                sS_MaskedTextBox_FacilityNo.Text = CustodianObj.FacCode;
                                sS_MaskedTextBox_FacName.Text = Global.FormOrder.Function_GetFacName(CustodianObj.FacCode);
                            }
                            else
                            {
                                SS_MyMessageBox.ShowBox("No matched data.");
                                // Edit on 07-01-09 (Additional)
                                Enm_StateForm = Enum_Mode.PreAdd;
                                Global.ConfigForm.Enum_FlagTransaction = Enum_Mode.PreAdd;
                            }
                            sS_MaskedTextBox_CustodianNo.Focus();
                        }
                        break;
                        
                    case Enum_Mode.Cancel:
                        if (Enm_StateForm == Enum_Mode.PreEdit)
                        {
                            Function_ExecuteTransaction(Enum_Mode.ShowData);
                            sS_MaskedTextBox_CustodianNo.Focus();
                        }
                        if (Enm_StateForm == Enum_Mode.PreAdd)
                        {
                            Function_ClearData();
                            sS_MaskedTextBox_CustodianNo.Focus();
                            Function_ShowDataInDatagridView();
                        }
                        if (Enm_StateForm == Enum_Mode.PreSearch)
                        {
                            sS_MaskedTextBox_CustodianNo.ReadOnly = false;
                            sS_MaskedTextBox_FirstName.ReadOnly = false;
                            Function_SetReadOnlyControl(true);
                            Enm_StateForm = Enum_Mode.PreAdd;
                        }
                        else
                        {
                            sS_MaskedTextBox_CustodianNo.ReadOnly = false;
                            sS_MaskedTextBox_FirstName.ReadOnly = false;
                            Function_SetReadOnlyControl(true);
                            Enm_StateForm = Enum_Mode.Search;
                        }
                        break;
                    DEFAULT:
                        Function_ClearData();
                        sS_MaskedTextBox_CustodianNo.ReadOnly = false;
                        sS_MaskedTextBox_CustodianNo.Focus();
                        Function_ShowDataInDatagridView();
                        break;
                }
            }
            catch (Exception Err)
            {
                SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
            }
        }
        private void Function_ClearData()
        {
            try
            {
                sS_MaskedTextBox_CustodianNo.Text = "";
                sS_MaskedTextBox_FirstName.Text = "";
                sS_MaskedTextBox_LastName.Text = "";
                sS_MaskedTextBox_DepartmentNo.Text = "";
                sS_MaskedTextBox_DeptName.Text = "";
                sS_MaskedTextBox_Remark.Text = "";
                sS_MaskedTextBox_FacilityNo.Text = "";
                sS_MaskedTextBox_FacName.Text = "";
                
            }
            catch (Exception Err)
            {
                SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
            }
        }
        private void Function_ShowDataInDatagridView()
        {
            try
            {
                // sS_DataGridView1.SortOrder = SortOrder.None;
                // this.sS_DataGridView1.SortedColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
                DataSet Ds = new DataSet();
                Ds= Manager.Engine.GetDataSet<Custodian>("");
                sS_DataGridView_Custodian.DataSource = Ds;
                sS_DataGridView_Custodian.DataMember = "Table";
                Ds.Dispose();
                Ds = null;
            }
            catch (Exception Err)
            {
                SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
            }
        }
        private void Function_ShowDataInControl()
        {
            try
            {
                if (sS_DataGridView_Custodian.Rows.Count > 0)
                {
                    sS_MaskedTextBox_CustodianNo.Text = sS_DataGridView_Custodian[0, sS_DataGridView_Custodian.CurrentRow.Index].Value.ToString();
                    sS_MaskedTextBox_FirstName.Text = sS_DataGridView_Custodian[1, sS_DataGridView_Custodian.CurrentRow.Index].Value.ToString();
                    sS_MaskedTextBox_LastName.Text = sS_DataGridView_Custodian[2, sS_DataGridView_Custodian.CurrentRow.Index].Value.ToString();
                    sS_MaskedTextBox_DepartmentNo.Text = sS_DataGridView_Custodian[3, sS_DataGridView_Custodian.CurrentRow.Index].Value.ToString();
                    //sS_MaskedTextBox_DepartmentName.Text = sS_DataGridView_Custodian[4, sS_DataGridView_Custodian.CurrentRow.Index].Value.ToString();
                    sS_MaskedTextBox_Remark.Text = sS_DataGridView_Custodian[4, sS_DataGridView_Custodian.CurrentRow.Index].Value.ToString();
                    sS_MaskedTextBox_FacilityNo.Text = sS_DataGridView_Custodian[5, sS_DataGridView_Custodian.CurrentRow.Index].Value.ToString();
                    sS_MaskedTextBox_CustodianNo.Focus();

                }
            }
            catch (Exception Err)
            {
                SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
            }
        }
        public void Function_SetReadOnlyControl(bool Bool_StateControl)
        {
            //sS_MaskedTextBox_FirstName.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_LastName.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_Remark.ReadOnly = Bool_StateControl;
    
        }

       
        private void Form_002011_Custodian_FormClosed(object sender, FormClosedEventArgs e)
        {
            Global.Function_RemoveTabStripButton(this.Tag);
        }

        private void sS_MaskedTextBox_FacilityNo_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.F1)&&((Enm_StateForm ==Enum_Mode.PreAdd)||(Enm_StateForm ==Enum_Mode.PreEdit)))
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
                Frm_Present.Controlreturnvalue2 = sS_MaskedTextBox_DeptName;
                Frm_Present.Show_Data("Screen", "002010");

                Frm_Present.ShowDialog();
                Frm_Present.Dispose();
            }
        }

        private void Form_002011_Custodian_Activated(object sender, EventArgs e)
        {
            AuthorizeState.Funtion_SetButtonAuthorize(Enm_StateForm);
        }

        private void sS_DataGridView_Custodian_Click(object sender, EventArgs e)
        {
            Function_ExecuteTransaction(Enum_Mode.ShowData);
            Enm_StateForm = Enum_Mode.CellClick;
            AuthorizeState.Funtion_SetButtonAuthorize(Enm_StateForm);
            //Global.Function_ToolStripSetUP(Enum_Mode.CellClick);

            // Edit on 07-01-09 (Additional)
            Enm_StateForm = Enum_Mode.PreAdd;
            Global.ConfigForm.Enum_FlagTransaction = Enum_Mode.PreAdd;
        }

        private void Form_002011_Custodian_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Global.Location.Int_CountForm > 0)
            {
                Global.Location.Int_CountForm = Global.Location.Int_CountForm - 1;
            }
            AuthorizeState.Funtion_SetButtonAuthorize(Enum_Mode.SetDefault);
        }

        private string Function_GetNextRunningNo()
        {
            string nextNo = "";
            try
            {
                string qry = "SELECT Prefix, CurrentRun FROM SysRunNo WHERE RunID = 3"; // Custodian

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
                             "' WHERE RunId = 3" ; // Custodian

                Manager.Engine.ExecuteCommand(qry);
            }
            catch { }

        }

        private void sS_MaskedTextBox_CustodianNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                Function_ShowDataSerchKey();

                Enm_StateForm = Enum_Mode.CellClick;
                AuthorizeState.Funtion_SetButtonAuthorize(Enm_StateForm);
                // Edit on 07-01-09 (Additional)
                Enm_StateForm = Enum_Mode.PreAdd;
                Global.ConfigForm.Enum_FlagTransaction = Enum_Mode.PreAdd;

            }
        }

        private void sS_MaskedTextBox_FirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                Function_ShowDataInDatagridViewByName();

                Enm_StateForm = Enum_Mode.CellClick;
                AuthorizeState.Funtion_SetButtonAuthorize(Enm_StateForm);
            }
        }
        private void Function_ShowDataSerchKey()
        {

            Function_ExecuteTransaction(Enum_Mode.ShowData_search);

        }
        private void Function_ShowDataInDatagridViewByName()
        {
            try
            {
                DataSet Ds_Supplier = new DataSet();
                string str_val = sS_MaskedTextBox_FirstName.Text.ToString().Trim();

                string SQL = "SELECT * FROM Custodian WHERE FirstName LIKE '%" + str_val + "%' ";

                Ds_Supplier = Manager.Engine.GetDataSet(SQL);
                if (Ds_Supplier.Tables[0].Rows.Count > 0)
                {
                    sS_DataGridView_Custodian.DataSource = Ds_Supplier;
                    sS_DataGridView_Custodian.DataMember = "Table";
                    Ds_Supplier.Dispose();
                    Ds_Supplier = null;

                    Enm_StateForm = Enum_Mode.PreSearch;
                    Function_ExecuteTransaction(Enum_Mode.Cancel);
                }
                else
                {
                    SS_MyMessageBox.ShowBox("No matched data.");
                    // Edit on 07-01-09 (Additional)
                    Enm_StateForm = Enum_Mode.PreAdd;
                    Global.ConfigForm.Enum_FlagTransaction = Enum_Mode.PreAdd;
                }
                sS_MaskedTextBox_FirstName.Focus();
                sS_MaskedTextBox_FirstName.SelectAll();
            }
            catch (Exception Err)
            {
                SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
            }
        }
    }
}