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
    public partial class Form_002010_Department : SS_PaintGradientForm
    {
        private Enum_Mode Enm_StateForm = Enum_Mode.Search;
        Class_AuthorizeState AuthorizeState = new Class_AuthorizeState();

        public Form_002010_Department()
        {
            InitializeComponent();
            DarkColor = Global.ConfigForm.Colr_BackColor;
            Function_IntitialControl();
            Global.Function_ToolStripSetUP(Enum_Mode.Search);

            AuthorizeState.Function_SetAuthorize("210");
            AuthorizeState.Funtion_SetButtonAuthorize(Enm_StateForm);
        }

        private void Function_IntitialControl()
        {
            this.Text = Global.Function_Language(this, this, "ID:002010(Department)");
            LBL_DepartmentNo.Text = Global.Function_Language(this, LBL_DepartmentNo, " Department No:");
            LBL_DepartmentName.Text = Global.Function_Language(this, LBL_DepartmentName, "Department Name:");
            LBL_CompanyNo.Text = Global.Function_Language(this, LBL_CompanyNo, "Company:");
            
        }
         public void Function_ExecuteTransaction(Enum_Mode mode)
        {
            try
            {
                DepartmentHome DepartmentHomeObj = new DepartmentHome();
                ValidateuserinputData ValidateInput = new ValidateuserinputData(Global.ConfigPath.Str_AppPathValidate + "\\" + this.Name + ".xml", this);
                object[] Obj_DepartmentNo = new object[1] { sS_MaskedTextBox_DepartmentNo.Text };
                object[] Obj_DepartmentRow = new object[1] { sS_DataGridView_Department.SelectedRows.Count };
                switch (mode)
                {
                    case Enum_Mode.Search:
                        {
                            break;
                        }
                    case Enum_Mode.PreAdd:
                        Function_ClearData();
                        Function_SetReadOnlyControl(false);
                        sS_MaskedTextBox_DepartmentNo.ReadOnly = false;
                        sS_MaskedTextBox_DepartmentNo.Focus();
                        Enm_StateForm = Enum_Mode.PreAdd;
                        break;
                    case Enum_Mode.Add:
                        if (ValidateInput.ValidateData(Global.Lang.Str_Language))
                        {
                            DepartmentHomeObj.Departmentobj.DeptID = sS_MaskedTextBox_DepartmentNo.Text;
                            DepartmentHomeObj.Departmentobj.DeptName = sS_MaskedTextBox_DepartmentName.Text;
                            DepartmentHomeObj.Departmentobj.FacCode = sS_MaskedTextBox_FacilityNo.Text;

                            Department DepartmentObj = new Department();
                            DepartmentObj = Manager.Engine.GetObject<Department>(sS_MaskedTextBox_DepartmentNo.Text);
                            if (DepartmentObj != null)
                            {
                                SS_MyMessageBox.ShowBox("DepartmentNo : " + sS_MaskedTextBox_DepartmentNo.Text + " is duplicate data", "Warning", DialogMode.OkOnly, this.Name, "000010", Obj_DepartmentNo, Global.Lang.Str_Language);
                                Global.Bool_CheckComplete = false;
                                sS_MaskedTextBox_DepartmentNo.Focus();
                                break;
                            }
                            if (DepartmentHomeObj.Add())
                            {
                                SS_MyMessageBox.ShowBox("Add data : " + sS_MaskedTextBox_DepartmentNo.Text + " Complete", "Add Data Information", DialogMode.OkOnly, this.Name, "000001", Obj_DepartmentNo, Global.Lang.Str_Language);
                                Global.Bool_CheckComplete = true;
                                Enm_StateForm = Enum_Mode.PreAdd;
                                Function_ExecuteTransaction(Enum_Mode.Cancel);
                            }
                            else
                            {
                                SS_MyMessageBox.ShowBox("Can not add data: " + sS_MaskedTextBox_DepartmentNo.Text + " !", "Warning", DialogMode.OkOnly, this.Name, "000002", Obj_DepartmentNo, Global.Lang.Str_Language);
                                Global.Bool_CheckComplete = false;
                                goto DEFAULT;
                            }
                           
                        }
                        else
                            Global.Bool_CheckComplete = false;
                                break;
                    case Enum_Mode.PreEdit:
                        Function_SetReadOnlyControl(false);
                        sS_MaskedTextBox_DepartmentName.Focus();
                        Enm_StateForm = Enum_Mode.PreEdit;
                        break;
                    case Enum_Mode.Edit:
                        {
                            if (ValidateInput.ValidateData(Global.Lang.Str_Language))
                            {
                                DepartmentHomeObj.Departmentobj.DeptID = sS_MaskedTextBox_DepartmentNo.Text;
                                DepartmentHomeObj.Departmentobj.DeptName = sS_MaskedTextBox_DepartmentName.Text;
                                DepartmentHomeObj.Departmentobj.FacCode = sS_MaskedTextBox_FacilityNo.Text;
                                if (DepartmentHomeObj.Edit())
                                {
                                    SS_MyMessageBox.ShowBox("Edit data : " + sS_MaskedTextBox_DepartmentNo.Text + " Complete", "Edit Data Information", DialogMode.OkOnly, this.Name, "000003", Obj_DepartmentNo, Global.Lang.Str_Language);
                                    Global.Bool_CheckComplete = true;
                                }
                                else
                                {
                                    SS_MyMessageBox.ShowBox("Can not edit data : " + sS_MaskedTextBox_DepartmentNo.Text + " !", "Warning", DialogMode.OkOnly, this.Name, "000004", Obj_DepartmentNo, Global.Lang.Str_Language);
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
                            if (sS_DataGridView_Department.SelectedRows.Count > 1)
                            {
                                List<Department> DepartmentCollection = new List<Department>();
                                Department TempDepartment = new Department();

                                foreach (DataGridViewRow TempDataGridRow in sS_DataGridView_Department.SelectedRows)
                                {
                                    TempDepartment = Manager.Engine.GetObject<Department>(TempDataGridRow.Cells[0].Value.ToString());
                                    DepartmentCollection.Add(TempDepartment);
                                }
                                if (SS_MyMessageBox.ShowBox("Do you want to delete data" + sS_DataGridView_Department.SelectedRows.Count + "record ?", "Delete Data Information", DialogMode.OkCancel, this.Name, "000014", Obj_DepartmentRow, Global.Lang.Str_Language) == DialogResult.OK)
                                {

                                    Wilson.ORMapper.Transaction ORTransaction = Manager.Engine.BeginTransaction();

                                    if (DepartmentHomeObj.Delete(ORTransaction, DepartmentCollection))
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
                                if (sS_MaskedTextBox_DepartmentNo.Text != "")
                                {
                                    if (SS_MyMessageBox.ShowBox("Do you want to delete : " + sS_MaskedTextBox_DepartmentNo.Text + " ?", "Delete Data Information", DialogMode.OkCancel, this.Name, "000005", Obj_DepartmentNo, Global.Lang.Str_Language) == DialogResult.OK)
                                    {
                                        Global.Bool_CheckComplete = true;
                                        DepartmentHomeObj.Departmentobj.DeptID = sS_MaskedTextBox_DepartmentNo.Text;
                                        if (DepartmentHomeObj.Delete())
                                        {
                                            SS_MyMessageBox.ShowBox("Delete data : " + sS_MaskedTextBox_DepartmentNo.Text + "complete", "Delete Data Information", DialogMode.OkOnly, this.Name, "000006", Obj_DepartmentNo, Global.Lang.Str_Language);
                                            Global.Bool_CheckComplete = true;

                                            Enm_StateForm = Enum_Mode.PreAdd;
                                            Function_ShowDataInDatagridView();
                                        }
                                        else
                                        {
                                            SS_MyMessageBox.ShowBox("Can not delete data : " + sS_MaskedTextBox_DepartmentNo.Text + " !", "Warning", DialogMode.OkOnly, this.Name, "000007", Obj_DepartmentNo, Global.Lang.Str_Language);
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
                        if(sS_DataGridView_Department.Rows.Count>0)
                        {
                            sS_MaskedTextBox_DepartmentNo.ReadOnly = true;
                            sS_MaskedTextBox_DepartmentNo.Text = sS_DataGridView_Department[0, sS_DataGridView_Department.CurrentRow.Index].Value.ToString();
                            Department DepartmentObj = new Department();
                            DepartmentObj = Manager.Engine.GetObject<Department>(sS_MaskedTextBox_DepartmentNo.Text);
                            if (DepartmentObj != null)
                            {
                                sS_MaskedTextBox_DepartmentName.Text = DepartmentObj.DeptName;
                                sS_MaskedTextBox_FacilityNo.Text = DepartmentObj.FacCode;
                                sS_MaskedTextBox_FacName.Text = Global.FormOrder.Function_GetFacName(DepartmentObj.FacCode);
                            }
                            sS_MaskedTextBox_DepartmentNo.Focus();
                         }
                         break;
                     case Enum_Mode.ShowData_search://
                         if (sS_DataGridView_Department.Rows.Count > 0)
                         {
                             sS_MaskedTextBox_DepartmentNo.ReadOnly = true;
                             //sS_MaskedTextBox_DepartmentNo.Text = sS_DataGridView_Department[0, sS_DataGridView_Department.CurrentRow.Index].Value.ToString();
                             Department DepartmentObj = new Department();
                             DepartmentObj = Manager.Engine.GetObject<Department>(sS_MaskedTextBox_DepartmentNo.Text);
                             if (DepartmentObj != null)
                             {
                                 sS_MaskedTextBox_DepartmentName.Text = DepartmentObj.DeptName;
                                 sS_MaskedTextBox_FacilityNo.Text = DepartmentObj.FacCode;
                                 sS_MaskedTextBox_FacName.Text = Global.FormOrder.Function_GetFacName(DepartmentObj.FacCode);
                             }
                             else
                             {
                                 SS_MyMessageBox.ShowBox("No matched data.");
                                 // Edit on 07-01-09 (Additional)
                                 Enm_StateForm = Enum_Mode.PreAdd;
                                 Global.ConfigForm.Enum_FlagTransaction = Enum_Mode.PreAdd;
                             }
                             sS_MaskedTextBox_DepartmentNo.Focus();
                         }
                         break;
                     case Enum_Mode.Cancel:
                         if (Enm_StateForm == Enum_Mode.PreEdit)
                         {
                             Function_ExecuteTransaction(Enum_Mode.ShowData);
                             sS_MaskedTextBox_DepartmentNo.Focus();
                         }
                         if (Enm_StateForm == Enum_Mode.PreAdd)
                         {
                             Function_ClearData();
                             sS_MaskedTextBox_DepartmentNo.Focus();
                             Function_ShowDataInDatagridView();
                         }
                         if (Enm_StateForm == Enum_Mode.PreSearch)
                         {
                             sS_MaskedTextBox_DepartmentNo.ReadOnly = false;
                             Function_SetReadOnlyControl(false);
                             Enm_StateForm = Enum_Mode.PreAdd;
                         }
                         else
                         {
                             sS_MaskedTextBox_DepartmentNo.ReadOnly = false;
                             Function_SetReadOnlyControl(false);
                             Enm_StateForm = Enum_Mode.Search;
                         }
                         break;
                    DEFAULT:
                         Function_ClearData();
                         sS_MaskedTextBox_DepartmentNo.ReadOnly = false;
                         sS_MaskedTextBox_DepartmentNo.Focus();
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
                sS_MaskedTextBox_DepartmentNo.Text = "";
                sS_MaskedTextBox_DepartmentName.Text = "";
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
               // Ds= Manager.Engine.GetDataSet<Department>("");
                Ds = Manager.Engine.GetDataSet<Department>("FacCode = '" + Global.ConfigDatabase.Str_Company + "'");
                sS_DataGridView_Department.DataSource = Ds;
                sS_DataGridView_Department.DataMember = "Table";
                Ds.Dispose();
                Ds = null;
            }
            catch (Exception Err)
            {
                SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
            }
        }
        public void Function_SetReadOnlyControl(bool Bool_StateControl)
        {
            //sS_MaskedTextBox_DepartmentName.ReadOnly = Bool_StateControl;
        }
        private void Function_ShowDataInControl()
        {
            try
            {
                if (sS_DataGridView_Department.Rows.Count > 0)
                {
                    sS_MaskedTextBox_DepartmentNo.Text = sS_DataGridView_Department[0, sS_DataGridView_Department.CurrentRow.Index].Value.ToString();
                    sS_MaskedTextBox_DepartmentName.Text = sS_DataGridView_Department[1, sS_DataGridView_Department.CurrentRow.Index].Value.ToString();
                    sS_MaskedTextBox_FacilityNo.Text = sS_DataGridView_Department[2, sS_DataGridView_Department.CurrentRow.Index].Value.ToString();
                    sS_MaskedTextBox_DepartmentNo.Focus();

                }
            }
            catch (Exception Err)
            {
                SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
            }
        }
    
        private void Form_002010_Department_Load(object sender, EventArgs e)
        {
            Global.Location.Int_CountForm = Global.Location.Int_CountForm + 0;
            Function_ShowDataInDatagridView();
            Function_SetReadOnlyControl(true);
            sS_MaskedTextBox_DepartmentNo.ReadOnly = false;
            Function_ClearData();      
        }

     
        private void sS_ButtonGlass_Cancel_Click(object sender, EventArgs e)
        {
            Global.Function_ToolStripSetUP(Enum_Mode.Search);
            Function_ClearData();
        }

        private void Form_002010_Department_FormClosed(object sender, FormClosedEventArgs e)
        {
            Global.Function_RemoveTabStripButton(this.Tag);
        }

        private void sS_MaskedTextBox_FacilityNo_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.F1)&&((Enm_StateForm ==Enum_Mode.PreAdd)||(Enm_StateForm==Enum_Mode.PreEdit)))
            {
                SimatSoft.QueryManager.Form_Present Frm_Present = new SimatSoft.QueryManager.Form_Present();
                Frm_Present.Controlreturnvalue = sS_MaskedTextBox_FacilityNo;
                Frm_Present.Controlreturnvalue2 = sS_MaskedTextBox_FacName;
                Frm_Present.Show_Data("Screen", "002006");

                Frm_Present.ShowDialog();
                Frm_Present.Dispose();
            }
        }

        private void Form_002010_Department_Activated(object sender, EventArgs e)
        {
            AuthorizeState.Funtion_SetButtonAuthorize(Enm_StateForm);
        }

        private void sS_DataGridView_Department_Click(object sender, EventArgs e)
        {
            Function_ExecuteTransaction(Enum_Mode.ShowData);
            Enm_StateForm = Enum_Mode.CellClick;
            AuthorizeState.Funtion_SetButtonAuthorize(Enm_StateForm);
            //Global.Function_ToolStripSetUP(Enum_Mode.CellClick);

            // Edit on 07-01-09 (Additional)
            Enm_StateForm = Enum_Mode.PreAdd;
            Global.ConfigForm.Enum_FlagTransaction = Enum_Mode.PreAdd;
        }

        private void Form_002010_Department_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Global.Location.Int_CountForm > 0)
            {
                Global.Location.Int_CountForm = Global.Location.Int_CountForm - 1;
            }
            AuthorizeState.Funtion_SetButtonAuthorize(Enum_Mode.SetDefault);
        }

        private void sS_MaskedTextBox_DepartmentNo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void sS_MaskedTextBox_DepartmentName_KeyPress(object sender, KeyPressEventArgs e)
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
                string str_val = sS_MaskedTextBox_DepartmentName.Text.ToString().Trim();

                string SQL = "SELECT * FROM Department WHERE deptName LIKE '%" + str_val + "%' ";

                Ds_Supplier = Manager.Engine.GetDataSet(SQL);
                if (Ds_Supplier.Tables[0].Rows.Count > 0)
                {
                    sS_DataGridView_Department.DataSource = Ds_Supplier;
                    sS_DataGridView_Department.DataMember = "Table";
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
                sS_MaskedTextBox_DepartmentName.Focus();
                sS_MaskedTextBox_DepartmentName.SelectAll();
            }
            catch (Exception Err)
            {
                SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
            }
        }
    }
}