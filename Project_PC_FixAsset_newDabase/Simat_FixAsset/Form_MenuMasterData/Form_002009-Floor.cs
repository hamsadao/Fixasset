using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SimatSoft.CustomControl;
using Wilson.ORMapper;
using SimatSoft.DB.ORM;
using SimatSoft.ValidateData;

namespace SimatSoft.FixAsset
{
    
    public partial class Form_002009_Floor : SS_PaintGradientForm
    {
        private Enum_Mode Enm_StateForm = Enum_Mode.Search;
        Class_AuthorizeState AuthorizeState = new Class_AuthorizeState();
        public Form_002009_Floor()
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
            try
            {
                this.Text = Global.Function_Language(this, this, "ID:002009(Floor)");
                LBL_FloorNo.Text = Global.Function_Language(this, LBL_FloorNo, " Floor No:");
                LBL_FloorName.Text = Global.Function_Language(this, LBL_FloorName, "Floor Name:");
                LBL_BuildingNo.Text = Global.Function_Language(this, LBL_BuildingNo, "Building No:");
                LBL_CompanyNo.Text = Global.Function_Language(this, LBL_CompanyNo, "Company:");
            }
            catch (Exception Err)
            {
                SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
            }
        }

       
        public void Function_ExecuteTransaction(Enum_Mode mode)
        {
            try
            {
                FloorHome FloorHomeObj = new FloorHome();
                ValidateuserinputData ValidateInput = new ValidateuserinputData(Global.ConfigPath.Str_AppPathValidate + "\\" + this.Name + ".xml", this);
                object[] Obj_FloorNo = new object[1] { sS_MaskedTextBox_FloorNo.Text };
                object[] Obj_FloorRow = new object[1] { sS_DataGridView_Floor.SelectedRows.Count };
                switch (mode)
                {
                    case Enum_Mode.Search:
                        {
                            break;
                        }
                    case Enum_Mode.PreAdd:
                        Function_ClearData();
                        Function_SetReadOnlyControl(false);
                        sS_MaskedTextBox_FloorNo.ReadOnly = false;
                        sS_MaskedTextBox_FloorNo.Focus();
                        Enm_StateForm = Enum_Mode.PreAdd;
                        break;
                    case Enum_Mode.Add:
                            if (ValidateInput.ValidateData(Global.Lang.Str_Language))
                            {
                                FloorHomeObj.Floorobj.ID = sS_MaskedTextBox_FloorNo.Text;
                                FloorHomeObj.Floorobj.Name = sS_MaskedTextBox_FloorName.Text;
                                FloorHomeObj.Floorobj.BuildID = sS_MaskedTextBox_BuildingNo.Text;
                                FloorHomeObj.Floorobj.FacCode = sS_MaskedTextBox_FacilityNo.Text;

                                Floor FloorObj = new Floor();
                                FloorObj = Manager.Engine.GetObject<Floor>(sS_MaskedTextBox_FloorNo.Text);
                                if (FloorObj != null)
                                {
                                    SS_MyMessageBox.ShowBox("FloorNo : " + sS_MaskedTextBox_FloorNo.Text + " is duplicate data", "Warning", DialogMode.OkOnly, this.Name, "000010", Obj_FloorNo, Global.Lang.Str_Language);
                                    Global.Bool_CheckComplete = false;
                                    sS_MaskedTextBox_FloorNo.Focus();
                                    break;
                                }
                                else
                                {
                                    if (FloorHomeObj.Add())
                                    {
                                        SS_MyMessageBox.ShowBox("Add data : " + sS_MaskedTextBox_FloorNo.Text + " Complete", "Add Data Information", DialogMode.OkOnly, this.Name, "000001", Obj_FloorNo, Global.Lang.Str_Language);
                                        Global.Bool_CheckComplete = true;

                                        Enm_StateForm = Enum_Mode.PreAdd;
                                        Function_ExecuteTransaction(Enum_Mode.Cancel);
                                    }
                                    else
                                    {
                                        SS_MyMessageBox.ShowBox("Can not add data: " + sS_MaskedTextBox_FloorNo.Text + " !", "Warning", DialogMode.OkOnly, this.Name, "000002", Obj_FloorNo, Global.Lang.Str_Language);
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
                        sS_MaskedTextBox_FloorName.Focus();
                        Enm_StateForm = Enum_Mode.PreEdit;
                        break;
                    case Enum_Mode.Edit:
                        if (ValidateInput.ValidateData(Global.Lang.Str_Language))
                        {
                            FloorHomeObj.Floorobj.ID = sS_MaskedTextBox_FloorNo.Text;
                            FloorHomeObj.Floorobj.Name = sS_MaskedTextBox_FloorName.Text;
                            FloorHomeObj.Floorobj.BuildID = sS_MaskedTextBox_BuildingNo.Text;
                            FloorHomeObj.Floorobj.FacCode = sS_MaskedTextBox_FacilityNo.Text;
                            if (FloorHomeObj.Edit())
                            {
                                SS_MyMessageBox.ShowBox("Edit data : " + sS_MaskedTextBox_FloorNo.Text + " Complete", "Edit Data Information", DialogMode.OkOnly, this.Name, "000003", Obj_FloorNo, Global.Lang.Str_Language);
                                Global.Bool_CheckComplete = true;
                            }
                            else
                            {
                                SS_MyMessageBox.ShowBox("Can not edit data : " + sS_MaskedTextBox_FloorNo.Text + " !", "Warning", DialogMode.OkOnly, this.Name, "000004", Obj_FloorNo, Global.Lang.Str_Language);
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
                    case Enum_Mode.Delete:
                        if (sS_DataGridView_Floor.SelectedRows.Count > 1)
                        {
                            List<Floor> FloorCollection = new List<Floor>();
                            Floor TempFloor = new Floor();
                            foreach (DataGridViewRow TempDataGridRow in sS_DataGridView_Floor.SelectedRows)
                            {
                                TempFloor = Manager.Engine.GetObject<Floor>(TempDataGridRow.Cells[0].Value.ToString());
                                FloorCollection.Add(TempFloor);
                            }
                            if (SS_MyMessageBox.ShowBox("Do you want to delete data" + sS_DataGridView_Floor.SelectedRows.Count + "record ?", "Delete Data Information", DialogMode.OkCancel, this.Name, "000014", Obj_FloorRow, Global.Lang.Str_Language) == DialogResult.OK)
                            {

                                Wilson.ORMapper.Transaction ORTransaction = Manager.Engine.BeginTransaction();

                                if (FloorHomeObj.Delete(ORTransaction, FloorCollection))
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
                            if (sS_MaskedTextBox_FloorNo.Text != "")
                            {
                                if (SS_MyMessageBox.ShowBox("Do you want to delete : " + sS_MaskedTextBox_FloorNo.Text + " ?", "Delete Data Information", DialogMode.OkCancel, this.Name, "000005", Obj_FloorNo, Global.Lang.Str_Language) == DialogResult.OK)
                                {
                                    Global.Bool_CheckComplete = true;
                                    FloorHomeObj.Floorobj.ID = sS_MaskedTextBox_FloorNo.Text;
                                    if (FloorHomeObj.Delete())
                                    {
                                        SS_MyMessageBox.ShowBox("Delete data: " + sS_MaskedTextBox_FloorNo.Text + "complete", "Delete Data Information", DialogMode.OkOnly, this.Name, "000006", Obj_FloorNo, Global.Lang.Str_Language);
                                        Global.Bool_CheckComplete = true;

                                        Enm_StateForm = Enum_Mode.PreAdd;
                                        Function_ShowDataInDatagridView();
                                    }
                                    else
                                    {
                                        SS_MyMessageBox.ShowBox("Can not delete data : " + sS_MaskedTextBox_FloorNo.Text + " !", "Warning", DialogMode.OkOnly, this.Name, "000007", Obj_FloorNo, Global.Lang.Str_Language);
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
                 case Enum_Mode.ShowData://
                     if (sS_DataGridView_Floor.Rows.Count > 0)
                     {
                         sS_MaskedTextBox_FloorNo.ReadOnly = true;
                         sS_MaskedTextBox_FloorNo.Text = sS_DataGridView_Floor[0, sS_DataGridView_Floor.CurrentRow.Index].Value.ToString();
                         Floor FloorObj = new Floor();
                         FloorObj = Manager.Engine.GetObject<Floor>(sS_MaskedTextBox_FloorNo.Text);
                         if (FloorObj != null)
                         {
                             sS_MaskedTextBox_FloorName.Text = FloorObj.Name;
                             sS_MaskedTextBox_BuildingNo.Text = FloorObj.BuildID;
                             sS_MaskedTextBox_BuildName.Text = Global.FormOrder.Function_GetBuildingName(FloorObj.BuildID);
                             sS_MaskedTextBox_FacilityNo.Text = FloorObj.FacCode;
                             sS_MaskedTextBox_FacName.Text = Global.FormOrder.Function_GetFacName(FloorObj.FacCode);
                         }
                         sS_MaskedTextBox_FloorNo.Focus();
                     }
                     break;
                 case Enum_Mode.ShowData_search://
                     if (sS_DataGridView_Floor.Rows.Count > 0)
                     {
                         sS_MaskedTextBox_FloorNo.ReadOnly = true;
                         //sS_MaskedTextBox_FloorNo.Text = sS_DataGridView_Floor[0, sS_DataGridView_Floor.CurrentRow.Index].Value.ToString();
                         Floor FloorObj = new Floor();
                         FloorObj = Manager.Engine.GetObject<Floor>(sS_MaskedTextBox_FloorNo.Text);
                         if (FloorObj != null)
                         {
                             sS_MaskedTextBox_FloorName.Text = FloorObj.Name;
                             sS_MaskedTextBox_BuildingNo.Text = FloorObj.BuildID;
                             sS_MaskedTextBox_BuildName.Text = Global.FormOrder.Function_GetBuildingName(FloorObj.BuildID);
                             sS_MaskedTextBox_FacilityNo.Text = FloorObj.FacCode;
                             sS_MaskedTextBox_FacName.Text = Global.FormOrder.Function_GetFacName(FloorObj.FacCode);
                         }
                         else
                         {
                             SS_MyMessageBox.ShowBox("No matched data.");
                             // Edit on 07-01-09 (Additional)
                             Enm_StateForm = Enum_Mode.PreAdd;
                             Global.ConfigForm.Enum_FlagTransaction = Enum_Mode.PreAdd;

                         }
                         sS_MaskedTextBox_FloorNo.Focus();
                     }
                     break;
                 case Enum_Mode.Cancel:
                     if (Enm_StateForm == Enum_Mode.PreEdit)
                     {
                         Function_ExecuteTransaction(Enum_Mode.ShowData);
                         sS_MaskedTextBox_FloorNo.Focus();
                     }
                     if (Enm_StateForm == Enum_Mode.PreAdd)
                     {
                         Function_ClearData();
                         sS_MaskedTextBox_FloorNo.Focus();
                         Function_ShowDataInDatagridView();
                     }
                     if (Enm_StateForm == Enum_Mode.PreSearch)
                     {
                         sS_MaskedTextBox_FloorNo.ReadOnly = false;
                         Function_SetReadOnlyControl(false);
                         Enm_StateForm = Enum_Mode.PreAdd;
                     }
                     else
                     {
                         sS_MaskedTextBox_FloorNo.ReadOnly = false;
                         Function_SetReadOnlyControl(false);
                         Enm_StateForm = Enum_Mode.Search;
                     }
                     break;
                 DEFAULT:
                     Function_ClearData();
                     sS_MaskedTextBox_FloorNo.ReadOnly = false;
                     sS_MaskedTextBox_FloorNo.Focus();
                     Function_ShowDataInDatagridView();
                     break;
                }
                
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
                DataSet Ds = new DataSet();
                Ds = Manager.Engine.GetDataSet<Floor>("");
                sS_DataGridView_Floor.DataSource = Ds;
                sS_DataGridView_Floor.DataMember = "Table";
                Ds.Dispose();
                Ds = null;
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
                sS_MaskedTextBox_FloorNo.Text = "";
                sS_MaskedTextBox_FloorName.Text = "";
                sS_MaskedTextBox_BuildingNo.Text = "";
                sS_MaskedTextBox_BuildName.Text = "";
                sS_MaskedTextBox_FacilityNo.Text = "";
                sS_MaskedTextBox_FacName.Text = "";
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
                if (sS_DataGridView_Floor.Rows.Count > 0)
                {
                    sS_MaskedTextBox_FloorNo.Text = sS_DataGridView_Floor[0, sS_DataGridView_Floor.CurrentRow.Index].Value.ToString();
                    sS_MaskedTextBox_FloorName.Text = sS_DataGridView_Floor[1, sS_DataGridView_Floor.CurrentRow.Index].Value.ToString();
                    sS_MaskedTextBox_BuildingNo.Text = sS_DataGridView_Floor[2, sS_DataGridView_Floor.CurrentRow.Index].Value.ToString();
                    sS_MaskedTextBox_FacilityNo.Text = sS_DataGridView_Floor[3, sS_DataGridView_Floor.CurrentRow.Index].Value.ToString();
                    sS_MaskedTextBox_FloorNo.Focus();
                }
            }
            catch (Exception Err)
            {
                SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
            }
        }
        public void Function_SetReadOnlyControl(bool Bool_StateControl)
        {
            sS_MaskedTextBox_FloorName.ReadOnly = Bool_StateControl;
        }
        private void sS_ButtonGlass_Cancel_Click(object sender, EventArgs e)
        {
            Global.Function_ToolStripSetUP(Enum_Mode.Search);
            Function_ClearData();
        }

        private void Form_002009_Floor_FormClosed(object sender, FormClosedEventArgs e)
        {
            Global.Function_RemoveTabStripButton(this.Tag);
        }

        private void sS_MaskedTextBox_BuildingNo_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.F1)&&((Enm_StateForm ==Enum_Mode.PreAdd)||(Enm_StateForm==Enum_Mode.PreEdit)))
            {
                SimatSoft.QueryManager.Form_Present Frm_Present = new SimatSoft.QueryManager.Form_Present();
                Frm_Present.Controlreturnvalue = sS_MaskedTextBox_BuildingNo;
                Frm_Present.Controlreturnvalue2 = sS_MaskedTextBox_BuildName;
                Frm_Present.Show_Data("Screen", "002008");

                Frm_Present.ShowDialog();
                Frm_Present.Dispose();
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

        private void Form_002009_Floor_Load(object sender, EventArgs e)
        {
            Global.Location.Int_CountForm = Global.Location.Int_CountForm + 0;
            Function_ShowDataInDatagridView();
            sS_MaskedTextBox_FloorNo.ReadOnly = false;

            Function_SetReadOnlyControl(false);
            Function_ClearData();
        }

        private void Form_002009_Floor_Activated(object sender, EventArgs e)
        {
            AuthorizeState.Funtion_SetButtonAuthorize(Enm_StateForm);
        }

        private void sS_DataGridView_Floor_Click(object sender, EventArgs e)
        {
            Function_ExecuteTransaction(Enum_Mode.ShowData);
            Enm_StateForm = Enum_Mode.CellClick;
            AuthorizeState.Funtion_SetButtonAuthorize(Enm_StateForm);
            //Global.Function_ToolStripSetUP(Enum_Mode.CellClick);

            // Edit on 07-01-09 (Additional)
            Enm_StateForm = Enum_Mode.PreAdd;
            Global.ConfigForm.Enum_FlagTransaction = Enum_Mode.PreAdd;
        }

        private void Form_002009_Floor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Global.Location.Int_CountForm > 0)
            {
                Global.Location.Int_CountForm = Global.Location.Int_CountForm - 1;
            }
            AuthorizeState.Funtion_SetButtonAuthorize(Enum_Mode.SetDefault);
        }

        private void sS_MaskedTextBox_FloorNo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void sS_MaskedTextBox_FloorName_KeyPress(object sender, KeyPressEventArgs e)
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
                string str_val = sS_MaskedTextBox_FloorName.Text.ToString().Trim();

                string SQL = "SELECT * FROM Floor WHERE floorName LIKE '%" + str_val + "%' ";

                Ds_Supplier = Manager.Engine.GetDataSet(SQL);
                if (Ds_Supplier.Tables[0].Rows.Count > 0)
                {
                    sS_DataGridView_Floor.DataSource = Ds_Supplier;
                    sS_DataGridView_Floor.DataMember = "Table";
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
                sS_MaskedTextBox_FloorName.Focus();
                sS_MaskedTextBox_FloorName.SelectAll();
            }
            catch (Exception Err)
            {
                SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
            }
        }
    }
}