using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SimatSoft.DB.ORM;
using SimatSoft.CustomControl;
using SimatSoft.ValidateData;


namespace SimatSoft.FixAsset
{
    public partial class Form_002007_Area : SS_PaintGradientForm
    {
        private Enum_Mode Enm_StateForm = Enum_Mode.Search;
        Class_AuthorizeState AuthorizeState = new Class_AuthorizeState();
        public Form_002007_Area()
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
            this.Text = Global.Function_Language(this, this, "ID:002007(Area)");
            LBL_AreaNo.Text = Global.Function_Language(this, LBL_AreaNo, " Area No:");
            LBL_AreaName.Text = Global.Function_Language(this, LBL_AreaName, "Area Name:");
            LBL_CompanyNo.Text = Global.Function_Language(this, LBL_CompanyNo, "Company:");
            LBL_FloorNo.Text = Global.Function_Language(this, LBL_FloorNo, "Floor No:");
            LBL_BuildingNo.Text = Global.Function_Language(this, LBL_BuildingNo, "Building No:");
        }

        private void Form_002007_Area_Load(object sender, EventArgs e)
        {
            Global.Location.Int_CountForm = Global.Location.Int_CountForm + 0;
            Function_ShowDataInDatagridView();
            Function_SetReadOnlyControl(false);
            sS_MaskedTextBox_AreaNo.ReadOnly = false;
            Function_ClearData();  
   

        }
        public void Function_ExecuteTransaction(Enum_Mode mode)
        {
            try
            {
                AreaHome AreaHomeObj = new AreaHome();
                ValidateuserinputData ValidateInput = new ValidateuserinputData(Global.ConfigPath.Str_AppPathValidate + "\\" + this.Name + ".xml", this);
                object[] Obj_AreaNo = new object[1] { sS_MaskedTextBox_AreaNo.Text };
                object[] Obj_AreaRow = new object[1] { sS_DataGridView_Area.SelectedRows.Count };
                switch (mode)
                {
                    case Enum_Mode.Search:
                        {
                            break;
                        }
                    case Enum_Mode.PreAdd:
                        Function_ClearData();
                        Function_SetReadOnlyControl(false);
                        sS_MaskedTextBox_AreaNo.ReadOnly = false;
                        sS_MaskedTextBox_AreaNo.Focus();
                        Enm_StateForm = Enum_Mode.PreAdd;
                        break;
                    case Enum_Mode.Add:
                            if (ValidateInput.ValidateData(Global.Lang.Str_Language))
                            {
                                AreaHomeObj.Areaobj.ID = sS_MaskedTextBox_AreaNo.Text;
                                AreaHomeObj.Areaobj.Name = sS_MaskedTextBox_AreaName.Text;
                                AreaHomeObj.Areaobj.FacCode = sS_MaskedTextBox_FacilityNo.Text;
                                AreaHomeObj.Areaobj.BuildID = sS_MaskedTextBox_BuildingNo.Text;
                                AreaHomeObj.Areaobj.FloorID = sS_MaskedTextBox_FloorNo.Text;

                                Area AreaObj = new Area();
                                AreaObj = Manager.Engine.GetObject<Area>(sS_MaskedTextBox_AreaNo.Text);
                                if (AreaObj != null)
                                {
                                    SS_MyMessageBox.ShowBox("AreaNo : " + sS_MaskedTextBox_AreaNo.Text + " is duplicate data", "Warning", DialogMode.OkOnly, this.Name, "000010",Obj_AreaNo, Global.Lang.Str_Language);
                                    Global.Bool_CheckComplete = false;
                                    sS_MaskedTextBox_AreaNo.Focus();
                                    break;
                                }
                                else
                                {
                                    if (AreaHomeObj.Add())
                                    {
                                        SS_MyMessageBox.ShowBox("Add data : " + sS_MaskedTextBox_AreaNo.Text + " Complete", "Add Data Information", DialogMode.OkOnly, this.Name, "000001", Obj_AreaNo, Global.Lang.Str_Language);
                                        Global.Bool_CheckComplete = true;
                                        Enm_StateForm = Enum_Mode.PreAdd;
                                        Function_ExecuteTransaction(Enum_Mode.Cancel);
                                    }
                                    else
                                    {
                                        SS_MyMessageBox.ShowBox("Can not add data: " + sS_MaskedTextBox_AreaNo.Text + " !", "Warning", DialogMode.OkOnly, this.Name, "000002", Obj_AreaNo, Global.Lang.Str_Language);
                                        Global.Bool_CheckComplete = false;
                                        goto DEFAULT;
                                    }
                                }
                            }
                            else
                                Global.Bool_CheckComplete =false;
                                break;
                    case Enum_Mode.PreEdit:
                        Function_SetReadOnlyControl(false);
                        sS_MaskedTextBox_AreaName.Focus();
                        Enm_StateForm = Enum_Mode.PreEdit;
                        break;
                    case Enum_Mode.Edit:
                        {
                            if (ValidateInput.ValidateData(Global.Lang.Str_Language))
                            {
                                AreaHomeObj.Areaobj.ID = sS_MaskedTextBox_AreaNo.Text;
                                AreaHomeObj.Areaobj.Name = sS_MaskedTextBox_AreaName.Text;
                                AreaHomeObj.Areaobj.FacCode = sS_MaskedTextBox_FacilityNo.Text;
                                AreaHomeObj.Areaobj.FloorID = sS_MaskedTextBox_FloorNo.Text;
                                AreaHomeObj.Areaobj.BuildID = sS_MaskedTextBox_BuildingNo.Text;
                                if (AreaHomeObj.Edit())
                                {
                                    SS_MyMessageBox.ShowBox("Edit data : " + sS_MaskedTextBox_AreaNo.Text + " Complete", "Edit Data Information", DialogMode.OkOnly, this.Name, "000003", Obj_AreaNo, Global.Lang.Str_Language);
                                    Global.Bool_CheckComplete = true;
                                }
                                else
                                {
                                    SS_MyMessageBox.ShowBox("Can not edit data : " + sS_MaskedTextBox_AreaNo.Text + " !", "Warning", DialogMode.OkOnly, this.Name, "000004", Obj_AreaNo, Global.Lang.Str_Language);
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
                            if (sS_DataGridView_Area.SelectedRows.Count > 1)
                            {
                                List<Area> AreaCollection = new List<Area>();
                                Area TempArea = new Area();
                                foreach (DataGridViewRow TempDataGridRow in sS_DataGridView_Area.SelectedRows)
                                {
                                    TempArea = Manager.Engine.GetObject<Area>(TempDataGridRow.Cells[0].Value.ToString());
                                    AreaCollection.Add(TempArea);
                                }
                                if (SS_MyMessageBox.ShowBox("Do you want to delete data" + sS_DataGridView_Area.SelectedRows.Count + "record ?", "Delete Data Information", DialogMode.OkCancel, this.Name, "000014", Obj_AreaRow, Global.Lang.Str_Language) == DialogResult.OK)
                                {

                                    Wilson.ORMapper.Transaction ORTransaction = Manager.Engine.BeginTransaction();

                                    if (AreaHomeObj.Delete(ORTransaction, AreaCollection))
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
                                if (sS_MaskedTextBox_AreaNo.Text != "")
                                {
                                    if (SS_MyMessageBox.ShowBox("Do you want to delete : " + sS_MaskedTextBox_AreaNo.Text + " ?", "Delete Data Information", DialogMode.OkCancel, this.Name, "000005", Obj_AreaNo, Global.Lang.Str_Language) == DialogResult.OK)
                                    {
                                        Global.Bool_CheckComplete = true;
                                        AreaHomeObj.Areaobj.ID = sS_MaskedTextBox_AreaNo.Text;
                                        if (AreaHomeObj.Delete())
                                        {
                                            SS_MyMessageBox.ShowBox("Delete data : " + sS_MaskedTextBox_AreaNo.Text + "complete", "Delete Data Information", DialogMode.OkOnly, this.Name, "000006", Obj_AreaNo, Global.Lang.Str_Language);
                                            Global.Bool_CheckComplete = true;

                                            Enm_StateForm = Enum_Mode.PreAdd;
                                            Function_ShowDataInDatagridView();
                                        }
                                        else
                                        {
                                            SS_MyMessageBox.ShowBox("Can not delete data : " + sS_MaskedTextBox_AreaNo.Text + " !", "Warning", DialogMode.OkOnly, this.Name, "000007", Obj_AreaNo, Global.Lang.Str_Language);
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
                        if (sS_DataGridView_Area.Rows.Count > 0)
                        {
                            sS_MaskedTextBox_AreaNo.ReadOnly = true;
                            sS_MaskedTextBox_AreaNo.Text = sS_DataGridView_Area[0, sS_DataGridView_Area.CurrentRow.Index].Value.ToString();
                            Area AreaObj = new Area();
                            AreaObj = Manager.Engine.GetObject<Area>(sS_MaskedTextBox_AreaNo.Text);
                            if (AreaObj != null)
                            {
                                sS_MaskedTextBox_AreaName.Text = AreaObj.Name;
                                sS_MaskedTextBox_BuildingNo.Text = AreaObj.BuildID;
                                sS_MaskedTextBox_BuildName.Text = Global.FormOrder.Function_GetBuildingName(AreaObj.BuildID);
                                sS_MaskedTextBox_FloorNo.Text = AreaObj.FloorID;
                                sS_MaskedTextBox_FloorName.Text = Global.FormOrder.Function_GetFloorName(AreaObj.FloorID);
                                sS_MaskedTextBox_FacilityNo.Text = AreaObj.FacCode;
                                sS_MaskedTextBox_FacName.Text = Global.FormOrder.Function_GetFacName(AreaObj.FacCode);
                            }
                            sS_MaskedTextBox_AreaNo.Focus();
                        }
                        break;
                    case Enum_Mode.ShowData_search://
                        if (sS_DataGridView_Area.Rows.Count > 0)
                        {
                            sS_MaskedTextBox_AreaNo.ReadOnly = true;
                           // sS_MaskedTextBox_AreaNo.Text = sS_DataGridView_Area[0, sS_DataGridView_Area.CurrentRow.Index].Value.ToString();
                            Area AreaObj = new Area();
                            AreaObj = Manager.Engine.GetObject<Area>(sS_MaskedTextBox_AreaNo.Text);
                            if (AreaObj != null)
                            {
                                sS_MaskedTextBox_AreaName.Text = AreaObj.Name;
                                sS_MaskedTextBox_BuildingNo.Text = AreaObj.BuildID;
                                sS_MaskedTextBox_BuildName.Text = Global.FormOrder.Function_GetBuildingName(AreaObj.BuildID);
                                sS_MaskedTextBox_FloorNo.Text = AreaObj.FloorID;
                                sS_MaskedTextBox_FloorName.Text = Global.FormOrder.Function_GetFloorName(AreaObj.FloorID);
                                sS_MaskedTextBox_FacilityNo.Text = AreaObj.FacCode;
                                sS_MaskedTextBox_FacName.Text = Global.FormOrder.Function_GetFacName(AreaObj.FacCode);
                            }
                            else
                            {
                                SS_MyMessageBox.ShowBox("No matched data.");
                                // Edit on 07-01-09 (Additional)
                                Enm_StateForm = Enum_Mode.PreAdd;
                                Global.ConfigForm.Enum_FlagTransaction = Enum_Mode.PreAdd;

                            }
                            sS_MaskedTextBox_AreaNo.Focus();
                        }
                        break;
                        
                    case Enum_Mode.Cancel:
                        if (Enm_StateForm == Enum_Mode.PreEdit)
                        {
                            Function_ExecuteTransaction(Enum_Mode.ShowData);
                            sS_MaskedTextBox_AreaNo.Focus();
                        }
                        if (Enm_StateForm == Enum_Mode.PreAdd)
                        {
                            Function_ClearData();
                            sS_MaskedTextBox_AreaNo.Focus();
                            Function_ShowDataInDatagridView();
                        }
                        if (Enm_StateForm == Enum_Mode.PreSearch)
                        {
                            sS_MaskedTextBox_AreaNo.ReadOnly = false;
                            Function_SetReadOnlyControl(false);
                            Enm_StateForm = Enum_Mode.PreAdd;
                        }
                        else
                        {
                            sS_MaskedTextBox_AreaNo.ReadOnly = false;
                            Function_SetReadOnlyControl(false);
                            Enm_StateForm = Enum_Mode.Search;
                        }
                        break;
                    DEFAULT:
                        Function_ClearData();
                        sS_MaskedTextBox_AreaNo.ReadOnly = false;
                        sS_MaskedTextBox_AreaNo.Focus();
                        Function_ShowDataInDatagridView();
                        break;
                }
            }
            catch (Exception Err)
            {
                SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
            }
        }
        public void Function_SetReadOnlyControl(bool Bool_StateControl)
        {
            sS_MaskedTextBox_AreaName.ReadOnly = Bool_StateControl;
        }
        private void Function_ClearData()
        {
            try
            {
                sS_MaskedTextBox_AreaNo.Text = "";
                sS_MaskedTextBox_AreaName.Text = "";
                sS_MaskedTextBox_FacilityNo.Text = "";
                sS_MaskedTextBox_FacName.Text = "";
                sS_MaskedTextBox_FloorNo.Text = "";
                sS_MaskedTextBox_FloorName.Text = "";
                sS_MaskedTextBox_BuildingNo.Text = "";
                sS_MaskedTextBox_BuildName.Text = "";
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
               // Ds=Manager.Engine.GetDataSet<Area>("");
                string sql = "SELECT ";
                Ds = Manager.Engine.GetDataSet<Area>("FacCode = '" + Global.ConfigDatabase.Str_Company + "'");
                sS_DataGridView_Area.DataSource = Ds;
                sS_DataGridView_Area.DataMember = "Table";

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
                if (sS_DataGridView_Area.Rows.Count > 0)
                {
                    sS_MaskedTextBox_AreaNo.Text = sS_DataGridView_Area[0, sS_DataGridView_Area.CurrentRow.Index].Value.ToString();
                    sS_MaskedTextBox_AreaName.Text = sS_DataGridView_Area[1, sS_DataGridView_Area.CurrentRow.Index].Value.ToString();
                    sS_MaskedTextBox_FacilityNo.Text = sS_DataGridView_Area[4, sS_DataGridView_Area.CurrentRow.Index].Value.ToString();
                    sS_MaskedTextBox_BuildingNo.Text = sS_DataGridView_Area[3, sS_DataGridView_Area.CurrentRow.Index].Value.ToString();
                    sS_MaskedTextBox_FloorNo.Text = sS_DataGridView_Area[2, sS_DataGridView_Area.CurrentRow.Index].Value.ToString();
                    sS_MaskedTextBox_AreaNo.Focus();

                }
            }
            catch (Exception Err)
            {
                SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
            }
        }
       private void sS_ButtonGlass_Cancel_Click(object sender, EventArgs e)
        {
            Global.Function_ToolStripSetUP(Enum_Mode.Search);
            Function_ClearData();
        }

      
        private void Form_002007_Area_FormClosed(object sender, FormClosedEventArgs e)
        {
            Global.Function_RemoveTabStripButton(this.Tag);
        }

        private void sS_MaskedTextBox_BuildingNo_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.F1)&&((Enm_StateForm ==Enum_Mode.PreAdd)||(Enm_StateForm == Enum_Mode.PreEdit)))
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

        private void sS_MaskedTextBox_FloorNo_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.F1) && ((Enm_StateForm == Enum_Mode.PreAdd) || (Enm_StateForm == Enum_Mode.PreEdit)))
            {
                SimatSoft.QueryManager.Form_Present Frm_Present = new SimatSoft.QueryManager.Form_Present();
                Frm_Present.Controlreturnvalue = sS_MaskedTextBox_FloorNo;
                Frm_Present.Controlreturnvalue2 = sS_MaskedTextBox_FloorName;
                Frm_Present.Show_Data("Screen", "002009");

                Frm_Present.ShowDialog();
                Frm_Present.Dispose();
            }
        }

        private void Form_002007_Area_Activated(object sender, EventArgs e)
        {
            AuthorizeState.Funtion_SetButtonAuthorize(Enm_StateForm);
        }

        private void sS_DataGridView_Area_Click(object sender, EventArgs e)
        {
            Function_ExecuteTransaction(Enum_Mode.ShowData);
            Enm_StateForm = Enum_Mode.CellClick;
            AuthorizeState.Funtion_SetButtonAuthorize(Enm_StateForm);
            //Global.Function_ToolStripSetUP(Enum_Mode.CellClick);

            // Edit on 07-01-09 (Additional)
            Enm_StateForm = Enum_Mode.PreAdd;
            Global.ConfigForm.Enum_FlagTransaction = Enum_Mode.PreAdd;
        }

        private void Form_002007_Area_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Global.Location.Int_CountForm > 0)
            {
                Global.Location.Int_CountForm = Global.Location.Int_CountForm - 1;
            }
            AuthorizeState.Funtion_SetButtonAuthorize(Enum_Mode.SetDefault);
        }

        private void sS_MaskedTextBox_AreaNo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void sS_MaskedTextBox_AreaName_KeyPress(object sender, KeyPressEventArgs e)
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
                string str_val = sS_MaskedTextBox_AreaName.Text.ToString().Trim();

                string SQL = "SELECT * FROM Area WHERE areaName LIKE '%" + str_val + "%' ";

                Ds_Supplier = Manager.Engine.GetDataSet(SQL);
                if (Ds_Supplier.Tables[0].Rows.Count > 0)
                {
                    sS_DataGridView_Area.DataSource = Ds_Supplier;
                    sS_DataGridView_Area.DataMember = "Table";
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

                sS_MaskedTextBox_AreaName.Focus();
                sS_MaskedTextBox_AreaName.SelectAll();
            }
            catch (Exception Err)
            {
                SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
            }
        }
       

    }
}