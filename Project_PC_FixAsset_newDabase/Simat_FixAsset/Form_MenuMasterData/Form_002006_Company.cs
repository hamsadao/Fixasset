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
    public partial class Form_002006_Company : SS_PaintGradientForm
    {
        private Enum_Mode Enm_StateForm = Enum_Mode.Search;
        Class_AuthorizeState AuthorizeState = new Class_AuthorizeState();
        public Form_002006_Company()
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
            this.Text = Global.Function_Language(this, this, "ID:002006(Company)");
            LBL_CompanyNo.Text = Global.Function_Language(this, LBL_CompanyNo, " Company No:");
            LBL_CompanyName.Text = Global.Function_Language(this, LBL_CompanyName, "Company Name:");
            LBL_Address1.Text = Global.Function_Language(this, LBL_Address1, "Address1:");
            LBL_Address2.Text = Global.Function_Language(this, LBL_Address2, "Address2:");
            LBL_City.Text = Global.Function_Language(this, LBL_City, "City:");
            LBL_Phone.Text = Global.Function_Language(this, LBL_Phone, "Phone:");

        }

        private void Form_002006_Facility_Load(object sender, EventArgs e)
        {
            Global.Location.Int_CountForm = Global.Location.Int_CountForm + 0;
            Function_ShowDataInDatagridView();
            Function_ClearData();
            sS_MaskedTextBox_FacilityNo.ReadOnly = false;
            Function_SetReadOnlyControl(true);
        }
        public void Function_ExecuteTransaction(Enum_Mode mode)
        {
            try
            {
                FacilityHome FacilityHomeObj = new FacilityHome();
                ValidateuserinputData ValidateInput = new ValidateuserinputData(Global.ConfigPath.Str_AppPathValidate + "\\" + this.Name + ".xml", this);
                object[] Obj_FacilityNo = new object[1] { sS_MaskedTextBox_FacilityNo.Text };
                object[] Obj_FacilityRow = new object[1] { sS_DataGridView_Facility.SelectedRows.Count };
                switch (mode)
                {
                    case Enum_Mode.Search:
                        {
                            break;
                        }
                    case Enum_Mode.PreAdd:
                        Function_ClearData();
                        Function_SetReadOnlyControl(false);
                        sS_MaskedTextBox_FacilityNo.ReadOnly = false;
                        sS_MaskedTextBox_FacilityNo.Focus();
                        Enm_StateForm = Enum_Mode.PreAdd;
                        break;
                    case Enum_Mode.Add:

                        if (ValidateInput.ValidateData(Global.Lang.Str_Language))
                        {
                            FacilityHomeObj.Facilityobj.FacCode = sS_MaskedTextBox_FacilityNo.Text;
                            FacilityHomeObj.Facilityobj.FacName = sS_MaskedTextBox_FacilityName.Text;
                            FacilityHomeObj.Facilityobj.Address1 = sS_MaskedTextBox_Address1.Text;
                            FacilityHomeObj.Facilityobj.Address2 = sS_MaskedTextBox_Address2.Text;
                            FacilityHomeObj.Facilityobj.FacCity = sS_MaskedTextBox_City.Text;
                            FacilityHomeObj.Facilityobj.Phone = sS_MaskedTextBox_Phone.Text;

                            Facility FacilityObj = new Facility();
                            FacilityObj = Manager.Engine.GetObject<Facility>(sS_MaskedTextBox_FacilityNo.Text);
                            if (FacilityObj != null)
                            {
                                SS_MyMessageBox.ShowBox("CompanyNo : " + sS_MaskedTextBox_FacilityNo.Text + "is duplicate data", "Warning", DialogMode.OkOnly, this.Name, "000010", Obj_FacilityNo, Global.Lang.Str_Language);
                                Global.Bool_CheckComplete = false;
                                sS_MaskedTextBox_FacilityNo.Focus();
                                break;
                            }
                            else
                            {
                                if (FacilityHomeObj.Add())
                                {
                                    SS_MyMessageBox.ShowBox("Add data : " + sS_MaskedTextBox_FacilityNo.Text + " Complete", "Add Data Information", DialogMode.OkOnly, this.Name, "000001", Obj_FacilityNo, Global.Lang.Str_Language);
                                    Global.Bool_CheckComplete = true;
                                    Enm_StateForm = Enum_Mode.PreAdd;
                                    Function_ExecuteTransaction(Enum_Mode.Cancel);
                                }
                                else
                                {
                                    SS_MyMessageBox.ShowBox("Can not add data: " + sS_MaskedTextBox_FacilityNo.Text + " !", "Warning", DialogMode.OkOnly, this.Name, "000002", Obj_FacilityNo, Global.Lang.Str_Language);
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
                        sS_MaskedTextBox_FacilityName.Focus();
                        Enm_StateForm = Enum_Mode.PreEdit;
                        break;
                    case Enum_Mode.Edit:
                        if (ValidateInput.ValidateData(Global.Lang.Str_Language))
                        {
                            FacilityHomeObj.Facilityobj.FacCode = sS_MaskedTextBox_FacilityNo.Text;
                            FacilityHomeObj.Facilityobj.FacName = sS_MaskedTextBox_FacilityName.Text;
                            FacilityHomeObj.Facilityobj.Address1 = sS_MaskedTextBox_Address1.Text;
                            FacilityHomeObj.Facilityobj.Address2 = sS_MaskedTextBox_Address2.Text;
                            FacilityHomeObj.Facilityobj.FacCity = sS_MaskedTextBox_City.Text;
                            FacilityHomeObj.Facilityobj.Phone = sS_MaskedTextBox_Phone.Text;
                            if (FacilityHomeObj.Edit())
                            {
                                SS_MyMessageBox.ShowBox("Edit data : " + sS_MaskedTextBox_FacilityNo.Text + " Complete", "Edit Data Information", DialogMode.OkOnly, this.Name, "000003", Obj_FacilityNo, Global.Lang.Str_Language);
                                Global.Bool_CheckComplete = true;
                            }
                            else
                            {
                                SS_MyMessageBox.ShowBox("Can not edit data : " + sS_MaskedTextBox_FacilityNo.Text + " !", "Warning", DialogMode.OkOnly, this.Name, "000004", Obj_FacilityNo, Global.Lang.Str_Language);
                                Global.Bool_CheckComplete = false;
                            }
                            Enm_StateForm = Enum_Mode.PreEdit;
                            Function_ExecuteTransaction(Enum_Mode.Cancel);
                            Function_ShowDataInDatagridView();
                           // goto DEFAULT;
                        }
                        else
                            Global.Bool_CheckComplete = false;
                                break;
                     case Enum_Mode.Delete:
                         if (sS_DataGridView_Facility.SelectedRows.Count > 1)
                         {
                             List<Facility> FacilityCollection = new List<Facility>();
                             Facility TempFacility = new Facility();
                             foreach (DataGridViewRow TempDataGridRow in sS_DataGridView_Facility.SelectedRows)
                             {
                                 TempFacility =Manager.Engine.GetObject<Facility>(TempDataGridRow.Cells[0].Value.ToString());
                                 FacilityCollection.Add(TempFacility);
                             }

                              if (SS_MyMessageBox.ShowBox("Do you want to delete data" + sS_DataGridView_Facility.SelectedRows.Count + "record ?", "Delete Data Information", DialogMode.OkCancel, this.Name, "000014", Obj_FacilityRow, Global.Lang.Str_Language) == DialogResult.OK)
                            {

                                Wilson.ORMapper.Transaction ORTransaction = Manager.Engine.BeginTransaction();

                                if (FacilityHomeObj.Delete(ORTransaction, FacilityCollection))
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
                             if (sS_MaskedTextBox_FacilityNo.Text != "")
                             {
                                 if (SS_MyMessageBox.ShowBox("Do you want to delete : " + sS_MaskedTextBox_FacilityNo.Text + " ?", "Delete Data Information", DialogMode.OkCancel, this.Name, "000005", Obj_FacilityNo, Global.Lang.Str_Language) == DialogResult.OK)
                                 {
                                     Global.Bool_CheckComplete = true;
                                     FacilityHomeObj.Facilityobj.FacCode = sS_MaskedTextBox_FacilityNo.Text;
                                     if (FacilityHomeObj.Delete())
                                     {
                                         SS_MyMessageBox.ShowBox("Delete data : " + sS_MaskedTextBox_FacilityNo.Text + "complete", "Delete Data Information", DialogMode.OkOnly, this.Name, "000006", Obj_FacilityNo, Global.Lang.Str_Language);
                                         Global.Bool_CheckComplete = true;

                                         Enm_StateForm = Enum_Mode.PreAdd;
                                         Function_ShowDataInDatagridView();
                                     }
                                     else
                                     {
                                         SS_MyMessageBox.ShowBox("Can not delete data : " + sS_MaskedTextBox_FacilityNo.Text + " !", "Warning", DialogMode.OkOnly, this.Name, "000007", Obj_FacilityNo, Global.Lang.Str_Language);
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
                        if (sS_DataGridView_Facility.Rows.Count > 0)
                        {
                            sS_MaskedTextBox_FacilityNo.ReadOnly = true;
                            sS_MaskedTextBox_FacilityNo.Text = sS_DataGridView_Facility[0, sS_DataGridView_Facility.CurrentRow.Index].Value.ToString();
                            Facility FacilityObj = new Facility();
                            FacilityObj = Manager.Engine.GetObject<Facility>(sS_MaskedTextBox_FacilityNo.Text);
                            if (FacilityObj != null)
                            {
                                sS_MaskedTextBox_FacilityName.Text = FacilityObj.FacName;
                                sS_MaskedTextBox_Address1.Text = FacilityObj.Address1;
                                sS_MaskedTextBox_Address2.Text = FacilityObj.Address2;
                                sS_MaskedTextBox_City.Text = FacilityObj.FacCity;
                                sS_MaskedTextBox_Phone.Text = FacilityObj.Phone;
                            }
                            sS_MaskedTextBox_FacilityNo.Focus();
                        }
                        break;
                    case Enum_Mode.ShowData_search://
                        if (sS_DataGridView_Facility.Rows.Count > 0)
                        {
                            sS_MaskedTextBox_FacilityNo.ReadOnly = true;
                           // sS_MaskedTextBox_FacilityNo.Text = sS_DataGridView_Facility[0, sS_DataGridView_Facility.CurrentRow.Index].Value.ToString();
                            Facility FacilityObj = new Facility();
                            FacilityObj = Manager.Engine.GetObject<Facility>(sS_MaskedTextBox_FacilityNo.Text);
                            if (FacilityObj != null)
                            {
                                sS_MaskedTextBox_FacilityName.Text = FacilityObj.FacName;
                                sS_MaskedTextBox_Address1.Text = FacilityObj.Address1;
                                sS_MaskedTextBox_Address2.Text = FacilityObj.Address2;
                                sS_MaskedTextBox_City.Text = FacilityObj.FacCity;
                                sS_MaskedTextBox_Phone.Text = FacilityObj.Phone;
                            }
                            else
                            {
                                SS_MyMessageBox.ShowBox("No matched data.");
                                // Edit on 07-01-09 (Additional)
                                Enm_StateForm = Enum_Mode.PreAdd;
                                Global.ConfigForm.Enum_FlagTransaction = Enum_Mode.PreAdd;

                            }
                            sS_MaskedTextBox_FacilityNo.Focus();
                        }
                        break;
                    case Enum_Mode.Cancel:
                        if (Enm_StateForm == Enum_Mode.PreEdit)
                        {
                            Function_ExecuteTransaction(Enum_Mode.ShowData);
                            sS_MaskedTextBox_FacilityNo.Focus();
                        }
                        if(Enm_StateForm ==Enum_Mode.PreAdd)
                        {
                            Function_ClearData();
                            sS_MaskedTextBox_FacilityNo.Focus();
                            Function_ShowDataInDatagridView();
                        }
                        if (Enm_StateForm == Enum_Mode.PreSearch)
                        {
                            sS_MaskedTextBox_FacilityNo.ReadOnly = false;
                            Function_SetReadOnlyControl(false);
                            Enm_StateForm = Enum_Mode.PreAdd;
                        }
                        else
                        {
                            sS_MaskedTextBox_FacilityNo.ReadOnly = false;
                            Function_SetReadOnlyControl(true);
                            Enm_StateForm = Enum_Mode.Search;
                        }
                        break;
                    DEFAULT:
                        Function_ClearData();
                        sS_MaskedTextBox_FacilityNo.ReadOnly = false;
                        sS_MaskedTextBox_FacilityNo.Focus();
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
                sS_MaskedTextBox_FacilityNo.Text = "";
                sS_MaskedTextBox_FacilityName.Text = "";
                sS_MaskedTextBox_Address1.Text = "";
                sS_MaskedTextBox_Address2.Text = "";
                sS_MaskedTextBox_City.Text = "";
                sS_MaskedTextBox_Phone.Text = "";
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
                Ds=Manager.Engine.GetDataSet<Facility>("");
                sS_DataGridView_Facility.DataSource = Ds;
                sS_DataGridView_Facility.DataMember = "Table";

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
                if (sS_DataGridView_Facility.Rows.Count > 0)
                {
                    sS_MaskedTextBox_FacilityNo.Text = sS_DataGridView_Facility[0, sS_DataGridView_Facility.CurrentRow.Index].Value.ToString();
                    sS_MaskedTextBox_FacilityName.Text = sS_DataGridView_Facility[1, sS_DataGridView_Facility.CurrentRow.Index].Value.ToString();
                    sS_MaskedTextBox_Address1.Text = sS_DataGridView_Facility[2, sS_DataGridView_Facility.CurrentRow.Index].Value.ToString();
                    sS_MaskedTextBox_Address2.Text = sS_DataGridView_Facility[3, sS_DataGridView_Facility.CurrentRow.Index].Value.ToString();
                    sS_MaskedTextBox_City.Text = sS_DataGridView_Facility[5, sS_DataGridView_Facility.CurrentRow.Index].Value.ToString();
                    sS_MaskedTextBox_Phone.Text = sS_DataGridView_Facility[4, sS_DataGridView_Facility.CurrentRow.Index].Value.ToString();
                    sS_MaskedTextBox_FacilityNo.Focus();
                }
            }
            catch (Exception Err)
            {
                SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
            }
        }
        public void Function_SetReadOnlyControl(bool Bool_StateControl)
        {
            sS_MaskedTextBox_FacilityName.ReadOnly = false;
            sS_MaskedTextBox_Address1.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_Address2.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_City.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_Phone.ReadOnly = Bool_StateControl;
        }
    
        private void Form_002006_Facility_FormClosed(object sender, FormClosedEventArgs e)
        {
            Global.Function_RemoveTabStripButton(this.Tag);
        }

        private void Form_002006_Facility_Activated(object sender, EventArgs e)
        {
            AuthorizeState.Funtion_SetButtonAuthorize(Enm_StateForm);
        }

        private void sS_DataGridView_Facility_Click(object sender, EventArgs e)
        {
            Function_ExecuteTransaction(Enum_Mode.ShowData);
            Enm_StateForm = Enum_Mode.CellClick;
            AuthorizeState.Funtion_SetButtonAuthorize(Enm_StateForm);
            //Global.Function_ToolStripSetUP(Enum_Mode.CellClick);

            // Edit on 07-01-09 (Additional)
            Enm_StateForm = Enum_Mode.PreAdd;
            Global.ConfigForm.Enum_FlagTransaction = Enum_Mode.PreAdd;
            
        }

        private void Form_002006_Company_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Global.Location.Int_CountForm > 0)
            {
                Global.Location.Int_CountForm = Global.Location.Int_CountForm - 1;
            }
            AuthorizeState.Funtion_SetButtonAuthorize(Enum_Mode.SetDefault);
        }

        private void sS_MaskedTextBox_FacilityNo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void sS_MaskedTextBox_FacilityName_KeyPress(object sender, KeyPressEventArgs e)
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
                string str_val = sS_MaskedTextBox_FacilityName.Text.ToString().Trim();

                string SQL = "SELECT * FROM Facility WHERE FacName LIKE '%" + str_val + "%' ";

                Ds_Supplier = Manager.Engine.GetDataSet(SQL);
                if (Ds_Supplier.Tables[0].Rows.Count > 0)
                {
                    sS_DataGridView_Facility.DataSource = Ds_Supplier;
                    sS_DataGridView_Facility.DataMember = "Table";
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
                sS_MaskedTextBox_FacilityName.Focus();
                sS_MaskedTextBox_FacilityName.SelectAll();
            }
            catch (Exception Err)
            {
                SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
            }
        }
    }
}