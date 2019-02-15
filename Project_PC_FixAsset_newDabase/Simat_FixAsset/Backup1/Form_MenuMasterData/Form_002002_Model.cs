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
    public partial class Form_002002_Model : SS_PaintGradientForm
    {
        public Class_QueryManager clsquery = new Class_QueryManager();
        Class_AuthorizeState AuthorizeState = new Class_AuthorizeState();
        private Enum_Mode Enm_StateForm = Enum_Mode.Search;

        string fildName = "";
        string value_str = "";

        private string currentNo = "";

        public Form_002002_Model()
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
            this.Text = Global.Function_Language(this, this, "ID:002002(Model)");
            LBL_ModelNo.Text = Global.Function_Language(this, LBL_ModelNo, " Model No:");
            LBL_ModelName.Text = Global.Function_Language(this, LBL_ModelName, "Model Name:");
            LBL_Brand.Text = Global.Function_Language(this, LBL_Brand, " Brand:");
            LBL_Value.Text = Global.Function_Language(this, LBL_Value, "Value:");
        } 
        public void Function_ExecuteTransaction(Enum_Mode mode)
        {
            try
            {
                ModelHome ModelHomeObj = new ModelHome();
                ValidateuserinputData ValidateInput = new ValidateuserinputData(Global.ConfigPath.Str_AppPathValidate + "\\" + this.Name + ".xml", this);
                object[] Obj_ModelID = new object[1] { sS_MaskedTextBox_ModelNo.Text };
                object[] Obj_ModelRow = new object[1] { sS_DataGridView_Model.SelectedRows.Count };
                switch (mode)
                {
                    case Enum_Mode.Search:
                            break;
                    case Enum_Mode.PreAdd:
                            Function_ClearData();
                            Function_SetReadOnlyControl(false);
                        // Edit on 26-01-09 ///
                            sS_MaskedTextBox_ModelNo.Text = Function_GetNextRunningNo();
                        /////////////////
                            sS_MaskedTextBox_ModelNo.ReadOnly = false;
                            sS_MaskedTextBox_ModelNo.Focus();
                            Enm_StateForm = Enum_Mode.PreAdd;
                            break;
                        case Enum_Mode.Add:
                                if (ValidateInput.ValidateData(Global.Lang.Str_Language))
                                {
                                    ModelHomeObj.Modelobj.ID = sS_MaskedTextBox_ModelNo.Text;
                                    ModelHomeObj.Modelobj.Name = sS_MaskedTextBox_ModelName.Text;
                                    ModelHomeObj.Modelobj.Brand = sS_MaskedTextBox_Brand.Text;
                                    if (sS_MaskedTextBox_Value.Text != "")
                                    {
                                        ModelHomeObj.Modelobj.Value = Convert.ToDecimal(sS_MaskedTextBox_Value.Text);
                                    }
                                    else
                                    {
                                        ModelHomeObj.Modelobj.Value = 0;
                                    }

                                    Model ModelObj = new Model();
                                    ModelObj = Manager.Engine.GetObject<Model>(sS_MaskedTextBox_ModelNo.Text);
                                    if (ModelObj != null)
                                    {
                                        SS_MyMessageBox.ShowBox("ModelNo :" + sS_MaskedTextBox_ModelNo.Text + "is duplicate data", "Warning", DialogMode.OkOnly ,this.Name, "000010", Obj_ModelID, Global.Lang.Str_Language);
                                        Global.Bool_CheckComplete = false;
                                        sS_MaskedTextBox_ModelNo.Focus();
                                        break;
                                    }
                                    else
                                    {
                                        if (ModelHomeObj.Add())
                                        {
                                            Function_SaveCurrentRunningNo(currentNo);

                                            SS_MyMessageBox.ShowBox("Add data : " + sS_MaskedTextBox_ModelNo.Text + " Complete", "Add Data Information", DialogMode.OkOnly, this.Name, "000001", Obj_ModelID, Global.Lang.Str_Language);
                                            Global.Bool_CheckComplete = true;
                                            Enm_StateForm = Enum_Mode.PreAdd;
                                            Function_ExecuteTransaction(Enum_Mode.Cancel);
                                        }
                                        else
                                        {
                                            SS_MyMessageBox.ShowBox("Can not add data: " + sS_MaskedTextBox_ModelNo.Text + " !", "Warning", DialogMode.OkOnly, this.Name, "000002", Obj_ModelID, Global.Lang.Str_Language);
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
                        sS_MaskedTextBox_ModelName.Focus();
                        Enm_StateForm = Enum_Mode.PreEdit;
                        break;
                    case Enum_Mode.Edit:
                        if (ValidateInput.ValidateData(Global.Lang.Str_Language))
                        {
                            ModelHomeObj.Modelobj.ID = sS_MaskedTextBox_ModelNo.Text;
                            ModelHomeObj.Modelobj.Name = sS_MaskedTextBox_ModelName.Text;
                            ModelHomeObj.Modelobj.Brand = sS_MaskedTextBox_Brand.Text;
                            if (sS_MaskedTextBox_Value.Text != "")
                            {
                                ModelHomeObj.Modelobj.Value = Convert.ToDecimal(sS_MaskedTextBox_Value.Text);
                            }
                            else
                            {
                                ModelHomeObj.Modelobj.Value = 0;
                            }
                            if (ModelHomeObj.Edit())
                            {
                                SS_MyMessageBox.ShowBox("Edit data : " + sS_MaskedTextBox_ModelNo.Text + " Complete", "Edit Data Information", DialogMode.OkOnly, this.Name, "000003", Obj_ModelID, Global.Lang.Str_Language);
                                Global.Bool_CheckComplete = true;

                            }
                            else
                            {
                                SS_MyMessageBox.ShowBox("Can not edit data : " + sS_MaskedTextBox_ModelNo.Text + " !", "Warning", DialogMode.OkOnly, this.Name, "000004", Obj_ModelID, Global.Lang.Str_Language);
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
                        if (sS_DataGridView_Model.SelectedRows.Count > 1)
                        {
                            List<Model> ModelCollection = new List<Model>();
                            Model TempModel = new Model();

                            foreach (DataGridViewRow TempDataGridRow in sS_DataGridView_Model.SelectedRows)
                            {
                                TempModel = Manager.Engine.GetObject<Model>(TempDataGridRow.Cells[0].Value.ToString());

                                ModelCollection.Add(TempModel);
                            }
                            if (SS_MyMessageBox.ShowBox("Do you want to delete data" + sS_DataGridView_Model.SelectedRows.Count + "record ?", "Delete Data Information", DialogMode.OkCancel, this.Name, "000014", Obj_ModelRow, Global.Lang.Str_Language) == DialogResult.OK)
                            {

                                Wilson.ORMapper.Transaction ORTransaction = Manager.Engine.BeginTransaction();

                                if (ModelHomeObj.Delete(ORTransaction, ModelCollection))
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
                            if (sS_MaskedTextBox_ModelNo.Text != "")
                            {
                                if (SS_MyMessageBox.ShowBox("Do you want to delete : " + sS_MaskedTextBox_ModelNo.Text + " ?", "Delete Data Information", DialogMode.OkCancel, this.Name, "000005", Obj_ModelID, Global.Lang.Str_Language) == DialogResult.OK)
                                {
                                    Global.Bool_CheckComplete = true;
                                    ModelHomeObj.Modelobj.ID = sS_MaskedTextBox_ModelNo.Text;
                                    if (ModelHomeObj.Delete())
                                    {
                                        SS_MyMessageBox.ShowBox("Delete data : " + sS_MaskedTextBox_ModelNo.Text + " Complete", "Delete Data Information", DialogMode.OkOnly, this.Name, "000006", Obj_ModelID, Global.Lang.Str_Language);
                                        Global.Bool_CheckComplete = true;

                                        Enm_StateForm = Enum_Mode.PreAdd;
                                        Function_ShowDataInDatagridView();
                                    }
                                    else
                                    {
                                        SS_MyMessageBox.ShowBox("Can not delete data : " + sS_MaskedTextBox_ModelNo.Text + " !", "Warning", DialogMode.OkOnly, this.Name, "000007", Obj_ModelID, Global.Lang.Str_Language);
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
                         if (sS_DataGridView_Model.Rows.Count > 0)
                         {
                             //sS_MaskedTextBox_ModelNo.ReadOnly = true;
                             sS_MaskedTextBox_ModelNo.Text = sS_DataGridView_Model[0, sS_DataGridView_Model.CurrentRow.Index].Value.ToString();
                             Model ModelObj = new Model();
                             ModelObj = Manager.Engine.GetObject<Model>(sS_MaskedTextBox_ModelNo.Text);
                             if (ModelObj != null)
                             {
                                 sS_MaskedTextBox_ModelName.Text = ModelObj.Name;
                                 sS_MaskedTextBox_Brand.Text = ModelObj.Brand;
                                 //sS_MaskedTextBox_Value.Text =Convert.ToString(ModelObj.Value);
                                 // Edit 26-01-09
                                 sS_MaskedTextBox_Value.Text = string.Format("{0:#,0.00}", Convert.ToDouble(ModelObj.Value));
                             }
                             sS_MaskedTextBox_ModelNo.ReadOnly = true;
                             sS_MaskedTextBox_ModelNo.Focus();
                             Function_SetReadOnlyControl(true);
                         }
                         break;
                     case Enum_Mode.ShowData_search://
                         if (sS_DataGridView_Model.Rows.Count > 0)
                         {
                             //sS_MaskedTextBox_ModelNo.ReadOnly = true;
                             //sS_MaskedTextBox_ModelNo.Text = sS_DataGridView_Model[0, sS_DataGridView_Model.CurrentRow.Index].Value.ToString();
                             Model ModelObj = new Model();
                             ModelObj = Manager.Engine.GetObject<Model>(sS_MaskedTextBox_ModelNo.Text);
                             if (ModelObj != null)
                             {
                                 sS_MaskedTextBox_ModelName.Text = ModelObj.Name;
                                 sS_MaskedTextBox_Brand.Text = ModelObj.Brand;
                                 //sS_MaskedTextBox_Value.Text = Convert.ToString(ModelObj.Value);
                                 // Edit 26-01-09
                                 sS_MaskedTextBox_Value.Text = string.Format("{0:#,0.00}", Convert.ToDouble(ModelObj.Value));
                             }
                             else
                             {
                                 SS_MyMessageBox.ShowBox("No matched data.");
                                 // Edit on 07-01-09 (Additional)
                                 Enm_StateForm = Enum_Mode.PreAdd;
                                 Global.ConfigForm.Enum_FlagTransaction = Enum_Mode.PreAdd;

                             }
                             sS_MaskedTextBox_ModelNo.ReadOnly = false;
                             sS_MaskedTextBox_ModelNo.Focus();
                             Function_SetReadOnlyControl(true);
                         }
                         break;
                     case Enum_Mode.Cancel:
                         if (Enm_StateForm == Enum_Mode.PreEdit)
                         {
                             Function_ExecuteTransaction(Enum_Mode.ShowData);
                             sS_MaskedTextBox_ModelNo.Focus();
                         }
                         if (Enm_StateForm == Enum_Mode.PreAdd)
                         {
                             Function_ClearData();
                             sS_MaskedTextBox_ModelNo.Focus();
                             Function_ShowDataInDatagridView();                          
                         }
                         if (Enm_StateForm == Enum_Mode.PreSearch)
                         {
                             sS_MaskedTextBox_ModelNo.ReadOnly = false;
                             Function_SetReadOnlyControl(true);
                             Enm_StateForm = Enum_Mode.PreAdd;
                         }
                         else
                         {
                             sS_MaskedTextBox_ModelNo.ReadOnly = false;
                             Function_SetReadOnlyControl(true);
                             Enm_StateForm = Enum_Mode.Search;
                         }
                         break;
                     DEFAULT:
                        Enm_StateForm = Enum_Mode.Search;
                        Function_ClearData();
                        sS_MaskedTextBox_ModelNo.ReadOnly = false;
                        sS_MaskedTextBox_ModelNo.Focus();
                        Function_ShowDataInDatagridView();
                        break;
                }
                Obj_ModelID = null;
                Obj_ModelRow = null;
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
                sS_MaskedTextBox_ModelNo.Text = "";
                sS_MaskedTextBox_ModelName.Text = "";
                sS_MaskedTextBox_Brand.Text = "";
                sS_MaskedTextBox_Value.Text = "";
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
               Ds = Manager.Engine.GetDataSet<Model>("");
               sS_DataGridView_Model.DataSource = Ds;
               sS_DataGridView_Model.DataMember = "Table";
               Ds.Dispose();
               Ds = null;                        
            }
            catch (Exception Err)
            {
                SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
            }
        }
        private void Form_002002_Model_Load(object sender, EventArgs e)
        {
            Global.Location.Int_CountForm = Global.Location.Int_CountForm + 0;
             Function_ClearData();
             Function_ShowDataInDatagridView();
             //Function_SetReadOnlyControl(true);
             sS_MaskedTextBox_ModelNo.ReadOnly = false;
             //clsquery.Show_Data("Screen", "2002", this, ref sS_DataGridView_Model);
             //clsquery.Searchdata(this, ref sS_DataGridView_Model);
        }

        

        private void sS_ButtonGlass_Cancel_Click(object sender, EventArgs e)
        {
            Global.Function_ToolStripSetUP(Enum_Mode.Search);
            Function_ClearData();
        }

        private void Form_002002_Model_FormClosed(object sender, FormClosedEventArgs e)
        {
            Global.Function_RemoveTabStripButton(this.Tag);
        }
        public void Function_SetReadOnlyControl(bool Bool_StateControl)
        {
            sS_MaskedTextBox_ModelName.ReadOnly = false;
            sS_MaskedTextBox_Brand.ReadOnly = false ;
            sS_MaskedTextBox_Value.ReadOnly = false ;
        }

        private void Form_002002_Model_Activated(object sender, EventArgs e)
        {
            AuthorizeState.Funtion_SetButtonAuthorize(Enm_StateForm);
        }

        private void sS_DataGridView_Model_Click(object sender, EventArgs e)
        {
            Function_ExecuteTransaction(Enum_Mode.ShowData);
            Enm_StateForm = Enum_Mode.CellClick;
            //Global.Function_ToolStripSetUP(Enum_Mode.CellClick);
            AuthorizeState.Funtion_SetButtonAuthorize(Enm_StateForm);

            // Edit on 07-01-09 (Additional)
            Enm_StateForm = Enum_Mode.PreAdd;
            Global.ConfigForm.Enum_FlagTransaction = Enum_Mode.PreAdd;
        }

        private void Form_002002_Model_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Global.Location.Int_CountForm > 0)
            {
                Global.Location.Int_CountForm = Global.Location.Int_CountForm - 1;
            }
            AuthorizeState.Funtion_SetButtonAuthorize(Enum_Mode.SetDefault);
        }

        private void sS_MaskedTextBox_ModelNo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void sS_MaskedTextBox_ModelName_KeyPress(object sender, KeyPressEventArgs e)
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
                string str_val = sS_MaskedTextBox_ModelName.Text.ToString().Trim();

                string SQL = "SELECT modelID,modelName,brand,value FROM Model WHERE modelName LIKE '%" + str_val + "%' ";

                Ds_Supplier = Manager.Engine.GetDataSet(SQL);
                if (Ds_Supplier.Tables[0].Rows.Count > 0)
                {
                    sS_DataGridView_Model.DataSource = Ds_Supplier;
                    sS_DataGridView_Model.DataMember = "Table";
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
                sS_MaskedTextBox_ModelName.Focus();
                sS_MaskedTextBox_ModelName.SelectAll();
            }
            catch (Exception Err)
            {
                SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
            }
        }

        private void sS_MaskedTextBox_Brand_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                Function_ShowDataInDatagridViewByBrand();

                Enm_StateForm = Enum_Mode.CellClick;
                AuthorizeState.Funtion_SetButtonAuthorize(Enm_StateForm);
            }
        }
        private void Function_ShowDataInDatagridViewByBrand()
        {
            try
            {
                DataSet Ds_Supplier = new DataSet();

                value_str = sS_MaskedTextBox_Brand.Text.ToString().Trim();


                string SQL = "SELECT modelID,modelName,brand,value FROM Model WHERE brand LIKE '%" + value_str + "%' ";

                Ds_Supplier = Manager.Engine.GetDataSet(SQL);
                if (Ds_Supplier.Tables[0].Rows.Count > 0)
                {
                    sS_DataGridView_Model.DataSource = Ds_Supplier;
                    sS_DataGridView_Model.DataMember = "Table";
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
                sS_MaskedTextBox_ModelName.Focus();
                sS_MaskedTextBox_ModelName.SelectAll();
            }
            catch (Exception Err)
            {
                SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
            }
        }

        private void Function_ShowDataInDatagridViewByValue()
        {
            try
            {
                DataSet Ds_Supplier = new DataSet();

                value_str = sS_MaskedTextBox_Value.Text.ToString().Trim();


                string SQL = "SELECT modelID,modelName,brand,value FROM Model WHERE value LIKE '%" + value_str + "%' ";

                Ds_Supplier = Manager.Engine.GetDataSet(SQL);
                if (Ds_Supplier.Tables[0].Rows.Count > 0)
                {
                    sS_DataGridView_Model.DataSource = Ds_Supplier;
                    sS_DataGridView_Model.DataMember = "Table";
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
                sS_MaskedTextBox_ModelName.Focus();
                sS_MaskedTextBox_ModelName.SelectAll();
            }
            catch (Exception Err)
            {
                SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
            }
        }

        private void sS_MaskedTextBox_Value_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                Function_ShowDataInDatagridViewByValue();

                Enm_StateForm = Enum_Mode.CellClick;
                AuthorizeState.Funtion_SetButtonAuthorize(Enm_StateForm);
            }
        }

        private string Function_GetNextRunningNo()
        {
            string nextNo = "";
            try
            {
                string qry = "SELECT Prefix, CurrentRun FROM SysRunNo WHERE RunID = 6"; // Model

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
                             "' WHERE RunId = 6"; // Model

                Manager.Engine.ExecuteCommand(qry);
            }
            catch { }

        }
    }
}