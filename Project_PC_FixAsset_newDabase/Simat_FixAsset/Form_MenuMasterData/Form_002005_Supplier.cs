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
    public partial class Form_002005_Supplier : SS_PaintGradientForm
    {
        private Enum_Mode Enm_StateForm = Enum_Mode.Search;
        Class_AuthorizeState AuthorizeState = new Class_AuthorizeState();
        private string currentNo = "";
        public Form_002005_Supplier()
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
            this.Text = Global.Function_Language(this, this, "ID:002005(Supplier)");
            LBL_SupplierNo.Text = Global.Function_Language(this, LBL_SupplierNo, "Supplier No:");
            LBL_SupplierFirstName.Text = Global.Function_Language(this, LBL_SupplierFirstName, "Supplier FirstName:");
            LBL_SupplierLastName.Text = Global.Function_Language(this, LBL_SupplierLastName, "Supplier LastName:");
            LBL_SupplierTypes.Text = Global.Function_Language(this, LBL_SupplierTypes, "SupplierFlag:");
            LBL_Address1.Text = Global.Function_Language(this, LBL_Address1, "Address1:");
            LBL_Address2.Text = Global.Function_Language(this, LBL_Address2, "Address2:");
            LBL_City.Text = Global.Function_Language(this, LBL_City, "City:");
            LBL_State.Text = Global.Function_Language(this, LBL_State, "State:");
            LBL_Zip.Text = Global.Function_Language(this, LBL_Zip, "Zip");
            LBL_Phone.Text = Global.Function_Language(this, LBL_Phone, "Phone:");
            LBL_Fax.Text = Global.Function_Language(this, LBL_Fax, "Fax:");
            LBL_Email.Text = Global.Function_Language(this, LBL_Email, "Email:");
            LBL_Contact.Text = Global.Function_Language(this, LBL_Contact, "Contact:");
            LBL_Remark.Text = Global.Function_Language(this, LBL_Remark, "Remark:");
            
            
        }
        private void Form_002005_Supplier_Load(object sender, EventArgs e)
        {
            Global.Location.Int_CountForm = Global.Location.Int_CountForm + 0;
            Function_ShowDataInDatagridView();
            Function_ClearData();
            sS_MaskedTextBox_SupplierNo.ReadOnly = false;
            Function_SetReadOnlyControl(true);
        }
        
        public void Function_ExecuteTransaction(Enum_Mode mode)
        {
            try
            {
                VendorHome VendorHomeObj = new VendorHome();
                ValidateuserinputData ValidateInput = new ValidateuserinputData(Global.ConfigPath.Str_AppPathValidate + "\\" + this.Name + ".xml", this);
                object[] Obj_SupplierNo = new object[1] { sS_MaskedTextBox_SupplierNo.Text };
                object[] Obj_SupplierRow = new object[1] { sS_DataGridView_Supplier.SelectedRows.Count };
                switch (mode)
                {
                    case Enum_Mode.PreSearch:
                        {
                            //Function_ClearData();
                            //sS_MaskedTextBox_SupplierNo.ReadOnly = false;
                            //Function_SetReadOnlyControl(false);
                            //sS_MaskedTextBox_SupplierNo.Focus();
                            //Enm_StateForm = Enum_Mode.PreSearch;
                            break;
                        }
                    case Enum_Mode.Search:
                        {
                            //if (sS_DataGridView_Supplier.Rows.Count > 0)
                            //{
                            //    string str_val = sS_MaskedTextBox_SupplierFirstName.Text.ToString().Trim();
                            //    // Ds_Supplier = Manager.Engine.GetDataSet<Vendor>(sS_MaskedTextBox_SupplierFirstName.Text);  
                            //    string SQL = "SELECT * FROM Vendor WHERE vendorFirstName LIKE '%" + str_val + "%' ";
                               
                            //    //sS_MaskedTextBox_SupplierNo.ReadOnly = true;
                            //    //sS_MaskedTextBox_SupplierNo.Text = sS_DataGridView_Supplier[0, sS_DataGridView_Supplier.CurrentRow.Index].Value.ToString();
                            //    //Vendor VendorObj = new Vendor();
                            //    //VendorObj = Manager.Engine.GetObject<Vendor>(str_txt);
                            //   DataSet Ds_Supplier = Manager.Engine.GetDataSet(SQL);

                            //   if (Ds_Supplier.Tables[0].Rows.Count > 0)
                            //    {
                                   
                            //        sS_DataGridView_Supplier.DataSource = Ds_Supplier;
                            //        sS_DataGridView_Supplier.DataMember = "Table";
                            //        Function_SetVendorFlagInDataGrid();
                            //        Ds_Supplier.Dispose();
                            //        Ds_Supplier = null;

                            //        Enm_StateForm = Enum_Mode.PreEdit;
                            //        Function_ExecuteTransaction(Enum_Mode.Cancel);

                            //    }
                            //    sS_MaskedTextBox_SupplierNo.Focus();
                            //}
                            break;
                        }
                    case Enum_Mode.PreAdd:
                        Function_ClearData();
                        Function_SetReadOnlyControl(false);
                        sS_MaskedTextBox_SupplierNo.Text = Function_GetNextRunningNo();
                        sS_MaskedTextBox_SupplierNo.ReadOnly = false;
                        sS_MaskedTextBox_SupplierNo.Focus();
                        Enm_StateForm = Enum_Mode.PreAdd;
                        break;
                    case Enum_Mode.Add:
                        if (ValidateInput.ValidateData(Global.Lang.Str_Language))
                        {
                            VendorHomeObj.Vendorobj.ID = sS_MaskedTextBox_SupplierNo.Text;
                            VendorHomeObj.Vendorobj.FirstName = sS_MaskedTextBox_SupplierFirstName.Text;
                            VendorHomeObj.Vendorobj.LastName = sS_MaskedTextBox_SupplierLastName.Text;
                            VendorHomeObj.Vendorobj.Flag = Function_SupplierFlag();
                            VendorHomeObj.Vendorobj.Address1 = sS_MaskedTextBox_Address1.Text;
                            VendorHomeObj.Vendorobj.Address2 = sS_MaskedTextBox_Address2.Text;
                            VendorHomeObj.Vendorobj.City = sS_MaskedTextBox_City.Text;
                            VendorHomeObj.Vendorobj.State = sS_MaskedTextBox_State.Text;
                            VendorHomeObj.Vendorobj.Zip = sS_MaskedTextBox_Zip.Text;
                            VendorHomeObj.Vendorobj.Phone = sS_MaskedTextBox_Phone.Text;
                            VendorHomeObj.Vendorobj.Fax = sS_MaskedTextBox_Fax.Text;
                            VendorHomeObj.Vendorobj.Contact = sS_MaskedTextBox_Contact.Text;
                            VendorHomeObj.Vendorobj.Email = sS_MaskedTextBox_Email.Text;
                            VendorHomeObj.Vendorobj.Remark = sS_MaskedTextBox_Remark.Text;

                            Vendor VendorObj = new Vendor();
                            VendorObj = Manager.Engine.GetObject<Vendor>(sS_MaskedTextBox_SupplierNo.Text);
                            if (VendorObj != null)
                            {
                                SS_MyMessageBox.ShowBox("SupplierNo : " + sS_MaskedTextBox_SupplierNo.Text + "is duplicate data", "Warning", DialogMode.OkOnly, this.Name, "000010",Obj_SupplierNo, Global.Lang.Str_Language);
                                Global.Bool_CheckComplete = false;
                                sS_MaskedTextBox_SupplierNo.Focus();
                                break;
                            }
                            else
                            {
                                if (VendorHomeObj.Add())
                                {
                                    Function_SaveCurrentRunningNo(currentNo);
                                    SS_MyMessageBox.ShowBox("Add data : " + sS_MaskedTextBox_SupplierNo.Text + " Complete", "Add Data Information", DialogMode.OkOnly, this.Name, "000001", Obj_SupplierNo, Global.Lang.Str_Language);
                                    Global.Bool_CheckComplete = true;
                                    Enm_StateForm = Enum_Mode.PreAdd;
                                    Function_ExecuteTransaction(Enum_Mode.Cancel);
                                }
                                else
                                {
                                    SS_MyMessageBox.ShowBox("Can not add data: " + sS_MaskedTextBox_SupplierNo.Text + " !", "Warning", DialogMode.OkOnly, this.Name, "000002", Obj_SupplierNo, Global.Lang.Str_Language);
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
                        sS_MaskedTextBox_SupplierFirstName.Focus();
                        Enm_StateForm = Enum_Mode.PreEdit;
                        break;
                    case Enum_Mode.Edit:
                        {
                            if (ValidateInput.ValidateData(Global.Lang.Str_Language))
                            {
                                VendorHomeObj.Vendorobj.ID = sS_MaskedTextBox_SupplierNo.Text;
                                VendorHomeObj.Vendorobj.FirstName = sS_MaskedTextBox_SupplierFirstName.Text;
                                VendorHomeObj.Vendorobj.LastName = sS_MaskedTextBox_SupplierLastName.Text;
                                VendorHomeObj.Vendorobj.Flag = Function_SupplierFlag();
                                VendorHomeObj.Vendorobj.Address1 = sS_MaskedTextBox_Address1.Text;
                                VendorHomeObj.Vendorobj.Address2 = sS_MaskedTextBox_Address2.Text;
                                VendorHomeObj.Vendorobj.City = sS_MaskedTextBox_City.Text;
                                VendorHomeObj.Vendorobj.State = sS_MaskedTextBox_State.Text;
                                VendorHomeObj.Vendorobj.Zip = sS_MaskedTextBox_Zip.Text;
                                VendorHomeObj.Vendorobj.Phone = sS_MaskedTextBox_Phone.Text;
                                VendorHomeObj.Vendorobj.Fax = sS_MaskedTextBox_Fax.Text;
                                VendorHomeObj.Vendorobj.Contact = sS_MaskedTextBox_Contact.Text;
                                VendorHomeObj.Vendorobj.Email = sS_MaskedTextBox_Email.Text;
                                VendorHomeObj.Vendorobj.Remark = sS_MaskedTextBox_Remark.Text;

                                if (VendorHomeObj.Edit())
                                {
                                    SS_MyMessageBox.ShowBox("Edit data : " + sS_MaskedTextBox_SupplierNo.Text + " Complete", "Edit Data Information", DialogMode.OkOnly, this.Name, "000003", Obj_SupplierNo, Global.Lang.Str_Language);
                                    Global.Bool_CheckComplete = true;
                                }
                                else
                                {
                                    SS_MyMessageBox.ShowBox("Can not edit data : " + sS_MaskedTextBox_SupplierNo.Text + " !", "Warning", DialogMode.OkOnly, this.Name, "000004", Obj_SupplierNo, Global.Lang.Str_Language);
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
                        if (sS_DataGridView_Supplier.SelectedRows.Count > 1)
                        {
                            List<Vendor> VendorCollection = new List<Vendor>();
                            Vendor TempVendor = new Vendor();

                            foreach (DataGridViewRow TempDataGridRow in sS_DataGridView_Supplier.SelectedRows)
                            {
                                TempVendor = Manager.Engine.GetObject<Vendor>(TempDataGridRow.Cells[0].Value.ToString());
                                VendorCollection.Add(TempVendor);

                            }
                            if (SS_MyMessageBox.ShowBox("Do you want to delete data" + sS_DataGridView_Supplier.SelectedRows.Count + "record ?", "Delete Data Information", DialogMode.OkCancel, this.Name, "000014", Obj_SupplierRow, Global.Lang.Str_Language) == DialogResult.OK)
                            {

                                Wilson.ORMapper.Transaction ORTransaction = Manager.Engine.BeginTransaction();

                                if (VendorHomeObj.Delete(ORTransaction, VendorCollection))
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
                            if (sS_MaskedTextBox_SupplierNo.Text != "")
                            {
                                if (SS_MyMessageBox.ShowBox("Do you want to delete : " + sS_MaskedTextBox_SupplierNo.Text + " ?", "Delete Data Information", DialogMode.OkCancel, this.Name, "000005", Obj_SupplierNo, Global.Lang.Str_Language) == DialogResult.OK)
                                {
                                    Global.Bool_CheckComplete = true;
                                    VendorHomeObj.Vendorobj.ID = sS_MaskedTextBox_SupplierNo.Text;
                                    if (VendorHomeObj.Delete())
                                    {
                                        SS_MyMessageBox.ShowBox("Delete data : " + sS_MaskedTextBox_SupplierNo.Text + "complete", "Delete Data Information", DialogMode.OkOnly, this.Name, "000006", Obj_SupplierNo, Global.Lang.Str_Language);
                                        Global.Bool_CheckComplete = true;

                                        Enm_StateForm = Enum_Mode.PreAdd;
                                        Function_ShowDataInDatagridView();
                                    }
                                    else
                                    {
                                        SS_MyMessageBox.ShowBox("Can not delete data : " + sS_MaskedTextBox_SupplierNo.Text + " !", "Warning", DialogMode.OkOnly, this.Name, "000007", Obj_SupplierNo, Global.Lang.Str_Language);
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
                        if (sS_DataGridView_Supplier.Rows.Count > 0)
                        {
                            sS_MaskedTextBox_SupplierNo.ReadOnly = true;
                            sS_MaskedTextBox_SupplierNo.Text = sS_DataGridView_Supplier[0, sS_DataGridView_Supplier.CurrentRow.Index].Value.ToString();
                            Vendor VendorObj = new Vendor();
                            VendorObj = Manager.Engine.GetObject<Vendor>(sS_MaskedTextBox_SupplierNo.Text);
                            if (VendorObj != null)
                            {
                                sS_MaskedTextBox_SupplierFirstName.Text = VendorObj.FirstName;
                                sS_MaskedTextBox_SupplierLastName.Text = VendorObj.LastName;
                                sS_ComboBox_SupplierTypes.Text = Function_ShowFlagInControl1(VendorObj.Flag);
                                sS_MaskedTextBox_Address1.Text = VendorObj.Address1;
                                sS_MaskedTextBox_Address2.Text = VendorObj.Address2;
                                sS_MaskedTextBox_City.Text = VendorObj.City;
                                sS_MaskedTextBox_State.Text = VendorObj.State;
                                sS_MaskedTextBox_Zip.Text = VendorObj.Zip;
                                sS_MaskedTextBox_Phone.Text = VendorObj.Phone;
                                sS_MaskedTextBox_Fax.Text = VendorObj.Fax;
                                sS_MaskedTextBox_Email.Text = VendorObj.Email;
                                sS_MaskedTextBox_Contact.Text = VendorObj.Contact;
                                sS_MaskedTextBox_Remark.Text = VendorObj.Remark;
                                
                            }
                            sS_MaskedTextBox_SupplierNo.Focus();
                        }
                        break;
                        //////////
                    case Enum_Mode.ShowData_search:// 23-12-08 This function use for vender searching (key supplierNo. and Enter)
                        if (sS_DataGridView_Supplier.Rows.Count > 0)
                        {
                            sS_MaskedTextBox_SupplierNo.ReadOnly = false;
                            //sS_MaskedTextBox_SupplierNo.Text = sS_DataGridView_Supplier[0, sS_DataGridView_Supplier.CurrentRow.Index].Value.ToString();
                            Vendor VendorObj = new Vendor();
                            VendorObj = Manager.Engine.GetObject<Vendor>(sS_MaskedTextBox_SupplierNo.Text);
                            if (VendorObj != null)
                            {
                                sS_MaskedTextBox_SupplierFirstName.Text = VendorObj.FirstName;
                                sS_MaskedTextBox_SupplierLastName.Text = VendorObj.LastName;
                                sS_ComboBox_SupplierTypes.Text = Function_ShowFlagInControl1(VendorObj.Flag);
                                sS_MaskedTextBox_Address1.Text = VendorObj.Address1;
                                sS_MaskedTextBox_Address2.Text = VendorObj.Address2;
                                sS_MaskedTextBox_City.Text = VendorObj.City;
                                sS_MaskedTextBox_State.Text = VendorObj.State;
                                sS_MaskedTextBox_Zip.Text = VendorObj.Zip;
                                sS_MaskedTextBox_Phone.Text = VendorObj.Phone;
                                sS_MaskedTextBox_Fax.Text = VendorObj.Fax;
                                sS_MaskedTextBox_Email.Text = VendorObj.Email;
                                sS_MaskedTextBox_Contact.Text = VendorObj.Contact;
                                sS_MaskedTextBox_Remark.Text = VendorObj.Remark;

                            }
                            else
                            {
                                SS_MyMessageBox.ShowBox("No matched data.");
                                // Edit on 07-01-09 (Additional)
                                Enm_StateForm = Enum_Mode.PreAdd;
                                Global.ConfigForm.Enum_FlagTransaction = Enum_Mode.PreAdd;

                            }
                            sS_MaskedTextBox_SupplierNo.Focus();
                        }
                        break;

                        /////////
                    case Enum_Mode.Cancel:
                        if (Enm_StateForm == Enum_Mode.PreEdit)
                        {
                            Function_ExecuteTransaction(Enum_Mode.ShowData);
                            sS_MaskedTextBox_SupplierNo.Focus();
                        }
                        if (Enm_StateForm == Enum_Mode.PreAdd)
                        {
                            Function_ClearData();
                            sS_MaskedTextBox_SupplierNo.Focus();
                            Function_ShowDataInDatagridView();
                        }
                        if (Enm_StateForm == Enum_Mode.PreSearch)
                        {
                            sS_MaskedTextBox_SupplierNo.ReadOnly = false;
                            Function_SetReadOnlyControl(true);
                            Enm_StateForm = Enum_Mode.PreAdd;
                        }
                        break;
                    DEFAULT:
                        Function_ClearData();
                        sS_MaskedTextBox_SupplierNo.ReadOnly = false;
                        sS_MaskedTextBox_SupplierNo.Focus();
                        Function_ShowDataInDatagridView();
                        break;
                }
                Obj_SupplierNo = null;
                Obj_SupplierRow = null;
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
                sS_MaskedTextBox_SupplierNo.Text = "";
                sS_MaskedTextBox_SupplierFirstName.Text = "";
                sS_MaskedTextBox_SupplierLastName.Text = "";
                sS_MaskedTextBox_Address1.Text = "";
                sS_MaskedTextBox_Address2.Text = "";
                sS_MaskedTextBox_City.Text = "";
                sS_MaskedTextBox_State.Text = "";
                sS_MaskedTextBox_Zip.Text = "";
                sS_MaskedTextBox_Phone.Text = "";
                sS_MaskedTextBox_Fax.Text = "";
                sS_MaskedTextBox_Email.Text = "";
                sS_MaskedTextBox_Contact.Text = "";
                sS_MaskedTextBox_Remark.Text = "";
                sS_ComboBox_SupplierTypes.SelectedIndex = 0;
               
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
                DataSet Ds_Supplier = new DataSet();
                Ds_Supplier = Manager.Engine.GetDataSet<Vendor>("");
                sS_DataGridView_Supplier.DataSource = Ds_Supplier;
                sS_DataGridView_Supplier.DataMember = "Table";
                Function_SetVendorFlagInDataGrid();
                Ds_Supplier.Dispose();
                Ds_Supplier = null;

            }
            catch (Exception Err)
            {
                SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
            }
        }

        private void Function_SetVendorFlagInDataGrid()
        {
            if(sS_DataGridView_Supplier.Rows.Count!=0)
            {
                for (int i = 0; i <= sS_DataGridView_Supplier.Rows.Count - 1; i++)
                {
                    if (sS_DataGridView_Supplier[12, i].Value != null)
                    {
                        if (sS_DataGridView_Supplier[12, i].Value.ToString() != "")
                        {
                            switch (sS_DataGridView_Supplier[12, i].Value.ToString())
                            {
                                case "C":
                                    sS_DataGridView_Supplier[12, i].Value = "Customer";
                                    break;
                                case "V":
                                    sS_DataGridView_Supplier[12, i].Value = "Supplier";
                                    break;
                            }
                        }
                    }
                }
            }

        }

        public void Function_SetReadOnlyControl(bool Bool_StateControl)
        {
            sS_MaskedTextBox_SupplierFirstName.ReadOnly = false;
            sS_MaskedTextBox_SupplierLastName.ReadOnly = false;
            sS_MaskedTextBox_Address1.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_Address2.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_City.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_Zip.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_Phone.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_Fax.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_Email.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_State.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_Contact.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_Remark.ReadOnly = Bool_StateControl;
          
        }

    
        private string Function_SupplierFlag()
        {
            String Str_Flag = "";
            try
            {
                
                switch (sS_ComboBox_SupplierTypes.SelectedIndex)
                {
                    case 0:
                        Str_Flag = "C";
                        break;
                    case 1:
                        Str_Flag = "V";
                        break;
                        
                }
               
            }
            catch (Exception Err)
            {
                SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
            }
            return Str_Flag;
        }
        private void Function_ShowFlagInControl()
        {
            try
            {
                switch (sS_ComboBox_SupplierTypes.Text)
                {
                    case "C":
                        sS_ComboBox_SupplierTypes.Text = "Customer";
                        break;
                    case "V":
                        sS_ComboBox_SupplierTypes.Text = "Supplier";
                        break;
                }
            }
            catch (Exception Err)
            {
                SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
            }
        }

        private string Function_ShowFlagInControl1(string Str_TempSupplierType)
        {
            try
            {
                switch (Str_TempSupplierType)
                {
                    case "C":
                        sS_ComboBox_SupplierTypes.Text = "Customer";
                        break;
                    case "V":
                        sS_ComboBox_SupplierTypes.Text = "Supplier";
                        break;
                }

            }
            catch (Exception Err)
            {
                SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
            }
            return sS_ComboBox_SupplierTypes.Text;
        }

        private void Form_002005_Supplier_FormClosed(object sender, FormClosedEventArgs e)
        {
            Global.Function_RemoveTabStripButton(this.Tag);
        }

        private void Form_002005_Supplier_Activated(object sender, EventArgs e)
        {
            AuthorizeState.Funtion_SetButtonAuthorize(Enm_StateForm);
        }

        private void sS_DataGridView_Supplier_Click(object sender, EventArgs e)
        {
            Function_ExecuteTransaction(Enum_Mode.ShowData);
            Enm_StateForm = Enum_Mode.CellClick;
            AuthorizeState.Funtion_SetButtonAuthorize(Enm_StateForm);
            //Global.Function_ToolStripSetUP(Enum_Mode.CellClick);
            Function_ShowFlagInControl();

            // Edit on 07-01-09 (Additional)
            Enm_StateForm = Enum_Mode.PreAdd;
            Global.ConfigForm.Enum_FlagTransaction = Enum_Mode.PreAdd;
        }

        private void Form_002005_Supplier_FormClosing(object sender, FormClosingEventArgs e)
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
                string qry = "SELECT Prefix, CurrentRun FROM SysRunNo WHERE RunID = 2"; // Supplier

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
                             "' WHERE RunId = 2"; // Supplier

                Manager.Engine.ExecuteCommand(qry);
            }
            catch { }

        }

        private void sS_MaskedTextBox_SupplierNo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void Function_ShowDataSerchKey()
        {

            Function_ExecuteTransaction(Enum_Mode.ShowData_search);
            
        }

        private void Function_ShowDataInDatagridViewByName()
        {
            try
            {
                DataSet Ds_Supplier = new DataSet();
                string str_val = sS_MaskedTextBox_SupplierFirstName.Text.ToString().Trim();
               
                string SQL = "SELECT * FROM Vendor WHERE vendorFirstName LIKE '%" + str_val + "%' ";
                
                Ds_Supplier = Manager.Engine.GetDataSet(SQL);
                if (Ds_Supplier.Tables[0].Rows.Count > 0)
                {
                    sS_DataGridView_Supplier.DataSource = Ds_Supplier;
                    sS_DataGridView_Supplier.DataMember = "Table";
                    Function_SetVendorFlagInDataGrid();
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
                sS_MaskedTextBox_SupplierFirstName.Focus();
                sS_MaskedTextBox_SupplierFirstName.SelectAll();
            }
            catch (Exception Err)
            {
                SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
            }
        }

        private void Function_ShowDataInDatagridViewByTagID()
        {
            try
            {
                DataSet Ds_Supplier = new DataSet();
                string str_val = sS_MaskedTextBox_SupplierLastName.Text.ToString().Trim();

                string SQL = "SELECT vendorID,vendorFirstName,vendorLastName AS TaggedID,vendorAddress1,vendorAddress2,vendorCity,vendorState,vendorZip,vendorPhone,vendorFax,vendorEmail,vendorContact,VendorFlag,Remark FROM Vendor WHERE vendorLastName LIKE '%" + str_val + "%' ";
                Ds_Supplier = Manager.Engine.GetDataSet(SQL);
                if (Ds_Supplier.Tables[0].Rows.Count > 0)
                {
                    sS_DataGridView_Supplier.DataSource = Ds_Supplier;
                    sS_DataGridView_Supplier.DataMember = "Table";
                    Function_SetVendorFlagInDataGrid();
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
                sS_MaskedTextBox_SupplierLastName.Focus();
                sS_MaskedTextBox_SupplierLastName.SelectAll();

            }
            catch (Exception Err)
            {
                SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
            }
        }

        
        private void sS_MaskedTextBox_SupplierFirstName_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                Function_ShowDataInDatagridViewByName();

                Enm_StateForm = Enum_Mode.CellClick;
                AuthorizeState.Funtion_SetButtonAuthorize(Enm_StateForm);
            }
        }

        private void sS_MaskedTextBox_SupplierLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                Function_ShowDataInDatagridViewByTagID();

                

                Enm_StateForm = Enum_Mode.CellClick;
                AuthorizeState.Funtion_SetButtonAuthorize(Enm_StateForm);
            }
        }

       

    }
}