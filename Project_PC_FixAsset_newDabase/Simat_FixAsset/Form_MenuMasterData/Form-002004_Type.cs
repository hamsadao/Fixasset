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
using SimatSoft.QueryManager;  

namespace SimatSoft.FixAsset
{
    public partial class Form_002004_Type : SS_PaintGradientForm
    {
        public Class_QueryManager clsquery = new Class_QueryManager();
        Class_AuthorizeState AuthorizeState = new Class_AuthorizeState();
        private Enum_Mode Enm_StateForm = Enum_Mode.Search; 
        public Form_002004_Type()
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
            this.Text = Global.Function_Language(this, this, "ID:002004(Type)");
            LBL_TypeNo.Text = Global.Function_Language(this, LBL_TypeNo, " Type No:");
            LBL_TypeName.Text = Global.Function_Language(this, LBL_TypeName, "Type Name:");
            LBL_Remark.Text = Global.Function_Language(this, LBL_Remark, "Remark:");
        }

        private void Form_002004_Type_Load(object sender, EventArgs e)
        {
            Function_ShowDataInDatagridView();
            Function_ClearData();
            //sS_MaskedTextBox_TypeNo.ReadOnly = true;
            sS_MaskedTextBox_TypeNo.ReadOnly = false;
            sS_MaskedTextBox_TypeName.ReadOnly = false;

            Function_SetReadOnlyControl(true);
            //clsquery.Show_Data("Screen","1", this, ref dataGridView1);  
        }
        public void Function_ExecuteTransaction(Enum_Mode mode)
        {
            try
            {
                TypeHome TypeHomeObj = new TypeHome();
                ValidateuserinputData ValidateInput = new ValidateuserinputData(Global.ConfigPath.Str_AppPathValidate + "\\" + this.Name + ".xml", this);
                object[] Obj_TypeNo = new object[1] { sS_MaskedTextBox_TypeNo.Text };
                object[] Obj_TypeRow = new object[1] { sS_DataGridView_Type.SelectedRows.Count };
                switch (mode)
                {
                    case Enum_Mode.Search:
                        {
                            break;
                        }
                    case Enum_Mode.PreAdd:
                        {
                            Function_ClearData();
                            Function_SetReadOnlyControl(false);
                            sS_MaskedTextBox_TypeNo.ReadOnly = false;
                            sS_MaskedTextBox_TypeNo.Focus();
                            Enm_StateForm = Enum_Mode.PreAdd;
                            break;
                        }
                    case Enum_Mode.Add:
                            if (ValidateInput.ValidateData(Global.Lang.Str_Language))
                            {
                                TypeHomeObj.Typeobj.ID = sS_MaskedTextBox_TypeNo.Text;
                                TypeHomeObj.Typeobj.Name = sS_MaskedTextBox_TypeName.Text;
                                TypeHomeObj.Typeobj.Remark = sS_MaskedTextBox_Remark.Text;
                                TypeHomeObj.Typeobj.Group = "ASSET";

                                SimatSoft.DB.ORM.Type TypeObj = new SimatSoft.DB.ORM.Type();
                                TypeObj = Manager.Engine.GetObject<SimatSoft.DB.ORM.Type>(sS_MaskedTextBox_TypeNo.Text);
                                if (TypeObj != null)
                                {
                                    SS_MyMessageBox.ShowBox("TypeNo : " + sS_MaskedTextBox_TypeNo.Text + " is duplicate data", "Warning", DialogMode.OkOnly, this.Name, "000010", Obj_TypeNo, Global.Lang.Str_Language);
                                    Global.Bool_CheckComplete = false;
                                    sS_MaskedTextBox_TypeNo.Focus();
                                    break;
                                }
                                else
                                {
                                    if (TypeHomeObj.Add())
                                    {
                                        SS_MyMessageBox.ShowBox("Add data : " + sS_MaskedTextBox_TypeNo.Text + " Complete", "Add Data Information", DialogMode.OkOnly, this.Name, "000001", Obj_TypeNo, Global.Lang.Str_Language);
                                        Global.Bool_CheckComplete = true;
                                        Enm_StateForm = Enum_Mode.PreAdd;
                                        Function_ExecuteTransaction(Enum_Mode.Cancel);
                                    }
                                    else
                                    {
                                        SS_MyMessageBox.ShowBox("Can not add data: " + sS_MaskedTextBox_TypeNo.Text + " !", "Warning", DialogMode.OkOnly, this.Name, "000002", Obj_TypeNo, Global.Lang.Str_Language);
                                        Global.Bool_CheckComplete = false;
                                        goto DEFAULT;
                                    }
                                }
                                
                            }
                            else
                                Global.Bool_CheckComplete=false;
                                break;

                    case Enum_Mode.PreEdit:
                        Function_SetReadOnlyControl(false);
                        sS_MaskedTextBox_TypeName.Focus();
                        Enm_StateForm = Enum_Mode.PreEdit;
                        break;
                    case Enum_Mode.Edit:
                        {
                            if (ValidateInput.ValidateData(Global.Lang.Str_Language))
                            {
                                TypeHomeObj.Typeobj.ID = sS_MaskedTextBox_TypeNo.Text;
                                TypeHomeObj.Typeobj.Name = sS_MaskedTextBox_TypeName.Text;
                                TypeHomeObj.Typeobj.Remark = sS_MaskedTextBox_Remark.Text;
                                TypeHomeObj.Typeobj.Group = "ASSET";
                                if (TypeHomeObj.Edit())
                                {
                                    SS_MyMessageBox.ShowBox("Edit data : " + sS_MaskedTextBox_TypeNo.Text + " Complete", "Edit Data Information", DialogMode.OkOnly, this.Name, "000003", Obj_TypeNo, Global.Lang.Str_Language);
                                    Global.Bool_CheckComplete = true;

                                }
                                else
                                {
                                    SS_MyMessageBox.ShowBox("Can not edit data : " + sS_MaskedTextBox_TypeNo.Text + " !", "Warning", DialogMode.OkOnly, this.Name, "000004", Obj_TypeNo, Global.Lang.Str_Language);
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
                            if (sS_DataGridView_Type.SelectedRows.Count > 1)
                            {
                                List<SimatSoft.DB.ORM.Type> TypeCollection = new List<SimatSoft.DB.ORM.Type>();
                                SimatSoft.DB.ORM.Type TempType = new SimatSoft.DB.ORM.Type();

                                foreach (DataGridViewRow TempDataGridRow in sS_DataGridView_Type.SelectedRows)
                                {
                                    TempType = Manager.Engine.GetObject<SimatSoft.DB.ORM.Type>(TempDataGridRow.Cells[0].Value.ToString());
                                    TypeCollection.Add(TempType);
                                }
                                if (SS_MyMessageBox.ShowBox("Do you want to delete data" + sS_DataGridView_Type.SelectedRows.Count + "record ?", "Delete Data Information", DialogMode.OkCancel, this.Name, "000014", Obj_TypeRow, Global.Lang.Str_Language) == DialogResult.OK)
                                {

                                    Wilson.ORMapper.Transaction ORTransaction = Manager.Engine.BeginTransaction();

                                    if (TypeHomeObj.Delete(ORTransaction, TypeCollection))
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
                                if (sS_MaskedTextBox_TypeNo.Text != "")
                                {
                                    if (SS_MyMessageBox.ShowBox("Do you want to delete : " + sS_MaskedTextBox_TypeNo.Text + " ?", "Delete Data Information", DialogMode.OkCancel, this.Name, "000005", Obj_TypeNo, Global.Lang.Str_Language) == DialogResult.OK)
                                    {
                                        TypeHomeObj.Typeobj.ID = sS_MaskedTextBox_TypeNo.Text;

                                        if (TypeHomeObj.Delete())
                                        {
                                            SS_MyMessageBox.ShowBox("Delete data : " + sS_MaskedTextBox_TypeNo.Text + "complete", "Delete Data Information", DialogMode.OkOnly, this.Name, "000006", Obj_TypeNo, Global.Lang.Str_Language);
                                            Global.Bool_CheckComplete = true;

                                            Enm_StateForm = Enum_Mode.PreAdd;
                                            Function_ShowDataInDatagridView();
                                        }
                                        else
                                        {
                                            SS_MyMessageBox.ShowBox("Can not delete data : " + sS_MaskedTextBox_TypeNo.Text + " !", "Warning", DialogMode.OkOnly, this.Name, "000007", Obj_TypeNo, Global.Lang.Str_Language);
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
                        if (sS_DataGridView_Type.Rows.Count > 0)
                        {
                            sS_MaskedTextBox_TypeNo.ReadOnly = true;
                            sS_MaskedTextBox_TypeNo.Text = sS_DataGridView_Type[0, sS_DataGridView_Type.CurrentRow.Index].Value.ToString();
                            SimatSoft.DB.ORM.Type TypeObj = new SimatSoft.DB.ORM.Type();
                            TypeObj = Manager.Engine.GetObject<SimatSoft.DB.ORM.Type>(sS_MaskedTextBox_TypeNo.Text);
                            if (TypeObj != null)
                            {
                                sS_MaskedTextBox_TypeName.Text = TypeObj.Name;
                                sS_MaskedTextBox_Remark.Text = TypeObj.Remark;
                            }
                            sS_MaskedTextBox_TypeNo.Focus();
                        }
                        break;
                    case Enum_Mode.ShowData_search://
                        if (sS_DataGridView_Type.Rows.Count > 0)
                        {
                            sS_MaskedTextBox_TypeNo.ReadOnly = true;
                           // sS_MaskedTextBox_TypeNo.Text = sS_DataGridView_Type[0, sS_DataGridView_Type.CurrentRow.Index].Value.ToString();
                            SimatSoft.DB.ORM.Type TypeObj = new SimatSoft.DB.ORM.Type();
                            TypeObj = Manager.Engine.GetObject<SimatSoft.DB.ORM.Type>(sS_MaskedTextBox_TypeNo.Text);
                            if (TypeObj != null)
                            {
                                sS_MaskedTextBox_TypeName.Text = TypeObj.Name;
                                sS_MaskedTextBox_Remark.Text = TypeObj.Remark;
                            }
                            else
                            {
                                SS_MyMessageBox.ShowBox("No matched data.");
                                // Edit on 07-01-09 (Additional)
                                Enm_StateForm = Enum_Mode.PreAdd;
                                Global.ConfigForm.Enum_FlagTransaction = Enum_Mode.PreAdd;
                            }
                            sS_MaskedTextBox_TypeNo.Focus();

                            
                        }
                        break;
                    case Enum_Mode.Cancel:
                        if (Enm_StateForm == Enum_Mode.PreEdit)
                        {
                            Function_ExecuteTransaction(Enum_Mode.ShowData);
                            sS_MaskedTextBox_TypeNo.Focus();
                        }
                        if (Enm_StateForm == Enum_Mode.PreAdd)
                        {
                            Function_ClearData();
                            sS_MaskedTextBox_TypeNo.Focus();
                            Function_ShowDataInDatagridView();
                        }
                        if (Enm_StateForm == Enum_Mode.PreSearch)
                        {
                            sS_MaskedTextBox_TypeNo.ReadOnly = false;
                            sS_MaskedTextBox_TypeName.ReadOnly = false;

                            Function_SetReadOnlyControl(false);
                            Enm_StateForm = Enum_Mode.PreAdd;
                        }
                        else
                        {
                            //sS_MaskedTextBox_TypeNo.ReadOnly = true;
                            //Edit 0n 07-01-09
                            sS_MaskedTextBox_TypeNo.ReadOnly = false;
                            sS_MaskedTextBox_TypeName.ReadOnly = false;
                            //////
                            Function_SetReadOnlyControl(false);
                            Enm_StateForm = Enum_Mode.Search;
                        }
                        break; 

                    DEFAULT:
                        Function_ClearData();
                        sS_MaskedTextBox_TypeNo.ReadOnly = false;
                        sS_MaskedTextBox_TypeNo.Focus();
                        Function_ShowDataInDatagridView();
                        break;

                }
                Obj_TypeNo = null;
                Obj_TypeRow = null;
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
                sS_MaskedTextBox_TypeNo.Text = "";
                sS_MaskedTextBox_TypeName.Text = "";
                sS_MaskedTextBox_Remark.Text = "";
            }
            catch (Exception Err)
            {
                SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
            }
        }
        public void Function_SetReadOnlyControl(bool Bool_StateControl)
        {
            //sS_MaskedTextBox_TypeName.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_Remark.ReadOnly = Bool_StateControl;
        }

        private void Function_ShowDataInDatagridView()
        {
            try
            {
               
                DataSet Ds = new DataSet();
                Ds= Manager.Engine.GetDataSet<SimatSoft.DB.ORM.Type>(" TypeGroup = 'ASSET'");
                sS_DataGridView_Type.DataSource = Ds;
                sS_DataGridView_Type.DataMember = "Table";
                Ds.Dispose();
                Ds = null;
            }
            catch (Exception Err)
            {
                SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
            }
        }
       
        private void Form_002004_Type_FormClosed(object sender, FormClosedEventArgs e)
        {
            Global.Function_RemoveTabStripButton(this.Tag);
        }
        private void sS_MaskedTextBox_TypeNo_DoubleClick(object sender, EventArgs e)
        {
            //clsquery.Searchdata(this, ref dataGridView1 );  
        }
        private void button1_Click(object sender, EventArgs e)
        {
            cls_main.texttemp.Text = "";
            SimatSoft.QueryManager.Form_Present frm = new Form_Present();
            frm.Show_Data("Screen", "1");
            frm.MdiParent = this.MdiParent;
            frm.Controlreturnvalue = sS_MaskedTextBox_TypeNo;// cls_main.texttemp;
            frm.Show();
            sS_MaskedTextBox_TypeNo.Text  = cls_main.texttemp.Text;   
        }

        private void Form_002004_Type_Activated(object sender, EventArgs e)
        {
            AuthorizeState.Funtion_SetButtonAuthorize(Enm_StateForm);
        }

        private void sS_DataGridView_Type_Click(object sender, EventArgs e)
        {
            Function_ExecuteTransaction(Enum_Mode.ShowData);
            Enm_StateForm = Enum_Mode.CellClick;
            //Global.Function_ToolStripSetUP(Enum_Mode.CellClick);
            AuthorizeState.Funtion_SetButtonAuthorize(Enm_StateForm);

            // Edit on 07-01-09 (Additional)
            Enm_StateForm = Enum_Mode.PreAdd;
            Global.ConfigForm.Enum_FlagTransaction = Enum_Mode.PreAdd;
        }

        private void Form_002004_Type_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Global.Location.Int_CountForm > 0)
            {
                Global.Location.Int_CountForm = Global.Location.Int_CountForm - 1;
            }
            AuthorizeState.Funtion_SetButtonAuthorize(Enum_Mode.SetDefault);
        }

        private void sS_MaskedTextBox_TypeNo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void sS_MaskedTextBox_TypeName_KeyPress(object sender, KeyPressEventArgs e)
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
                string str_val = sS_MaskedTextBox_TypeName.Text.ToString().Trim();

                string SQL = "SELECT * FROM Type WHERE typeName LIKE '%" + str_val + "%' ";

                Ds_Supplier = Manager.Engine.GetDataSet(SQL);
                if (Ds_Supplier.Tables[0].Rows.Count > 0)
                {
                    sS_DataGridView_Type.DataSource = Ds_Supplier;
                    sS_DataGridView_Type.DataMember = "Table";
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
                sS_MaskedTextBox_TypeName.Focus();
                sS_MaskedTextBox_TypeName.SelectAll();
            }
            catch (Exception Err)
            {
                SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
            }
        }
    }
}