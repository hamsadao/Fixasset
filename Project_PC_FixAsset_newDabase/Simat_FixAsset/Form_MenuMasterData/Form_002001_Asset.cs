using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SimatSoft.DB.ORM;
using SimatSoft.CustomControl;
using Wilson.ORMapper;
using SimatSoft.ValidateData;
using SimatSoft.QueryManager;
using System.Drawing.Printing;

namespace SimatSoft.FixAsset
{
    public partial class Form_002001_Asset : SS_PaintGradientForm
    {

        public Class_QueryManager clsquery = new Class_QueryManager();
        Class_AuthorizeState AuthorizeState = new Class_AuthorizeState();
        private Enum_Mode Enm_StateForm = Enum_Mode.Search;
        //private Enum_Mode Temp_CheckEnumState = Enum_Mode.Search;
        private string Str_PreviousCustodian = "";
        private string currentNo = "";
        string AssetNo;
        string AssetName;
        string Depart;
        string Date;
        public Form_002001_Asset()
        {
            InitializeComponent();
            DarkColor = Global.ConfigForm.Colr_BackColor;
            Function_IntitialControl();
           // Global.Function_ToolStripSetUP(Enum_Mode.Search);

            AuthorizeState.Function_SetAuthorize(this.Name.Substring(5, 6).Replace("0", ""));
            AuthorizeState.Funtion_SetButtonAuthorize(Enm_StateForm);
            

        }
        private void Function_IntitialControl()
        {
            this.Text = Global.Function_Language(this, this, "ID:002001(Assets)");
            LBL_AssetNo.Text = Global.Function_Language(this, LBL_AssetNo, " Asset No:");
            LBL_AssetName.Text = Global.Function_Language(this, LBL_AssetName, "Asset Name:");
            LBL_ModelID.Text = Global.Function_Language(this, LBL_ModelID, " Model:");
            LBL_SerialNo.Text = Global.Function_Language(this, LBL_SerialNo, "Serial:");
            LBL_TypeNo.Text = Global.Function_Language(this, LBL_TypeNo, " Type:");
            LBL_SupplierNo.Text = Global.Function_Language(this, LBL_SupplierNo, "Supplier:");
            LBL_DepartmentNo.Text = Global.Function_Language(this, LBL_DepartmentNo, " Department:");
            LBL_BuildingNo.Text = Global.Function_Language(this, LBL_BuildingNo, "Building:");
            LBL_FloorNo.Text = Global.Function_Language(this, LBL_FloorNo, " Floor:");
            LBL_AreaNo.Text = Global.Function_Language(this, LBL_AreaNo, "Area:");
            LBL_ReasonNo.Text = Global.Function_Language(this, LBL_ReasonNo, " Reason:");
            LBL_CurrentCustodianNo.Text = Global.Function_Language(this, LBL_CurrentCustodianNo, "CurrentCustomer:");
            LBL_PreviousCustodianNo.Text = Global.Function_Language(this, LBL_PreviousCustodianNo, " PreviousCustomer:");
            LBL_Remark.Text = Global.Function_Language(this, LBL_Remark, "Remark:");
            LBL_PurchasePrice.Text = Global.Function_Language(this, LBL_PurchasePrice, "PurchasePrice:");
            LBL_StatusNo.Text = Global.Function_Language(this, LBL_StatusNo, "Status:");
            LBL_WarrantyStartDate.Text = Global.Function_Language(this, LBL_WarrantyStartDate, " Warranty Start Date:");
            //LBL_WarrantyEndDate.Text = Global.Function_Language(this, LBL_WarrantyEndDate, "Warranty End Date:");
            LBL_UserName.Text = Global.Function_Language(this, LBL_UserName, " UserName:");
            LBL_DateAdded.Text = Global.Function_Language(this, LBL_DateAdded, "DateAdded:");
            LBL_LastInventoryDate.Text = Global.Function_Language(this, LBL_LastInventoryDate, " LastInventoryDate:");
            LBL_Company.Text = Global.Function_Language(this, LBL_Company, "Company:");
            LBL_MANo.Text = Global.Function_Language(this, LBL_MANo, "MA Contract No:");
            LBL_Capex.Text = Global.Function_Language(this, LBL_Capex, "Capex No:");
            LBL_QTNo.Text = Global.Function_Language(this, LBL_QTNo, "Quotation No:");
            LBL_InvNo.Text = Global.Function_Language(this, LBL_InvNo, "Invoice No:");
            LBL_PRNo.Text = Global.Function_Language(this, LBL_PRNo, "PR No:");
            LBL_PONo.Text = Global.Function_Language(this, LBL_PONo, "PO No:");
            LBL_SName.Text = Global.Function_Language(this, LBL_SName, "Asset Short Name:");
            LBL_JDENo.Text = Global.Function_Language(this, LBL_JDENo, "JDE No:");
            LBL_MAStartDt.Text = Global.Function_Language(this, LBL_MAStartDt, "MA Start Date:");

        }
        private void Form_002001_Asset_Load(object sender, EventArgs e)
        {
            Global.Location.Int_CountForm = Global.Location.Int_CountForm + 0;
            //Function_ShowDataInDatagridView();
            Function_ClearData();
            //Function_ShowDataInDatagrid();
            clsquery.Show_Data("Screen", "002001", this, ref sS_DataGridView_Asset);
            clsquery.Searchdata(this, ref sS_DataGridView_Asset);
            Function_SetReadOnlyControl(true);
            //sS_MaskedTextBox_AssetNo.ReadOnly = true;

            sS_MaskedTextBox_PreviousCustodianNo.Enabled = true;
            sS_MaskedTextBox_PreviousCustodianName.Enabled = true;
           
            Function_SetReadOnlyControlSearch(true);
            Function_EnableControlDate(false);
            sS_MaskedTextBox_PurchasePrice.Text = "0.00";
            sS_MaskedTextBox_UserName.Enabled = false;
            sS_MaskedTextBox_UserName.Text = Global.ConfigDatabase.Str_UserName;
            
           
        }
        public void Function_EnableControlDate(bool Bool_State)
        {
            dateTimePicker_DateAdded.Enabled = Bool_State;
            dateTimePicker_LastInventoryDate.Enabled = Bool_State;
            dateTimePicker_WarrantyEndDate.Enabled = Bool_State;
            dateTimePicker_WarrantyStartDate.Enabled = Bool_State;
            dateTimePicker_InvDt.Enabled = Bool_State;
            dateTimePicker_MAStartDate.Enabled = Bool_State;
            dateTimePicker_MAEndDate.Enabled = Bool_State;

        }
        public void Function_ExecuteTransaction(Enum_Mode mode)
        {
            try
            {
                AssetHome AssetHomeObj = new AssetHome();
                ValidateuserinputData ValidateInput = new ValidateuserinputData(Global.ConfigPath.Str_AppPathValidate + "\\" + this.Name + ".xml", this);
                object[] Obj_AssetNo = new object[1] { sS_MaskedTextBox_AssetNo.Text };
                object[] Obj_AssetRow = new object[1] { sS_DataGridView_Asset.SelectedRows.Count };
                switch (mode)
                {
                    case Enum_Mode.Search:
                        Function_ClearData();
                        sS_MaskedTextBox_AssetNo.ReadOnly = false;
                        sS_MaskedTextBox_AssetNo.Focus();
                        //Function_ShowDataInDatagridView();
                        clsquery.Searchdata(this, ref sS_DataGridView_Asset);
                        break;
                    case Enum_Mode.PreAdd:
                        Function_ClearData();
                        Function_SetReadOnlyControl(false);
                        Function_SetReadOnlyControlSearch(true);
                        Function_EnableControlDate(true);
                        ///////////Edit on 19-02-09 //////////
                        sS_DataGridView_Asset.Enabled = false;
                        //////////////////////////

                        ///////  Edit on 26-01-09 ///////

                        dateTimePicker_WarrantyStartDate.Value = System.DateTime.Now;
                        dateTimePicker_WarrantyEndDate.Value = System.DateTime.Now;
                        dateTimePicker_MAStartDate.Value = System.DateTime.Now;
                        dateTimePicker_MAEndDate.Value = System.DateTime.Now;
                        dateTimePicker_InvDt.Value = System.DateTime.Now;
                        dateTimePicker_DateAdded.Value = System.DateTime.Now;
                        dateTimePicker_LastInventoryDate.Value = System.DateTime.Now;

                        ////////////////////
                        sS_MaskedTextBox_UserName.Enabled = false;
                        sS_MaskedTextBox_AssetNo.Text = Function_GetNextRunningNo();
                        sS_MaskedTextBox_AssetNo.ReadOnly = false;
                        sS_MaskedTextBox_AssetNo.Focus();
                        Enm_StateForm = Enum_Mode.PreAdd;
                        break;

                    case Enum_Mode.Add:
                        if (ValidateInput.ValidateData(Global.Lang.Str_Language))
                        {
                            AssetHomeObj.Assetobj.ID = sS_MaskedTextBox_AssetNo.Text;
                            AssetHomeObj.Assetobj.Name = sS_MaskedTextBox_AssetName.Text;
                            AssetHomeObj.Assetobj.ModelID = sS_MaskedTextBox_ModelID.Text;
                            AssetHomeObj.Assetobj.SerialNo = sS_MaskedTextBox_SerailNo.Text;
                            AssetHomeObj.Assetobj.TypeID = sS_MaskedTextBox_TypeNo.Text;

                            Class_CheckMaster.Function_CheckData.TB_Asset("Type", AssetHomeObj);

                           AssetHomeObj.Assetobj.VendorID = sS_MaskedTextBox_SupplierNo.Text;
                            AssetHomeObj.Assetobj.DeptID = sS_MaskedTextBox_DepartmentNo.Text;
                            AssetHomeObj.Assetobj.BuildID = sS_MaskedTextBox_BuildingNo.Text;
                            AssetHomeObj.Assetobj.FloorID = sS_MaskedTextBox_FloorNo.Text;
                            AssetHomeObj.Assetobj.AreaID = sS_MaskedTextBox_AreaNo.Text;

                            Class_CheckMaster.Function_CheckData.TB_Asset("Area", AssetHomeObj);

                            AssetHomeObj.Assetobj.Remark = sS_MaskedTextBox_Remark.Text;
                            AssetHomeObj.Assetobj.ReasonCode = sS_MaskedTextBox_ReasonNo.Text;
                            AssetHomeObj.Assetobj.CustodianID = sS_MaskedTextBox_CurrentCustodianNo.Text;
                            AssetHomeObj.Assetobj.PreviosCustodian = sS_MaskedTextBox_PreviousCustodianNo.Text;
                            //if (sS_MaskedTextBox_PurchasePrice.Text == "")
                            //{
                            //    sS_MaskedTextBox_PurchasePrice.Text = "0.00";
                            //}
                            AssetHomeObj.Assetobj.Price = Convert.ToDecimal(sS_MaskedTextBox_PurchasePrice.Text);
                            AssetHomeObj.Assetobj.StatusID = sS_MaskedTextBox_StatusNo.Text;

                            Class_CheckMaster.Function_CheckData.TB_Asset("Status", AssetHomeObj);

                            AssetHomeObj.Assetobj.WarrantyStartDate = dateTimePicker_WarrantyStartDate.Value.Date;
                            AssetHomeObj.Assetobj.WarrantyEndDate = dateTimePicker_WarrantyEndDate.Value.Date;

                            AssetHomeObj.Assetobj.UserName = Global.ConfigDatabase.Str_UserID;
                            AssetHomeObj.Assetobj.CreatedDate = dateTimePicker_DateAdded.Value.Date;

                            AssetHomeObj.Assetobj.UpdateDate = dateTimePicker_LastInventoryDate.Value.Date;
                            AssetHomeObj.Assetobj.FacCode = sS_MaskedTextBox_FacilityNo.Text;

                            AssetHomeObj.Assetobj.Customfiled1 = sS_MaskedTextBox_JDENo.Text;
                            AssetHomeObj.Assetobj.Customfiled2 = sS_MaskedTextBox_Capex.Text;
                            AssetHomeObj.Assetobj.Customfiled3 = sS_MaskedTextBox_InvNo.Text;
                            //AssetHomeObj.Assetobj.Customfiled4 = dateTimePicker_InvDt.Value.Date.ToString();
                            AssetHomeObj.Assetobj.Customfiled4 = dateTimePicker_InvDt.Value.Date;
                            AssetHomeObj.Assetobj.Customfiled5 = sS_MaskedTextBox_QTNo.Text;
                            AssetHomeObj.Assetobj.Customfiled6 = sS_MaskedTextBox_MANo.Text;
                            AssetHomeObj.Assetobj.Customfiled7 = sS_MaskedTextBox_PRNo.Text;
                            AssetHomeObj.Assetobj.Customfiled8 = sS_MaskedTextBox_PONo.Text;
                            AssetHomeObj.Assetobj.Customfiled9 = sS_MaskedTextBox_SName.Text;
                            //AssetHomeObj.Assetobj.Customfiled10 = dateTimePicker_MAStartDate.Value.Date.ToString();
                            AssetHomeObj.Assetobj.Customfiled10 = dateTimePicker_MAStartDate.Value.Date;
                            AssetHomeObj.Assetobj.Customfiled11 = dateTimePicker_MAEndDate.Value.Date.ToString();

                            Asset AssetObj = new Asset();
                            AssetObj = Manager.Engine.GetObject<Asset>(sS_MaskedTextBox_AssetNo.Text);

                            if (AssetObj!=null)
                            {
                                SS_MyMessageBox.ShowBox("AssetNo : " + sS_MaskedTextBox_AssetNo.Text + " is duplicate data", "Warning", DialogMode.OkOnly, this.Name, "000010", Obj_AssetNo, Global.Lang.Str_Language);
                                Global.Bool_CheckComplete = false;
                                sS_MaskedTextBox_AssetNo.Focus();
                                break;
                            }

                            if (AssetHomeObj.Add())
                            {
                                Function_SaveCurrentRunningNo(currentNo);
                                SS_MyMessageBox.ShowBox("Add data : " + sS_MaskedTextBox_AssetNo.Text + " Complete", "Add Data Information", DialogMode.OkOnly, this.Name, "000001", Obj_AssetNo, Global.Lang.Str_Language);
                                Global.Bool_CheckComplete = true;
                                Enm_StateForm = Enum_Mode.PreAdd;
                                Function_ExecuteTransaction(Enum_Mode.Cancel);
                                ///////////Edit on 19-02-09 //////////
                                sS_DataGridView_Asset.Enabled = true;
                                //////////////////////////
                                                               
                            }
                            else
                            {
                                SS_MyMessageBox.ShowBox("Can not add data: " + sS_MaskedTextBox_AssetNo.Text + " !", "Warning", DialogMode.OkOnly, this.Name, "000002", Obj_AssetNo, Global.Lang.Str_Language);
                                Global.Bool_CheckComplete = false;
                                goto DEFAULT;
                            }
                        }
                        else
                            Global.Bool_CheckComplete = false;
                                break;

                    case Enum_Mode.PreEdit:
                        sS_MaskedTextBox_AssetName.Focus();
                        Function_SetReadOnlyControl(false);
                        Function_SetReadOnlyControlSearch(true);
                        sS_MaskedTextBox_UserName.Enabled = false;
                        Function_EnableControlDate(true);
                        dateTimePicker_DateAdded.Enabled = false;
                        Enm_StateForm = Enum_Mode.PreEdit;
                        ///////////Edit on 19-02-09 //////////
                       // sS_DataGridView_Asset.Enabled = true;

                        // Edit on 13-03-09
                        sS_DataGridView_Asset.Enabled = false;
                        //////////////////////////
                        break;
                    case Enum_Mode.Edit:
                        {

                            if (ValidateInput.ValidateData(Global.Lang.Str_Language))
                            {
                                AssetHomeObj.Assetobj.ID = sS_MaskedTextBox_AssetNo.Text;
                                AssetHomeObj.Assetobj.Name = sS_MaskedTextBox_AssetName.Text;
                                AssetHomeObj.Assetobj.ModelID = sS_MaskedTextBox_ModelID.Text;
                                AssetHomeObj.Assetobj.SerialNo = sS_MaskedTextBox_SerailNo.Text;
                                AssetHomeObj.Assetobj.TypeID = sS_MaskedTextBox_TypeNo.Text;

                                Class_CheckMaster.Function_CheckData.TB_Asset("Type", AssetHomeObj);

                                AssetHomeObj.Assetobj.VendorID = sS_MaskedTextBox_SupplierNo.Text;
                                AssetHomeObj.Assetobj.DeptID = sS_MaskedTextBox_DepartmentNo.Text;
                                AssetHomeObj.Assetobj.BuildID = sS_MaskedTextBox_BuildingNo.Text;
                                AssetHomeObj.Assetobj.FloorID = sS_MaskedTextBox_FloorNo.Text;
                                AssetHomeObj.Assetobj.AreaID = sS_MaskedTextBox_AreaNo.Text;

                                Class_CheckMaster.Function_CheckData.TB_Asset("Area", AssetHomeObj);

                                AssetHomeObj.Assetobj.Remark = sS_MaskedTextBox_Remark.Text;
                                AssetHomeObj.Assetobj.ReasonCode = sS_MaskedTextBox_ReasonNo.Text;
                                AssetHomeObj.Assetobj.CustodianID = sS_MaskedTextBox_CurrentCustodianNo.Text;
                                AssetHomeObj.Assetobj.PreviosCustodian = Function_SetPreviousCustodian();
                                AssetHomeObj.Assetobj.StatusID = sS_MaskedTextBox_StatusNo.Text;
                                AssetHomeObj.Assetobj.Price = Convert.ToDecimal(sS_MaskedTextBox_PurchasePrice.Text);

                                Class_CheckMaster.Function_CheckData.TB_Asset("Status", AssetHomeObj);

                                AssetHomeObj.Assetobj.WarrantyStartDate = dateTimePicker_WarrantyStartDate.Value.Date;
                                AssetHomeObj.Assetobj.WarrantyEndDate = dateTimePicker_WarrantyEndDate.Value.Date;
                                AssetHomeObj.Assetobj.UserName = Global.ConfigDatabase.Str_UserID;
                                AssetHomeObj.Assetobj.CreatedDate = dateTimePicker_DateAdded.Value.Date;
                                AssetHomeObj.Assetobj.UpdateDate = dateTimePicker_LastInventoryDate.Value.Date;
                                AssetHomeObj.Assetobj.FacCode = sS_MaskedTextBox_FacilityNo.Text;

                                AssetHomeObj.Assetobj.Customfiled1 = sS_MaskedTextBox_JDENo.Text;
                                AssetHomeObj.Assetobj.Customfiled2 = sS_MaskedTextBox_Capex.Text;
                                AssetHomeObj.Assetobj.Customfiled3 = sS_MaskedTextBox_InvNo.Text;
                               // AssetHomeObj.Assetobj.Customfiled4 = dateTimePicker_InvDt.Value.Date.ToString();
                                AssetHomeObj.Assetobj.Customfiled4 = dateTimePicker_InvDt.Value.Date;
                                AssetHomeObj.Assetobj.Customfiled5 = sS_MaskedTextBox_QTNo.Text;
                                AssetHomeObj.Assetobj.Customfiled6 = sS_MaskedTextBox_MANo.Text;
                                AssetHomeObj.Assetobj.Customfiled7 = sS_MaskedTextBox_PRNo.Text;
                                AssetHomeObj.Assetobj.Customfiled8 = sS_MaskedTextBox_PONo.Text;
                                AssetHomeObj.Assetobj.Customfiled9 = sS_MaskedTextBox_SName.Text;
                               // AssetHomeObj.Assetobj.Customfiled10 = dateTimePicker_MAStartDate.Value.Date.ToString();
                                AssetHomeObj.Assetobj.Customfiled10 = dateTimePicker_MAStartDate.Value.Date;
                                AssetHomeObj.Assetobj.Customfiled11 = dateTimePicker_MAEndDate.Value.Date.ToString();

                                if (AssetHomeObj.Edit())
                                {
                                    SS_MyMessageBox.ShowBox("Edit data : " + sS_MaskedTextBox_AssetNo.Text + " Complete", "Edit Data Information", DialogMode.OkOnly, this.Name, "000003", Obj_AssetNo, Global.Lang.Str_Language);
                                    Global.Bool_CheckComplete = true;
                                    ///////////Edit on 19-02-09 //////////
                                    sS_DataGridView_Asset.Enabled = true;
                                    //////////////////////////
                                }
                                else
                                {
                                    SS_MyMessageBox.ShowBox("Can not edit data : " + sS_MaskedTextBox_AssetNo.Text + " !", "Warning", DialogMode.OkOnly, this.Name, "000004", Obj_AssetNo, Global.Lang.Str_Language);
                                    Global.Bool_CheckComplete = false;
                                }

                                Enm_StateForm = Enum_Mode.PreEdit;
                                Function_ExecuteTransaction(Enum_Mode.Cancel);
                               //Function_ShowDataInDatagrid();

                               // goto DEFAULT;
                            }
                            else
                                Global.Bool_CheckComplete = false;
                            break;
                        }
                    case Enum_Mode.Delete:
                        {
                            if (sS_DataGridView_Asset.SelectedRows.Count > 1)
                            {
                                List<Asset> AssetCollection = new List<Asset>();
                                Asset TempAsset = new Asset();

                                foreach (DataGridViewRow TempDataGridRow in sS_DataGridView_Asset.SelectedRows)
                                {   
                                    TempAsset = Manager.Engine.GetObject<Asset>(TempDataGridRow.Cells[0].Value.ToString());
                                    
                                    AssetCollection.Add(TempAsset);                                  
                                }
                                if (SS_MyMessageBox.ShowBox("Do you want to delete data"  + sS_DataGridView_Asset.SelectedRows.Count + "record ?", "Delete Data Information", DialogMode.OkCancel, this.Name, "000014",Obj_AssetRow, Global.Lang.Str_Language) == DialogResult.OK)
                                {
                                    Global.Bool_CheckComplete = true;
                                    Wilson.ORMapper.Transaction ORTransaction = Manager.Engine.BeginTransaction();

                                    if (AssetHomeObj.Delete(ORTransaction, AssetCollection))
                                    {
                                        ORTransaction.Commit();
                                        SS_MyMessageBox.ShowBox("Delete data complete", "Delete Data Information", DialogMode.OkOnly, this.Name, "000012", Global.Lang.Str_Language);
                                        Global.Bool_CheckComplete = true;

                                        Enm_StateForm = Enum_Mode.PreAdd;
                                        Function_ShowDataInDatagrid();
                                        ///////////Edit on 19-02-09 //////////
                                        sS_DataGridView_Asset.Enabled = true;
                                        //////////////////////////
                                    }
                                    else
                                    {
                                        SS_MyMessageBox.ShowBox("Can not delete data : " + sS_MaskedTextBox_AssetNo.Text + " !", "Warning", DialogMode.OkOnly, this.Name, "000013", Global.Lang.Str_Language);
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
                                if (sS_MaskedTextBox_AssetNo.Text != "")
                                {
                                    if (SS_MyMessageBox.ShowBox("Do you want to delete : " + sS_MaskedTextBox_AssetNo.Text + " ?", "Delete Data Information", DialogMode.OkCancel, this.Name, "000005", Obj_AssetNo, Global.Lang.Str_Language) == DialogResult.OK)
                                    {
                                        Global.Bool_CheckComplete = true;
                                        AssetHomeObj.Assetobj.ID = sS_MaskedTextBox_AssetNo.Text;
                                        if (AssetHomeObj.Delete())
                                        {
                                            SS_MyMessageBox.ShowBox("Delete data : " + sS_MaskedTextBox_AssetNo.Text + "complete", "Delete Data Information", DialogMode.OkOnly, this.Name, "000006", Obj_AssetNo, Global.Lang.Str_Language);
                                            Global.Bool_CheckComplete = true;

                                            Enm_StateForm = Enum_Mode.PreAdd;
                                            Function_ShowDataInDatagrid();
                                            ///////////Edit on 19-02-09 //////////
                                            sS_DataGridView_Asset.Enabled = true;
                                            //////////////////////////

                                        }
                                        else
                                        {
                                            SS_MyMessageBox.ShowBox("Can not delete data : " + sS_MaskedTextBox_AssetNo.Text + " !", "Warning", DialogMode.OkOnly, this.Name, "000007", Obj_AssetNo, Global.Lang.Str_Language);
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
                                    Global.Bool_CheckComplete = false;
                            }
                                break;
                        }
                    case Enum_Mode.ShowData://
                        {
                            Function_ShowDataInControlnew();
                            break;
                        }

                    case Enum_Mode.Cancel:
                        if (Enm_StateForm == Enum_Mode.PreEdit)
                        {
                            //Function_ExecuteTransaction(Enum_Mode.ShowData);
                            sS_MaskedTextBox_AssetNo.Focus();
                        }

                        if (Enm_StateForm == Enum_Mode.PreAdd)
                        {
                             Function_ClearData();
                             sS_MaskedTextBox_AssetNo.Focus();
                             Function_ShowDataInDatagrid();
                             ///////////Edit on 19-02-09 //////////
                             sS_DataGridView_Asset.Enabled = true;
                             //////////////////////////
                        }
                      
                    // sS_MaskedTextBox_AssetNo.ReadOnly = true;
                        // Edit on 07-01-09
                        sS_MaskedTextBox_AssetNo.ReadOnly = false;
                        /////
                        Function_SetReadOnlyControl(true);
                        Function_SetReadOnlyControlSearch(true);
                        Function_EnableControlDate(false);       
                        Enm_StateForm = Enum_Mode.Search;
                        break;

                    DEFAULT:
                        Function_ClearData();
                        sS_MaskedTextBox_AssetNo.ReadOnly = false;
                        sS_MaskedTextBox_AssetNo.Focus();
                        //Function_ShowDataInDatagridView();
                        clsquery.Searchdata(this, ref sS_DataGridView_Asset);
                        break;
                }
                Obj_AssetNo = null;
                Obj_AssetRow = null;
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
                sS_MaskedTextBox_AssetNo.Text = "";
                sS_MaskedTextBox_AssetName.Text = "";
                sS_MaskedTextBox_SName.Text = "";
                sS_MaskedTextBox_ModelID.Text = "";
                sS_MaskedTextBox_ModelName.Text = "";
                sS_MaskedTextBox_SerailNo.Text = "";
                sS_MaskedTextBox_TypeNo.Text = "";
                sS_MaskedTextBox_TypeName.Text = "";
                sS_MaskedTextBox_SupplierNo.Text = "";
                sS_MaskedTextBox_SupplierName.Text = "";
                sS_MaskedTextBox_DepartmentNo.Text = "";
                sS_MaskedTextBox_DepartmentName.Text = "";
                sS_MaskedTextBox_BuildingNo.Text = "";
                sS_MaskedTextBox_BuildingName.Text = "";
                sS_MaskedTextBox_FloorNo.Text = "";
                sS_MaskedTextBox_FloorName.Text = "";
                sS_MaskedTextBox_AreaNo.Text = "";
                sS_MaskedTextBox_AreaName.Text = "";
                sS_MaskedTextBox_Remark.Text = "";
                sS_MaskedTextBox_ReasonNo.Text = "";
                sS_MaskedTextBox_ReasonName.Text = "";
                sS_MaskedTextBox_CurrentCustodianNo.Text = "";
                sS_MaskedTextBox_CustodianName.Text = "";
                sS_MaskedTextBox_PurchasePrice.Text = "0.00";
                sS_MaskedTextBox_PreviousCustodianNo.Text = "";
                sS_MaskedTextBox_PreviousCustodianName.Text = "";
                sS_MaskedTextBox_StatusNo.Text = "";
                sS_MaskedTextBox_StatusName.Text = "";
                sS_MaskedTextBox_FacilityNo.Text = "";
                sS_MaskedTextBox_FacName.Text = "";
                sS_MaskedTextBox_Capex.Text = "";
                sS_MaskedTextBox_InvNo.Text = "";
                sS_MaskedTextBox_QTNo.Text = "";
                sS_MaskedTextBox_MANo.Text = "";
                sS_MaskedTextBox_PRNo.Text = "";
                sS_MaskedTextBox_PONo.Text = "";
                sS_MaskedTextBox_JDENo.Text = "";
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

                //sS_DataGridView_Asset.DataSource = Manager.Engine.GetObjectSet<Asset >("");
                // sS_DataGridView1.SortOrder = SortOrder.None;
                // this.sS_DataGridView1.SortedColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
                //Global.set_header(sS_DataGridView_Asset, Application.StartupPath + "\\Data\\Form\\HeaderCol\\test-H.xml");
                //sS_DataGridView_Asset.DataMember = "Table";
                //DataSet ds = new DataSet();
                //ds = (DataSet)Manager.Engine.GetDataSet <Asset>("");
                //sS_DataGridView_Asset.DataSource = ds;

            }
            catch (Exception Err)
            {
                SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
            }
        }
        public void Function_SetReadOnlyControl(bool Bool_StateControl)
        {
            sS_MaskedTextBox_AssetName.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_SName.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_SerailNo.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_Remark.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_PurchasePrice.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_UserName.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_Capex.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_InvNo.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_QTNo.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_MANo.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_PRNo.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_PONo.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_JDENo.ReadOnly = Bool_StateControl;
        }

        private void Function_SetReadOnlyControlSearch(bool Bool_StateControl)
        {
            sS_MaskedTextBox_ModelID.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_ModelName.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_TypeNo.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_TypeName.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_SupplierNo.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_SupplierName.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_DepartmentNo.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_DepartmentName.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_BuildingNo.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_BuildingName.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_FloorNo.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_FloorName.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_AreaNo.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_AreaName.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_FacilityNo.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_FacName.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_ReasonNo.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_ReasonName.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_CurrentCustodianNo.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_CustodianName.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_PreviousCustodianNo.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_PreviousCustodianName.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_StatusNo.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_StatusName.ReadOnly = Bool_StateControl;
        }
        private void Function_ShowDataInControl()
        {
            try
            {
                if (sS_DataGridView_Asset.Rows.Count > 0)
                {
                    sS_MaskedTextBox_AssetNo.Text = sS_DataGridView_Asset[14, sS_DataGridView_Asset.CurrentRow.Index].Value.ToString();
                    sS_MaskedTextBox_AssetName.Text = sS_DataGridView_Asset[19, sS_DataGridView_Asset.CurrentRow.Index].Value.ToString();
                    sS_MaskedTextBox_ModelID.Text = sS_DataGridView_Asset[6, sS_DataGridView_Asset.CurrentRow.Index].Value.ToString();
                    sS_MaskedTextBox_SerailNo.Text = sS_DataGridView_Asset[17, sS_DataGridView_Asset.CurrentRow.Index].Value.ToString();
                    sS_MaskedTextBox_TypeNo.Text = sS_DataGridView_Asset[13, sS_DataGridView_Asset.CurrentRow.Index].Value.ToString();
                    sS_MaskedTextBox_SupplierNo.Text = sS_DataGridView_Asset[9, sS_DataGridView_Asset.CurrentRow.Index].Value.ToString();
                    sS_MaskedTextBox_DepartmentNo.Text = sS_DataGridView_Asset[11, sS_DataGridView_Asset.CurrentRow.Index].Value.ToString();
                    sS_MaskedTextBox_BuildingNo.Text = sS_DataGridView_Asset[0, sS_DataGridView_Asset.CurrentRow.Index].Value.ToString();
                    sS_MaskedTextBox_FloorNo.Text = sS_DataGridView_Asset[7, sS_DataGridView_Asset.CurrentRow.Index].Value.ToString();
                    sS_MaskedTextBox_AreaNo.Text = sS_DataGridView_Asset[10, sS_DataGridView_Asset.CurrentRow.Index].Value.ToString();
                    sS_MaskedTextBox_Remark.Text = sS_DataGridView_Asset[2, sS_DataGridView_Asset.CurrentRow.Index].Value.ToString();
                    sS_MaskedTextBox_ReasonNo.Text = sS_DataGridView_Asset[21, sS_DataGridView_Asset.CurrentRow.Index].Value.ToString();
                    sS_MaskedTextBox_CurrentCustodianNo.Text = sS_DataGridView_Asset[18, sS_DataGridView_Asset.CurrentRow.Index].Value.ToString();
                    sS_MaskedTextBox_PreviousCustodianNo.Text = sS_DataGridView_Asset[1, sS_DataGridView_Asset.CurrentRow.Index].Value.ToString();
                    sS_MaskedTextBox_PurchasePrice.Text = sS_DataGridView_Asset[3, sS_DataGridView_Asset.CurrentRow.Index].Value.ToString();
                    sS_MaskedTextBox_StatusNo.Text = sS_DataGridView_Asset[16, sS_DataGridView_Asset.CurrentRow.Index].Value.ToString();
                    dateTimePicker_WarrantyStartDate.Text = sS_DataGridView_Asset[4, sS_DataGridView_Asset.CurrentRow.Index].Value.ToString();
                    dateTimePicker_WarrantyEndDate.Text= sS_DataGridView_Asset[15, sS_DataGridView_Asset.CurrentRow.Index].Value.ToString();
                    sS_MaskedTextBox_UserName.Text = sS_DataGridView_Asset[20, sS_DataGridView_Asset.CurrentRow.Index].Value.ToString();
                    dateTimePicker_DateAdded.Text = sS_DataGridView_Asset[8, sS_DataGridView_Asset.CurrentRow.Index].Value.ToString();
                    dateTimePicker_LastInventoryDate.Text = sS_DataGridView_Asset[12, sS_DataGridView_Asset.CurrentRow.Index].Value.ToString();
                    sS_MaskedTextBox_FacilityNo.Text = sS_DataGridView_Asset[5, sS_DataGridView_Asset.CurrentRow.Index].Value.ToString();


                    Asset assetobj = new Asset();
                    assetobj = Manager.Engine.GetObject<Asset>(sS_MaskedTextBox_AssetNo.Text);

                    if (assetobj != null)
                    {
                        sS_MaskedTextBox_JDENo.Text = assetobj.Customfiled1;
                        sS_MaskedTextBox_Capex.Text = assetobj.Customfiled2;
                        sS_MaskedTextBox_InvNo.Text = assetobj.Customfiled3;
                       // dateTimePicker_InvDt.Text = assetobj.Customfiled4;
                        dateTimePicker_InvDt.Text = Convert.ToString(assetobj.Customfiled4);
                        sS_MaskedTextBox_QTNo.Text = assetobj.Customfiled5;
                        sS_MaskedTextBox_MANo.Text = assetobj.Customfiled6;
                        sS_MaskedTextBox_PRNo.Text = assetobj.Customfiled7;
                        sS_MaskedTextBox_PONo.Text = assetobj.Customfiled8;
                        sS_MaskedTextBox_SName.Text = assetobj.Customfiled9;
                        //dateTimePicker_MAStartDate.Text = assetobj.Customfiled10;
                        dateTimePicker_MAStartDate.Text = Convert.ToString(assetobj.Customfiled10);
                        dateTimePicker_MAEndDate.Text = assetobj.Customfiled11;
                    }

                    sS_MaskedTextBox_AssetNo.Focus();

                    Str_PreviousCustodian = sS_MaskedTextBox_CurrentCustodianNo.Text;
                }
                sS_MaskedTextBox_UserName.ReadOnly = true;
            }
            catch (Exception Err)
            {
                SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
            }
        }
        private string Function_SetPreviousCustodian()
        {
            String Str_Previous = "";
            if (Str_PreviousCustodian != sS_MaskedTextBox_CurrentCustodianNo.Text)
            {
                Str_Previous = Str_PreviousCustodian;
            }
            return Str_Previous;
        }
      
        private void Form_002001_Asset_FormClosed(object sender, FormClosedEventArgs e)
        {
            Global.Function_RemoveTabStripButton(this.Tag);
        }

        private void panel_Asset_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Function_ShowDataInDatagrid()
        {
            try
            {
                DataSet Ds = new DataSet();
                Ds = Manager.Engine.GetDataSet<Asset>("");
                sS_DataGridView_Asset.DataSource = Ds;
                sS_DataGridView_Asset.DataMember = "Table";
                Ds.Dispose();
                Ds = null;
            }
            catch (Exception Err)
            {
                SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
            }
        }

        private string Function_CheckNullInDatagrid(string Obj_ID)
        {
            string Temp = string.Empty;
            if (Obj_ID == "null")
                Temp = string.Empty;

            return Temp;
        }
        private string Function_CheckNullInDatagrid1(string Obj_ID)
        {
            if (Obj_ID != "-")
                return Obj_ID;
            else
             return Obj_ID = string.Empty;        
        }
        private bool Function_ShowDataSerchKey()
        {
            bool result = false;
            try
            {
                if (sS_DataGridView_Asset.Rows.Count > 0)
                {
                    //sS_MaskedTextBox_AssetNo.ReadOnly = true;
                    sS_MaskedTextBox_UserName.Enabled = false;
                    sS_MaskedTextBox_AreaNo.Focus();
                    //sS_MaskedTextBox_AssetNo.Text = Textserch;

                    Asset assetobj = new Asset();
                    assetobj = Manager.Engine.GetObject<Asset>(sS_MaskedTextBox_AssetNo.Text);

                    if (assetobj != null)
                    {
                        sS_MaskedTextBox_AssetName.Text = Global.FormOrder.Function_GetAssetName(assetobj.ID);
                        sS_MaskedTextBox_ModelID.Text = Function_CheckNullInDatagrid1(assetobj.ModelID);
                        sS_MaskedTextBox_ModelName.Text = Global.FormOrder.Function_GetModelName(assetobj.ModelID);
                        sS_MaskedTextBox_SerailNo.Text = assetobj.SerialNo;
                        sS_MaskedTextBox_TypeNo.Text = assetobj.TypeID;
                        sS_MaskedTextBox_TypeName.Text = Global.FormOrder.Function_GetTypeName(assetobj.TypeID);
                        sS_MaskedTextBox_SupplierNo.Text = Function_CheckNullInDatagrid1(assetobj.VendorID);
                        sS_MaskedTextBox_SupplierName.Text = Global.FormOrder.Function_GetSupplierName(assetobj.VendorID);
                        sS_MaskedTextBox_DepartmentNo.Text = Function_CheckNullInDatagrid1(assetobj.DeptID);
                        sS_MaskedTextBox_DepartmentName.Text = Global.FormOrder.Function_GetDeptName(assetobj.DeptID);
                        sS_MaskedTextBox_BuildingNo.Text = assetobj.BuildID;
                        sS_MaskedTextBox_BuildingName.Text = Global.FormOrder.Function_GetBuildingName(assetobj.BuildID);
                        sS_MaskedTextBox_FloorNo.Text = assetobj.FloorID;
                        sS_MaskedTextBox_FloorName.Text = Global.FormOrder.Function_GetFloorName(assetobj.FloorID);
                        sS_MaskedTextBox_AreaNo.Text = assetobj.AreaID;
                        sS_MaskedTextBox_AreaName.Text = Global.FormOrder.Function_GetAreaName(assetobj.AreaID);
                        sS_MaskedTextBox_Remark.Text = assetobj.Remark;
                        sS_MaskedTextBox_ReasonNo.Text = assetobj.ReasonCode;
                        sS_MaskedTextBox_ReasonName.Text = Global.FormOrder.Function_GetReasonName(assetobj.ReasonCode);
                        sS_MaskedTextBox_CurrentCustodianNo.Text = Function_CheckNullInDatagrid1(assetobj.CustodianID);
                        sS_MaskedTextBox_CustodianName.Text = Global.FormOrder.Function_GetCustodianName(assetobj.CustodianID);
                        sS_MaskedTextBox_PreviousCustodianNo.Text = assetobj.PreviosCustodian;
                        sS_MaskedTextBox_PreviousCustodianName.Text = Global.FormOrder.Function_GetCustodianName(assetobj.PreviosCustodian);
                        sS_MaskedTextBox_PurchasePrice.Text = string.Format("{0:#,0.00}", Convert.ToDouble(assetobj.Price)); 
                        sS_MaskedTextBox_StatusNo.Text = assetobj.StatusID;
                        sS_MaskedTextBox_StatusName.Text = Global.FormOrder.Function_GetStatusName(assetobj.StatusID);
                        //dateTimePicker_WarrantyStartDate.Text = Convert.ToString(assetobj.WarrantyStartDate);
                        dateTimePicker_WarrantyStartDate.Value = assetobj.WarrantyStartDate;
                        dateTimePicker_WarrantyEndDate.Text = Convert.ToString(assetobj.WarrantyEndDate);
                        dateTimePicker_DateAdded.Text = Convert.ToString(assetobj.CreatedDate);
                        dateTimePicker_LastInventoryDate.Text = Convert.ToString(assetobj.UpdateDate);
                        sS_MaskedTextBox_FacilityNo.Text = assetobj.FacCode;
                        sS_MaskedTextBox_FacName.Text = Global.FormOrder.Function_GetFacName(assetobj.FacCode);
                        sS_MaskedTextBox_JDENo.Text = assetobj.Customfiled1; 
                        sS_MaskedTextBox_Capex.Text = assetobj.Customfiled2;
                        sS_MaskedTextBox_InvNo.Text = assetobj.Customfiled3;
                       // dateTimePicker_InvDt.Text = assetobj.Customfiled4;
                       dateTimePicker_InvDt.Text = Convert.ToString(assetobj.Customfiled4);
                        
                        sS_MaskedTextBox_QTNo.Text = assetobj.Customfiled5;
                        sS_MaskedTextBox_MANo.Text = assetobj.Customfiled6;
                        sS_MaskedTextBox_PRNo.Text = assetobj.Customfiled7;
                        sS_MaskedTextBox_PONo.Text = assetobj.Customfiled8;
                        sS_MaskedTextBox_SName.Text = assetobj.Customfiled9;
                        //dateTimePicker_MAStartDate.Text = assetobj.Customfiled10;
                        dateTimePicker_MAStartDate.Text = Convert.ToString(assetobj.Customfiled10);
                        dateTimePicker_MAEndDate.Text = assetobj.Customfiled11;
                        sS_MaskedTextBox_AssetNo.Focus();

                        Str_PreviousCustodian = sS_MaskedTextBox_CurrentCustodianNo.Text;

                        result = true;
                    }

                }
                sS_MaskedTextBox_AssetNo.Focus();
            }
            catch (Exception Err)
            {
                SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
            }
            return result;
        }

        private void Function_ShowDataInControlnew()
        {
            try
            {             
                if (sS_DataGridView_Asset.Rows.Count > 0)
                {
                    //sS_MaskedTextBox_AssetNo.ReadOnly = true;
                    sS_MaskedTextBox_UserName.Enabled = false ;
                    sS_MaskedTextBox_AreaNo.Focus();
                    sS_MaskedTextBox_AssetNo.Text = sS_DataGridView_Asset[0, sS_DataGridView_Asset.CurrentRow.Index].Value.ToString();
                   
                    Asset assetobj = new Asset();
                    assetobj = Manager.Engine.GetObject<Asset>(sS_MaskedTextBox_AssetNo.Text);
               
                    if (assetobj != null)
                    {
                        sS_MaskedTextBox_AssetName.Text = Global.FormOrder.Function_GetAssetName(assetobj.ID);
                        sS_MaskedTextBox_ModelID.Text = Function_CheckNullInDatagrid1(assetobj.ModelID);
                        sS_MaskedTextBox_ModelName.Text = Global.FormOrder.Function_GetModelName(assetobj.ModelID);
                        sS_MaskedTextBox_SerailNo.Text = assetobj.SerialNo;
                        sS_MaskedTextBox_TypeNo.Text = assetobj.TypeID;
                        sS_MaskedTextBox_TypeName.Text = Global.FormOrder.Function_GetTypeName(assetobj.TypeID);
                        sS_MaskedTextBox_SupplierNo.Text = Function_CheckNullInDatagrid1(assetobj.VendorID);
                        sS_MaskedTextBox_SupplierName.Text = Global.FormOrder.Function_GetSupplierName(assetobj.VendorID);
                        sS_MaskedTextBox_DepartmentNo.Text =Function_CheckNullInDatagrid1(assetobj.DeptID);
                        sS_MaskedTextBox_DepartmentName.Text = Global.FormOrder.Function_GetDeptName(assetobj.DeptID);
                        sS_MaskedTextBox_BuildingNo.Text = assetobj.BuildID;
                        sS_MaskedTextBox_BuildingName.Text = Global.FormOrder.Function_GetBuildingName(assetobj.BuildID);
                        sS_MaskedTextBox_FloorNo.Text = assetobj.FloorID;
                        sS_MaskedTextBox_FloorName.Text = Global.FormOrder.Function_GetFloorName(assetobj.FloorID);
                        sS_MaskedTextBox_AreaNo.Text = assetobj.AreaID;
                        sS_MaskedTextBox_AreaName.Text = Global.FormOrder.Function_GetAreaName(assetobj.AreaID);
                        sS_MaskedTextBox_Remark.Text = assetobj.Remark;
                        sS_MaskedTextBox_ReasonNo.Text = assetobj.ReasonCode;
                        sS_MaskedTextBox_ReasonName.Text = Global.FormOrder.Function_GetReasonName(assetobj.ReasonCode);
                        sS_MaskedTextBox_CurrentCustodianNo.Text = Function_CheckNullInDatagrid1(assetobj.CustodianID);
                        sS_MaskedTextBox_CustodianName.Text = Global.FormOrder.Function_GetCustodianName(assetobj.CustodianID);
                        sS_MaskedTextBox_PreviousCustodianNo.Text = assetobj.PreviosCustodian;
                        sS_MaskedTextBox_PreviousCustodianName.Text =Global.FormOrder.Function_GetCustodianName(assetobj.PreviosCustodian);
                        sS_MaskedTextBox_PurchasePrice.Text = string.Format("{0:#,0.00}",Convert.ToDouble(assetobj.Price));
                        sS_MaskedTextBox_StatusNo.Text = assetobj.StatusID;
                        sS_MaskedTextBox_StatusName.Text =Global.FormOrder.Function_GetStatusName(assetobj.StatusID);
                        //dateTimePicker_WarrantyStartDate.Text = Convert.ToString(assetobj.WarrantyStartDate);
                        dateTimePicker_WarrantyStartDate.Value  = assetobj.WarrantyStartDate;
                        dateTimePicker_WarrantyEndDate.Text = Convert.ToString(assetobj.WarrantyEndDate);
                        dateTimePicker_DateAdded.Text = Convert.ToString(assetobj.CreatedDate);
                        dateTimePicker_LastInventoryDate.Text = Convert.ToString(assetobj.UpdateDate);
                        sS_MaskedTextBox_FacilityNo.Text = assetobj.FacCode;
                        sS_MaskedTextBox_FacName.Text =Global.FormOrder.Function_GetFacName(assetobj.FacCode);

                        sS_MaskedTextBox_JDENo.Text = assetobj.Customfiled1;
                        sS_MaskedTextBox_Capex.Text = assetobj.Customfiled2;
                        sS_MaskedTextBox_InvNo.Text = assetobj.Customfiled3; 
                       // dateTimePicker_InvDt.Text = assetobj.Customfiled4; 
                        dateTimePicker_InvDt.Text = Convert.ToString(assetobj.Customfiled4);
                        //dateTimePicker_InvDt.Value = assetobj.Customfiled4;
                        
                        sS_MaskedTextBox_QTNo.Text = assetobj.Customfiled5; 
                        sS_MaskedTextBox_MANo.Text = assetobj.Customfiled6;
                        sS_MaskedTextBox_PRNo.Text = assetobj.Customfiled7;
                        sS_MaskedTextBox_PONo.Text = assetobj.Customfiled8;
                        sS_MaskedTextBox_SName.Text = assetobj.Customfiled9;
                        //dateTimePicker_MAStartDate.Text = assetobj.Customfiled10;
                        dateTimePicker_MAStartDate.Text = Convert.ToString(assetobj.Customfiled10);
                        dateTimePicker_MAEndDate.Text = assetobj.Customfiled11;
                        
                        sS_MaskedTextBox_AssetNo.Focus();
                        Str_PreviousCustodian = sS_MaskedTextBox_CurrentCustodianNo.Text;
                    }

                }
                sS_MaskedTextBox_AssetNo.Focus();
            }
            catch (Exception Err)
            {
                SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void sS_MaskedTextBox_ModelID_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.F1)&&((Enm_StateForm ==Enum_Mode.PreAdd)||(Enm_StateForm ==Enum_Mode.PreEdit)))
            {
                SimatSoft.QueryManager.Form_Present Frm_Present = new SimatSoft.QueryManager.Form_Present();
                Frm_Present.Controlreturnvalue = sS_MaskedTextBox_ModelID;
                Frm_Present.Controlreturnvalue2 = sS_MaskedTextBox_ModelName;
                Frm_Present.Show_Data("Screen", "002002");

                Frm_Present.ShowDialog();
                Frm_Present.Dispose();
            }
        }

        private void sS_MaskedTextBox_TypeNo_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.F1) && ((Enm_StateForm == Enum_Mode.PreAdd) || (Enm_StateForm == Enum_Mode.PreEdit)))
            {
                SimatSoft.QueryManager.Form_Present Frm_Present = new SimatSoft.QueryManager.Form_Present();
                Frm_Present.Controlreturnvalue = sS_MaskedTextBox_TypeNo;
                Frm_Present.Controlreturnvalue2 = sS_MaskedTextBox_TypeName;
                string qry = "typeGroup = 'ASSET' ";
                Frm_Present.Show_Data("Screen", "002004",qry);

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

        private void sS_MaskedTextBox_BuildingNo_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.F1) && ((Enm_StateForm == Enum_Mode.PreAdd) || (Enm_StateForm == Enum_Mode.PreEdit)))
            {
                SimatSoft.QueryManager.Form_Present Frm_Present = new SimatSoft.QueryManager.Form_Present();
                Frm_Present.Controlreturnvalue = sS_MaskedTextBox_BuildingNo;
                Frm_Present.Controlreturnvalue2 = sS_MaskedTextBox_BuildingName;
                Frm_Present.Show_Data("Screen", "002008");

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

                string qry = "buildid = '" + sS_MaskedTextBox_BuildingNo.Text + "'";
                Frm_Present.Show_Data("Screen", "002009",qry);

                Frm_Present.ShowDialog();
                Frm_Present.Dispose();
            }
        }

        private void sS_MaskedTextBox_AreaNo_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.F1) && ((Enm_StateForm == Enum_Mode.PreAdd) || (Enm_StateForm == Enum_Mode.PreEdit)))
            {
                SimatSoft.QueryManager.Form_Present Frm_Present = new SimatSoft.QueryManager.Form_Present();
                Frm_Present.Controlreturnvalue = sS_MaskedTextBox_AreaNo;
                Frm_Present.Controlreturnvalue2 = sS_MaskedTextBox_AreaName;

                string qry = "buildid = '" + sS_MaskedTextBox_BuildingNo.Text + "' and floorid = '"
                            + sS_MaskedTextBox_FloorNo.Text + "'";
                Frm_Present.Show_Data("Screen", "002007", qry);

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

        private void sS_MaskedTextBox_CurrentCustodianNo_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.F1) && ((Enm_StateForm == Enum_Mode.PreAdd) || (Enm_StateForm == Enum_Mode.PreEdit)))
            {
                SimatSoft.QueryManager.Form_Present Frm_Present = new SimatSoft.QueryManager.Form_Present();
                Frm_Present.Controlreturnvalue = sS_MaskedTextBox_CurrentCustodianNo;
                Frm_Present.Controlreturnvalue2 = sS_MaskedTextBox_CustodianName;
                Frm_Present.Show_Data("Screen", "002011");

                Frm_Present.ShowDialog();
                Frm_Present.Dispose();
            }
        }

        private void sS_MaskedTextBox_PreviousCustodianNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                SimatSoft.QueryManager.Form_Present Frm_Present = new SimatSoft.QueryManager.Form_Present();
                Frm_Present.Controlreturnvalue = sS_MaskedTextBox_PreviousCustodianNo;
                Frm_Present.Controlreturnvalue2 = sS_MaskedTextBox_PreviousCustodianName;
                Frm_Present.Show_Data("Screen", "002011");

                Frm_Present.ShowDialog();
                Frm_Present.Dispose();
            }
        }

        private void sS_MaskedTextBox_StatusNo_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.F1) && ((Enm_StateForm == Enum_Mode.PreAdd) || (Enm_StateForm == Enum_Mode.PreEdit)))
            {
                SimatSoft.QueryManager.Form_Present Frm_Present = new SimatSoft.QueryManager.Form_Present();
                Frm_Present.Controlreturnvalue = sS_MaskedTextBox_StatusNo;
                Frm_Present.Controlreturnvalue2 = sS_MaskedTextBox_StatusName;
                Frm_Present.Show_Data("Screen", "002013");

                Frm_Present.ShowDialog();
                Frm_Present.Dispose();
            }
        }

        private void sS_MaskedTextBox_ReasonNo_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.F1) && ((Enm_StateForm == Enum_Mode.PreAdd) || (Enm_StateForm == Enum_Mode.PreEdit)))
            {
                SimatSoft.QueryManager.Form_Present Frm_Present = new SimatSoft.QueryManager.Form_Present();
                Frm_Present.Controlreturnvalue = sS_MaskedTextBox_ReasonNo;
                Frm_Present.Controlreturnvalue2 = sS_MaskedTextBox_ReasonName;
                Frm_Present.Show_Data("Screen", "002012");

                Frm_Present.ShowDialog();
                Frm_Present.Dispose();
            }
        }

        private void Form_002001_Asset_Activated(object sender, EventArgs e)
        {
            AuthorizeState.Funtion_SetButtonAuthorize(Enm_StateForm);
        }

        private string Function_GetPrice(string Str_TempModelID)
        {
           string TempStr_Price = "0.00";
            Model TempModelObj = new Model();
            TempModelObj = Manager.Engine.GetObject<Model>(Str_TempModelID);
            if (TempModelObj != null)
                TempStr_Price = string.Format("{0.00}",TempModelObj.Value.ToString());
            else
                TempStr_Price = "0.00";
            TempModelObj = null;
            return TempStr_Price;
        }

        private void dateTimePicker_WarrantyEndDate_CloseUp(object sender, EventArgs e)
        {
            if (this.dateTimePicker_WarrantyEndDate.Value < dateTimePicker_WarrantyStartDate.Value)
            {
                SS_MyMessageBox.ShowBox("Please choose WarrantyEndDate again!", "Warnning", DialogMode.OkOnly,this.Name,"000009",Global.Lang.Str_Language);
                dateTimePicker_WarrantyEndDate.Value = dateTimePicker_WarrantyStartDate.Value;
               
            }          
        }

        private void sS_DataGridView_Asset_Click(object sender, EventArgs e)
        {
            Function_ShowDataInControlnew();
            Enm_StateForm = Enum_Mode.CellClick;
            AuthorizeState.Funtion_SetButtonAuthorize(Enm_StateForm);
            DataGridViewSelectedRowCollection xx = sS_DataGridView_Asset.SelectedRows;
            Function_ExecuteTransaction(Enum_Mode.Cancel);
        }

        private void sS_ButtonGlass_Picture_Click(object sender, EventArgs e)
        {
            Function_PicturePreview();
        }

        public void Function_PicturePreview()
        {
            //string Str_SQL ="AssetID =' " + sS_MaskedTextBox_AssetNo.Text + "' AND ModelID = '" + sS_MaskedTextBox_ModelID.Text + "'";
            //OPathQuery<AssetPic> OpathAssetPic = new OPathQuery<AssetPic>(Str_SQL);

            AssetPic AssetPicObj = new AssetPic();
            AssetPicObj = ManagerPic.Engine.GetObject<AssetPic>(sS_MaskedTextBox_AssetNo.Text);

            if (AssetPicObj != null)
            {
                Form_002001_AssetPicturePreview Frm_AssetPicturePreview = new Form_002001_AssetPicturePreview();
                Frm_AssetPicturePreview.Tag = AssetPicObj.Picture;
                Frm_AssetPicturePreview.ShowDialog();
            }
            else
            {
                SS_MyMessageBox.ShowBox("ID " + sS_MaskedTextBox_AssetNo.Text + " : no have picture", "Information", DialogMode.OkOnly);
            }
        }

        #region Old code by Aot
       /* private void sS_ButtonGlass1_Click(object sender, EventArgs e)
        {
            if (sS_MaskedTextBox_AssetNo.Text != "")
            {
                string AssetNo, AssetName, Depart, Date;
                AssetNo = sS_MaskedTextBox_AssetNo.Text;
                AssetName = sS_MaskedTextBox_SName.Text; 
               // AssetName = sS_MaskedTextBox_AssetName.Text;
                //Depart = sS_MaskedTextBox_DepartmentNo.Text;
                Depart = sS_MaskedTextBox_DepartmentName.Text;
                //Date = Convert.ToString(dateTimePicker_DateAdded.Value).Replace("0:00:00","");
               // Date = dateTimePicker_DateAdded.Value.ToShortDateString();
                
                Date = dateTimePicker_InvDt.Value.ToShortDateString();
               
                // Form_005009_Barcode frm_new = new Form_005009_Barcode();
               // frm_new.Show();
               // frm_new.GetAsseforPrint(AssetNo, AssetName, Depart, Date);
                Prints cmdPrint = new Prints();
                bool Printresult = cmdPrint.PrintInform(AssetNo, Depart, Date, AssetNo, AssetName);
                if (Printresult == true)
                {
                    SS_MyMessageBox.ShowBox("Printing Asset Barcode : " + AssetNo + " Complete. ", "Print Data Information", DialogMode.OkOnly);

                }
                else
                {
                    SS_MyMessageBox.ShowBox("Printing Asset Barcode : " + AssetNo + " incomplet !! ", "Print Data Information", DialogMode.OkOnly);
                }  
            }
        }*/
        #endregion

        private void sS_ButtonGlass1_Click(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.PrintDialog printDialog = new System.Windows.Forms.PrintDialog();
                printDialog.UseEXDialog = true;


                if (printDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    PrintDocument pd = new PrintDocument();
                    pd.PrinterSettings = printDialog.PrinterSettings;

                    //pd.PrinterSettings.PrinterName = printDialog.PrinterSettings.PrinterName;//90 mm//354
                    pd.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Custom", 204, 102); //5cm/1.97 inch -> 3.5cm/1.36 inch
                    pd.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                    pd.PrinterSettings.DefaultPageSettings.Margins = new Margins(9, 9, 9, 9);
                    //pd.DefaultPageSettings.Margins.Left = 0;
                    //pd.DefaultPageSettings.Margins.Top = 0;//= new Margins(0,0,0,0);
                    pd.DefaultPageSettings.Landscape = false;
                    pd.DocumentName = "RTE";
                    pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);

                    printDialog.Document = pd;

                    if (sS_MaskedTextBox_AssetNo.Text != "")
                    {

                        AssetNo = sS_MaskedTextBox_AssetNo.Text;
                        AssetName = sS_MaskedTextBox_SName.Text;
                        Depart = sS_MaskedTextBox_DepartmentName.Text;
                        Date = dateTimePicker_InvDt.Value.ToShortDateString();

                        pd.Print();
                        SS_MyMessageBox.ShowBox("Printing Asset Barcode : " + AssetNo + " Complete. ", "Print Data Information", DialogMode.OkOnly);
                        
                    }
                    else {
                        SS_MyMessageBox.ShowBox("Printing Asset Barcode : " + AssetNo + " incomplet !! ", "Print Data Information", DialogMode.OkOnly);
                    }
                }
            }
            catch (Exception Err)
            {
                SS_MyMessageBox.ShowBox("Printing Asset Barcode : " + AssetNo + " incomplet !! ", "Print Data Information", DialogMode.OkOnly);
            }
        }

        private void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                /*string AssetNo;
                string AssetName;
                string BU;
                string Date;
                string Dept;*/
                //string AssetNo, AssetName, BU, Date, Dept;
                int std = 0;//5;
                Single leftMargin = e.MarginBounds.Left;
                Single topMargin = e.MarginBounds.Top;
                //int wd = e.PageBounds.Width;

                Font printFont1 = new Font("Tahoma", 9, System.Drawing.FontStyle.Regular);
                Font printFont2 = new Font("Tahoma", 9, System.Drawing.FontStyle.Bold);
                Font printFont3 = new Font("Tahoma", 11, System.Drawing.FontStyle.Bold);
                Font printFont4 = new Font("Tahoma", 7, System.Drawing.FontStyle.Regular);

                SolidBrush br = new SolidBrush(System.Drawing.Color.Black);
                BarcodeLib.Barcode b = new BarcodeLib.Barcode();
                b.LabelPosition = BarcodeLib.LabelPositions.TOPRIGHT;
                //
                System.Drawing.Image bar = b.Encode(BarcodeLib.TYPE.CODE128, AssetNo, 180, 25);

                e.Graphics.DrawString(Date, printFont4, br, 135, std + 5);
                e.Graphics.DrawString(AssetName, printFont4, br, 25, std + 30);
                e.Graphics.DrawString(Depart, printFont4, br, 25, std + 43);
                //e.Graphics.DrawString(Dept, printFont4, br, 75 + BU.Length* 3 , std + 43 );

                e.Graphics.DrawString(AssetNo, printFont2, br, 40 + AssetNo.Length * 3, std + 50);
                e.Graphics.DrawImage(bar, 1, std + 65);//270);




            }
            catch (Exception Err)
            {

                throw new Exception("pd_PrintPage(): " + Err.Message);
            }
        }

        private void Form_002001_Asset_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Global.Location.Int_CountForm > 0)
            {
                Global.Location.Int_CountForm = Global.Location.Int_CountForm - 1;
            }
            Enm_StateForm = Enum_Mode.SetDefault;
            AuthorizeState.Funtion_SetButtonAuthorize(Enm_StateForm);
        }

        private void sS_MaskedTextBox_AssetNo_Enter(object sender, EventArgs e)
        {
          
        }

        private void sS_MaskedTextBox_AssetNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (Function_ShowDataSerchKey())
            {
                
                Enm_StateForm = Enum_Mode.CellClick;
                AuthorizeState.Funtion_SetButtonAuthorize(Enm_StateForm);

                // Edit on 07-01-09 (Additional)
                Enm_StateForm = Enum_Mode.PreAdd;
                Global.ConfigForm.Enum_FlagTransaction = Enum_Mode.PreAdd;
            }
        }

        private void sS_MaskedTextBox_AssetNo_Leave(object sender, EventArgs e)
        {
          //  Function_ShowDataSerchKey();
        }

        private void sS_MaskedTextBox_SName_Enter(object sender, EventArgs e)
        {
            
        }

        private void sS_MaskedTextBox_AssetName_Leave(object sender, EventArgs e)
        {
            if (Enm_StateForm == Enum_Mode.PreAdd || Enm_StateForm == Enum_Mode.PreEdit ||
                Enm_StateForm == Enum_Mode.Add || Enm_StateForm == Enum_Mode.Edit)
            {
                if (sS_MaskedTextBox_SName.Text == "" && sS_MaskedTextBox_AssetName.Text.Length > 17)
                {
                    sS_MaskedTextBox_SName.Text = sS_MaskedTextBox_AssetName.Text.Substring(0, 17);
                }
                else
                {
                    sS_MaskedTextBox_SName.Text = sS_MaskedTextBox_AssetName.Text;
                }
            }
        }

        private string Function_GetNextRunningNo()
        {
            string nextNo = "";
            try
            {
                string qry = "SELECT Prefix, CurrentRun FROM SysRunNo WHERE RunID = 1"; // Asset
                //string qry = "SELECT Prefix, CurrentRun FROM SysRunNo WHERE (RunID IN ";
                //qry += "(SELECT RunID FROM SysRunNoAssetMapping WHERE (FacCode = '" + Global.ConfigDatabase.Str_Company + "')))";

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
                             "' WHERE RunId = 1"; // Asset

                Manager.Engine.ExecuteCommand(qry);
            }
            catch { }

        }

        private void dateTimePicker_MAEndDate_CloseUp(object sender, EventArgs e)
        {
            if (this.dateTimePicker_MAEndDate.Value < dateTimePicker_MAStartDate.Value)
            {
                SS_MyMessageBox.ShowBox("Please choose MA End Date again!", "Warnning", DialogMode.OkOnly, this.Name, "000009", Global.Lang.Str_Language);
                dateTimePicker_WarrantyEndDate.Value = dateTimePicker_WarrantyStartDate.Value;

            }
        }


        //private void sS_MaskedTextBox_AssetNo_KeyDown(object sender, KeyEventArgs e)
        //{
        //    //if ((e.KeyCode ==Keys.F1)&&(Enm_StateForm == Enum_Mode.PreAdd))
        //    if (e.KeyCode == Keys.F1)
        //    {

        //        //SimatSoft.QueryManager.Form_Present Frm_Present = new SimatSoft.QueryManager.Form_Present();
        //        //Frm_Present.Controlreturnvalue = this.sS_MaskedTextBox_AssetNo;
        //        //Frm_Present.Controlreturnvalue2 = sS_MaskedTextBox_AssetName;

        //        //Frm_Present.Show_Data("Screen", "002001");

        //        //Frm_Present.ShowDialog();
        //        //Frm_Present.Dispose();

        //    }
        //    //else
        //    //{
        //    //    SimatSoft.QueryManager.Form_Present Frm_Present = new SimatSoft.QueryManager.Form_Present();
        //    //    Frm_Present.Controlreturnvalue = sS_MaskedTextBox_AssetID;
        //    //    Frm_Present.Controlreturnvalue2 = sS_MaskedTextBox_AssetName;
        //    //    Frm_Present.Show_Data("Screen", "005001_02");

        //    //    Frm_Present.ShowDialog();
        //    //    Frm_Present.Dispose();
        //    //}
        //}
       //private void panel_Asset_DoubleClick(object sender, EventArgs e)
        //{
        //    clsquery.Searchdata(this, ref dataGridView1);
        //}
    }
}


      

       