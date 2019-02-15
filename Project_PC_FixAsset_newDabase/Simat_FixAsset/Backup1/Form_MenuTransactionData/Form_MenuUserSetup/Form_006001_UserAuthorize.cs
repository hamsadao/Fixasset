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
    public partial class Form_006001_UserAuthorize : SS_PaintGradientForm
    {
        Class_AuthorizeState AuthorizeState = new Class_AuthorizeState();
        WhGroupHome WhGroupHomeObj = new WhGroupHome();
        private Enum_Mode Enm_StateForm = Enum_Mode.Search; 
        public Form_006001_UserAuthorize()
        {
            InitializeComponent();
            Function_IntitialControl();

            AuthorizeState.Function_SetAuthorize(this.Name.Substring(5, 6).Replace("0", ""));
            AuthorizeState.Funtion_SetButtonAuthorize(Enm_StateForm);
            //Global.Function_ToolStripSetUP(Enum_Mode.Search);
        }
        private void Function_IntitialControl()
        {
            DarkColor = Global.ConfigForm.Colr_BackColor;
            this.Text = Global.Function_Language(this, this, "ID:006001(UserAuthorize)");
            LBL_UserID.Text = Global.Function_Language(this, LBL_UserID, "User ID:");
            LBL_FirstName.Text = Global.Function_Language(this, LBL_FirstName, "FirstName:");
            LBL_Lastname.Text = Global.Function_Language(this, LBL_Lastname, "LastName:");
            LBL_Password.Text = Global.Function_Language(this, LBL_Password, "Password:");
            LBL_Group.Text = Global.Function_Language(this, LBL_Group, "Group:");
            LBL_Department.Text = Global.Function_Language(this, LBL_Department, "Department:");
            LBL_Company.Text = Global.Function_Language(this, LBL_Company, "Company:");
        }
        private void Form_006001_UserAutolize_FormClosed(object sender, FormClosedEventArgs e)
        {
            Global.Function_RemoveTabStripButton(this.Tag);
        }
        private void Function_ClearData()
        {
            sS_MaskedTextBox_UserID.Text = "";
            sS_MaskedTextBox_FirstName.Text = "";
            sS_MaskedTextBox_LastName.Text = "";
            sS_MaskedTextBox_Password.Text = "";
            sS_MaskedTextBox_Group.Text = "";
            sS_MaskedTextBox_GroupName.Text = "";
            sS_MaskedTextBox_DeptNo.Text = "";
            sS_MaskedTextBox_DeptName.Text = "";
            sS_MaskedTextBox_FacCode.Text = "";
            sS_MaskedTextBox_FacName.Text = "";
        }
     
        public void Function_ExecuteTransaction(Enum_Mode Enum_mode)
        {
            try
            {
                WhuserHome WhuserHomeObj = new WhuserHome();
                ScreenHome ScreenHomeObj = new ScreenHome();
                Wilson.ORMapper.Transaction ORTransaction = null;
                bool Bool_CheckExecuteComplete = false;
                object[] Obj_UserID = new object[1] { sS_MaskedTextBox_UserID.Text };
                ValidateuserinputData ValidateInput = new ValidateuserinputData(Global.ConfigPath.Str_AppPathValidate + "\\" + this.Name + ".xml", this);

                int i = 0;
                switch (Enum_mode)
                {
                    case Enum_Mode.Search:
                        break;
                    case Enum_Mode.PreAdd:
                        Function_ClearData();
                        Function_ReadOnlyControl(false);
                        sS_MaskedTextBox_UserID.Focus();
                        sS_DataGridView_UserAutolize.Rows.Clear();
                        Function_ShowScreenNameInDatagrid();
                        sS_DataGridView_UserAutolize.ReadOnly = true;
                        Enm_StateForm = Enum_Mode.PreAdd;
                        break;
                    case Enum_Mode.Add:

                        if (ValidateInput.ValidateData(Global.Lang.Str_Language))
                        {
                            ORTransaction = Manager.Engine.BeginTransaction();

                            WhuserHomeObj.WhUserobj.UsID = sS_MaskedTextBox_UserID.Text;
                            WhuserHomeObj.WhUserobj.UsFirstName = sS_MaskedTextBox_FirstName.Text;
                            WhuserHomeObj.WhUserobj.UsLastName = sS_MaskedTextBox_LastName.Text;
                            WhuserHomeObj.WhUserobj.UsPass = sS_MaskedTextBox_Password.Text;
                            WhuserHomeObj.WhUserobj.UsGroupID = sS_MaskedTextBox_Group.Text;
                            WhuserHomeObj.WhUserobj.CreatedDate = DateTime.Now.Date;
                            WhuserHomeObj.WhUserobj.DeptID = sS_MaskedTextBox_DeptNo.Text;
                            WhuserHomeObj.WhUserobj.FacCode = sS_MaskedTextBox_FacCode.Text;
                            WhuserHomeObj.WhUserobj.ActiveFlag = true;

                            Whuser TempWhuserObj = new Whuser();
                            TempWhuserObj = Manager.Engine.GetObject<Whuser>(sS_MaskedTextBox_UserID.Text);
                            if (TempWhuserObj != null)
                            {
                                SS_MyMessageBox.ShowBox("UserID : " + sS_MaskedTextBox_UserID.Text + " is duplicate data", "Warning", DialogMode.OkOnly,this.Name,"000008",Obj_UserID,Global.Lang.Str_Language);
                                Global.Bool_CheckComplete = false;
                                sS_MaskedTextBox_UserID.Focus();
                                break;
                            }
                            else
                            {

                                if (WhuserHomeObj.AddwhUser(ORTransaction))
                                    Bool_CheckExecuteComplete = true;
                                else
                                    Bool_CheckExecuteComplete = false;

                                for (i = 0; i <= sS_DataGridView_UserAutolize.Rows.Count - 1; i++)
                                {
                                    if (Convert.ToBoolean(sS_DataGridView_UserAutolize[0, i].Value) == true)
                                    {
                                        WhuserHomeObj.WhUserAccessObj.UsID = sS_MaskedTextBox_UserID.Text;
                                        WhuserHomeObj.WhUserAccessObj.ScID = Convert.ToString(sS_DataGridView_UserAutolize[1, i].Value);
                                        WhuserHomeObj.WhUserAccessObj.AddR = Convert.ToBoolean(sS_DataGridView_UserAutolize[3, i].Value);
                                        WhuserHomeObj.WhUserAccessObj.DeleteR = Convert.ToBoolean(sS_DataGridView_UserAutolize[4, i].Value);
                                        WhuserHomeObj.WhUserAccessObj.EditR = Convert.ToBoolean(sS_DataGridView_UserAutolize[5, i].Value);

                                        if (WhuserHomeObj.AddGroupAccess(ORTransaction))
                                            Bool_CheckExecuteComplete = true;
                                        else
                                            Bool_CheckExecuteComplete = false;
                                    }
                                }
                                if (Bool_CheckExecuteComplete)
                                {
                                    ORTransaction.Commit();
                                    SS_MyMessageBox.ShowBox("Add data : " + sS_MaskedTextBox_UserID.Text + " Complete", "Add Data Information", DialogMode.OkOnly, this.Name, "000001", Obj_UserID, Global.Lang.Str_Language);
                                    Global.Bool_CheckComplete = true;
                                    Enm_StateForm = Enum_Mode.PreAdd;
                                    Function_ExecuteTransaction(Enum_Mode.Cancel);
                                }
                                else
                                {
                                    SS_MyMessageBox.ShowBox("Can not add data: " + sS_MaskedTextBox_UserID.Text + " !", "Warning", DialogMode.OkOnly, this.Name, "000002", Obj_UserID, Global.Lang.Str_Language);
                                    ORTransaction.Rollback();
                                }
                            }
                        }
                        else
                            break;
                           
                            break;
                    case Enum_Mode.PreEdit:
                        Function_SetReadOnlyDatagrid();
                        sS_MaskedTextBox_UserID.ReadOnly = true;
                        sS_DataGridView_UserAutolize.ReadOnly = false;
                        Function_ReadOnlyControl(false);
                        sS_MaskedTextBox_FirstName.Focus();
                        Enm_StateForm = Enum_Mode.PreEdit;
                        break;
                    case Enum_Mode.Edit:
                        ORTransaction = Manager.Engine.BeginTransaction();
                        WhuserHomeObj.WhUserobj.UsID = sS_MaskedTextBox_UserID.Text;

                        if (WhuserHomeObj.Delete())
                        {
                            if (ValidateInput.ValidateData(Global.Lang.Str_Language))
                            {
                                WhuserHomeObj.WhUserobj.UsID = sS_MaskedTextBox_UserID.Text;
                                WhuserHomeObj.WhUserobj.UsFirstName = sS_MaskedTextBox_FirstName.Text;
                                WhuserHomeObj.WhUserobj.UsLastName = sS_MaskedTextBox_LastName.Text;
                                WhuserHomeObj.WhUserobj.UsPass = sS_MaskedTextBox_Password.Text;
                                WhuserHomeObj.WhUserobj.UsGroupID = sS_MaskedTextBox_Group.Text;
                                WhuserHomeObj.WhUserobj.CreatedDate = DateTime.Now.Date;
                                WhuserHomeObj.WhUserobj.DeptID = sS_MaskedTextBox_DeptNo.Text;
                                WhuserHomeObj.WhUserobj.FacCode = sS_MaskedTextBox_FacCode.Text;
                                WhuserHomeObj.WhUserobj.ActiveFlag = true;

                                if (WhuserHomeObj.AddwhUser(ORTransaction))
                                    Bool_CheckExecuteComplete = true;
                                else
                                    Bool_CheckExecuteComplete = false;

                                for (i = 0; i <= sS_DataGridView_UserAutolize.Rows.Count - 1; i++)
                                {
                                    if (Convert.ToBoolean(sS_DataGridView_UserAutolize[0, i].Value) == true)
                                    {
                                        WhuserHomeObj.WhUserAccessObj.UsID = sS_MaskedTextBox_UserID.Text;
                                        WhuserHomeObj.WhUserAccessObj.ScID = Convert.ToString(sS_DataGridView_UserAutolize[1, i].Value);
                                        WhuserHomeObj.WhUserAccessObj.AddR = Convert.ToBoolean(sS_DataGridView_UserAutolize[3, i].Value);
                                        WhuserHomeObj.WhUserAccessObj.DeleteR = Convert.ToBoolean(sS_DataGridView_UserAutolize[4, i].Value);
                                        WhuserHomeObj.WhUserAccessObj.EditR = Convert.ToBoolean(sS_DataGridView_UserAutolize[5, i].Value);

                                        if (WhuserHomeObj.AddGroupAccess(ORTransaction))
                                            Bool_CheckExecuteComplete = true;
                                        else
                                            Bool_CheckExecuteComplete = false;
                                    }
                                }
                                if (Bool_CheckExecuteComplete)
                                {
                                    ORTransaction.Commit();
                                    SS_MyMessageBox.ShowBox("Edit data : " + sS_MaskedTextBox_UserID.Text + " Complete", "Edit Data Information", DialogMode.OkOnly, this.Name, "000003", Obj_UserID, Global.Lang.Str_Language);
                                    Function_ClearData();
                                    sS_DataGridView_UserAutolize.Rows.Clear();
                                    sS_MaskedTextBox_UserID.Focus();
                                    Function_ShowScreenNameInDatagrid();
                                }
                                else
                                {
                                    SS_MyMessageBox.ShowBox("Can not edit data : " + sS_MaskedTextBox_UserID.Text + " !", "Warning", DialogMode.OkOnly, this.Name, "000004", Obj_UserID, Global.Lang.Str_Language);
                                    ORTransaction.Rollback();
                                }
                            }
                             
                        }
                        Enm_StateForm = Enum_Mode.PreEdit;
                        Function_ExecuteTransaction(Enum_Mode.Cancel);
                        Function_ShowScreenNameInDatagrid();
                        break;
                    case Enum_Mode.Delete:
                        if (sS_MaskedTextBox_UserID.Text != "")
                        {
                            if (SS_MyMessageBox.ShowBox("Do you want to delete : " + sS_MaskedTextBox_UserID.Text + " ?", "Delete Data Information", DialogMode.OkCancel, this.Name, "000005", Obj_UserID, Global.Lang.Str_Language) == DialogResult.OK)
                            {
                                Global.Bool_CheckComplete = true;
                                WhuserHomeObj.WhUserobj.UsID = sS_MaskedTextBox_UserID.Text;

                                if (WhuserHomeObj.Delete())
                                {
                                    SS_MyMessageBox.ShowBox("Delete data : " + sS_MaskedTextBox_UserID.Text + " ?", "Delete Data Information", DialogMode.OkOnly, this.Name, "000006", Obj_UserID, Global.Lang.Str_Language);
                                    Global.Bool_CheckComplete = true;

                                    Enm_StateForm = Enum_Mode.PreAdd;
                                    Function_ShowScreenNameInDatagrid();
                                }
                                else
                                {
                                    SS_MyMessageBox.ShowBox("Can not delete data : " + sS_MaskedTextBox_UserID.Text + " !", "Warning", DialogMode.OkOnly, this.Name, "000007", Obj_UserID, Global.Lang.Str_Language);
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
                        break;
                        //goto DEFAULT;

                    case Enum_Mode.Cancel:
                        if (Enm_StateForm == Enum_Mode.PreEdit)
                        {
                            Function_ExecuteTransaction(Enum_Mode.ShowData);
                            sS_MaskedTextBox_UserID.Focus();
                        }
                        if (Enm_StateForm == Enum_Mode.PreAdd)
                        {
                            Function_ClearData();
                            sS_DataGridView_UserAutolize.Rows.Clear();
                            sS_MaskedTextBox_UserID.Focus();
                            Function_ShowScreenNameInDatagrid();
                            
                        }
                        Function_ReadOnlyControl(true);
                        Function_SetReadOnlyDatagrid();
                        sS_DataGridView_UserAutolize.ReadOnly = true;
                        Enm_StateForm = Enum_Mode.Search;
                        break;
                    case Enum_Mode.ShowData:
                        sS_DataGridView_UserAutolize.Rows.Clear();
                        Function_ShowScreenNameInDatagrid();

                        Wilson.ORMapper.ObjectSet<WhuserAccess> TempWhuserAccessObj = Manager.Engine.GetObjectSet<WhuserAccess>("usID= '" + sS_MaskedTextBox_UserID.Text + "'");
                        Whuser WhuserObj = new Whuser();
                        WhuserObj = Manager.Engine.GetObject<Whuser>(sS_MaskedTextBox_UserID.Text);
                        if (WhuserObj != null)
                        {
                            sS_MaskedTextBox_FirstName.Text = WhuserObj.UsFirstName;
                            sS_MaskedTextBox_LastName.Text = WhuserObj.UsLastName;
                            sS_MaskedTextBox_Password.Text = WhuserObj.UsPass;
                            sS_MaskedTextBox_Group.Text = WhuserObj.UsGroupID;
                            sS_MaskedTextBox_GroupName.Text = Global.FormOrder.Function_GetGroupName(sS_MaskedTextBox_Group.Text);
                            sS_MaskedTextBox_DeptNo.Text = WhuserObj.DeptID;
                            sS_MaskedTextBox_DeptName.Text = Global.FormOrder.Function_GetDeptName(sS_MaskedTextBox_DeptNo.Text);
                            sS_MaskedTextBox_FacCode.Text = WhuserObj.FacCode;
                            sS_MaskedTextBox_FacName.Text = Global.FormOrder.Function_GetFacName(sS_MaskedTextBox_FacCode.Text);
                        }
                        if (TempWhuserAccessObj.Count > 0)
                        {
                            for (i = 0; i <= TempWhuserAccessObj.Count - 1; i++)
                            {
                
                                for (int k = 0; k <= sS_DataGridView_UserAutolize.Rows.Count - 1; k++)
                                {
                                    if (sS_DataGridView_UserAutolize[1, k].Value.ToString() == TempWhuserAccessObj[i].ScID)
                                    {
                                        sS_DataGridView_UserAutolize[0, k].Value = true;
                                        sS_DataGridView_UserAutolize[3, k].Value = TempWhuserAccessObj[i].AddR;
                                        sS_DataGridView_UserAutolize[4, k].Value = TempWhuserAccessObj[i].DeleteR;
                                        sS_DataGridView_UserAutolize[5, k].Value = TempWhuserAccessObj[i].EditR;
                                    }
                                }

                            }
                        }
                        else // เมื่อตอนทำการเพิ่มแต่ไม่ได้เช็ค screenaccess เลย 
                        {
                            Function_ShowScreenNameInDatagrid();

                        }
                        Global.Function_ToolStripSetUP(Enum_Mode.CellClick);
                        sS_MaskedTextBox_UserID.ReadOnly = true;
                        Function_SetReadOnlyDatagrid();
                        sS_DataGridView_UserAutolize.ReadOnly = true;
                        break;
                    DEFAULT:
                        Function_ClearData();
                        sS_DataGridView_UserAutolize.Rows.Clear();
                        Function_ShowScreenNameInDatagrid();
                        Function_ReadOnlyControl(true);
                        sS_MaskedTextBox_UserID.Focus();
                        sS_DataGridView_UserAutolize.ReadOnly = true;
                        Function_SetReadOnlyDatagrid();
                        break;

                }
            }
            catch (Exception Ex)
            {
                SS_MyMessageBox.ShowBox(Ex.Message, "Error on Internal Transfer Order Execute Transaction", DialogMode.Error_Cancel, Ex);
            }
        }
       
        private void Function_SetReadOnlyDatagrid()
        {
            sS_DataGridView_UserAutolize.Columns[1].ReadOnly = true;
            sS_DataGridView_UserAutolize.Columns[2].ReadOnly = true;
        }

        /// <summary>
        /// Function for When user choose group and show value by whGroup_Access 
        /// 20/06/2007
        /// </summary>
        private void Function_ScreenGroupShow()
        {
            sS_DataGridView_UserAutolize.Rows.Clear();
            Function_ShowScreenNameInDatagrid();
            WhGroupHomeObj.WhGroupObj = Manager.Engine.GetObject<WhGroup>(sS_MaskedTextBox_Group.Text);
            if (WhGroupHomeObj.WhGroupObj.WhgroupAccesses.Count > 0)
            {
                for (int i = 0; i <= WhGroupHomeObj.WhGroupObj.WhgroupAccesses.Count - 1; i++)
                {
                    WhGroupHomeObj.WhgroupAccessObj = (WhgroupAccess)WhGroupHomeObj.WhGroupObj.WhgroupAccesses[i];

                    for (int k = 0; k <= sS_DataGridView_UserAutolize.Rows.Count - 1; k++)
                    {
                        if (sS_DataGridView_UserAutolize[1, k].Value.ToString() == WhGroupHomeObj.WhgroupAccessObj.ScID)
                        {
                            sS_DataGridView_UserAutolize[0, k].Value = true;
                            sS_DataGridView_UserAutolize[3, k].Value = WhGroupHomeObj.WhgroupAccessObj.AddR;
                            sS_DataGridView_UserAutolize[4, k].Value = WhGroupHomeObj.WhgroupAccessObj.DeleteR;
                            sS_DataGridView_UserAutolize[5, k].Value = WhGroupHomeObj.WhgroupAccessObj.EditR;
                        }
                    }

                }
            }
            else // เมื่อตอนทำการเพิ่มแต่ไม่ได้เช็ค screenaccess เลย 
            {
                Function_ShowScreenNameInDatagrid();
            }
            Function_SetReadOnlyDatagrid();
            //Function_ReadOnlyControl(true);

        }
        private void Form_006001_UserAutolize_Load(object sender, EventArgs e)
        {
            Global.Location.Int_CountForm = Global.Location.Int_CountForm + 0;
            Function_ShowScreenNameInDatagrid();
            sS_DataGridView_UserAutolize.ReadOnly = true;
            Function_ReadOnlyControl(true);
            Function_SetReadOnlyDatagrid();

        }
        private void Function_ReadOnlyControl(bool Bool_ReadOnly)
        {
            sS_MaskedTextBox_FirstName.ReadOnly = Bool_ReadOnly;
            sS_MaskedTextBox_LastName.ReadOnly = Bool_ReadOnly;
            sS_MaskedTextBox_Password.ReadOnly = Bool_ReadOnly;
           
        }
        private void Function_ShowScreenNameInDatagrid()
        {
            DataSet ds = new DataSet();

            ds = Manager.Engine.GetDataSet<SimatSoft.DB.ORM.Screen>("");

            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                Object[] Rows = new Object[] { false, ds.Tables[0].Rows[i].ItemArray[0], ds.Tables[0].Rows[i].ItemArray[2], false, false, false };

                sS_DataGridView_UserAutolize.Rows.Add(Rows);
            }

        }
        private void sS_MaskedTextBox_Group_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if ((e.KeyCode == Keys.F1)&&((Enm_StateForm ==Enum_Mode.PreAdd)||(Enm_StateForm ==Enum_Mode.PreEdit)))
                {
                    SimatSoft.QueryManager.Form_Present Frm_Present = new SimatSoft.QueryManager.Form_Present();
                    Frm_Present.Controlreturnvalue = sS_MaskedTextBox_Group;
                    Frm_Present.Controlreturnvalue2 = sS_MaskedTextBox_GroupName;
                    Frm_Present.Show_Data("Screen", "006002");

                    Frm_Present.ShowDialog();
                    Frm_Present.Dispose();
                    if (sS_MaskedTextBox_Group.Text != "")
                    {
                        Function_ScreenGroupShow();
                        sS_DataGridView_UserAutolize.ReadOnly = false;
                    }
                }
            }
            catch (Exception Ex)
            {
                SS_MyMessageBox.ShowBox(Ex.Message, "Error On Purchase Order Select PO", DialogMode.Error_Cancel, Ex);
            }
        }

        private void sS_MaskedTextBox_UserID_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1) 
                {
                    SimatSoft.QueryManager.Form_Present Frm_Present = new SimatSoft.QueryManager.Form_Present();
                    Frm_Present.Controlreturnvalue = sS_MaskedTextBox_UserID;
                    Frm_Present.Controlreturnvalue2 = sS_MaskedTextBox_FirstName;
                    Frm_Present.Controlreturnvalue3 = sS_MaskedTextBox_LastName;
                    Frm_Present.Controlreturnvalue4 = sS_MaskedTextBox_Password;
                    Frm_Present.Controlreturnvalue5 = sS_MaskedTextBox_Group;
                    Frm_Present.Controlreturnvalue6 = sS_MaskedTextBox_DeptNo;
                    Frm_Present.Controlreturnvalue7 = sS_MaskedTextBox_FacCode;

                    Frm_Present.Show_Data("Screen", "006001");
                    Frm_Present.ShowDialog();

                    Frm_Present.Dispose();

                    if (sS_MaskedTextBox_UserID.Text != "")
                    {
                       sS_MaskedTextBox_FacName.Text = Global.FormOrder.Function_GetFacName(sS_MaskedTextBox_FacCode.Text);
                       sS_MaskedTextBox_GroupName.Text = Global.FormOrder.Function_GetGroupName(sS_MaskedTextBox_Group.Text);
                       sS_MaskedTextBox_DeptName.Text = Global.FormOrder.Function_GetDeptName(sS_MaskedTextBox_DeptNo.Text);
                       Function_ExecuteTransaction(Enum_Mode.ShowData);
                    }
                }

               
            }
            catch (Exception Ex)
            {
                SS_MyMessageBox.ShowBox(Ex.Message, "Error On Purchase Order Select PO", DialogMode.Error_Cancel, Ex);
            }
        }

       

        private void sS_MaskedTextBox_DeptNo_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.F1) && ((Enm_StateForm == Enum_Mode.PreAdd) || (Enm_StateForm == Enum_Mode.PreEdit)))
            {
                SimatSoft.QueryManager.Form_Present Frm_Present = new SimatSoft.QueryManager.Form_Present();
                Frm_Present.Controlreturnvalue = sS_MaskedTextBox_DeptNo;
                Frm_Present.Controlreturnvalue2 = sS_MaskedTextBox_DeptName;
                Frm_Present.Show_Data("Screen", "002010");

                Frm_Present.ShowDialog();
                Frm_Present.Dispose();
            }
        }

        private void sS_MaskedTextBox_FacCode_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.F1) && ((Enm_StateForm == Enum_Mode.PreAdd) || (Enm_StateForm == Enum_Mode.PreEdit)))
            {
                SimatSoft.QueryManager.Form_Present Frm_Present = new SimatSoft.QueryManager.Form_Present();
                Frm_Present.Controlreturnvalue = sS_MaskedTextBox_FacCode;
                Frm_Present.Controlreturnvalue2 = sS_MaskedTextBox_FacName;
                Frm_Present.Show_Data("Screen", "002006");

                Frm_Present.ShowDialog();
                Frm_Present.Dispose();
            }
        }
       

        private void sS_DataGridView_UserAutolize_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            bool Bool_Check = false;    
            if ((e.ColumnIndex == 0)&&((Enm_StateForm ==Enum_Mode.PreAdd)||(Enm_StateForm ==Enum_Mode.PreEdit)))
            {
                if (e.RowIndex != -1)
                {
                    sS_DataGridView_UserAutolize[e.ColumnIndex, e.RowIndex].Value = !Convert.ToBoolean(sS_DataGridView_UserAutolize[e.ColumnIndex, e.RowIndex].Value);
                    if (Convert.ToBoolean(sS_DataGridView_UserAutolize[0, e.RowIndex].Value) == true)
                        Bool_Check = true;
                    else
                        Bool_Check = false;
                }
                sS_DataGridView_UserAutolize[3, e.RowIndex].Value = Bool_Check;
                sS_DataGridView_UserAutolize[4, e.RowIndex].Value = Bool_Check;
                sS_DataGridView_UserAutolize[5, e.RowIndex].Value = Bool_Check;
            }
        }

        private void Form_006001_UserAuthorize_Activated(object sender, EventArgs e)
        {
            AuthorizeState.Funtion_SetButtonAuthorize(Enm_StateForm);
        }

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            bool Bool_Check = false;
            if (((Enm_StateForm == Enum_Mode.PreAdd) | (Enm_StateForm == Enum_Mode.PreEdit)))
            {
                for (int i = 0; i <= Convert.ToUInt32(sS_DataGridView_UserAutolize.RowCount.ToString()) - 1; i++)
                {
                    Bool_Check = true;
                    this.sS_DataGridView_UserAutolize[0, i].Value = Bool_Check;
                    for (int n = 3; n <= 5; n++)
                    {
                        sS_DataGridView_UserAutolize[n, i].Value = Bool_Check;
                    }
                }
            }
        }

        private void btnDiselect_Click(object sender, EventArgs e)
        {
            bool Bool_Check = true;
            if (((Enm_StateForm == Enum_Mode.PreAdd) | (Enm_StateForm == Enum_Mode.PreEdit)))
            {
                for (int i = 0; i <= Convert.ToUInt32(sS_DataGridView_UserAutolize.RowCount.ToString()) - 1; i++)
                {
                    Bool_Check = false;
                    sS_DataGridView_UserAutolize[0, i].Value = Bool_Check;
                    for (int n = 3; n <= 5; n++)
                    {
                        sS_DataGridView_UserAutolize[n, i].Value = Bool_Check;
                    }
                }
            }
        }

        private void Form_006001_UserAuthorize_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Global.Location.Int_CountForm > 0)
            {
                Global.Location.Int_CountForm = Global.Location.Int_CountForm - 1;
            }
        }
   }
}